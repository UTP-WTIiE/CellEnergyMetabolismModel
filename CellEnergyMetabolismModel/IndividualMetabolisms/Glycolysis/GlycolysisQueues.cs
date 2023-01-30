using System;
using System.Collections.Generic;
using System.Text;

namespace CellEnergyMetabolismModel.IndividualMetabolisms.Glycolysis
{
    public static class GlycolysisQueues
    {
        public static double rand(int whatever) => new Random().NextDouble();
        public static double abs(double a) => Math.Abs(a);

        public static (double Q1, double Q2) queue_1(double Q1p, double Q2p, double rate1, double rate2, double delta, double Q2n )
        {
            //Function emulating a single input M/M/1 queue, where Q2's input is
            //connected to Q1's output, rate1 is a service rate of the queue
            //assuming that the time increament is small enough that only one packet
            //from Q1 is being processed during a single time increament. Q1p and Q2p
            //are the lengths of Q1 and Q2 at the start of the time interval. A
            //balancing port of Q2 is serviced with rate2 if rate2 is positive or
            //receives packets with -rate2 if rate2 is negative.
            //
            //  Author: BJ Wysocki,     Date: June 25, 2015


            double Q1=Q1p;
            double Q2=Q2p;

            if(rate1 >= 0) {
                if (rand(1) <= rate1 && Q1 > delta)
                {
                    Q1 = Q1 - delta;
                    Q2 = Q2 + delta;
                }
            }
            else {
                if (rand(1) <= abs(rate1) && Q2 > delta)
                {
                    Q2 = Q2 - delta;
                    Q1 = Q1 + delta;
                }
            }

            if (rate2 >= 0) {
                if (rand(1) <= rate2 * (Q2p / Q2n) && Q2 > delta) {
                    //if rand(1) <= rate2 && Q2 > delta,
                    Q2 = Q2 - delta;
                }
            }
            else
            {
                if (rand(1) <= abs(rate2) * (Q2n / Q2p)) {
                    //if rand(1) <= abs(rate2),
                    Q2 = Q2 + delta;
                }
            }

            return (Q1: Q1, Q2: Q2);
        }
        // Zapytaj, czy queue_1 czy queue_1_a

        public static (double Q1, double Q2, double Q3) queue_F6P(double Q1p, double Q2p, double Q3p, double rate1, double rate2, double rate3, double rate4, double rate5, double delta, double Q2n, double Q3n)
        {
            double Q1=Q1p;
            double Q2=Q2p;
            double Q3=Q3p;
            if (rate1 >= 0) {
                if (rand(1) <= rate1 && Q1 > delta)
                {
                    Q1 = Q1 - delta;
                    Q2 = Q2 + delta;
                }
            }
            else
            {
                if (rand(1) <= abs(rate1) && Q2 > delta) {
                    Q2 = Q2 - delta;
                    Q1 = Q1 + delta;
                }
            }
            if (rate3 >= 0)
            {
                if (rand(1) <= rate3 && Q2 > delta)
                {
                    Q2 = Q2 - delta;
                    Q3 = Q3 + delta;
                }
            }
            else
            {
                if (rand(1) <= abs(rate3) && Q3 > delta)
                {
                    Q2 = Q2 + delta;
                    Q3 = Q3 - delta;
                }
            }

            if (rate4 >= 0) {
                if (rand(1) <= rate4 && Q3 > delta) {
                    Q3 = Q3 - delta;
                    Q2 = Q2 + delta;
                }
            }
            else {
                if (rand(1) <= abs(rate4) && Q2 > delta) {
                    Q2 = Q2 - delta;
                    Q3 = Q3 + delta;
                }
            }

            if (rate2 >= 0) {
                if (rand(1) <= rate2 * Q2 / Math.Pow(Q2n, 0.01) && Q2 > delta) {
                    //if ( rand(1) <= rate2 && Q2>delta ) {}
                    Q2 = Q2 - delta;
                }
            }
            else
            {
                if (rand(1) <= abs(rate2) * Q2n / Math.Pow(Q2, 0.5)) {
                    //if ( rand(1) <= abs(rate2) ) {}
                    Q2 = Q2 + delta;
                }
            }

            if (rate5 >= 0) {
                if (rand(1) <= rate5 * Q3 / Math.Pow(Q3n, 0.01) && Q3 > delta) {
                    //if ( rand(1) <= rate5 && Q3>delta ) {}
                    Q3 = Q3 - delta;
                }
            }
            else { 
                if (rand(1) <= abs(rate5) * Q3n / Math.Pow(Q3, 0.5)) { 
                //if ( rand(1) <= abs(rate5) ) {}
                    Q3=Q3+delta;
                }
            }

            return (Q1, Q2, Q3);
        }

