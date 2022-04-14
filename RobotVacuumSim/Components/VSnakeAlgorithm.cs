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
    /// Subclass of VacuumController. Implements Snake Pathing algorithm for the Vacuum.
    /// </summary>
    public class VSnakeAlgorithm : VacuumController
    {
        private string SnakeAlgVer = "Snake Algorithm Version 0";  //not implemented yet 
        public override string getVer()
        {
            return SnakeAlgVer;
        }
        public override void ExecVPath(VacuumDisplay VacDisplay, FloorplanLayout HouseLayout, CollisionHandler collisionHandler, FloorCleaner floorCleaner, Vacuum ActualVacuumData)
        {
            //Debug.WriteLine("running snake algorithm");
        }

    }
}
