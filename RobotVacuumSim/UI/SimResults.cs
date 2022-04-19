using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VacuumSim.UI
{
    public partial class SimResults : Form
    {
        private string _inPath;
        private FloorplanLayout _fplayout;
        private SimulationReport _loadedReport;

        public SimResults(string loadedFileName, Form1 ParentForm, ref FloorplanLayout fplayout)
        {
            _inPath = loadedFileName;
            _fplayout = fplayout;
            InitializeComponent();
            string[] _splitFileName = loadedFileName.Split('\\');
            string fileName = _splitFileName[_splitFileName.Length - 1];
            LoadedFileLabel.Text = "Loaded: " + fileName;

            string simReport = File.ReadAllText(loadedFileName);
            SimulationReport inreport = JsonSerializer.Deserialize<SimulationReport>(simReport)!;
            _loadedReport = inreport;

            PropertyInfo[] properties = inreport.GetType().GetProperties();
            foreach (PropertyInfo pi in properties)
            {
                if (pi.Name != "FloorplanData")
                {
                    SimReportFieldsTable.Rows.Add(pi.Name, pi.GetValue(inreport, null).ToString());
                }
            }
        }

        private void LoadFloorplanButton_Click(object sender, EventArgs e)
        {
            FloorplanFileReader.LoadTileGridData(_loadedReport.FloorplanData, _fplayout);
            this.Close();
        }
    }
}