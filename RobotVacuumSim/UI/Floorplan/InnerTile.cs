using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VacuumSim.UI.Floorplan
{
    public class InnerTile
    {
        public int x; // x coordinate of top-left inner tile corner
        public int y; // y coordinate of top-left inner tile corner
        public ObstacleType obstacle; // Obstacle contained within this inner tile
        public float dirtiness;
        private float dirtyThreshold = 0.05f;
        public const int innerTileSideLength = 3; // Each inner tile's side is 3 pixels (4 inches) long

        public InnerTile(int x, int y, ObstacleType obstacle, float dirtiness)
        {
            this.x = x;
            this.y = y;
            this.obstacle = obstacle;
            this.dirtiness = dirtiness;

            // Enforce given dirtiness is between 0-100 (percentage)
            if (dirtiness > 100.0f)
            {
                this.dirtiness = 100.0f;
            }
            else if (dirtiness < 0.0f)
            {
                this.dirtiness = 0.0f;
            }
            else
            {
                this.dirtiness = dirtiness;
            }
        }

        // IsDirty returns true if the tile dirtiness is above the dirty threshold.
        public bool IsDirty()
        {
            return this.dirtiness > dirtyThreshold;
        }

        // CleanTile reduces this tile's dirtiness level by a given efficiency percentgage float 0..1.
        public void CleanTile(float efficiency)
        {
            float dirtinessDiff = this.dirtiness * efficiency;

            this.dirtiness = this.dirtiness - dirtinessDiff;
        }

        // GetDirtinessAsString returns the dirtiness level of a tile to the given precision.
        public string GetDirtinessAsString(int precision)
        {
            return string.Format(new NumberFormatInfo() { NumberDecimalDigits = precision }, "{0:F}", this.dirtiness);
        }
    }
}
