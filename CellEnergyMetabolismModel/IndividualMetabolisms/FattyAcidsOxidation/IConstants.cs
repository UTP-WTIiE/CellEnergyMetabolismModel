using System;
using System.Collections.Generic;
using System.Text;

namespace CellEnergyMetabolismModel.IndividualMetabolisms.FattyAcidsOxidation
{
    public interface IConstants
    {
        double[] GetState();
        IConstants CreateNew(double[] array);
        IConstants CreateOriginalConsts();
    }
}
