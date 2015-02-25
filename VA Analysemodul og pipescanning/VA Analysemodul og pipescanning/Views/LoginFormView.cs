using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VA_Analysemodul
{
    public partial class LoginFormView : Form
    {
        private string brukernavn;

        public string Brukernavn
        {
            get { return txtBrukernavn.Text; }
            set { brukernavn = value; }
        }
        
        public LoginFormView()
        {
            InitializeComponent();
            int x = Bounds.Height / 2 - this.Height / 2;
            int y = Bounds.Width / 2 - this.Width / 2;
            this.Location = new Point(x, y);
        }

        public void setController(AnalyseModul_LogOn logon)
        {
        }

        private void txtBrukernavn_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void btnLoggInn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
