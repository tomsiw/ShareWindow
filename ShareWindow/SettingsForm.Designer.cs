namespace ShareWindow
{
    partial class SettingsForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.portTextBox = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.updateTextBox = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.acceptButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.httpPermButton = new System.Windows.Forms.Button();
            this.portHelpButton = new System.Windows.Forms.Button();
            this.printWinRadioButton = new System.Windows.Forms.RadioButton();
            this.gdiRadioButton = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Port:";
            // 
            // portTextBox
            // 
            this.portTextBox.Location = new System.Drawing.Point(146, 6);
            this.portTextBox.Mask = "00000";
            this.portTextBox.Name = "portTextBox";
            this.portTextBox.Size = new System.Drawing.Size(100, 20);
            this.portTextBox.TabIndex = 1;
            this.portTextBox.Text = "11001";
            this.portTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.portTextBox.ValidatingType = typeof(int);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Update every:";
            // 
            // updateTextBox
            // 
            this.updateTextBox.Location = new System.Drawing.Point(146, 31);
            this.updateTextBox.Mask = "00000";
            this.updateTextBox.Name = "updateTextBox";
            this.updateTextBox.Size = new System.Drawing.Size(100, 20);
            this.updateTextBox.TabIndex = 1;
            this.updateTextBox.Text = "1000";
            this.updateTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.updateTextBox.ValidatingType = typeof(int);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(252, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "ms";
            // 
            // acceptButton
            // 
            this.acceptButton.Location = new System.Drawing.Point(123, 132);
            this.acceptButton.Name = "acceptButton";
            this.acceptButton.Size = new System.Drawing.Size(75, 23);
            this.acceptButton.TabIndex = 3;
            this.acceptButton.Text = "OK";
            this.acceptButton.UseVisualStyleBackColor = true;
            this.acceptButton.Click += new System.EventHandler(this.acceptButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(204, 132);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 3;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // httpPermButton
            // 
            this.httpPermButton.Location = new System.Drawing.Point(15, 62);
            this.httpPermButton.Name = "httpPermButton";
            this.httpPermButton.Size = new System.Drawing.Size(109, 23);
            this.httpPermButton.TabIndex = 4;
            this.httpPermButton.Text = "HTTP Namespaces";
            this.httpPermButton.UseVisualStyleBackColor = true;
            this.httpPermButton.Click += new System.EventHandler(this.httpPermButton_Click);
            // 
            // portHelpButton
            // 
            this.portHelpButton.Location = new System.Drawing.Point(250, 4);
            this.portHelpButton.Name = "portHelpButton";
            this.portHelpButton.Size = new System.Drawing.Size(22, 23);
            this.portHelpButton.TabIndex = 5;
            this.portHelpButton.Text = "?";
            this.portHelpButton.UseVisualStyleBackColor = true;
            this.portHelpButton.Click += new System.EventHandler(this.portHelpButton_Click);
            // 
            // printWinRadioButton
            // 
            this.printWinRadioButton.AutoSize = true;
            this.printWinRadioButton.Location = new System.Drawing.Point(15, 91);
            this.printWinRadioButton.Name = "printWinRadioButton";
            this.printWinRadioButton.Size = new System.Drawing.Size(107, 17);
            this.printWinRadioButton.TabIndex = 6;
            this.printWinRadioButton.TabStop = true;
            this.printWinRadioButton.Text = "Use PrintWindow";
            this.printWinRadioButton.UseVisualStyleBackColor = true;
            // 
            // gdiRadioButton
            // 
            this.gdiRadioButton.AutoSize = true;
            this.gdiRadioButton.Location = new System.Drawing.Point(128, 91);
            this.gdiRadioButton.Name = "gdiRadioButton";
            this.gdiRadioButton.Size = new System.Drawing.Size(66, 17);
            this.gdiRadioButton.TabIndex = 6;
            this.gdiRadioButton.TabStop = true;
            this.gdiRadioButton.Text = "Use GDI";
            this.gdiRadioButton.UseVisualStyleBackColor = true;
            // 
            // SettingsForm
            // 
            this.AcceptButton = this.acceptButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(291, 167);
            this.Controls.Add(this.gdiRadioButton);
            this.Controls.Add(this.printWinRadioButton);
            this.Controls.Add(this.portHelpButton);
            this.Controls.Add(this.httpPermButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.acceptButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.updateTextBox);
            this.Controls.Add(this.portTextBox);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox portTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox updateTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button acceptButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button httpPermButton;
        private System.Windows.Forms.Button portHelpButton;
        private System.Windows.Forms.RadioButton printWinRadioButton;
        private System.Windows.Forms.RadioButton gdiRadioButton;
    }
}