using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VacuumSim.Components
{
    /// <summary>
    /// Links the primitive Vacuum class to the simulation by changing the attributes
    /// of the vacuum.
    /// Class is abstract to allow for different subclasses for each pathing algorithm.
    /// Inheriting will make it easier to impliment individual algorithms rather than programming
    /// them as functions in the class.
    /// </summary>
    public abstract class VacuumController
    {
        // Will send updates about the vacuum's status to the UI
        public class VacuumEventArgs : EventArgs
        {
            public IEnumerable<Vacuum> updated;
        }
        // Triggers UI update. Not needed at the moment but will be important when we start
        // connecting front and back end. 
        public event EventHandler<VacuumEventArgs> VacuumUpdated;

        // Constructor
        public VacuumController()
        {
            // Initialize all components based on input from UI when user presses start.
            // Any components not changed or specified will use default hard coded values.
            // Branch to specific algorithm subclass based on which one(s) are selected.
        }

        // Abstract function that wil be called differently in each pathing algorithm's
        // subclass. Executes specific vacuum path.
        // maybe called in the constructor?
        public abstract void ExecVPath();
    }
}
