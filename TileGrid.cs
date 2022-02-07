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
    public class TileGrid
    {
        public static int numTilesPerRow = 50;
        public static int numTilesPerCol = 40;
        public static int tileSideLength = 15;

        public static Tile[,] floorLayout { get; set; } // 2D array of tiles

        public TileGrid()
        {
            floorLayout = new Tile[numTilesPerRow, numTilesPerCol];

            for (int i = 0; i < numTilesPerRow; i++)
            {
                for (int j = 0; j < numTilesPerCol; j++)
                {
                    floorLayout[i, j] = new Tile(i * tileSideLength, j * tileSideLength, ObstacleType.NONE);
                }
            }
        }

        public static bool modifyTile(int x, int y, ObstacleType ob)
        {
            // Get (x,y) coordinates of top left corner of selected tile
            int xTile = x / tileSideLength;
            int yTile = y / tileSideLength;

            if (xTile > numTilesPerRow * tileSideLength || yTile > numTilesPerCol * tileSideLength)
                return false; // Outside grid

            
            floorLayout[xTile, yTile].obstacle = ob;
            
            return true;
        }
    }
}
