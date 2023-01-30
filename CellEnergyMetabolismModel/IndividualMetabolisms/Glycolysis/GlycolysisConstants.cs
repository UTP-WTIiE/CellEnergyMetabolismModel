using CellEnergyMetabolismModel.IndividualMetabolisms.IrsMtorc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CellEnergyMetabolismModel.IndividualMetabolisms.Glycolysis
{
    public class GlycolysisConstants
    {
        public double[] Const_0= new double[]{262.1443,0.14,1.00,0.02,3.5,651}; //[6.38e3 41 1.0 0.1 1.0 0.47 0.47 0.03 3.0 0.0};
        public double[] Const_1= new double[]{4.8e4, 4.0e4, 0.3, 0.123};
        public double[] Const_2= new double[]{15.5e2, 6.78e1, 6.0e-2, 6.8e-2, 0.54, 0.65, 5.5e-3, 0.1, 0.1, 0.3, 0.2, 30, 0.5, 2e-3};
        public double[] Const_3A= new double[]{41.6, 0.15, 0.032, 0.008, 0.062, 0.15, 0.001, 0.02, 0.23, 0.013, 16};
        public double[] Const_3B= new double[]{416.0, 1e-3, 25e-3,};
        public double[] Const_4= new double[]{6.75e2, 2.32e3, 5e-2, 1.98e-2, 3.5e-2, 1.1e-2, 0.189, 1.5,};
        public double[] Const_5= new double[]{5.10e2, 4.61e1, 1.62e-1, 4.30e-1,};
        public double[] Const_6= new double[]{5.317e3, 3.919e3, 0.045, 0.045, 3.16, 3.16, 0.095, 1.59e-16, 0.031, 0.033, 0.01, 0.00671, 1.52e-18, 0.001, 1.9e-8,};
        public double[] Const_7= new double[]{5.96e4, 2.39e4, 0.1, 0.08, 0.002, 1.6, 1.0, 0.186, 1.1, 0.205, 3.2e3,};
        public double[] Const_8= new double[]{4.894e5, 4.395e5, 0.168, 0.0256, 0.17,};
        public double[] Const_9= new double[]{2.106e4, 5.542e3, 0.14, 0.11, 0.046, 3.0,};
        public double[] Const_10= new double[]{2.02e4, 47.5, 2.25e-1, 4.74e-1, 3.0, 3.39, 4.0, 0.04, 1.0e-1, 0.02, 0.398,};

        // TODO: Dodaj szum
        public GlycolysisConstants ApplyNoise(double noiseAmplitude)
        {
            var rand = new RandomGenerator();
            double[] r(double[] d) => d.Select(x => x * (1 + noiseAmplitude * rand.NextGaussian())).ToArray();

            return new GlycolysisConstants()
            {
                Const_0 = r(Const_0),
                Const_1 = r(Const_1),
                Const_2 = r(Const_2),
                Const_3A = r(Const_3A),
                Const_3B = r(Const_3B),
                Const_4 = r(Const_4),
                Const_5 = r(Const_5),
                Const_6 = r(Const_6),
                Const_7 = r(Const_7),
                Const_8 = r(Const_8),
                Const_9 = r(Const_9),
                Const_10 = r(Const_10)
            };
        }
    }
}
