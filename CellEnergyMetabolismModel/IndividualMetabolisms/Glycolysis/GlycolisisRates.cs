using System;
using System.Collections.Generic;
using System.Text;

namespace CellEnergyMetabolismModel.IndividualMetabolisms.Glycolysis
{
    public static class GlycolisisRates
    {

        public static double rate_0(double C_MgATP, double C_GLC, double C_MgADP, double C_G6P, double C_G16BP, double C_23BPG, double C_GSH, double[] Const_0)
        {
            double a = C_MgATP / Const_0[3-1];
            double b = C_GLC / Const_0[4-1];
            double c = C_MgADP / Const_0[5-1];
            double d = C_G6P / Const_0[6-1];
            double e = C_G6P / Const_0[7-1];
            double f = C_G16BP / Const_0[8-1];
            double g = C_23BPG / Const_0[10-1];
            double h = C_GLC / Const_0[4-1];
            double i = C_GSH / Const_0[9-1];
            double V0 = (Const_0[1-1] * a * b - Const_0[2-1] * c * d) * (1 / (1 + a + e + b + a * b + c + c * d + b * d + h * f + h * g + h * i));

            return V0;
        }
        public static double g6p_rate(double c_gl, double c_g6p)
        {
            double Vmf = 262.1443;
            double Ka = 0.14;
            double Kb = 1.00;
            double Kp = 0.02;
            double Kq = 3.5;
            double Keq = 651;
            double A = c_gl;
            double B = 2.5;// 0.159;
            double P = c_g6p;
            double Q = 0.5;// 0.0937;
            double v = 5 * Vmf * (A * B - P * Q / Keq);
            v = v / (1 + A / Ka + B / Kb + A * B / Ka / Kb + P / Kp + Q / Kq + P * Q / Kp / Kq + A * Q / Ka / Kq + P * B / Kp / Kb);
            return v / 3600;
        }

        public static double rate_1(double c_g6p, double c_f6p, double[] const1)
        {
            double a = c_g6p / const1[2];
            double b = c_f6p / const1[3];
            double V1 = 0.0890 * (a * const1[0] - b * const1[1]) / (1 + a + b);

            return V1 / 3600;
        }

        public static double rate_2(double C_MgATP, double C_F6P, double C_MgADP, double C_F16BP, double C_ATP, double C_Mg, double C_23BPG, double C_AMP, double C_G16BP, double C_Pi, double C_F26BP, double[] Const_2)
        {
            // Function to calculate rate V1. 
            // C_MgATP, C_F6P, C_MgADP, C_F16BP, C_ATP, C_Mg, C_23BPG, C_AMP, C_G16BP,
            // C_Pi, C_F26BP are the input concentrations and Const_2 is a matrix of
            // kinetc constants to calculate rate_2.
            // The constants should be input before invoking the function rate_2.
            //
            // Const_2(1) - V_f ^ PFK
            // Const_2(2) - V_r ^ PFK
            // Const_2(3) - K_F6P ^ PFK
            // Const_2(4) - K_MgATP ^ PFK
            // Const_2(5) - K_MgADP ^ PFK
            // Const_2(6) - K_F16BP ^ PFK
            // Const_2(7) - K_F26BP ^ PFK
            // Const_2(8) - K_G16BP ^ PFK
            // Const_2(9) - K_ATP ^ PFK
            // Const_2(10) - K_AMP ^ PFK
            // Const_2(11) - K_Mg ^ PFK
            // Const_2(12) - K_Pi ^ PFK
            // Const_2(13) - K_23BPG ^ PFK
            // Const_2(14) - L_PFK
            //
            // L_PFK represents the equilitbrium constant between the two states of the
            // enzyme in the absece of any substrates.
            // This function will be called in every step of the simulation.

            double a = C_MgATP / Const_2[4-1];
            double b = C_F6P / Const_2[3-1];
            double c = C_MgADP / Const_2[5-1];
            double d = C_F16BP / Const_2[6-1];
            double e = C_ATP / Const_2[9-1];
            double f = C_Mg / Const_2[11-1];
            double g = C_23BPG / Const_2[13-1];
            double h = C_AMP / Const_2[10-1];
            double i = C_G16BP / Const_2[8-1];
            double j = C_Pi / Const_2[12-1];
            double k = C_F26BP / Const_2[7-1];
            //2.515 *
            double V2 = 18.7479 * ((Const_2[1-1] * a * b - Const_2[2-1] * c * d) / ((1 + b) * (1 + a) + (1 + d) * (1 + c) - 1)) * (1 / (1 + (((Const_2[14-1] * (Math.Pow((1 + e), 4)) * (Math.Pow((1 + f), 4)) * (Math.Pow((1 + g), 4))) / ((Math.Pow((1 + b + d), 4)) * (Math.Pow((1 + h), 4)) * (Math.Pow((1 + i), 4)) * (Math.Pow((1 + j), 4)) * (Math.Pow((1 + k), 4)))))));
            return V2 / 3600;
        }

