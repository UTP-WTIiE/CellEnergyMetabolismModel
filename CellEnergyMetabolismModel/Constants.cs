using CellEnergyMetabolismModel.IndividualMetabolisms.FattyAcidsOxidation;
using CellEnergyMetabolismModel.IndividualMetabolisms.Glycolysis;
using CellEnergyMetabolismModel.IndividualMetabolisms.KrebsCycle.Functions;
using CellEnergyMetabolismModel.IndividualMetabolisms.KrebsCycle.Structs;
using CellEnergyMetabolismModel.IndividualMetabolisms.PPP.Structs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CellEnergyMetabolismModel
{
    public class Constants
    {
        public FattyAcidConstantsSimplifiedSeparated FattyAcidConsts { get; set; }
        public GlycolysisConstants GlycolysisConstants { get; set; }
        public KrebsConstants KrebsConstants { get; set; }
        public PPPConstants PPPConstants { get; set; }

        private FattyAcidStateComputerSimplifiedSeparated facomputer;
        private GlycolysisComputation glycomputer;

        Random b = new Random();

        public SimulationSettings Settings { get; private set; }
        private double cglycLowLevel => Settings != null ? Settings.CGlycLowLevel : SimulationSettings.CGlycDefaultLowLevel;


        public static Constants LiteratureStart(CellState start, double noise = 0)
        {
            var f = FattyAcidConstantsSimplifiedSeparated.GetTrainedConstants();
            var g = new GlycolysisConstants();
            var k = KrebsConstants.DefaultConstants();
            var p = PPPConstants.GetLiteratureConstants();

            return new Constants(f, g, k, p, start, noise);
        }

        public void SetSettings(SimulationSettings settings)
        {
            Settings = settings;
            PPPConstants.Settings = Settings;
            facomputer.turn_on_accoa_balancing_flow = settings.BetaOxidationAccoaBalance;
        }

        public Constants()
        {
            
        }

        public Constants(FattyAcidConstantsSimplifiedSeparated fattyAcidConsts, GlycolysisConstants glycolysisConstants, KrebsConstants krebsConstants, PPPConstants pPPConstants, CellState start, double noise = 0) : this()
        {
            FattyAcidConsts = fattyAcidConsts ?? throw new ArgumentNullException(nameof(fattyAcidConsts));
            GlycolysisConstants = glycolysisConstants ?? throw new ArgumentNullException(nameof(glycolysisConstants));
            KrebsConstants = krebsConstants ?? throw new ArgumentNullException(nameof(krebsConstants));
            PPPConstants = pPPConstants ?? throw new ArgumentNullException(nameof(pPPConstants));

            this.facomputer = new FattyAcidStateComputerSimplifiedSeparated(this.FattyAcidConsts, noise);
            this.facomputer.SetCurrentState(start);

            this.glycomputer = new GlycolysisComputation(start, GlycolysisConstants);

            SetSettings(new SimulationSettings());
        }

        public CellState ComputeStep(CellState state)
        {
            var a = state;

            // values to be filled again
            var nadp = a.NADP;
            var c16acylcoacyt = a.C16AcylCoACYT;
            var glc = a.C_GLC;

            // if glycolysis is below 4 do the FattyAcidConsts
            // otherwise do Glycolysis and PPP

            bool glc_level_low = state.C_GLC < cglycLowLevel;
            bool run_beta_oxidation = glc_level_low;

            if (run_beta_oxidation)
            {
                if (Settings.RunFattyAcids)
                {
                    var fastate = facomputer.ComputeQueues();
                    a.Fill(fastate);
                }
            }
            else
            {
                if (Settings.RunGlycolysis)
                {
                    var glycstate = glycomputer.ComputeOneGlycolysisTimestep(a, this.GlycolysisConstants, 0.001);
                    a.Fill(glycstate);
                }
                if (Settings.RunPPP)
                {
                    var pppstate = PPPConstants.ComputeOneTimeStep(a.GetPPP(), () => b.NextDouble(), modify_input_products: true, rate3_inhibition: 0, keep_f6p_unchanged: false);
                    a.Fill(pppstate);
                }
            }

            if (Settings.RunKrebs)
            {
                var rates = ComputeRates.ComputeReduced(a, KrebsConstants);
                var kq = new KrebsComputeQueues2();
                kq.IsBetaOxidationPathwayActivated = run_beta_oxidation;
                var krebs_result = kq.ComputeReduced(a, rates, Settings.KrebsRunCitBalance, Settings.KrebsRunOxoBalance);
                a.Fill(krebs_result);
            }

            // filling again
            a.NADP = nadp;
            //a.C16AcylCoACYT = c16acylcoacyt;
            if (Settings.KeepGLCLevel)
                a.C_GLC = glc;
            if (Settings.KeepC16AcylCoAcyt)
                a.C16AcylCoACYT = c16acylcoacyt;

            facomputer.SetCurrentState(a);
            return a;
        }

        private string[] fattyacidsRatesNames() => FattyAcidStateComputerSimplifiedSeparated.GetRatesNames().Select(x => $"FA: {x}").ToArray();
        private string[] glycolysisRatesNames() => new string[] {
            "g6p_rate",
            "rate_1",
            "rate_2",
            "rate_3A",
            "rate_3B",
            "rate_4",
            "rate_5",
            "rate_6",
            "rate_7",
            "rate_9",
            "rate_10",
        }.Select(x=> $"GLYCOLYSIS: {x}").ToArray();

        private string[] pppRatesNames() => new string[]
        {
            "G6P + NADP -> PGL + NADPH",
            "PGL + H20 -> 6PG + H",
            "6PG + NADP -> OR5P + NADPH + H + CO2",
            "OR5P -> R5P",
            "OR5P -> X5P",
            "X5P + R5P -> G3P + S7P",
            "X5P + E4P -> G3P + F6P",
            "S7P + G3P -> E4P + F6P",
            "G3PBalancingFlow",
            "F6PBalancingFlow",
            "E4PBalancingFlow",
            "G6PBalancingFlow",
            "R5PBalancingFlow",
            "S7PBalancingFlow"
        }.Select(x=>$"PPP: {x}").ToArray();

        private string[] krebsRatesNames() => new string[]
        {
            "PYR -> ACCOA",
            "PYR -> OXO",
            "ACCOA + OXO -> CIT",
            "CIT -> ISO",
            "ISO -> KETO",
            "KETO -> SCA",
            "SCA -> FUM",
            "FUM -> MAL",
            "MAL -> OXO",
            "OXO BALANCE",
            "CIT BALANCE"
        }.Select(x => $"KREBS: {x}").ToArray();

        public string[] GetRatesNames(double c_glyc_level)
        {
            var names = new List<string>();

        //if (c_glyc_level < 4)
            fattyacidsRatesNames().ToList().ForEach(x => names.Add(x));
        //else
        //{
            glycolysisRatesNames().ToList().ForEach(x => names.Add(x));
            pppRatesNames().ToList().ForEach(x => names.Add(x));
        //}

            krebsRatesNames().ToList().ForEach(x => names.Add(x));

            return names.ToArray();
        }

        public double[] GetRates(CellState start, CellState state, double noise = 0)
        {
            List<double> rates = new List<double>();

        //if (state.C_GLC < 4)
        //{
            var fc = new FattyAcidStateComputerSimplifiedSeparated(this.FattyAcidConsts, noise);
            fc.SetCurrentState(state);
            fc.GetRates().ToList().ForEach(x => rates.Add(x));
        //}
        //else
        //{
            var gc = new GlycolysisComputation(state, GlycolysisConstants);
            gc.ComputeRates(state, GlycolysisConstants).ToList().ForEach(x => rates.Add(x));

            PPPConstants.GetRatesList().Select(x => x.CalculateRate(state)).ToList().ForEach(x => rates.Add(x));
        //}

            ComputeRates.ComputeReduced(state, KrebsConstants).ToArray().ToList().ForEach(x => rates.Add(x));

            return rates.ToArray();
        }
    }
}
