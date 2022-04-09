﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

            //int tileLen = FloorplanLayout.tileSideLength;

            var floorPlan = HouseLayout;
            //var tile = new VacuumSim.Tile();
            var rand = new Random();
            int adjustmentX = 0;
            int adjustmentY = 0;
            var collision = collisionHandler;
            Tile currentTile = null;  

             // floorPlan.GetTileFromRowCol((int)VacDisplay.startTileX, (int)VacDisplay.startTileX);
            //Tile startTileLocation = floorPlan.GetTileFromCoordinates(floorPlan.GetTileLocationX(startTile), floorPlan.GetTileLocationY(startTile));
            //tile.obstacle = ObstacleType.Floor;
            //int laps = 0;
            //get starting point

            float heading = VacDisplay.vacuumHeading;
            //while battery > 0
            int battery = VacDisplay.batterySecondsRemaining;
            

            if (battery > 0)
            {
                //  Debug.WriteLine("running");
                ActualVacuumData.VacuumCoords[0] += FloorCanvasCalculator.GetDistanceTraveledPerFrame(VacDisplay.vacuumSpeed) * (float)Math.Cos((Math.PI * VacDisplay.vacuumHeading) / 180);
                ActualVacuumData.VacuumCoords[1] += FloorCanvasCalculator.GetDistanceTraveledPerFrame(VacDisplay.vacuumSpeed) * (float)Math.Sin((Math.PI * VacDisplay.vacuumHeading) / 180);
                
                VacDisplay.CenterVacuumDisplay(ActualVacuumData.VacuumCoords, floorPlan);

                

                //Debug.WriteLine(VacDisplay.loopNum);

               


                //currentTile = floorPlan.GetTileFromCoordinates((int)VacDisplay.vacuumCoords[0] + adjustmentX, (int)VacDisplay.vacuumCoords[1] + adjustmentY);

                Tile tileActualLocation = floorPlan.GetTileFromCoordinates((int)ActualVacuumData.VacuumCoords[0], (int)ActualVacuumData.VacuumCoords[1]);

                if (VacDisplay.startTile != null)
                {
                    //Debug.WriteLine("startTile not null");

                    if (tileActualLocation.TileEquals(VacDisplay.startTile, tileActualLocation))
                    {
                       // Debug.WriteLine("startTile hit");
                        if (VacDisplay.incremented == false)
                        {
                            VacDisplay.incremented = true;
                            VacDisplay.loopNum += 1;


                            if (VacDisplay.vacuumHeading < 90.0f)
                            {
                                adjustmentX += 6 * (VacDisplay.loopNum - 1); //vacuum is facing east. therefore to lap the room the offset must be moved to the left. logic is the same through the switch statemet for different directions
                            }
                            else if (VacDisplay.vacuumHeading < 180.0f)
                            {
                                adjustmentY += 6 * (VacDisplay.loopNum - 1);
                            }
                            else if (VacDisplay.vacuumHeading < 270.0f)
                            {
                                adjustmentX -= 6 * (VacDisplay.loopNum - 1);
                            }
                            else
                            {
                                adjustmentY -= 6 * (VacDisplay.loopNum - 1);
                            }
                            ActualVacuumData.VacuumCoords[0] +=adjustmentX;
                            ActualVacuumData.VacuumCoords[1] += adjustmentY;
                            Debug.WriteLine(VacDisplay.loopNum);
                        }

                        //need to update start tile
                        //VacDisplay.startTile = floorPlan.GetTileFromCoordinates((int)ActualVacuumData.VacuumCoords[0] + adjustmentX, (int)ActualVacuumData.VacuumCoords[1] + adjustmentY);

                        if (VacDisplay.startTile != tileActualLocation)
                            VacDisplay.incremented = false;
                    }
                }
                if (collision.VacuumCollidedWithObstacle(VacDisplay, floorPlan))
                {
                    collision.HandleCollision(VacDisplay, ActualVacuumData, floorPlan);
                    //actually start running the algorithm
                    // save starting tile to use to break from wall later 
                    if (VacDisplay.firstWallCol)
                    {

                        VacDisplay.startTile = floorPlan.GetTileFromCoordinates((int)ActualVacuumData.VacuumCoords[0], (int)ActualVacuumData.VacuumCoords[1]);
                       
                        VacDisplay.firstWallCol = false;
                        Debug.WriteLine("startTile Set");
                        //Debug.WriteLine((int)ActualVacuumData.VacuumCoords[0]);
                        //Debug.WriteLine((int)ActualVacuumData.VacuumCoords[1]);

                    }

                    //align with wall by turning clockwise
                    VacDisplay.vacuumHeading += 90;
                    VacDisplay.vacuumHeading = VacDisplay.vacuumHeading % 360;
                }




                //check the current heading to be able to check where to turn

                //tried to use a switch here to try and differentiate it from the sea of if statements
                //might not end up working due to float rounding issues

            }
            //check if the start tile or if in line with the start tile







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
