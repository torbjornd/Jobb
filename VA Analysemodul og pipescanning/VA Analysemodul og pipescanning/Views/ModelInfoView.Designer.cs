namespace VA_Analysemodul
{
    partial class ModelInfoView
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
            this.btnSaveEdits = new System.Windows.Forms.Button();
            this.lblModelDesc = new System.Windows.Forms.Label();
            this.txtModelDescription = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtModelInfoFilePath = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.btnOpenDocument = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // btnSaveEdits
            // 
            this.btnSaveEdits.Location = new System.Drawing.Point(427, 29);
            this.btnSaveEdits.Name = "btnSaveEdits";
            this.btnSaveEdits.Size = new System.Drawing.Size(75, 23);
            this.btnSaveEdits.TabIndex = 0;
            this.btnSaveEdits.Text = Properties.Resources.SaveEdits;
            this.btnSaveEdits.UseVisualStyleBackColor = true;
            this.btnSaveEdits.Click += new System.EventHandler(this.btnSaveEdits_Click);
            // 
            // lblModelDesc
            // 
            this.lblModelDesc.AutoSize = true;
            this.lblModelDesc.Location = new System.Drawing.Point(13, 57);
            this.lblModelDesc.Name = "lblModelDesc";
            this.lblModelDesc.Size = new System.Drawing.Size(93, 13);
            this.lblModelDesc.TabIndex = 1;
            this.lblModelDesc.Text = Properties.Resources.ModelDesc;
            // 
            // txtModelDescription
            // 
            this.txtModelDescription.Location = new System.Drawing.Point(16, 74);
            this.txtModelDescription.Multiline = true;
            this.txtModelDescription.Name = "txtModelDescription";
            this.txtModelDescription.Size = new System.Drawing.Size(486, 96);
            this.txtModelDescription.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 193);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Info / description file path:";
            // 
            // txtModelInfoFilePath
            // 
            this.txtModelInfoFilePath.Location = new System.Drawing.Point(19, 210);
            this.txtModelInfoFilePath.Name = "txtModelInfoFilePath";
            this.txtModelInfoFilePath.Size = new System.Drawing.Size(483, 20);
            this.txtModelInfoFilePath.TabIndex = 4;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(248, 236);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(124, 23);
            this.btnBrowse.TabIndex = 5;
            this.btnBrowse.Text = Properties.Resources.BrowseDocument;
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // btnOpenDocument
            // 
            this.btnOpenDocument.Location = new System.Drawing.Point(378, 236);
            this.btnOpenDocument.Name = "btnOpenDocument";
            this.btnOpenDocument.Size = new System.Drawing.Size(124, 23);
            this.btnOpenDocument.TabIndex = 6;
            this.btnOpenDocument.Text = Properties.Resources.OpenDocument;
            this.btnOpenDocument.UseVisualStyleBackColor = true;
            this.btnOpenDocument.Click += new System.EventHandler(this.btnOpenDocument_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // ModelInfoView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(531, 298);
            this.Controls.Add(this.btnOpenDocument);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.txtModelInfoFilePath);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtModelDescription);
            this.Controls.Add(this.lblModelDesc);
            this.Controls.Add(this.btnSaveEdits);
            this.Name = "ModelInfoView";
            this.Text = Properties.Resources.TitleModelInfo;
            this.Load += new System.EventHandler(this.VaAnalyseModulForm_ModelInfo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSaveEdits;
        private System.Windows.Forms.Label lblModelDesc;
        private System.Windows.Forms.TextBox txtModelDescription;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtModelInfoFilePath;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Button btnOpenDocument;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}