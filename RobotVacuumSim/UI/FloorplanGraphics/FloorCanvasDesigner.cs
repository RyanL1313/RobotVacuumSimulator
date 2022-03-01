using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using VacuumSim.Sim;

/// <summary>
/// Includes anything graphics-related that gets applied to the floorplan
/// </summary>
namespace VacuumSim.UI.FloorplanGraphics
{
    public class FloorCanvasDesigner
    {
        public static bool eraserModeOn = false; // Is the user currently drawing in eraser mode?
        public static bool roomDrawingModeOn = false; // Is the user currently in room drawing mode?
        public static bool chairTableDrawingModeOn = false; // Is the user currently in chair/table drawing mode?
        public static bool currentlyAddingChairTableOrRoom = false; // Is the user currently adding a chair/table/room?
        public static bool successAddingChairTableOrRoom = false; // Was the previous attempt at adding a chair/table/room successful?

        /// <summary>
        /// Turn on anti-aliasing when simulation is running
        /// </summary>
        /// <param name="CanvasEditor"> Graphics object to edit FloorCanvas </param>
        public static void SetAntiAliasing(Graphics CanvasEditor)
        {
            if (Simulation.simStarted)
                CanvasEditor.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            else
                CanvasEditor.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
        }

        /// <summary>
        /// Draws the floorplan to FloorCanvas based on HouseLayout's 2D array of tiles
        /// </summary>
        /// <param name="CanvasEditor"> Graphics object to edit FloorCanvas </param>
        /// <param name="HouseLayout"> The floorplan layout </param>
        public static void DrawFloorplan(Graphics CanvasEditor, FloorplanLayout HouseLayout, VacuumDisplay VacDisplay)
        {
            for (int i = 0; i < HouseLayout.numTilesPerRow; i++)
            {
                for (int j = 0; j < HouseLayout.numTilesPerCol; j++)
                {
                    if (HouseLayout.floorLayout[i, j].obstacle == ObstacleType.Floor && HouseLayout.gridLinesOn) // Blank tile
                    {
                        DrawTileOutline(i, j, new Pen(Color.Black), CanvasEditor);
                    }
                    else if (HouseLayout.floorLayout[i, j].obstacle == ObstacleType.Wall) // Wall tile
                    {
                        PaintTile(i, j, new SolidBrush(Color.Black), CanvasEditor);
                    }
                    else if (HouseLayout.floorLayout[i, j].obstacle == ObstacleType.Chest) // Chest tile
                    {
                        PaintTile(i, j, new SolidBrush(Color.Brown), CanvasEditor);
                    }
                    else if (HouseLayout.floorLayout[i, j].obstacle == ObstacleType.Chair) // Chair tile
                    {
                        PaintTile(i, j, new SolidBrush(Color.Green), CanvasEditor);
                    }
                    else if (HouseLayout.floorLayout[i, j].obstacle == ObstacleType.Table) // Table tile
                    {
                        PaintTile(i, j, new SolidBrush(Color.Blue), CanvasEditor);
                    }
                }
            }
        }

        /// <summary>
        /// Fills in a tile on the floorplan grid
        /// </summary>
        /// <param name="rowIndex"> Index of chosen row </param>
        /// <param name="colIndex"> Index of chosen column </param>
        /// <param name="brush"> Brush chosen to fill in the tile </param>
        /// <param name="canvasEditor"> Graphics object to edit FloorCanvas </param>
        private static void PaintTile(int rowIndex, int colIndex, SolidBrush brush, Graphics canvasEditor)
        {
            canvasEditor.FillRectangle(brush, FloorplanLayout.tileSideLength * rowIndex, FloorplanLayout.tileSideLength * colIndex, FloorplanLayout.tileSideLength + 1, FloorplanLayout.tileSideLength + 1);
        }