        public static double rate_3A(double C_ATP, double C_F6P, double C_ADP, double C_F26BP, double C_PEP, double C_pAkt, double[] Const_3A)
        {
            // Function to calculate rate V3(PFK2).
            // C_ATP, C_F6P, C_ADP, C_F26BP, C_PEP are the input concentrations and
            // Const_3A is a matrix of kinetic constants to calculate rate V3A.
            // The constants should be input before invoking the function rate_3A.
            //
            // Const_3A(1) - V_f ^ PFK2
            // Const_3A(2) - K_m,ATP ^ PFK2
            // Const_3A(3) - K_m,F6P ^ PFK2
            // Const_3A(4) - K_m,F26BP ^ PFK2
            // Const_3A(5) - K_m,ADP ^ PFK2
            // Const_3A(6) - K_i,ATP ^ PFK2
            // Const_3A(7) - K_i,F6P ^ PFK2
            // Const_3A(8) - K_i,F26BP ^ PFK2
            // Const_3A(9) - K_i,ADP ^ PFK2
            // Const_3A(10) - K_i,PEP ^ PFK2
            // Const_3A(11) - K_eq ^ PFK2
            // K_Akt = m = 0.5
            //
            // This function will be calculated in every step of the simulation.

            double a = C_ATP * C_F6P;
            double b = (C_ADP * C_F26BP) / Const_3A[11-1];
            double c = C_ATP * Const_3A[3-1];
            double d = C_F6P * Const_3A[2-1];
            double e = (C_F26BP * Const_3A[5-1]) / Const_3A[11-1];
            double f = (C_ADP * Const_3A[4-1]) / Const_3A[11-1];
            double g = C_ATP / Const_3A[6-1];
            double h = C_ADP / Const_3A[9-1];
            double i = C_F26BP / Const_3A[8-1];
            double j = C_F6P / Const_3A[7-1];
            double k = C_PEP / Const_3A[10-1];
            double m = 0.5; // K_Akt

            double V3A = (Const_3A[1-1] * (a - b) * (0.2 + (0.8 / (1 + m / C_pAkt)))) / ((Const_3A[6-1] * Const_3A[3-1] + c + d + e + f + a + e * g + b + d * h + a * i + b * j) * (1 + k));

            return V3A / 3600;
        }

        public static double rate_3B(double C_F26BP, double C_F6P, double[] Const_3B, double C_PEP, double[] Const_3A)
        {
            // Function to calculate rate V3B.
            // C_F26BP and C_F6P are input concentrations and Const_3B is a matrix of
            // kinetic constants to calculate rate 3B.

            // Const_3B(1) - V_F26BPase
            // Const_3B(2) - K_m,F26BP ^ F26BPase
            // Const_3B(3) - K_i,F6P ^ F26BPase

            // This function will be called in every step of the simulation.

            double a = C_F26BP * Const_3B[1-1];
            double b = C_F6P / Const_3B[3-1];
            double c = C_F26BP + Const_3B[2-1];
            double k = C_PEP / Const_3A[10-1];
            double V3B = 0.6 * (a) / (((1 + b) * c) * (1 + 10 * k)) * 14.0772 * C_F26BP / 0.004;// 4.2693;
            return V3B / 3600;
        }

        public static double rate_4(double C_F16BP, double C_GAP, double C_DHAP, double C_23BPG, double[] Const_4)
        {
            // Funtion to calculate V4(Aldoslase).
            // 
            // C_F16BP, C_GAP, C_DHAP, C_23BPG are input concentrations.
            // Const_4 is a matrix of kinetic constants to calculate V4.
            // The constants should be input before invoking the function rate_4.
            // 
            // Const_4[1-1] - V_mf ^ ALD
            // Const_4[2-1] - V_mr ^ ALD
            // Const_4[3-1] - K_F16BP ^ ALD
            // Const_4[4-1] - K_i,F16BP ^ ALD
            // Const_4[5-1] - K_DHAP ^ ALD
            // Const_4[6-1] - K_i,DHAP ^ ALD
            // Const_4[7-1] - K_GAP ^ ALD
            // Const_4[8-1] - K_i,23BPG ^ ALD
            // 
            // This function will be called in every step of the simulation.

            double a = C_F16BP / Const_4[3-1];
            double b = C_GAP / Const_4[7-1];
            double c = C_DHAP / Const_4[6-1];
            double d = C_23BPG / Const_4[8-1];
            double e = C_F16BP / Const_4[4-1];
            double f = Const_4[5-1] / Const_4[6-1];
            double V4 = 7.6341 * ((Const_4[2-1] * a) - (Const_4[1-1] * b * c)) / (1 + d + a + (f * b) * (1 + d) + c + (f * e * b) + (c * b));

            return V4 / 3600;
        }

