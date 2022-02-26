using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VacuumSim
{
    public class VacuumDisplay
    {
        public const float vacuumDiameter = (12.8f * FloorplanLayout.tileSideLength) / 24.0f; // Ratio of inches compared to actual drawing size Remove later - access from VacuumController
        public float[] vacuumCoords = { 200.0f, 15.0f }; // (x, y) coordinates of vacuum
        public int vacuumHeading { get; set; } = 0; // Angle vacuum is traveling at (think of unit circle, so 0 is to the right)
        public int whiskersHeadingWRTVacuum { get; set; } = 30; // Angle of whiskers CW from vacuum heading
        public float[] whiskersStartingCoords { get; set; } = { 0.0f, 0.0f }; // Coordinates of bottom of whiskers (right along the edge of the circle)
        public float[] whiskersEndingCoords { get; set; } = { 0.0f, 0.0f }; // Coordinates of endpoint of whiskers (2 inches beyond the circle)
        public int vacuumSpeed { get; set; } = 12; // Speed of the vacuum in inches/second
        public int batterySecondsRemaining { get; set; } = 9000; // Battery remaining (seconds). Default is 150 * 60 = 9000
    }
}
