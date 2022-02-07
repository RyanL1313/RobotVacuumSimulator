using System;
using System.IO;
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
            var something = new TileGrid();
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
            Graphics gridDrawer = e.Graphics;

            Pen blackPen = new Pen(Color.Black); // For blank tiles
            Brush blackBrush = new SolidBrush(Color.Black); // Walls
            Brush brownBrush = new SolidBrush(Color.Brown); // Chests
            Brush greenBrush = new SolidBrush(Color.Green); // Chairs
            Brush blueBrush = new SolidBrush(Color.Blue); // Tables

            int numSquaresInRow = 50;
            int numSquaresInCol = 40;
            int lenSquareSide = 15;

            /* Draw 50 x 40 grid. Each square in the grid is 4 ft^2 */

            for (int i = 0; i < numSquaresInRow; i++)
            {
                for (int j = 0; j < numSquaresInCol; j++)
                {
                    if (TileGrid.floorLayout[i, j].obstacle == ObstacleType.NONE) // Blank tile
                    {
                        Point p1 = new Point(lenSquareSide * i, lenSquareSide * j);
                        Point p2 = new Point(lenSquareSide * i, lenSquareSide * j + TileGrid.tileSideLength);
                        Point p3 = new Point(lenSquareSide * i + TileGrid.tileSideLength, lenSquareSide * j + TileGrid.tileSideLength);
                        Point p4 = new Point(lenSquareSide * i + TileGrid.tileSideLength, lenSquareSide * j);

                        gridDrawer.DrawLine(blackPen, p1, p2);
                        gridDrawer.DrawLine(blackPen, p2, p3);
                        gridDrawer.DrawLine(blackPen, p3, p4);
                        gridDrawer.DrawLine(blackPen, p4, p1);
                    }
                    else if (TileGrid.floorLayout[i, j].obstacle == ObstacleType.WALL) // Wall tile
                    {
                        gridDrawer.FillRectangle(blackBrush, lenSquareSide * i, lenSquareSide * j, TileGrid.tileSideLength, TileGrid.tileSideLength);
                    }
                    else if (TileGrid.floorLayout[i, j].obstacle == ObstacleType.CHEST) // Chest tile
                    {
                        gridDrawer.FillRectangle(brownBrush, lenSquareSide * i, lenSquareSide * j, TileGrid.tileSideLength, TileGrid.tileSideLength);
                    }
                    else if (TileGrid.floorLayout[i, j].obstacle == ObstacleType.CHAIR) // Chair tile
                    {
                        gridDrawer.FillRectangle(greenBrush, lenSquareSide * i, lenSquareSide * j, TileGrid.tileSideLength, TileGrid.tileSideLength);
                    }
                    else if (TileGrid.floorLayout[i, j].obstacle == ObstacleType.TABLE) // Table tile
                    {
                        gridDrawer.FillRectangle(blueBrush, lenSquareSide * i, lenSquareSide * j, TileGrid.tileSideLength, TileGrid.tileSideLength);
                    }
                }
            }
        }

        private void FloorCanvas_Click(object sender, EventArgs e)
        {
            Point canvasCoords = FloorCanvas.PointToClient(Cursor.Position);

            string selectedObstruction = ObstacleSelector.SelectedItem.ToString();

            ObstacleType ob = ObstacleType.NONE; // To get passed into "modifyTile()"

            if (selectedObstruction.Equals("Blank"))
                ob = ObstacleType.NONE;
            else if (selectedObstruction.Equals("Wall"))
                ob = ObstacleType.WALL;
            else if (selectedObstruction.Equals("Chest"))
                ob = ObstacleType.CHEST;
            else if (selectedObstruction.Equals("Chair"))
                ob = ObstacleType.CHAIR;
            else if (selectedObstruction.Equals("Table"))
                ob = ObstacleType.TABLE;

            TileGrid.modifyTile(canvasCoords.X, canvasCoords.Y, ob);
            FloorCanvas.Invalidate(); // Re-trigger paint event
        }

        private void SaveFloorplanButton_Click(object sender, EventArgs e)
        {
            // Temporary => just for saving default floorplan for now
            // Should use different class in Control layer to do this (MVC)
            string[] lines = new string[TileGrid.numTilesPerRow];
            
            for (int i = 0; i < TileGrid.numTilesPerCol; i++)
            {
                for (int j = 0; j < TileGrid.numTilesPerRow; j++)
                {
                    if (j == 0)
                        lines[i] = i + " " + j + " " + TileGrid.floorLayout[j, i].obstacle;
                    else
                        lines[i] = lines[i] + " " + i + " " + j + " " + TileGrid.floorLayout[j, i].obstacle;
                }
            }

            File.WriteAllLines("../../../DefaultFloorPlan2.txt", lines); // Temporarily added a 2 so I don't override the file accidentally
        }

        private void LoadFloorplanButton_Click(object sender, EventArgs e)
        {
            // Temporary => just for saving default floorplan for now
            // Should use different class in Control layer to do this (MVC)
            string[] lines = File.ReadAllLines("../../../DefaultFloorPlan.txt");

            int row = 0;
            int col = 0;
            string tmpOb = "";
            ObstacleType ob = ObstacleType.NONE;         

            // Iterate over each row in the .txt file
            for (int i = 0; i < TileGrid.numTilesPerCol; i++)
            {
                string[] rowData = lines[i].Split(" ");
                int strIndex = 0;

                for (int j = 0; j < TileGrid.numTilesPerRow; j++)
                {
                    row = Int32.Parse(rowData[strIndex++]);
                    col = Int32.Parse(rowData[strIndex++]);

                    tmpOb = rowData[strIndex++];

                    // Need to create a function to do this -- yikes
                    if (tmpOb.Equals("NONE"))
                        ob = ObstacleType.NONE;
                    else if (tmpOb.Equals("WALL"))
                        ob = ObstacleType.WALL;
                    else if (tmpOb.Equals("CHEST"))
                        ob = ObstacleType.CHEST;
                    else if (tmpOb.Equals("CHAIR"))
                        ob = ObstacleType.CHAIR;
                    else if (tmpOb.Equals("TABLE"))
                        ob = ObstacleType.TABLE;

                    TileGrid.floorLayout[col, row].obstacle = ob;
                }
                
                FloorCanvas.Invalidate(); // Re-trigger paint event
            }
        }
    }
}