using System;
using System.Collections.Generic;
using System.Text;

namespace CellEnergyMetabolismModel.Interfaces
{
    public interface IKrebsCellState
    {
        double Pyr{ get; set; }
        double Accoa{ get; set; }
        double Oxo{ get; set; }
        double Cit{ get; set; }
        double Iso{ get; set; }
        double Keto{ get; set; }
        double Sca{ get; set; }
        double Fum{ get; set; }
        double Mal{ get; set; }
    }
}
