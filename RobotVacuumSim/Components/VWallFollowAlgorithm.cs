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
        public override void ExecVPath(VacuumDisplay VacDisplay, FloorplanLayout floorPlan, CollisionHandler collisionHandler, FloorCleaner floorCleaner, Vacuum ActualVacuumData, object sender, EventArgs e)
        {
            //Debug.WriteLine("running wall follow algorithm");

            var rand = new Random();
            
            var collision = collisionHandler;
            InnerTile leftBackTile = null;
            InnerTile leftFrontTile = null;
            Tile tileActualLocation = null;
            float heading = VacDisplay.vacuumHeading;
            int battery = VacDisplay.batterySecondsRemaining;
            bool backGreater;
            int[] test = new int[2];
            if (battery > 0)
            {
               
                ActualVacuumData.VacuumCoords[0] += FloorCanvasCalculator.GetDistanceTraveledPerFrame(VacDisplay.vacuumSpeed) * (float)Math.Cos((Math.PI * VacDisplay.vacuumHeading) / 180);
                ActualVacuumData.VacuumCoords[1] += FloorCanvasCalculator.GetDistanceTraveledPerFrame(VacDisplay.vacuumSpeed) * (float)Math.Sin((Math.PI * VacDisplay.vacuumHeading) / 180);
                
                VacDisplay.CenterVacuumDisplay(ActualVacuumData.VacuumCoords, floorPlan);

                //Debug.WriteLine(VacDisplay.vacuumHeading);
                
                tileActualLocation = floorPlan.GetTileFromCoordinates((int)ActualVacuumData.VacuumCoords[0], (int)ActualVacuumData.VacuumCoords[1]);

                Tile tile = floorPlan.GetTileFromCoordinates(132, 375);

                test = FloorplanLayout.GetTileIndices(132, 375);

                if (!VacDisplay.firstWallCol)
                {
                    //need the tile to the left of the vacuum
                    if (VacDisplay.vacuumHeading < 90.0f) //vaccuum is heading right
                    {
                        leftBackTile = floorPlan.GetInnerTileFromCoordinates((int)VacDisplay.vacuumCoords[0]-5, (int)VacDisplay.vacuumCoords[1] - 5);
                    }
                    else if (VacDisplay.vacuumHeading < 180.0f) // vacuum is heading down
                    {
                        leftBackTile = floorPlan.GetInnerTileFromCoordinates((int)VacDisplay.vacuumCoords[0] + 5, (int)VacDisplay.vacuumCoords[1]-5);
                    }
                    else if (VacDisplay.vacuumHeading < 270.0f) // vacuum is heading left
                    {
                        leftBackTile = floorPlan.GetInnerTileFromCoordinates((int)VacDisplay.vacuumCoords[0]+5, (int)VacDisplay.vacuumCoords[1] + 5);

                    }
                    else //vacuum is heading up
                    {
                        leftBackTile = floorPlan.GetInnerTileFromCoordinates((int)VacDisplay.vacuumCoords[0] -5, (int)VacDisplay.vacuumCoords[1]+5);

                    }

                    if (VacDisplay.vacuumHeading < 90.0f) //vaccuum is heading right
                    {
                        leftFrontTile = floorPlan.GetInnerTileFromCoordinates((int)VacDisplay.vacuumCoords[0] + 5, (int)VacDisplay.vacuumCoords[1] - 5);
                    }
                    else if (VacDisplay.vacuumHeading < 180.0f) // vacuum is heading down
                    {
                        leftFrontTile = floorPlan.GetInnerTileFromCoordinates((int)VacDisplay.vacuumCoords[0] + 5, (int)VacDisplay.vacuumCoords[1] + 5);
                    }
                    else if (VacDisplay.vacuumHeading < 270.0f) // vacuum is heading left
                    {
                        leftFrontTile = floorPlan.GetInnerTileFromCoordinates((int)VacDisplay.vacuumCoords[0] - 5, (int)VacDisplay.vacuumCoords[1] + 5);

                    }
                    else //vacuum is heading up
                    {
                        leftFrontTile = floorPlan.GetInnerTileFromCoordinates((int)VacDisplay.vacuumCoords[0] - 5, (int)VacDisplay.vacuumCoords[1] - 5);

                    }

                    Debug.WriteLine(VacDisplay.vacuumHeading);
                    
                }

                if (collision.VacuumCollidedWithObstacle(VacDisplay, floorPlan))
                {
                    floorPlan.GetTileFromCoordinates((int)VacDisplay.vacuumCoords[0], (int)VacDisplay.vacuumCoords[1]);
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


                //currently flawed as the left tile isn't reset in time for this to move anywhere
                else if (!VacDisplay.firstWallCol && ((leftBackTile.obstacle == ObstacleType.Floor && leftFrontTile.obstacle == ObstacleType.Floor) && backGreater))
                {

                    InnerTile swing = swingTile(VacDisplay, floorPlan, leftBackTile);
                    VacDisplay.vacuumHeading -= 90;
                    if (VacDisplay.vacuumHeading < 0)
                        VacDisplay.vacuumHeading = 270;
                    
                    if (VacDisplay.vacuumHeading < 90.0f) //vaccuum is heading right
                    {
                        if (leftBackTile.x > swing.x)
                            backGreater = true;
                        else
                            backGreater = false;

                    }
                    else if (VacDisplay.vacuumHeading < 180.0f) // vacuum is heading down
                    {
                    }
                    else if (VacDisplay.vacuumHeading < 270.0f) // vacuum is heading left
                    {

                    }
                    else //vacuum is heading up
                    {

                    }
                    
                    //VacDisplay.vacuumHeading = VacDisplay.vacuumHeading % 360;
                    
                    //Debug.WriteLine("leftBackTile floor");

                }
                

                //check the current heading to be able to check where to turn

                

            }
            //Debug.WriteLine(VacDisplay.vacuumHeading);





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


        public InnerTile swingTile(VacuumDisplay VacDisplay, FloorplanLayout floorPlan, InnerTile leftBackTile)
        {
            if (VacDisplay.vacuumHeading < 90.0f) //vaccuum is heading right
            {
                return floorPlan.GetInnerTileFromCoordinates(leftBackTile.x - InnerTile.innerTileSideLength, leftBackTile.y);

            }
            else if (VacDisplay.vacuumHeading < 180.0f) // vacuum is heading down
            {
                return floorPlan.GetInnerTileFromCoordinates(leftBackTile.x, leftBackTile.y - InnerTile.innerTileSideLength);

            }
            else if (VacDisplay.vacuumHeading < 270.0f) // vacuum is heading left
            {
                return floorPlan.GetInnerTileFromCoordinates(leftBackTile.x + InnerTile.innerTileSideLength, leftBackTile.y); 
            }
            else //vacuum is heading up
            {
                return floorPlan.GetInnerTileFromCoordinates(leftBackTile.x , leftBackTile.y + InnerTile.innerTileSideLength);
            }
        }
    }


   
}
