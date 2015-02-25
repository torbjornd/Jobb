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
    public partial class DesignDialogView : Form
    {
        public DesignDialogControl _controller;


        #region Properties
        
        #region "AnalysisInfo"
        private AnalyseModul_LogOn paalogging;
        private VAAnalyseModul analyseModul;
        private string modelOwner;
        private string modelId;
        private string modelDescr;
        private string modelName;
        private string MainObjectClassName;
        private string mainLyrName;
        private string mainObjectClassDataSource;
        private int modelListIndex;
        private List<string> mainObjectClass_RelField1;
        private List<string> mainObjectClass_RelField2;
        private List<string> mainObjectClass_RelField3;
        private List<string> mainObjectClass_RelField4;
        private List<string> mainObjectClass_RelField5;
        private List<string> mainObjectClass_RelField6;
        private List<string> mainObjectClass_RelField7;
        private List<string> mainObjectClass_RelField8;
        private List<string> modelList;

        private string pageName;

        public string PageName
        {
            get { return tbcRelations.SelectedTab.Name; }
            set { tbcRelations.Name = value; }
        }

        private string regDate;

        public string RegDate
        {
            get { return txtCreatedDate.Text; }
            set { txtCreatedDate.Text = value; }
        }

        private string chDate;

        public string ChDate
        {
            get { return txtChangedDate.Text; }
            set { txtChangedDate.Text = value; }
        }

        private string firstRunDate;

        public string FirstRunDate
        {
            get { return txtFirstRun.Text; }
            set { txtFirstRun.Text = value; }
        }

        private string lastRunDate;

        public string LastRunDate
        {
            get { return txtLastRun.Text; }
            set { txtLastRun.Text = value; }
        }

        private List<string> mainLyrName_ItemsList;

        public List<string> MainLyrName_ItemsList
        {
            get { return chxLayerName.Items.Cast<string>().ToList(); }
            set { chxLayerName.Items.AddRange(value.ToArray()); }
        }
        public int ModelListIndex
        {
            get { return lstModelList.SelectedIndices[0]; }
            //set { lstModelList.SelectedIndices[0]= value; }
        }
        
        public ListViewItem ModelList
        {
            set { lstModelList.Items.Add(value); }
        }

        public ListView.ListViewItemCollection ModelListItems
        {
            get { return lstModelList.Items; }
        }

        public string MainObjectClassDataSource
        {
            get { return txtMainObjectClassDataSource.Text; }
            set { txtMainObjectClassDataSource.Text = value; }
        }

        public string MainObjectClassName1
        {
            get { return txtMainObjectClass.Text; }
            set { txtMainObjectClass.Text = value; }
        }

        public string ModelName
        {
            get { return txtModelName.Text; }
            set { txtModelName.Text = value; }
        }

        public string MainLyrName
        {
            get { return chxLayerName.Text; }
            set 
            {
                try
                {
                    chxLayerName.Items.Add(value);
                    chxLayerName.SelectedIndex = chxLayerName.FindString(value);
                }
                catch (NullReferenceException nullEx)
                {
                    throw new Exception("Laget " + value + " ble ikke funnet");
                }
            }
        }

        public string ModelDescr
        {
            get { return txtModelDescription.Text; }
            set { txtModelDescription.Text = value; }
        }

        public string ModelId
        {
            get { return txtModelId.Text; }
            set { txtModelId.Text = value; }
        }

        public string ModelOwner
        {
            get { return chxModelOwner.Text; }
            set 
            {
                if (!chxModelOwner.Items.Contains(value))
                {
                    chxModelOwner.Items.Add(value);
                }
                chxModelOwner.SelectedIndex = chxModelOwner.FindString(value);
            }
        }
        
        private string userName;

        public string UserName
        {
            get { return lblBrukernavn.Text; }
            set { lblBrukernavn.Text += value; }
        }

        private List<string> modelOwnerList;

        public List<string> ModelOwnerList
        {
            get { return chxSearchModelOwner.Items.Cast<string>().ToList(); }
            set { chxSearchModelOwner.Items.AddRange(value.ToArray()); }
        }

        private string modelOwnerList_selected;

        public string ModelOwnerList_selected
        {
            get { return chxModelOwner.Text; }
            set { chxModelOwner.SelectedIndex = chxModelOwner.FindString(value); }
        }

        private List<string> modelNameList;

        public List<string> ModelNameList
        {
            get { return cbxModelName.Items.Cast<string>().ToList(); }
            set { cbxModelName.Items.AddRange(value.ToArray()); }
        }

        private string modelNameList_selected;

        public string ModelNameList_selected
        {
            get { return cbxModelName.Text; }
            set { cbxModelName.SelectedIndex = cbxModelName.FindString(value); }
        }



        private string OIDModel;

        public string OIDModel1
        {
            get { return txtOIDModel.Text; }
            set { txtOIDModel.Text = value.ToString(); }
        }

        #endregion

        #region relTab1
        private List<string> lyrNameRel1;

        public List<string> LyrNameRel1
        {
            get { return rCtrlRelation1.LyrNameRel; }
            set
            {
                try
                {
                    if (value.Contains(null))
                        value.Remove(null);
                    rCtrlRelation1.LyrNameRel = value;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                
            }
        }

        private string lyrNameRel1_selected;

        public string LyrNameRel1_selected
        {
            get { return rCtrlRelation1.LyrNameRel_selected; }
            set
            {
                rCtrlRelation1.LyrNameRel_selected = value;
            }
        }

        private List<string> objectClassName1;

        public List<string> ObjectClassName1
        {
            get { return rCtrlRelation1.ObjectClassName; }
            set { rCtrlRelation1.ObjectClassName = value; }
        }

        private string objectClassName1_selected;

        public string ObjectClassName1_selected
        {
            get { return rCtrlRelation1.ObjectClassName_selected; }
            set { rCtrlRelation1.ObjectClassName_selected = value; }
        }

        private List<string> relationType1;

        public List<string> RelationType1
        {
            get { return rCtrlRelation1.RelationType; }
            set { rCtrlRelation1.RelationType = value; }
        }

        private string relationType1_selected;

        public string RelationType1_selected
        {
            get { return rCtrlRelation1.RelationType_selected; }
            set { rCtrlRelation1.RelationType_selected = value; }
        }

        private string dataSourceRel1;

        public string DataSourceRel1
        {
            get { return rCtrlRelation1.DataSourceRel; }
            set { rCtrlRelation1.DataSourceRel = value; }
        }
                
        private List<string> objectClassRelField1;

        public List<string> ObjectClassRelField1
        {
            get { return rCtrlRelation1.ObjectClassRelField; }
            set {rCtrlRelation1.ObjectClassRelField = value; }
        }
        
        private string objectClassRelField1_selected;

        public string ObjectClassRelField1_selected
        {
            get { return rCtrlRelation1.ObjectClassRelField_selected; }
            set { rCtrlRelation1.ObjectClassRelField_selected = value; }
        }
        
        private string mainObjectClass_relField1_selected;

        public string MainObjectClass_relField1_selected
        {
            get { return rCtrlRelation1.MainObjectClass_relField_selected; }
            set { rCtrlRelation1.MainObjectClass_relField_selected = value; }
        }

        private List<string> mainObjectClass_relField1;

        public List<string> MainObjectClass_relField1
        {
            get { return rCtrlRelation1.MainObjectClass_relField; }
            set { rCtrlRelation1.MainObjectClass_relField = value; }
        }

        
        private List<string> selectionTypeRel1;

        public List<string> SelectionTypeRel1
        {
            get { return rCtrlRelation1.SelectionTypeRel; }
            set { rCtrlRelation1.SelectionTypeRel = value; }
        }

        private string selectionTypeRel1_selected;

        public string SelectionTypeRel1_selected
        {
            get { return rCtrlRelation1.SelectionTypeRel_selected; }
            set { rCtrlRelation1.SelectionTypeRel_selected = value; }
        }

        private bool includeFeaturesRel1;

        public bool IncludeFeaturesRel1
        {
            get { return rCtrlRelation1.IncludeFeaturesRel; }
            set { rCtrlRelation1.IncludeFeaturesRel = value; }
        }

        
        private int antallRelaterte;
        public int AntallRelaterte
        {
            get 
            {
                int defalutVal;
                int.TryParse(rCtrlRelation1.AntallRelaterte.ToString(), out defalutVal);
                return defalutVal;
            }
            set { rCtrlRelation1.AntallRelaterte = value; }
        }

        private List<string> spatialTypeRel1;

        public List<string> SpatialTypeRel1
        {
            get { return rCtrlRelation1.SpatialTypeRel; }
            set { rCtrlRelation1.SpatialTypeRel = value; }
        }

        private string spatialTypeRel1_selected;

        public string SpatialTypeRel1_selected
        {
            get { return rCtrlRelation1.SpatialTypeRel_selected; }
            set { rCtrlRelation1.SpatialTypeRel_selected = value; }
        }

        private double bufferDistanceRel1;

        public double BufferDistanceRel1
        {
            get { return rCtrlRelation1.BufferDistanceRelation; }
            set { rCtrlRelation1.BufferDistanceRelation = value; }
        }
        #endregion

        // RelTab2
        #region "relTab2"
        private List<string> lyrNameRel2;

        public List<string> LyrNameRel2
        {
            get { return rCtrlRelation2.LyrNameRel; }
            set 
            {
                if (value.Contains(null))
                    value.Remove(null);
                rCtrlRelation2.LyrNameRel = value;
            }
        }

        private string lyrNameRel2_selected;

        public string LyrNameRel2_selected
        {
            get { return rCtrlRelation2.LyrNameRel_selected; }
            set { rCtrlRelation2.LyrNameRel_selected = value; }
        }

        private List<string> objectClassName2;

        public List<string> ObjectClassName2
        {
            get { return rCtrlRelation2.ObjectClassName; }
            set { rCtrlRelation2.ObjectClassName = value; }
        }

        private string objectClassName2_selected;

        public string ObjectClassName2_selected
        {
            get { return rCtrlRelation2.ObjectClassName_selected; }
            set { rCtrlRelation2.ObjectClassName_selected = value; }
        }


        private List<string> relationType2;

        public List<string> RelationType2
        {
            get { return rCtrlRelation2.RelationType; }
            set { rCtrlRelation2.RelationType = value; }
        }

        private string relationType2_selected;

        public string RelationType2_selected
        {
            get { return rCtrlRelation2.RelationType_selected; }
            set { rCtrlRelation2.RelationType_selected = value; }
        }


        private string dataSourceRel2;

        public string DataSourceRel2
        {
            get { return rCtrlRelation2.DataSourceRel; }
            set { rCtrlRelation2.DataSourceRel = value; }
        }

        private List<string> objectClassRelField2;

        public List<string> ObjectClassRelField2
        {
            get { return rCtrlRelation2.ObjectClassRelField; }
            set { rCtrlRelation2.ObjectClassRelField = value; }
        }

        private string objectClassRelField2_selected;

        public string ObjectClassRelField2_selected
        {
            get { return rCtrlRelation2.ObjectClassRelField_selected; }
            set { rCtrlRelation2.ObjectClassRelField_selected = value; }
        }

        private string mainObjectClass_relField2_selected;

        public string MainObjectClass_relField2_selected
        {
            get { return rCtrlRelation2.MainObjectClass_relField_selected; }
            set { rCtrlRelation2.MainObjectClass_relField_selected = value; }
        }

        private List<string> mainObjectClass_relField2;

        public List<string> MainObjectClass_relField2
        {
            get { return rCtrlRelation2.MainObjectClass_relField; }
            set { rCtrlRelation2.MainObjectClass_relField = value; }
        }


        private List<string> selectionTypeRel2;

        public List<string> SelectionTypeRel2
        {
            get { return rCtrlRelation2.SelectionTypeRel; }
            set { rCtrlRelation2.SelectionTypeRel = value; }
        }

        private string selectionTypeRel2_selected;

        public string SelectionTypeRel2_selected
        {
            get { return rCtrlRelation2.SelectionTypeRel_selected; }
            set { rCtrlRelation2.SelectionTypeRel_selected = value; }
        }

        private bool includeFeaturesRel2;

        public bool IncludeFeaturesRel2
        {
            get { return rCtrlRelation2.IncludeFeaturesRel; }
            set { rCtrlRelation2.IncludeFeaturesRel = value; }
        }
        

        private List<string> spatialTypeRel2;

        public List<string> SpatialTypeRel2
        {
            get { return rCtrlRelation2.SpatialTypeRel; }
            set { rCtrlRelation2.SpatialTypeRel = value; }
        }

        private string spatialTypeRel2_selected;

        public string SpatialTypeRel2_selected
        {
            get { return rCtrlRelation2.SpatialTypeRel_selected; }
            set { rCtrlRelation2.SpatialTypeRel_selected = value; }
        }

        private double bufferDistanceRel2;

        public double BufferDistanceRel2
        {
            get { return rCtrlRelation2.BufferDistanceRelation; }
            set { rCtrlRelation2.BufferDistanceRelation = value; }
        }
        #endregion

        #region "relTab3"
        private List<string> lyrNameRel3;

        public List<string> LyrNameRel3
        {
            get { return rCtrlRelation3.LyrNameRel; }
            set 
            {
                if (value.Contains(null))
                    value.Remove(null);
                rCtrlRelation3.LyrNameRel = value; 
            }
        }

        private string lyrNameRel3_selected;

        public string LyrNameRel3_selected
        {
            get { return rCtrlRelation3.LyrNameRel_selected; }
            set { rCtrlRelation3.LyrNameRel_selected = value; }
        }

        private List<string> objectClassName3;

        public List<string> ObjectClassName3
        {
            get { return rCtrlRelation3.ObjectClassName; }
            set { rCtrlRelation3.ObjectClassName = value; }
        }

        private string objectClassName3_selected;

        public string ObjectClassName3_selected
        {
            get { return rCtrlRelation3.ObjectClassName_selected; }
            set { rCtrlRelation3.ObjectClassName_selected = value; }
        }


        private List<string> relationType3;

        public List<string> RelationType3
        {
            get { return rCtrlRelation3.RelationType; }
            set { rCtrlRelation3.RelationType = value; }
        }

        private string relationType3_selected;

        public string RelationType3_selected
        {
            get { return rCtrlRelation3.RelationType_selected; }
            set { rCtrlRelation3.RelationType_selected = value; }
        }


        private string dataSourceRel3;

        public string DataSourceRel3
        {
            get { return rCtrlRelation3.DataSourceRel; }
            set { rCtrlRelation3.DataSourceRel = value; }
        }

        private List<string> objectClassRelField3;

        public List<string> ObjectClassRelField3
        {
            get { return rCtrlRelation3.ObjectClassRelField; }
            set { rCtrlRelation3.ObjectClassRelField = value; }
        }

        private string objectClassRelField3_selected;

        public string ObjectClassRelField3_selected
        {
            get { return rCtrlRelation3.ObjectClassRelField_selected; }
            set { rCtrlRelation3.ObjectClassRelField_selected = value; }
        }

        private string mainObjectClass_relField3_selected;

        public string MainObjectClass_relField3_selected
        {
            get { return rCtrlRelation3.MainObjectClass_relField_selected; }
            set { rCtrlRelation3.MainObjectClass_relField_selected = value; }
        }

        private List<string> mainObjectClass_relField3;

        public List<string> MainObjectClass_relField3
        {
            get { return rCtrlRelation3.MainObjectClass_relField; }
            set { rCtrlRelation3.MainObjectClass_relField = value; }
        }


        private List<string> selectionTypeRel3;

        public List<string> SelectionTypeRel3
        {
            get { return rCtrlRelation3.SelectionTypeRel; }
            set { rCtrlRelation3.SelectionTypeRel = value; }
        }

        private string selectionTypeRel3_selected;

        public string SelectionTypeRel3_selected
        {
            get { return rCtrlRelation3.SelectionTypeRel_selected; }
            set { rCtrlRelation3.SelectionTypeRel_selected = value; }
        }

        private bool includeFeaturesRel3;

        public bool IncludeFeaturesRel3
        {
            get { return rCtrlRelation3.IncludeFeaturesRel; }
            set { rCtrlRelation3.IncludeFeaturesRel = value; }
        }


        private List<string> spatialTypeRel3;

        public List<string> SpatialTypeRel3
        {
            get { return rCtrlRelation3.SpatialTypeRel; }
            set { rCtrlRelation3.SpatialTypeRel = value; }
        }

        private string spatialTypeRel3_selected;

        public string SpatialTypeRel3_selected
        {
            get { return rCtrlRelation3.SpatialTypeRel_selected; }
            set { rCtrlRelation3.SpatialTypeRel_selected = value; }
        }

        private double bufferDistanceRel3;

        public double BufferDistanceRel3
        {
            get { return rCtrlRelation3.BufferDistanceRelation; }
            set { rCtrlRelation3.BufferDistanceRelation = value; }
        }
        #endregion

        #region "relTab4"
        private List<string> lyrNameRel4;

        public List<string> LyrNameRel4
        {
            get { return rCtrlRelation4.LyrNameRel; }
            set
            {
                if (value.Contains(null))
                    value.Remove(null); 
                rCtrlRelation4.LyrNameRel = value;
            }
        }

        private string lyrNameRel4_selected;

        public string LyrNameRel4_selected
        {
            get { return rCtrlRelation4.LyrNameRel_selected; }
            set { rCtrlRelation4.LyrNameRel_selected = value; }
        }

        private List<string> objectClassName4;

        public List<string> ObjectClassName4
        {
            get { return rCtrlRelation4.ObjectClassName; }
            set { rCtrlRelation4.ObjectClassName = value; }
        }

        private string objectClassName4_selected;

        public string ObjectClassName4_selected
        {
            get { return rCtrlRelation4.ObjectClassName_selected; }
            set { rCtrlRelation4.ObjectClassName_selected = value; }
        }


        private List<string> relationType4;

        public List<string> RelationType4
        {
            get { return rCtrlRelation4.RelationType; }
            set { rCtrlRelation4.RelationType = value; }
        }

        private string relationType4_selected;

        public string RelationType4_selected
        {
            get { return rCtrlRelation4.RelationType_selected; }
            set { rCtrlRelation4.RelationType_selected = value; }
        }


        private string dataSourceRel4;

        public string DataSourceRel4
        {
            get { return rCtrlRelation4.DataSourceRel; }
            set { rCtrlRelation4.DataSourceRel = value; }
        }

        private List<string> objectClassRelField4;

        public List<string> ObjectClassRelField4
        {
            get { return rCtrlRelation4.ObjectClassRelField; }
            set { rCtrlRelation4.ObjectClassRelField = value; }
        }

        private string objectClassRelField4_selected;

        public string ObjectClassRelField4_selected
        {
            get { return rCtrlRelation4.ObjectClassRelField_selected; }
            set { rCtrlRelation4.ObjectClassRelField_selected = value; }
        }

        private string mainObjectClass_relField4_selected;

        public string MainObjectClass_relField4_selected
        {
            get { return rCtrlRelation4.MainObjectClass_relField_selected; }
            set { rCtrlRelation4.MainObjectClass_relField_selected = value; }
        }

        private List<string> mainObjectClass_relField4;

        public List<string> MainObjectClass_relField4
        {
            get { return rCtrlRelation4.MainObjectClass_relField; }
            set { rCtrlRelation4.MainObjectClass_relField = value; }
        }


        private List<string> selectionTypeRel4;

        public List<string> SelectionTypeRel4
        {
            get { return rCtrlRelation4.SelectionTypeRel; }
            set { rCtrlRelation4.SelectionTypeRel = value; }
        }

        private string selectionTypeRel4_selected;

        public string SelectionTypeRel4_selected
        {
            get { return rCtrlRelation4.SelectionTypeRel_selected; }
            set { rCtrlRelation4.SelectionTypeRel_selected = value; }
        }

        private bool includeFeaturesRel4;

        public bool IncludeFeaturesRel4
        {
            get { return rCtrlRelation4.IncludeFeaturesRel; }
            set { rCtrlRelation4.IncludeFeaturesRel = value; }
        }


        private List<string> spatialTypeRel4;

        public List<string> SpatialTypeRel4
        {
            get { return rCtrlRelation4.SpatialTypeRel; }
            set { rCtrlRelation4.SpatialTypeRel = value; }
        }

        private string spatialTypeRel4_selected;

        public string SpatialTypeRel4_selected
        {
            get { return rCtrlRelation4.SpatialTypeRel_selected; }
            set { rCtrlRelation4.SpatialTypeRel_selected = value; }
        }

        private double bufferDistanceRel4;

        public double BufferDistanceRel4
        {
            get { return rCtrlRelation4.BufferDistanceRelation; }
            set { rCtrlRelation4.BufferDistanceRelation = value; }
        }
        #endregion

        #region relTab5
        private List<string> lyrNameRel5;

        public List<string> LyrNameRel5
        {
            get { return rCtrlRelation5.LyrNameRel; }
            set
            {
                if (value.Contains(null))
                    value.Remove(null); 
                rCtrlRelation5.LyrNameRel = value;
            }
        }

        private string lyrNameRel5_selected;

        public string LyrNameRel5_selected
        {
            get { return rCtrlRelation5.LyrNameRel_selected; }
            set { rCtrlRelation5.LyrNameRel_selected = value; }
        }

        private List<string> objectClassName5;

        public List<string> ObjectClassName5
        {
            get { return rCtrlRelation5.ObjectClassName; }
            set { rCtrlRelation5.ObjectClassName = value; }
        }

        private string objectClassName5_selected;

        public string ObjectClassName5_selected
        {
            get { return rCtrlRelation5.ObjectClassName_selected; }
            set { rCtrlRelation5.ObjectClassName_selected = value; }
        }


        private List<string> relationType5;

        public List<string> RelationType5
        {
            get { return rCtrlRelation5.RelationType; }
            set { rCtrlRelation5.RelationType = value; }
        }

        private string relationType5_selected;

        public string RelationType5_selected
        {
            get { return rCtrlRelation5.RelationType_selected; }
            set { rCtrlRelation5.RelationType_selected = value; }
        }


        private string dataSourceRel5;

        public string DataSourceRel5
        {
            get { return rCtrlRelation5.DataSourceRel; }
            set { rCtrlRelation5.DataSourceRel = value; }
        }

        private List<string> objectClassRelField5;

        public List<string> ObjectClassRelField5
        {
            get { return rCtrlRelation5.ObjectClassRelField; }
            set { rCtrlRelation5.ObjectClassRelField = value; }
        }

        private string objectClassRelField5_selected;

        public string ObjectClassRelField5_selected
        {
            get { return rCtrlRelation5.ObjectClassRelField_selected; }
            set { rCtrlRelation5.ObjectClassRelField_selected = value; }
        }

        private string mainObjectClass_relField5_selected;

        public string MainObjectClass_relField5_selected
        {
            get { return rCtrlRelation5.MainObjectClass_relField_selected; }
            set { rCtrlRelation5.MainObjectClass_relField_selected = value; }
        }

        private List<string> mainObjectClass_relField5;

        public List<string> MainObjectClass_relField5
        {
            get { return rCtrlRelation5.MainObjectClass_relField; }
            set { rCtrlRelation5.MainObjectClass_relField = value; }
        }


        private List<string> selectionTypeRel5;

        public List<string> SelectionTypeRel5
        {
            get { return rCtrlRelation5.SelectionTypeRel; }
            set { rCtrlRelation5.SelectionTypeRel = value; }
        }

        private string selectionTypeRel5_selected;

        public string SelectionTypeRel5_selected
        {
            get { return rCtrlRelation5.SelectionTypeRel_selected; }
            set { rCtrlRelation5.SelectionTypeRel_selected = value; }
        }

        private bool includeFeaturesRel5;

        public bool IncludeFeaturesRel5
        {
            get { return rCtrlRelation5.IncludeFeaturesRel; }
            set { rCtrlRelation5.IncludeFeaturesRel = value; }
        }


        private List<string> spatialTypeRel5;

        public List<string> SpatialTypeRel5
        {
            get { return rCtrlRelation5.SpatialTypeRel; }
            set { rCtrlRelation5.SpatialTypeRel = value; }
        }

        private string spatialTypeRel5_selected;

        public string SpatialTypeRel5_selected
        {
            get { return rCtrlRelation5.SpatialTypeRel_selected; }
            set { rCtrlRelation5.SpatialTypeRel_selected = value; }
        }

        private double bufferDistanceRel5;

        public double BufferDistanceRel5
        {
            get { return rCtrlRelation5.BufferDistanceRelation; }
            set { rCtrlRelation5.BufferDistanceRelation = value; }
        }
        #endregion

        #region relTab6
        private List<string> lyrNameRel6;

        public List<string> LyrNameRel6
        {
            get { return rCtrlRelation6.LyrNameRel; }
            set
            {
                if (value.Contains(null))
                    value.Remove(null);
                rCtrlRelation6.LyrNameRel = value; 
            }
        }

        private string lyrNameRel6_selected;

        public string LyrNameRel6_selected
        {
            get { return rCtrlRelation6.LyrNameRel_selected; }
            set { rCtrlRelation6.LyrNameRel_selected = value; }
        }

        private List<string> objectClassName6;

        public List<string> ObjectClassName6
        {
            get { return rCtrlRelation6.ObjectClassName; }
            set { rCtrlRelation6.ObjectClassName = value; }
        }

        private string objectClassName6_selected;

        public string ObjectClassName6_selected
        {
            get { return rCtrlRelation6.ObjectClassName_selected; }
            set { rCtrlRelation6.ObjectClassName_selected = value; }
        }


        private List<string> relationType6;

        public List<string> RelationType6
        {
            get { return rCtrlRelation6.RelationType; }
            set { rCtrlRelation6.RelationType = value; }
        }

        private string relationType6_selected;

        public string RelationType6_selected
        {
            get { return rCtrlRelation6.RelationType_selected; }
            set { rCtrlRelation6.RelationType_selected = value; }
        }


        private string dataSourceRel6;

        public string DataSourceRel6
        {
            get { return rCtrlRelation6.DataSourceRel; }
            set { rCtrlRelation6.DataSourceRel = value; }
        }

        private List<string> objectClassRelField6;

        public List<string> ObjectClassRelField6
        {
            get { return rCtrlRelation6.ObjectClassRelField; }
            set { rCtrlRelation6.ObjectClassRelField = value; }
        }

        private string objectClassRelField6_selected;

        public string ObjectClassRelField6_selected
        {
            get { return rCtrlRelation6.ObjectClassRelField_selected; }
            set { rCtrlRelation6.ObjectClassRelField_selected = value; }
        }

        private string mainObjectClass_relField6_selected;

        public string MainObjectClass_relField6_selected
        {
            get { return rCtrlRelation6.MainObjectClass_relField_selected; }
            set { rCtrlRelation6.MainObjectClass_relField_selected = value; }
        }

        private List<string> mainObjectClass_relField6;

        public List<string> MainObjectClass_relField6
        {
            get { return rCtrlRelation6.MainObjectClass_relField; }
            set { rCtrlRelation6.MainObjectClass_relField = value; }
        }


        private List<string> selectionTypeRel6;

        public List<string> SelectionTypeRel6
        {
            get { return rCtrlRelation6.SelectionTypeRel; }
            set { rCtrlRelation6.SelectionTypeRel = value; }
        }

        private string selectionTypeRel6_selected;

        public string SelectionTypeRel6_selected
        {
            get { return rCtrlRelation6.SelectionTypeRel_selected; }
            set { rCtrlRelation6.SelectionTypeRel_selected = value; }
        }

        private bool includeFeaturesRel6;

        public bool IncludeFeaturesRel6
        {
            get { return rCtrlRelation6.IncludeFeaturesRel; }
            set { rCtrlRelation6.IncludeFeaturesRel = value; }
        }


        private List<string> spatialTypeRel6;

        public List<string> SpatialTypeRel6
        {
            get { return rCtrlRelation6.SpatialTypeRel; }
            set { rCtrlRelation6.SpatialTypeRel = value; }
        }

        private string spatialTypeRel6_selected;

        public string SpatialTypeRel6_selected
        {
            get { return rCtrlRelation6.SpatialTypeRel_selected; }
            set { rCtrlRelation6.SpatialTypeRel_selected = value; }
        }

        private double bufferDistanceRel6;

        public double BufferDistanceRel6
        {
            get { return rCtrlRelation6.BufferDistanceRelation; }
            set { rCtrlRelation6.BufferDistanceRelation = value; }
        }
        #endregion

        #region relTab7
        private List<string> lyrNameRel7;

        public List<string> LyrNameRel7
        {
            get { return rCtrlRelation7.LyrNameRel; }
            set
            {
                if (value.Contains(null))
                    value.Remove(null);
                rCtrlRelation7.LyrNameRel = value; 
            }
        }

        private string lyrNameRel7_selected;

        public string LyrNameRel7_selected
        {
            get { return rCtrlRelation7.LyrNameRel_selected; }
            set { rCtrlRelation7.LyrNameRel_selected = value; }
        }

        private List<string> objectClassName7;

        public List<string> ObjectClassName7
        {
            get { return rCtrlRelation7.ObjectClassName; }
            set { rCtrlRelation7.ObjectClassName = value; }
        }

        private string objectClassName7_selected;

        public string ObjectClassName7_selected
        {
            get { return rCtrlRelation7.ObjectClassName_selected; }
            set { rCtrlRelation7.ObjectClassName_selected = value; }
        }


        private List<string> relationType7;

        public List<string> RelationType7
        {
            get { return rCtrlRelation7.RelationType; }
            set { rCtrlRelation7.RelationType = value; }
        }

        private string relationType7_selected;

        public string RelationType7_selected
        {
            get { return rCtrlRelation7.RelationType_selected; }
            set { rCtrlRelation7.RelationType_selected = value; }
        }


        private string dataSourceRel7;

        public string DataSourceRel7
        {
            get { return rCtrlRelation7.DataSourceRel; }
            set { rCtrlRelation7.DataSourceRel = value; }
        }

        private List<string> objectClassRelField7;

        public List<string> ObjectClassRelField7
        {
            get { return rCtrlRelation7.ObjectClassRelField; }
            set { rCtrlRelation7.ObjectClassRelField = value; }
        }

        private string objectClassRelField7_selected;

        public string ObjectClassRelField7_selected
        {
            get { return rCtrlRelation7.ObjectClassRelField_selected; }
            set { rCtrlRelation7.ObjectClassRelField_selected = value; }
        }

        private string mainObjectClass_relField7_selected;

        public string MainObjectClass_relField7_selected
        {
            get { return rCtrlRelation7.MainObjectClass_relField_selected; }
            set { rCtrlRelation7.MainObjectClass_relField_selected = value; }
        }

        private List<string> mainObjectClass_relField7;

        public List<string> MainObjectClass_relField7
        {
            get { return rCtrlRelation7.MainObjectClass_relField; }
            set { rCtrlRelation7.MainObjectClass_relField = value; }
        }


        private List<string> selectionTypeRel7;

        public List<string> SelectionTypeRel7
        {
            get { return rCtrlRelation7.SelectionTypeRel; }
            set { rCtrlRelation7.SelectionTypeRel = value; }
        }

        private string selectionTypeRel7_selected;

        public string SelectionTypeRel7_selected
        {
            get { return rCtrlRelation7.SelectionTypeRel_selected; }
            set { rCtrlRelation7.SelectionTypeRel_selected = value; }
        }

        private bool includeFeaturesRel7;

        public bool IncludeFeaturesRel7
        {
            get { return rCtrlRelation7.IncludeFeaturesRel; }
            set { rCtrlRelation7.IncludeFeaturesRel = value; }
        }


        private List<string> spatialTypeRel7;

        public List<string> SpatialTypeRel7
        {
            get { return rCtrlRelation7.SpatialTypeRel; }
            set { rCtrlRelation7.SpatialTypeRel = value; }
        }

        private string spatialTypeRel7_selected;

        public string SpatialTypeRel7_selected
        {
            get { return rCtrlRelation7.SpatialTypeRel_selected; }
            set { rCtrlRelation7.SpatialTypeRel_selected = value; }
        }

        private double bufferDistanceRel7;

        public double BufferDistanceRel7
        {
            get { return rCtrlRelation7.BufferDistanceRelation; }
            set { rCtrlRelation7.BufferDistanceRelation = value; }
        }
        #endregion

        #region relTab8
        private List<string> lyrNameRel8;

        public List<string> LyrNameRel8
        {
            get { return rCtrlRelation8.LyrNameRel; }
            set
            {
                if (value.Contains(null))
                    value.Remove(null);
                rCtrlRelation8.LyrNameRel = value; 
            }
        }

        private string lyrNameRel8_selected;

        public string LyrNameRel8_selected
        {
            get { return rCtrlRelation8.LyrNameRel_selected; }
            set { rCtrlRelation8.LyrNameRel_selected = value; }
        }

        private List<string> objectClassName8;

        public List<string> ObjectClassName8
        {
            get { return rCtrlRelation8.ObjectClassName; }
            set { rCtrlRelation8.ObjectClassName = value; }
        }

        private string objectClassName8_selected;

        public string ObjectClassName8_selected
        {
            get { return rCtrlRelation8.ObjectClassName_selected; }
            set { rCtrlRelation8.ObjectClassName_selected = value; }
        }


        private List<string> relationType8;

        public List<string> RelationType8
        {
            get { return rCtrlRelation8.RelationType; }
            set { rCtrlRelation8.RelationType = value; }
        }

        private string relationType8_selected;

        public string RelationType8_selected
        {
            get { return rCtrlRelation8.RelationType_selected; }
            set { rCtrlRelation8.RelationType_selected = value; }
        }


        private string dataSourceRel8;

        public string DataSourceRel8
        {
            get { return rCtrlRelation8.DataSourceRel; }
            set { rCtrlRelation8.DataSourceRel = value; }
        }

        private List<string> objectClassRelField8;

        public List<string> ObjectClassRelField8
        {
            get { return rCtrlRelation8.ObjectClassRelField; }
            set { rCtrlRelation8.ObjectClassRelField = value; }
        }

        private string objectClassRelField8_selected;

        public string ObjectClassRelField8_selected
        {
            get { return rCtrlRelation8.ObjectClassRelField_selected; }
            set { rCtrlRelation8.ObjectClassRelField_selected = value; }
        }

        private string mainObjectClass_relField8_selected;

        public string MainObjectClass_relField8_selected
        {
            get { return rCtrlRelation8.MainObjectClass_relField_selected; }
            set { rCtrlRelation8.MainObjectClass_relField_selected = value; }
        }

        private List<string> mainObjectClass_relField8;

        public List<string> MainObjectClass_relField8
        {
            get { return rCtrlRelation8.MainObjectClass_relField; }
            set { rCtrlRelation8.MainObjectClass_relField = value; }
        }


        private List<string> selectionTypeRel8;

        public List<string> SelectionTypeRel8
        {
            get { return rCtrlRelation8.SelectionTypeRel; }
            set { rCtrlRelation8.SelectionTypeRel = value; }
        }

        private string selectionTypeRel8_selected;

        public string SelectionTypeRel8_selected
        {
            get { return rCtrlRelation8.SelectionTypeRel_selected; }
            set { rCtrlRelation8.SelectionTypeRel_selected = value; }
        }

        private bool includeFeaturesRel8;

        public bool IncludeFeaturesRel8
        {
            get { return rCtrlRelation8.IncludeFeaturesRel; }
            set { rCtrlRelation8.IncludeFeaturesRel = value; }
        }


        private List<string> spatialTypeRel8;

        public List<string> SpatialTypeRel8
        {
            get { return rCtrlRelation8.SpatialTypeRel; }
            set { rCtrlRelation8.SpatialTypeRel = value; }
        }

        private string spatialTypeRel8_selected;

        public string SpatialTypeRel8_selected
        {
            get { return rCtrlRelation8.SpatialTypeRel_selected; }
            set { rCtrlRelation8.SpatialTypeRel_selected = value; }
        }

        private double bufferDistanceRel8;

        public double BufferDistanceRel8
        {
            get { return rCtrlRelation8.BufferDistanceRelation; }
            set { rCtrlRelation8.BufferDistanceRelation = value; }
        }
        #endregion

        #endregion

        private string brukernavn;

        public string Brukernavn
        {
            get { return lblBrukernavn.Text; }
            set { lblBrukernavn.Text = value;}
        }

        public DesignDialogView()
        {
            InitializeComponent();

            btnCopyModel.Text = Properties.Resources.KopierModell;
            rCtrlRelation1.SpatialTypeRel_visible = true;
            rCtrlRelation1.BufferDistanceRel_visible = true;
            rCtrlRelation1.antallRelaterte_CheckedChanged += new EventHandler(rCtrlRelation_chxAntallRelaterte_CheckedChanged);
            rCtrlRelation1.lyrName_Changed += new EventHandler(rCtrlRelation_lyrName_SelectedValueChanged);
            rCtrlRelation1.relationType_Changed+=new EventHandler(rCtrlRelation_relationType_Changed);
            rCtrlRelation1.saveQuery_Clicked+=new EventHandler(rCtrlRelation_saveQuery_Clicked);
            rCtrlRelation1.editQuery_Clicked += new EventHandler(rCtrlRelation_editQuery_Clicked);
            rCtrlRelation1.deleteQuery_Clicked += new EventHandler(rCtrlRelation_deleteQuery_Clicked);

            rCtrlRelation2.SpatialTypeRel_visible = true;
            rCtrlRelation2.BufferDistanceRel_visible = true;
            rCtrlRelation2.antallRelaterte_CheckedChanged += new EventHandler(rCtrlRelation_chxAntallRelaterte_CheckedChanged);
            rCtrlRelation2.lyrName_Changed += new EventHandler(rCtrlRelation_lyrName_SelectedValueChanged);
            rCtrlRelation2.relationType_Changed += new EventHandler(rCtrlRelation_relationType_Changed);
            rCtrlRelation2.saveQuery_Clicked += new EventHandler(rCtrlRelation_saveQuery_Clicked);
            rCtrlRelation2.editQuery_Clicked += new EventHandler(rCtrlRelation_editQuery_Clicked);
            rCtrlRelation2.deleteQuery_Clicked += new EventHandler(rCtrlRelation_deleteQuery_Clicked);

            rCtrlRelation3.antallRelaterte_CheckedChanged += new EventHandler(rCtrlRelation_chxAntallRelaterte_CheckedChanged);
            rCtrlRelation3.lyrName_Changed += new EventHandler(rCtrlRelation_lyrName_SelectedValueChanged);
            rCtrlRelation3.relationType_Changed += new EventHandler(rCtrlRelation_relationType_Changed);
            rCtrlRelation3.saveQuery_Clicked += new EventHandler(rCtrlRelation_saveQuery_Clicked);
            rCtrlRelation3.editQuery_Clicked += new EventHandler(rCtrlRelation_editQuery_Clicked);
            rCtrlRelation3.deleteQuery_Clicked += new EventHandler(rCtrlRelation_deleteQuery_Clicked);

            rCtrlRelation4.antallRelaterte_CheckedChanged += new EventHandler(rCtrlRelation_chxAntallRelaterte_CheckedChanged);
            rCtrlRelation4.lyrName_Changed += new EventHandler(rCtrlRelation_lyrName_SelectedValueChanged);
            rCtrlRelation4.relationType_Changed += new EventHandler(rCtrlRelation_relationType_Changed);
            rCtrlRelation4.saveQuery_Clicked += new EventHandler(rCtrlRelation_saveQuery_Clicked);
            rCtrlRelation4.editQuery_Clicked += new EventHandler(rCtrlRelation_editQuery_Clicked);
            rCtrlRelation4.deleteQuery_Clicked += new EventHandler(rCtrlRelation_deleteQuery_Clicked);

            rCtrlRelation5.antallRelaterte_CheckedChanged += new EventHandler(rCtrlRelation_chxAntallRelaterte_CheckedChanged);
            rCtrlRelation5.lyrName_Changed += new EventHandler(rCtrlRelation_lyrName_SelectedValueChanged);
            rCtrlRelation5.relationType_Changed += new EventHandler(rCtrlRelation_relationType_Changed);
            rCtrlRelation5.saveQuery_Clicked += new EventHandler(rCtrlRelation_saveQuery_Clicked);
            rCtrlRelation5.editQuery_Clicked += new EventHandler(rCtrlRelation_editQuery_Clicked);
            rCtrlRelation5.deleteQuery_Clicked += new EventHandler(rCtrlRelation_deleteQuery_Clicked);

            rCtrlRelation6.antallRelaterte_CheckedChanged += new EventHandler(rCtrlRelation_chxAntallRelaterte_CheckedChanged);
            rCtrlRelation6.lyrName_Changed += new EventHandler(rCtrlRelation_lyrName_SelectedValueChanged);
            rCtrlRelation6.relationType_Changed += new EventHandler(rCtrlRelation_relationType_Changed);
            rCtrlRelation6.saveQuery_Clicked += new EventHandler(rCtrlRelation_saveQuery_Clicked);
            rCtrlRelation6.editQuery_Clicked += new EventHandler(rCtrlRelation_editQuery_Clicked);
            rCtrlRelation6.deleteQuery_Clicked += new EventHandler(rCtrlRelation_deleteQuery_Clicked);

            rCtrlRelation7.antallRelaterte_CheckedChanged += new EventHandler(rCtrlRelation_chxAntallRelaterte_CheckedChanged);
            rCtrlRelation7.lyrName_Changed += new EventHandler(rCtrlRelation_lyrName_SelectedValueChanged);
            rCtrlRelation7.relationType_Changed += new EventHandler(rCtrlRelation_relationType_Changed);
            rCtrlRelation7.saveQuery_Clicked += new EventHandler(rCtrlRelation_saveQuery_Clicked);
            rCtrlRelation7.editQuery_Clicked += new EventHandler(rCtrlRelation_editQuery_Clicked);
            rCtrlRelation7.deleteQuery_Clicked += new EventHandler(rCtrlRelation_deleteQuery_Clicked);

            rCtrlRelation8.antallRelaterte_CheckedChanged += new EventHandler(rCtrlRelation_chxAntallRelaterte_CheckedChanged);
            rCtrlRelation8.lyrName_Changed += new EventHandler(rCtrlRelation_lyrName_SelectedValueChanged);
            rCtrlRelation8.relationType_Changed += new EventHandler(rCtrlRelation_relationType_Changed);
            rCtrlRelation8.saveQuery_Clicked += new EventHandler(rCtrlRelation_saveQuery_Clicked);
            rCtrlRelation8.editQuery_Clicked += new EventHandler(rCtrlRelation_editQuery_Clicked);
            rCtrlRelation8.deleteQuery_Clicked += new EventHandler(rCtrlRelation_deleteQuery_Clicked);

        }

        public void SetController(DesignDialogControl control)
        {
            _controller = control;
        }


        public DesignDialogView(AnalyseModul_LogOn logon, VAAnalyseModul analyseModul)
        {
            int x = Bounds.Height / 2 - this.Height / 2;
            int y = Bounds.Width / 2 - this.Width / 2;
            this.Location = new Point(x, y);
            //createBindings();
            InitializeComponent();
            this.paalogging = logon;
            this.analyseModul = analyseModul;
        }


        private void txtCreatedDate_TextChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Tømmer innholder i listen som inneholder modellene.
        /// </summary>
        public void clearList()
        {
            lstModelList.Items.Clear();
        }

        public void updateList()
        {

        }

        /// <summary>
        /// Mottar en event om at knappen for ny modell ble trykket, og videresender
        /// til controll.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreateNewModel_Click(object sender, EventArgs e)
        {
            try
            {
                _controller.createNewModel();
            }
            catch (Exception ex)
            {
                visFeilmelding(ex.Message);
            }
        }

        /// <summary>
        /// Mottar en event om at knappen for kjør modell ble trykket, og videresender
        /// til controll.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRunModel_Click(object sender, EventArgs e)
        {
            // Kjør analysemodell
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                _controller.runModel();
                

            }
            catch (Exception ex)
            {
                visFeilmelding(ex.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        /// <summary>
        /// Mottar en event om at knappen for redigering av spørring ble trykket, og videresender
        /// til controll.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEditQuery_Click(object sender, EventArgs e)
        {
            try
            {
                string tabName = tbcRelations.SelectedTab.Name;
                _controller.editQuery(tabName);
            }
            catch (Exception ex)
            {
                visFeilmelding(ex.Message);
            }
        }

        /// <summary>
        /// Mottar en event om at knappen for lagring av endringer i modellen ble trykket, og videresender
        /// til controll.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSaveEdits_Click(object sender, EventArgs e)
        {
            // Lagre endrede opplysninger for analysemodell
            try
            {
                _controller.saveEdits();
            }
            catch (Exception ex)
            {
                visFeilmelding(ex.Message);
            }
        }

        /// <summary>
        /// Mottar en event om at knappen for sletting av modell ble trykket, og videresender
        /// til controll.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeleteModel_Click(object sender, EventArgs e)
        {
            // Slett analysemodell
            try
            {
                _controller.deleteModel();
            }
            catch (Exception ex)
            {
                visFeilmelding(ex.Message);
            }
        }

        /// <summary>
        /// Mottar en event om at knappen for redigering av modellinformasjon ble trykket, og videresender
        /// til controll.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEditInfo_Click(object sender, EventArgs e)
        {
            try
            {
                _controller.editInfo();
            }
            catch (Exception ex)
            {

                visFeilmelding(ex.Message);
            }
        }

        /// <summary>
        /// Mottar en event om at knappen for åpning av modelldokumentasjon ble trykket, og videresender
        /// til controll.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOpenDoc_Click(object sender, EventArgs e)
        {
            try
            {
                // Åpne dokument-fil som er er tilknyttet modellen
                _controller.openDoc();
            }
            catch (Exception ex)
            {
                visFeilmelding(ex.Message);
            }
        }

        /// <summary>
        /// Mottar en event om at knappen for søk etter modellnavn eller eier ble trykket, og videresender
        /// til controll.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            // Søk på modelnavn eller modeleier
            try
            {
                _controller.search();
            }
            catch (Exception ex)
            {
                visFeilmelding(ex.Message);
            }
        }

        /// <summary>
        /// Mottar en event om at knappen for at brukeren skal legge inn relasjoner ble trykket, og videresender
        /// til controll.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddRelations_Click(object sender, EventArgs e)
        {
            try
            {
                _controller.addRelations();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Det skjedde ett eller annet feil under forsøk på å opprette relasjon: \n" + ex.Message,
                        "Feil rettigheter",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Mottar en event om at knappen for å redigere innstillingene for analysemodulen ble trykket, og videresender
        /// til controll.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOptions_Click(object sender, EventArgs e)
        {
            try
            {
                _controller.modelOptions();
            }
            catch (Exception ex)
            {
                visFeilmelding(ex.Message);
            }
            // Åpne vindu med alternativer
            OptionsView options = new OptionsView();
            options.ShowDialog();
        }

        /// <summary>
        /// Mottar en event om at knappen for endring av pålogget bruker ble trykket, og videresender
        /// til controll.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnChangeUser_Click(object sender, EventArgs e)
        {
            try
            {
                _controller.changeUser();
            }
            catch (Exception ex)
            {
                visFeilmelding(ex.Message);
            }
        }

        /// <summary>
        /// Laster vinduet VaAnalyseModulForm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void VaAnalyseModulForm_Load(object sender, EventArgs e)
        {
            try
            {
                loggInn();
                _controller.load();
                
            }
            catch (Exception ex)
            {
                visFeilmelding(ex.Message);
                Application.Exit();
            }
        }

        /// <summary>
        /// Starter prosedyren med å logge brukeren inn på systemet. Hvis ikke brukernavnet blir 
        /// akseptert, vil bruker få spørsmål om den vil forsøke igjen.
        /// </summary>
        private void loggInn()
        {
            if (!_controller.loggInn())
                {
                    DialogResult resultat = MessageBox.Show("Brukeren finnes ikke. Prøv på nytt.", 
                        "Feil bruker", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

                    if (resultat == DialogResult.Yes)
                        loggInn();
                    else
                        Environment.Exit(0);
                }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chxModelOwner_SelectedValueChanged(object sender, EventArgs e)
        {
            modelOwner = ((ComboBox)sender).SelectedItem.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtModelId_TextChanged(object sender, EventArgs e)
        {
            ModelId = ((TextBox)sender).Text;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="page"></param>
        /// <param name="enable"></param>
        public void EnableTab(TabPage page, bool enable)
        {
            EnableControls(page.Controls, enable);
        }

        public void allTabs(bool enable)
        {
            EnableTab(tabPageRel1, enable);
            EnableTab(tabPageRel2, enable);
            EnableTab(tabPageRel3, enable);
            EnableTab(tabPageRel4, enable);
            EnableTab(tabPageRel5, enable);
            EnableTab(tabPageRel6, enable);
            EnableTab(tabPageRel7, enable);
            EnableTab(tabPageRel8, enable);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ctrColl"></param>
        /// <param name="enable"></param>
        public void EnableControls(Control.ControlCollection ctrColl, bool enable)
        {
            foreach (Control ctrl in ctrColl)
            {
                if(ctrl.Name.Equals("txtAntallRelasjoner") == false){
                    ctrl.Enabled = enable;
                    EnableControls(ctrl.Controls, enable);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deleteQueryRelation_Click(object sender, EventArgs e)
        {
            //
            try
            {
                _controller.deleteQueryRelation(tbcRelations.SelectedTab.Name);
            }
            catch (Exception ex)
            {
                visFeilmelding(ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveRelation_Click(object sender, EventArgs e)
        {
            try
            {
                _controller.saveRelation(tbcRelations.SelectedTab.Name);
            }
            catch (Exception ex)
            {
                visFeilmelding(ex.Message);
            }
        }

        private void finnOpenForms()
        {
            FormCollection formCollection = Application.OpenForms;

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ex"></param>
        private void visFeilmelding(string ex)
        {
            MessageBox.Show(ex, "Det skjedde noe feil!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstModelList_Click(object sender, EventArgs e)
        {
            try
            {
                _controller.modelList_click();
            }
            catch (Exception ex)
            {
                visFeilmelding(ex.Message);
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbcRelations_TabIndexChanged(object sender, EventArgs e)
        {
            try
            {
                _controller.tabChanged();
            }
            catch (Exception ex)
            {
                visFeilmelding(ex.Message);
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        public void clearModelList()
        {
            lstModelList.Items.Clear();
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chxLayerName_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                _controller.layerName_SelectionChanged();
            }
            catch (Exception ex)
            {
                visFeilmelding(ex.Message);
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rCtrlRelation_lyrName_Changed(object sender, EventArgs e)
        {
            try
            {
                _controller.relLayerName_Changed(tbcRelations.SelectedTab.Name);
            }
            catch (Exception ex)
            {
                visFeilmelding(ex.Message);
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rCtrlRelation_lyrName_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                _controller.relationLayerName_SelectionChanged(tbcRelations.SelectedTab.Name);
            }
            catch (Exception ex)
            {
                visFeilmelding(ex.Message);
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rCtrlRelation_RelField_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                _controller.relObjectClass_relField_changed(tbcRelations.SelectedTab.Name);
            }
            catch (Exception ex)
            {
                visFeilmelding(ex.Message);
            }
        }
        /// <summary>
        /// Setter kontroller til aktiv eller inaktiv basert på spørringn.
        /// </summary>
        /// <param name="enable"></param>
        public void relationTypeVisibility()
        {
            try
            {
                foreach (TabPage page in tbcRelations.TabPages)
                {
                    if (page.Name != "tabPageAnalyse")
                    {
                        foreach (Control c in page.Controls)
                        {
                            if (c is RelationControl)
                            {
                                ((RelationControl)c).settRelationTypeEnable();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                visFeilmelding(ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void rCtrlRelation_relationType_Changed(object sender, System.EventArgs e)
        {
            _controller.relTypeChange(tbcRelations.SelectedTab.Name);
        }


        /// <summary>
        /// Videreformidler kallet på editering av en relasjonsquery til kontroll-klassene til designdialog.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void rCtrlRelation_editQuery_Clicked(object sender, System.EventArgs e)
        {
            try
            {
                _controller.editQuery(tbcRelations.SelectedTab.Name);
            }
            catch (Exception ex)
            {
                visFeilmelding(ex.Message);
            }
        }

        /// <summary>
        /// Tar imot en event fra relationControl om lagring av spørring.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void rCtrlRelation_saveQuery_Clicked(object sender, System.EventArgs e)
        {
            try
            {
                _controller.saveRelation(tbcRelations.SelectedTab.Name);
            }
            catch (Exception ex)
            {
                visFeilmelding(ex.Message);
            }
        }

        /// <summary>
        /// Tar imot en event fra relationControl om sletting av spørring
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void rCtrlRelation_deleteQuery_Clicked(object sender, System.EventArgs e)
        {
            try
            {
                _controller.deleteQueryRelation(tbcRelations.SelectedTab.Name);
            }
            catch (Exception ex)
            {
                
                visFeilmelding(ex.Message);
            }
        }


        /// <summary>
        /// Nullstiller hver av kontrollene i hver fane.
        /// </summary>
        public void resetPages()
        {
            try
            {
                foreach (TabPage page in tbcRelations.TabPages)
                {
                    if (page.Name.Equals("tabPageAnalyse") == false)
                    {
                        foreach (Control c in page.Controls)
                        {
                            if (c is RelationControl)
                            {
                                ((RelationControl)c).resetPages();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                visFeilmelding(ex.Message);
            }
        }

        /// <summary>
        /// Kjører gjennom alle fanene for å sette kontrollene til inaktive, slik de opprinnelig er.
        /// </summary>
        public void setDefault()
        {
            try
            {
                foreach (TabPage page in tbcRelations.TabPages)
                {
                    if (page.Name.Equals("tabPageAnalyse") == false)
                    {
                        foreach (Control c in page.Controls)
                        {
                            if (c is RelationControl)
                            {
                                ((RelationControl)c).setDefault();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                visFeilmelding(ex.Message);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            _controller.clearAll();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnCopyModel_Click(object sender, EventArgs e)
        {
            try
            {
                string nyModelID = null;

                VA_Analysemodul.Views.ModelIDCopy modelCopyVindu = new Views.ModelIDCopy();
                if (modelCopyVindu.ShowDialog(this) == DialogResult.OK)
                {
                    nyModelID = modelCopyVindu.NyModelID;
                    modelCopyVindu.Dispose();
                }
                _controller.copyModel(nyModelID);
            }
            catch(Exception ex)
            {
                visFeilmelding(ex.Message);
            }
        }

        public void rCtrlRelation_chxAntallRelaterte_CheckedChanged (object sender, EventArgs e)
        {
            rCtrlRelation1.AntallRelaterte_enable = true;
            rCtrlRelation2.AntallRelaterte_enable = true;
            rCtrlRelation3.AntallRelaterte_enable = true;
            rCtrlRelation4.AntallRelaterte_enable = true;
            rCtrlRelation5.AntallRelaterte_enable = true;
            rCtrlRelation6.AntallRelaterte_enable = true;
            rCtrlRelation7.AntallRelaterte_enable = true;
            rCtrlRelation8.AntallRelaterte_enable = true;
        }
    }
}
