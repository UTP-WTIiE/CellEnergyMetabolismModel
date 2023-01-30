using CellEnergyMetabolismModel.IndividualMetabolisms.PPP.Structs;
using CellEnergyMetabolismModel.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CellEnergyMetabolismModel.IndividualMetabolisms.PPP.Interfaces
{
    public interface IRate : IDoubleArray
    {
        double CalculateRate(IPPPCellState state);
        PPPCellState Queue(PPPCellState currentState, double delta, Func<double> univariate_random_fn);
        bool IsReversible { get; }
        IRate ShallowCopy();
        IRate ModifyWeights(Func<int, double, double> modification_fn);
        string Name { get; }
        bool IsBalancingFlow { get; }
        int Frequency { get; }
    }
}
