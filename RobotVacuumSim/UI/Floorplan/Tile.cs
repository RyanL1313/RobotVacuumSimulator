using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Globalization;

namespace VacuumSim
{
    public class Tile
    {
        public int x; // x coordinate of top left tile corner
        public int y; // y coordinate of top left tile corner
        public ObstacleType obstacle;

        public float Dirtiness;
        private float dirtyThreshold = 0.05f;

        // IsDirty returns true if the tile dirtiness is above the dirty threshold.
        public bool IsDirty()
        {
            return this.Dirtiness > dirtyThreshold;
        }

        // CleanTile reduces this tile's dirtiness level by a given efficiency percentgage float 0..1.
        public void CleanTile(float efficiency)
        {
            this.Dirtiness = this.Dirtiness * efficiency;
        }

        // GetDirtinessAsString returns the dirtiness level of a tile to the given precision.
        public string GetDirtinessAsString(int precision)
        {
            return string.Format(new NumberFormatInfo() { NumberDecimalDigits = precision }, "{0:F}", this.Dirtiness);
        }

        // constructor without explicit dirtiness, should be re-evaluated.
        public Tile(int x, int y, ObstacleType obstacle)
        {
            this.x = x;
            this.y = y;
            this.obstacle = obstacle;
            this.Dirtiness = 0.5f;
        }

        // overloaded constructor for specifying float dirtiness.
        public Tile(int x, int y, ObstacleType obstacle, float dirtiness)
        {
            this.x = x;
            this.y = y;
            this.obstacle = obstacle;

            // Enforce given dirtiness is between 0-100 (percentage)
            if (dirtiness > 100.0f)
            {
                this.Dirtiness = 100.0f;
            }
            else if (dirtiness < 0.0f)
            {
                this.Dirtiness = 0.0f;
            }
            else
            {
                this.Dirtiness = dirtiness;
            }
        }
    }
}