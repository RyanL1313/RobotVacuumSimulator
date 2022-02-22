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
        private TileGridAccessor HouseLayoutAccessor;
        private VacuumDisplay Vacuum;

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
            HouseLayoutAccessor = new TileGridAccessor();
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

        private void RoomWidthSelector_ValueChanged(object sender, EventArgs e)
        {
        }

        private void FloorCanvas_Paint(object sender, PaintEventArgs e)
        {
            Graphics canvasEditor = e.Graphics;
            canvasEditor.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            /* Draw 50 x 40 square grid. Each square in the grid is 4 ft^2 */
            for (int i = 0; i < HouseLayoutAccessor.numTilesPerRow; i++)
            {
                for (int j = 0; j < HouseLayoutAccessor.numTilesPerCol; j++)
                {
                    if (HouseLayoutAccessor.floorLayout[i, j].obstacle == ObstacleType.None && HouseLayoutAccessor.gridLinesOn) // Blank tile
                    {
                        DrawTileOutline(i, j, new Pen(Color.Black), canvasEditor);
                    }
                    else if (HouseLayoutAccessor.floorLayout[i, j].obstacle == ObstacleType.Wall) // Wall tile
                    {
                        PaintTile(i, j, new SolidBrush(Color.Black), canvasEditor);
                    }
                    else if (HouseLayoutAccessor.floorLayout[i, j].obstacle == ObstacleType.Chest) // Chest tile
                    {
                        PaintTile(i, j, new SolidBrush(Color.Brown), canvasEditor);
                    }
                    else if (HouseLayoutAccessor.floorLayout[i, j].obstacle == ObstacleType.Chair) // Chair tile
                    {
                        PaintTile(i, j, new SolidBrush(Color.Green), canvasEditor);
                    }
                    else if (HouseLayoutAccessor.floorLayout[i, j].obstacle == ObstacleType.Table) // Table tile
                    {
                        PaintTile(i, j, new SolidBrush(Color.Blue), canvasEditor);
                    }
                }
            }

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
                    if (canvasCoords.X >= HouseLayoutAccessor.numTilesPerRow * TileGridAccessor.tileSideLength || canvasCoords.Y >= HouseLayoutAccessor.numTilesPerCol * TileGridAccessor.tileSideLength)
                        return;

                    ObstacleType ob = TileGridAccessor.GetObstacleTypeFromString(selectedObstruction);

                    // Check that we aren't writing the same value that already exists
                    if (HouseLayoutAccessor.GetTileFromCoordinates(canvasCoords.X, canvasCoords.Y).obstacle != ob)
                    {
                        HouseLayoutAccessor.ModifyTile(canvasCoords.X, canvasCoords.Y, ob);

                        FloorCanvas.Invalidate(); // Re-trigger paint event
                    }
                }
            }
        }

        private void SaveFloorplanButton_Click(object sender, EventArgs e)
        {
            // Modify this in the future
            FloorplanFileWriter.SaveTileGridData("../../../DefaultFloorPlan.txt", HouseLayoutAccessor);
        }

        private void LoadFloorplanButton_Click(object sender, EventArgs e)
        {
            // Read the floorplan data file and store it in HouseLayoutAccessor.floorLayout
            // Modify this in the future
            FloorplanFileReader.LoadTileGridData("../../../DefaultFloorPlan.txt", HouseLayoutAccessor);

            FloorCanvas.Invalidate(); // Re-trigger paint event
        }

        /* Fill a tile using a SolidBrush */
        /* The +1's are there so everything matches up with the grid lines (which are of pen width 1) */

        private void PaintTile(int rowIndex, int colIndex, SolidBrush brush, Graphics canvasEditor)
        {
            canvasEditor.FillRectangle(brush, TileGridAccessor.tileSideLength * rowIndex, TileGridAccessor.tileSideLength * colIndex, TileGridAccessor.tileSideLength + 1, TileGridAccessor.tileSideLength + 1);
        }

        /* Draw a tile (just the outline, no fill) using a Pen */

        private void DrawTileOutline(int rowIndex, int colIndex, Pen penColor, Graphics canvasEditor)
        {
            // Get the coordinates of each tile corner
            Point p1 = new Point(TileGridAccessor.tileSideLength * rowIndex, TileGridAccessor.tileSideLength * colIndex);
            Point p2 = new Point(TileGridAccessor.tileSideLength * rowIndex, TileGridAccessor.tileSideLength * colIndex + TileGridAccessor.tileSideLength);
            Point p3 = new Point(TileGridAccessor.tileSideLength * rowIndex + TileGridAccessor.tileSideLength, TileGridAccessor.tileSideLength * colIndex + TileGridAccessor.tileSideLength);
            Point p4 = new Point(TileGridAccessor.tileSideLength * rowIndex + TileGridAccessor.tileSideLength, TileGridAccessor.tileSideLength * colIndex);

            // Draw the tile
            canvasEditor.DrawLine(penColor, p1, p2);
            canvasEditor.DrawLine(penColor, p2, p3);
            canvasEditor.DrawLine(penColor, p3, p4);
            canvasEditor.DrawLine(penColor, p4, p1);
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
            Vacuum.vacuumCoords[0] += (int)(TileGridAccessor.tileSideLength / 2 * (float)Math.Cos((Math.PI * Vacuum.vacuumHeading) / 180));
            Vacuum.vacuumCoords[1] += (int)(TileGridAccessor.tileSideLength / 2 * (float)Math.Sin((Math.PI * Vacuum.vacuumHeading) / 180));

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
            float lenWhiskersExtendFromVacuum = TileGridAccessor.tileSideLength / 12;
            Vacuum.whiskersHeadingWRTVacuum = (Vacuum.whiskersHeadingWRTVacuum + 30) % 120;
            Vacuum.whiskersEndingCoords[0] = Vacuum.vacuumCoords[0] + (VacuumDisplay.vacuumDiameter / 2 + lenWhiskersExtendFromVacuum) * (float)Math.Cos((Math.PI * Vacuum.vacuumHeading - Vacuum.whiskersHeadingWRTVacuum) / 180);
            Vacuum.whiskersEndingCoords[1] = Vacuum.vacuumCoords[1] + (VacuumDisplay.vacuumDiameter / 2 + lenWhiskersExtendFromVacuum) * (float)Math.Sin((Math.PI * Vacuum.vacuumHeading - Vacuum.whiskersHeadingWRTVacuum) / 180);

            FloorCanvas.Invalidate(); // Re-trigger paint event
        }

        private void StartSimulationButton_Click(object sender, EventArgs e)
        {
            VacuumBodyTimer.Enabled = true;
            VacuumWhiskersTimer.Enabled = true;
            HouseLayoutAccessor.gridLinesOn = false;
        }

        private void StopSimulationButton_Click(object sender, EventArgs e)
        {
            VacuumBodyTimer.Enabled = false;
            VacuumWhiskersTimer.Enabled = false;
            HouseLayoutAccessor.gridLinesOn = true;

            FloorCanvas.Invalidate(); // Re-trigger paint event
        }
    }
}