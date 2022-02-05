
namespace demoapp
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
            this.LeftPane = new System.Windows.Forms.SplitContainer();
            this.RoomSizeGroupBox = new System.Windows.Forms.GroupBox();
            this.RoomWidthLabel = new System.Windows.Forms.Label();
            this.RoomHeightLabel = new System.Windows.Forms.Label();
            this.RoomWidthSelector = new System.Windows.Forms.NumericUpDown();
            this.RoomHeightSelector = new System.Windows.Forms.NumericUpDown();
            this.FloorTypeGroupBox = new System.Windows.Forms.GroupBox();
            this.WallRadioButton = new System.Windows.Forms.RadioButton();
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
            this.LoadFloorplanButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.SaveFloorplanButton = new System.Windows.Forms.Button();
            this.LoadSimulationButton = new System.Windows.Forms.Button();
            this.SaveSimulationButton = new System.Windows.Forms.Button();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.LeftPane)).BeginInit();
            this.LeftPane.Panel1.SuspendLayout();
            this.LeftPane.Panel2.SuspendLayout();
            this.LeftPane.SuspendLayout();
            this.RoomSizeGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RoomWidthSelector)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RoomHeightSelector)).BeginInit();
            this.FloorTypeGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ControlsPane)).BeginInit();
            this.ControlsPane.Panel1.SuspendLayout();
            this.ControlsPane.Panel2.SuspendLayout();
            this.ControlsPane.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RobotSpeedSelector)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RobotBatteryLifeSelector)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CenterSplitPane)).BeginInit();
            this.CenterSplitPane.Panel1.SuspendLayout();
            this.CenterSplitPane.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // LeftPane
            // 
            this.LeftPane.Cursor = System.Windows.Forms.Cursors.VSplit;
            this.LeftPane.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LeftPane.IsSplitterFixed = true;
            this.LeftPane.Location = new System.Drawing.Point(0, 0);
            this.LeftPane.Name = "LeftPane";
            // 
            // LeftPane.Panel1
            // 
            this.LeftPane.Panel1.Controls.Add(this.groupBox1);
            this.LeftPane.Panel1.Controls.Add(this.RoomSizeGroupBox);
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
            this.LeftPane.Size = new System.Drawing.Size(623, 751);
            this.LeftPane.SplitterDistance = 312;
            this.LeftPane.TabIndex = 1;
            // 
            // RoomSizeGroupBox
            // 
            this.RoomSizeGroupBox.AutoSize = true;
            this.RoomSizeGroupBox.Controls.Add(this.RoomWidthLabel);
            this.RoomSizeGroupBox.Controls.Add(this.RoomHeightLabel);
            this.RoomSizeGroupBox.Controls.Add(this.RoomWidthSelector);
            this.RoomSizeGroupBox.Controls.Add(this.RoomHeightSelector);
            this.RoomSizeGroupBox.Location = new System.Drawing.Point(0, 338);
            this.RoomSizeGroupBox.Name = "RoomSizeGroupBox";
            this.RoomSizeGroupBox.Size = new System.Drawing.Size(312, 132);
            this.RoomSizeGroupBox.TabIndex = 11;
            this.RoomSizeGroupBox.TabStop = false;
            this.RoomSizeGroupBox.Text = "Room Size";
            // 
            // RoomWidthLabel
            // 
            this.RoomWidthLabel.Location = new System.Drawing.Point(6, 35);
            this.RoomWidthLabel.Name = "RoomWidthLabel";
            this.RoomWidthLabel.Size = new System.Drawing.Size(73, 20);
            this.RoomWidthLabel.TabIndex = 9;
            this.RoomWidthLabel.Text = "Width (ft)";
            // 
            // RoomHeightLabel
            // 
            this.RoomHeightLabel.Location = new System.Drawing.Point(100, 35);
            this.RoomHeightLabel.Name = "RoomHeightLabel";
            this.RoomHeightLabel.Size = new System.Drawing.Size(78, 20);
            this.RoomHeightLabel.TabIndex = 10;
            this.RoomHeightLabel.Text = "Height (ft)";
            // 
            // RoomWidthSelector
            // 
            this.RoomWidthSelector.Location = new System.Drawing.Point(6, 72);
            this.RoomWidthSelector.Margin = new System.Windows.Forms.Padding(10);
            this.RoomWidthSelector.Name = "RoomWidthSelector";
            this.RoomWidthSelector.Size = new System.Drawing.Size(74, 27);
            this.RoomWidthSelector.TabIndex = 7;
            this.RoomWidthSelector.Value = new decimal(new int[] {
            45,
            0,
            0,
            0});
            this.RoomWidthSelector.ValueChanged += new System.EventHandler(this.RoomWidthSelector_ValueChanged);
            // 
            // RoomHeightSelector
            // 
            this.RoomHeightSelector.Location = new System.Drawing.Point(100, 72);
            this.RoomHeightSelector.Name = "RoomHeightSelector";
            this.RoomHeightSelector.Size = new System.Drawing.Size(74, 27);
            this.RoomHeightSelector.TabIndex = 8;
            this.RoomHeightSelector.Value = new decimal(new int[] {
            45,
            0,
            0,
            0});
            // 
            // FloorTypeGroupBox
            // 
            this.FloorTypeGroupBox.AutoSize = true;
            this.FloorTypeGroupBox.Controls.Add(this.radioButton1);
            this.FloorTypeGroupBox.Controls.Add(this.WallRadioButton);
            this.FloorTypeGroupBox.Controls.Add(this.FriezeCutPileRadioButton);
            this.FloorTypeGroupBox.Controls.Add(this.CutPileRadioButton);
            this.FloorTypeGroupBox.Controls.Add(this.LoopPileRadioButton);
            this.FloorTypeGroupBox.Controls.Add(this.HardWoodRadioButton);
            this.FloorTypeGroupBox.Location = new System.Drawing.Point(0, 31);
            this.FloorTypeGroupBox.Name = "FloorTypeGroupBox";
            this.FloorTypeGroupBox.Size = new System.Drawing.Size(312, 301);
            this.FloorTypeGroupBox.TabIndex = 6;
            this.FloorTypeGroupBox.TabStop = false;
            this.FloorTypeGroupBox.Text = "Floor Types";
            // 
            // WallRadioButton
            // 
            this.WallRadioButton.AutoSize = true;
            this.WallRadioButton.Location = new System.Drawing.Point(7, 147);
            this.WallRadioButton.Name = "WallRadioButton";
            this.WallRadioButton.Size = new System.Drawing.Size(59, 24);
            this.WallRadioButton.TabIndex = 4;
            this.WallRadioButton.TabStop = true;
            this.WallRadioButton.Text = "Wall";
            this.WallRadioButton.UseVisualStyleBackColor = true;
            // 
            // FriezeCutPileRadioButton
            // 
            this.FriezeCutPileRadioButton.AutoSize = true;
            this.FriezeCutPileRadioButton.Location = new System.Drawing.Point(7, 117);
            this.FriezeCutPileRadioButton.Name = "FriezeCutPileRadioButton";
            this.FriezeCutPileRadioButton.Size = new System.Drawing.Size(125, 24);
            this.FriezeCutPileRadioButton.TabIndex = 3;
            this.FriezeCutPileRadioButton.TabStop = true;
            this.FriezeCutPileRadioButton.Text = "Frieze-Cut Pile";
            this.FriezeCutPileRadioButton.UseVisualStyleBackColor = true;
            // 
            // CutPileRadioButton
            // 
            this.CutPileRadioButton.AutoSize = true;
            this.CutPileRadioButton.Location = new System.Drawing.Point(6, 87);
            this.CutPileRadioButton.Name = "CutPileRadioButton";
            this.CutPileRadioButton.Size = new System.Drawing.Size(80, 24);
            this.CutPileRadioButton.TabIndex = 2;
            this.CutPileRadioButton.TabStop = true;
            this.CutPileRadioButton.Text = "Cut Pile";
            this.CutPileRadioButton.UseVisualStyleBackColor = true;
            // 
            // LoopPileRadioButton
            // 
            this.LoopPileRadioButton.AutoSize = true;
            this.LoopPileRadioButton.Location = new System.Drawing.Point(7, 57);
            this.LoopPileRadioButton.Name = "LoopPileRadioButton";
            this.LoopPileRadioButton.Size = new System.Drawing.Size(92, 24);
            this.LoopPileRadioButton.TabIndex = 1;
            this.LoopPileRadioButton.TabStop = true;
            this.LoopPileRadioButton.Text = "Loop Pile";
            this.LoopPileRadioButton.UseVisualStyleBackColor = true;
            // 
            // HardWoodRadioButton
            // 
            this.HardWoodRadioButton.AutoSize = true;
            this.HardWoodRadioButton.Location = new System.Drawing.Point(7, 27);
            this.HardWoodRadioButton.Name = "HardWoodRadioButton";
            this.HardWoodRadioButton.Size = new System.Drawing.Size(107, 24);
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
            this.FloorplanSectionLabel.Margin = new System.Windows.Forms.Padding(10);
            this.FloorplanSectionLabel.Name = "FloorplanSectionLabel";
            this.FloorplanSectionLabel.Size = new System.Drawing.Size(312, 31);
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
            this.ControlsPane.Size = new System.Drawing.Size(307, 751);
            this.ControlsPane.SplitterDistance = 467;
            this.ControlsPane.TabIndex = 0;
            // 
            // SimulationSpeedLabel
            // 
            this.SimulationSpeedLabel.AutoSize = true;
            this.SimulationSpeedLabel.Location = new System.Drawing.Point(8, 358);
            this.SimulationSpeedLabel.Name = "SimulationSpeedLabel";
            this.SimulationSpeedLabel.Size = new System.Drawing.Size(126, 20);
            this.SimulationSpeedLabel.TabIndex = 10;
            this.SimulationSpeedLabel.Text = "Simulation Speed";
            // 
            // SimulationSpeedSelector
            // 
            this.SimulationSpeedSelector.FormattingEnabled = true;
            this.SimulationSpeedSelector.Location = new System.Drawing.Point(8, 381);
            this.SimulationSpeedSelector.Name = "SimulationSpeedSelector";
            this.SimulationSpeedSelector.Size = new System.Drawing.Size(151, 28);
            this.SimulationSpeedSelector.TabIndex = 9;
            // 
            // StopSimulationButton
            // 
            this.StopSimulationButton.Location = new System.Drawing.Point(140, 415);
            this.StopSimulationButton.Name = "StopSimulationButton";
            this.StopSimulationButton.Size = new System.Drawing.Size(126, 29);
            this.StopSimulationButton.TabIndex = 8;
            this.StopSimulationButton.Text = "Stop Simulation";
            this.StopSimulationButton.UseVisualStyleBackColor = true;
            // 
            // StartSimulationButton
            // 
            this.StartSimulationButton.Location = new System.Drawing.Point(8, 415);
            this.StartSimulationButton.Name = "StartSimulationButton";
            this.StartSimulationButton.Size = new System.Drawing.Size(126, 29);
            this.StartSimulationButton.TabIndex = 7;
            this.StartSimulationButton.Text = "Start Simulation";
            this.StartSimulationButton.UseVisualStyleBackColor = true;
            // 
            // SimulationControlLabel
            // 
            this.SimulationControlLabel.BackColor = System.Drawing.Color.Transparent;
            this.SimulationControlLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.SimulationControlLabel.Font = new System.Drawing.Font("Segoe UI", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point);
            this.SimulationControlLabel.Location = new System.Drawing.Point(0, 0);
            this.SimulationControlLabel.Margin = new System.Windows.Forms.Padding(5);
            this.SimulationControlLabel.Name = "SimulationControlLabel";
            this.SimulationControlLabel.Size = new System.Drawing.Size(305, 31);
            this.SimulationControlLabel.TabIndex = 6;
            this.SimulationControlLabel.Text = "Simulation Control";
            this.SimulationControlLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // RunAllAlgorithmsCheckbox
            // 
            this.RunAllAlgorithmsCheckbox.AutoSize = true;
            this.RunAllAlgorithmsCheckbox.Checked = true;
            this.RunAllAlgorithmsCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.RunAllAlgorithmsCheckbox.Location = new System.Drawing.Point(8, 228);
            this.RunAllAlgorithmsCheckbox.Name = "RunAllAlgorithmsCheckbox";
            this.RunAllAlgorithmsCheckbox.Size = new System.Drawing.Size(151, 24);
            this.RunAllAlgorithmsCheckbox.TabIndex = 12;
            this.RunAllAlgorithmsCheckbox.Text = "Run all algorithms";
            this.RunAllAlgorithmsCheckbox.UseVisualStyleBackColor = true;
            this.RunAllAlgorithmsCheckbox.CheckedChanged += new System.EventHandler(this.RunAllAlgorithmsCheckbox_CheckedChanged);
            // 
            // RobotPathAlgorithmLabel
            // 
            this.RobotPathAlgorithmLabel.AutoSize = true;
            this.RobotPathAlgorithmLabel.Location = new System.Drawing.Point(10, 170);
            this.RobotPathAlgorithmLabel.Name = "RobotPathAlgorithmLabel";
            this.RobotPathAlgorithmLabel.Size = new System.Drawing.Size(129, 20);
            this.RobotPathAlgorithmLabel.TabIndex = 11;
            this.RobotPathAlgorithmLabel.Text = "Pathing Algorithm";
            // 
            // RobotPathAlgorithmSelector
            // 
            this.RobotPathAlgorithmSelector.Enabled = false;
            this.RobotPathAlgorithmSelector.FormattingEnabled = true;
            this.RobotPathAlgorithmSelector.Location = new System.Drawing.Point(8, 193);
            this.RobotPathAlgorithmSelector.Name = "RobotPathAlgorithmSelector";
            this.RobotPathAlgorithmSelector.Size = new System.Drawing.Size(151, 28);
            this.RobotPathAlgorithmSelector.TabIndex = 10;
            // 
            // RobotSpeedLabel
            // 
            this.RobotSpeedLabel.AutoSize = true;
            this.RobotSpeedLabel.Location = new System.Drawing.Point(8, 103);
            this.RobotSpeedLabel.Name = "RobotSpeedLabel";
            this.RobotSpeedLabel.Size = new System.Drawing.Size(179, 20);
            this.RobotSpeedLabel.TabIndex = 9;
            this.RobotSpeedLabel.Text = "Movement Speed (in/sec)";
            // 
            // RobotSpeedSelector
            // 
            this.RobotSpeedSelector.Location = new System.Drawing.Point(10, 133);
            this.RobotSpeedSelector.Margin = new System.Windows.Forms.Padding(10);
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
            this.RobotSpeedSelector.Size = new System.Drawing.Size(74, 27);
            this.RobotSpeedSelector.TabIndex = 8;
            this.RobotSpeedSelector.Value = new decimal(new int[] {
            12,
            0,
            0,
            0});
            // 
            // RobotBatteryLifeLabel
            // 
            this.RobotBatteryLifeLabel.AutoSize = true;
            this.RobotBatteryLifeLabel.Location = new System.Drawing.Point(8, 36);
            this.RobotBatteryLifeLabel.Name = "RobotBatteryLifeLabel";
            this.RobotBatteryLifeLabel.Size = new System.Drawing.Size(123, 20);
            this.RobotBatteryLifeLabel.TabIndex = 7;
            this.RobotBatteryLifeLabel.Text = "Battery Life (min)";
            // 
            // RobotBatteryLifeSelector
            // 
            this.RobotBatteryLifeSelector.Location = new System.Drawing.Point(10, 66);
            this.RobotBatteryLifeSelector.Margin = new System.Windows.Forms.Padding(10);
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
            this.RobotBatteryLifeSelector.Size = new System.Drawing.Size(74, 27);
            this.RobotBatteryLifeSelector.TabIndex = 6;
            this.RobotBatteryLifeSelector.Value = new decimal(new int[] {
            150,
            0,
            0,
            0});
            // 
            // RobotSectionLabel
            // 
            this.RobotSectionLabel.BackColor = System.Drawing.Color.Transparent;
            this.RobotSectionLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.RobotSectionLabel.Font = new System.Drawing.Font("Segoe UI", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point);
            this.RobotSectionLabel.Location = new System.Drawing.Point(0, 0);
            this.RobotSectionLabel.Margin = new System.Windows.Forms.Padding(5);
            this.RobotSectionLabel.Name = "RobotSectionLabel";
            this.RobotSectionLabel.Size = new System.Drawing.Size(305, 31);
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
            this.CenterSplitPane.Name = "CenterSplitPane";
            // 
            // CenterSplitPane.Panel1
            // 
            this.CenterSplitPane.Panel1.Controls.Add(this.LeftPane);
            this.CenterSplitPane.Size = new System.Drawing.Size(1250, 753);
            this.CenterSplitPane.SplitterDistance = 625;
            this.CenterSplitPane.SplitterWidth = 1;
            this.CenterSplitPane.TabIndex = 0;
            // 
            // LoadFloorplanButton
            // 
            this.LoadFloorplanButton.Location = new System.Drawing.Point(6, 32);
            this.LoadFloorplanButton.Name = "LoadFloorplanButton";
            this.LoadFloorplanButton.Size = new System.Drawing.Size(123, 29);
            this.LoadFloorplanButton.TabIndex = 12;
            this.LoadFloorplanButton.Text = "Load Floorplan";
            this.LoadFloorplanButton.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.Controls.Add(this.SaveSimulationButton);
            this.groupBox1.Controls.Add(this.LoadSimulationButton);
            this.groupBox1.Controls.Add(this.SaveFloorplanButton);
            this.groupBox1.Controls.Add(this.LoadFloorplanButton);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 535);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(312, 216);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Load/Save";
            // 
            // SaveFloorplanButton
            // 
            this.SaveFloorplanButton.Location = new System.Drawing.Point(6, 64);
            this.SaveFloorplanButton.Name = "SaveFloorplanButton";
            this.SaveFloorplanButton.Size = new System.Drawing.Size(123, 29);
            this.SaveFloorplanButton.TabIndex = 13;
            this.SaveFloorplanButton.Text = "Save Floorplan";
            this.SaveFloorplanButton.UseVisualStyleBackColor = true;
            // 
            // LoadSimulationButton
            // 
            this.LoadSimulationButton.Location = new System.Drawing.Point(4, 126);
            this.LoadSimulationButton.Name = "LoadSimulationButton";
            this.LoadSimulationButton.Size = new System.Drawing.Size(184, 29);
            this.LoadSimulationButton.TabIndex = 14;
            this.LoadSimulationButton.Text = "Load Simulation Settings";
            this.LoadSimulationButton.UseVisualStyleBackColor = true;
            // 
            // SaveSimulationButton
            // 
            this.SaveSimulationButton.Location = new System.Drawing.Point(4, 161);
            this.SaveSimulationButton.Name = "SaveSimulationButton";
            this.SaveSimulationButton.Size = new System.Drawing.Size(184, 29);
            this.SaveSimulationButton.TabIndex = 15;
            this.SaveSimulationButton.Text = "Save Simulation Settings";
            this.SaveSimulationButton.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(6, 177);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(59, 24);
            this.radioButton1.TabIndex = 5;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Wall";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1250, 753);
            this.Controls.Add(this.CenterSplitPane);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Team 8 Robot Vaccuum Simulation";
            this.LeftPane.Panel1.ResumeLayout(false);
            this.LeftPane.Panel1.PerformLayout();
            this.LeftPane.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LeftPane)).EndInit();
            this.LeftPane.ResumeLayout(false);
            this.RoomSizeGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.RoomWidthSelector)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RoomHeightSelector)).EndInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.CenterSplitPane)).EndInit();
            this.CenterSplitPane.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
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
        private System.Windows.Forms.GroupBox RoomSizeGroupBox;
        private System.Windows.Forms.Label RoomWidthLabel;
        private System.Windows.Forms.Label RoomHeightLabel;
        private System.Windows.Forms.NumericUpDown RoomWidthSelector;
        private System.Windows.Forms.NumericUpDown RoomHeightSelector;
        private System.Windows.Forms.GroupBox FloorTypeGroupBox;
        private System.Windows.Forms.RadioButton WallRadioButton;
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
        private System.Windows.Forms.Button LoadFloorplanButton;
        private System.Windows.Forms.RadioButton radioButton1;
    }
}

