namespace VA_Analysemodul
{
    partial class LoginFormView
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
            this.lblBrukernavn = new System.Windows.Forms.Label();
            this.txtBrukernavn = new System.Windows.Forms.TextBox();
            this.btnLoggInn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblBrukernavn
            // 
            this.lblBrukernavn.AutoSize = true;
            this.lblBrukernavn.Location = new System.Drawing.Point(14, 26);
            this.lblBrukernavn.Name = "lblBrukernavn";
            this.lblBrukernavn.Size = new System.Drawing.Size(62, 13);
            this.lblBrukernavn.TabIndex = 0;
            this.lblBrukernavn.Text = "Brukernavn";
            // 
            // txtBrukernavn
            // 
            this.txtBrukernavn.Location = new System.Drawing.Point(82, 23);
            this.txtBrukernavn.Name = "txtBrukernavn";
            this.txtBrukernavn.Size = new System.Drawing.Size(190, 20);
            this.txtBrukernavn.TabIndex = 1;
            this.txtBrukernavn.TextChanged += new System.EventHandler(this.txtBrukernavn_TextChanged);
            // 
            // btnLoggInn
            // 
            this.btnLoggInn.Location = new System.Drawing.Point(105, 49);
            this.btnLoggInn.Name = "btnLoggInn";
            this.btnLoggInn.Size = new System.Drawing.Size(75, 23);
            this.btnLoggInn.TabIndex = 2;
            this.btnLoggInn.Text = global::VA_Analysemodul.Properties.Resources.LoggIn;
            this.btnLoggInn.UseVisualStyleBackColor = true;
            this.btnLoggInn.Click += new System.EventHandler(this.btnLoggInn_Click);
            // 
            // LoginFormView
            // 
            this.AcceptButton = this.btnLoggInn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(289, 80);
            this.Controls.Add(this.btnLoggInn);
            this.Controls.Add(this.txtBrukernavn);
            this.Controls.Add(this.lblBrukernavn);
            this.Name = "LoginFormView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Logg inn";
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblBrukernavn;
        public System.Windows.Forms.TextBox txtBrukernavn;
        private System.Windows.Forms.Button btnLoggInn;
    }
}