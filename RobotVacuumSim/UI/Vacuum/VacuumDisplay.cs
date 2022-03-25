using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VacuumSim.Components;
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

        public bool VacuumCollidedWithObstacle(List<InnerTile> possibleCollisionTiles)
        {
            // Iterate through each possible inner tile and see if any inner tile contains an obstacle
            // If so, this is a collision
            foreach (InnerTile innerTile in possibleCollisionTiles)
            {
                if (innerTile.obstacle != ObstacleType.Floor) // COLLISION
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Handles a collision by moving the vacuum horizontal, vertical, or diagonal by one inner tile
        /// Terrifyingly ugly function, but it works (as far as I can tell) and shouldn't be too computationally intensive
        /// </summary>
        /// <param name="ActualVacuumData"> The vacuum data </param>
        /// <param name="HouseLayout"> The floorplan layout </param>
        public void HandleCollision(Vacuum ActualVacuumData, FloorplanLayout HouseLayout)
        {
            if (vacuumHeading == 0) // Vacuum moved strictly to the right
                ActualVacuumData.VacuumCoords[0] -= InnerTile.innerTileSideLength; // Move the vacuum to the left 1 inner tile side length
            else if (vacuumHeading == 90) // Vacuum moved strictly downwards
                ActualVacuumData.VacuumCoords[1] -= InnerTile.innerTileSideLength; // Move the vacuum up 1 inner tile side length (remember the downwards +y axis)
            else if (vacuumHeading == 180) // Vacuum moved strictly left
                ActualVacuumData.VacuumCoords[0] += InnerTile.innerTileSideLength; // Move the vacuum to the right 1 inner tile side length
            else if (vacuumHeading == 270) // Vacuum moved strictly up
                ActualVacuumData.VacuumCoords[1] += InnerTile.innerTileSideLength; // Move the vacuum down 1 inner tile side length (remember the downwards +y axis)
            else if (vacuumHeading > 0 && vacuumHeading < 90) // Vacuum moved down and to the right
            {
                ActualVacuumData.VacuumCoords[0] -= InnerTile.innerTileSideLength; // Move the vacuum to the left 1 inner tile side length

                // Check if still colliding
                List<InnerTile> possibleCollisionTiles = HouseLayout.GetInnerTilesBeingCleanedByWhiskers(this);
                if (VacuumCollidedWithObstacle(possibleCollisionTiles))
                {
                    ActualVacuumData.VacuumCoords[0] += InnerTile.innerTileSideLength; // Move the vacuum back to where it was
                    ActualVacuumData.VacuumCoords[1] -= InnerTile.innerTileSideLength; // Move the vacuum up 1 inner tile side length (remember the downwards +y axis)

                    // Check if still colliding
                    List<InnerTile> morePossibleCollisionTiles = HouseLayout.GetInnerTilesBeingCleanedByWhiskers(this);
                    if (VacuumCollidedWithObstacle(morePossibleCollisionTiles))
                    {
                        ActualVacuumData.VacuumCoords[1] += InnerTile.innerTileSideLength; // Move the vacuum back to where it was

                        // Move the vacuum both up and to the left one inner tile length (this should now fix the collision)
                        ActualVacuumData.VacuumCoords[0] -= InnerTile.innerTileSideLength;
                        ActualVacuumData.VacuumCoords[1] -= InnerTile.innerTileSideLength;
                    }
                }
            }
            else if (vacuumHeading > 90 && vacuumHeading < 180) // Vacuum moved down and to the left
            {
                ActualVacuumData.VacuumCoords[0] += InnerTile.innerTileSideLength; // Move the vacuum to the right 1 inner tile side length

                // Check if still colliding
                List<InnerTile> possibleCollisionTiles = HouseLayout.GetInnerTilesBeingCleanedByWhiskers(this);
                if (VacuumCollidedWithObstacle(possibleCollisionTiles))
                {
                    ActualVacuumData.VacuumCoords[0] -= InnerTile.innerTileSideLength; // Move the vacuum back to where it was
                    ActualVacuumData.VacuumCoords[1] -= InnerTile.innerTileSideLength; // Move the vacuum up 1 inner tile side length (remember the downwards +y axis)

                    // Check if still colliding
                    List<InnerTile> morePossibleCollisionTiles = HouseLayout.GetInnerTilesBeingCleanedByWhiskers(this);
                    if (VacuumCollidedWithObstacle(morePossibleCollisionTiles))
                    {
                        ActualVacuumData.VacuumCoords[1] += InnerTile.innerTileSideLength; // Move the vacuum back to where it was

                        // Move the vacuum both up and to the right one inner tile length (this should now fix the collision)
                        ActualVacuumData.VacuumCoords[0] += InnerTile.innerTileSideLength;
                        ActualVacuumData.VacuumCoords[1] -= InnerTile.innerTileSideLength;
                    }
                }
            }
            else if (vacuumHeading > 180 && vacuumHeading < 270) // Vacuum moved up and to the left
            {
                ActualVacuumData.VacuumCoords[0] += InnerTile.innerTileSideLength; // Move the vacuum to the right 1 inner tile side length

                // Check if still colliding
                List<InnerTile> possibleCollisionTiles = HouseLayout.GetInnerTilesBeingCleanedByWhiskers(this);
                if (VacuumCollidedWithObstacle(possibleCollisionTiles))
                {
                    ActualVacuumData.VacuumCoords[0] -= InnerTile.innerTileSideLength; // Move the vacuum back to where it was
                    ActualVacuumData.VacuumCoords[1] += InnerTile.innerTileSideLength; // Move the vacuum down 1 inner tile side length (remember the downwards +y axis)

                    // Check if still colliding
                    List<InnerTile> morePossibleCollisionTiles = HouseLayout.GetInnerTilesBeingCleanedByWhiskers(this);
                    if (VacuumCollidedWithObstacle(morePossibleCollisionTiles))
                    {
                        ActualVacuumData.VacuumCoords[1] -= InnerTile.innerTileSideLength; // Move the vacuum back to where it was

                        // Move the vacuum both down and to the right one inner tile length (this should now fix the collision)
                        ActualVacuumData.VacuumCoords[0] += InnerTile.innerTileSideLength;
                        ActualVacuumData.VacuumCoords[1] += InnerTile.innerTileSideLength;
                    }
                }
            }
            else if (vacuumHeading > 270 && vacuumHeading < 360) // Vacuum moved up and to the right
            {
                ActualVacuumData.VacuumCoords[0] -= InnerTile.innerTileSideLength; // Move the vacuum to the left 1 inner tile side length

                // Check if still colliding
                List<InnerTile> possibleCollisionTiles = HouseLayout.GetInnerTilesBeingCleanedByWhiskers(this);
                if (VacuumCollidedWithObstacle(possibleCollisionTiles))
                {
                    ActualVacuumData.VacuumCoords[0] += InnerTile.innerTileSideLength; // Move the vacuum back to where it was
                    ActualVacuumData.VacuumCoords[1] += InnerTile.innerTileSideLength; // Move the vacuum down 1 inner tile side length (remember the downwards +y axis)

                    // Check if still colliding
                    List<InnerTile> morePossibleCollisionTiles = HouseLayout.GetInnerTilesBeingCleanedByWhiskers(this);
                    if (VacuumCollidedWithObstacle(morePossibleCollisionTiles))
                    {
                        ActualVacuumData.VacuumCoords[1] -= InnerTile.innerTileSideLength; // Move the vacuum back to where it was

                        // Move the vacuum both down and to the left one inner tile length (this should now fix the collision)
                        ActualVacuumData.VacuumCoords[0] -= InnerTile.innerTileSideLength;
                        ActualVacuumData.VacuumCoords[1] += InnerTile.innerTileSideLength;
                    }
                }
            }
        }
    }
}
