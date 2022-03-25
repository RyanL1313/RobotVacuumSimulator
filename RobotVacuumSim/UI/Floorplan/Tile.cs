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


        // constructor without explicit dirtiness, should be re-evaluated.
        public Tile(int x, int y, ObstacleType obstacle)
        {
            this.x = x;
            this.y = y;
            this.obstacle = obstacle;
            this.groupID = -1;
        }

        // overloaded constructor for specifying float dirtiness.
        public Tile(int x, int y, ObstacleType obstacle, float dirtiness)
        {
            this.x = x;
            this.y = y;
            this.obstacle = obstacle;
            this.groupID = -1;

            this.innerTiles = new InnerTile[numInnerTilesInRowAndCol, numInnerTilesInRowAndCol]; // Create the 2D array of inner tiles
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
    }
}