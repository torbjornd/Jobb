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
    public partial class ModelInfoView : Form
    {

        #region properties
        string document = null;

        public ModelInfoControl _control;

        private int oid;

        public int Oid
        {
            get { return oid; }
            set { oid = value; }
        }

        private AnalyseModul_LogOn logon;

        public AnalyseModul_LogOn Logon
        {
            get { return logon; }
            set { logon = value; }
        }

        private string modelDescription;

        public string ModelDescription
        {
            get { return txtModelDescription.Text; }
            set { txtModelDescription.Text = value; }
        }
        private string modelInfoPath;

        public string ModelInfoPath
        {
            get { return txtModelInfoFilePath.Text; }
            set { txtModelInfoFilePath.Text = value; }
        }
        
        #endregion

        public ModelInfoView()
        {
            InitializeComponent();
            _control = new ModelInfoControl();
            _control.setView(this);
            
        }
        public void setControl()
        {
            _control = new ModelInfoControl();
        }

        
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog1.ShowDialog();
                document = openFileDialog1.FileName;
                txtModelInfoFilePath.Text = document;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Det skjedde noe feil under henting av fil. " + ex.Message,
                    "Det skjedde noe feil",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnOpenDocument_Click(object sender, EventArgs e)
        {
            try
            {
                _control.openDocument();
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        private void btnSaveEdits_Click(object sender, EventArgs e)
        {
            try
            {
                _control.saveEdits();
            }
            catch (Exception ex)
            {
                this.Close();
            }
        }

        private void VaAnalyseModulForm_ModelInfo_Load(object sender, EventArgs e)
        {
            _control.setLogon(Logon);
            _control.load();
            
        }
    }
}
