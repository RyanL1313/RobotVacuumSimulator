using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace VacuumSim
{
    public class FloorplanFileWriter
    {
        public FloorplanFileWriter()
        {

        }

        public static void SaveTileGridData(string path, FloorplanLayout HouseLayout)
        {
            string[] lines = new string[HouseLayout.numTilesPerCol]; // NumTilesPerCol is technically the number of rows. Confusing, I know

            for (int i = 0; i < HouseLayout.numTilesPerCol; i++)
            {
                lines[i] = i + " " + "0" + " " + HouseLayout.floorLayout[0, i].obstacle; // First value in row
                for (int j = 1; j < HouseLayout.numTilesPerRow; j++)
                {
                    lines[i] = lines[i] + " " + i + " " + j + " " + HouseLayout.floorLayout[j, i].obstacle;
                }
            }

            File.WriteAllLines("../../../UI/Floorplan/DefaultFloorplan.txt", lines);
        }
    }
}
