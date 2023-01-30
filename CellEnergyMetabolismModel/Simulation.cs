using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CellEnergyMetabolismModel
{
    public class Simulation
    {
        public Simulation()
        {
            
        }

        public List<CellState> SimulateOneCell(CellState start, Constants consts, SimulationSettings settings, int timeSteps, int timeStepsToSave = 100)
        {
            var list = new List<CellState>();
            
            var a = start;
            if (settings.FillZerosWithDelta)
                a = a.FillZerosWithOneDeltaMinimalValue();

            List<CellState> toBeAveraged = new List<CellState>();
            for(int i = 0; i < timeSteps; i++)
            {
                toBeAveraged.Add(a);

                if (i % timeStepsToSave == 0)
                {
                    var avg = toBeAveraged.Aggregate((a, b) => a + b) / (double)toBeAveraged.Count;
                    list.Add(avg);
                    toBeAveraged.Clear();
                }

                a = consts.ComputeStep(a);
            }

            return list;
        }
    }
}
