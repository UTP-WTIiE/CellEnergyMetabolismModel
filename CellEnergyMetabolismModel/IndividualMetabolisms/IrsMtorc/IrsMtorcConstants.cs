﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CellEnergyMetabolismModel.IndividualMetabolisms.IrsMtorc
{
    public class IrsMtorcConstants
    {
        private double c = 1.72 * 6.022e4;
        private double d = 60000;

        public double[,] C { get; set; }
        
        /// <summary>
        /// This complex uses one more weight, which is located in
        /// </summary>
        public double[] GAPDH_mTORC1_Complex_Consts = new double[] { 6096.3, 2.4638, Math.Pow(10, -0.24), 0.00766 };

        public IrsMtorcConstants()
        {
            C = new double[60, 4];
            C[45-1, 1-1] = 0.06 / 10000;
            C[45-1, 2-1] = 0.2;
            C[1-1, 1-1] = 2500;
            C[2-1, 1-1] = 0.2;
            C[3-1, 1-1] = 0.0021;
            C[3-1, 2-1] = 0.00021;
            C[4-1, 1-1] = 0.06 / 10000;
            C[4-1, 2-1] = 20;
            C[5-1, 1-1] = 0.0021;
            C[5-1, 2-1] = 0.00021;
            C[6-1, 1-1] = 4.16;
            C[6-1, 2-1] = 1.4;
            C[7-1, 1-1] = 3;
            C[7-1, 2-1] = 1;
            C[8-1, 1-1] = 300;
            C[9-1, 1-1] = 13500;
            C[10-1, 1-1] = 900;
            C[11-1, 1-1] = 0.03;
            C[11-1, 2-1] = 140;
            C[12-1, 1-1] = 30;
            C[13-1, 1-1] = 30;
            C[14-1, 1-1] = 8000;
            C[14-1, 2-1] = 0.01;
            C[15-1, 1-1] = 15;
            C[16-1, 1-1] = 3.6;
            C[17-1, 1-1] = 150;
            C[17-1, 2-1] = 2;
            C[18-1, 1-1] = 1;
            C[18-1, 2-1] = 2.2;
            C[19-1, 1-1] = 150;
            C[20-1, 1-1] = 150;
            C[21-1, 1-1] = 15000;
            C[21-1, 2-1] = 20;
            C[22-1, 1-1] = 15000;
            C[22-1, 2-1] = 0.1;
            C[23-1, 1-1] = 15000;
            C[23-1, 2-1] = 0.1;
            C[24-1, 1-1] = 3;
            C[24-1, 2-1] = 0.1;
            C[25-1, 1-1] = 45;
            C[26-1, 1-1] = 3;
            C[27-1, 1-1] = 0.3;
            C[28-1, 1-1] = 45;
            C[29-1, 1-1] = 30;
            C[30-1, 1-1] = 30;
            C[31-1, 1-1] = 3;
            C[31-1, 2-1] = 0.1;
            C[32-1, 1-1] = 45;
            C[33-1, 1-1] = 45;
            C[34-1, 1-1] = 30;
            C[35-1, 1-1] = 450;
            C[35-1, 2-1] = 100; 
            C[36-1, 1-1] = 3;
            C[36-1, 2-1] = 0.1;
            C[37-1, 1-1] = 45;
            C[38-1, 1-1] = 30;
            C[39-1, 1-1] = 600;
            C[39-1, 2-1] = 324;
            C[39-1, 3-1] = 230 * c;
            C[39-1, 4-1] = 250;
            C[40-1, 1-1] = 600;
            C[41-1, 1-1] = 234;
            C[42-1, 1-1] = 600;
            C[42-1, 2-1] = 234;
            C[42-1, 3-1] = 3860 * c;
            C[42-1, 4-1] = 250;
            C[43-1, 1-1] = 600;
            C[44-1, 1-1] = 234;
            C[46-1, 1-1] = 5.6796e-8;
            C[47-1, 1-1] = 2.4167e-5;
            C[48-1, 1-1] = 0.0513784;
            C[48-1, 2-1] = 0.999989;
            C[51-1, 1-1] = 1;         
            C[51-1, 2-1] = 0.0001;    
            C[51-1, 3-1] = 0.0001; 
            C[52-1, 1-1] = 0.00573896;
            C[52-1, 2-1] = 0.00528455;
            C[53-1, 1-1] = 9.79766;
            C[54-1, 1-1] = 0.0107215;
            C[55-1, 1-1] = 0.036559;
            C[55-1, 2-1] = 0.000100001;
            C[56-1, 1-1] = 4.50769;
            C[56-1, 2-1] = 5.90372;
            C[56-1, 3-1] = 7.52842;
            C[57-1, 1-1] = 0.0174149;
            C[58-1, 1-1] = 0.0781585;
            C[59-1, 1-1] = 1;
            C[60-1, 1-1] = 0.1;

            for (int i = 0; i < 45; i++)
                C[i, 0] /= d;

            C[45-1, 2-1] /= d;
            C[3-1, 2-1] /= d;
            C[4-1, 2-1] /= d;
            C[6-1, 2-1] /= d;
            C[5-1, 2-1] /= d;
            C[6-1, 2-1] /= d;
            C[39-1, 2-1] /= d;
            C[42-1, 2-1] /= d;
            C[48-1, 1-1] /= d;
            C[48-1, 2-1] /= d;
            C[51-1, 1-1] /= d;
            C[51-1, 2-1] /= d;
            C[51-1, 3-1] /= d;
            C[52-1, 1-1] /= d;
            C[52-1, 2-1] /= d;
            C[53-1, 1-1] /= d;
            C[54-1, 1-1] /= d;
            C[55-1, 1-1] /= d;
            C[55-1, 2-1] /= d;
            C[56-1, 1-1] /= d;
            C[56-1, 2-1] /= d;
            C[56-1, 3-1] /= d;
            C[57-1, 1-1] /= d;
            C[58-1, 1-1] /= d;
            C[59-1, 1-1] /= d;
            C[60-1, 1-1] /= d;

        }

        public IrsMtorcConstants ApplyNoise(double noiseAmplitude)
        {
            var a = 0.2;
            var r = new RandomGenerator();
            var d = new double[C.GetLength(0), C.GetLength(1)];
            double[,] rc = new double[C.GetLength(0), C.GetLength(1)];

            for (int i = 0; i < C.GetLength(0); i++)
                for (int j = 0; j < C.GetLength(1); j++)
                    d[i, j] = C[i, j] * (1 + r.NextGaussian() * noiseAmplitude / 3);

            var rand = new RandomGenerator();
            double[] rfn(double[] _d) => _d.Select(x => x * (1 + noiseAmplitude * rand.NextGaussian() / 3)).ToArray();

            return new IrsMtorcConstants() { 
                C = d,
                GAPDH_mTORC1_Complex_Consts = rfn(GAPDH_mTORC1_Complex_Consts)
            };
        }
    }
}
