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

        public static void LoadTileGridData(string path, FloorplanLayout HouseLayout)
        {
            string[] lines = File.ReadAllLines(path);

            int row = 0;
            int col = 0;
            int gid = 0;
            string strOb = "";

            ObstacleType ob = ObstacleType.Floor;

            // Parse the data in the top of the .txt file
            string[] topRowData = lines[0].Split(" ");
            FloorplanFileWriter.currentObstacleGroupNumber = Int32.Parse(topRowData[1]);

            // Iterate over each row of tile data in the .txt file
            for (int i = 1; i <= HouseLayout.numTilesPerCol; i++)
            {
                string[] rowTileData = lines[i].Split(" ");
                int strIndex = 0;

                for (int j = 0; j < HouseLayout.numTilesPerRow; j++)
                {
                    row = Int32.Parse(rowTileData[strIndex++]);
                    col = Int32.Parse(rowTileData[strIndex++]);

                    strOb = rowTileData[strIndex++];
                    ob = FloorplanLayout.GetObstacleTypeFromString(strOb);

                    gid = Int32.Parse(rowTileData[strIndex++]);

                    HouseLayout.floorLayout[col, row].obstacle = ob;
                    HouseLayout.floorLayout[col, row].groupID = gid;
                }
            }
        }
    }
}
