using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace VacuumSim
{
    public class FloorplanFileReader
    {
        public FloorplanFileReader()
        {

        }

        public static void LoadTileGridData(string path, TileGridAccessor tga)
        {
            string[] lines = File.ReadAllLines("../../../UI/Floorplan/DefaultFloorPlan.txt");

            int row = 0;
            int col = 0;
            string strOb = "";
            ObstacleType ob = ObstacleType.None;

            // Iterate over each row in the .txt file
            for (int i = 0; i < tga.numTilesPerCol; i++)
            {
                string[] rowData = lines[i].Split(" ");
                int strIndex = 0;

                for (int j = 0; j < tga.numTilesPerRow; j++)
                {
                    row = Int32.Parse(rowData[strIndex++]);
                    col = Int32.Parse(rowData[strIndex++]);

                    strOb = rowData[strIndex++];
                    ob = TileGridAccessor.GetObstacleTypeFromString(strOb);

                    tga.floorLayout[col, row].obstacle = ob;
                }
            }
        }
    }
}
