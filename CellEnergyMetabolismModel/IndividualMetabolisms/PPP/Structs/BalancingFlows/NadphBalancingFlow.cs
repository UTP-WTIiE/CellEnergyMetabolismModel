using CellEnergyMetabolismModel.IndividualMetabolisms.PPP.Interfaces;
using CellEnergyMetabolismModel.IndividualMetabolisms.PPP.Structs.Constants;
using CellEnergyMetabolismModel.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CellEnergyMetabolismModel.IndividualMetabolisms.PPP.Structs.BalancingFlows
{
    public struct NadphBalancingFlow : IDoubleArray, IRate
    {
        public const double ReferenceProbabilityRate = RateG6P_NADP__PGL_NADPH_Constants.ReferenceRateProbability;
        public static double Delta = RateG6P_NADP__PGL_NADPH_Constants.Delta;
        public const int Length = 1;

        public double C0 { get; set; }
        public bool IsReversible => false;

        public string Name => $"Nadph Balance";

        public bool IsBalancingFlow => true;
        public int Frequency => 1;


        public NadphBalancingFlow(double[] array)
        {
            C0 = array[0];
        }

        public static NadphBalancingFlow GetLiteratureConstants()
        {
            var c = new NadphBalancingFlow();
            var p = PPPCellState.Default().NADPH;
            c.C0 = ReferenceProbabilityRate / p;

            return c;
        }

        public NadphBalancingFlow ApplyNoise(double noiseAmplitude, Func<double> gaussian_random_fn)
        {
            var c = (NadphBalancingFlow)this.ShallowCopy();
            double n() => 1 + noiseAmplitude * gaussian_random_fn();

            c.C0 *= n();

            return c;
        }

        public double CalculateRate(IPPPCellState state)
        {
            return state.NADPH * C0;
        }

        public IRate ModifyWeights(Func<int, double, double> modification_fn)
        {
            var array = this.ToDoubleArray();
            for (int i = 0; i < array.Length; i++)
                array[i] = modification_fn(i, array[i]);

            return new NadphBalancingFlow(array);
        }

        public PPPCellState Queue(PPPCellState currentState, double delta, Func<double> univariate_random_fn)
        {
            if (currentState.NADPH <= delta)
                return new PPPCellState();

            var rate = CalculateRate(currentState);
            if (univariate_random_fn() < rate)
            {
                return new PPPCellState()
                {
                    NADPH = -1 * delta
                };
            }
            else return new PPPCellState();
        }

        public IRate ShallowCopy()
        {
            return new NadphBalancingFlow(this.ToDoubleArray());
        }

        public double[] ToDoubleArray()
        {
            return new double[Length]
            {
                C0
            };
        }
    }
}
