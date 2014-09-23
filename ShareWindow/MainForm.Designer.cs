namespace ShareWindow
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.pickWindowToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.startStopToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.propertiesToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip
            // 
            this.toolStrip.ImageScalingSize = new System.Drawing.Size(48, 48);
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pickWindowToolStripButton,
            this.startStopToolStripButton,
            this.toolStripSeparator1,
            this.propertiesToolStripButton});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(202, 55);
            this.toolStrip.TabIndex = 0;
            this.toolStrip.MouseEnter += new System.EventHandler(this.MainForm_MouseEnter);
            this.toolStrip.MouseLeave += new System.EventHandler(this.MainForm_MouseLeave);
            this.toolStrip.MouseHover += new System.EventHandler(this.MainForm_MouseHover);
            // 
            // pickWindowToolStripButton
            // 
            this.pickWindowToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.pickWindowToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("pickWindowToolStripButton.Image")));
            this.pickWindowToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.pickWindowToolStripButton.Name = "pickWindowToolStripButton";
            this.pickWindowToolStripButton.Size = new System.Drawing.Size(52, 52);
            this.pickWindowToolStripButton.Text = "Pick";
            this.pickWindowToolStripButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.pickWindowToolStripButton.ToolTipText = "Pick a window to share";
            this.pickWindowToolStripButton.Click += new System.EventHandler(this.pickWindowToolStripButton_Click);
            // 
            // startStopToolStripButton
            // 
            this.startStopToolStripButton.CheckOnClick = true;
            this.startStopToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.startStopToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("startStopToolStripButton.Image")));
            this.startStopToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.startStopToolStripButton.Name = "startStopToolStripButton";
            this.startStopToolStripButton.Size = new System.Drawing.Size(52, 52);
            this.startStopToolStripButton.Text = "Start/Stop";
            this.startStopToolStripButton.ToolTipText = "Start or stop transmition";
            this.startStopToolStripButton.Click += new System.EventHandler(this.startStopToolStripButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 55);
            // 
            // propertiesToolStripButton
            // 
            this.propertiesToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.propertiesToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("propertiesToolStripButton.Image")));
            this.propertiesToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.propertiesToolStripButton.Name = "propertiesToolStripButton";
            this.propertiesToolStripButton.Size = new System.Drawing.Size(52, 52);
            this.propertiesToolStripButton.Text = "Settings";
            this.propertiesToolStripButton.ToolTipText = "Application Settings";
            this.propertiesToolStripButton.Click += new System.EventHandler(this.propertiesToolStripButton_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 59);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(202, 22);
            this.statusStrip.SizingGrip = false;
            this.statusStrip.TabIndex = 1;
            this.statusStrip.MouseEnter += new System.EventHandler(this.MainForm_MouseEnter);
            this.statusStrip.MouseLeave += new System.EventHandler(this.MainForm_MouseLeave);
            this.statusStrip.MouseHover += new System.EventHandler(this.MainForm_MouseHover);
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel.Text = "Window not selected";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(202, 81);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.toolStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Share Window";
            this.TopMost = true;
            this.MouseEnter += new System.EventHandler(this.MainForm_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.MainForm_MouseLeave);
            this.MouseHover += new System.EventHandler(this.MainForm_MouseHover);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton pickWindowToolStripButton;
        private System.Windows.Forms.ToolStripButton startStopToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton propertiesToolStripButton;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
    }
}

