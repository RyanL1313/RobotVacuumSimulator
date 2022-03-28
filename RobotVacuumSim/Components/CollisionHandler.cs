using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VacuumSim.UI.Floorplan;

namespace VacuumSim.Components
{
    public class CollisionHandler
    {
        /// <summary>
        /// Checks if any of the vacuum display's hitboxes contain non-floor obstacles. If so ==> collision
        /// </summary>
        /// <param name="VacDisplay"> Vacuum display </param>
        /// <param name="HouseLayout"> Floor plan layout </param>
        /// <returns> Whether or not a collision occured </returns>
        public bool VacuumCollidedWithObstacle(VacuumDisplay VacDisplay, FloorplanLayout HouseLayout)
        {
            List<InnerTile> innerHitboxTiles = HouseLayout.GetVacuumHitboxInnerTiles(VacDisplay, HouseLayout);

            // Iterate through each possible inner tile and see if any inner tile contains an obstacle
            // If so, this is a collision
            foreach (InnerTile innerTile in innerHitboxTiles)
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
        public void HandleCollision(VacuumDisplay VacDisplay, Vacuum ActualVacuumData, FloorplanLayout HouseLayout)
        {
            if (VacDisplay.vacuumHeading == 0) // Vacuum moved strictly to the right
                ActualVacuumData.VacuumCoords[0] -= InnerTile.innerTileSideLength; // Move the vacuum to the left 1 inner tile side length
            else if (VacDisplay.vacuumHeading == 90) // Vacuum moved strictly downwards
                ActualVacuumData.VacuumCoords[1] -= InnerTile.innerTileSideLength; // Move the vacuum up 1 inner tile side length (remember the downwards +y axis)
            else if (VacDisplay.vacuumHeading == 180) // Vacuum moved strictly left
                ActualVacuumData.VacuumCoords[0] += InnerTile.innerTileSideLength; // Move the vacuum to the right 1 inner tile side length
            else if (VacDisplay.vacuumHeading == 270) // Vacuum moved strictly up
                ActualVacuumData.VacuumCoords[1] += InnerTile.innerTileSideLength; // Move the vacuum down 1 inner tile side length (remember the downwards +y axis)
            else if (VacDisplay.vacuumHeading > 0 && VacDisplay.vacuumHeading < 90) // Vacuum moved down and to the right
            {
                ActualVacuumData.VacuumCoords[0] -= InnerTile.innerTileSideLength; // Move the vacuum to the left 1 inner tile side length

                // Check if still colliding
                List<InnerTile> possibleCollisionTiles = HouseLayout.GetInnerTilesBeingCleanedByWhiskers(VacDisplay);
                if (VacuumCollidedWithObstacle(VacDisplay, HouseLayout))
                {
                    ActualVacuumData.VacuumCoords[0] += InnerTile.innerTileSideLength; // Move the vacuum back to where it was
                    ActualVacuumData.VacuumCoords[1] -= InnerTile.innerTileSideLength; // Move the vacuum up 1 inner tile side length (remember the downwards +y axis)

                    // Check if still colliding
                    List<InnerTile> morePossibleCollisionTiles = HouseLayout.GetInnerTilesBeingCleanedByWhiskers(VacDisplay);
                    if (VacuumCollidedWithObstacle(VacDisplay, HouseLayout))
                    {
                        ActualVacuumData.VacuumCoords[1] += InnerTile.innerTileSideLength; // Move the vacuum back to where it was

                        // Move the vacuum both up and to the left one inner tile length (this should now fix the collision)
                        ActualVacuumData.VacuumCoords[0] -= InnerTile.innerTileSideLength;
                        ActualVacuumData.VacuumCoords[1] -= InnerTile.innerTileSideLength;
                    }
                }
            }
            else if (VacDisplay.vacuumHeading > 90 && VacDisplay.vacuumHeading < 180) // Vacuum moved down and to the left
            {
                ActualVacuumData.VacuumCoords[0] += InnerTile.innerTileSideLength; // Move the vacuum to the right 1 inner tile side length

                // Check if still colliding
                List<InnerTile> possibleCollisionTiles = HouseLayout.GetInnerTilesBeingCleanedByWhiskers(VacDisplay);
                if (VacuumCollidedWithObstacle(VacDisplay, HouseLayout))
                {
                    ActualVacuumData.VacuumCoords[0] -= InnerTile.innerTileSideLength; // Move the vacuum back to where it was
                    ActualVacuumData.VacuumCoords[1] -= InnerTile.innerTileSideLength; // Move the vacuum up 1 inner tile side length (remember the downwards +y axis)

                    // Check if still colliding
                    List<InnerTile> morePossibleCollisionTiles = HouseLayout.GetInnerTilesBeingCleanedByWhiskers(VacDisplay);
                    if (VacuumCollidedWithObstacle(VacDisplay, HouseLayout))
                    {
                        ActualVacuumData.VacuumCoords[1] += InnerTile.innerTileSideLength; // Move the vacuum back to where it was

                        // Move the vacuum both up and to the right one inner tile length (this should now fix the collision)
                        ActualVacuumData.VacuumCoords[0] += InnerTile.innerTileSideLength;
                        ActualVacuumData.VacuumCoords[1] -= InnerTile.innerTileSideLength;
                    }
                }
            }
            else if (VacDisplay.vacuumHeading > 180 && VacDisplay.vacuumHeading < 270) // Vacuum moved up and to the left
            {
                ActualVacuumData.VacuumCoords[0] += InnerTile.innerTileSideLength; // Move the vacuum to the right 1 inner tile side length

                // Check if still colliding
                List<InnerTile> possibleCollisionTiles = HouseLayout.GetInnerTilesBeingCleanedByWhiskers(VacDisplay);
                if (VacuumCollidedWithObstacle(VacDisplay, HouseLayout))
                {
                    ActualVacuumData.VacuumCoords[0] -= InnerTile.innerTileSideLength; // Move the vacuum back to where it was
                    ActualVacuumData.VacuumCoords[1] += InnerTile.innerTileSideLength; // Move the vacuum down 1 inner tile side length (remember the downwards +y axis)

                    // Check if still colliding
                    List<InnerTile> morePossibleCollisionTiles = HouseLayout.GetInnerTilesBeingCleanedByWhiskers(VacDisplay);
                    if (VacuumCollidedWithObstacle(VacDisplay, HouseLayout))
                    {
                        ActualVacuumData.VacuumCoords[1] -= InnerTile.innerTileSideLength; // Move the vacuum back to where it was

                        // Move the vacuum both down and to the right one inner tile length (this should now fix the collision)
                        ActualVacuumData.VacuumCoords[0] += InnerTile.innerTileSideLength;
                        ActualVacuumData.VacuumCoords[1] += InnerTile.innerTileSideLength;
                    }
                }
            }
            else if (VacDisplay.vacuumHeading > 270 && VacDisplay.vacuumHeading < 360) // Vacuum moved up and to the right
            {
                ActualVacuumData.VacuumCoords[0] -= InnerTile.innerTileSideLength; // Move the vacuum to the left 1 inner tile side length

                // Check if still colliding
                List<InnerTile> possibleCollisionTiles = HouseLayout.GetInnerTilesBeingCleanedByWhiskers(VacDisplay);
                if (VacuumCollidedWithObstacle(VacDisplay, HouseLayout))
                {
                    ActualVacuumData.VacuumCoords[0] += InnerTile.innerTileSideLength; // Move the vacuum back to where it was
                    ActualVacuumData.VacuumCoords[1] += InnerTile.innerTileSideLength; // Move the vacuum down 1 inner tile side length (remember the downwards +y axis)

                    // Check if still colliding
                    List<InnerTile> morePossibleCollisionTiles = HouseLayout.GetInnerTilesBeingCleanedByWhiskers(VacDisplay);
                    if (VacuumCollidedWithObstacle(VacDisplay, HouseLayout))
                    {
                        ActualVacuumData.VacuumCoords[1] -= InnerTile.innerTileSideLength; // Move the vacuum back to where it was

                        // Move the vacuum both down and to the left one inner tile length (this should now fix the collision)
                        ActualVacuumData.VacuumCoords[0] -= InnerTile.innerTileSideLength;
                        ActualVacuumData.VacuumCoords[1] += InnerTile.innerTileSideLength;
                    }
                }
            }

            VacDisplay.CenterVacuumDisplay(ActualVacuumData.VacuumCoords, HouseLayout); // Re-center the vacuum display after fixing the collision
        }
    }
}
