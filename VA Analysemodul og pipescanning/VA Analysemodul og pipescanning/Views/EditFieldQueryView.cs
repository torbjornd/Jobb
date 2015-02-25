using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VA_Analysemodul
{
    public partial class EditFieldQueryView : Form
    {
        public EditFieldQueryController _controller;



        #region "Properties"

        private string pageName;

        public string PageName
        {
            get { return pageName; }
            set { pageName = value; }
        }

        private string mainLyrName;

        public string MainLyrName
        {
            get { return txtLayerName.Text; }
            set { txtLayerName.Text = value; }
        }

        private string mainObjectClassName;

        public string MainObjectClassName
        {
            get { return txtObjectClass.Text; }
            set { txtObjectClass.Text = value; }
        }
        
        private string value;

        public string Value
        {
            get { return lbxValueList.SelectedItem.ToString(); }
            set { this.value = value; }
        }

        private ComboBox fieldNamesBox;

        public ComboBox FieldNamesBox
        {
            get { return cbxFieldName; }
            set { cbxFieldName = value; }
        }
        
        private int antSelektert;

        public int AntSelektert
        {
            get { return lsvFieldQueryList.SelectedItems.Count; }
            set { antSelektert = value; }
        }

        private List<string> valueList;

        public List<string> ValueList
        {
            get { return lbxValueList.Items.Cast<string>().ToList<string>(); }
            set
            {
                lbxValueList.Items.AddRange(value.ToArray()); 
            }
        }

        private int valueList_selected;

        public int ValueList_selected
        {
            get { return valueList_selected; }
            set { lbxValueList.SetSelected(value, true); }
        }

        private int valueList_selectedCount;

        public int ValueList_selectedCount
        {
            get { return lbxValueList.SelectedItems.Count; }
            //set { valueList_selectedCount = value; }
        }


        private string[] valueList_selectedArray;

        public string[] ValueList_selectedArray
        {
            get
            {
                valueList_selectedArray = new string[valueList_selectedCount];
                int n = 0;
                for (int i = 0; i < lbxValueList.Items.Count; i++)
                {
                    if(lbxValueList.SelectedItems.Contains(lbxValueList.Items[i]))
                    {
                        valueList_selectedArray[n] = lbxValueList.Items[i].ToString();
                        n = n + 1;
                    }
                }
                return valueList_selectedArray; }
        }

        private string valueList_toSeparatedString;

        public string ValueList_toSeparatedString
        {
            get 
            { 
                List<string> listen = new List<string>();
                if (lbxValueList.SelectedItems.Count != 0)
                {
                    foreach (string s in lbxValueList.Items)
                    {
                        if (lbxValueList.SelectedItems.Contains(s))
                            listen.Add(s);
                    }
                    return string.Join(";", listen);
                }
                else
                {
                    return null;
                }
            }
        }
        private bool valueList_isSelected;

        public bool ValueList_isSelected
        {
            get
            {
                if (lbxValueList.SelectedItems.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        private string modelId;

        public string ModelId
        {
            get { return modelId; }
            set { modelId = value; }
        }

        private string tableNr;

        public string TableNr
        {
            get { return txtTableNo.Text; }
            set 
            {
                tableNr = value;
                txtTableNo.Text = value; 
            }
        }
        
        private int oid;

        public int Oid
        {
            get { return oid; }
            set 
            { 
                oid = value;
                txtOID.Text = value.ToString();
            }
        }
        
        private string andOr;
        public string AndOr
        {
            get { return cbxAndOr.Text; }
        }

        private string[,] fieldQueryList;

        public string[,] FieldQueryList
        {
            //get { return lsvFieldQueryList.Items.Cast<string>().ToArray(); }
            set 
            {
                for (int i = 0; i < value.GetLength(0); i++)
                {
                    ListViewItem item = new ListViewItem(value[i, value.GetLength(1)-1]);
                        
                    for (int j = 0; j < (value.GetLength(1) - 1); j++)
                    {
                        if (i == 0)
                        {
                            lsvFieldQueryList.Columns.Add(value[i, j]);
                        }
                        else
                        {
                            item.SubItems.Add(value[i, j]);
                        }
                    }
                    if (i != 0)
                    {
                        item.SubItems.RemoveAt(0);
                        lsvFieldQueryList.Items.Add(item);
                    }
                }
            }
        }

        private int fieldQueryList_selected;

        public int FieldQueryList_selected
        {
            get { return lsvFieldQueryList.SelectedIndices[0]; }
            set { fieldQueryList_selected = value; }
        }

        public int FieldQueryList_itemsCount
        {
            get { return lsvFieldQueryList.Items.Count; }
        }

        private List<string> mainObjectClass_AndOr;

        public List<string> MainObjectClass_AndOr
        {
            get { return cbxAndOr.Items.Cast<string>().ToList(); }
            set { cbxAndOr.Items.AddRange(value.ToArray());
                cbxAndOr.Items.Add("");
            }
        }

        private string mainObjectClass_AndOr_selected;

        public string MainObjectClass_AndOr_selected
        {
            get { return cbxAndOr.SelectedText; }
            set
            {
                if (cbxAndOr.Items.Contains(value) == false)
                {
                    cbxAndOr.Items.Add(value);
                }
                cbxAndOr.SelectedIndex = cbxAndOr.FindString(value); 
            }
        }

        private List<string> operatoren;

        public List<string> Operatoren
        {
            get { return cbxOperator.Items.Cast<string>().ToList(); }
            set { cbxOperator.Items.AddRange(value.ToArray()); }
        }

        private string operatoren_selected;

        public string Operatoren_selected
        {
            get { return cbxOperator.Text; }
            set
            {
                if (cbxOperator.Items.Contains(value) == false)
                {
                    cbxOperator.Items.Add(value);
                }
                cbxOperator.SelectedIndex = cbxOperator.FindString(value); 
            }
        }
        
        private List<string> fieldNameItems;

        public List<string> FieldNameItems
        {
            get { return cbxFieldName.Items.Cast<string>().ToList() ; }
            set
            { 
                cbxFieldName.Items.AddRange(value.ToArray());
            }
        }

        private string fieldNameItems_selected;

        public string FieldNameItems_selected
        {
            get { return cbxFieldName.Text; }
            set
            {
                if (cbxFieldName.Items.Contains(value) == false)
                {
                    cbxFieldName.Items.Add(value);
                }
                cbxFieldName.SelectedIndex = cbxFieldName.FindString(value); }
        }


        private List<string> mainObjectClassValue;

        public List<string> MainObjectClassValue
        {
            get { return cbxMainObjectClassValue.Items.Cast<string>().ToList(); }
            set
            {
                cbxMainObjectClassValue.Items.AddRange(value.ToArray()); 
            }
        }

        private string mainObjectClassValue_selected;

        public string MainObjectClassValue_selected
        {
            get { return cbxMainObjectClassValue.Text; }
            set
            {
                cbxMainObjectClassValue.Items.Clear();
                if (cbxMainObjectClassValue.Items.Contains(value) == false)
                {
                    cbxMainObjectClassValue.Items.Add(value);
                }
                cbxMainObjectClassValue.SelectedIndex = cbxMainObjectClassValue.FindString(value); 
            }
        }

        private string layerName;

        public string LayerName
        {
            get { return lblLayerName.Text; }
            set { lblLayerName.Text = value; }
        }
        
        private string objectClass;
        public string ObjectClass
        {
            get { return lblObjectClass.Text; }
            set { lblObjectClass.Text = value; }
        }
        
        private bool p1;
        public bool P1
        {
            get { return chxP1.Checked; }
            set { chxP1.Checked = value; }
        }

        private bool p2;
        public bool P2
        {
            get { return chxP2.Checked; }
            set { chxP2.Checked = value; }
        }
        
        private bool unique;
        public bool Unique
        {
            get { return chxUnique.Checked; }
            set { chxUnique.Checked = value; }
        }
        
        private bool sort;
        public bool Sort
        {
            get { return chxSort.Checked; }
            set { chxSort.Checked = value; }
        }

        #endregion

        /// <summary>
        /// 
        /// </summary>
        public EditFieldQueryView()
        {
            InitializeComponent();
            _controller = new EditFieldQueryController(this);
        }

        private void VaAnalyseModul_EditFieldQuery_Load(object sender, EventArgs e)
        {
            try
            {
                _controller.load();
            }
            catch (Exception ex)
            {
                visFeilMelding(ex.Message);
                this.Close();
            }
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="controller"></param>
        public void setController(EditFieldQueryController controller)
        {
            _controller = controller;
        }

        public void clearList()
        {
            lsvFieldQueryList.Items.Clear();
            lsvFieldQueryList.Columns.Clear();
        }

        public void clearFieldValues()
        {
            cbxMainObjectClassValue.Items.Clear();
            lbxValueList.Items.Clear();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeleteFieldQuery_Click(object sender, EventArgs e)
        {
            try
            {
                _controller.slettFieldQuery();
            }
            catch (Exception ex)
            {
                visFeilMelding(ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSaveEdits_Click(object sender, EventArgs e)
        {
            try
            {
                _controller.saveFieldQueryEdits();
            }
            catch (Exception ex)
            {
                visFeilMelding(ex.Message);
            }
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNewFieldQuery_Click(object sender, EventArgs e)
        {
            try
            {
                _controller.newFieldQuery();
            }
            catch (Exception ex)
            {
                visFeilMelding(ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        public void visFeilMelding(string text)
        {
            MessageBox.Show(text, "Det skjedde noe feil", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="feltNavn"></param>
        public void setFieldNames(List<string> feltNavn)
        {
            cbxFieldName.Items.AddRange(feltNavn.ToArray());
        }

        /// <summary>
        /// Det er haket av for sortering eller unike verdier.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                _controller.checkBox_checkChanged(((CheckBox)sender).Name);
            }
            catch (Exception ex)
            {
                visFeilMelding(ex.Message);
            }
        }


        public void lsvFieldQueryList_Clear()
        {
            lsvFieldQueryList.Columns.Clear();
            lsvFieldQueryList.Items.Clear();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lsvFieldQueryList_Click(object sender, EventArgs e)
        {
            try
            {
                _controller.mainObjectClass_FieldQueryList_clicked();
            }
            catch (Exception ex)
            {
                visFeilMelding(ex.Message);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditFieldQueryView_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbxFieldName_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                _controller.mainObjectClass_FieldNameChange(true);
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                visFeilMelding(ex.Message);
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtLayerName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                _controller.mainLyrName_Change();
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        private void lsvFieldQueryList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
    public class DomainValue
    {
        public string domainValue { get; set; }
        public string domainText { get; set; }
    }
}
