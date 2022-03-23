using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VacuumSim.Components
{
    /// <summary>
    /// Subclass of VacuumController. Implements Spiral Pathing algorithm for the Vacuum.
    /// </summary>
    public class VSpiralAlgorithm : VacuumController
    {
        public override void ExecVPath(VacuumDisplay VacDisplay, FloorplanLayout HouseLayout, object sender, EventArgs e)
        {
            Debug.WriteLine("running spiral algorithm");

            // upon completion
            if (Vacuum.VacuumAlgorithm.Count!= 0)
                Vacuum.VacuumAlgorithm.RemoveAt(0);
            if (Vacuum.VacuumAlgorithm.Count == 0)
                allAlgFinish = true;

        }

    }
}
