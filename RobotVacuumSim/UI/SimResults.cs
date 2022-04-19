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
        private Form1 _parentForm;
        private string _inPath;
        private FloorplanLayout _fplayout;
        private SimulationReport _loadedReport;

        public SimResults(string loadedFileName, Form1 ParentForm, ref FloorplanLayout fplayout)
        {
            _inPath = loadedFileName;
            _fplayout = fplayout;
            _parentForm = ParentForm;
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
                // Don't show the floorplan data field cause it's huge and not user-facing
                if (pi.Name != "FloorplanData")
                {
                    SimReportFieldsTable.Rows.Add(pi.Name, pi.GetValue(inreport, null).ToString());
                }
            }

            SimulationReportTabs.TabPages[0].Text = fileName;
        }

        private void LoadFloorplanButton_Click(object sender, EventArgs e)
        {
            FloorplanFileReader.LoadTileGridData(_loadedReport.FloorplanData, _fplayout);
            this.Close();
        }

        private void LoadFloorplanAndSettingsButton_Click(object sender, EventArgs e)
        {
            FloorplanFileReader.LoadTileGridData(_loadedReport.FloorplanData, _fplayout);
            _parentForm.LoadSimulationSettingsFromReport(_loadedReport);
            this.Close();
        }

        private void SimulationReportTabs_MouseClick(object sender, MouseEventArgs e)
        {
            var lastTabIdx = this.SimulationReportTabs.TabCount - 1;
            if (this.SimulationReportTabs.GetTabRect(lastTabIdx).Contains(e.Location))
            {
                string inFilePath;
                // get the current user's desktop directory.
                string usrDesktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

                OpenFileDialog openFloorplanDialog = new OpenFileDialog();
                openFloorplanDialog.Title = "Open Saved Simulation";
                openFloorplanDialog.Filter = "Report Files (*.json)|*.json";
                openFloorplanDialog.InitialDirectory = usrDesktopPath;
                openFloorplanDialog.RestoreDirectory = true;

                if (openFloorplanDialog.ShowDialog() == DialogResult.OK)
                {
                    inFilePath = openFloorplanDialog.FileName;
                }
                else
                {
                    // If the user closes the dialog without opening anything, just exit out.
                    return;
                }

                string[] _splitFileName = inFilePath.Split('\\');
                string fileName = _splitFileName[_splitFileName.Length - 1];

                string simReport = File.ReadAllText(inFilePath);
                SimulationReport inreport = JsonSerializer.Deserialize<SimulationReport>(simReport)!;

                this.SimulationReportTabs.TabPages.Insert(lastTabIdx, fileName);
                this.SimulationReportTabs.SelectedIndex = lastTabIdx;
                SimulationReportTabs.TabPages[SimulationReportTabs.SelectedIndex].Padding = new Padding(3);
                SimulationReportTabs.TabPages[SimulationReportTabs.SelectedIndex].UseVisualStyleBackColor = true;

                var lastContentTabIdx = this.SimulationReportTabs.TabCount - 2;

                DataGridView dgv = new DataGridView();
                dgv.Columns.Add("Property", "Property");
                dgv.Columns.Add("Value", "Value");
                dgv.AllowUserToAddRows = false;
                dgv.AllowUserToResizeRows = false;
                dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
                dgv.RowHeadersVisible = false;
                dgv.Size = new System.Drawing.Size(482, 473);

                PropertyInfo[] properties = inreport.GetType().GetProperties();
                foreach (PropertyInfo pi in properties)
                {
                    // Don't show the floorplan data field cause it's huge and not user-facing
                    if (pi.Name != "FloorplanData")
                    {
                        dgv.Rows.Add(pi.Name, pi.GetValue(inreport, null).ToString());
                    }
                }

                SimulationReportTabs.TabPages[lastContentTabIdx].Text = fileName;
                dgv.Parent = SimulationReportTabs.TabPages[lastContentTabIdx];
                dgv.Dock = DockStyle.Fill;
            }
        }
    }
}