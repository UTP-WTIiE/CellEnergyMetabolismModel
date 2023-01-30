using System;
using System.Collections.Generic;
using System.Text;

namespace CellEnergyMetabolismModel.Interfaces
{
    public interface IPPPCellState
    {
        double G6P { get; set; }
        double NADP { get; set; }
        double PGL { get; set; }
        double NADPH { get; set; }
        double _6GP { get; set; }
        double OR5P { get; set; }
        double R5P { get; set; }
        double X5P { get; set; }
        double G3P { get; set; }
        double S7P { get; set; }
        double E4P { get; set; }
        double F6P { get; set; }
        double CO2 { get; set; }
    }
}
