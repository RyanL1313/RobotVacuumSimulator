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
        public static bool editingFloorplan = true; // Is the user currently editing the floorplan?
        public static bool settingVacuumAttributes = false; // Is the user in the vacuum attribute editing stage?
        public static bool currentlyPlacingVacuum = false; // Is the user currently placing the vacuum?
        public static bool vacuumPlacingLocationIsValid = true; // Is the vacuum currently being placed in a valid location?
        public static bool successPlacingVacuum = false; // Was the previous attempt at placing the vacuum onto the floorplan successful?
        public static bool eraserModeOn = false; // Is the user currently drawing in eraser mode?
        public static bool roomCreatorModeOn = false; // Is the user currently in room creator mode?
        public static bool chairTableDrawingModeOn = false; // Is the user currently in chair/table drawing mode?
        public static bool currentlyAddingObstacle = false; // Is the user currently adding an obstacle?
        public static bool successAddingObstacle = true; // Was the previous attempt at adding an obstacle successful?
        public static ObstacleType currentObstacleBeingAdded; // Current obstacle being added
        public static int[] currentIndicesOfSelectedTile = { -1, -1 }; // col, row indices of tile currently selected
        public static FloorplanLayout FloorplanHouseDesigner; // Floorplan that gets used when adding obstacle

        /// <summary>
        /// Turns on anti-aliasing
        /// </summary>
        /// <param name="CanvasEditor"> Graphics object to edit FloorCanvas </param>
        public static void SetAntiAliasing(Graphics CanvasEditor)
        {
            CanvasEditor.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
        }

        /// <summary>
        /// Draws the floorplan to FloorCanvas based on HouseLayout's 2D array of tiles
        /// </summary>
        /// <param name="CanvasEditor"> Graphics object to edit FloorCanvas </param>
        /// <param name="HouseLayout"> The current floorplan layout </param>
        public static void DrawFloorplan(Graphics CanvasEditor, FloorplanLayout HouseLayout, VacuumDisplay VacDisplay)
        {
            // Get the current layout, depending on if we're in design mode or just displaying the floorplan
            FloorplanLayout CurrentLayout = currentlyAddingObstacle ? FloorplanHouseDesigner : HouseLayout;

            for (int i = 0; i < CurrentLayout.numTilesPerRow; i++)
            {
                for (int j = 0; j < CurrentLayout.numTilesPerCol; j++)
                {
                    if ((CurrentLayout.floorLayout[i, j].obstacle == ObstacleType.Floor || CurrentLayout.floorLayout[i, j].obstacle == ObstacleType.Doorway) && CurrentLayout.gridLinesOn) // Blank tile
                    {
                        DrawTileOutline(i, j, new Pen(Color.Black), CanvasEditor);
                    }
                    else if (CurrentLayout.floorLayout[i, j].obstacle == ObstacleType.Wall) // Wall tile
                    {
                        PaintTile(i, j, new SolidBrush(Color.Black), CanvasEditor);
                    }
                    else if (CurrentLayout.floorLayout[i, j].obstacle == ObstacleType.Chest) // Chest tile
                    {
                        PaintTile(i, j, new SolidBrush(Color.Sienna), CanvasEditor);
                    }
                    else if (CurrentLayout.floorLayout[i, j].obstacle == ObstacleType.Chair) // Chair tile
                    {
                        if (CurrentLayout.gridLinesOn)
                            DrawTileOutline(i, j, new Pen(Color.Black), CanvasEditor);

                        DrawChairOrTable(i, j, CurrentLayout, new SolidBrush(Color.DarkSlateBlue), CanvasEditor);
                    }
                    else if (CurrentLayout.floorLayout[i, j].obstacle == ObstacleType.Table) // Table tile
                    {
                        if (CurrentLayout.gridLinesOn)
                            DrawTileOutline(i, j, new Pen(Color.Black), CanvasEditor);

                        DrawChairOrTable(i, j, CurrentLayout, new SolidBrush(Color.Tomato), CanvasEditor);
                    }
                    else if (CurrentLayout.floorLayout[i, j].obstacle == ObstacleType.Success) // Success tile
                    {
                        PaintTile(i, j, new SolidBrush(Color.LimeGreen), CanvasEditor);
                    }
                    else if (CurrentLayout.floorLayout[i, j].obstacle == ObstacleType.Error) // Error tile
                    {
                        PaintTile(i, j, new SolidBrush(Color.Red), CanvasEditor);
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
            canvasEditor.FillRectangle(brush, FloorplanLayout.tileSideLength * rowIndex, FloorplanLayout.tileSideLength * colIndex, FloorplanLayout.tileSideLength, FloorplanLayout.tileSideLength);
        }

        /// <summary>
        /// Paints a light sky blue background behind every chair/table tile
        /// Might remove in future once we actually use a visual display of the floor covering being used.
        /// </summary>
        /// <param name="CurrentLayout"> The active FloorplanLayout object </param>
        /// <param name="CanvasEditor"> Graphics object to edit FloorCanvas </param>
        public static void PaintChairAndTableBackgrounds(Graphics CanvasEditor, FloorplanLayout CurrentLayout)
        {
            for (int i = 0; i < CurrentLayout.numTilesPerRow; i++)
            {
                for (int j = 0; j < CurrentLayout.numTilesPerCol; j++)
                {
                    if (CurrentLayout.floorLayout[i, j].obstacle == ObstacleType.Chair || CurrentLayout.floorLayout[i, j].obstacle == ObstacleType.Table)
                        PaintTile(i, j, new SolidBrush(Color.LightSkyBlue), CanvasEditor);
                }
            }
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
            Point p2 = new Point(0, HouseLayout.numTilesPerCol * FloorplanLayout.tileSideLength);
            Point p3 = new Point(HouseLayout.numTilesPerRow * FloorplanLayout.tileSideLength, HouseLayout.numTilesPerCol * FloorplanLayout.tileSideLength);
            Point p4 = new Point(HouseLayout.numTilesPerRow * FloorplanLayout.tileSideLength, 0);

            // Draw the house boundary
            CanvasEditor.DrawLine(BlackPen, p1, p2);
            CanvasEditor.DrawLine(BlackPen, p2, p3);
            CanvasEditor.DrawLine(BlackPen, p3, p4);
            CanvasEditor.DrawLine(BlackPen, p4, p1);
        }

        /// <summary>
        /// Draws the vacuum onto FloorCanvas
        /// </summary>
        /// <param name="CanvasEditor"> Graphics object to edit FloorCanvas </param>
        /// <param name="VacDisplay"> The display of the vacuum onto FloorCanvas </param>
        public static void DrawVacuum(Graphics CanvasEditor, VacuumDisplay VacDisplay)
        {
            if (!Simulation.simStarted && !successPlacingVacuum && !currentlyPlacingVacuum) // Don't draw vacuum if none of these cases are true
                return;

            Pen whiskersPen;
            SolidBrush vacuumBrush;

            // Determine brush and pen color
            if (!currentlyPlacingVacuum) // Not currently placing the vacuum. Draw it charcoal gray
            {
                whiskersPen = new Pen(Color.Indigo);
                vacuumBrush = new SolidBrush(Color.Indigo);
            }
            else // Currently placing the vacuum. Will be red or lime green depending on if vacuum is in valid location or not
            {
                if (vacuumPlacingLocationIsValid)
                {
                    whiskersPen = new Pen(Color.LimeGreen);
                    vacuumBrush = new SolidBrush(Color.LimeGreen);
                }
                else
                {
                    whiskersPen = new Pen(Color.Red);
                    vacuumBrush = new SolidBrush(Color.Red);
                }
            }

            FloorCanvasCalculator.CalculateWhiskerCoordinates(VacDisplay);

            // Draw vacuum whiskers
            PointF whiskersStart = new PointF(VacDisplay.whiskersStartingCoords[0], VacDisplay.whiskersStartingCoords[1]);
            PointF whiskersEnd = new PointF(VacDisplay.whiskersEndingCoords[0], VacDisplay.whiskersEndingCoords[1]);
            CanvasEditor.DrawLine(whiskersPen, whiskersStart, whiskersEnd);

            // Draw vacuum body
            FillCircle(vacuumBrush, VacuumDisplay.vacuumDiameter / 2, VacDisplay.vacuumCoords[0], VacDisplay.vacuumCoords[1], CanvasEditor);
        }

        /// <summary>
        /// Draws a chair or table, which consists of 4 circles for legs.
        /// </summary>
        /// <param name="rowIndex"> Index of selected row </param>
        /// <param name="colIndex"> Index of selected column </param>
        /// <param name="CurrentLayout"> The active layout (either the normal house or the designer mode house) </param>
        /// <param name="brush"> Brush to draw the chair/table </param>
        /// <param name="CanvasEditor"> Graphics object to edit FloorCanvas </param>
        public static void DrawChairOrTable(int rowIndex, int colIndex, FloorplanLayout CurrentLayout, SolidBrush brush, Graphics CanvasEditor)
        {
            // Get the coordinates of each leg of the chair/table
            float[,] chairOrTableCoordinates = CurrentLayout.GetChairOrTableLegCoordinates(CurrentLayout.floorLayout[rowIndex, colIndex]);

            // Prevent drawing the chair/table legs again if we've already drawn them once
            // We know we've already drawn them if we are not currently checking the upper left tile associated with the table/chair
            if ((rowIndex != (int)chairOrTableCoordinates[FloorplanLayout.UL, 0] / FloorplanLayout.tileSideLength || colIndex != (int)chairOrTableCoordinates[FloorplanLayout.UL, 1] / FloorplanLayout.tileSideLength) && !currentlyAddingObstacle)
                return;

            // Draw the chair/table legs (unless they are being covered up as the user is adding an obstacle)
            if (CurrentLayout.floorLayout[(int)chairOrTableCoordinates[FloorplanLayout.LL, 0] / FloorplanLayout.tileSideLength, (int)chairOrTableCoordinates[FloorplanLayout.LL, 1] / FloorplanLayout.tileSideLength].obstacle != ObstacleType.Error)
                FillCircle(brush, FloorplanLayout.chairAndTableLegRadius, chairOrTableCoordinates[FloorplanLayout.LL, 0], chairOrTableCoordinates[FloorplanLayout.LL, 1], CanvasEditor);
            if (CurrentLayout.floorLayout[(int)chairOrTableCoordinates[FloorplanLayout.LR, 0] / FloorplanLayout.tileSideLength, (int)chairOrTableCoordinates[FloorplanLayout.LR, 1] / FloorplanLayout.tileSideLength].obstacle != ObstacleType.Error)
                FillCircle(brush, FloorplanLayout.chairAndTableLegRadius, chairOrTableCoordinates[FloorplanLayout.LR, 0], chairOrTableCoordinates[FloorplanLayout.LR, 1], CanvasEditor);
            if (CurrentLayout.floorLayout[(int)chairOrTableCoordinates[FloorplanLayout.UR, 0] / FloorplanLayout.tileSideLength, (int)chairOrTableCoordinates[FloorplanLayout.UR, 1] / FloorplanLayout.tileSideLength].obstacle != ObstacleType.Error)
                FillCircle(brush, FloorplanLayout.chairAndTableLegRadius, chairOrTableCoordinates[FloorplanLayout.UR, 0], chairOrTableCoordinates[FloorplanLayout.UR, 1], CanvasEditor);
            if (CurrentLayout.floorLayout[(int)chairOrTableCoordinates[FloorplanLayout.UL, 0] / FloorplanLayout.tileSideLength, (int)chairOrTableCoordinates[FloorplanLayout.UL, 1] / FloorplanLayout.tileSideLength].obstacle != ObstacleType.Error)
                FillCircle(brush, FloorplanLayout.chairAndTableLegRadius, chairOrTableCoordinates[FloorplanLayout.UL, 0], chairOrTableCoordinates[FloorplanLayout.UL, 1], CanvasEditor);
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

        /// <summary>
        /// This gets called as user is clicking and dragging the vacuum around.
        /// It sets the "vacuumPlacingLocationIsValid" flag to true or false depending on if the vacuum was placed in a valid location or not.
        /// Then, in "FloorCanvas_MouseUp" in Form1.cs, it is decided if the vacuum can be placed or not, depending on if it was successfully placed or not
        /// </summary>
        /// <param name="HouseLayout"> The floorplan layout for the actual house </param>
        /// <param name="VacDisplay"> The display of the vacuum onto the canvas </param>
        public static void AttemptPlaceVacuum(FloorplanLayout HouseLayout, VacuumDisplay VacDisplay)
        {
            vacuumPlacingLocationIsValid = true; // Initially set to true, could get changed if vacuum is in invalid position

            // Get center tile and its (x, y) indices
            Tile tileContainingVacuumCenter = HouseLayout.GetTileFromCoordinates((int)VacDisplay.vacuumCoords[0], (int)VacDisplay.vacuumCoords[1]);

            int[] centerTileIndices = FloorplanLayout.GetTileIndices(tileContainingVacuumCenter.x, tileContainingVacuumCenter.y);

            // If tile containing vacuum center is a chest or wall tile, this is for sure invalid
            if (tileContainingVacuumCenter.obstacle == ObstacleType.Chest || tileContainingVacuumCenter.obstacle == ObstacleType.Wall)
            {
                vacuumPlacingLocationIsValid = false;
                return;
            }

            List<Tile> tilesVacuumCouldBeIn = new List<Tile>();

            // Get all tiles surrounding the center tile (including tiles connected by a corner)
            for (int i = centerTileIndices[0] - 1; i <= centerTileIndices[0] + 1; i++)
            {
                for (int j = centerTileIndices[1] - 1; j <= centerTileIndices[1] + 1; j++)
                {
                    if (i >= 0 && j >= 0 && i < HouseLayout.numTilesPerRow && j < HouseLayout.numTilesPerCol) // Make sure tile index is within grid
                    {
                        tilesVacuumCouldBeIn.Add(HouseLayout.floorLayout[i, j]);
                    }
                }
            }

            // Iterate through each possible tile and detect if the vacuum is touching any obstacles
            foreach (Tile tile in tilesVacuumCouldBeIn)
            {
                if (tile.obstacle == ObstacleType.Floor || tile.obstacle == ObstacleType.Doorway)
                    continue; // Vacuum can touch any part of this tile with no issues

                float vacRadius = VacuumDisplay.vacuumDiameter / 2.0f;
                float chairAndTableLegRadius = FloorplanLayout.chairAndTableLegRadius;
                int lenTile = FloorplanLayout.tileSideLength;

                // If vacRadius > abs(center - xVert) and part of the vacuum is between upper and lower bounds of the tile ==> COLLISION
                // If vacRadius > abs(center - yHoriz) and part of the vacuum is between left and right bounds of the tile ==> COLLISION
                if (tile.obstacle == ObstacleType.Wall || tile.obstacle == ObstacleType.Chest) // Check for circle intersection with line
                {
                    if (vacRadius > Math.Abs(VacDisplay.vacuumCoords[0] - tile.x) && ((VacDisplay.vacuumCoords[1] - vacRadius < tile.y + lenTile && VacDisplay.vacuumCoords[1] - vacRadius > tile.y) || (VacDisplay.vacuumCoords[1] + vacRadius > tile.y && VacDisplay.vacuumCoords[1] + vacRadius < tile.y + lenTile)))
                        vacuumPlacingLocationIsValid = false; // Vacuum intersected with left vertical tile line
                    else if (vacRadius > Math.Abs(VacDisplay.vacuumCoords[0] - (tile.x + lenTile)) && ((VacDisplay.vacuumCoords[1] - vacRadius < tile.y + lenTile && VacDisplay.vacuumCoords[1] - vacRadius > tile.y) || (VacDisplay.vacuumCoords[1] + vacRadius > tile.y && VacDisplay.vacuumCoords[1] + vacRadius < tile.y + lenTile)))
                        vacuumPlacingLocationIsValid = false; // Vacuum intersected with right vertical tile line
                    else if (vacRadius > Math.Abs(VacDisplay.vacuumCoords[1] - tile.y) && ((VacDisplay.vacuumCoords[0] - vacRadius < tile.x + lenTile && VacDisplay.vacuumCoords[0] - vacRadius > tile.x) || (VacDisplay.vacuumCoords[0] + vacRadius > tile.x && VacDisplay.vacuumCoords[0] + vacRadius < tile.x + lenTile)))
                        vacuumPlacingLocationIsValid = false; // Vacuum intersected with top horizontal tile line
                    else if (vacRadius > Math.Abs(VacDisplay.vacuumCoords[1] - (tile.y + lenTile)) && ((VacDisplay.vacuumCoords[0] - vacRadius < tile.x + lenTile && VacDisplay.vacuumCoords[0] - vacRadius > tile.x) || (VacDisplay.vacuumCoords[0] + vacRadius > tile.x && VacDisplay.vacuumCoords[0] + vacRadius < tile.x + lenTile)))
                        vacuumPlacingLocationIsValid = false; // Vacuum intersected with bottom horizontal tile line
                }
                else if (tile.obstacle == ObstacleType.Chair || tile.obstacle == ObstacleType.Table) // Check for circle intersection with circle or circle enveloping circle
                {
                    float[,] chairOrTableLegCoords = HouseLayout.GetChairOrTableLegCoordinates(tile);

                    // Iterate through each chair/table leg coordinate pair and check for collision with any of the legs
                    for (int i = 0; i < 4; i++)
                    {
                        double sumCircleCenterDistSquared = Math.Pow(VacDisplay.vacuumCoords[0] - chairOrTableLegCoords[i, 0], 2) + Math.Pow(VacDisplay.vacuumCoords[1] - chairOrTableLegCoords[i, 1], 2);

                        // Check if distance between circle centers is between the sum and difference of their radii
                        // If so, the circles intersect
                        if (sumCircleCenterDistSquared > Math.Pow(vacRadius - chairAndTableLegRadius, 2) && sumCircleCenterDistSquared < Math.Pow(vacRadius + chairAndTableLegRadius, 2))
                            vacuumPlacingLocationIsValid = false;
                        // Check if vacuum completely envelopes a chair/table leg without intersecting along the edge
                        // This would still be a collision
                        else if (vacRadius > Math.Sqrt(sumCircleCenterDistSquared) + chairAndTableLegRadius)
                            vacuumPlacingLocationIsValid = false;
                    }
                }
            }
        }

        /// <summary>
        /// Edits the "designer mode" floorplan to mark tiles as "Success" or "Error" if they can/cannot be placed here
        /// </summary>
        /// <param name="selectedObstacle"> Chair or Table being added </param>
        /// <param name="xTileIndex"> The selected column </param>
        /// <param name="yTileIndex"> The selected row </param>
        /// <param name="widthInFeet"> Obstacle width in feet </param>
        /// <param name="heightInFeet"> Obstacle height in feet </param>
        public static void AttemptAddChairOrTableToFloorplan(ObstacleType selectedObstacle, int xTileIndex, int yTileIndex, int widthInFeet, int heightInFeet)
        {
            currentObstacleBeingAdded = selectedObstacle;
            int chairTableWidthInTiles = widthInFeet / 2;
            int chairTableHeightInTiles = heightInFeet / 2;
            successAddingObstacle = true; // Initially set to true, could get changed if obstacle is in invalid position

            // Check if chair/table can be placed at this location
            for (int i = xTileIndex; i < xTileIndex + chairTableWidthInTiles; i++)
            {
                for (int j = yTileIndex; j < yTileIndex + chairTableHeightInTiles; j++)
                {
                    // Check if tile is out of bounds or non-floor obstacle already present at this tile
                    if ((i >= FloorplanHouseDesigner.numTilesPerRow || j >= FloorplanHouseDesigner.numTilesPerCol) || FloorplanHouseDesigner.floorLayout[i, j].obstacle != ObstacleType.Floor)
                        successAddingObstacle = false;
                }
            }

            // If chair/table can't be placed here, mark the tiles that the chair/table is covering as error tiles
            if (!successAddingObstacle)
            {
                for (int i = xTileIndex; i < xTileIndex + chairTableWidthInTiles && i < FloorplanHouseDesigner.numTilesPerRow; i++)
                {
                    for (int j = yTileIndex; j < yTileIndex + chairTableHeightInTiles && j < FloorplanHouseDesigner.numTilesPerCol; j++)
                    {
                        FloorplanHouseDesigner.ModifyTileBasedOnIndices(i, j, ObstacleType.Error);
                    }
                }
            }
            else // Chair/table can be placed here. Mark the associated tiles as success tiles
            {
                for (int i = xTileIndex; i < xTileIndex + chairTableWidthInTiles && i < FloorplanHouseDesigner.numTilesPerRow; i++)
                {
                    for (int j = yTileIndex; j < yTileIndex + chairTableHeightInTiles && j < FloorplanHouseDesigner.numTilesPerCol; j++)
                    {
                        FloorplanHouseDesigner.ModifyTileBasedOnIndices(i, j, ObstacleType.Success);
                    }
                }
            }
        }

        /// <summary>
        /// Edits the "designer mode" floorplan to mark chest tile as "Success" or "Error" if it can/cannot be placed here
        /// </summary>
        /// <param name="xTileIndex"> The selected column </param>
        /// <param name="yTileIndex"> The selected row </param>
        public static void AttemptAddChestToFloorplan(int xTileIndex, int yTileIndex)
        {
            currentObstacleBeingAdded = ObstacleType.Chest;
            successAddingObstacle = true; // Initially set to true, could get changed if obstacle is in invalid position

            // Check if chest can be placed at this location
            if ((xTileIndex >= FloorplanHouseDesigner.numTilesPerRow || yTileIndex >= FloorplanHouseDesigner.numTilesPerCol) || FloorplanHouseDesigner.floorLayout[xTileIndex, yTileIndex].obstacle != ObstacleType.Floor)
                successAddingObstacle = false;

            // If chest can't be placed here, mark the tile that the chest is covering as an error tile
            if (!successAddingObstacle)
                FloorplanHouseDesigner.ModifyTileBasedOnIndices(xTileIndex, yTileIndex, ObstacleType.Error);
            else // Chest can be placed here. Mark the associated tile as a success tile
                FloorplanHouseDesigner.ModifyTileBasedOnIndices(xTileIndex, yTileIndex, ObstacleType.Success);
        }

        /// <summary>
        /// Removes all tiles making up a chair/table from the floorplan
        /// </summary>
        /// <param name="HouseLayout"> The floorplan layout for the actual house </param>
        /// <param name="xTileIndex"> The selected column </param>
        /// <param name="yTileIndex"> The selected row </param>
        public static void RemoveChairOrTableFromFloorplan(FloorplanLayout HouseLayout, int xTileIndex, int yTileIndex)
        {
            int[,] legIndices = HouseLayout.GetChairOrTableLegIndices(HouseLayout.floorLayout[xTileIndex, yTileIndex]);

            // Iterate through each affected tile and set them to floor tiles
            for (int i = legIndices[FloorplanLayout.UL, 0]; i <= legIndices[FloorplanLayout.UR, 0]; i++)
            {
                for (int j = legIndices[FloorplanLayout.UL, 1]; j <= legIndices[FloorplanLayout.LL, 1]; j++)
                {
                    HouseLayout.floorLayout[i, j].obstacle = ObstacleType.Floor;
                    HouseLayout.floorLayout[i, j].groupID = -1;
                }
            }
        }

        /// <summary>
        /// Removes the tile making up a chest from the floorplan
        /// </summary>
        /// <param name="HouseLayout"> The floorplan layout for the actual house </param>
        /// <param name="xTileIndex"> The selected column </param>
        /// <param name="yTileIndex"> The selected row </param>
        public static void RemoveChestFromFloorplan(FloorplanLayout HouseLayout, int xTileIndex, int yTileIndex)
        {
            // Set the tile to be a floor tile
            HouseLayout.floorLayout[xTileIndex, yTileIndex].obstacle = ObstacleType.Floor;
            HouseLayout.floorLayout[xTileIndex, yTileIndex].groupID = -1;
        }

        /// <summary>
        /// Changes every tile in the "design mode" house layout with a Success obstacle to contain the obstacle currently selected
        /// </summary>
        public static void ChangeSuccessTilesToCurrentObstacle()
        {
            for (int i = 0; i < FloorplanHouseDesigner.numTilesPerRow; i++)
            {
                for (int j = 0; j < FloorplanHouseDesigner.numTilesPerCol; j++)
                {
                    if (FloorplanHouseDesigner.floorLayout[i, j].obstacle == ObstacleType.Success)
                    {
                        FloorplanHouseDesigner.ModifyTileBasedOnIndices(i, j, currentObstacleBeingAdded);
                        FloorplanHouseDesigner.floorLayout[i, j].groupID = FloorplanFileWriter.currentObstacleGroupNumber; // Assign group ID
                    }
                }
            }

            FloorplanFileWriter.currentObstacleGroupNumber++; // Obstacle was successfully placed, assign its corresponding tiles a group ID
        }
    }
}
