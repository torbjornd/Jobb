using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VA_Analysemodul.Views
{
    public partial class ModelIDCopy : Form
    {
        private string nyModelID;
        public string NyModelID
        {
            get { return txtNyModelID.Text; }
        }

        public ModelIDCopy()
        {
            InitializeComponent();
        }

        private void ModelIDCopy_Load(object sender, EventArgs e)
        {

        }
    }
}
