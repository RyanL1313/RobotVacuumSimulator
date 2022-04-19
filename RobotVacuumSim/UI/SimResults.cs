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
        public SimResults(string loadedFileName)
        {
            InitializeComponent();
            string[] _splitFileName = loadedFileName.Split('\\');
            string fileName = _splitFileName[_splitFileName.Length - 1];
            LoadedFileLabel.Text = "Loaded: " + fileName;

            string simReport = File.ReadAllText(loadedFileName);
            SimulationReport inreport = JsonSerializer.Deserialize<SimulationReport>(simReport)!;

            PropertyInfo[] properties = inreport.GetType().GetProperties();
            foreach (PropertyInfo pi in properties)
            {
                if (pi.Name != "FloorplanData")
                {
                    SimReportFieldsTable.Rows.Add(pi.Name, pi.GetValue(inreport, null).ToString());
                }
            }
        }
    }
}