
namespace VacuumSim
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.LeftPane = new System.Windows.Forms.SplitContainer();
            this.EraserModeButton = new System.Windows.Forms.Button();
            this.ChairTableDimensionsGroupBox = new System.Windows.Forms.GroupBox();
            this.ChairTableHeightLabel = new System.Windows.Forms.Label();
            this.ChairTableWidthLabel = new System.Windows.Forms.Label();
            this.ChairTableHeightSelector = new System.Windows.Forms.NumericUpDown();
            this.ChairTableWidthSelector = new System.Windows.Forms.NumericUpDown();
            this.ObstacleSelectorLabel = new System.Windows.Forms.Label();
            this.RoomDimensionsGroupBox = new System.Windows.Forms.GroupBox();
            this.RoomCreatorModeButton = new System.Windows.Forms.Button();
            this.RoomWidthLabel = new System.Windows.Forms.Label();
            this.RoomHeightLabel = new System.Windows.Forms.Label();
            this.RoomWidthSelector = new System.Windows.Forms.NumericUpDown();
            this.RoomHeightSelector = new System.Windows.Forms.NumericUpDown();
            this.ObstacleSelector = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.LoadSavedFloorplanButton = new System.Windows.Forms.Button();
            this.SaveSimulationButton = new System.Windows.Forms.Button();
            this.LoadSimulationButton = new System.Windows.Forms.Button();
            this.SaveFloorplanButton = new System.Windows.Forms.Button();
            this.LoadDefaultFloorplanButton = new System.Windows.Forms.Button();
            this.HouseDimensionsGroupBox = new System.Windows.Forms.GroupBox();
            this.HouseWidthLabel = new System.Windows.Forms.Label();
            this.HouseHeightLabel = new System.Windows.Forms.Label();
            this.HouseWidthSelector = new System.Windows.Forms.NumericUpDown();
            this.HouseHeightSelector = new System.Windows.Forms.NumericUpDown();
            this.FloorTypeGroupBox = new System.Windows.Forms.GroupBox();
            this.FriezeCutPileRadioButton = new System.Windows.Forms.RadioButton();
            this.CutPileRadioButton = new System.Windows.Forms.RadioButton();
            this.LoopPileRadioButton = new System.Windows.Forms.RadioButton();
            this.HardWoodRadioButton = new System.Windows.Forms.RadioButton();
            this.FloorplanSectionLabel = new System.Windows.Forms.Label();
            this.ControlsPane = new System.Windows.Forms.SplitContainer();
            this.SimulationSpeedLabel = new System.Windows.Forms.Label();
            this.SimulationSpeedSelector = new System.Windows.Forms.ComboBox();
            this.StopSimulationButton = new System.Windows.Forms.Button();
            this.StartSimulationButton = new System.Windows.Forms.Button();
            this.SimulationControlLabel = new System.Windows.Forms.Label();
            this.RunAllAlgorithmsCheckbox = new System.Windows.Forms.CheckBox();
            this.RobotPathAlgorithmLabel = new System.Windows.Forms.Label();
            this.RobotPathAlgorithmSelector = new System.Windows.Forms.ComboBox();
            this.RobotSpeedLabel = new System.Windows.Forms.Label();
            this.RobotSpeedSelector = new System.Windows.Forms.NumericUpDown();
            this.RobotBatteryLifeLabel = new System.Windows.Forms.Label();
            this.RobotBatteryLifeSelector = new System.Windows.Forms.NumericUpDown();
            this.RobotSectionLabel = new System.Windows.Forms.Label();
            this.CenterSplitPane = new System.Windows.Forms.SplitContainer();
            this.SimTimeElapsedLabel = new System.Windows.Forms.Label();
            this.SimTimeElapsedTitleLabel = new System.Windows.Forms.Label();
            this.BatteryLeftLabel = new System.Windows.Forms.Label();
            this.BatteryLeftTitleLabel = new System.Windows.Forms.Label();
            this.FloorCanvas = new System.Windows.Forms.PictureBox();
            this.VacuumBodyTimer = new System.Windows.Forms.Timer(this.components);
            this.VacuumWhiskersTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.LeftPane)).BeginInit();
            this.LeftPane.Panel1.SuspendLayout();
            this.LeftPane.Panel2.SuspendLayout();
            this.LeftPane.SuspendLayout();
            this.ChairTableDimensionsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ChairTableHeightSelector)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChairTableWidthSelector)).BeginInit();
            this.RoomDimensionsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RoomWidthSelector)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RoomHeightSelector)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.HouseDimensionsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.HouseWidthSelector)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HouseHeightSelector)).BeginInit();
            this.FloorTypeGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ControlsPane)).BeginInit();
            this.ControlsPane.Panel1.SuspendLayout();
            this.ControlsPane.Panel2.SuspendLayout();
            this.ControlsPane.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RobotSpeedSelector)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RobotBatteryLifeSelector)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CenterSplitPane)).BeginInit();
            this.CenterSplitPane.Panel1.SuspendLayout();
            this.CenterSplitPane.Panel2.SuspendLayout();
            this.CenterSplitPane.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FloorCanvas)).BeginInit();
            this.SuspendLayout();
            // 
            // LeftPane
            // 
            this.LeftPane.Cursor = System.Windows.Forms.Cursors.VSplit;
            this.LeftPane.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LeftPane.IsSplitterFixed = true;
            this.LeftPane.Location = new System.Drawing.Point(0, 0);
            this.LeftPane.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LeftPane.Name = "LeftPane";
            // 
            // LeftPane.Panel1
            // 
            this.LeftPane.Panel1.Controls.Add(this.EraserModeButton);
            this.LeftPane.Panel1.Controls.Add(this.ChairTableDimensionsGroupBox);
            this.LeftPane.Panel1.Controls.Add(this.ObstacleSelectorLabel);
            this.LeftPane.Panel1.Controls.Add(this.RoomDimensionsGroupBox);
            this.LeftPane.Panel1.Controls.Add(this.ObstacleSelector);
            this.LeftPane.Panel1.Controls.Add(this.groupBox1);
            this.LeftPane.Panel1.Controls.Add(this.HouseDimensionsGroupBox);
            this.LeftPane.Panel1.Controls.Add(this.FloorTypeGroupBox);
            this.LeftPane.Panel1.Controls.Add(this.FloorplanSectionLabel);
            this.LeftPane.Panel1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.LeftPane.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // LeftPane.Panel2
            // 
            this.LeftPane.Panel2.Controls.Add(this.ControlsPane);
            this.LeftPane.Panel2.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.LeftPane.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.LeftPane.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.LeftPane.Size = new System.Drawing.Size(771, 664);
            this.LeftPane.SplitterDistance = 384;
            this.LeftPane.TabIndex = 1;
            // 
            // EraserModeButton
            // 
            this.EraserModeButton.Location = new System.Drawing.Point(3, 449);
            this.EraserModeButton.Name = "EraserModeButton";
            this.EraserModeButton.Size = new System.Drawing.Size(127, 25);
            this.EraserModeButton.TabIndex = 15;
            this.EraserModeButton.Text = "Eraser Mode: OFF";
            this.EraserModeButton.UseVisualStyleBackColor = true;
            this.EraserModeButton.Click += new System.EventHandler(this.EraserModeButton_Click);
            // 
            // ChairTableDimensionsGroupBox
            // 
            this.ChairTableDimensionsGroupBox.Controls.Add(this.ChairTableHeightLabel);
            this.ChairTableDimensionsGroupBox.Controls.Add(this.ChairTableWidthLabel);
            this.ChairTableDimensionsGroupBox.Controls.Add(this.ChairTableHeightSelector);
            this.ChairTableDimensionsGroupBox.Controls.Add(this.ChairTableWidthSelector);
            this.ChairTableDimensionsGroupBox.Location = new System.Drawing.Point(206, 402);
            this.ChairTableDimensionsGroupBox.Name = "ChairTableDimensionsGroupBox";
            this.ChairTableDimensionsGroupBox.Size = new System.Drawing.Size(178, 100);
            this.ChairTableDimensionsGroupBox.TabIndex = 15;
            this.ChairTableDimensionsGroupBox.TabStop = false;
            this.ChairTableDimensionsGroupBox.Text = "Chair/Table Dimensions";
            // 
            // ChairTableHeightLabel
            // 
            this.ChairTableHeightLabel.AutoSize = true;
            this.ChairTableHeightLabel.Location = new System.Drawing.Point(88, 29);
            this.ChairTableHeightLabel.Name = "ChairTableHeightLabel";
            this.ChairTableHeightLabel.Size = new System.Drawing.Size(62, 15);
            this.ChairTableHeightLabel.TabIndex = 3;
            this.ChairTableHeightLabel.Text = "Height (ft)";
            // 
            // ChairTableWidthLabel
            // 
            this.ChairTableWidthLabel.AutoSize = true;
            this.ChairTableWidthLabel.Location = new System.Drawing.Point(6, 29);
            this.ChairTableWidthLabel.Name = "ChairTableWidthLabel";
            this.ChairTableWidthLabel.Size = new System.Drawing.Size(58, 15);
            this.ChairTableWidthLabel.TabIndex = 2;
            this.ChairTableWidthLabel.Text = "Width (ft)";
            // 
            // ChairTableHeightSelector
            // 
            this.ChairTableHeightSelector.Enabled = false;
            this.ChairTableHeightSelector.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.ChairTableHeightSelector.Location = new System.Drawing.Point(88, 47);
            this.ChairTableHeightSelector.Maximum = new decimal(new int[] {
            80,
            0,
            0,
            0});
            this.ChairTableHeightSelector.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.ChairTableHeightSelector.Name = "ChairTableHeightSelector";
            this.ChairTableHeightSelector.Size = new System.Drawing.Size(65, 23);
            this.ChairTableHeightSelector.TabIndex = 1;
            this.ChairTableHeightSelector.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.ChairTableHeightSelector.ValueChanged += new System.EventHandler(this.ChairTableHeightSelector_ValueChanged);
            // 
            // ChairTableWidthSelector
            // 
            this.ChairTableWidthSelector.Enabled = false;
            this.ChairTableWidthSelector.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.ChairTableWidthSelector.Location = new System.Drawing.Point(4, 47);
            this.ChairTableWidthSelector.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.ChairTableWidthSelector.Name = "ChairTableWidthSelector";
            this.ChairTableWidthSelector.Size = new System.Drawing.Size(65, 23);
            this.ChairTableWidthSelector.TabIndex = 0;
            this.ChairTableWidthSelector.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.ChairTableWidthSelector.ValueChanged += new System.EventHandler(this.ChairTableWidthSelector_ValueChanged);
            // 
            // ObstacleSelectorLabel
            // 
            this.ObstacleSelectorLabel.Location = new System.Drawing.Point(7, 398);
            this.ObstacleSelectorLabel.Name = "ObstacleSelectorLabel";
            this.ObstacleSelectorLabel.Size = new System.Drawing.Size(73, 15);
            this.ObstacleSelectorLabel.TabIndex = 14;
            this.ObstacleSelectorLabel.Text = "Obstacle";
            // 
            // RoomDimensionsGroupBox
            // 
            this.RoomDimensionsGroupBox.AutoSize = true;
            this.RoomDimensionsGroupBox.Controls.Add(this.RoomCreatorModeButton);
            this.RoomDimensionsGroupBox.Controls.Add(this.RoomWidthLabel);
            this.RoomDimensionsGroupBox.Controls.Add(this.RoomHeightLabel);
            this.RoomDimensionsGroupBox.Controls.Add(this.RoomWidthSelector);
            this.RoomDimensionsGroupBox.Controls.Add(this.RoomHeightSelector);
            this.RoomDimensionsGroupBox.Location = new System.Drawing.Point(206, 254);
            this.RoomDimensionsGroupBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RoomDimensionsGroupBox.Name = "RoomDimensionsGroupBox";
            this.RoomDimensionsGroupBox.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RoomDimensionsGroupBox.Size = new System.Drawing.Size(178, 138);
            this.RoomDimensionsGroupBox.TabIndex = 12;
            this.RoomDimensionsGroupBox.TabStop = false;
            this.RoomDimensionsGroupBox.Text = "Room Dimensions";
            // 
            // RoomCreatorModeButton
            // 
            this.RoomCreatorModeButton.Location = new System.Drawing.Point(6, 92);
            this.RoomCreatorModeButton.Name = "RoomCreatorModeButton";
            this.RoomCreatorModeButton.Size = new System.Drawing.Size(152, 25);
            this.RoomCreatorModeButton.TabIndex = 14;
            this.RoomCreatorModeButton.Text = "Room Creator Mode: OFF";
            this.RoomCreatorModeButton.UseVisualStyleBackColor = true;
            this.RoomCreatorModeButton.Click += new System.EventHandler(this.RoomCreatorModeButton_Click);
            // 
            // RoomWidthLabel
            // 
            this.RoomWidthLabel.Location = new System.Drawing.Point(5, 26);
            this.RoomWidthLabel.Name = "RoomWidthLabel";
            this.RoomWidthLabel.Size = new System.Drawing.Size(64, 15);
            this.RoomWidthLabel.TabIndex = 9;
            this.RoomWidthLabel.Text = "Width (ft)";
            // 
            // RoomHeightLabel
            // 
            this.RoomHeightLabel.Location = new System.Drawing.Point(88, 26);
            this.RoomHeightLabel.Name = "RoomHeightLabel";
            this.RoomHeightLabel.Size = new System.Drawing.Size(68, 15);
            this.RoomHeightLabel.TabIndex = 10;
            this.RoomHeightLabel.Text = "Height (ft)";
            // 
            // RoomWidthSelector
            // 
            this.RoomWidthSelector.BackColor = System.Drawing.SystemColors.Window;
            this.RoomWidthSelector.Enabled = false;
            this.RoomWidthSelector.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.RoomWidthSelector.Location = new System.Drawing.Point(5, 54);
            this.RoomWidthSelector.Margin = new System.Windows.Forms.Padding(9, 8, 9, 8);
            this.RoomWidthSelector.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.RoomWidthSelector.Name = "RoomWidthSelector";
            this.RoomWidthSelector.Size = new System.Drawing.Size(65, 23);
            this.RoomWidthSelector.TabIndex = 7;
            this.RoomWidthSelector.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.RoomWidthSelector.ValueChanged += new System.EventHandler(this.RoomWidthSelector_ValueChanged);
            // 
            // RoomHeightSelector
            // 
            this.RoomHeightSelector.BackColor = System.Drawing.SystemColors.Window;
            this.RoomHeightSelector.Enabled = false;
            this.RoomHeightSelector.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.RoomHeightSelector.Location = new System.Drawing.Point(88, 54);
            this.RoomHeightSelector.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RoomHeightSelector.Maximum = new decimal(new int[] {
            80,
            0,
            0,
            0});
            this.RoomHeightSelector.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.RoomHeightSelector.Name = "RoomHeightSelector";
            this.RoomHeightSelector.Size = new System.Drawing.Size(65, 23);
            this.RoomHeightSelector.TabIndex = 8;
            this.RoomHeightSelector.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.RoomHeightSelector.ValueChanged += new System.EventHandler(this.RoomHeightSelector_ValueChanged);
            // 
            // ObstacleSelector
            // 
            this.ObstacleSelector.FormattingEnabled = true;
            this.ObstacleSelector.Items.AddRange(new object[] {
            "Chair",
            "Table",
            "Chest",
            "Wall"});
            this.ObstacleSelector.Location = new System.Drawing.Point(4, 415);
            this.ObstacleSelector.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ObstacleSelector.Name = "ObstacleSelector";
            this.ObstacleSelector.Size = new System.Drawing.Size(112, 23);
            this.ObstacleSelector.TabIndex = 11;
            this.ObstacleSelector.SelectedIndexChanged += new System.EventHandler(this.ObstacleSelector_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.Controls.Add(this.LoadSavedFloorplanButton);
            this.groupBox1.Controls.Add(this.SaveSimulationButton);
            this.groupBox1.Controls.Add(this.LoadSimulationButton);
            this.groupBox1.Controls.Add(this.SaveFloorplanButton);
            this.groupBox1.Controls.Add(this.LoadDefaultFloorplanButton);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 501);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(384, 163);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Load/Save";
            // 
            // LoadSavedFloorplanButton
            // 
            this.LoadSavedFloorplanButton.Location = new System.Drawing.Point(6, 46);
            this.LoadSavedFloorplanButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LoadSavedFloorplanButton.Name = "LoadSavedFloorplanButton";
            this.LoadSavedFloorplanButton.Size = new System.Drawing.Size(152, 22);
            this.LoadSavedFloorplanButton.TabIndex = 16;
            this.LoadSavedFloorplanButton.Text = "Load Saved Floorplan";
            this.LoadSavedFloorplanButton.UseVisualStyleBackColor = true;
            this.LoadSavedFloorplanButton.Click += new System.EventHandler(this.LoadSavedFloorplanButton_Click);
            // 
            // SaveSimulationButton
            // 
            this.SaveSimulationButton.Location = new System.Drawing.Point(4, 121);
            this.SaveSimulationButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SaveSimulationButton.Name = "SaveSimulationButton";
            this.SaveSimulationButton.Size = new System.Drawing.Size(161, 22);
            this.SaveSimulationButton.TabIndex = 15;
            this.SaveSimulationButton.Text = "Save Simulation Settings";
            this.SaveSimulationButton.UseVisualStyleBackColor = true;
            // 
            // LoadSimulationButton
            // 
            this.LoadSimulationButton.Location = new System.Drawing.Point(4, 94);
            this.LoadSimulationButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LoadSimulationButton.Name = "LoadSimulationButton";
            this.LoadSimulationButton.Size = new System.Drawing.Size(161, 22);
            this.LoadSimulationButton.TabIndex = 14;
            this.LoadSimulationButton.Text = "Load Simulation Settings";
            this.LoadSimulationButton.UseVisualStyleBackColor = true;
            // 
            // SaveFloorplanButton
            // 
            this.SaveFloorplanButton.Location = new System.Drawing.Point(270, 20);
            this.SaveFloorplanButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SaveFloorplanButton.Name = "SaveFloorplanButton";
            this.SaveFloorplanButton.Size = new System.Drawing.Size(108, 22);
            this.SaveFloorplanButton.TabIndex = 13;
            this.SaveFloorplanButton.Text = "Save Floorplan";
            this.SaveFloorplanButton.UseVisualStyleBackColor = true;
            this.SaveFloorplanButton.Click += new System.EventHandler(this.SaveFloorplanButton_Click);
            // 
            // LoadDefaultFloorplanButton
            // 
            this.LoadDefaultFloorplanButton.Location = new System.Drawing.Point(7, 20);
            this.LoadDefaultFloorplanButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LoadDefaultFloorplanButton.Name = "LoadDefaultFloorplanButton";
            this.LoadDefaultFloorplanButton.Size = new System.Drawing.Size(151, 22);
            this.LoadDefaultFloorplanButton.TabIndex = 12;
            this.LoadDefaultFloorplanButton.Text = "Load Default Floorplan";
            this.LoadDefaultFloorplanButton.UseVisualStyleBackColor = true;
            this.LoadDefaultFloorplanButton.Click += new System.EventHandler(this.LoadDefaultFloorplanButton_Click);
            // 
            // HouseDimensionsGroupBox
            // 
            this.HouseDimensionsGroupBox.AutoSize = true;
            this.HouseDimensionsGroupBox.Controls.Add(this.HouseWidthLabel);
            this.HouseDimensionsGroupBox.Controls.Add(this.HouseHeightLabel);
            this.HouseDimensionsGroupBox.Controls.Add(this.HouseWidthSelector);
            this.HouseDimensionsGroupBox.Controls.Add(this.HouseHeightSelector);
            this.HouseDimensionsGroupBox.Location = new System.Drawing.Point(0, 254);
            this.HouseDimensionsGroupBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.HouseDimensionsGroupBox.Name = "HouseDimensionsGroupBox";
            this.HouseDimensionsGroupBox.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.HouseDimensionsGroupBox.Size = new System.Drawing.Size(181, 134);
            this.HouseDimensionsGroupBox.TabIndex = 11;
            this.HouseDimensionsGroupBox.TabStop = false;
            this.HouseDimensionsGroupBox.Text = "House Dimensions";
            // 
            // HouseWidthLabel
            // 
            this.HouseWidthLabel.Location = new System.Drawing.Point(5, 26);
            this.HouseWidthLabel.Name = "HouseWidthLabel";
            this.HouseWidthLabel.Size = new System.Drawing.Size(64, 15);
            this.HouseWidthLabel.TabIndex = 9;
            this.HouseWidthLabel.Text = "Width (ft)";
            // 
            // HouseHeightLabel
            // 
            this.HouseHeightLabel.Location = new System.Drawing.Point(88, 26);
            this.HouseHeightLabel.Name = "HouseHeightLabel";
            this.HouseHeightLabel.Size = new System.Drawing.Size(68, 15);
            this.HouseHeightLabel.TabIndex = 10;
            this.HouseHeightLabel.Text = "Height (ft)";
            // 
            // HouseWidthSelector
            // 
            this.HouseWidthSelector.BackColor = System.Drawing.SystemColors.Window;
            this.HouseWidthSelector.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.HouseWidthSelector.Location = new System.Drawing.Point(5, 54);
            this.HouseWidthSelector.Margin = new System.Windows.Forms.Padding(9, 8, 9, 8);
            this.HouseWidthSelector.Minimum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.HouseWidthSelector.Name = "HouseWidthSelector";
            this.HouseWidthSelector.Size = new System.Drawing.Size(65, 23);
            this.HouseWidthSelector.TabIndex = 7;
            this.HouseWidthSelector.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.HouseWidthSelector.ValueChanged += new System.EventHandler(this.HouseWidthSelector_ValueChanged);
            // 
            // HouseHeightSelector
            // 
            this.HouseHeightSelector.BackColor = System.Drawing.SystemColors.Window;
            this.HouseHeightSelector.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.HouseHeightSelector.Location = new System.Drawing.Point(88, 54);
            this.HouseHeightSelector.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.HouseHeightSelector.Maximum = new decimal(new int[] {
            80,
            0,
            0,
            0});
            this.HouseHeightSelector.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.HouseHeightSelector.Name = "HouseHeightSelector";
            this.HouseHeightSelector.Size = new System.Drawing.Size(65, 23);
            this.HouseHeightSelector.TabIndex = 8;
            this.HouseHeightSelector.Value = new decimal(new int[] {
            40,
            0,
            0,
            0});
            this.HouseHeightSelector.ValueChanged += new System.EventHandler(this.HouseHeightSelector_ValueChanged);
            // 
            // FloorTypeGroupBox
            // 
            this.FloorTypeGroupBox.AutoSize = true;
            this.FloorTypeGroupBox.Controls.Add(this.FriezeCutPileRadioButton);
            this.FloorTypeGroupBox.Controls.Add(this.CutPileRadioButton);
            this.FloorTypeGroupBox.Controls.Add(this.LoopPileRadioButton);
            this.FloorTypeGroupBox.Controls.Add(this.HardWoodRadioButton);
            this.FloorTypeGroupBox.Location = new System.Drawing.Point(0, 23);
            this.FloorTypeGroupBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.FloorTypeGroupBox.Name = "FloorTypeGroupBox";
            this.FloorTypeGroupBox.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.FloorTypeGroupBox.Size = new System.Drawing.Size(273, 226);
            this.FloorTypeGroupBox.TabIndex = 6;
            this.FloorTypeGroupBox.TabStop = false;
            this.FloorTypeGroupBox.Text = "Floor Types";
            // 
            // FriezeCutPileRadioButton
            // 
            this.FriezeCutPileRadioButton.AutoSize = true;
            this.FriezeCutPileRadioButton.Location = new System.Drawing.Point(6, 88);
            this.FriezeCutPileRadioButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.FriezeCutPileRadioButton.Name = "FriezeCutPileRadioButton";
            this.FriezeCutPileRadioButton.Size = new System.Drawing.Size(101, 19);
            this.FriezeCutPileRadioButton.TabIndex = 3;
            this.FriezeCutPileRadioButton.TabStop = true;
            this.FriezeCutPileRadioButton.Text = "Frieze-Cut Pile";
            this.FriezeCutPileRadioButton.UseVisualStyleBackColor = true;
            // 
            // CutPileRadioButton
            // 
            this.CutPileRadioButton.AutoSize = true;
            this.CutPileRadioButton.Location = new System.Drawing.Point(5, 65);
            this.CutPileRadioButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CutPileRadioButton.Name = "CutPileRadioButton";
            this.CutPileRadioButton.Size = new System.Drawing.Size(66, 19);
            this.CutPileRadioButton.TabIndex = 2;
            this.CutPileRadioButton.TabStop = true;
            this.CutPileRadioButton.Text = "Cut Pile";
            this.CutPileRadioButton.UseVisualStyleBackColor = true;
            // 
            // LoopPileRadioButton
            // 
            this.LoopPileRadioButton.AutoSize = true;
            this.LoopPileRadioButton.Location = new System.Drawing.Point(6, 43);
            this.LoopPileRadioButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LoopPileRadioButton.Name = "LoopPileRadioButton";
            this.LoopPileRadioButton.Size = new System.Drawing.Size(74, 19);
            this.LoopPileRadioButton.TabIndex = 1;
            this.LoopPileRadioButton.TabStop = true;
            this.LoopPileRadioButton.Text = "Loop Pile";
            this.LoopPileRadioButton.UseVisualStyleBackColor = true;
            // 
            // HardWoodRadioButton
            // 
            this.HardWoodRadioButton.AutoSize = true;
            this.HardWoodRadioButton.Location = new System.Drawing.Point(6, 20);
            this.HardWoodRadioButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.HardWoodRadioButton.Name = "HardWoodRadioButton";
            this.HardWoodRadioButton.Size = new System.Drawing.Size(86, 19);
            this.HardWoodRadioButton.TabIndex = 0;
            this.HardWoodRadioButton.TabStop = true;
            this.HardWoodRadioButton.Text = "Hard Wood";
            this.HardWoodRadioButton.UseVisualStyleBackColor = true;
            // 
            // FloorplanSectionLabel
            // 
            this.FloorplanSectionLabel.BackColor = System.Drawing.Color.Transparent;
            this.FloorplanSectionLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.FloorplanSectionLabel.Font = new System.Drawing.Font("Segoe UI", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point);
            this.FloorplanSectionLabel.Location = new System.Drawing.Point(0, 0);
            this.FloorplanSectionLabel.Margin = new System.Windows.Forms.Padding(9, 8, 9, 8);
            this.FloorplanSectionLabel.Name = "FloorplanSectionLabel";
            this.FloorplanSectionLabel.Size = new System.Drawing.Size(384, 23);
            this.FloorplanSectionLabel.TabIndex = 5;
            this.FloorplanSectionLabel.Text = "Floorplan Control";
            this.FloorplanSectionLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // ControlsPane
            // 
            this.ControlsPane.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ControlsPane.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.ControlsPane.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ControlsPane.IsSplitterFixed = true;
            this.ControlsPane.Location = new System.Drawing.Point(0, 0);
            this.ControlsPane.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ControlsPane.Name = "ControlsPane";
            this.ControlsPane.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // ControlsPane.Panel1
            // 
            this.ControlsPane.Panel1.Controls.Add(this.SimulationSpeedLabel);
            this.ControlsPane.Panel1.Controls.Add(this.SimulationSpeedSelector);
            this.ControlsPane.Panel1.Controls.Add(this.StopSimulationButton);
            this.ControlsPane.Panel1.Controls.Add(this.StartSimulationButton);
            this.ControlsPane.Panel1.Controls.Add(this.SimulationControlLabel);
            this.ControlsPane.Panel1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.ControlsPane.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // ControlsPane.Panel2
            // 
            this.ControlsPane.Panel2.Controls.Add(this.RunAllAlgorithmsCheckbox);
            this.ControlsPane.Panel2.Controls.Add(this.RobotPathAlgorithmLabel);
            this.ControlsPane.Panel2.Controls.Add(this.RobotPathAlgorithmSelector);
            this.ControlsPane.Panel2.Controls.Add(this.RobotSpeedLabel);
            this.ControlsPane.Panel2.Controls.Add(this.RobotSpeedSelector);
            this.ControlsPane.Panel2.Controls.Add(this.RobotBatteryLifeLabel);
            this.ControlsPane.Panel2.Controls.Add(this.RobotBatteryLifeSelector);
            this.ControlsPane.Panel2.Controls.Add(this.RobotSectionLabel);
            this.ControlsPane.Panel2.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.ControlsPane.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ControlsPane.Size = new System.Drawing.Size(383, 664);
            this.ControlsPane.SplitterDistance = 409;
            this.ControlsPane.SplitterWidth = 3;
            this.ControlsPane.TabIndex = 0;
            // 
            // SimulationSpeedLabel
            // 
            this.SimulationSpeedLabel.AutoSize = true;
            this.SimulationSpeedLabel.Location = new System.Drawing.Point(7, 289);
            this.SimulationSpeedLabel.Name = "SimulationSpeedLabel";
            this.SimulationSpeedLabel.Size = new System.Drawing.Size(99, 15);
            this.SimulationSpeedLabel.TabIndex = 10;
            this.SimulationSpeedLabel.Text = "Simulation Speed";
            // 
            // SimulationSpeedSelector
            // 
            this.SimulationSpeedSelector.FormattingEnabled = true;
            this.SimulationSpeedSelector.Location = new System.Drawing.Point(7, 307);
            this.SimulationSpeedSelector.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SimulationSpeedSelector.Name = "SimulationSpeedSelector";
            this.SimulationSpeedSelector.Size = new System.Drawing.Size(133, 23);
            this.SimulationSpeedSelector.TabIndex = 9;
            this.SimulationSpeedSelector.SelectedIndexChanged += new System.EventHandler(this.SimulationSpeedSelector_SelectedIndexChanged);
            // 
            // StopSimulationButton
            // 
            this.StopSimulationButton.Location = new System.Drawing.Point(120, 348);
            this.StopSimulationButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.StopSimulationButton.Name = "StopSimulationButton";
            this.StopSimulationButton.Size = new System.Drawing.Size(110, 22);
            this.StopSimulationButton.TabIndex = 8;
            this.StopSimulationButton.Text = "Stop Simulation";
            this.StopSimulationButton.UseVisualStyleBackColor = true;
            this.StopSimulationButton.Click += new System.EventHandler(this.StopSimulationButton_Click);
            // 
            // StartSimulationButton
            // 
            this.StartSimulationButton.Location = new System.Drawing.Point(5, 348);
            this.StartSimulationButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.StartSimulationButton.Name = "StartSimulationButton";
            this.StartSimulationButton.Size = new System.Drawing.Size(110, 22);
            this.StartSimulationButton.TabIndex = 7;
            this.StartSimulationButton.Text = "Start Simulation";
            this.StartSimulationButton.UseVisualStyleBackColor = true;
            this.StartSimulationButton.Click += new System.EventHandler(this.StartSimulationButton_Click);
            // 
            // SimulationControlLabel
            // 
            this.SimulationControlLabel.BackColor = System.Drawing.Color.Transparent;
            this.SimulationControlLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.SimulationControlLabel.Font = new System.Drawing.Font("Segoe UI", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point);
            this.SimulationControlLabel.Location = new System.Drawing.Point(0, 0);
            this.SimulationControlLabel.Margin = new System.Windows.Forms.Padding(4);
            this.SimulationControlLabel.Name = "SimulationControlLabel";
            this.SimulationControlLabel.Size = new System.Drawing.Size(381, 23);
            this.SimulationControlLabel.TabIndex = 6;
            this.SimulationControlLabel.Text = "Simulation Control";
            this.SimulationControlLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // RunAllAlgorithmsCheckbox
            // 
            this.RunAllAlgorithmsCheckbox.AutoSize = true;
            this.RunAllAlgorithmsCheckbox.Checked = true;
            this.RunAllAlgorithmsCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.RunAllAlgorithmsCheckbox.Location = new System.Drawing.Point(7, 171);
            this.RunAllAlgorithmsCheckbox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RunAllAlgorithmsCheckbox.Name = "RunAllAlgorithmsCheckbox";
            this.RunAllAlgorithmsCheckbox.Size = new System.Drawing.Size(122, 19);
            this.RunAllAlgorithmsCheckbox.TabIndex = 12;
            this.RunAllAlgorithmsCheckbox.Text = "Run all algorithms";
            this.RunAllAlgorithmsCheckbox.UseVisualStyleBackColor = true;
            this.RunAllAlgorithmsCheckbox.CheckedChanged += new System.EventHandler(this.RunAllAlgorithmsCheckbox_CheckedChanged);
            // 
            // RobotPathAlgorithmLabel
            // 
            this.RobotPathAlgorithmLabel.AutoSize = true;
            this.RobotPathAlgorithmLabel.Location = new System.Drawing.Point(9, 128);
            this.RobotPathAlgorithmLabel.Name = "RobotPathAlgorithmLabel";
            this.RobotPathAlgorithmLabel.Size = new System.Drawing.Size(105, 15);
            this.RobotPathAlgorithmLabel.TabIndex = 11;
            this.RobotPathAlgorithmLabel.Text = "Pathing Algorithm";
            // 
            // RobotPathAlgorithmSelector
            // 
            this.RobotPathAlgorithmSelector.Enabled = false;
            this.RobotPathAlgorithmSelector.FormattingEnabled = true;
            this.RobotPathAlgorithmSelector.Location = new System.Drawing.Point(7, 145);
            this.RobotPathAlgorithmSelector.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RobotPathAlgorithmSelector.Name = "RobotPathAlgorithmSelector";
            this.RobotPathAlgorithmSelector.Size = new System.Drawing.Size(133, 23);
            this.RobotPathAlgorithmSelector.TabIndex = 10;
            // 
            // RobotSpeedLabel
            // 
            this.RobotSpeedLabel.AutoSize = true;
            this.RobotSpeedLabel.Location = new System.Drawing.Point(7, 77);
            this.RobotSpeedLabel.Name = "RobotSpeedLabel";
            this.RobotSpeedLabel.Size = new System.Drawing.Size(143, 15);
            this.RobotSpeedLabel.TabIndex = 9;
            this.RobotSpeedLabel.Text = "Movement Speed (in/sec)";
            // 
            // RobotSpeedSelector
            // 
            this.RobotSpeedSelector.Location = new System.Drawing.Point(9, 100);
            this.RobotSpeedSelector.Margin = new System.Windows.Forms.Padding(9, 8, 9, 8);
            this.RobotSpeedSelector.Maximum = new decimal(new int[] {
            18,
            0,
            0,
            0});
            this.RobotSpeedSelector.Minimum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.RobotSpeedSelector.Name = "RobotSpeedSelector";
            this.RobotSpeedSelector.Size = new System.Drawing.Size(65, 23);
            this.RobotSpeedSelector.TabIndex = 8;
            this.RobotSpeedSelector.Value = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.RobotSpeedSelector.ValueChanged += new System.EventHandler(this.RobotSpeedSelector_ValueChanged);
            // 
            // RobotBatteryLifeLabel
            // 
            this.RobotBatteryLifeLabel.AutoSize = true;
            this.RobotBatteryLifeLabel.Location = new System.Drawing.Point(7, 27);
            this.RobotBatteryLifeLabel.Name = "RobotBatteryLifeLabel";
            this.RobotBatteryLifeLabel.Size = new System.Drawing.Size(98, 15);
            this.RobotBatteryLifeLabel.TabIndex = 7;
            this.RobotBatteryLifeLabel.Text = "Battery Life (min)";
            // 
            // RobotBatteryLifeSelector
            // 
            this.RobotBatteryLifeSelector.Location = new System.Drawing.Point(9, 50);
            this.RobotBatteryLifeSelector.Margin = new System.Windows.Forms.Padding(9, 8, 9, 8);
            this.RobotBatteryLifeSelector.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.RobotBatteryLifeSelector.Minimum = new decimal(new int[] {
            90,
            0,
            0,
            0});
            this.RobotBatteryLifeSelector.Name = "RobotBatteryLifeSelector";
            this.RobotBatteryLifeSelector.Size = new System.Drawing.Size(65, 23);
            this.RobotBatteryLifeSelector.TabIndex = 6;
            this.RobotBatteryLifeSelector.Value = new decimal(new int[] {
            150,
            0,
            0,
            0});
            this.RobotBatteryLifeSelector.ValueChanged += new System.EventHandler(this.RobotBatteryLifeSelector_ValueChanged);
            // 
            // RobotSectionLabel
            // 
            this.RobotSectionLabel.BackColor = System.Drawing.Color.Transparent;
            this.RobotSectionLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.RobotSectionLabel.Font = new System.Drawing.Font("Segoe UI", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point);
            this.RobotSectionLabel.Location = new System.Drawing.Point(0, 0);
            this.RobotSectionLabel.Margin = new System.Windows.Forms.Padding(4);
            this.RobotSectionLabel.Name = "RobotSectionLabel";
            this.RobotSectionLabel.Size = new System.Drawing.Size(381, 23);
            this.RobotSectionLabel.TabIndex = 5;
            this.RobotSectionLabel.Text = "Robot Control";
            this.RobotSectionLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // CenterSplitPane
            // 
            this.CenterSplitPane.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CenterSplitPane.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.CenterSplitPane.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CenterSplitPane.IsSplitterFixed = true;
            this.CenterSplitPane.Location = new System.Drawing.Point(0, 0);
            this.CenterSplitPane.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CenterSplitPane.Name = "CenterSplitPane";
            // 
            // CenterSplitPane.Panel1
            // 
            this.CenterSplitPane.Panel1.Controls.Add(this.LeftPane);
            // 
            // CenterSplitPane.Panel2
            // 
            this.CenterSplitPane.Panel2.Controls.Add(this.SimTimeElapsedLabel);
            this.CenterSplitPane.Panel2.Controls.Add(this.SimTimeElapsedTitleLabel);
            this.CenterSplitPane.Panel2.Controls.Add(this.BatteryLeftLabel);
            this.CenterSplitPane.Panel2.Controls.Add(this.BatteryLeftTitleLabel);
            this.CenterSplitPane.Panel2.Controls.Add(this.FloorCanvas);
            this.CenterSplitPane.Size = new System.Drawing.Size(1546, 666);
            this.CenterSplitPane.SplitterDistance = 773;
            this.CenterSplitPane.SplitterWidth = 1;
            this.CenterSplitPane.TabIndex = 0;
            // 
            // SimTimeElapsedLabel
            // 
            this.SimTimeElapsedLabel.AutoSize = true;
            this.SimTimeElapsedLabel.BackColor = System.Drawing.SystemColors.Window;
            this.SimTimeElapsedLabel.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.SimTimeElapsedLabel.Location = new System.Drawing.Point(663, 648);
            this.SimTimeElapsedLabel.Name = "SimTimeElapsedLabel";
            this.SimTimeElapsedLabel.Size = new System.Drawing.Size(70, 16);
            this.SimTimeElapsedLabel.TabIndex = 4;
            this.SimTimeElapsedLabel.Text = "0 Seconds";
            // 
            // SimTimeElapsedTitleLabel
            // 
            this.SimTimeElapsedTitleLabel.AutoSize = true;
            this.SimTimeElapsedTitleLabel.BackColor = System.Drawing.SystemColors.Window;
            this.SimTimeElapsedTitleLabel.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.SimTimeElapsedTitleLabel.Location = new System.Drawing.Point(505, 648);
            this.SimTimeElapsedTitleLabel.Name = "SimTimeElapsedTitleLabel";
            this.SimTimeElapsedTitleLabel.Size = new System.Drawing.Size(163, 16);
            this.SimTimeElapsedTitleLabel.TabIndex = 3;
            this.SimTimeElapsedTitleLabel.Text = "Simulation Time Elapsed:";
            // 
            // BatteryLeftLabel
            // 
            this.BatteryLeftLabel.AutoSize = true;
            this.BatteryLeftLabel.BackColor = System.Drawing.SystemColors.Window;
            this.BatteryLeftLabel.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BatteryLeftLabel.Location = new System.Drawing.Point(98, 648);
            this.BatteryLeftLabel.Name = "BatteryLeftLabel";
            this.BatteryLeftLabel.Size = new System.Drawing.Size(84, 16);
            this.BatteryLeftLabel.TabIndex = 2;
            this.BatteryLeftLabel.Text = "150 Minutes";
            // 
            // BatteryLeftTitleLabel
            // 
            this.BatteryLeftTitleLabel.AutoSize = true;
            this.BatteryLeftTitleLabel.BackColor = System.Drawing.SystemColors.Window;
            this.BatteryLeftTitleLabel.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BatteryLeftTitleLabel.Location = new System.Drawing.Point(17, 648);
            this.BatteryLeftTitleLabel.Name = "BatteryLeftTitleLabel";
            this.BatteryLeftTitleLabel.Size = new System.Drawing.Size(84, 16);
            this.BatteryLeftTitleLabel.TabIndex = 1;
            this.BatteryLeftTitleLabel.Text = "Battery Left:";
            // 
            // FloorCanvas
            // 
            this.FloorCanvas.BackColor = System.Drawing.SystemColors.Window;
            this.FloorCanvas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FloorCanvas.Location = new System.Drawing.Point(5, 0);
            this.FloorCanvas.Name = "FloorCanvas";
            this.FloorCanvas.Size = new System.Drawing.Size(947, 758);
            this.FloorCanvas.TabIndex = 0;
            this.FloorCanvas.TabStop = false;
            this.FloorCanvas.Paint += new System.Windows.Forms.PaintEventHandler(this.FloorCanvas_Paint);
            this.FloorCanvas.MouseClick += new System.Windows.Forms.MouseEventHandler(this.FloorCanvas_Click);
            this.FloorCanvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FloorCanvas_Click);
            this.FloorCanvas.MouseUp += new System.Windows.Forms.MouseEventHandler(this.FloorCanvas_MouseUp);
            // 
            // VacuumBodyTimer
            // 
            this.VacuumBodyTimer.Interval = 1000;
            this.VacuumBodyTimer.Tick += new System.EventHandler(this.VacuumBodyTimer_Tick);
            // 
            // VacuumWhiskersTimer
            // 
            this.VacuumWhiskersTimer.Interval = 10;
            this.VacuumWhiskersTimer.Tick += new System.EventHandler(this.VacuumWhiskersTimer_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1546, 666);
            this.Controls.Add(this.CenterSplitPane);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Team 8 Robot Vaccuum Simulation";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.LeftPane.Panel1.ResumeLayout(false);
            this.LeftPane.Panel1.PerformLayout();
            this.LeftPane.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LeftPane)).EndInit();
            this.LeftPane.ResumeLayout(false);
            this.ChairTableDimensionsGroupBox.ResumeLayout(false);
            this.ChairTableDimensionsGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ChairTableHeightSelector)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChairTableWidthSelector)).EndInit();
            this.RoomDimensionsGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.RoomWidthSelector)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RoomHeightSelector)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.HouseDimensionsGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.HouseWidthSelector)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HouseHeightSelector)).EndInit();
            this.FloorTypeGroupBox.ResumeLayout(false);
            this.FloorTypeGroupBox.PerformLayout();
            this.ControlsPane.Panel1.ResumeLayout(false);
            this.ControlsPane.Panel1.PerformLayout();
            this.ControlsPane.Panel2.ResumeLayout(false);
            this.ControlsPane.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ControlsPane)).EndInit();
            this.ControlsPane.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.RobotSpeedSelector)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RobotBatteryLifeSelector)).EndInit();
            this.CenterSplitPane.Panel1.ResumeLayout(false);
            this.CenterSplitPane.Panel2.ResumeLayout(false);
            this.CenterSplitPane.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CenterSplitPane)).EndInit();
            this.CenterSplitPane.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.FloorCanvas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.SplitContainer LeftPane;
        private System.Windows.Forms.SplitContainer ControlsPane;
        private System.Windows.Forms.Label RobotSectionLabel;
        private System.Windows.Forms.Label RobotBatteryLifeLabel;
        private System.Windows.Forms.NumericUpDown RobotBatteryLifeSelector;
        private System.Windows.Forms.Label RobotSpeedLabel;
        private System.Windows.Forms.NumericUpDown RobotSpeedSelector;
        private System.Windows.Forms.Label RobotPathAlgorithmLabel;
        private System.Windows.Forms.ComboBox RobotPathAlgorithmSelector;
        private System.Windows.Forms.CheckBox RunAllAlgorithmsCheckbox;
        private System.Windows.Forms.GroupBox HouseDimensionsGroupBox;
        private System.Windows.Forms.Label HouseWidthLabel;
        private System.Windows.Forms.Label HouseHeightLabel;
        private System.Windows.Forms.NumericUpDown HouseWidthSelector;
        private System.Windows.Forms.NumericUpDown HouseHeightSelector;
        private System.Windows.Forms.GroupBox FloorTypeGroupBox;
        private System.Windows.Forms.RadioButton FriezeCutPileRadioButton;
        private System.Windows.Forms.RadioButton CutPileRadioButton;
        private System.Windows.Forms.RadioButton LoopPileRadioButton;
        private System.Windows.Forms.RadioButton HardWoodRadioButton;
        private System.Windows.Forms.Label FloorplanSectionLabel;
        private System.Windows.Forms.Label SimulationSpeedLabel;
        private System.Windows.Forms.ComboBox SimulationSpeedSelector;
        private System.Windows.Forms.Button StopSimulationButton;
        private System.Windows.Forms.Button StartSimulationButton;
        private System.Windows.Forms.Label SimulationControlLabel;
        private System.Windows.Forms.SplitContainer CenterSplitPane;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button SaveSimulationButton;
        private System.Windows.Forms.Button LoadSimulationButton;
        private System.Windows.Forms.Button SaveFloorplanButton;
        private System.Windows.Forms.Button LoadDefaultFloorplanButton;
        private System.Windows.Forms.PictureBox FloorCanvas;
        private System.Windows.Forms.ComboBox ObstacleSelector;
        private System.Windows.Forms.Timer VacuumBodyTimer;
        private System.Windows.Forms.Timer VacuumWhiskersTimer;
        private System.Windows.Forms.Label BatteryLeftLabel;
        private System.Windows.Forms.Label BatteryLeftTitleLabel;
        private System.Windows.Forms.Button LoadSavedFloorplanButton;
        private System.Windows.Forms.Label SimTimeElapsedLabel;
        private System.Windows.Forms.Label SimTimeElapsedTitleLabel;
        private System.Windows.Forms.GroupBox RoomDimensionsGroupBox;
        private System.Windows.Forms.Label RoomWidthLabel;
        private System.Windows.Forms.Label RoomHeightLabel;
        private System.Windows.Forms.NumericUpDown RoomWidthSelector;
        private System.Windows.Forms.NumericUpDown RoomHeightSelector;
        private System.Windows.Forms.Button RoomCreatorModeButton;
        private System.Windows.Forms.Label ObstacleSelectorLabel;
        private System.Windows.Forms.GroupBox ChairTableDimensionsGroupBox;
        private System.Windows.Forms.Label ChairTableHeightLabel;
        private System.Windows.Forms.Label ChairTableWidthLabel;
        private System.Windows.Forms.NumericUpDown ChairTableHeightSelector;
        private System.Windows.Forms.NumericUpDown ChairTableWidthSelector;
        private System.Windows.Forms.Button EraserModeButton;
    }
}