        public static (double Q1, double Q2, double Q3) queue_GAP(double Q1p, double Q2p, double Q3p, double rate1, double rate2, double rate3, double rate4, double delta, double Q2n, double Q3n)
        {
            double Q1=Q1p;
            double Q2=Q2p;
            double Q3=Q3p;

            if (rate1 >= 0) {
                if (rand(1) <= rate1 && Q1 > delta) {
                    Q1 = Q1 - delta;
                    Q2 = Q2 + delta;
                    Q3 = Q3 + delta;
                }
            }
            else {
                if (rand(1) <= abs(rate1) && 0 * Q2 > delta && Q3 > delta) {
                    Q1 = Q1 + delta;
                    Q2 = Q2 - delta;
                    Q3 = Q3 - delta;
                }
            }

            if (rate3 >= 0) {
                if (rand(1) <= rate3 && Q3 > delta) {
                    Q3 = Q3 - delta;
                    Q2 = Q2 + delta;
                }
            }
            else {
                if (rand(1) <= abs(rate3) && 0 * Q2 > delta) {
                    Q3 = Q3 + delta;
                    Q2 = Q2 - delta;
                }
            }


            if (rate2 >= 0) {
                if (rand(1) <= rate2 * Q2p / Q2n && Q2 > delta) {
                    //if ( rand(1) <= rate2 && Q2>delta ) {}
                    Q2 = Q2 - delta;
                }
            }
            else {
                if (rand(1) <= abs(rate2) * Q2n / Q2) {
                    //if ( rand(1) <= abs(rate2) ) {}
                    Q2 = Q2 + delta;
                }
            }

            if (rate4 >= 0)
            {
                if (rand(1) <= rate4 * Q3 / Q3n && Q3 > delta)
                {
                    //if ( rand(1) <= rate4 && Q3>delta ) {}
                    Q3 = Q3 - delta;
                }
            }
            else
            {
                if (rand(1) <= abs(rate4) * Q3n / Q3)
                {
                    //if ( rand(1) <= abs(rate4) ) {}
                    Q3 = Q3 + delta;
                }
            }

            return (Q1, Q2, Q3);
        }
    
        public static (double Q1, double Q2) queue_pyr(double Q1p, double Q2p, double rate1, double rate2, double delta, double Q2n)
        {
            //Function emulating a single input M/M/1 queue, where Q2's input is
            //connected to Q1's output, rate1 is a service rate of the queue
            //assuming that the time increament is small enough that only one packet
            //from Q1 is being processed during a single time increament. Q1p and Q2p
            //are the lengthss of Q1 and Q2 at the start of the time interval. A
            //balancing port of Q2 is serviced with rate2 if rate2 is positive or
            //receives packets with -rate2 if rate2 is negative.
            //
            //  Author: BJ Wysocki,     Date: June 25, 2015


            double Q1=Q1p;
            double Q2=Q2p;

            if (rate1 >= 0) {
                if (rand(1) <= rate1 && Q1 > delta) {
                    Q1 = Q1 - delta;
                    Q2 = Q2 + delta;
                }
            }
            else {
                if (rand(1) <= abs(rate1) && Q2 > delta) {
                    Q2 = Q2 - delta;
                    Q1 = Q1 + delta;
                }
            }

            if (rate2 >= 0)
            {
                if (rand(1) <= rate2 * Math.Pow((Q2p / Q2n), 0.5) && Q2 > delta)
                {
                    //if ( rand(1) <= rate2 && Q2>delta ) {}
                    Q2 = Q2 - delta;
                }
            }
            else
            {
                if (rand(1) <= abs(rate2) * Math.Pow((Q2n / Q2p), 0.5))
                {
                    //if ( rand(1) <= abs(rate2) ) {}
                    Q2 = Q2 + delta;
                }
            }

            return (Q1, Q2);
        }
    }
}
