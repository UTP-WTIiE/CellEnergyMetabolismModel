using CellEnergyMetabolismModel.IndividualMetabolisms.FattyAcidsOxidation;
using CellEnergyMetabolismModel.IndividualMetabolisms.KrebsCycle.Structs;
using CellEnergyMetabolismModel.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CellEnergyMetabolismModel.IndividualMetabolisms.KrebsCycle.Functions
{
    public class KrebsComputeQueues2
    {
        public static double _delta = 0.0001;
        public bool IsBetaOxidationPathwayActivated { get; set; }
        public double delta => IsBetaOxidationPathwayActivated ? _delta / FattyAcidState.conversion_rate : _delta;

        public IKrebsCellState ComputeReduced(IKrebsCellState p, KrebsRates r, bool run_cit_balance, bool run_oxo_balance)
        {
            double r0 = _queue_non_reversable(r.Pyr_Accoa, p.Pyr);
            double r1 = _queue_non_reversable(r.Pyr_Oxo, p.Pyr);
            double r2 = _queue_non_reversable(r.AccoaOxo_Cit, p.Accoa, p.Oxo);
            double r3 = _queue_non_reversable(r.Cit_Iso, p.Cit);
            double r4 = _queue_non_reversable(r.Iso_Keto, p.Iso);
            double r5 = _queue_non_reversable(r.Keto_Sca, p.Keto);
            double r6 = _queue_non_reversable(r.Sca_Fum, p.Sca);
            double r7 = _queue_non_reversable(r.Fum_Mal, p.Fum);
            double r8 = _queue_non_reversable(r.Mal_Oxo, p.Mal);

            double b2 = 0;
            double b3 = 0;

            if (run_oxo_balance)
            {
                b2 = _queue_non_reversable(r.OxoBalance, p.Oxo);
            }

            if (run_cit_balance)
            {
                b3 = _queue_non_reversable(r.CitBalance, p.Cit);
            }

            p.Pyr += -1 * r0 - r1;
            p.Accoa += r0 - r2;
            p.Oxo += r1 - r2 + r8 - b2;
            p.Cit += r2 - r3 - b3;
            p.Iso += r3 - r4;
            p.Keto += r4 - r5;
            p.Sca += r5 - r6;
            p.Fum += r6 - r7;
            p.Mal += r7 - r8;

            return p;
        }

        public double _queue_non_reversable(double rate, double q1)
        {
            if (r(rate) && q1 > delta)
                return delta;
            else
                return 0;
        }

        public double _queue_non_reversable(double rate, double q1, double q2)
        {
            if (r(rate) && q1 > delta && q2 > delta)
                return delta;
            else
                return 0;
        }

        private static bool r(double rate)
        {
            return new Random().NextDouble() < rate;
        }
    }
}
