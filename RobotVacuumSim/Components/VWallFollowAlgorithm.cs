using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VacuumSim.UI.FloorplanGraphics;


namespace VacuumSim.Components
{
    /// <summary>
    /// Subclass of VacuumController. Implements Random Pathing algorithm for the Vacuum.
    /// </summary>
    public class VWallFollowAlgorithm : VacuumController
    {
        private string WallFollowAlgVer = "Wall Follow Algorithm Version 0";  // Not implemented yet 
        public override string getVer()
        {
            return WallFollowAlgVer;
        }
        public override void ExecVPath(VacuumDisplay VacDisplay, FloorplanLayout HouseLayout, CollisionHandler collisionHandler, FloorCleaner floorCleaner, Vacuum ActualVacuumData)
        {
            //Debug.WriteLine("running wall follow algorithm");
        }

    }
}
