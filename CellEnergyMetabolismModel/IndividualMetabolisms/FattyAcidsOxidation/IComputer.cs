using CellEnergyMetabolismModel.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CellEnergyMetabolismModel.IndividualMetabolisms.FattyAcidsOxidation
{
    public interface IComputer
    {
        void SetCurrentState(IFattyAcidsCellState state);
        IFattyAcidsCellState ComputeQueues();
        double[] GetRates();
        string[] GetRatesNames();
    }
}
