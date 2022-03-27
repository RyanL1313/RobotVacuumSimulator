using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VacuumSim.UI.Floorplan;

using System.Globalization;

namespace VacuumSim
{
    public class Tile
    {
        public int x; // x coordinate of top left tile corner
        public int y; // y coordinate of top left tile corner
        public ObstacleType obstacle;
        public int groupID; // ID of obstacle group this tile belongs to
        public InnerTile[,] innerTiles; // The 6x6 array of inner tiles within the main tiles. Used for cleaning and collision detection
        public const int numInnerTilesInRowAndCol = 6; // Each parent tile is composed of 6x6=36 inner tiles


        public Tile(int x, int y, ObstacleType obstacle)
        {
            this.x = x;
            this.y = y;
            this.obstacle = obstacle;
            this.groupID = -1;

            this.innerTiles = new InnerTile[numInnerTilesInRowAndCol, numInnerTilesInRowAndCol]; // Create the 2D array of inner tiles
            InitializeInnerTiles(x, y, obstacle, 100.0f); // Give the inner tiles their initial values
        }

        /// <summary>
        /// Initializes an inner tile's values. This gets called in FloorplanLayout's constructor.
        /// </summary>
        /// <param name="parentTileX"> x coordinate of top-left corner of the inner tile </param>
        /// <param name="parentTileY"> y coordinate of top-left corner of the inner tile </param>
        /// <param name="obstacle"> The obstacle contained within this sub-tile </param>
        /// <param name="dirtiness"> The dirtiness level of this inner tile. Starts at 1 and gets closer to 0 as the vacuum cleans it. </param>
        public void InitializeInnerTiles(int parentTileX, int parentTileY, ObstacleType obstacle, float dirtiness)
        {
            for (int i = 0; i < numInnerTilesInRowAndCol; i++)
            {
                for (int j = 0; j < numInnerTilesInRowAndCol; j++)
                {
                    innerTiles[i, j] = new InnerTile(parentTileX + i * InnerTile.innerTileSideLength, parentTileY + j * InnerTile.innerTileSideLength, obstacle, dirtiness);
                }
            }    
        }

        /// <summary>
        /// Sets every inner tile for this tile to either a Wall or Chest obstacle type.
        /// This gets called right before the simulation starts.
        /// </summary>
        /// <param name="ob"></param>
        public void SetWallChestInnerTileObstacles(ObstacleType ob)
        {
            for (int i = 0; i < numInnerTilesInRowAndCol; i++)
            {
                for (int j = 0; j < numInnerTilesInRowAndCol; j++)
                {
                    innerTiles[i, j].obstacle = ob;
                }
            }
        }

        /// <summary>
        /// Sets a single inner tile in this tile to be have a Chair or Table obstacle. This inner tile holds a single chair/table leg
        /// This gets called right before the simulation starts.
        /// </summary>
        /// <param name="ob"></param>
        /// <param name="corner"> The type of corner (lower left, lower right, upper right, or upper left) of this chair/table </param>
        public void SetChairTableInnerTileObstacle(ObstacleType ob, int corner)
        {
            if (corner == FloorplanLayout.LL)
            {
                innerTiles[0, numInnerTilesInRowAndCol - 1].obstacle = ob;
            }
            else if (corner == FloorplanLayout.LR)
            {
                innerTiles[numInnerTilesInRowAndCol - 1, numInnerTilesInRowAndCol - 1].obstacle = ob;
            }
            else if (corner == FloorplanLayout.UR)
            {
                innerTiles[numInnerTilesInRowAndCol - 1, 0].obstacle = ob;
            }
            else if (corner == FloorplanLayout.UL)
            {
                innerTiles[0, 0].obstacle = ob;
            }
        }

        /// <summary>
        /// Sets every inner tile for this tile to a Floor obstacle type and have a dirtiness of 100
        /// This gets called after a simulation is stopped/ends
        /// </summary>
        public void ResetAllInnerTiles()
        {
            for (int i = 0; i < numInnerTilesInRowAndCol; i++)
            {
                for (int j = 0; j < numInnerTilesInRowAndCol; j++)
                {
                    innerTiles[i, j].obstacle = ObstacleType.Floor;
                    innerTiles[i, j].dirtiness = 100.0f;
                }
            }
        }
    }
}