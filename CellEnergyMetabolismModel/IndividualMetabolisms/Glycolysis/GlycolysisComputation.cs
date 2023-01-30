using CellEnergyMetabolismModel.IndividualMetabolisms.IrsMtorc;
using CellEnergyMetabolismModel.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CellEnergyMetabolismModel.IndividualMetabolisms.Glycolysis
{
    public class GlycolysisComputation
    {
        public readonly double[] V;
        public readonly double[] Vout;

        static double Akt_pinh=0;
        double C_GLC=5;
        double C_G6P=0.039;
        double C_F6P=0.013;
        double C_F16BP=0.00231;
        double C_26BP=0.004;
        double C_GAP=1.94e-3;
        double C_DHAP=0.02;
        double C_13BPG=0.000369;
        double C_3PG=0.069;
        double C_2PG=0.010;
        double C_PEP=0.017;
        double C_PYR=0.085;
        double C_MgATP=1.52;
        double C_MgADP=0.110;
        double C_NAD=0.0599;
        double C_NADH=0.000245;
        double C_Pi=1.0;
        double C_Mg=0.40;
        double C_ATP=0.159;
        double C_ADP=0.0937;
        double C_AMP=0.03;
        double C_H=7.2121*10e-5;
        double C_F26BP=0.004;
        double C_23BPG=3.10;
        double C_GSH=3.20;
        double C_ALA=0.2;
        double C_G16BP=0.106;
        double C_Akt=(1-Akt_pinh)*100;

        public static double delta = 0.001;

        public GlycolysisComputation(IGlycolysisCellState startState, GlycolysisConstants consts)
        {
            double Akt_pinh = 0;
            double C_Akt = (1 - Akt_pinh) * 100;

            V = new double[]
            {
                GlycolisisRates.g6p_rate(startState.C_GLC,startState.C_G6P),
                GlycolisisRates.rate_1(C_G6P, C_F6P, consts.Const_1),
                GlycolisisRates.rate_2(startState.C_MgATP, startState.C_F6P, startState.C_MgADP, startState.C_F16BP, startState.C_ATP, startState.C_Mg, startState.C_23BPG, startState.C_AMP, startState.C_G16BP, startState.C_Pi, startState.C_F26BP, consts.Const_2),
                GlycolisisRates.rate_3A(startState.C_ATP, startState.C_F6P, startState.C_ADP, startState.C_F26BP, startState.C_PEP, C_Akt, consts.Const_3A),
                GlycolisisRates.rate_3B(startState.C_F26BP, startState.C_F6P, consts.Const_3B, startState.C_PEP, consts.Const_3A),
                GlycolisisRates.rate_4(startState.C_F16BP, startState.C_GAP, startState.C_DHAP, startState.C_23BPG, consts.Const_4),
                GlycolisisRates.rate_5(startState.C_DHAP, startState.C_GAP, consts.Const_5),
                GlycolisisRates.rate_6(startState.C_NAD, startState.C_Pi, startState.C_GAP, startState.C_13BPG, startState.C_NADH, startState.C_H, consts.Const_6),
                GlycolisisRates.rate_7(startState.C_13BPG, startState.C_MgADP, startState.C_3PG, startState.C_MgATP, consts.Const_7),
                GlycolisisRates.rate_8(startState.C_3PG, startState.C_2PG, consts.Const_8),
                GlycolisisRates.rate_9(startState.C_2PG, startState.C_Mg, startState.C_PEP, consts.Const_9),
                GlycolisisRates.rate_10(startState.C_PEP, startState.C_MgADP, startState.C_PYR, startState.C_MgATP, startState.C_ATP, startState.C_ALA, startState.C_F16BP, startState.C_G16BP, consts.Const_10)
            };

            Vout = new double[]
            {
                V[1-1] - V[2-1],
                V[2-1] + V[5-1] - V[3-1] - V[4-1],
                V[4-1] - V[5-1],
                V[3-1] - V[6-1],
                V[6-1] + V[7-1] - V[8-1],
                V[6-1] - V[7-1],
                V[8-1] - V[9-1],
                V[9-1] - V[10-1],
                V[10-1] - V[11-1],
                V[11-1] - V[12-1],
                V[12-1]
            };

        }

        public double[] ComputeRates(IGlycolysisCellState state, GlycolysisConstants constants)
        {
            return new double[] {
                GlycolisisRates.g6p_rate(state.C_GLC, state.C_G6P),
                GlycolisisRates.rate_1(state.C_G6P, state.C_F6P, constants.Const_1),
                GlycolisisRates.rate_2(C_MgATP, state.C_F6P, C_MgADP, state.C_F16BP, state.C_ATP, C_Mg, C_23BPG, C_AMP, C_G16BP, C_Pi, state.C_26BP, constants.Const_2),
                GlycolisisRates.rate_3A(state.C_ATP, state.C_F6P, state.C_ADP, state.C_26BP, state.C_PEP, C_Akt, constants.Const_3A),
                GlycolisisRates.rate_3B(state.C_26BP, state.C_F6P, constants.Const_3B, state.C_PEP, constants.Const_3A),
                GlycolisisRates.rate_4(state.C_F16BP, state.C_GAP, state.C_DHAP, C_23BPG, constants.Const_4),
                GlycolisisRates.rate_5(state.C_DHAP, state.C_GAP, constants.Const_5),
                GlycolisisRates.rate_6(C_NAD, C_Pi, state.C_GAP, state.C_13BPG, C_NADH, C_H, constants.Const_6),
                GlycolisisRates.rate_7(state.C_13BPG, C_MgADP, state.C_2PG * 0.1 / 0.169, C_MgATP, constants.Const_7),
                GlycolisisRates.rate_9(state.C_2PG * 0.069 / 0.169, C_Mg, state.C_PEP, constants.Const_9),
                GlycolisisRates.rate_10(state.C_PEP, C_MgADP, state.C_PYR, C_MgATP, state.C_ATP, C_ALA, state.C_F16BP, C_G16BP, constants.Const_10)
            };

        }

        public IGlycolysisCellState ComputeOneGlycolysisTimestep(IGlycolysisCellState state, GlycolysisConstants constants, double delta_1)
        {
            double v1 = 0;
            double v2 = 0;
            double v3 = 0;
            double v = 0;

            v1 = GlycolisisRates.g6p_rate(state.C_GLC, state.C_G6P);
            var q1 = GlycolysisQueues.queue_1(state.C_GLC, state.C_G6P, v1, Vout[1-1], delta_1, state.C_G6P);
            state.C_GLC = q1.Q1;
            state.C_G6P = q1.Q2;

            v1 = GlycolisisRates.rate_1(state.C_G6P, state.C_F6P, constants.Const_1);
            v2 = GlycolisisRates.rate_3A(state.C_ATP, state.C_F6P, state.C_ADP, state.C_26BP, state.C_PEP, C_Akt, constants.Const_3A);
            v3 = GlycolisisRates.rate_3B(state.C_26BP, state.C_F6P, constants.Const_3B, state.C_PEP, constants.Const_3A);
            var q2 = GlycolysisQueues.queue_F6P(state.C_G6P, state.C_F6P, state.C_26BP, v1, Vout[2-1], v2, v3, Vout[3-1], delta_1, C_F6P, C_F26BP);
            state.C_G6P = q2.Q1;
            state.C_F6P = q2.Q2;
            state.C_26BP = q2.Q3;

            v = GlycolisisRates.rate_2(C_MgATP, state.C_F6P, C_MgADP, state.C_F16BP, state.C_ATP, C_Mg, C_23BPG, C_AMP, C_G16BP, C_Pi, state.C_26BP, constants.Const_2);
            var q3 = GlycolysisQueues.queue_1(state.C_F6P, state.C_F16BP, v, Vout[4-1], delta_1, C_F16BP);
            state.C_F6P = q3.Q1;
            state.C_F16BP = q3.Q2;

            v1 = GlycolisisRates.rate_4(state.C_F16BP, state.C_GAP, state.C_DHAP, C_23BPG, constants.Const_4);
            v2 = GlycolisisRates.rate_5(state.C_DHAP, state.C_GAP, constants.Const_5);
            var q4 = GlycolysisQueues.queue_GAP(state.C_F16BP, state.C_GAP, state.C_DHAP, v1, Vout[5-1], v2, Vout[6-1], delta_1, C_GAP, C_DHAP);
            state.C_F16BP = q4.Q1;
            state.C_GAP = q4.Q2;
            state.C_DHAP = q4.Q3;

            for(int j = 0; j < 10; j++)
            {
                v = GlycolisisRates.rate_6(C_NAD, C_Pi, state.C_GAP, state.C_13BPG, C_NADH, C_H, constants.Const_6);
                var q5 = GlycolysisQueues.queue_1(state.C_GAP, state.C_13BPG, v, Vout[7-1] / 10, delta_1, C_13BPG);
                state.C_GAP = q5.Q1;
                state.C_13BPG = q5.Q2;

                v = GlycolisisRates.rate_7(state.C_13BPG, C_MgADP, state.C_2PG * 0.1 / 0.169, C_MgATP, constants.Const_7);
                var q6 = GlycolysisQueues.queue_1(state.C_13BPG, state.C_2PG, v, (Vout[9-1] + Vout[8-1]) * 0.069 / 0.169 / 10, delta_1, C_2PG);// +Vout[8]
                state.C_13BPG = q6.Q1;
                state.C_2PG = q6.Q2;

                v = GlycolisisRates.rate_9(state.C_2PG * 0.069 / 0.169, C_Mg, state.C_PEP, constants.Const_9);
                var q7 = GlycolysisQueues.queue_1(state.C_2PG, state.C_PEP, v, Vout[10-1] / 10, delta_1, C_PEP);
                state.C_2PG = q7.Q1;
                state.C_PEP = q7.Q2;

                v = GlycolisisRates.rate_10(state.C_PEP, C_MgADP, state.C_PYR, C_MgATP, state.C_ATP, C_ALA, state.C_F16BP, C_G16BP, constants.Const_10);
                var q8 = GlycolysisQueues.queue_pyr(state.C_PEP, state.C_PYR, v, Vout[11-1] / 10, delta_1, C_PYR);
                state.C_PEP = q8.Q1;
                state.C_PYR = q8.Q2;
            }

            return state;
        }

        public List<GlycolysisCellState> SimulateGlycolysis(
            GlycolysisCellState start, 
            GlycolysisConstants consts, 
            int timeSteps, 
            double noiseAmplitude = 0, 
            int savePerTimeSteps = 1, 
            int reapplyNoiseAfterTimeSamples = 100
            )
        {
            
            int saveSycles = timeSteps / savePerTimeSteps;
            var s = start.Copy();
            var c = consts;
            List<GlycolysisCellState> states = new List<GlycolysisCellState>();
            var r = new RandomGenerator();

            for(int i = 0; i < saveSycles; i++)
            {
                for(int j = 0; j < savePerTimeSteps; j++)
                {
                    if (i * j % reapplyNoiseAfterTimeSamples == 0)
                        c = c.ApplyNoise(noiseAmplitude);

                    //// szum na paliwie
                    //s.C_GLC = start.C_GLC * (1 + noiseAmplitude * r.NextGaussian());

                    ComputeOneGlycolysisTimestep(s, c, delta);
                }
                states.Add(s);
                s = s.Copy();
            }

            return states;
        }
    }
}
