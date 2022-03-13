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
        public override void ExecVPath(VacuumDisplay VacDisplay, FloorplanLayout HouseLayout, object sender, EventArgs e)
        {
            Random rnd = new Random();
            float vacRad = (float)(Vacuum.VacuumSize / 2.0f);
            int tileLen = FloorplanLayout.tileSideLength;
            VacDisplay.vacuumCoords[0] += FloorCanvasCalculator.GetDistanceTraveledPerFrame(VacDisplay.vacuumSpeed) * (float)Math.Cos((Math.PI * VacDisplay.vacuumHeading) / 180);
            VacDisplay.vacuumCoords[1] += FloorCanvasCalculator.GetDistanceTraveledPerFrame(VacDisplay.vacuumSpeed) * (float)Math.Sin((Math.PI * VacDisplay.vacuumHeading) / 180);

            // behavior around walls and chests
            Tile tile = HouseLayout.GetTileFromCoordinates((int)VacDisplay.vacuumCoords[0], (int)VacDisplay.vacuumCoords[1]);
            if (tile.obstacle == ObstacleType.Wall || tile.obstacle == ObstacleType.Chest)
            {


                //if vacuum is hitting the obstacle from the bottom (heading between 181 and 359)
                if ((VacDisplay.vacuumHeading % 360) > 0 && (VacDisplay.vacuumHeading % 360) > 180)
                {
                    VacDisplay.vacuumHeading += rnd.Next(1, 180);
                    Debug.WriteLine(VacDisplay.vacuumHeading % 360, "\n");
                }
                //if vacuum is hitting the obstacle from the top (heading between 1 and 179)
                else if ((VacDisplay.vacuumHeading % 360) < 180 && (VacDisplay.vacuumHeading % 360) > 0)
                {
                    VacDisplay.vacuumHeading += rnd.Next(181, 360);
                    Debug.WriteLine(VacDisplay.vacuumHeading % 360, "\n");
                }
                //if vacuum is hitting the obstacle from the left (heading between 91 and 269)
                else if ((VacDisplay.vacuumHeading % 360) < 270 && (VacDisplay.vacuumHeading % 360) > 90)
                {
                    VacDisplay.vacuumHeading = rnd.Next(1, 3) == 1 ? rnd.Next(0, 90) : rnd.Next(271, 361);
                    Debug.WriteLine(VacDisplay.vacuumHeading % 360, "\n");
                }
                //if vacuum is hitting the obstacle from the right (heading between 271 and 89)
                else if (((VacDisplay.vacuumHeading % 360) < 90 && (VacDisplay.vacuumHeading % 360) > 270) || (VacDisplay.vacuumHeading % 360) == 0)
                {
                    VacDisplay.vacuumHeading = rnd.Next(91, 270);
                    Debug.WriteLine(VacDisplay.vacuumHeading % 360, "\n");
                }

            }

            //behavior around table and chair legs
            if (HouseLayout.GetTileFromCoordinates((int)VacDisplay.vacuumCoords[0], (int)VacDisplay.vacuumCoords[1]).obstacle == ObstacleType.Chair||
               HouseLayout.GetTileFromCoordinates((int)VacDisplay.vacuumCoords[0], (int)VacDisplay.vacuumCoords[1]).obstacle == ObstacleType.Table)
            {
                float[,] coordinates = HouseLayout.GetChairOrTableLegCoordinates(HouseLayout.GetTileFromCoordinates((int)VacDisplay.vacuumCoords[0], (int)VacDisplay.vacuumCoords[1]));
                float legRad = FloorplanLayout.chairAndTableLegRadius;
                for (int i = 0; i <4; i++)
                {
                    double CircleDistSquared = Math.Pow(VacDisplay.vacuumCoords[0] - coordinates[i, 0], 2) + Math.Pow(VacDisplay.vacuumCoords[1] - coordinates[i, 1], 2);
                    if (CircleDistSquared > Math.Pow(vacRad - legRad, 2) && CircleDistSquared < Math.Pow(vacRad +legRad, 2))
                    {
                        //if vacuum is hitting the obstacle from the bottom (heading between 181 and 359)
                        if ((VacDisplay.vacuumHeading % 360) > 0 && (VacDisplay.vacuumHeading % 360) > 180)
                        {
                            VacDisplay.vacuumHeading = rnd.Next(1, 180);
                            Debug.WriteLine(VacDisplay.vacuumHeading % 360, "\n");
                        }
                        //if vacuum is hitting the obstacle from the top (heading between 1 and 179)
                        else if ((VacDisplay.vacuumHeading % 360) < 180 && (VacDisplay.vacuumHeading % 360) > 0)
                        {
                            VacDisplay.vacuumHeading = rnd.Next(181, 360);
                            Debug.WriteLine(VacDisplay.vacuumHeading % 360, "\n");
                        }
                        //if vacuum is hitting the obstacle from the left (heading between 91 and 269)
                        else if ((VacDisplay.vacuumHeading % 360) < 270 && (VacDisplay.vacuumHeading % 360) > 90)
                        {
                            VacDisplay.vacuumHeading = rnd.Next(1, 3) == 1 ? rnd.Next(0, 90) : rnd.Next(271, 361);
                            Debug.WriteLine(VacDisplay.vacuumHeading % 360, "\n");
                        }
                        //if vacuum is hitting the obstacle from the right (heading between 271 and 89)
                        else if (((VacDisplay.vacuumHeading % 360) < 90 && (VacDisplay.vacuumHeading % 360) > 270) || (VacDisplay.vacuumHeading % 360) == 0)
                        {
                            VacDisplay.vacuumHeading = rnd.Next(91, 270);
                            Debug.WriteLine(VacDisplay.vacuumHeading % 360, "\n");
                        }
                    }
                }
            }
            FloorCanvasCalculator.UpdateSimulationData(VacDisplay);

            //update later to also include the cleanliness of the whole house
            if (VacDisplay.batterySecondsRemaining == 0)
            {
                // upon completion
                if (Vacuum.VacuumAlgorithm.Count != 0)
                    Vacuum.VacuumAlgorithm.RemoveAt(0);
                if (Vacuum.VacuumAlgorithm.Count == 0)
                    allAlgFinish = true;
            }
        }
    }
}
