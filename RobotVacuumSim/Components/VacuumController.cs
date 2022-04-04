using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VacuumSim.Components
{
    public abstract class VacuumController
    {        
        public static bool allAlgFinish = true;
        public abstract void ExecVPath(VacuumDisplay VacDisplay, FloorplanLayout HouseLayout, CollisionHandler collisionHandler, FloorCleaner floorCleaner, Vacuum ActualVacuumData, object sender, EventArgs e);
    }
}
