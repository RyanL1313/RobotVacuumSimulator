using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VacuumSim
{
    public enum ObstacleType { NONE, WALL, CHEST, TABLE, CHAIR };

    public struct Tile
    {
        public int x; // x coordinate of top left tile corner
        public int y; // y coordinate of top left tile corner
        public ObstacleType obstacle;

        public Tile(int x, int y, ObstacleType obstacle)
        {
            this.x = x;
            this.y = y;
            this.obstacle = obstacle;
        }
    }
    public class TileGridAccessor
    {
        public int numTilesPerRow { get; private set; } = 50;
        public int numTilesPerCol { get; private set; } = 40;
        public int tileSideLength { get; private set; } = 15;
        public Tile[,] floorLayout { get; private set; } // 2D array of tiles

        public TileGridAccessor()
        {
            floorLayout = new Tile[numTilesPerRow, numTilesPerCol]; // Create the 2D array of tiles

            // Initialize the grid with blank tiles and the coordinates of those tiles
            for (int i = 0; i < numTilesPerRow; i++)
            {
                for (int j = 0; j < numTilesPerCol; j++)
                {
                    floorLayout[i, j] = new Tile(i * tileSideLength, j * tileSideLength, ObstacleType.NONE);
                }
            }
        }

        /* Returns the obstacle located at the tile associated with the (x, y) coordinates in the FloorCanvas PictureBox */
        public ObstacleType GetObstacleTypeFromTileCoordinates(int x, int y)
        {
            int xTileIndex = x / tileSideLength;
            int yTileIndex = y / tileSideLength;

            return floorLayout[xTileIndex, yTileIndex].obstacle;
        }

        public bool ModifyTile(int x, int y, ObstacleType ob)
        {
            // Get row, col indices of selected tile based on the coordinates selected by the user
            int xTileIndex = x / tileSideLength;
            int yTileIndex = y / tileSideLength;

            if (xTileIndex > numTilesPerRow || yTileIndex > numTilesPerCol)
                return false; // Outside grid

            
            floorLayout[xTileIndex, yTileIndex].obstacle = ob;
            
            return true;
        }

        public static ObstacleType GetObstacleTypeFromString(string strObstacle)
        {
            string lowercase = strObstacle.ToLower();
            ObstacleType ret = ObstacleType.NONE;

            if (lowercase.Equals("blank") || lowercase.Equals("none"))
                ret = ObstacleType.NONE;
            else if (lowercase.Equals("wall"))
                ret = ObstacleType.WALL;
            else if (lowercase.Equals("chest"))
                ret = ObstacleType.CHEST;
            else if (lowercase.Equals("chair"))
                ret = ObstacleType.CHAIR;
            else if (lowercase.Equals("table"))
                ret = ObstacleType.TABLE;

            return ret;
        }
    }
}
