namespace VA_Analysemodul
{
    partial class OptionsView
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
            this.lblOptionLabel = new System.Windows.Forms.Label();
            this.chxOptionList = new System.Windows.Forms.ComboBox();
            this.btnSaveSettings = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblOptionLabel
            // 
            this.lblOptionLabel.AutoSize = true;
            this.lblOptionLabel.Location = new System.Drawing.Point(13, 13);
            this.lblOptionLabel.Name = "lblOptionLabel";
            this.lblOptionLabel.Size = new System.Drawing.Size(219, 13);
            this.lblOptionLabel.TabIndex = 0;
            this.lblOptionLabel.Text = Properties.Resources.SelectionMode;
            // 
            // chxOptionList
            // 
            this.chxOptionList.FormattingEnabled = true;
            this.chxOptionList.Location = new System.Drawing.Point(13, 30);
            this.chxOptionList.Name = "chxOptionList";
            this.chxOptionList.Size = new System.Drawing.Size(358, 21);
            this.chxOptionList.TabIndex = 1;
            // 
            // btnSaveSettings
            // 
            this.btnSaveSettings.Location = new System.Drawing.Point(378, 27);
            this.btnSaveSettings.Name = "btnSaveSettings";
            this.btnSaveSettings.Size = new System.Drawing.Size(75, 23);
            this.btnSaveSettings.TabIndex = 2;
            this.btnSaveSettings.Text = Properties.Resources.SaveSelectionMode;
            this.btnSaveSettings.UseVisualStyleBackColor = true;
            this.btnSaveSettings.Click += new System.EventHandler(this.btnSaveSettings_Click);
            // 
            // VaAnalyseModul_Options
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 86);
            this.Controls.Add(this.btnSaveSettings);
            this.Controls.Add(this.chxOptionList);
            this.Controls.Add(this.lblOptionLabel);
            this.Name = "VaAnalyseModul_Options";
            this.Text = Properties.Resources.TitleOption;
            this.Load += new System.EventHandler(this.VaAnalyseModul_Options_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblOptionLabel;
        private System.Windows.Forms.ComboBox chxOptionList;
        private System.Windows.Forms.Button btnSaveSettings;
    }
}