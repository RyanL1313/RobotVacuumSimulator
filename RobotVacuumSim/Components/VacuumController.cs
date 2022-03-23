using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VacuumSim.Components
{
    public abstract class VacuumController
    {
        //TODO: clean up and determine exactly what other functionality this class needs. Combine this class and the individual vacuum class? seems unnecessary to have both atm
        
        public static bool allAlgFinish = true;

        public abstract void ExecVPath(VacuumDisplay VacDisplay, FloorplanLayout HouseLayout, object sender, EventArgs e);
    }
}
