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
    public partial class OptionsView : Form
    {
        #region "Properties"

        private OptionsController _controller;

        internal OptionsController Controller
        {
            get { return _controller; }
            set { _controller = value; }
        }

        private List<string> optionsList;

        public List<string> OptionsList
        {
            get { return chxOptionList.Items.Cast<string>().ToList(); }
            set { chxOptionList.Items.AddRange(value.ToArray()); }
        }

        private string optionsList_selected;

        public string OptionsList_selected
        {
            get { return chxOptionList.SelectedText; }
            set { chxOptionList.SelectedIndex = chxOptionList.FindString(value); }
        }
        #endregion

        public OptionsView()
        {
            InitializeComponent();
            _controller = new OptionsController();
        }

        private void btnSaveSettings_Click(object sender, EventArgs e)
        {
            try
            {
                _controller.saveOptions();
            }
            catch (Exception ex)
            {
                visFeilmelding(ex.Message);
            }
        }

        private void VaAnalyseModul_Options_Load(object sender, EventArgs e)
        {
            try
            {
                _controller.loadForm();
            }
            catch (Exception ex)
            {
                visFeilmelding(ex.Message);
            }
        }

        private void visFeilmelding(string melding)
        {
            MessageBox.Show(melding,
                    "Feil ved lagring",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
        }
    }
}
