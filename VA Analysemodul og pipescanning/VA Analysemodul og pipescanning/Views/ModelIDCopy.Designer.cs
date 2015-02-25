namespace VA_Analysemodul.Views
{
    partial class ModelIDCopy
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
            this.txtNyModelID = new System.Windows.Forms.TextBox();
            this.btnLagreModelId = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Oppgi ny modellID:";
            // 
            // txtNyModelID
            // 
            this.txtNyModelID.Location = new System.Drawing.Point(16, 39);
            this.txtNyModelID.Name = "txtNyModelID";
            this.txtNyModelID.Size = new System.Drawing.Size(256, 20);
            this.txtNyModelID.TabIndex = 1;
            // 
            // btnLagreModelId
            // 
            this.btnLagreModelId.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnLagreModelId.Location = new System.Drawing.Point(93, 70);
            this.btnLagreModelId.Name = "btnLagreModelId";
            this.btnLagreModelId.Size = new System.Drawing.Size(75, 23);
            this.btnLagreModelId.TabIndex = 2;
            this.btnLagreModelId.Text = "Lagre";
            this.btnLagreModelId.UseVisualStyleBackColor = true;
            // 
            // ModelIDCopy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 105);
            this.Controls.Add(this.btnLagreModelId);
            this.Controls.Add(this.txtNyModelID);
            this.Controls.Add(this.label1);
            this.Name = "ModelIDCopy";
            this.Text = "ModelIDCopy";
            this.Load += new System.EventHandler(this.ModelIDCopy_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNyModelID;
        private System.Windows.Forms.Button btnLagreModelId;
    }
}