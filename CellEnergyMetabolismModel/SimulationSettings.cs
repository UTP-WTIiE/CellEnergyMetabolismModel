using System;
using System.Collections.Generic;
using System.Text;

namespace CellEnergyMetabolismModel
{
    public class SimulationSettings
    {
        public const double CGlycDefaultLowLevel = 4.0;

        public bool RunGlycolysis { get; set; } = true;
        public bool RunPPP { get; set; } = true;
        public bool RunKrebs { get; set; } = true;
        public bool RunFattyAcids { get; set; } = true;
        public bool KeepGLCLevel { get; set; } = false;

        public bool PPPTurnOnG6PBalancingFlow { get; set; } = false;
        public bool KrebsRunCitBalance { get; set; } = false;
        public bool KeepC16AcylCoAcyt { get; set; } = false;
        public bool KrebsRunOxoBalance { get; set; } = false;
        public bool BetaOxidationAccoaBalance { get; set; } = false;
        public double CGlycLowLevel { get; set; } = SimulationSettings.CGlycDefaultLowLevel;
        public bool FillZerosWithDelta { get; set; } = false;

        public string Summarize()
        {
            var sb = new StringBuilder();

            if (RunGlycolysis == false)
                sb.Append("_gstop");
            if (RunPPP == false)
                sb.Append("_pppstop");
            if (RunKrebs == false)
                sb.Append("_kstop");
            if (RunFattyAcids == false)
                sb.Append("_fastop");
            if (KeepGLCLevel == true)
                sb.Append("_glcfill");
            if (KrebsRunCitBalance)
                sb.Append("_krebscitbalanceon");
            if (KrebsRunOxoBalance)
                sb.Append("_krebsoxobalanceon");
            if (KeepC16AcylCoAcyt)
                sb.Append("_c16acylcoacytfill");
            if (BetaOxidationAccoaBalance)
                sb.Append("_betaoxidationaccoabalance");
            if (CGlycLowLevel != CGlycDefaultLowLevel)
                sb.Append($"_cglyclowlevel{CGlycLowLevel}");
            if (FillZerosWithDelta)
                sb.Append("_fillzeroswithdelta");

            return sb.ToString();
        }
    }
}
