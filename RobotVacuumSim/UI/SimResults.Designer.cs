
namespace VacuumSim.UI
{
    partial class SimResults
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SimReportFieldsTable = new System.Windows.Forms.DataGridView();
            this.Property = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LoadedFileLabel = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.SimReportFieldsTable)).BeginInit();
            this.SuspendLayout();
            // 
            // SimReportFieldsTable
            // 
            this.SimReportFieldsTable.AllowUserToAddRows = false;
            this.SimReportFieldsTable.AllowUserToResizeRows = false;
            this.SimReportFieldsTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.SimReportFieldsTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SimReportFieldsTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Property,
            this.Value});
            this.SimReportFieldsTable.Location = new System.Drawing.Point(12, 47);
            this.SimReportFieldsTable.Name = "SimReportFieldsTable";
            this.SimReportFieldsTable.ReadOnly = true;
            this.SimReportFieldsTable.RowHeadersVisible = false;
            this.SimReportFieldsTable.RowTemplate.Height = 25;
            this.SimReportFieldsTable.Size = new System.Drawing.Size(496, 497);
            this.SimReportFieldsTable.TabIndex = 0;
            // 
            // Property
            // 
            this.Property.HeaderText = "Property";
            this.Property.Name = "Property";
            this.Property.ReadOnly = true;
            // 
            // Value
            // 
            this.Value.HeaderText = "Value";
            this.Value.Name = "Value";
            this.Value.ReadOnly = true;
            // 
            // LoadedFileLabel
            // 
            this.LoadedFileLabel.AutoSize = true;
            this.LoadedFileLabel.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LoadedFileLabel.Location = new System.Drawing.Point(12, 9);
            this.LoadedFileLabel.Name = "LoadedFileLabel";
            this.LoadedFileLabel.Size = new System.Drawing.Size(78, 25);
            this.LoadedFileLabel.TabIndex = 1;
            this.LoadedFileLabel.Text = "Loaded:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(345, 550);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(163, 45);
            this.button1.TabIndex = 2;
            this.button1.Text = "Load this floorplan + settings";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 551);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(163, 44);
            this.button2.TabIndex = 3;
            this.button2.Text = "Load this floorplan";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // SimResults
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(520, 607);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.LoadedFileLabel);
            this.Controls.Add(this.SimReportFieldsTable);
            this.Name = "SimResults";
            this.Text = "SimResults";
            ((System.ComponentModel.ISupportInitialize)(this.SimReportFieldsTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView SimReportFieldsTable;
        private System.Windows.Forms.Label LoadedFileLabel;
        private System.Windows.Forms.DataGridViewTextBoxColumn Property;
        private System.Windows.Forms.DataGridViewTextBoxColumn Value;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}