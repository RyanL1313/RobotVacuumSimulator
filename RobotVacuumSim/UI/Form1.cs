using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using VacuumSim.Sim;
using VacuumSim.UI.FloorplanGraphics;
using VacuumSim.Components;
using VacuumSim.UI.Floorplan;

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
        private FloorplanLayout HouseLayout;
        private VacuumDisplay VacDisplay;
        private Vacuum ActualVacuumData;
        private FloorCleaner floorCleaner = new FloorCleaner();
        private CollisionHandler collisionHandler = new CollisionHandler();

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

        private void InitFloorTileSelector()
        {
            // Set the data source of the dropdown box to be the values of our ObstacleType enum
            //ObstacleSelector.DataSource = Enum.GetValues(typeof(ObstacleType));
            // Set the default value to the ObstacleType.WALL;
            ObstacleSelector.SelectedIndex = 0;
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
            InitFloorTileSelector();

            // Create objects needed for drawing to FloorCanvas
            HouseLayout = new FloorplanLayout();
            FloorCanvasDesigner.FloorplanHouseDesigner = new FloorplanLayout();
            VacDisplay = new VacuumDisplay();
            ActualVacuumData = new Vacuum();

            // Enable double buffering for FloorCanvas
            this.DoubleBuffered = true;
            FloorCanvas.EnableDoubleBuffering();
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

        private void ObstacleSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            FloorCanvasDesigner.eraserModeOn = false;
            EraserModeButton.Text = FloorCanvasDesigner.eraserModeOn ? "Eraser Mode: ON" : "Eraser Mode: OFF";

            if (ObstacleSelector.SelectedItem.ToString() == "Room")
            {
                RoomDimensionsGroupBox.Enabled = true;
                ChairTableDimensionsGroupBox.Enabled = false;
            }
            else if (ObstacleSelector.SelectedItem.ToString() == "Chair" || ObstacleSelector.SelectedItem.ToString() == "Table")
            {
                ChairTableDimensionsGroupBox.Enabled = true;
                RoomDimensionsGroupBox.Enabled = false;
                FloorCanvasDesigner.chairTableDrawingModeOn = true;
            }
            else // Chest is selected
            {
                ChairTableDimensionsGroupBox.Enabled = false;
                RoomDimensionsGroupBox.Enabled = false;
                FloorCanvasDesigner.chairTableDrawingModeOn = false;
            }
        }

        private void HouseWidthSelector_ValueChanged(object sender, EventArgs e)
        {
            if ((int)HouseWidthSelector.Value % 2 == 1) // Prevent non-even entries
                HouseWidthSelector.Value += 1; // Round up

            int prevNumTilesPerRow = HouseLayout.numTilesPerRow; // Number of tiles in a row before the width was changed
            HouseLayout.numTilesPerRow = ((int)HouseWidthSelector.Value + 4) / 2; // Get number of tiles per row based on house width chosen by user
            FloorCanvasDesigner.UpdateFloorplanAfterHouseWidthChanged(HouseLayout, prevNumTilesPerRow);

            // Update selected obstacle widths if necessary
            RoomWidthSelector.Value = Math.Min(RoomWidthSelector.Value, HouseWidthSelector.Value);
            ChairTableWidthSelector.Value = Math.Min(ChairTableWidthSelector.Value, HouseWidthSelector.Value);

            FloorCanvas.Invalidate(); // Re-draw canvas to reflect change in house width
        }

        private void HouseHeightSelector_ValueChanged(object sender, EventArgs e)
        {
            if ((int)HouseHeightSelector.Value % 2 == 1) // Prevent non-even entries
                HouseHeightSelector.Value += 1;

            int prevNumTilesPerCol = HouseLayout.numTilesPerCol; // Number of tiles in a column before the height was changed
            HouseLayout.numTilesPerCol = ((int)HouseHeightSelector.Value + 4) / 2; // Get number of tiles per column based on house height chosen by user
            FloorCanvasDesigner.UpdateFloorplanAfterHouseHeightChanged(HouseLayout, prevNumTilesPerCol);

            // Update selected obstacle heights if necessary
            RoomHeightSelector.Value = Math.Min(RoomHeightSelector.Value, HouseHeightSelector.Value);
            ChairTableHeightSelector.Value = Math.Min(ChairTableHeightSelector.Value, HouseHeightSelector.Value);

            FloorCanvas.Invalidate(); // Re-draw canvas to reflect change in house height
        }

        private void RoomWidthSelector_ValueChanged(object sender, EventArgs e)
        {
            if ((int)RoomWidthSelector.Value % 2 == 1) // Prevent non-even entries
                RoomWidthSelector.Value += 1;

            RoomWidthSelector.Value = Math.Min(RoomWidthSelector.Value, HouseWidthSelector.Value);
        }

        private void RoomHeightSelector_ValueChanged(object sender, EventArgs e)
        {
            if ((int)RoomHeightSelector.Value % 2 == 1) // Prevent non-even entries
                RoomHeightSelector.Value += 1;

            RoomHeightSelector.Value = Math.Min(RoomHeightSelector.Value, HouseHeightSelector.Value);
        }

        private void ChairTableWidthSelector_ValueChanged(object sender, EventArgs e)
        {
            if ((int)ChairTableWidthSelector.Value % 2 == 1) // Prevent non-even entries
                ChairTableWidthSelector.Value += 1;

            ChairTableWidthSelector.Value = Math.Min(ChairTableWidthSelector.Value, HouseWidthSelector.Value);
        }

        private void ChairTableHeightSelector_ValueChanged(object sender, EventArgs e)
        {
            if ((int)ChairTableHeightSelector.Value % 2 == 1) // Prevent non-even entries
                ChairTableHeightSelector.Value += 1;

            ChairTableHeightSelector.Value = Math.Min(ChairTableHeightSelector.Value, HouseHeightSelector.Value);
        }

        private void SimulationSpeedSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            Simulation.simSpeed = Int32.Parse(SimulationSpeedSelector.SelectedItem.ToString().TrimEnd('x'));

            // Set the vacuum timer to update every 1000 / (simulation speed) / (frames per simulation second)
            VacuumBodyTimer.Interval = 1000 / Simulation.simSpeed / FloorCanvasCalculator.framesPerSimSecond;
        }

        private void RobotSpeedSelector_ValueChanged(object sender, EventArgs e)
        {
            VacDisplay.vacuumSpeed = (int)RobotSpeedSelector.Value;
        }

        private void RobotBatteryLifeSelector_ValueChanged(object sender, EventArgs e)
        {
            BatteryLeftLabel.Text = "" + RobotBatteryLifeSelector.Value + " minutes";
            VacDisplay.batterySecondsRemaining = (int)RobotBatteryLifeSelector.Value * 60;
        }

        private void InitialVacuumHeadingSelector_ValueChanged(object sender, EventArgs e)
        {
            VacDisplay.vacuumHeading = (int)InitialVacuumHeadingSelector.Value;

            FloorCanvas.Invalidate(); // Re-draw canvas to show new whiskers display
        }

        private void FloorTypeControlChanged(object sender, EventArgs e)
        {
            // Update the default vacuum efficiency based on the selected floor covering
            if (HardWoodRadioButton.Checked)
            {
                VacuumEfficiencySlider.Value = 90;
                WhiskersEfficiencySlider.Value = 50;
                ActualVacuumData.VacuumEfficiency = 90.0f / 100.0f;
            }
            else if (LoopPileRadioButton.Checked)
            {
                VacuumEfficiencySlider.Value = 75;
                WhiskersEfficiencySlider.Value = 30;
                ActualVacuumData.VacuumEfficiency = 75.0f / 100.0f;
            }
            else if (CutPileRadioButton.Checked)
            {
                VacuumEfficiencySlider.Value = 70;
                WhiskersEfficiencySlider.Value = 20;
                ActualVacuumData.VacuumEfficiency = 70.0f / 100.0f;
            }
            else if (FriezeCutPileRadioButton.Checked)
            {
                VacuumEfficiencySlider.Value = 65;
                WhiskersEfficiencySlider.Value = 10;
                ActualVacuumData.VacuumEfficiency = 65.0f / 100.0f;
            }

            VacuumEfficiencyValueLabel.Text = VacuumEfficiencySlider.Value + "%";
            WhiskersEfficiencyValueLabel.Text = WhiskersEfficiencySlider.Value + "%";

            FloorCanvas.Invalidate();
        }

        private void VacuumEfficiencySlider_Scroll(object sender, EventArgs e)
        {
            VacuumEfficiencyValueLabel.Text = VacuumEfficiencySlider.Value + "%";
            ActualVacuumData.VacuumEfficiency = VacuumEfficiencySlider.Value / 100.0f;
        }

        private void WhiskerEfficiencySlider_Scroll(object sender, EventArgs e)
        {
            WhiskersEfficiencyValueLabel.Text = WhiskersEfficiencySlider.Value + "%";
            ActualVacuumData.WhiskerEfficiency = WhiskersEfficiencySlider.Value / 100.0f;
        }

        private void ShowInstructionsButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("To-do.\n\nsomething something vacuum go vroom vroom.");
        }

        private void FinishOrEditFloorplanButton_Click(object sender, EventArgs e)
        {
            FloorCanvasDesigner.editingFloorplan = !FloorCanvasDesigner.editingFloorplan;

            if (!FloorCanvasDesigner.editingFloorplan) // User just finished editing the floorplan
            {
                // Move to vacuum attribute setting stage
                FloorCanvasDesigner.settingVacuumAttributes = true;
                FloorCanvasDesigner.editingFloorplan = false;

                // Floorplan widget attributes
                FloorplanDesignLabel.Enabled = false;
                FloorTypeGroupBox.Enabled = false;
                HouseDimensionsGroupBox.Enabled = false;
                RoomDimensionsGroupBox.Enabled = false;
                ChairTableDimensionsGroupBox.Enabled = false;
                ObstaclesGroupBox.Enabled = false;
                FloorCanvasDesigner.eraserModeOn = false;
                EraserModeButton.Text = "Eraser Mode: OFF";
                FinishOrEditFloorplanButton.Text = "Edit Floor Plan";
                LoadSaveFloorplanGroupBox.Enabled = false;

                // Vacuum widget attributes
                VacuumAttributesLabel.Enabled = true;
                VacuumEfficiencyTitleLabel.Enabled = true;
                VacuumEfficiencyValueLabel.Enabled = true;
                VacuumEfficiencySlider.Enabled = true;
                WhiskersEfficiencyTitleLabel.Enabled = true;
                WhiskersEfficiencyValueLabel.Enabled = true;
                WhiskersEfficiencySlider.Enabled = true;
                RobotBatteryLifeLabel.Enabled = true;
                RobotBatteryLifeSelector.Enabled = true;
                RobotSpeedLabel.Enabled = true;
                RobotSpeedSelector.Enabled = true;
                RobotPathAlgorithmLabel.Enabled = true;
                RobotPathAlgorithmSelector.Enabled = true;
                RunAllAlgorithmsCheckbox.Enabled = true;
                InitialVacuumHeadingLabel.Enabled = true;
                InitialVacuumHeadingSelector.Enabled = true;
                PlaceVacuumInstructionsLabel.Visible = true;
            }
            else // User just returned to editing the floorplan
            {
                // Move back to floorplan editing stage
                FloorCanvasDesigner.settingVacuumAttributes = false;
                FloorCanvasDesigner.editingFloorplan = true;
                FloorCanvasDesigner.successPlacingVacuum = false;
                FloorCanvasDesigner.currentlyPlacingVacuum = false;

                // Floorplan widget attributes
                FloorplanDesignLabel.Enabled = true;
                FloorTypeGroupBox.Enabled = true;
                HouseDimensionsGroupBox.Enabled = true;
                ObstaclesGroupBox.Enabled = true;
                RoomDimensionsGroupBox.Enabled = ObstacleSelector.SelectedIndex == 0;
                ChairTableDimensionsGroupBox.Enabled = ObstacleSelector.SelectedIndex == 1 || ObstacleSelector.SelectedIndex == 2;
                LoadSaveFloorplanGroupBox.Enabled = true;
                FinishOrEditFloorplanButton.Text = "Finish Floor Plan";

                // Vacuum widget attributes
                VacuumAttributesLabel.Enabled = false;
                VacuumEfficiencyTitleLabel.Enabled = false;
                VacuumEfficiencyValueLabel.Enabled = false;
                VacuumEfficiencySlider.Enabled = false;
                WhiskersEfficiencyTitleLabel.Enabled = false;
                WhiskersEfficiencyValueLabel.Enabled = false;
                WhiskersEfficiencySlider.Enabled = false;
                RobotBatteryLifeLabel.Enabled = false;
                RobotBatteryLifeSelector.Enabled = false;
                RobotSpeedLabel.Enabled = false;
                RobotSpeedSelector.Enabled = false;
                RobotPathAlgorithmLabel.Enabled = false;
                RobotPathAlgorithmSelector.Enabled = false;
                RunAllAlgorithmsCheckbox.Enabled = false;
                InitialVacuumHeadingLabel.Enabled = false;
                InitialVacuumHeadingSelector.Enabled = false;
                PlaceVacuumInstructionsLabel.Visible = false;

                // Simulation widget attributes
                SimulationControlLabel.Enabled = false;
                SimulationSpeedLabel.Enabled = false;
                SimulationSpeedSelector.Enabled = false;
                StartSimulationButton.Enabled = false;
                StopSimulationButton.Enabled = false;
            }

            FloorCanvas.Invalidate();
        }

        private void SaveFloorplanButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFloorplanDialog = new SaveFileDialog();
            saveFloorplanDialog.Filter = "Text files (*.txt)|*.txt";
            saveFloorplanDialog.Title = "Save Floorplan";
            saveFloorplanDialog.ShowDialog();

            string outFilePath;

            if (saveFloorplanDialog.FileName != "")
            {
                outFilePath = saveFloorplanDialog.FileName;
            }
            else
            {
                // If the path fails then tell the user to try again.
                MessageBox.Show("Invalid file path passed, please try again.");
                return;
            }

            FloorplanFileWriter.SaveTileGridData(outFilePath, HouseLayout);
        }

        private void LoadDefaultFloorplanButton_Click(object sender, EventArgs e)
        {
            HouseWidthSelector.Value = 50; // 25 tiles wide (excluding boundary walls)
            HouseHeightSelector.Value = 40; // 20 tiles high (excluding boundary walls)

            FloorplanFileReader.LoadTileGridData("../../../UI/Floorplan/DefaultFloorPlan.txt", HouseLayout);

            FloorCanvas.Invalidate(); // Re-trigger paint event
        }

        private void LoadSavedFloorplanButton_Click(object sender, EventArgs e)
        {
            string inFilePath;
            // This handy bit of code gets the current user's desktop directory.
            // We use this as the default directory for the load dialog.
            string usrDesktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            OpenFileDialog openFloorplanDialog = new OpenFileDialog();
            openFloorplanDialog.Title = "Open Floorplan";
            openFloorplanDialog.Filter = "Text files (*.txt)|*.txt";
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

            FloorplanFileReader.LoadTileGridData(inFilePath, HouseLayout);

            // Set the house width and height selector values to the size of the newly-loaded floorplan
            HouseWidthSelector.Value = HouseLayout.numTilesPerRow * 2 - 4;
            HouseHeightSelector.Value = HouseLayout.numTilesPerCol * 2 - 4;

            FloorCanvas.Invalidate();
        }

        private void StartSimulationButton_Click(object sender, EventArgs e)
        {
            SetInitialSimulationValues();
        }

        private void StopSimulationButton_Click(object sender, EventArgs e)
        {
            // Need to save simulation data right here

            ResetValuesAfterSimEnd();

            FloorCanvas.Invalidate();
        }

        private void YesRunAnotherSimulationButton_Click(object sender, EventArgs e)
        {
            ResetValuesAfterExitingHeatMap();

            FloorCanvas.Invalidate();
        }

        private void NoRunAnotherSimulationButton_Click(object sender, EventArgs e)
        {
            this.Close(); // User is finished running the program
        }

        private void EraserModeButton_Click(object sender, EventArgs e)
        {
            // Alternate between drawing and eraser modes
            FloorCanvasDesigner.eraserModeOn = !FloorCanvasDesigner.eraserModeOn;

            // Update eraser mode button text
            EraserModeButton.Text = FloorCanvasDesigner.eraserModeOn ? "Eraser Mode: ON" : "Eraser Mode: OFF";
        }

        private void FloorCanvas_Paint(object sender, PaintEventArgs e)
        {
            Graphics canvasEditor = e.Graphics;

            var SelectedFloorType = FloorTypeGroupBox.Controls.OfType<RadioButton>()
                           .FirstOrDefault(n => n.Checked).Name;

            if (FloorCanvasDesigner.displayingHeatMap)
            {
                FloorCanvasDesigner.DrawHeatMap(canvasEditor, HouseLayout);
            }
            else
            {
                FloorCanvasDesigner.SetAntiAliasing(canvasEditor);
                FloorCanvasDesigner.DisplayFloorCovering(canvasEditor, HouseLayout, SelectedFloorType);
                FloorCanvasDesigner.PaintChairAndTableBackgrounds(canvasEditor, HouseLayout);
                FloorCanvasDesigner.DisplayCleanedTiles(canvasEditor, HouseLayout);
                FloorCanvasDesigner.DrawVacuum(canvasEditor, VacDisplay);
                //FloorCanvasDesigner.PaintVacuumHitboxInnerTiles(canvasEditor, HouseLayout, VacDisplay);
                //if (Simulation.simStarted) FloorCanvasDesigner.PaintInnerTilesGettingCleaned(canvasEditor, HouseLayout, VacDisplay); // testing purposes
                //FloorCanvasDesigner.DrawInnerTileGridLines(canvasEditor, HouseLayout); // testing purposes
                FloorCanvasDesigner.DrawFloorplan(canvasEditor, HouseLayout, VacDisplay);
            }
        }

        /// <summary>
        /// FloorCanvas_Click is the handler for both the MouseClick and the MouseMove events for FloorCanvas.
        /// This allows us to draw a tile from a single click, as well as a click-and-drag.
        /// Maybe a little bit crude, but it does indeed work.
        /// </summary>
        private void FloorCanvas_Click(object sender, MouseEventArgs e)
        {
            // Prevent drawing while simulation is running and if left click wasn't pressed
            if (Simulation.simStarted || e.Button != MouseButtons.Left)
                return;

            // Get coordinates and indices of selected tile
            PointF canvasCoords = FloorCanvas.PointToClient(Cursor.Position);
            int[] selectedTileIndices = FloorplanLayout.GetTileIndices((int)canvasCoords.X, (int)canvasCoords.Y);

            // Make sure we don't re-draw the canvas if the user is still selecting the same tile while in floorplan drawing mode (efficiency concerns)
            // Also, prevent drawing on the canvas based on various other conditions
            if (FloorCanvasDesigner.justPlacedDoorway || FloorCanvasDesigner.displayingHeatMap || !FloorCanvasDesigner.eraserModeOn && !FloorCanvasDesigner.currentlyAddingDoorway && !FloorCanvasDesigner.settingVacuumAttributes &&
                selectedTileIndices[0] == FloorCanvasDesigner.currentIndicesOfSelectedTile[0] && selectedTileIndices[1] == FloorCanvasDesigner.currentIndicesOfSelectedTile[1])
                return;
            else
            {
                // Set the indices of currently selected tile
                FloorCanvasDesigner.currentIndicesOfSelectedTile[0] = selectedTileIndices[0];
                FloorCanvasDesigner.currentIndicesOfSelectedTile[1] = selectedTileIndices[1];
            }

            // Make sure user clicked within the grid
            if (canvasCoords.X >= HouseLayout.numTilesPerRow * FloorplanLayout.tileSideLength ||
                (canvasCoords.X <= 0 ||
                canvasCoords.Y >= HouseLayout.numTilesPerCol * FloorplanLayout.tileSideLength) ||
                canvasCoords.Y <= 0)
                return;

            // Get currently obstacle selected from combo box and obstacle located at selected tile
            ObstacleType selectedObstacle = FloorplanLayout.GetObstacleTypeFromString(ObstacleSelector.SelectedItem.ToString());
            ObstacleType curObstacleAtTile = HouseLayout.floorLayout[selectedTileIndices[0], selectedTileIndices[1]].obstacle;

            if (FloorCanvasDesigner.settingVacuumAttributes) // User is in vacuum placing stage
            {
                FloorCanvasDesigner.currentlyPlacingVacuum = true;

                // Set the current vacuum coordinates to the coordinates clicked by the user
                ActualVacuumData.VacuumCoords[0] = canvasCoords.X;
                ActualVacuumData.VacuumCoords[1] = canvasCoords.Y;

                VacDisplay.CenterVacuumDisplay(ActualVacuumData.VacuumCoords, HouseLayout); // Also, center the vacuum display within the correct inner tile

                FloorCanvasDesigner.AttemptPlaceVacuum(HouseLayout, ActualVacuumData);
            }
            else if (FloorCanvasDesigner.currentlyAddingDoorway) // User currently needs to add a doorway to the room they just placed
            {
                // Process attempt to add doorway to the room
                bool success = FloorCanvasDesigner.AttemptAddDoorwayToRoom(selectedTileIndices[0], selectedTileIndices[1]);

                if (success) // Doorway was just successfully placed
                {
                    HouseLayout.DeepCopyFloorplan(FloorCanvasDesigner.FloorplanHouseDesigner);
                    EnableFloorplanWidgets(true);
                }
            }
            else if (FloorCanvasDesigner.eraserModeOn) // If eraser mode is on, remove item that is at this tile
            {
                // Process attempt to remove room from floorplan
                if (curObstacleAtTile == ObstacleType.Wall)
                {
                    FloorCanvasDesigner.RemoveRoomFromFloorplan(HouseLayout, selectedTileIndices[0], selectedTileIndices[1]);
                }
                else if (curObstacleAtTile == ObstacleType.Chair || curObstacleAtTile == ObstacleType.Table) // Process attempt to add chair/table to floorplan
                {
                    FloorCanvasDesigner.RemoveChairOrTableFromFloorplan(HouseLayout, selectedTileIndices[0], selectedTileIndices[1]);
                }
                else if (curObstacleAtTile == ObstacleType.Chest) // Process attempt to add chest to floorplan
                {
                    FloorCanvasDesigner.RemoveChestFromFloorplan(HouseLayout, selectedTileIndices[0], selectedTileIndices[1]);
                }
            }
            else // Otherwise, in drawing mode. Draw room/obstacle
            {
                FloorCanvasDesigner.currentlyAddingObstacle = true;
                FloorCanvasDesigner.FloorplanHouseDesigner.DeepCopyFloorplan(HouseLayout); // Copy the actual house layout into the designer house layout

                // Process attempt to add room to floorplan
                if (selectedObstacle == ObstacleType.Room)
                {
                    FloorCanvasDesigner.AttemptAddRoomToFloorplan(selectedTileIndices[0], selectedTileIndices[1], (int)RoomWidthSelector.Value, (int)RoomHeightSelector.Value);
                }
                else if (selectedObstacle == ObstacleType.Chair || selectedObstacle == ObstacleType.Table) // Process attempt to add chair/table to floorplan
                {
                    FloorCanvasDesigner.AttemptAddChairOrTableToFloorplan(selectedObstacle, selectedTileIndices[0], selectedTileIndices[1], (int)ChairTableWidthSelector.Value, (int)ChairTableHeightSelector.Value);
                }
                else if (selectedObstacle == ObstacleType.Chest) // Process attempt to add chest to floorplan
                {
                    FloorCanvasDesigner.AttemptAddChestToFloorplan(selectedTileIndices[0], selectedTileIndices[1]);
                }
            }

            FloorCanvas.Invalidate(); // Re-trigger paint event
        }

        private void FloorCanvas_MouseUp(object sender, MouseEventArgs e)
        {
            // Prevent event when simulation is running or if left mouse button was not pressed
            if (Simulation.simStarted || e.Button != MouseButtons.Left)
                return;

            if (FloorCanvasDesigner.currentlyPlacingVacuum) // Process mouse up event when placing vacuum
            {
                if (FloorCanvasDesigner.vacuumPlacingLocationIsValid) // Vacuum was dropped in valid location
                {
                    FloorCanvasDesigner.successPlacingVacuum = true;
                    EnableSimulationWidgets(true);
                }
                else // Vacuum was dropped in invalid location
                {
                    FloorCanvasDesigner.successPlacingVacuum = false;
                    EnableSimulationWidgets(false);
                }
            }
            else if (FloorCanvasDesigner.successAddingObstacle && !FloorCanvasDesigner.eraserModeOn && !FloorCanvasDesigner.settingVacuumAttributes)
            {
                FloorCanvasDesigner.ChangeSuccessTilesToCurrentObstacle(); // Change success tiles in FloorplanHouseDesigner to be the same obstacle type that was just added
                HouseLayout.DeepCopyFloorplan(FloorCanvasDesigner.FloorplanHouseDesigner); // Copy the designer mode house layout to now be the actual house layout

                if (FloorCanvasDesigner.currentObstacleBeingAdded == ObstacleType.Room || FloorCanvasDesigner.currentObstacleBeingAdded == ObstacleType.Wall) // Just placed room, now need to add doorway
                {
                    FloorCanvasDesigner.FloorplanHouseDesigner.DeepCopyFloorplan(HouseLayout); // Back to using the designer mode house layout
                    FloorCanvasDesigner.currentlyAddingDoorway = FloorCanvasDesigner.ShowPossibleDoorwayTiles();

                    if (FloorCanvasDesigner.currentlyAddingDoorway) // Disable all floorplan widgets until user adds the doorway
                    {
                        EnableFloorplanWidgets(false);
                    }
                }
                else
                {
                    FloorCanvasDesigner.ChangeSuccessTilesToCurrentObstacle(); // Change success tiles in FloorplanHouseDesigner to be the same obstacle type that was just added
                    HouseLayout.DeepCopyFloorplan(FloorCanvasDesigner.FloorplanHouseDesigner); // Copy the designer mode house layout to now be the actual house layout
                }
            }

            FloorCanvasDesigner.currentlyPlacingVacuum = false;
            FloorCanvasDesigner.currentlyAddingObstacle = false;
            FloorCanvasDesigner.justPlacedDoorway = false;
            FloorCanvasDesigner.successAddingObstacle = false;

            FloorCanvas.Invalidate();
        }

        private void VacuumBodyTimer_Tick(object sender, EventArgs e)
        {
            // Get the actual coordinates of the new vacuum position
            ActualVacuumData.VacuumCoords[0] += FloorCanvasCalculator.GetDistanceTraveledPerFrame(VacDisplay.vacuumSpeed) * (float)Math.Cos((Math.PI * VacDisplay.vacuumHeading) / 180);
            ActualVacuumData.VacuumCoords[1] += FloorCanvasCalculator.GetDistanceTraveledPerFrame(VacDisplay.vacuumSpeed) * (float)Math.Sin((Math.PI * VacDisplay.vacuumHeading) / 180);

            // Update the vacuum display's coordinates based on the actual coordinates just calculated. The vacuum display's centerpoint will get centered within an inner tile
            VacDisplay.CenterVacuumDisplay(ActualVacuumData.VacuumCoords, HouseLayout);

            // Check for collision. If one occurred, deal with it by updating the vacuum's coordinates based on the previous direction traveled
            if (collisionHandler.VacuumCollidedWithObstacle(VacDisplay, HouseLayout))
            {
                collisionHandler.HandleCollision(VacDisplay, ActualVacuumData, HouseLayout);

                Random rnd = new Random();
                VacDisplay.vacuumHeading = rnd.Next() % 360;
            }

            // Clean affected inner tiles
            floorCleaner.CleanInnerTiles(VacDisplay, ActualVacuumData, HouseLayout);

            FloorCanvasCalculator.UpdateSimulationData(VacDisplay);
            BatteryLeftLabel.Text = FloorCanvasCalculator.GetBatteryRemainingText(VacDisplay);
            SimTimeElapsedLabel.Text = FloorCanvasCalculator.GetTimeElapsedText();

            // Save and reset simulation data if battery just ran out
            if (VacDisplay.batterySecondsRemaining <= 0)
                ResetValuesAfterSimEnd();

            FloorCanvas.Invalidate();
        }

        private void VacuumWhiskersTimer_Tick(object sender, EventArgs e)
        {
            FloorCanvasCalculator.CalculateWhiskerCoordinates(VacDisplay);

            FloorCanvas.Invalidate(); // Re-trigger paint event
        }

        /// <summary>
        /// Enables floorplan widgets if value is true, disables them if value is false
        /// </summary>
        /// <param name="value"> A value of true means enable, false means disable </param>
        private void EnableFloorplanWidgets(bool value)
        {
            CreateDoorwayInstructionsLabel.Visible = !value;
            FloorTypeGroupBox.Enabled = value;
            HouseDimensionsGroupBox.Enabled = value;
            ObstaclesGroupBox.Enabled = value;
            RoomDimensionsGroupBox.Enabled = ObstacleSelector.Text.ToString() == "Room" && !FloorCanvasDesigner.currentlyAddingDoorway;
            ChairTableDimensionsGroupBox.Enabled = ObstacleSelector.Text.ToString() == "Chair" || ObstacleSelector.Text.ToString() == "Table";
            LoadSaveFloorplanGroupBox.Enabled = value;
            FinishOrEditFloorplanButton.Enabled = value;
        }

        /// <summary>
        /// Enables simulation widgets if value is true, disables them if value is false
        /// </summary>
        /// <param name="value"> A value of true means enable, false means disable </param>
        private void EnableSimulationWidgets(bool value)
        {
            SimulationControlLabel.Enabled = value;
            SimulationSpeedLabel.Enabled = value;
            SimulationSpeedSelector.Enabled = value;
            StartSimulationButton.Enabled = value;
        }

        /// <summary>
        /// Setting initial UI, vacuum, and simulation data for when simulation starts running
        /// </summary>
        private void SetInitialSimulationValues()
        {
            VacuumBodyTimer.Enabled = true;
            VacuumWhiskersTimer.Enabled = true;
            HouseLayout.gridLinesOn = false;
            StartSimulationButton.Enabled = false;
            StopSimulationButton.Enabled = true;
            FinishOrEditFloorplanButton.Enabled = false;
            ControlsPane.Panel1.Enabled = false;
            LoadDefaultFloorplanButton.Enabled = false;
            LoadSavedFloorplanButton.Enabled = false;
            SaveFloorplanButton.Enabled = false;
            EraserModeButton.Enabled = false;
            ChairTableWidthSelector.Enabled = false;
            ChairTableHeightSelector.Enabled = false;
            ObstacleSelector.Enabled = false;
            FloorTypeGroupBox.Enabled = false;
            Simulation.simStarted = true;
            Simulation.simTimeElapsed = 0;
            FloorCanvasCalculator.frameCount = 0;
            VacDisplay.batterySecondsRemaining = (int)RobotBatteryLifeSelector.Value * 60;
            VacDisplay.CenterVacuumDisplay(ActualVacuumData.VacuumCoords, HouseLayout);
            VacDisplay.vacuumHeading = (int)InitialVacuumHeadingSelector.Value;

            HouseLayout.PerformAreaCalculations();
            HouseLayout.SetInnerTileObstacles();
        }

        /// <summary>
        /// Resetting UI, vacuum, and simulation data after simulation finishes
        /// </summary>
        private void ResetValuesAfterSimEnd()
        {
            FloorCanvasDesigner.displayingHeatMap = true;
            VacuumBodyTimer.Enabled = false;
            VacuumWhiskersTimer.Enabled = false;
            Simulation.simStarted = false;
            Simulation.simTimeElapsed = 0;
            FloorCanvasCalculator.frameCount = 0;
            VacDisplay.batterySecondsRemaining = (int)RobotBatteryLifeSelector.Value * 60;
            InitialVacuumHeadingSelector.Value = VacDisplay.vacuumHeading;
            YesRunAnotherSimulationButton.Visible = true;
            NoRunAnotherSimulationButton.Visible = true;
            RunAnotherSimulationLabel.Visible = true;

            FloorCanvas.Invalidate(); // Re-trigger paint event
        }

        /// <summary>
        /// Resetting values after the user chooses to return to designing a floor plan after seeing the heat map for their previous run
        /// </summary>
        private void ResetValuesAfterExitingHeatMap()
        {
            FloorCanvasDesigner.displayingHeatMap = false;
            FinishOrEditFloorplanButton.Enabled = true;
            ControlsPane.Panel1.Enabled = true;
            LoadDefaultFloorplanButton.Enabled = true;
            LoadSavedFloorplanButton.Enabled = true;
            SaveFloorplanButton.Enabled = true;
            EraserModeButton.Enabled = true;
            ChairTableWidthSelector.Enabled = true;
            ChairTableHeightSelector.Enabled = true;
            ObstacleSelector.Enabled = true;
            FloorTypeGroupBox.Enabled = true;
            StartSimulationButton.Enabled = true;
            StopSimulationButton.Enabled = false;
            YesRunAnotherSimulationButton.Visible = false;
            NoRunAnotherSimulationButton.Visible = false;
            RunAnotherSimulationLabel.Visible = false;

            HouseLayout.ResetInnerTiles();
            HouseLayout.totalFloorplanArea = 0;
            HouseLayout.totalNonCleanableFloorplanArea = 0;

            FloorCanvas.Invalidate();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }
    }

    /// <summary>
    /// This extension class class just exists to enable double buffering for the FloorCanvas picture box.
    /// </summary>
    public static class Extensions
    {
        public static void EnableDoubleBuffering(this Control control)
        {
            var property = typeof(Control).GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
            property.SetValue(control, true, null);
        }
    }
}