        public static double rate_5(double C_DHAP, double C_GAP, double[] Const_5)
        {
            // Function to calculate rate V5(Triose Phosphate Isomerase). 
            // C_DHAP and C_GAP are the input concentrations and Const_5 is the matrix
            // of kinetic constants to calculate rate V5.
            // The constants should be input before invoking the function rate_5.
            // 
            // Const_5[1-1] - V_mf ^ TPI
            // Const_5[2-1] - V_mr ^ TPI
            // Const_5[3-1] - K_f ^ TPI
            // Const_5[4-1] - K_r ^ TPI
            // 
            // This function will be called inevery step of the simulation

            double a = C_DHAP / Const_5[3-1];
            double b = C_GAP / Const_5[4-1];
            double V5 = 2.5356 * (Const_5[1-1] * a - Const_5[2-1] * b) / (1 + a + b);

            return V5 / 3600;
        }

        public static double rate_6(double C_NAD, double C_Pi, double C_GAP, double C_13BPG, double C_NADH, double C_H, double[] Const_6)
        {
            // Function to calculate rate V6(Glyceraldehyde 3-Phosphate Dehydrogenase).
            // C_NAD, C_Pi, C_GAP, C_13BPG, C_NADH, C_H are input concentrations and
            // Const_6 is a matrix of kinetic consstants to calculate rate V6. 
            // The constants should be input before invoking the function rate_6.
            //
            // Const_6[1-1]-V_mf^GAPD
            // Const_6[2-1]-V_mr^GAPD
            // Const_6[3-1]-K_NAD^GAPD
            // Const_6[4-1]-K_i,NAD^GAPD
            // Const_6[5-1]-K_Pi^GAPD
            // Const_6[6-1]-K_i,Pi^GAPD
            // Const_6[7-1]-K_GAP^GAPD
            // Const_6[8-1]-K_i,GAP^GAPD
            // Const_6[9-1]-K_i,GAP^'GAPD
            // Const_6[10-1]-K_NADH^GAPD
            // Const_6[11-1]-K_i,NADH^GAPD
            // Const_6[12-1]-K_13BPG^GAPD
            // Const_6[13-1]-K_i,13BPG^GAPD
            // Const_6[14-1]-K_i,13BPG^'GAPD
            // Const_6[15-1]-K_eq^GAPD
            // This function will be called in every step of the simulation 

            double a=C_NAD/Const_6[3-1];
            double b=C_Pi/Const_6[6-1];
            double c=C_GAP/Const_6[8-1];
            double d=C_13BPG/Const_6[13-1];
            double e=(C_NADH*C_H)/Const_6[10-1];
            double f=(C_NADH*C_H)/Const_6[11-1];
            double g=C_GAP/Const_6[9-1];
            double h=C_NAD/Const_6[4-1];
            double i=1/Const_6[14-1];
            double j=C_13BPG/Const_6[14-1];
            double k=Const_6[12-1]/Const_6[13-1];
            double l=Const_6[7-1]/Const_6[8-1];
            double V6=9.9570*(Const_6[1-1]*a*b*c-Const_6[2-1]*d*e)/(c*(1+g)+d*(1+g)+k*e+l*a*b+h*c+b*c*(1+g)+h*d+k*b*e+c*f+d*e+a*b*c+l*a*b*j+b*c*f+d*e*b*i);

            return V6 / 3600;
        }

        public static double rate_7(double C_13BPG, double C_MgADP, double C_3PG, double C_MgATP, double[] Const_7)
        {
            // Function to calculate rate V7(Phosphoglycerate Kinase). 
            // C_13BPG, C_MgADP, C_3PG, C_MgATP are input concentrations and Const_7 is
            // a matrix of kinetic constants to calculate rate V7. 
            // The constants should be input before invoking the function rate_7.
            //
            // Const_7[1-1]-V_mf^PGK
            // Const_7[2-1]-V_mr^PGK
            // Const_7[3-1]-K_MgADP^PGK
            // Const_7[4-1]-K_i,MgADP^PGK
            // Const_7[5-1]-K_13BPG^PGK
            // Const_7[6-1]-K_i,13BPG^PGK
            // Const_7[7-1]-K_MgATP^PGK
            // Const_7[8-1]-K_i,MgATP^PGK
            // Const_7[9-1]-K_3PG^PGK
            // Const_7[10-1]-K_i,3PG^PGK
            // Const_7[11-1]-K_eq^PGK
            //
            // This function will be called in every step of the simulation 

            double a=C_13BPG/Const_7[5-1];
            double b=C_MgADP/Const_7[4-1];
            double c=C_3PG/Const_7[9-1];
            double d=C_MgATP/Const_7[8-1];
            double e=C_13BPG/Const_7[6-1];
            double f=C_3PG/Const_7[10-1];
            double V7=1.10*(Const_7[1-1]*a*b-Const_7[2-1]*c*d)/(1+e+b+a*b+f+d+c*d);
            return V7 / 3600;
        }

