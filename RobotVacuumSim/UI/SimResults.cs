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

            PropertyInfo[] properties = inreport.GetType().GetProperties();
            foreach (PropertyInfo pi in properties)
            {
                // Don't show the floorplan data field cause it's huge and not user-facing
                if (pi.Name != "FloorplanData")
                {
                    MainDataGridView.Rows.Add(pi.Name, pi.GetValue(inreport, null).ToString());
                }
            }

            MainDataGridView.Rows.Add("Report Path", loadedFileName);

            SimulationReportTabs.TabPages[0].Text = fileName;
        }

        private SimulationReport GetSimReportFromActiveTab()
        {
            var activeTabControls = SimulationReportTabs.SelectedTab.Controls;
            DataGridView activeTabGridView = (DataGridView)activeTabControls[0];
            string thisReportPath = "";
            var pathRow = activeTabGridView.Rows[activeTabGridView.Rows.GetLastRow(DataGridViewElementStates.Visible)];
            if (pathRow.Cells[0].Value.ToString() == "Report Path")
            {
                thisReportPath = pathRow.Cells[1].Value.ToString();
            }

            string simReport = "";
            if (thisReportPath != "")
            {
                simReport = File.ReadAllText(thisReportPath);
            }
            else { return null; }
            SimulationReport inreport = JsonSerializer.Deserialize<SimulationReport>(simReport)!;

            return inreport;
        }

        private void LoadFloorplanButton_Click(object sender, EventArgs e)
        {
            SimulationReport inreport = GetSimReportFromActiveTab();

            if (inreport == null)
            {
                MessageBox.Show("Error loading simulation report.");
                this.Close();
            }
            FloorplanFileReader.LoadTileGridData(inreport.FloorplanData, _fplayout);
            this.Close();
        }

        private void LoadFloorplanAndSettingsButton_Click(object sender, EventArgs e)
        {
            SimulationReport inreport = GetSimReportFromActiveTab();

            if (inreport == null)
            {
                MessageBox.Show("Error loading simulation report.");
                this.Close();
            }
            FloorplanFileReader.LoadTileGridData(inreport.FloorplanData, _fplayout);
            _parentForm.LoadSimulationSettingsFromReport(inreport);
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

                dgv.Rows.Add("Report Path", inFilePath);

                SimulationReportTabs.TabPages[lastContentTabIdx].Text = fileName;
                dgv.Parent = SimulationReportTabs.TabPages[lastContentTabIdx];
                dgv.Dock = DockStyle.Fill;
            }
        }
    }
}