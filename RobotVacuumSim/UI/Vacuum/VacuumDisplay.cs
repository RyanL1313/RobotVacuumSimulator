using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VacuumSim.UI.Floorplan;

namespace VacuumSim
{
    public class VacuumDisplay
    {
        public const float vacuumDiameter = (12.0f * FloorplanLayout.tileSideLength) / 24.0f; // Vacuum diameter in pixels (should be 9)
        public float[] vacuumCoords = { 200.0f, 30.0f }; // (x, y) coordinates of vacuum that gets displayed (might be a bit off from the actual. Use Vacuum.cs for actual coordinates)
        public int vacuumHeading { get; set; } = 0; // Angle vacuum is traveling at (think of unit circle, so 0 is to the right)
        public int whiskersHeadingWRTVacuum { get; set; } = 30; // Angle of whiskers CW from vacuum heading
        public float[] whiskersStartingCoords { get; set; } = { 0.0f, 0.0f }; // Coordinates of bottom of whiskers (right along the edge of the circle)
        public float[] whiskersEndingCoords { get; set; } = { 0.0f, 0.0f }; // Coordinates of endpoint of whiskers (2 inches beyond the circle)
        public int vacuumSpeed { get; set; } = 12; // Speed of the vacuum in inches/second
        public int batterySecondsRemaining { get; set; } = 9000; // Battery remaining (seconds). Default is 150 * 60 = 9000

        /// <summary>
        /// Updates the vacuum display's coordinates to be centered within the inner tile its centerpoint currently resides in
        /// </summary>
        /// <param name="actualVacuumCoords"> The actual current coordinates of the vacuum (as in Vacuum.cs) </param>
        /// <param name="HouseLayout"> The floorplan layout used in the simulation </param>
        public void CenterVacuumDisplay(float[] actualVacuumCoords, FloorplanLayout HouseLayout)
        {
            InnerTile innerTile = HouseLayout.GetInnerTileFromCoordinates((int)actualVacuumCoords[0], (int)actualVacuumCoords[1]);

            vacuumCoords[0] = innerTile.x + InnerTile.innerTileSideLength / 2.0f;
            vacuumCoords[1] = innerTile.y + InnerTile.innerTileSideLength / 2.0f;
        }
    }
}
