using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VA_Analysemodul
{
    public partial class RelationControl : UserControl
    {

        #region relTab
        private List<string> lyrNameRel;

        public List<string> LyrNameRel
        {
            get { return cbxLyrRel.Items.Cast<string>().ToList(); }
            set {
                cbxLyrRel.Items.Clear();
                cbxLyrRel.Items.AddRange(value.ToArray());
                int a = cbxLyrRel.FindString("");
                while (a > -1)
                {
                    cbxLyrRel.Items.RemoveAt(a);
                    cbxLyrRel.Refresh();
                    a = cbxLyrRel.FindStringExact("");
                }
            }
        }

        private string lyrNameRel_selected;

        public string LyrNameRel_selected
        {
            get { return cbxLyrRel.Text; }
            set
            {
                if (value.Equals("") == false)
                    cbxLyrRel.Text = value;
                
            }
        }

        private List<string> objectClassName;

        public List<string> ObjectClassName
        {
            get { return cbxObjClassName.Items.Cast<string>().ToList(); }
            set { cbxObjClassName.Items.AddRange(value.ToArray()); }
        }

        private string objectClassName_selected;

        public string ObjectClassName_selected
        {
            get { return cbxObjClassName.Text; }
            set { cbxObjClassName.Text = value; }
        }


        private List<string> relationType;

        public List<string> RelationType
        {
            get { return cbxRelTypeRel.Items.Cast<string>().ToList(); }
            set 
            { 
                cbxRelTypeRel.Items.AddRange(value.ToArray());
                if(cbxRelTypeRel.Items.Count > 0)
                    cbxRelTypeRel.SelectedIndex = 0;    
            }
        }

        private string relationType_selected;

        public string RelationType_selected
        {
            get { return cbxRelTypeRel.Text; }
            set {
                //if (cbxRelTypeRel.SelectedIndex == -1)
                //{
                    int indeks = cbxRelTypeRel.FindString(value);
                    cbxRelTypeRel.SelectedIndex = indeks;
                    cbxRelTypeRel.Text = value;
                //}
            }
        }

        private string dataSourceRel;

        public string DataSourceRel
        {
            get { return txtDatasourceRel.Text; }
            set { txtDatasourceRel.Text = value; }
        }

        private List<string> objectClassRelField;

        public List<string> ObjectClassRelField
        {
            get { return cbxObjectClass_RelField.Items.Cast<string>().ToList(); }
            set { cbxObjectClass_RelField.Items.AddRange(value.ToArray()); }
        }

        private bool objectClassRelField_visible;

        public bool ObjectClassRelField_visible
        {
            get { return cbxObjectClass_RelField.Visible; }
            set { cbxObjectClass_RelField.Visible = value; }
        }

        private string objectClassRelField_selected;

        public string ObjectClassRelField_selected
        {
            get { return cbxObjectClass_RelField.Text; }
            set { cbxObjectClass_RelField.Text = value; }
        }


        private string mainObjectClass_relField_selected;

        public string MainObjectClass_relField_selected
        {
            get { return cbxMainObjectClass_relField.Text; }
            set { cbxMainObjectClass_relField.Text = value; }
        }

        private List<string> mainObjectClass_relField;

        public List<string> MainObjectClass_relField
        {
            get { return cbxMainObjectClass_relField.Items.Cast<string>().ToList(); }
            set 
            {
                cbxMainObjectClass_relField.Items.Clear();
                cbxMainObjectClass_relField.Items.AddRange(value.ToArray()); 
            }
        }

        private bool mainObjectClass_relField_visible;

        public bool MainObjectClass_relField_visible
        {
            get { return cbxMainObjectClass_relField.Visible; }
            set { cbxMainObjectClass_relField.Visible = value; }
        }


        private List<string> selectionTypeRel;

        public List<string> SelectionTypeRel
        {
            get { return cbxSelectionTypeRel.Items.Cast<string>().ToList(); }
            set { cbxSelectionTypeRel.Items.AddRange(value.ToArray()); }
        }

        private string selectionTypeRel_selected;

        public string SelectionTypeRel_selected
        {
            get { return cbxSelectionTypeRel.Text; }
            set 
            { 
                cbxSelectionTypeRel.SelectedIndex = cbxSelectionTypeRel.FindString(value);
                cbxSelectionTypeRel.Text = value;
            }
        }

        private bool includeFeaturesRel;

        public bool IncludeFeaturesRel
        {
            get { return chxIncludeFeaturesRel.Checked; }
            set { chxIncludeFeaturesRel.Checked = value; }
        }

        private bool includeFeaturesRel_visible;

        public bool IncludeFeaturesRel_visible
        {
            get { return chxIncludeFeaturesRel.Visible; }
            set { chxIncludeFeaturesRel.Visible = value; }
        }


        private List<string> spatialTypeRel;

        public List<string> SpatialTypeRel
        {
            get { return cbxSpatialRelTypeRel.Items.Cast<string>().ToList(); }
            set { cbxSpatialRelTypeRel.Items.AddRange(value.ToArray()); }
        }

        private string spatialTypeRel_selected;

        public string SpatialTypeRel_selected
        {
            get { return cbxSpatialRelTypeRel.Text; }
            set { cbxSpatialRelTypeRel.Text = value; }
        }

        private bool spatialTypeRel_visible;

        public bool SpatialTypeRel_visible
        {
            get { return cbxSpatialRelTypeRel.Visible; }
            set { cbxSpatialRelTypeRel.Visible = value; }
        }

        private double bufferDistanceRelation;

        public double BufferDistanceRelation
        {
            get 
            {
                try
                {
                    double buffer;
                    double.TryParse(txtBufferDistanceRel.Text, out buffer);
                    return buffer;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            set { txtBufferDistanceRel.Text = value.ToString(); }
        }

        private bool antallRalaterte_enable;

        public bool AntallRelaterte_enable
        {
            set { txtAntallRelasjoner.Enabled = value; }
        }

        private int antallRelaterte;

        public int AntallRelaterte
        {
            get { return int.Parse(txtAntallRelasjoner.Text); }
            set { txtAntallRelasjoner.Text = value.ToString(); }
        }

        private bool bufferDistanceRel_visible;

        public bool BufferDistanceRel_visible
        {
            get { return txtBufferDistanceRel.Visible; }
            set { txtBufferDistanceRel.Visible = value; }
        }

        


        public event EventHandler relationType_Changed;
        public event EventHandler lyrName_Changed;
        public event EventHandler editQuery_Clicked;
        public event EventHandler saveQuery_Clicked;
        public event EventHandler deleteQuery_Clicked;
        public event EventHandler antallRelaterte_CheckedChanged;

        #endregion

        public RelationControl()
        {
            InitializeComponent();
            antallRalaterte_enable = false;
        }

        public void settAlleEnablet(bool enable)
        {
            foreach (Control c in this.Controls)
            {
                c.Enabled = enable;
            }
        }

        public void settRelationTypeEnable()
        {
            try
            {
                if (RelationType_selected != null && RelationType_selected.Equals("Attributt/felt"))
                {
                    cbxObjectClass_RelField.Visible = true;
                    cbxObjectClass_RelField.Enabled = true;
                    cbxMainObjectClass_relField.Visible = true;
                    cbxMainObjectClass_relField.Enabled = true;
                    cbxSelectionTypeRel.Visible = true;
                    cbxSelectionTypeRel.Enabled = true;
                    chxIncludeFeaturesRel.Enabled = true;
                    cbxSpatialRelTypeRel.Enabled = false;
                    txtBufferDistanceRel.Enabled = false;
                }
                else
                {
                    cbxObjectClass_RelField.Visible = true;
                    cbxObjectClass_RelField.Enabled = false;
                    cbxMainObjectClass_relField.Enabled = false;
                    cbxMainObjectClass_relField.Visible = true;
                    chxIncludeFeaturesRel.Enabled = false;
                    cbxSelectionTypeRel.Visible = true;
                    cbxSelectionTypeRel.Enabled = false;
                    cbxSpatialRelTypeRel.Enabled = true;
                    txtBufferDistanceRel.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void cbxRelTypeRel_SelectedValueChanged(object sender, EventArgs e)
        {
            if(this.relationType_Changed != null)
                this.relationType_Changed(this, e);
        }

        protected void cbxLyrRel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.lyrName_Changed != null)
                this.lyrName_Changed(this, e);
        }

        protected void chxAntallRelaterte_CheckedChanged(object sender, EventArgs e)
        {
            if (this.antallRelaterte_CheckedChanged != null)
                this.antallRelaterte_CheckedChanged(this, e);
        }
            
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEditQuery_Click(object sender, EventArgs e)
        {
            if (this.editQuery_Clicked != null)
                this.editQuery_Clicked(this, e);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeleteRelation_Click(object sender, EventArgs e)
        {
            if (this.deleteQuery_Clicked != null)
                this.deleteQuery_Clicked(this, e);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSaveRelation_Click(object sender, EventArgs e)
        {
            if (this.saveQuery_Clicked != null)
                this.saveQuery_Clicked(this,e);
        }


        public void resetPages()
        {
            try
            {
                string relSearchTypeValue = "AND: Selection criteria in origin objectclass and in related table";
                string relTypeValue = "Attributt/felt";

                SelectionTypeRel_selected = relSearchTypeValue;
                IncludeFeaturesRel = false;
                RelationType_selected = relTypeValue;
                ObjectClassName_selected = "";
                DataSourceRel = "";
                MainObjectClass_relField_selected = "";
                ObjectClassRelField_selected = "";
                LyrNameRel_selected = "";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void setDefault()
        {
            cbxRelTypeRel.SelectedIndex = cbxRelTypeRel.FindString("AND: Selection criteria in origin objectclass and in related table");
            cbxSelectionTypeRel.SelectedIndex = cbxRelTypeRel.FindString("Attributt/felt");
        }
               
    }
}
