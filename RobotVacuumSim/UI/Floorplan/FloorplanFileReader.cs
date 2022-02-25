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
            string[] lines = File.ReadAllLines("../../../UI/Floorplan/DefaultFloorplan.txt");

            int row = 0;
            int col = 0;
            string strOb = "";

            ObstacleType ob = ObstacleType.None;

            // Iterate over each row in the .txt file
            for (int i = 0; i < HouseLayout.numTilesPerCol; i++)
            {
                string[] rowData = lines[i].Split(" ");
                int strIndex = 0;

                for (int j = 0; j < HouseLayout.numTilesPerRow; j++)
                {
                    row = Int32.Parse(rowData[strIndex++]);
                    col = Int32.Parse(rowData[strIndex++]);

                    strOb = rowData[strIndex++];
                    ob = FloorplanLayout.GetObstacleTypeFromString(strOb);

                    HouseLayout.floorLayout[col, row].obstacle = ob;
                }
            }
        }
    }
}
