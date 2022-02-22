﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VacuumSim
{
    public enum ObstacleType
    { None, Wall, Chest, Table, Chair };

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
        public const int tileSideLength = 15;
        public Tile[,] floorLayout { get; private set; } // 2D array of tiles
        public bool gridLinesOn { get; set; } = true; // Should grid lines currently be displaying?

        /* Feel free to remove this gigantic comment block later. */
        /* Creates the 2D array of tiles and sets the tiles' default attributes */
        /* Note: The 2D array of tiles is created using column-major order since */
        /* numTilesPerRow is actually the number of columns, while numTilesPerCol */
        /* is the number of rows. This might be inconvenient when accessing certain */
        /* tiles, so I added a helper method (GetTileFromRowCol) to easily access a */
        /* tile based on the row and column and another helper method */
        /* (GetTileFromCoordinates) to easily access a tile based on the coordinates */
        /* clicked on by the user. */

        public TileGridAccessor()
        {
            floorLayout = new Tile[numTilesPerRow, numTilesPerCol]; // Create the 2D array of tiles

            // Initialize the grid with blank tiles and the coordinates of those tiles
            for (int i = 0; i < numTilesPerRow; i++)
            {
                for (int j = 0; j < numTilesPerCol; j++)
                {
                    floorLayout[i, j] = new Tile(i * tileSideLength, j * tileSideLength, ObstacleType.None);
                }
            }
        }

        /* Returns the Tile object by requested row and column. */

        public Tile GetTileFromRowCol(int row, int col)
        {
            return floorLayout[col, row];
        }

        /* Returns the Tile object located at the (x, y) coordinates in the FloorCanvas PictureBox */

        public Tile GetTileFromCoordinates(int x, int y)
        {
            int xTileIndex = x / tileSideLength;
            int yTileIndex = y / tileSideLength;

            return floorLayout[xTileIndex, yTileIndex];
        }

        /* Modifies the obstacle located in a certain tile based on the (x, y) coordinates in the FloorCanvas PictureBox */

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

        /* Returns the ObstacleType enum value associated with an obstacle string */

        public static ObstacleType GetObstacleTypeFromString(string strObstacle)
        {
            string lowercase = strObstacle.ToLower();
            ObstacleType ret = ObstacleType.None;

            if (lowercase.Equals("blank") || lowercase.Equals("none"))
                ret = ObstacleType.None;
            else if (lowercase.Equals("wall"))
                ret = ObstacleType.Wall;
            else if (lowercase.Equals("chest"))
                ret = ObstacleType.Chest;
            else if (lowercase.Equals("chair"))
                ret = ObstacleType.Chair;
            else if (lowercase.Equals("table"))
                ret = ObstacleType.Table;

            return ret;
        }
    }
}