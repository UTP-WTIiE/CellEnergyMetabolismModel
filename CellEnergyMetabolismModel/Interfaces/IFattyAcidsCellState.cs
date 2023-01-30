using System;
using System.Collections.Generic;
using System.Text;

namespace CellEnergyMetabolismModel.Interfaces
{
    public interface IFattyAcidsCellState
    {
        double C16AcylCoACYT{ get; set; }
        double C16AcylCarCYT{ get; set; }
        double C16AcylCarMAT{ get; set; }
        double C16AcylCoAMAT{ get; set; }
        double C16EnoylCoAMAT{ get; set; }
        double C16HydroxyacylCoAMAT{ get; set; }
        double C16KetoacylCoAMAT{ get; set; }
        double C14AcylCoAMAT{ get; set; }
        double C14EnoylCoAMAT{ get; set; }
        double C14HydroxyacylCoAMAT{ get; set; }
        double C14KetoacylCoAMAT{ get; set; }
        double C12AcylCoAMAT{ get; set; }
        double C12EnoylCoAMAT{ get; set; }
        double C12HydroxyacylCoAMAT{ get; set; }
        double C12KetoacylCoAMAT{ get; set; }
        double C10AcylCoAMAT{ get; set; }
        double C10EnoylCoAMAT{ get; set; }
        double C10HydroxyacylCoAMAT{ get; set; }
        double C10KetoacylCoAMAT{ get; set; }
        double C8AcylCoAMAT{ get; set; }
        double C8EnoylCoAMAT{ get; set; }
        double C8HydroxyacylCoAMAT{ get; set; }
        double C8KetoacylCoAMAT{ get; set; }
        double C6AcylCoAMAT{ get; set; }
        double C6EnoylCoAMAT{ get; set; }
        double C6HydroxyacylCoAMAT{ get; set; }
        double C6KetoacylCoAMAT{ get; set; }
        double C4AcylCoAMAT{ get; set; }
        double C4EnoylCoAMAT{ get; set; }
        double C4HydroxyacylCoAMAT{ get; set; }
        double C4AcetoacylCoAMAT{ get; set; }
        double AcetylCoAMAT{ get; set; }
        double FADHMAT{ get; set; }
        double NADHMAT{ get; set; }
    }
}
