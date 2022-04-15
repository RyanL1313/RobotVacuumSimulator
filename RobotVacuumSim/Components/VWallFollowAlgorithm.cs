﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VacuumSim.UI.Floorplan;
using VacuumSim.UI.FloorplanGraphics;


namespace VacuumSim.Components
{
    /// <summary>
    /// Subclass of VacuumController. Wall Follow Pathing algorithm for the Vacuum.
    /// </summary>
    public class VWallFollowAlgorithm : VacuumController
    {
        public override void ExecVPath(VacuumDisplay VacDisplay, FloorplanLayout HouseLayout, CollisionHandler collisionHandler, FloorCleaner floorCleaner, Vacuum ActualVacuumData, object sender, EventArgs e)
        {
            //Debug.WriteLine("running wall follow algorithm");

            var floorPlan = HouseLayout;
            var rand = new Random();
            
            var collision = collisionHandler;
            InnerTile leftTile = null;
            Tile tileActualLocation = null;
            float heading = VacDisplay.vacuumHeading;
            int battery = VacDisplay.batterySecondsRemaining;
            

            if (battery > 0)
            {
               
                ActualVacuumData.VacuumCoords[0] += FloorCanvasCalculator.GetDistanceTraveledPerFrame(VacDisplay.vacuumSpeed) * (float)Math.Cos((Math.PI * VacDisplay.vacuumHeading) / 180);
                ActualVacuumData.VacuumCoords[1] += FloorCanvasCalculator.GetDistanceTraveledPerFrame(VacDisplay.vacuumSpeed) * (float)Math.Sin((Math.PI * VacDisplay.vacuumHeading) / 180);
                
                VacDisplay.CenterVacuumDisplay(ActualVacuumData.VacuumCoords, floorPlan);

                //Debug.WriteLine(VacDisplay.vacuumHeading);
                
                tileActualLocation = floorPlan.GetTileFromCoordinates((int)ActualVacuumData.VacuumCoords[0], (int)ActualVacuumData.VacuumCoords[1]);

               
                if (!VacDisplay.firstWallCol)
                {
                    //need the tile to the left of the vacuum
                    if (VacDisplay.vacuumHeading < 90.0f) //vaccuum is heading right
                    {
                        leftTile = floorPlan.GetInnerTileFromCoordinates((int)ActualVacuumData.VacuumCoords[0], (int)ActualVacuumData.VacuumCoords[1] - InnerTile.innerTileSideLength);
                    }
                    else if (VacDisplay.vacuumHeading < 180.0f) // vacuum is heading up
                    {
                        leftTile = floorPlan.GetInnerTileFromCoordinates((int)ActualVacuumData.VacuumCoords[0] + InnerTile.innerTileSideLength, (int)ActualVacuumData.VacuumCoords[1]);
                    }
                    else if (VacDisplay.vacuumHeading < 270.0f) // vacuum is heading left
                    {
                        leftTile = floorPlan.GetInnerTileFromCoordinates((int)ActualVacuumData.VacuumCoords[0], (int)ActualVacuumData.VacuumCoords[1] + InnerTile.innerTileSideLength);

                    }
                    else //vacuum is heading down
                    {
                        leftTile = floorPlan.GetInnerTileFromCoordinates((int)ActualVacuumData.VacuumCoords[0] - InnerTile.innerTileSideLength, (int)ActualVacuumData.VacuumCoords[1]);

                    }

                    Debug.WriteLine(leftTile.obstacle);
                }

                if (collision.VacuumCollidedWithObstacle(VacDisplay, floorPlan))
                {
                    collision.HandleCollision(VacDisplay, ActualVacuumData, floorPlan);
                    //actually start running the algorithm
                    // save starting tile to use to break from wall later 
                    if (VacDisplay.firstWallCol)
                    {                       
                        VacDisplay.firstWallCol = false;
                        Debug.WriteLine("startTile Set");

                    }

                    //align with wall by turning clockwise
                    VacDisplay.vacuumHeading += 90;
                    VacDisplay.vacuumHeading = VacDisplay.vacuumHeading % 360;
                }

                /*else if (!VacDisplay.firstWallCol && leftTile != null && leftTile.obstacle == ObstacleType.Floor )
                {
                    VacDisplay.vacuumHeading -= 90;
                    VacDisplay.vacuumHeading = VacDisplay.vacuumHeading % 360;
                    if (VacDisplay.vacuumHeading < 0)
                        VacDisplay.vacuumHeading = 270;
                    //Debug.WriteLine("leftTile floor");

                }
                */

                //check the current heading to be able to check where to turn

                //tried to use a switch here to try and differentiate it from the sea of if statements
                //might not end up working due to float rounding issues

            }
            Debug.WriteLine(VacDisplay.vacuumHeading);





            //as built right now, other obstacles besides walls can possibly derail the algorithm
            // FloorCanvasCalculator.UpdateSimulationData(VacDisplay);
            // upon completion
            if (Vacuum.VacuumAlgorithm.Count != 0)
            {
                Vacuum.VacuumAlgorithm.RemoveAt(0);
            }
            if (Vacuum.VacuumAlgorithm.Count == 0)
            {
                allAlgFinish = true;
            }
        }

    }
}
