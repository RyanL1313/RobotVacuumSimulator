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

        private void InitSimulationSpeedSelector()
        {
            SimulationSpeedSelector.DataSource = SimulationSpeeds;
        }

        public Form1()
        {
            InitializeComponent();
            InitAlgorithmSelector();
            InitSimulationSpeedSelector();

            HouseLayoutAccessor = new TileGridAccessor();
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
            Graphics gridEditor = e.Graphics;

            /* Draw 50 x 40 grid. Each square in the grid is 4 ft^2 */
            for (int i = 0; i < HouseLayoutAccessor.numTilesPerRow; i++)
            {
                for (int j = 0; j < HouseLayoutAccessor.numTilesPerCol; j++)
                {
                    if (HouseLayoutAccessor.floorLayout[i, j].obstacle == ObstacleType.NONE) // Blank tile
                    {
                        DrawTileOutline(i, j, new Pen(Color.Black), gridEditor);
                    }
                    else if (HouseLayoutAccessor.floorLayout[i, j].obstacle == ObstacleType.WALL) // Wall tile
                    {
                        PaintTile(i, j, new SolidBrush(Color.Black), gridEditor);
                    }
                    else if (HouseLayoutAccessor.floorLayout[i, j].obstacle == ObstacleType.CHEST) // Chest tile
                    {
                        PaintTile(i, j, new SolidBrush(Color.Brown), gridEditor);
                    }
                    else if (HouseLayoutAccessor.floorLayout[i, j].obstacle == ObstacleType.CHAIR) // Chair tile
                    {
                        PaintTile(i, j, new SolidBrush(Color.Green), gridEditor);
                    }
                    else if (HouseLayoutAccessor.floorLayout[i, j].obstacle == ObstacleType.TABLE) // Table tile
                    {
                        PaintTile(i, j, new SolidBrush(Color.Blue), gridEditor);
                    }
                }
            }
        }

        private void FloorCanvas_Click(object sender, EventArgs e)
        {
            Point canvasCoords = FloorCanvas.PointToClient(Cursor.Position);

            string selectedObstruction = ObstacleSelector.SelectedItem.ToString();

            // Make sure user clicks within the grid
            if (canvasCoords.X >= HouseLayoutAccessor.numTilesPerRow * HouseLayoutAccessor.tileSideLength || canvasCoords.Y >= HouseLayoutAccessor.numTilesPerCol * HouseLayoutAccessor.tileSideLength)
                return;

            ObstacleType ob = TileGridAccessor.GetObstacleTypeFromString(selectedObstruction);

            HouseLayoutAccessor.ModifyTile(canvasCoords.X, canvasCoords.Y, ob);

            FloorCanvas.Invalidate(); // Re-trigger paint event
        }

        private void SaveFloorplanButton_Click(object sender, EventArgs e)
        {
            FloorplanFileWriter.SaveTileGridData("../../../DefaultFloorPlan.txt", HouseLayoutAccessor);
        }

        private void LoadFloorplanButton_Click(object sender, EventArgs e)
        {
            // Read the floorplan data file and store it in HouseLayoutAccessor.floorLayout
            FloorplanFileReader.LoadTileGridData("../../../DefaultFloorPlan.txt", HouseLayoutAccessor);
            
            FloorCanvas.Invalidate(); // Re-trigger paint event
        }

        /* Fill a tile using a SolidBrush */
        private void PaintTile(int rowIndex, int colIndex, SolidBrush brush, Graphics gridEditor)
        {
            gridEditor.FillRectangle(brush, HouseLayoutAccessor.tileSideLength * rowIndex, HouseLayoutAccessor.tileSideLength * colIndex, HouseLayoutAccessor.tileSideLength, HouseLayoutAccessor.tileSideLength);
        }

        /* Draw a tile (just the outline, no fill) using a Pen */
        private void DrawTileOutline(int rowIndex, int colIndex, Pen penColor, Graphics gridEditor)
        {
            // Get the coordinates of each tile corner
            Point p1 = new Point(HouseLayoutAccessor.tileSideLength * rowIndex, HouseLayoutAccessor.tileSideLength * colIndex);
            Point p2 = new Point(HouseLayoutAccessor.tileSideLength * rowIndex, HouseLayoutAccessor.tileSideLength * colIndex + HouseLayoutAccessor.tileSideLength);
            Point p3 = new Point(HouseLayoutAccessor.tileSideLength * rowIndex + HouseLayoutAccessor.tileSideLength, HouseLayoutAccessor.tileSideLength * colIndex + HouseLayoutAccessor.tileSideLength);
            Point p4 = new Point(HouseLayoutAccessor.tileSideLength * rowIndex + HouseLayoutAccessor.tileSideLength, HouseLayoutAccessor.tileSideLength * colIndex);

            // Draw the tile
            gridEditor.DrawLine(penColor, p1, p2);
            gridEditor.DrawLine(penColor, p2, p3);
            gridEditor.DrawLine(penColor, p3, p4);
            gridEditor.DrawLine(penColor, p4, p1);
        }
    }
}