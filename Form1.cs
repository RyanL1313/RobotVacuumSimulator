using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace demoapp
{
    // The GridObject enum gives us a more convenient way to reference the different types of
    // objects that the user can place on the UI.
    // Ensure that any additions to this enum correspond to a Brush in RoomBrushTypes.
    internal enum GridObject
    {
        Empty,
        Wall,
        Furniture,
    }

    public partial class Form1 : Form
    {
        private Brush ActiveBrush = Brushes.Red;
        private Panel SimDrawingPanel;
        private Graphics SimDrawingPanelGraphics;
        private int PanelXBounds, PanelYBounds, PanelXMin, PanelYMin;
        private static int SQUARE_SIZE = 25;
        private static int GRID_DIM = 25;

        // RoomBrushTypes stores the Brushes for drawing various items in the room designer, such as walls, furniture, etc.
        // The elements in this array should be ordered to match the GridObject enum.
        private Brush[] RoomBrushTypes = new Brush[] { Brushes.White, Brushes.Red, Brushes.Blue };

        // GridSpacesPositions is a 2d array of Points that stores the top left corner coordinate of each space in the room designer array.
        private Point[,] GridSpacesPositions = new Point[GRID_DIM, GRID_DIM];

        // GridSpacesPositions keeps track of what element is at what position. To be used in the simulation to represent the room.
        private GridObject[,] GridSpacesStatus = new GridObject[GRID_DIM, GRID_DIM];

        // Callback for clicking the button "Draw Furniture" button
        private void DrawFurnitureButton_Click(object sender, EventArgs e)
        {
            ActiveBrush = RoomBrushTypes[(int)GridObject.Furniture];
        }

        // Callback for clicking the button "Draw Wall" button
        private void DrawWallButton_Click(object sender, EventArgs e)
        {
            ActiveBrush = RoomBrushTypes[(int)GridObject.Wall];
        }

        // Callback for clicking within the drawing window
        private void SplitContainer_Panel2_MouseDown(object sender, MouseEventArgs e)
        {
            // Calculate the grid index of the clicked cell
            int xidx = (int)Math.Floor(e.X / (double)SQUARE_SIZE);
            int yidx = (int)Math.Floor(e.Y / (double)SQUARE_SIZE);
            Point p = GridSpacesPositions[xidx, yidx];
            // Do the drawing
            SimDrawingPanelGraphics.FillRectangle(ActiveBrush, p.X, p.Y, SQUARE_SIZE, SQUARE_SIZE);

            // Store object type in
            GridSpacesStatus[xidx, yidx] = (GridObject)Array.IndexOf(RoomBrushTypes, ActiveBrush);
        }

        public Form1()
        {
            InitializeComponent();
            SimDrawingPanel = SplitContainer.Panel2;
            SimDrawingPanelGraphics = SimDrawingPanel.CreateGraphics();
            PanelXBounds = SimDrawingPanel.Width;
            PanelYBounds = SimDrawingPanel.Height;
            PanelXMin = SimDrawingPanel.Width - PanelXBounds;
            PanelYMin = SimDrawingPanel.Height - PanelYBounds;

            // init grid spaces
            for (int i = 0; i < SQUARE_SIZE; i++)
            {
                for (int j = 0; j < SQUARE_SIZE; j++)
                {
                    GridSpacesPositions[j, i] = new Point(j * SQUARE_SIZE, i * SQUARE_SIZE);
                    GridSpacesStatus[j, i] = GridObject.Empty;
                }
            }
        }
    }
}