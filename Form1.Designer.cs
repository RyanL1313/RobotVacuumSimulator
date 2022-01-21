
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
            this.SplitContainer = new System.Windows.Forms.SplitContainer();
            this.DrawWallButton = new System.Windows.Forms.Button();
            this.DrawFurnitureButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer)).BeginInit();
            this.SplitContainer.Panel1.SuspendLayout();
            this.SplitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // SplitContainer
            // 
            this.SplitContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SplitContainer.Cursor = System.Windows.Forms.Cursors.VSplit;
            this.SplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainer.IsSplitterFixed = true;
            this.SplitContainer.Location = new System.Drawing.Point(0, 0);
            this.SplitContainer.Name = "SplitContainer";
            // 
            // SplitContainer.Panel1
            // 
            this.SplitContainer.Panel1.Controls.Add(this.DrawFurnitureButton);
            this.SplitContainer.Panel1.Controls.Add(this.DrawWallButton);
            // 
            // SplitContainer.Panel2
            // 
            this.SplitContainer.Panel2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SplitContainer.Panel2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SplitContainer_Panel2_MouseDown);
            this.SplitContainer.Size = new System.Drawing.Size(1250, 577);
            this.SplitContainer.SplitterDistance = 625;
            this.SplitContainer.SplitterWidth = 1;
            this.SplitContainer.TabIndex = 0;
            // 
            // DrawWallButton
            // 
            this.DrawWallButton.Location = new System.Drawing.Point(495, 11);
            this.DrawWallButton.Name = "DrawWallButton";
            this.DrawWallButton.Size = new System.Drawing.Size(115, 29);
            this.DrawWallButton.TabIndex = 0;
            this.DrawWallButton.Text = "Draw Wall";
            this.DrawWallButton.UseVisualStyleBackColor = true;
            this.DrawWallButton.Click += new System.EventHandler(this.DrawWallButton_Click);
            // 
            // DrawFurnitureButton
            // 
            this.DrawFurnitureButton.Location = new System.Drawing.Point(495, 46);
            this.DrawFurnitureButton.Name = "DrawFurnitureButton";
            this.DrawFurnitureButton.Size = new System.Drawing.Size(115, 29);
            this.DrawFurnitureButton.TabIndex = 1;
            this.DrawFurnitureButton.Text = "Draw Furniture";
            this.DrawFurnitureButton.UseVisualStyleBackColor = true;
            this.DrawFurnitureButton.Click += new System.EventHandler(this.DrawFurnitureButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1250, 577);
            this.Controls.Add(this.SplitContainer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Form1";
            this.SplitContainer.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer)).EndInit();
            this.SplitContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer SplitContainer;
        private System.Windows.Forms.Button DrawFurnitureButton;
        private System.Windows.Forms.Button DrawWallButton;
    }
}

