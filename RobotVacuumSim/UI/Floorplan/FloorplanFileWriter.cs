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

        public static void SaveTileGridData(string path, TileGridAccessor tga)
        {
            string[] lines = new string[tga.numTilesPerCol]; // NumTilesPerCol is technically the number of rows. Confusing, I know

            for (int i = 0; i < tga.numTilesPerCol; i++)
            {
                lines[i] = i + " " + "0" + " " + tga.floorLayout[0, i].obstacle; // First value in row
                for (int j = 1; j < tga.numTilesPerRow; j++)
                {
                    lines[i] = lines[i] + " " + i + " " + j + " " + tga.floorLayout[j, i].obstacle;
                }
            }

            File.WriteAllLines("../../../UI/Floorplan/SavedFloorplan.txt", lines);
        }
    }
}
