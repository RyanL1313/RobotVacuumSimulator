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
    /// Subclass of VacuumController. Implements Spiral Pathing algorithm for the Vacuum.
    /// </summary>
    public class VSpiralAlgorithm : VacuumController
    {
        private bool spiralFlag = false;
        private int obstacleDistanceCounter = 0;
        //private double radius = 45;
        private float rate = 0.1f;
        private float radius = 0;
        public override void ExecVPath(VacuumDisplay VacDisplay, FloorplanLayout HouseLayout, CollisionHandler collisionHandler, FloorCleaner floorCleaner, Vacuum ActualVacuumData, object sender, EventArgs e)
        {
            //If the vacuum is not in a spiral, it will move in a straight line. This will be used when the vacuum first starts and after it hits
            // an obstacle to ensure it has enough space to begin spiraling.
            if (spiralFlag == false)
            {
                ActualVacuumData.VacuumCoords[0] += FloorCanvasCalculator.GetDistanceTraveledPerFrame(VacDisplay.vacuumSpeed) * (float)Math.Cos((Math.PI * VacDisplay.vacuumHeading) / 180);
                ActualVacuumData.VacuumCoords[1] += FloorCanvasCalculator.GetDistanceTraveledPerFrame(VacDisplay.vacuumSpeed) * (float)Math.Sin((Math.PI * VacDisplay.vacuumHeading) / 180);
                obstacleDistanceCounter++;
                if (obstacleDistanceCounter >= 30)
                    spiralFlag = true;
            }
            else if (spiralFlag == true)
            {

                ActualVacuumData.VacuumCoords[0] += FloorCanvasCalculator.GetDistanceTraveledPerFrame(VacDisplay.vacuumSpeed) * ((float)Math.Cos((VacDisplay.vacuumHeading)) * radius);
                ActualVacuumData.VacuumCoords[1] += FloorCanvasCalculator.GetDistanceTraveledPerFrame(VacDisplay.vacuumSpeed) * ((float)Math.Sin((VacDisplay.vacuumHeading)) * radius);

                radius += rate;
                VacDisplay.vacuumHeading = (VacDisplay.vacuumHeading + 1) % 360;
                //if (radius != 1)
                //    radius -= (2*Math.PI);
                //Debug.WriteLine(radius);
            }

            VacDisplay.CenterVacuumDisplay(ActualVacuumData.VacuumCoords, HouseLayout);

            if (collisionHandler.VacuumCollidedWithObstacle(VacDisplay, HouseLayout))
            {
                collisionHandler.HandleCollision(VacDisplay, ActualVacuumData, HouseLayout);
                // when the vacuum encounters an obstacle, it will turn a random direction and travel in a straight line once more
                // until it determines with the obstacleDistanceCounter that it has traveled sufficiently far away.
                Random rnd = new Random();
                VacDisplay.vacuumHeading = rnd.Next() % 360;
                spiralFlag = false;
                obstacleDistanceCounter = 0;
                radius = 0;
            }
            floorCleaner.CleanInnerTiles(VacDisplay, ActualVacuumData, HouseLayout);

            FloorCanvasCalculator.UpdateSimulationData(VacDisplay);

            // upon completion
            if (Vacuum.VacuumAlgorithm.Count!= 0)
                Vacuum.VacuumAlgorithm.RemoveAt(0);
            if (Vacuum.VacuumAlgorithm.Count == 0)
                allAlgFinish = true;

        }

    }
}