        /// <summary>
        /// Draw a tile (just the outline, no fill) using a Pen */
        /// </summary>
        /// <param name="colIndex"> Index of column </param>
        /// <param name="rowIndex"> Index of row </param>
        /// <param name="penColor"> Pen color </param>
        /// <param name="canvasEditor"> Graphics object to edit FloorCanvas </param>
        private static void DrawTileOutline(int colIndex, int rowIndex, Pen penColor, Graphics canvasEditor)
        {
            // Get the coordinates of each tile corner
            Point p1 = new Point(FloorplanLayout.tileSideLength * colIndex, FloorplanLayout.tileSideLength * rowIndex);
            Point p2 = new Point(FloorplanLayout.tileSideLength * colIndex, FloorplanLayout.tileSideLength * rowIndex + FloorplanLayout.tileSideLength);
            Point p3 = new Point(FloorplanLayout.tileSideLength * colIndex + FloorplanLayout.tileSideLength, FloorplanLayout.tileSideLength * rowIndex + FloorplanLayout.tileSideLength);
            Point p4 = new Point(FloorplanLayout.tileSideLength * colIndex + FloorplanLayout.tileSideLength, FloorplanLayout.tileSideLength * rowIndex);

            // Draw the tile
            canvasEditor.DrawLine(penColor, p1, p2);
            canvasEditor.DrawLine(penColor, p2, p3);
            canvasEditor.DrawLine(penColor, p3, p4);
            canvasEditor.DrawLine(penColor, p4, p1);
        }

        /// <summary>
        /// Draw the boundary lines around the floorplan (if the simulation is running)
        /// </summary>
        /// <param name="CanvasEditor"> Graphics object to edit FloorCanvas </param>
        /// <param name="HouseLayout"> The floorplan layout </param>
        public static void DrawHouseBoundaryLines(Graphics CanvasEditor, FloorplanLayout HouseLayout)
        {
            if (!Simulation.simStarted) // No need to draw the boundary lines if the grid is still being displayed
                return;

            Pen BlackPen = new Pen(Color.Black);

            // Get the vertices of the boundary
            Point p1 = new Point(0, 0);
            Point p2 = new Point(0, HouseLayout.numTilesPerCol * FloorplanLayout.tileSideLength + 1);
            Point p3 = new Point(HouseLayout.numTilesPerRow * FloorplanLayout.tileSideLength + 1, HouseLayout.numTilesPerCol * FloorplanLayout.tileSideLength + 1);
            Point p4 = new Point(HouseLayout.numTilesPerRow * FloorplanLayout.tileSideLength + 1, 0);

            // Draw the house boundary
            CanvasEditor.DrawLine(BlackPen, p1, p2);
            CanvasEditor.DrawLine(BlackPen, p2, p3);
            CanvasEditor.DrawLine(BlackPen, p3, p4);
            CanvasEditor.DrawLine(BlackPen, p4, p1);
        }

        /// <summary>
        /// Draws the vacuum onto FloorCanvas
        /// </summary>
        /// <param name="CanvasEditor">  </param>
        /// <param name="VacDisplay"> The display of the vacuum onto FloorCanvas </param>
        public static void DrawVacuum(Graphics CanvasEditor, VacuumDisplay VacDisplay)
        {
            // Draw vacuum whiskers
            Pen charcoalGrayPen = new Pen(Color.FromArgb(255, 72, 70, 70));
            PointF whiskersStart = new PointF(VacDisplay.whiskersStartingCoords[0], VacDisplay.whiskersStartingCoords[1]);
            PointF whiskersEnd = new PointF(VacDisplay.whiskersEndingCoords[0], VacDisplay.whiskersEndingCoords[1]);
            CanvasEditor.DrawLine(charcoalGrayPen, whiskersStart, whiskersEnd);

            // Draw vacuum body
            SolidBrush charcoalGrayBrush = new SolidBrush(Color.FromArgb(255, 72, 70, 70));
            FillCircle(charcoalGrayBrush, VacuumDisplay.vacuumDiameter / 2, VacDisplay.vacuumCoords[0], VacDisplay.vacuumCoords[1], CanvasEditor);
        }

        /// <summary>
        /// Helper function to draw a filled circle
        /// </summary>
        /// <param name="brush"> Brush chosen to fill in the tile </param>
        /// <param name="radius"> Radius of the circle to be drawn </param>
        /// <param name="centerX"> X coordinate of circle on FloorCanvas </param>
        /// <param name="centerY"> Y coordinate of circle on FloorCanvas </param>
        /// <param name="CanvasEditor"> Graphics object to edit FloorCanvas </param>
        private static void FillCircle(SolidBrush brush, float radius, float centerX, float centerY, Graphics CanvasEditor)
        {
            CanvasEditor.FillEllipse(brush, centerX - radius, centerY - radius, radius + radius, radius + radius);
        }
    }
}
