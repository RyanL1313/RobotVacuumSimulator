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
    public class VRandAlgorithm : VacuumController
    {
        public override void ExecVPath(VacuumDisplay VacDisplay, FloorplanLayout HouseLayout, CollisionHandler collisionHandler, FloorCleaner floorCleaner, Vacuum ActualVacuumData, object sender, EventArgs e)
        {
            ActualVacuumData.VacuumCoords[0] += FloorCanvasCalculator.GetDistanceTraveledPerFrame(VacDisplay.vacuumSpeed) * (float)Math.Cos((Math.PI * VacDisplay.vacuumHeading) / 180);
            ActualVacuumData.VacuumCoords[1] += FloorCanvasCalculator.GetDistanceTraveledPerFrame(VacDisplay.vacuumSpeed) * (float)Math.Sin((Math.PI * VacDisplay.vacuumHeading) / 180);

            VacDisplay.CenterVacuumDisplay(ActualVacuumData.VacuumCoords, HouseLayout);

            if (collisionHandler.VacuumCollidedWithObstacle(VacDisplay, HouseLayout))
            {
                collisionHandler.HandleCollision(VacDisplay, ActualVacuumData, HouseLayout);

                Random rnd = new Random();
                VacDisplay.vacuumHeading = rnd.Next() % 360;
            }
            floorCleaner.CleanInnerTiles(VacDisplay, ActualVacuumData, HouseLayout);

            FloorCanvasCalculator.UpdateSimulationData(VacDisplay);

            // upon completion
            if (Vacuum.VacuumAlgorithm.Count != 0)
                Vacuum.VacuumAlgorithm.RemoveAt(0);
            if (Vacuum.VacuumAlgorithm.Count == 0)
                allAlgFinish = true;
        }
    }
}