        public static double rate_8(double C_3PG, double C_2PG, double[] Const_8)
        {
            // Function to calculate rate V8(Phosphoglycerate Mutase).
            // C_3PG, C_2PG are the input concentrations and Const_8 is a matrix of
            // kinetic constants to calculate rate V_8. 
            // The constants should be input before invoking the function rate_8.
            //
            // Const_8[1-1]-V_mf^PGAM
            // Const_8[2-1]-V_mr^PGAM
            // Const_8[3-1]-K_3PG^PGAM
            // Const_8[4-1]-K_2PG^PGAM
            // Const_8[5-1]-K_eq^PGAM
            //
            // This function will be called in every step of the simulation 

            double a=C_3PG/Const_8[3-1];
            double b=C_2PG/Const_8[4-1];
            double V8=0.795*(Const_8[1-1]*a-Const_8[2-1]*b)/(1+a+b)/45.9476;

            return V8 / 3600;
        }

        public static double rate_9(double C_2PG, double C_Mg, double C_PEP, double[] Const_9)
        {
            // Function to calculate rate V9(Enolase).
            // C_2PG, C_Mg, C_PEP are input concentrations and Const_9 is a matrix of
            // kinetic constants to calculate rate V9.
            // The constants should be input before invoking the function rate_9.
            //
            // Const_9(1)-V_mf^ENO
            // Const_9(2)-V_mr^ENO
            // Const_9(3)-K_i,Mg^ENO
            // Const_9(4)-K_PEP^ENO
            // Const_9(5)-K_2PG^ENO
            // Const_9(6)-K_eq^ENO
            //
            // This function will be called in every step of the simulation. 

            double a=C_2PG/Const_9[5-1];
            double b=C_Mg/Const_9[3-1];
            double c=C_PEP/Const_9[4-1];
            double d=C_2PG/Const_9[5-1];

            // No reported value for i,2PG or i,PEP. (Possible error in the paper?)

            double V9= 0.2161*(Const_9[1-1]*a*b-Const_9[2-1]*c*b)/(1+d+b+d*b+c+b+c*b);

            return V9 / 3600;
        }

        public static double rate_10(double C_PEP, double C_MgADP, double C_PYR, double C_MgATP, double C_ATP, double C_ALA, double C_F16BP, double C_G16BP, double[] Const_10)
        {
            // Function to calculate rate V10. 
            // C_PEP, C_MgADP, C_PYR, C_MgATP, C_ATP, C_ALA, C_F16BP, C_G16BP are input
            // concentrations and Const_10 is a matrix of kinetic constants to
            // calculate V10.
            // The constants should be input before invoking the function rate_10. 
            //
            // Const_10(1)-V_mf^PK
            // Const_10(2)-V_mr^PK
            // Const_10(3)-K_PEP^PK
            // Const_10(4)-K_MgADP^PK
            // Const_10(5)-K_MgATP^PK
            // Const_10(6)-K_ATP^PK
            // Const_10(7)-K_PYR^PK
            // Const_10(8)-K_F16BP^PK
            // Const_10(9)-K_G16BP^PK
            // Const_10(10)-K_ALA^PK
            // Const_10(11)-L_PK
            //
            // This function will be called in every step of the simulation. 

            double a=C_PEP/Const_10[3-1];
            double b=C_MgADP/Const_10[4-1];
            double c=C_PYR/Const_10[7-1];
            double d=C_MgATP/Const_10[5-1];
            double e=C_ATP/Const_10[6-1];
            double f=C_ALA/Const_10[10-1];
            double g=C_F16BP/Const_10[8-1];
            double h=C_G16BP/Const_10[9-1];
            double V10=358.8748*((Const_10[1-1]*a*b-Const_10[2-1]*c*d) / ((1+a)*(1+b)+(1+c)*(1+d)-1))*(1/ (1+Const_10[11-1]*(((Math.Pow((1+e),4))*(Math.Pow((1+f),4))) / ((Math.Pow((1+a+c),4))*(Math.Pow((1+g+h),4))))));

            return V10 / 3600;
        }

    }
}
