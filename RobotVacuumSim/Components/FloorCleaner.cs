using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VacuumSim.UI.Floorplan;

namespace VacuumSim.Components
{
    public class FloorCleaner
    {
        private List<InnerTile> curInnerTilesWhiskersAreCleaning = new List<InnerTile>();
        private InnerTile curInnerTileVacuumIsCleaning;

        public void CleanInnerTiles(VacuumDisplay VacDisplay, Vacuum ActualVacuumData, InnerTile encounteredVacuumTile, List<InnerTile> encounteredWhiskerTiles)
        {
            // Check if possible inner tile is currently being cleaned by the vacuum
            // If not, clean this inner tile and set it as the current inner tile being cleaned by the vacuum
            if (curInnerTileVacuumIsCleaning != encounteredVacuumTile) // New tile
            {
                encounteredVacuumTile.CleanTile(ActualVacuumData.VacuumEfficiency);
                curInnerTileVacuumIsCleaning = encounteredVacuumTile;
            }

            // Iterate through each possible inner tile and check if it is currently being cleaned by the whiskers
            // If not, clean the inner tile and add it to the list
            foreach (InnerTile innerTile in encounteredWhiskerTiles)
            {
                if (!curInnerTilesWhiskersAreCleaning.Any(p => p.uniqueID.Equals(innerTile.uniqueID)))
                {
                    innerTile.CleanTile(ActualVacuumData.WhiskerEfficiency);
                    curInnerTilesWhiskersAreCleaning.Add(innerTile);
                }
            }

            // Iterate through each inner tile that was previously cleaned by the whiskers and remove any that are no longer getting cleaned
            foreach (InnerTile innerTile in curInnerTilesWhiskersAreCleaning.ToList())
            {
                if (!encounteredWhiskerTiles.Any(p => p.uniqueID.Equals(innerTile.uniqueID))) // Inner tile not in new list of encountered inner tiles => remove it
                {
                    InnerTile removedTile = curInnerTilesWhiskersAreCleaning.Find(p => p.uniqueID.Equals(innerTile.uniqueID));
                    curInnerTilesWhiskersAreCleaning.Remove(removedTile);
                }
            }
        }
    }
}
