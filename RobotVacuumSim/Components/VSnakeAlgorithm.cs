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

        public override void ExecVPath(VacuumDisplay VacDisplay, FloorplanLayout floorPlan, CollisionHandler collisionHandler, FloorCleaner floorCleaner, Vacuum ActualVacuumData, object sender, EventArgs e)
        {
            //Debug.WriteLine("running snake algorithm");


            var collision = collisionHandler;
            double test;

            ActualVacuumData.VacuumCoords[0] += FloorCanvasCalculator.GetDistanceTraveledPerFrame(VacDisplay.vacuumSpeed) * (float)Math.Cos((Math.PI * VacDisplay.vacuumHeading) / 180);
            ActualVacuumData.VacuumCoords[1] += FloorCanvasCalculator.GetDistanceTraveledPerFrame(VacDisplay.vacuumSpeed) * (float)Math.Sin((Math.PI * VacDisplay.vacuumHeading) / 180);

            VacDisplay.CenterVacuumDisplay(ActualVacuumData.VacuumCoords, floorPlan);

            if (VacDisplay.vacuumHeading < 0)
                VacDisplay.vacuumHeading = 360 + VacDisplay.vacuumHeading;

            //vacuum colides. Target position is set
            if (collision.VacuumCollidedWithObstacle(VacDisplay, floorPlan))
            {
                collision.HandleCollision(VacDisplay, ActualVacuumData, floorPlan);

                double angle = Math.PI * VacDisplay.vacuumHeading / 180.0;

                test = ActualVacuumData.VacuumSize / 2 * Math.Sin(angle);

                VacDisplay.destination[0] = ActualVacuumData.VacuumCoords[0] + test;
                VacDisplay.destination[1] = ActualVacuumData.VacuumCoords[1] - Math.Sqrt(ActualVacuumData.VacuumSize / 2 * ActualVacuumData.VacuumSize / 2 - test * test);


                VacDisplay.vacuumHeading += VacDisplay.turnDirection;
                VacDisplay.vacuumHeading = VacDisplay.vacuumHeading % 360;

                if (VacDisplay.collided)
                {
                    Random rnd = new Random();
                    VacDisplay.vacuumHeading = rnd.Next() % 360;
                }
                

                VacDisplay.collided = true; 
                //X value of the target is reached 
            }
            if (VacDisplay.collided)
            {
                if (VacDisplay.vacuumHeading > 270 || VacDisplay.vacuumHeading < 90)
                {

                    if (ActualVacuumData.VacuumCoords[0] > VacDisplay.destination[0])
                    {
                        VacDisplay.vacuumHeading += VacDisplay.turnDirection;
                        VacDisplay.vacuumHeading = VacDisplay.vacuumHeading % 360;

                        VacDisplay.turnDirection = -VacDisplay.turnDirection;
                        Debug.WriteLine("right quadrent");
                        Debug.WriteLine(VacDisplay.vacuumHeading);
                        VacDisplay.collided = false;

                    }

                }
                else if (VacDisplay.vacuumHeading > 90 || VacDisplay.vacuumHeading < 270)
                {
                    if (ActualVacuumData.VacuumCoords[0] < VacDisplay.destination[0])
                    {
                        VacDisplay.vacuumHeading += VacDisplay.turnDirection;
                        VacDisplay.vacuumHeading = VacDisplay.vacuumHeading % 360;

                        VacDisplay.turnDirection = -VacDisplay.turnDirection;
                        Debug.WriteLine("left quadrent");
                        VacDisplay.collided = false;

                    }
                }
                else if (VacDisplay.vacuumHeading == 90)
                {
                    if (ActualVacuumData.VacuumCoords[1] < VacDisplay.destination[1])
                    {
                        VacDisplay.vacuumHeading += VacDisplay.turnDirection;
                        VacDisplay.vacuumHeading = VacDisplay.vacuumHeading % 360;

                        VacDisplay.turnDirection = -VacDisplay.turnDirection;
                        Debug.WriteLine("bottom quadrent");
                        VacDisplay.collided = false;
                    }
                }
                else
                {
                    if (ActualVacuumData.VacuumCoords[1] > VacDisplay.destination[1])
                    {
                        VacDisplay.vacuumHeading += VacDisplay.turnDirection;
                        VacDisplay.vacuumHeading = VacDisplay.vacuumHeading % 360;

                        VacDisplay.turnDirection = -VacDisplay.turnDirection;
                        Debug.WriteLine("top quadrent");
                        VacDisplay.collided = false;
                    }


                }
            }

            floorCleaner.CleanInnerTiles(VacDisplay, ActualVacuumData, floorPlan);

            FloorCanvasCalculator.UpdateSimulationData(VacDisplay);
        }
    
    
    
        private string SnakeAlgVer = "Snake Algorithm Version 0";  //not implemented yet 
        public override string getVer()
        {
            return SnakeAlgVer;
        }
    } 
}
