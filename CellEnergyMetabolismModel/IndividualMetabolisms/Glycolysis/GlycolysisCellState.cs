using CellEnergyMetabolismModel.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CellEnergyMetabolismModel.IndividualMetabolisms.Glycolysis
{
    public class GlycolysisCellState : IGlycolysisCellState
    {
        public double C_GLC{ get; set; } = 5;
        public double C_G6P{ get; set; } = 0.039;
        public double C_F6P{ get; set; } = 0.013;
        public double C_F16BP{ get; set; } = 0.00231;
        public double C_26BP{ get; set; } = 0.004;
        /// <summary>
        /// In other words it is G3P
        /// </summary>
        public double C_GAP{ get; set; } = 1.94e-3;
        public double C_DHAP{ get; set; } = 0.02;
        public double C_13BPG{ get; set; } = 0.000369;
        public double C_3PG{ get; set; } = 0.069;
        public double C_2PG{ get; set; } = 0.010;
        public double C_PEP{ get; set; } = 0.017;
        public double C_PYR{ get; set; } = 0.085;
        public double C_MgATP{ get; set; } = 1.52;
        public double C_MgADP{ get; set; } = 0.110;
        public double C_NAD{ get; set; } = 0.0599;
        public double C_NADH{ get; set; } = 0.000245;
        public double C_Pi{ get; set; } = 1.0;
        public double C_Mg{ get; set; } = 0.40;
        public double C_ATP{ get; set; } = 0.159;
        public double C_ADP{ get; set; } = 0.0937;
        public double C_AMP{ get; set; } = 0.03;
        public double C_H{ get; set; } = 7.2121*10e-5;
        public double C_F26BP{ get; set; } = 0.004;
        public double C_23BPG{ get; set; } = 3.10;
        public double C_GSH{ get; set; } = 3.20;
        public double C_ALA{ get; set; } = 0.2;
        public double C_G16BP{ get; set; } = 0.106;

        public string[] SubstrateNames => new string[] {
            "C_GLC",
            "C_G6P",
            "C_F6P",
            "C_F16BP",
            "C_26BP",
            "C_GAP",
            "C_DHAP",
            "C_13BPG",
            "C_3PG",
            "C_2PG",
            "C_PEP",
            "C_PYR",
            "C_MgATP",
            "C_MgADP",
            "C_NAD",
            "C_NADH",
            "C_Pi",
            "C_Mg",
            "C_ATP",
            "C_ADP",
            "C_AMP",
            "C_H",
            "C_F26BP",
            "C_23BPG",
            "C_GSH",
            "C_ALA",
            "C_G16BP"
        };

        public double[] State => new double[] {
            C_GLC,
            C_G6P,
            C_F6P,
            C_F16BP,
            C_26BP,
            C_GAP,
            C_DHAP,
            C_13BPG,
            C_3PG,
            C_2PG,
            C_PEP,
            C_PYR,
            C_MgATP,
            C_MgADP,
            C_NAD,
            C_NADH,
            C_Pi,
            C_Mg,
            C_ATP,
            C_ADP,
            C_AMP,
            C_H,
            C_F26BP,
            C_23BPG,
            C_GSH,
            C_ALA,
            C_G16BP
        };

        public GlycolysisCellState Copy()
        {
            var a = new GlycolysisCellState();
            a.C_GLC = this.C_GLC;
            a.C_G6P = this.C_G6P;
            a.C_F6P = this.C_F6P;
            a.C_F16BP = 0.00231;
            a.C_26BP = this.C_26BP;
            a.C_GAP = this.C_GAP;
            a.C_DHAP = this.C_DHAP;
            a.C_13BPG = this.C_13BPG;
            a.C_3PG = this.C_3PG;
            a.C_2PG = this.C_2PG;
            a.C_PEP = this.C_PEP;
            a.C_PYR = this.C_PYR;
            a.C_MgATP = this.C_MgATP;
            a.C_MgADP = this.C_MgADP;
            a.C_NAD = this.C_NAD;
            a.C_NADH = this.C_NADH;
            a.C_Pi = this.C_Pi;
            a.C_Mg = this.C_Mg;
            a.C_ATP = this.C_ATP;
            a.C_ADP = this.C_ADP;
            a.C_AMP = this.C_AMP;
            a.C_H = this.C_H;
            a.C_F26BP = this.C_F26BP;
            a.C_23BPG = this.C_23BPG;
            a.C_GSH = this.C_GSH;
            a.C_ALA = this.C_ALA;
            a.C_G16BP = this.C_G16BP;

            return a;
        }
    }
}
