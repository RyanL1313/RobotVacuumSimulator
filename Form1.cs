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
    public partial class Form1 : Form
    {
        private Brush ActiveBrush = Brushes.Red;
        private Panel SimDrawingPanel;
        private Graphics SimDrawingPanelGraphics;
        private int PanelXBounds, PanelYBounds, PanelXMin, PanelYMin;
        private static int SQUARE_SIZE = 25;
        private static int GRID_DIM = 25;

        public Form1()
        {
            InitializeComponent();
            SimDrawingPanel = SplitContainer.Panel2;
            SimDrawingPanelGraphics = SimDrawingPanel.CreateGraphics();
            PanelXBounds = SimDrawingPanel.Width;
            PanelYBounds = SimDrawingPanel.Height;
            PanelXMin = SimDrawingPanel.Width - PanelXBounds;
            PanelYMin = SimDrawingPanel.Height - PanelYBounds;
        }
    }
}