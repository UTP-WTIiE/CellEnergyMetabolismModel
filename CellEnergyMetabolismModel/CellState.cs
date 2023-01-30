using CellEnergyMetabolismModel.IndividualMetabolisms.FattyAcidsOxidation;
using CellEnergyMetabolismModel.IndividualMetabolisms.Glycolysis;
using CellEnergyMetabolismModel.IndividualMetabolisms.KrebsCycle.Functions;
using CellEnergyMetabolismModel.IndividualMetabolisms.KrebsCycle.Structs;
using CellEnergyMetabolismModel.IndividualMetabolisms.PPP.Structs;
using CellEnergyMetabolismModel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CellEnergyMetabolismModel
{
    public struct CellState : IKrebsCellState, IGlycolysisCellState, IPPPCellState, IFattyAcidsCellState
    {
        public static int[] constantsIndices = new int[] { 
            16,17,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35, 37, 44, 76, 77
        };
        public static CellState LiteratureState()
        {
            var a = new CellState();

            var g = new GlycolysisCellState();
            a.Fill(g);

            var k = KrebsProducts.Default();
            a.Fill(k);

            var p = PPPCellState.Default();
            a.Fill(p);

            var f = FattyAcidState.LiteratureStart();
            a.Fill(f);

            a.C_G6P = g.C_G6P;
            a.Accoa = 0.07;
            a.Keto = 0.03;

            return a;
        }

        public CellState(double[] data)
        {
            Pyr = data[0];
            Accoa = data[1];
            Oxo = data[2];
            Cit = data[3];
            Iso = data[4];
            Keto = data[5];
            Sca = data[6];
            Fum = data[7];
            Mal = data[8];

            // GLYCOLYSIS
            C_GLC = data[9];
            C_G6P = data[10];
            C_F6P = data[11];
            C_F16BP = data[12];
            C_26BP = data[13];
            C_GAP = data[14];
            C_DHAP = data[15];
            C_13BPG = data[16];
            C_3PG = data[17];
            C_2PG = data[18];
            C_PEP = data[19];
            C_MgATP = data[20];
            C_MgADP = data[21];
            C_NAD = data[22];
            C_NADH = data[23];
            C_Pi = data[24];
            C_Mg = data[25];
            C_ATP = data[26];
            C_ADP = data[27];
            C_AMP = data[28];
            C_H = data[29];
            C_F26BP = data[30];
            C_23BPG = data[31];
            C_GSH = data[32];
            C_ALA = data[33];
            C_G16BP = data[34];

            // PPP
            NADP = data[35];
            PGL = data[36];
            NADPH = data[37];
            _6GP = data[38];
            OR5P = data[39];
            R5P = data[40];
            X5P = data[41];
            S7P = data[42];
            E4P = data[43];
            CO2 = data[44];

            //FATTY ACIDS
            C16AcylCoACYT = data[45];
            C16AcylCarCYT = data[46];
            C16AcylCarMAT = data[47];
            C16AcylCoAMAT = data[48];
            C16EnoylCoAMAT = data[49];
            C16HydroxyacylCoAMAT = data[50];
            C16KetoacylCoAMAT = data[51];
            C14AcylCoAMAT = data[52];
            C14EnoylCoAMAT = data[53];
            C14HydroxyacylCoAMAT = data[54];
            C14KetoacylCoAMAT = data[55];
            C12AcylCoAMAT = data[56];
            C12EnoylCoAMAT = data[57];
            C12HydroxyacylCoAMAT = data[58];
            C12KetoacylCoAMAT = data[59];
            C10AcylCoAMAT = data[60];
            C10EnoylCoAMAT = data[61];
            C10HydroxyacylCoAMAT = data[62];
            C10KetoacylCoAMAT = data[63];
            C8AcylCoAMAT = data[64];
            C8EnoylCoAMAT = data[65];
            C8HydroxyacylCoAMAT = data[66];
            C8KetoacylCoAMAT = data[67];
            C6AcylCoAMAT = data[68];
            C6EnoylCoAMAT = data[69];
            C6HydroxyacylCoAMAT = data[70];
            C6KetoacylCoAMAT = data[71];
            C4AcylCoAMAT = data[72];
            C4EnoylCoAMAT = data[73];
            C4HydroxyacylCoAMAT = data[74];
            C4AcetoacylCoAMAT = data[75];
            FADHMAT = data[76];
            NADHMAT = data[77];
        }

        

        // KREBS
        public double Pyr { get ; set ; }
        public double Accoa { get ; set ; }
        public double Oxo { get ; set ; }
        public double Cit { get ; set ; }
        public double Iso { get ; set ; }
        public double Keto { get ; set ; }
        public double Sca { get ; set ; }
        public double Fum { get ; set ; }
        public double Mal { get ; set ; }

        // GLYCOLYSIS
        public double C_GLC { get ; set ; }
        public double C_G6P { get ; set ; }
        public double C_F6P { get ; set ; }
        public double C_F16BP { get ; set ; }
        public double C_26BP { get ; set ; }
        public double C_GAP { get ; set ; }
        public double C_DHAP { get ; set ; }
        public double C_13BPG { get ; set ; }
        public double C_3PG { get ; set ; }
        public double C_2PG { get ; set ; }
        public double C_PEP { get ; set ; }
        //public double C_PYR { get ; set ; }
        public double C_MgATP { get ; set ; }
        public double C_MgADP { get ; set ; }
        public double C_NAD { get ; set ; }
        public double C_NADH { get ; set ; }
        public double C_Pi { get ; set ; }
        public double C_Mg { get ; set ; }
        public double C_ATP { get ; set ; }
        public double C_ADP { get ; set ; }
        public double C_AMP { get ; set ; }
        public double C_H { get ; set ; }
        public double C_F26BP { get ; set ; }
        public double C_23BPG { get ; set ; }
        public double C_GSH { get ; set ; }
        public double C_ALA { get ; set ; }
        public double C_G16BP { get ; set ; }


        // PPP
        //public double G6P { get ; set ; }
        public double NADP { get ; set ; }
        public double PGL { get ; set ; }
        public double NADPH { get ; set ; }
        public double _6GP { get ; set ; }
        public double OR5P { get ; set ; }
        public double R5P { get ; set ; }
        public double X5P { get ; set ; }
        //public double G3P { get ; set ; }
        public double S7P { get ; set ; }
        public double E4P { get ; set ; }
        //public double F6P { get ; set ; }
        public double CO2 { get ; set ; }

        //FATTY ACIDS
        public double C16AcylCoACYT { get ; set ; }
        public double C16AcylCarCYT { get ; set ; }
        public double C16AcylCarMAT { get ; set ; }
        public double C16AcylCoAMAT { get ; set ; }
        public double C16EnoylCoAMAT { get ; set ; }
        public double C16HydroxyacylCoAMAT { get ; set ; }
        public double C16KetoacylCoAMAT { get ; set ; }
        public double C14AcylCoAMAT { get ; set ; }
        public double C14EnoylCoAMAT { get ; set ; }
        public double C14HydroxyacylCoAMAT { get ; set ; }
        public double C14KetoacylCoAMAT { get ; set ; }
        public double C12AcylCoAMAT { get ; set ; }
        public double C12EnoylCoAMAT { get ; set ; }
        public double C12HydroxyacylCoAMAT { get ; set ; }
        public double C12KetoacylCoAMAT { get ; set ; }
        public double C10AcylCoAMAT { get ; set ; }
        public double C10EnoylCoAMAT { get ; set ; }
        public double C10HydroxyacylCoAMAT { get ; set ; }
        public double C10KetoacylCoAMAT { get ; set ; }
        public double C8AcylCoAMAT { get ; set ; }
        public double C8EnoylCoAMAT { get ; set ; }
        public double C8HydroxyacylCoAMAT { get ; set ; }
        public double C8KetoacylCoAMAT { get ; set ; }
        public double C6AcylCoAMAT { get ; set ; }
        public double C6EnoylCoAMAT { get ; set ; }
        public double C6HydroxyacylCoAMAT { get ; set ; }
        public double C6KetoacylCoAMAT { get ; set ; }
        public double C4AcylCoAMAT { get ; set ; }
        public double C4EnoylCoAMAT { get ; set ; }
        public double C4HydroxyacylCoAMAT { get ; set ; }
        public double C4AcetoacylCoAMAT { get ; set ; }
        //public double AcetylCoAMAT { get ; set ; }
        public double FADHMAT { get ; set ; }
        public double NADHMAT { get ; set ; }



        double IGlycolysisCellState.C_PYR { get => Pyr; set => Pyr = value; }
        double IPPPCellState.G6P { get => C_G6P; set => C_G6P = value; }
        double IFattyAcidsCellState.AcetylCoAMAT { get => Accoa; set => Accoa = value; }
        double IPPPCellState.G3P { get => C_GAP; set => C_GAP = value; }
        double IPPPCellState.F6P { get => C_F6P; set => C_F6P = value; }

        public CellState FillZerosWithOneDeltaMinimalValue()
        {
            var data = GetState();

            // Krebs
            for (int i = 0; i < 9; i++)
                data[i] = Math.Max(data[i], KrebsComputeQueues2._delta);

            // Glycolysis
            for (int i = 9; i < 35; i++)
                data[i] = Math.Max(data[i], GlycolysisComputation.delta);

            // PPP
            for (int i = 35; i < 45; i++)
                data[i] = Math.Max(data[i], 1e-6);

            // Fatty Acids
            for (int i = 45; i < 78; i++)
                data[i] = Math.Max(data[i], FattyAcidStateComputerSimplifiedSeparated.delta);

            return new CellState(data);
        } 

        public double[] GetState()
        {
            var data = new double[78];

            data[0] = Pyr;
            data[1] = Accoa;
            data[2] = Oxo;
            data[3] = Cit;
            data[4] = Iso;
            data[5] = Keto;
            data[6] = Sca;
            data[7] = Fum;
            data[8] = Mal;

            // GLYCOLYSIS
            data[9] = C_GLC;
            data[10] = C_G6P;
            data[11] = C_F6P;
            data[12] = C_F16BP;
            data[13] = C_26BP;
            data[14] = C_GAP;
            data[15] = C_DHAP;
            data[16] = C_13BPG;
            data[17] = C_3PG;
            data[18] = C_2PG;
            data[19] = C_PEP;
            data[20] = C_MgATP;
            data[21] = C_MgADP;
            data[22] = C_NAD;
            data[23] = C_NADH;
            data[24] = C_Pi;
            data[25] = C_Mg;
            data[26] = C_ATP;
            data[27] = C_ADP;
            data[28] = C_AMP;
            data[29] = C_H;
            data[30] = C_F26BP;
            data[31] = C_23BPG;
            data[32] = C_GSH;
            data[33] = C_ALA;
            data[34] = C_G16BP;

            // PPP
            data[35] = NADP;
            data[36] = PGL;
            data[37] = NADPH;
            data[38] = _6GP;
            data[39] = OR5P;
            data[40] = R5P;
            data[41] = X5P;
            data[42] = S7P;
            data[43] = E4P;
            data[44] = CO2;

            //FATTY ACIDS
            data[45] = C16AcylCoACYT;
            data[46] = C16AcylCarCYT;
            data[47] = C16AcylCarMAT;
            data[48] = C16AcylCoAMAT;
            data[49] = C16EnoylCoAMAT;
            data[50] = C16HydroxyacylCoAMAT;
            data[51] = C16KetoacylCoAMAT;
            data[52] = C14AcylCoAMAT;
            data[53] = C14EnoylCoAMAT;
            data[54] = C14HydroxyacylCoAMAT;
            data[55] = C14KetoacylCoAMAT;
            data[56] = C12AcylCoAMAT;
            data[57] = C12EnoylCoAMAT;
            data[58] = C12HydroxyacylCoAMAT;
            data[59] = C12KetoacylCoAMAT;
            data[60] = C10AcylCoAMAT;
            data[61] = C10EnoylCoAMAT;
            data[62] = C10HydroxyacylCoAMAT;
            data[63] = C10KetoacylCoAMAT;
            data[64] = C8AcylCoAMAT;
            data[65] = C8EnoylCoAMAT;
            data[66] = C8HydroxyacylCoAMAT;
            data[67] = C8KetoacylCoAMAT;
            data[68] = C6AcylCoAMAT;
            data[69] = C6EnoylCoAMAT;
            data[70] = C6HydroxyacylCoAMAT;
            data[71] = C6KetoacylCoAMAT;
            data[72] = C4AcylCoAMAT;
            data[73] = C4EnoylCoAMAT;
            data[74] = C4HydroxyacylCoAMAT;
            data[75] = C4AcetoacylCoAMAT;
            data[76] = FADHMAT;
            data[77] = NADHMAT;

            return data;
        }

        public double[] GetStateWithoutConstants()
        {
            var data = GetState();
            var ci = constantsIndices;

            var noConsts = data.Select((x, i) => ci.Contains(i) ? -1 : x).Where(x=>x >= 0).ToArray();
            return noConsts;
        }

        public static string[] GetHeader()
        {
            var data = new string[78];

            data[0] = "Pyr";
            data[1] = "Accoa";
            data[2] = "Oxo";
            data[3] = "Cit";
            data[4] = "Iso";
            data[5] = "Keto";
            data[6] = "Sca";
            data[7] = "Fum";
            data[8] = "Mal";

            // GLYCOLYSIS
            data[9] = "C_GLC";
            data[10] = "C_G6P";
            data[11] = "C_F6P";
            data[12] = "C_F16BP";
            data[13] = "C_26BP";
            data[14] = "C_GAP";
            data[15] = "C_DHAP";
            data[16] = "C_13BPG";
            data[17] = "C_3PG";
            data[18] = "C_2PG";
            data[19] = "C_PEP";
            data[20] = "C_MgATP";
            data[21] = "C_MgADP";
            data[22] = "C_NAD";
            data[23] = "C_NADH";
            data[24] = "C_Pi";
            data[25] = "C_Mg";
            data[26] = "C_ATP";
            data[27] = "C_ADP";
            data[28] = "C_AMP";
            data[29] = "C_H";
            data[30] = "C_F26BP";
            data[31] = "C_23BPG";
            data[32] = "C_GSH";
            data[33] = "C_ALA";
            data[34] = "C_G16BP";

            // PPP
            data[35] = "NADP";
            data[36] = "PGL";
            data[37] = "NADPH";
            data[38] = "_6GP";
            data[39] = "OR5P";
            data[40] = "R5P";
            data[41] = "X5P";
            data[42] = "S7P";
            data[43] = "E4P";
            data[44] = "CO2";

            //FATTY ACIDS
            data[45] = "C16AcylCoACYT";
            data[46] = "C16AcylCarCYT";
            data[47] = "C16AcylCarMAT";
            data[48] = "C16AcylCoAMAT";
            data[49] = "C16EnoylCoAMAT";
            data[50] = "C16HydroxyacylCoAMAT";
            data[51] = "C16KetoacylCoAMAT";
            data[52] = "C14AcylCoAMAT";
            data[53] = "C14EnoylCoAMAT";
            data[54] = "C14HydroxyacylCoAMAT";
            data[55] = "C14KetoacylCoAMAT";
            data[56] = "C12AcylCoAMAT";
            data[57] = "C12EnoylCoAMAT";
            data[58] = "C12HydroxyacylCoAMAT";
            data[59] = "C12KetoacylCoAMAT";
            data[60] = "C10AcylCoAMAT";
            data[61] = "C10EnoylCoAMAT";
            data[62] = "C10HydroxyacylCoAMAT";
            data[63] = "C10KetoacylCoAMAT";
            data[64] = "C8AcylCoAMAT";
            data[65] = "C8EnoylCoAMAT";
            data[66] = "C8HydroxyacylCoAMAT";
            data[67] = "C8KetoacylCoAMAT";
            data[68] = "C6AcylCoAMAT";
            data[69] = "C6EnoylCoAMAT";
            data[70] = "C6HydroxyacylCoAMAT";
            data[71] = "C6KetoacylCoAMAT";
            data[72] = "C4AcylCoAMAT";
            data[73] = "C4EnoylCoAMAT";
            data[74] = "C4HydroxyacylCoAMAT";
            data[75] = "C4AcetoacylCoAMAT";
            data[76] = "FADHMAT";
            data[77] = "NADHMAT";

            return data;
        }

        public static string[] GetHeaderWithoutConstants()
        {
            var data = GetHeader();
            var ci = constantsIndices;

            var noConsts = data.Select((x, i) => ci.Contains(i) ? null : x).Where(x => x != null).ToArray();
            return noConsts;
        }
        public void Fill(IKrebsCellState c)
        {
            this.Pyr = c.Pyr;
            this.Accoa = c.Accoa;
            this.Oxo = c.Oxo;
            this.Cit = c.Cit;
            this.Iso = c.Iso;
            this.Keto = c.Keto;
            this.Sca = c.Sca;
            this.Fum = c.Fum;
            this.Mal = c.Mal;
        }

        public void Fill(IGlycolysisCellState c)
        {
            this.C_GLC = c.C_GLC;
            this.C_G6P = c.C_G6P;
            this.C_F6P = c.C_F6P;
            this.C_F16BP = c.C_F16BP;
            this.C_26BP = c.C_26BP;
            this.C_GAP = c.C_GAP;
            this.C_DHAP = c.C_DHAP;
            this.C_13BPG = c.C_13BPG;
            this.C_3PG = c.C_3PG;
            this.C_2PG = c.C_2PG;
            this.C_PEP = c.C_PEP;
            this.Pyr = c.C_PYR;
            this.C_MgATP = c.C_MgATP;
            this.C_MgADP = c.C_MgADP;
            this.C_NAD = c.C_NAD;
            this.C_NADH = c.C_NADH;
            this.C_Pi = c.C_Pi;
            this.C_Mg = c.C_Mg;
            this.C_ATP = c.C_ATP;
            this.C_ADP = c.C_ADP;
            this.C_AMP = c.C_AMP;
            this.C_H = c.C_H;
            this.C_F26BP = c.C_F26BP;
            this.C_23BPG = c.C_23BPG;
            this.C_GSH = c.C_GSH;
            this.C_ALA = c.C_ALA;
            this.C_G16BP = c.C_G16BP;
        }

        public void Fill(IPPPCellState c)
        {
            this.C_G6P = c.G6P;
            this.NADP = c.NADP;
            this.PGL = c.PGL;
            this.NADPH = c.NADPH;
            this._6GP = c._6GP;
            this.OR5P = c.OR5P;
            this.R5P = c.R5P;
            this.X5P = c.X5P;
            this.C_GAP = c.G3P;
            this.S7P = c.S7P;
            this.E4P = c.E4P;
            this.C_F6P = c.F6P;
            this.CO2 = c.CO2;
        }

        public void Fill(IFattyAcidsCellState c)
        {
            this.C16AcylCoACYT = c.C16AcylCoACYT;
            this.C16AcylCarCYT = c.C16AcylCarCYT;
            this.C16AcylCarMAT = c.C16AcylCarMAT;
            this.C16AcylCoAMAT = c.C16AcylCoAMAT;
            this.C16EnoylCoAMAT = c.C16EnoylCoAMAT;
            this.C16HydroxyacylCoAMAT = c.C16HydroxyacylCoAMAT;
            this.C16KetoacylCoAMAT = c.C16KetoacylCoAMAT;
            this.C14AcylCoAMAT = c.C14AcylCoAMAT;
            this.C14EnoylCoAMAT = c.C14EnoylCoAMAT;
            this.C14HydroxyacylCoAMAT = c.C14HydroxyacylCoAMAT;
            this.C14KetoacylCoAMAT = c.C14KetoacylCoAMAT;
            this.C12AcylCoAMAT = c.C12AcylCoAMAT;
            this.C12EnoylCoAMAT = c.C12EnoylCoAMAT;
            this.C12HydroxyacylCoAMAT = c.C12HydroxyacylCoAMAT;
            this.C12KetoacylCoAMAT = c.C12KetoacylCoAMAT;
            this.C10AcylCoAMAT = c.C10AcylCoAMAT;
            this.C10EnoylCoAMAT = c.C10EnoylCoAMAT;
            this.C10HydroxyacylCoAMAT = c.C10HydroxyacylCoAMAT;
            this.C10KetoacylCoAMAT = c.C10KetoacylCoAMAT;
            this.C8AcylCoAMAT = c.C8AcylCoAMAT;
            this.C8EnoylCoAMAT = c.C8EnoylCoAMAT;
            this.C8HydroxyacylCoAMAT = c.C8HydroxyacylCoAMAT;
            this.C8KetoacylCoAMAT = c.C8KetoacylCoAMAT;
            this.C6AcylCoAMAT = c.C6AcylCoAMAT;
            this.C6EnoylCoAMAT = c.C6EnoylCoAMAT;
            this.C6HydroxyacylCoAMAT = c.C6HydroxyacylCoAMAT;
            this.C6KetoacylCoAMAT = c.C6KetoacylCoAMAT;
            this.C4AcylCoAMAT = c.C4AcylCoAMAT;
            this.C4EnoylCoAMAT = c.C4EnoylCoAMAT;
            this.C4HydroxyacylCoAMAT = c.C4HydroxyacylCoAMAT;
            this.C4AcetoacylCoAMAT = c.C4AcetoacylCoAMAT;
            this.Accoa = c.AcetylCoAMAT;
            this.FADHMAT = c.FADHMAT;
            this.NADHMAT = c.NADHMAT;
        }

        public PPPCellState GetPPP()
        {
            var c = new PPPCellState();
            c.G6P = this.C_G6P;
            c.NADP = this.NADP;
            c.PGL = this.PGL;
            c.NADPH = this.NADPH;
            c._6GP = this._6GP;
            c.OR5P = this.OR5P;
            c.R5P = this.R5P;
            c.X5P = this.X5P;
            c.G3P = this.C_GAP;
            c.S7P = this.S7P;
            c.E4P = this.E4P;
            c.F6P = this.C_F6P;
            c.CO2 = this.CO2;

            return c;
        }

        public static CellState operator + (CellState a, CellState b)
        {
            var da = a.GetState();
            var db = b.GetState();

            var dc = da.Zip(db, (x, y) => x + y).ToArray();
            return new CellState(dc);
        }

        public static CellState operator / (CellState a, double b)
        {
            var da = a.GetState();
            var dc = da.Select(x => x / b).ToArray();

            return new CellState(dc);
        }
    }
}
