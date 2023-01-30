using CellEnergyMetabolismModel.IndividualMetabolisms.PPP.Structs;
using System;
using System.Collections.Generic;
using System.Text;

namespace CellEnergyMetabolismModel.IndividualMetabolisms.PPP.Models
{
    public class SimulationResult
    {
        public IEnumerable<PPPCellState> CellStates { get; set; }
        public double Rate3Inhibition { get; set; }
    }
}
