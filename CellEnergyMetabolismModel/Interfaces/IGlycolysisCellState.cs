using System;
using System.Collections.Generic;
using System.Text;

namespace CellEnergyMetabolismModel.Interfaces
{
    public interface IGlycolysisCellState
    {
        double C_GLC{ get; set; }
        double C_G6P{ get; set; }
        double C_F6P{ get; set; }
        double C_F16BP{ get; set; }
        double C_26BP{ get; set; }
        /// <summary>
        /// In other words it is G3P
        /// </summary>
        double C_GAP{ get; set; }
        double C_DHAP{ get; set; }
        double C_13BPG{ get; set; }
        double C_3PG{ get; set; }
        double C_2PG{ get; set; }
        double C_PEP{ get; set; }
        double C_PYR{ get; set; }
        double C_MgATP{ get; set; }
        double C_MgADP{ get; set; }
        double C_NAD{ get; set; }
        double C_NADH{ get; set; }
        double C_Pi{ get; set; }
        double C_Mg{ get; set; }
        double C_ATP{ get; set; }
        double C_ADP{ get; set; }
        double C_AMP{ get; set; }
        double C_H{ get; set; }
        double C_F26BP{ get; set; }
        double C_23BPG{ get; set; }
        double C_GSH{ get; set; }
        double C_ALA{ get; set; }
        double C_G16BP{ get; set; }
    }
}
