using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VacuumSim
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// Describes the different pathing algorithm types the robot can use.
        /// </summary>
        /// Not certain an enum is right for this task, but I think it could work.
        private enum PathAlgorithm
        {
            Random,
            Spiral,
            Snaking,
            WallFollow
        }

        private List<string> SimulationSpeeds = new List<string> { "1x", "5x", "50x" };
        private FloorplanLayout HouseLayout;
        private VacuumDisplay Vacuum;
        bool simStarted = false; // Probably need to make a Simulation class in the future and move this there

        /// <summary>
        /// Initializes the algorithm selector to allow for choosing an algorithm type as specified by the PathAlgorithm enum.
        /// </summary>
        private void InitAlgorithmSelector()
        {
            // Set the data source of the dropdown box to be the values of our PathAlgorithm enum.
            RobotPathAlgorithmSelector.DataSource = Enum.GetValues(typeof(PathAlgorithm));
            // Set the default value to the PathAlgorithm.Random value.
            RobotPathAlgorithmSelector.SelectedItem = PathAlgorithm.Random;
        }

        private void InitFloorTileSelector()
        {
            // Set the data source of the dropdown box to be the values of our ObstacleType enum
            ObstacleSelector.DataSource = Enum.GetValues(typeof(ObstacleType));
            // Set the default value to the ObstacleType.WALL;
            ObstacleSelector.SelectedItem = ObstacleType.Wall;
        }

        private void InitSimulationSpeedSelector()
        {
            SimulationSpeedSelector.DataSource = SimulationSpeeds;
        }

        public Form1()
        {
            InitializeComponent();
            InitAlgorithmSelector();
            InitSimulationSpeedSelector();
            InitFloorTileSelector();

            // Create objects needed for drawing to FloorCanvas
            HouseLayout = new FloorplanLayout();
            Vacuum = new VacuumDisplay();

            this.DoubleBuffered = true; // Enable double buffering for smooth animation
        }

        /// <summary>
        /// Callback for clicking the 'Run All Algorithms' checkbox
        /// TODO: Currently just disables the algorithm selector, should tell the robot to run each algorithm.
        /// </summary>
        ///
        private void RunAllAlgorithmsCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (RunAllAlgorithmsCheckbox.Checked)
            {
                RobotPathAlgorithmSelector.Enabled = false;
            }
            else
            {
                RobotPathAlgorithmSelector.Enabled = true;
            }
        }

        private void HouseWidthSelector_ValueChanged(object sender, EventArgs e)
        {
            if (HouseWidthSelector.Value < 2) // Minimum width is 2 ft (1 tile wide)
                HouseWidthSelector.Value = 2;
            else if (HouseWidthSelector.Value > 100) // Maximum width is 100 ft (50 tiles wide)
                HouseWidthSelector.Value = 100;
            else if (HouseWidthSelector.Value * HouseHeightSelector.Value > 8000) // Maximum area is 8000 sq ft
                HouseWidthSelector.Value -= 2; // Go back to previous value
            else if (HouseWidthSelector.Value * HouseHeightSelector.Value < 4) // Minimum area is 4 sq ft
                HouseWidthSelector.Value += 2; // Go back to previous value

            HouseLayout.numTilesPerRow = (int)HouseWidthSelector.Value / 2; // Get number of tiles per row based on house width chosen by user

            FloorCanvas.Invalidate(); // Re-draw canvas to reflect change in house width
        }

        private void HouseHeightSelector_ValueChanged(object sender, EventArgs e)
        {
            if (HouseHeightSelector.Value < 2) // Minimum height is 2 ft (1 tile high)
                HouseHeightSelector.Value = 2;
            else if (HouseHeightSelector.Value > 80) // Maximum height is 80 ft (40 tiles high)
                HouseHeightSelector.Value = 80;
            else if (HouseHeightSelector.Value * HouseHeightSelector.Value > 8000) // Maximum area is 8000 sq ft
                HouseHeightSelector.Value -= 2; // Go back to previous value
            else if (HouseHeightSelector.Value * HouseHeightSelector.Value < 4) // Minimum area is 4 sq ft
                HouseHeightSelector.Value += 2; // Go back to previous value

            HouseLayout.numTilesPerCol = (int)HouseHeightSelector.Value / 2; // Get number of tiles per column based on house height chosen by user

            FloorCanvas.Invalidate(); // Re-draw canvas to reflect change in house height
        }

        private void FloorCanvas_Paint(object sender, PaintEventArgs e)
        {
            Graphics canvasEditor = e.Graphics;
            canvasEditor.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            /* Draw the floor layout. Each square in the grid is 4 ft^2 */
            for (int i = 0; i < HouseLayout.numTilesPerRow; i++)
            {
                for (int j = 0; j < HouseLayout.numTilesPerCol; j++)
                {
                    if (HouseLayout.floorLayout[i, j].obstacle == ObstacleType.None && HouseLayout.gridLinesOn) // Blank tile
                    {
                        DrawTileOutline(i, j, new Pen(Color.Black), canvasEditor);
                    }
                    else if (HouseLayout.floorLayout[i, j].obstacle == ObstacleType.Wall) // Wall tile
                    {
                        PaintTile(i, j, new SolidBrush(Color.Black), canvasEditor);
                    }
                    else if (HouseLayout.floorLayout[i, j].obstacle == ObstacleType.Chest) // Chest tile
                    {
                        PaintTile(i, j, new SolidBrush(Color.Brown), canvasEditor);
                    }
                    else if (HouseLayout.floorLayout[i, j].obstacle == ObstacleType.Chair) // Chair tile
                    {
                        PaintTile(i, j, new SolidBrush(Color.Green), canvasEditor);
                    }
                    else if (HouseLayout.floorLayout[i, j].obstacle == ObstacleType.Table) // Table tile
                    {
                        PaintTile(i, j, new SolidBrush(Color.Blue), canvasEditor);
                    }
                }
            }

            DrawHouseBoundaryLines(canvasEditor); // Draw the boundary lines of the house
            DrawVacuum(canvasEditor); // Draw vacuum to the canvas
        }

        /// <summary>
        /// FloorCanvas_Click is the handler for both the MouseClick and the MouseMove events for FloorCanvas.
        /// This allows us to draw a tile from a single click, as well as a click-and-drag.
        /// Maybe a little bit crude, but it does indeed work.
        /// </summary>
        private void FloorCanvas_Click(object sender, MouseEventArgs e)
        {
            // Check that the sim is not running
            if (!VacuumBodyTimer.Enabled)
            {
                if (e.Button == MouseButtons.Left)
                {
                    Point canvasCoords = FloorCanvas.PointToClient(Cursor.Position);

                    string selectedObstruction = ObstacleSelector.SelectedItem.ToString();

                    // Make sure user clicks within the grid
                    if (canvasCoords.X >= HouseLayout.numTilesPerRow * FloorplanLayout.tileSideLength ||
                        (canvasCoords.X <= 0 ||
                        canvasCoords.Y >= HouseLayout.numTilesPerCol * FloorplanLayout.tileSideLength) ||
                        canvasCoords.Y <= 0)
                        return;

                    ObstacleType ob = FloorplanLayout.GetObstacleTypeFromString(selectedObstruction);

                    // Check that we aren't writing the same value that already exists
                    if (HouseLayout.GetTileFromCoordinates(canvasCoords.X, canvasCoords.Y).obstacle != ob)
                    {
                        HouseLayout.ModifyTile(canvasCoords.X, canvasCoords.Y, ob);

                        FloorCanvas.Invalidate(); // Re-trigger paint event
                    }
                }
            }
        }

        private void SaveFloorplanButton_Click(object sender, EventArgs e)
        {
            // Modify this in the future
            FloorplanFileWriter.SaveTileGridData("../../../DefaultFloorplan.txt", HouseLayout);
        }

        private void LoadFloorplanButton_Click(object sender, EventArgs e)
        {
            // Change this in future when we need to load other floorplans
            HouseWidthSelector.Value = 50;
            HouseHeightSelector.Value = 40;

            // Read the floorplan data file and store it in HouseLayoutAccessor.floorLayout
            // Modify this in the future
            FloorplanFileReader.LoadTileGridData("../../../DefaultFloorplan.txt", HouseLayout);

            FloorCanvas.Invalidate(); // Re-trigger paint event
        }

        /* Fill a tile using a SolidBrush */
        /* The +1's are there so everything matches up with the grid lines (which are of pen width 1) */

        private void PaintTile(int rowIndex, int colIndex, SolidBrush brush, Graphics canvasEditor)
        {
            canvasEditor.FillRectangle(brush, FloorplanLayout.tileSideLength * rowIndex, FloorplanLayout.tileSideLength * colIndex, FloorplanLayout.tileSideLength + 1, FloorplanLayout.tileSideLength + 1);
        }

        /* Draw a tile (just the outline, no fill) using a Pen */

        private void DrawTileOutline(int rowIndex, int colIndex, Pen penColor, Graphics canvasEditor)
        {
            // Get the coordinates of each tile corner
            Point p1 = new Point(FloorplanLayout.tileSideLength * rowIndex, FloorplanLayout.tileSideLength * colIndex);
            Point p2 = new Point(FloorplanLayout.tileSideLength * rowIndex, FloorplanLayout.tileSideLength * colIndex + FloorplanLayout.tileSideLength);
            Point p3 = new Point(FloorplanLayout.tileSideLength * rowIndex + FloorplanLayout.tileSideLength, FloorplanLayout.tileSideLength * colIndex + FloorplanLayout.tileSideLength);
            Point p4 = new Point(FloorplanLayout.tileSideLength * rowIndex + FloorplanLayout.tileSideLength, FloorplanLayout.tileSideLength * colIndex);

            // Draw the tile
            canvasEditor.DrawLine(penColor, p1, p2);
            canvasEditor.DrawLine(penColor, p2, p3);
            canvasEditor.DrawLine(penColor, p3, p4);
            canvasEditor.DrawLine(penColor, p4, p1);
        }

        private void DrawHouseBoundaryLines(Graphics canvasEditor)
        {
            if (!simStarted) // No need to draw the boundary lines if the grid is still being displayed
                return;

            Pen BlackPen = new Pen(Color.Black);

            Point p1 = new Point(0, 0);
            Point p2 = new Point(0, HouseLayout.numTilesPerCol * FloorplanLayout.tileSideLength + 1);
            Point p3 = new Point(HouseLayout.numTilesPerRow * FloorplanLayout.tileSideLength + 1, HouseLayout.numTilesPerCol * FloorplanLayout.tileSideLength + 1);
            Point p4 = new Point(HouseLayout.numTilesPerRow * FloorplanLayout.tileSideLength + 1, 0);

            // Draw the house boundary
            canvasEditor.DrawLine(BlackPen, p1, p2);
            canvasEditor.DrawLine(BlackPen, p2, p3);
            canvasEditor.DrawLine(BlackPen, p3, p4);
            canvasEditor.DrawLine(BlackPen, p4, p1);
        }

        /* Draws the vacuum onto the canvas */

        private void DrawVacuum(Graphics canvasEditor)
        {
            // Draw vacuum whiskers
            Pen charcoalGrayPen = new Pen(Color.FromArgb(255, 72, 70, 70));
            PointF whiskersStart = new PointF(Vacuum.whiskersStartingCoords[0], Vacuum.whiskersStartingCoords[1]);
            PointF whiskersEnd = new PointF(Vacuum.whiskersEndingCoords[0], Vacuum.whiskersEndingCoords[1]);
            canvasEditor.DrawLine(charcoalGrayPen, whiskersStart, whiskersEnd);

            // Draw vacuum body
            SolidBrush charcoalGrayBrush = new SolidBrush(Color.FromArgb(255, 72, 70, 70));
            FillCircle(charcoalGrayBrush, VacuumDisplay.vacuumDiameter / 2, Vacuum.vacuumCoords[0], Vacuum.vacuumCoords[1], canvasEditor);
        }

        /* Helper function to draw filled circles using FillEllipse */

        private void FillCircle(SolidBrush brush, float radius, float centerX, float centerY, Graphics canvasEditor)
        {
            canvasEditor.FillEllipse(brush, centerX - radius, centerY - radius, radius + radius, radius + radius);
        }

        private void VacuumBodyTimer_Tick(object sender, EventArgs e)
        {
            // TO-DO: Calculate next (x, y) position of vacuum based on selected algorithm (backend)

            // Initial attempt at animating the vacuum to go in a circle
            // 12 inches/second = half tile length/second
            Vacuum.vacuumCoords[0] += (int)(FloorplanLayout.tileSideLength / 2 * (float)Math.Cos((Math.PI * Vacuum.vacuumHeading) / 180));
            Vacuum.vacuumCoords[1] += (int)(FloorplanLayout.tileSideLength / 2 * (float)Math.Sin((Math.PI * Vacuum.vacuumHeading) / 180));

            FloorCanvas.Invalidate(); // Re-trigger paint event

            Vacuum.vacuumHeading = (Vacuum.vacuumHeading + 45) % 360;
        }

        private void VacuumWhiskersTimer_Tick(object sender, EventArgs e)
        {
            // Choose fixed start (x, y) coordinates of whiskers based on vacuum heading
            Vacuum.whiskersStartingCoords[0] = Vacuum.vacuumCoords[0] + (VacuumDisplay.vacuumDiameter / 2) * (float)Math.Cos((Math.PI * Vacuum.vacuumHeading - 30) / 180);
            Vacuum.whiskersStartingCoords[1] = Vacuum.vacuumCoords[1] + (VacuumDisplay.vacuumDiameter / 2) * (float)Math.Sin((Math.PI * Vacuum.vacuumHeading - 30) / 180);

            // Calculate ending (x, y) coordinates of whiskers
            // Also, remember that 2 inch long whiskers = tile side length (2 ft = 24 inches) / 12
            float lenWhiskersExtendFromVacuum = FloorplanLayout.tileSideLength / 12;
            Vacuum.whiskersHeadingWRTVacuum = (Vacuum.whiskersHeadingWRTVacuum + 30) % 120;
            Vacuum.whiskersEndingCoords[0] = Vacuum.vacuumCoords[0] + (VacuumDisplay.vacuumDiameter / 2 + lenWhiskersExtendFromVacuum) * (float)Math.Cos((Math.PI * Vacuum.vacuumHeading - Vacuum.whiskersHeadingWRTVacuum) / 180);
            Vacuum.whiskersEndingCoords[1] = Vacuum.vacuumCoords[1] + (VacuumDisplay.vacuumDiameter / 2 + lenWhiskersExtendFromVacuum) * (float)Math.Sin((Math.PI * Vacuum.vacuumHeading - Vacuum.whiskersHeadingWRTVacuum) / 180);

            FloorCanvas.Invalidate(); // Re-trigger paint event
        }

        private void StartSimulationButton_Click(object sender, EventArgs e)
        {
            VacuumBodyTimer.Enabled = true;
            VacuumWhiskersTimer.Enabled = true;
            HouseLayout.gridLinesOn = false;
            HouseWidthSelector.Enabled = false;
            HouseHeightSelector.Enabled = false;
            simStarted = true;
        }

        private void StopSimulationButton_Click(object sender, EventArgs e)
        {
            VacuumBodyTimer.Enabled = false;
            VacuumWhiskersTimer.Enabled = false;
            HouseLayout.gridLinesOn = true;
            HouseWidthSelector.Enabled = true;
            HouseHeightSelector.Enabled = true;
            simStarted = false;

            FloorCanvas.Invalidate(); // Re-trigger paint event
        }
    }
}