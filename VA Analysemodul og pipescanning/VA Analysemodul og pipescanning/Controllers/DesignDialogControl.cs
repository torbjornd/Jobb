using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VA_Analysemodul
{
    public class DesignDialogControl
    {
        public DesignDialogView _view;
        public AnalyseModul_LogOn _paalogging;
        public VAAnalyseModul _analyse;
        public EditFieldQueryView _editFieldQueryView;
        public ModelInfoView _modelInfoView;
        public OptionsView _optionsView;
        public LoginFormView _loginView;

        private List<Modell> modellene = new List<Modell>();

        public DesignDialogControl()
        {
        }

        public DesignDialogControl(DesignDialogView view, AnalyseModul_LogOn login, VAAnalyseModul analyse, 
            EditFieldQueryView editFieldView, ModelInfoView modelInfoView)
        {
            _view = view;
            _paalogging = login;
            _analyse = analyse;
            _editFieldQueryView = editFieldView;
            _modelInfoView = modelInfoView;
            _view.SetController(this);
        }

        /// <summary>
        /// Mottar ønske om et søk etter modellnavn eller modelleier, og sender det videre til VAAnalyseModul,
        /// oppdaterer deretter listen med modeller.
        /// </summary>
        public void search()
        {
            try
            {
                modellene =_analyse.modelNameSearch(_view.ModelNameList_selected, _view.ModelOwnerList_selected);
                _view.clearModelList();
                modelList_update();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        /// <summary>
        /// Logger inn ved oppstart av applikasjonen.
        /// </summary>
        /// <returns>Sann dersom brukeren er logget inn, usann hvis ikke</returns>
        public bool loggInn()
        {
            try
            {
                string brukernavn = null;
                AnalyseModul_LogOn logon = new AnalyseModul_LogOn();
                _paalogging = logon;
                logon.AnalyseModul = _analyse;

                _loginView = new LoginFormView();
                if (_loginView.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    brukernavn = _loginView.Brukernavn;
                }
                else
                {
                    throw new Exception("");
                }

                if (logon.VerifiserBrukernavn(brukernavn))
                {
                    _view.Brukernavn = brukernavn;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Oppdaterer listeboksen som viser informasjon om modellene, ut fra listen som inneholder
        /// modeller.
        /// </summary>
        private void modelList_update()
        {
            foreach (Modell modellen in modellene)
            {
                System.Windows.Forms.ListViewItem item = new System.Windows.Forms.ListViewItem(modellen.ModelID);
                item.SubItems.Add(modellen.ModelName);
                item.SubItems.Add(modellen.ModelOwner);
                item.SubItems.Add(modellen.RegDate.ToString());
                item.SubItems.Add(modellen.ChDate.ToString());
                item.SubItems.Add(modellen.LastRunDate.ToString());
                item.SubItems.Add(modellen.FirstRunDate.ToString());
                item.SubItems.Add(modellen.MxdName);
                item.SubItems.Add(modellen.MxdPath);
                item.SubItems.Add(modellen.Resultlyr);
                item.SubItems.Add(modellen.Mainlyr);
                item.SubItems.Add(modellen.Layername);
                item.SubItems.Add(modellen.MainFclDescr);
                item.SubItems.Add(modellen.ModelDescr);
                item.Tag = modellen;

                _view.ModelList = item;
            }
        }

        /// <summary>
        /// Fyller ut kombinasjonsbokser- og avkrysningsbokser for relasjonstyper og sammensatt søk
        /// </summary>
        public void load()
        {
            try
            {
                List<string> listen = new List<string>();

                // Henter data til listeview "modelList"
                List<Modell> modelListen = _analyse.modelList_update(listen, null, null);
                modellene = modelListen;
                modelList_update();

                // Listealternativer for kombinasjonsboks "mainLyrName"
                listen = _analyse.TOCFeatureLayerListToComboBox(listen, _view.MainLyrName);
                _view.MainLyrName_ItemsList = listen;

                _view.ModelOwner = _view.UserName;

                List<string> selectionTypes = new List<string>();
                selectionTypes.Add("AND: Selection criteria in origin objectclass and in related table");
                selectionTypes.Add("OR: Selection criteria in origin objectclass or in related table");

                List<string> relationTypes = new List<string>();
                relationTypes.Add("Attributt/felt");
                relationTypes.Add("Romlig");

                List<string> spatialTypes = new List<string>();
                spatialTypes.Add("Intersects");
                spatialTypes.Add("Are within a distance of");

                //Fyller ut kombinasjonsbokser- og avkrysningsbokser for relasjonstyper og sammensatt søk
                // RelTab1
                _view.SelectionTypeRel1 = selectionTypes;
                _view.IncludeFeaturesRel1 = false;
                _view.RelationType1 = relationTypes;
                _view.SpatialTypeRel1 = spatialTypes;
                _view.BufferDistanceRel1 = 10;

                // RelTab2
                _view.SelectionTypeRel2 = selectionTypes;
                _view.IncludeFeaturesRel2 = false;
                _view.RelationType2 = relationTypes;
                _view.SpatialTypeRel2 = spatialTypes;
                _view.BufferDistanceRel2 = 10;

                // RelTab3
                _view.SelectionTypeRel3 = selectionTypes;
                _view.IncludeFeaturesRel3 = false;
                _view.RelationType3 = relationTypes;
                _view.SpatialTypeRel3 = spatialTypes;
                _view.BufferDistanceRel3 = 10;

                // RelTab4
                _view.SelectionTypeRel4 = selectionTypes;
                _view.IncludeFeaturesRel4 = false;
                _view.RelationType4 = relationTypes;
                _view.SpatialTypeRel4 = spatialTypes;
                _view.BufferDistanceRel4 = 10;

                // RelTab5
                _view.SelectionTypeRel5 = selectionTypes;
                _view.IncludeFeaturesRel5 = false;
                _view.RelationType5 = relationTypes;
                _view.SpatialTypeRel5 = spatialTypes;
                _view.BufferDistanceRel5 = 10;

                // RelTab6
                _view.SelectionTypeRel6 = selectionTypes;
                _view.IncludeFeaturesRel6 = false;
                _view.RelationType6 = relationTypes;
                _view.SpatialTypeRel6 = spatialTypes;
                _view.BufferDistanceRel6 = 10;

                // RelTab7
                _view.SelectionTypeRel7 = selectionTypes;
                _view.IncludeFeaturesRel7 = false;
                _view.RelationType7 = relationTypes;
                _view.SpatialTypeRel7 = spatialTypes;
                _view.BufferDistanceRel7 = 10;

                // RelTab8
                _view.SelectionTypeRel8 = selectionTypes;
                _view.IncludeFeaturesRel8 = false;
                _view.RelationType8 = relationTypes;
                _view.SpatialTypeRel8 = spatialTypes;
                _view.BufferDistanceRel8 = 10;
                
                // Setter kombinasjonsboksene til en defaultverdi.
                _view.setDefault();
                
                _view.ModelNameList = _analyse.modelNameList();
                _view.ModelOwnerList = _analyse.modelOwnerList();

                _view.allTabs(false);
                
            }
            catch (Exception ex)
            {
                _analyse.WriteErrorLog("VAanalyseModul_DesignDialog", "UserForm_Initialize", ex.Message);
                throw ex;
            }

        }
        /// <summary>
        /// Mottar informasjon om at feltet relationLayerName er endret, og oppdaterer derfor
        /// informasjonen som står i objectclassname og datasource for den aktuelle fanen.
        /// </summary>
        public void relationLayerName_SelectionChanged(string pageName)
        {
            try
            {
                switch (pageName)
                {
                    case "tabPageRel1":
                        _view.ObjectClassName1_selected = _analyse.ObjectClassNameForLayer(_view.LyrNameRel1_selected);
                        _view.DataSourceRel1 = _analyse.workspacePathNameForLayer(_view.LyrNameRel1_selected);

                        if (_analyse.objectClassCategoryEvaluation(_view.LyrNameRel1_selected))
                        {
                            List<string> liste = new List<string>();
                            _view.ObjectClassRelField1 = _analyse.LayerTableFieldListToComboBox(_view.LyrNameRel1_selected, liste);
                            List<string> koblingsFelt = _analyse.getOriginAndDestinationFields(_view.MainLyrName, _view.LyrNameRel1_selected);
                            _view.MainObjectClass_relField1_selected = koblingsFelt[0];
                            _view.ObjectClassRelField1_selected = koblingsFelt[1];
                        }
                        break;
                    case "tabPageRel2":
                        _view.ObjectClassName2_selected = _analyse.ObjectClassNameForLayer(_view.LyrNameRel2_selected);
                        _view.DataSourceRel2 = _analyse.workspacePathNameForLayer(_view.LyrNameRel2_selected);

                        if (_analyse.objectClassCategoryEvaluation(_view.LyrNameRel2_selected))
                        {
                            List<string> liste = new List<string>();
                            _view.ObjectClassRelField2 = _analyse.LayerTableFieldListToComboBox(_view.LyrNameRel2_selected, liste);
                            List<string> koblingsFelt = _analyse.getOriginAndDestinationFields(_view.MainLyrName, _view.LyrNameRel2_selected);
                            _view.MainObjectClass_relField2_selected = koblingsFelt[0];
                            _view.ObjectClassRelField2_selected = koblingsFelt[1];
                        }
                        break;
                    case "tabPageRel3":
                        _view.ObjectClassName3_selected = _analyse.ObjectClassNameForLayer(_view.LyrNameRel3_selected);
                        _view.DataSourceRel3 = _analyse.workspacePathNameForLayer(_view.LyrNameRel3_selected);

                        if (_analyse.objectClassCategoryEvaluation(_view.LyrNameRel3_selected))
                        {
                            List<string> liste = new List<string>();
                            _view.ObjectClassRelField3 = _analyse.LayerTableFieldListToComboBox(_view.LyrNameRel3_selected, liste);
                            List<string> koblingsFelt = _analyse.getOriginAndDestinationFields(_view.MainLyrName, _view.LyrNameRel3_selected);
                            _view.MainObjectClass_relField3_selected = koblingsFelt[0];
                            _view.ObjectClassRelField3_selected = koblingsFelt[1];
                        }
                        break;
                    case "tabPageRel4":
                        _view.ObjectClassName4_selected = _analyse.ObjectClassNameForLayer(_view.LyrNameRel4_selected);
                        _view.DataSourceRel4 = _analyse.workspacePathNameForLayer(_view.LyrNameRel4_selected);

                        if (_analyse.objectClassCategoryEvaluation(_view.LyrNameRel4_selected))
                        {
                            List<string> liste = new List<string>();
                            _view.ObjectClassRelField4 = _analyse.LayerTableFieldListToComboBox(_view.LyrNameRel4_selected, liste);
                            List<string> koblingsFelt = _analyse.getOriginAndDestinationFields(_view.MainLyrName, _view.LyrNameRel4_selected);
                            _view.MainObjectClass_relField4_selected = koblingsFelt[0];
                            _view.ObjectClassRelField4_selected = koblingsFelt[1];
                        }
                        break;
                    case "tabPageRel5":
                        _view.ObjectClassName5_selected = _analyse.ObjectClassNameForLayer(_view.LyrNameRel5_selected);
                        _view.DataSourceRel5 = _analyse.workspacePathNameForLayer(_view.LyrNameRel5_selected);

                        if (_analyse.objectClassCategoryEvaluation(_view.LyrNameRel5_selected))
                        {
                            List<string> liste = new List<string>();
                            _view.ObjectClassRelField5 = _analyse.LayerTableFieldListToComboBox(_view.LyrNameRel5_selected, liste);
                            List<string> koblingsFelt = _analyse.getOriginAndDestinationFields(_view.MainLyrName, _view.LyrNameRel5_selected);
                            _view.MainObjectClass_relField5_selected = koblingsFelt[0];
                            _view.ObjectClassRelField5_selected = koblingsFelt[1];
                        }
                        break;
                    case "tabPageRel6":
                        _view.ObjectClassName6_selected = _analyse.ObjectClassNameForLayer(_view.LyrNameRel6_selected);
                        _view.DataSourceRel6 = _analyse.workspacePathNameForLayer(_view.LyrNameRel6_selected);

                        if (_analyse.objectClassCategoryEvaluation(_view.LyrNameRel6_selected))
                        {
                            List<string> liste = new List<string>();
                            _view.ObjectClassRelField6 = _analyse.LayerTableFieldListToComboBox(_view.LyrNameRel6_selected, liste);
                            List<string> koblingsFelt = _analyse.getOriginAndDestinationFields(_view.MainLyrName, _view.LyrNameRel6_selected);
                            _view.MainObjectClass_relField6_selected = koblingsFelt[0];
                            _view.ObjectClassRelField6_selected = koblingsFelt[1];
                        }
                        break;
                    case "tabPageRel7":
                        _view.ObjectClassName7_selected = _analyse.ObjectClassNameForLayer(_view.LyrNameRel7_selected);
                        _view.DataSourceRel7 = _analyse.workspacePathNameForLayer(_view.LyrNameRel7_selected);

                        if (_analyse.objectClassCategoryEvaluation(_view.LyrNameRel7_selected))
                        {
                            List<string> liste = new List<string>();
                            _view.ObjectClassRelField7 = _analyse.LayerTableFieldListToComboBox(_view.LyrNameRel7_selected, liste);
                            List<string> koblingsFelt = _analyse.getOriginAndDestinationFields(_view.MainLyrName, _view.LyrNameRel7_selected);
                            _view.MainObjectClass_relField7_selected = koblingsFelt[0];
                            _view.ObjectClassRelField7_selected = koblingsFelt[1];
                        }
                        break;
                    case "tabPageRel8":
                        _view.ObjectClassName8_selected = _analyse.ObjectClassNameForLayer(_view.LyrNameRel8_selected);
                        _view.DataSourceRel8 = _analyse.workspacePathNameForLayer(_view.LyrNameRel8_selected);

                        if (_analyse.objectClassCategoryEvaluation(_view.LyrNameRel8_selected))
                        {
                            List<string> liste = new List<string>();
                            _view.ObjectClassRelField8 = _analyse.LayerTableFieldListToComboBox(_view.LyrNameRel8_selected, liste);
                            List<string> koblingsFelt = _analyse.getOriginAndDestinationFields(_view.MainLyrName, _view.LyrNameRel8_selected);
                            _view.MainObjectClass_relField8_selected = koblingsFelt[0];
                            _view.ObjectClassRelField8_selected = koblingsFelt[1];
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// Seleksjonen i kombinasjonsboksen for lagnavn er endret, og derfor skal feltnavne i laget
        /// legges i korrekt kombinasjonsboks i relasjonsfanen.
        /// </summary>
        public void layerName_SelectionChanged()
        {
            try
            {
                string layerName = _view.MainLyrName;
                _view.MainObjectClassName1 = _analyse.ObjectClassNameForLayer(layerName);
                _view.MainObjectClassDataSource = _analyse.workspacePathNameForLayer(layerName); ;

                // Hent valgbare felt for feltet "Hved.tab-rel.felt" (Mainobjectclass_relField<n>)
                _view.MainObjectClass_relField1 = 
                    _analyse.LayerTableFieldListToComboBox(layerName, _view.MainObjectClass_relField1);

                _view.MainObjectClass_relField2 = 
                    _analyse.LayerTableFieldListToComboBox(layerName, _view.MainObjectClass_relField2);

                _view.MainObjectClass_relField3 = 
                    _analyse.LayerTableFieldListToComboBox(layerName, _view.MainObjectClass_relField3);

                _view.MainObjectClass_relField4 = 
                    _analyse.LayerTableFieldListToComboBox(layerName, _view.MainObjectClass_relField4);

                _view.MainObjectClass_relField5 = 
                    _analyse.LayerTableFieldListToComboBox(layerName, _view.MainObjectClass_relField5);

                _view.MainObjectClass_relField6 = 
                    _analyse.LayerTableFieldListToComboBox(layerName, _view.MainObjectClass_relField6);

                _view.MainObjectClass_relField7 = 
                    _analyse.LayerTableFieldListToComboBox(layerName, _view.MainObjectClass_relField7);

                _view.MainObjectClass_relField8 = 
                    _analyse.LayerTableFieldListToComboBox(layerName, _view.MainObjectClass_relField8);
            }
            catch (Exception ex)
            {
                _analyse.WriteErrorLog("VAanalyseModul_DesignDialog", "layerName_selectionChanged", ex.Message);
                throw ex;
            }
        }

        /// <summary>
        /// Det blir klikket på en modell i listen modelList, og informasjon om modellen hentes fra 
        /// tabellen og legges inn i ulike tekstbokser.
        /// </summary>
        public void modelList_click()
        {
            try
            {
                Modell modellen = null;
                System.Windows.Forms.ListView.ListViewItemCollection coll = _view.ModelListItems;
                int selectedIndex = _view.ModelListIndex;

                System.Windows.Forms.ListViewItem item = coll[selectedIndex];

                modellen = modellene[selectedIndex];

                if (selectedIndex > -1)
                {
                    editModel(selectedIndex, modellen);
                    // table 1 til 8
                    resetPageForRelatedTable(1);
                    List<Modell> modell = _analyse.readFromTab_AnalysisModelInputTables(modellen.ModelID);

                    foreach (Modell m in modell)
                    {
                        populateRelTabFields(m);
                    }
                }
                else
                {
                    resetPageForRelatedTable(1);
                }
                _paalogging.ModelId = _view.ModelId;
            }
            catch (Exception ex)
            {   
                throw ex;
            }
        }

        /// <summary>
        /// Legger inn informasjon fra modellen i de ulike relasjonsfanene.
        /// </summary>
        /// <param name="tabNo">Nummeret på relasjonsfanen</param>
        public void populateRelTabFields(Modell modellen)
        {

            switch (modellen.RelationTabNo)
            {
                case 1: 
                    _view.LyrNameRel1_selected = modellen.Layername;
                    _view.ObjectClassName1_selected = modellen.ObjectClassName;
                    _view.RelationType1_selected = modellen.RelationType;
                    _view.ObjectClassRelField1_selected = modellen.ObjectClass_relfield;
                    _view.MainObjectClass_relField1_selected= modellen.MainObjectClass_relfield;
                    _view.IncludeFeaturesRel1 = modellen.IncludeFeaturesWithoutRelRecords;
                    _view.SelectionTypeRel1_selected = modellen.RelationSearchType;
                    _view.AntallRelaterte = modellen.AntRelasjoner;
                    _view.SpatialTypeRel1_selected = modellen.SpatialRelationType1;
                    _view.BufferDistanceRel1 = modellen.BufferDistance;
                    break;
                case 2:
                    _view.LyrNameRel2_selected = modellen.Layername;
                    _view.ObjectClassName2_selected = modellen.ObjectClassName;
                    _view.RelationType2_selected = modellen.RelationType;
                    _view.ObjectClassRelField2_selected = modellen.ObjectClass_relfield;
                    _view.MainObjectClass_relField2_selected = modellen.MainObjectClass_relfield;
                    _view.IncludeFeaturesRel2 = modellen.IncludeFeaturesWithoutRelRecords;
                    _view.SelectionTypeRel2_selected = modellen.RelationSearchType;
                    _view.SpatialTypeRel2_selected = modellen.SpatialRelationType1;
                    _view.BufferDistanceRel2 = modellen.BufferDistance;
                    break;
                case 3: 
                    _view.LyrNameRel3_selected = modellen.Layername;
                    _view.ObjectClassName3_selected = modellen.ObjectClassName;
                    _view.RelationType3_selected = modellen.RelationType;
                    _view.ObjectClassRelField3_selected = modellen.ObjectClass_relfield;
                    _view.MainObjectClass_relField3_selected = modellen.MainObjectClass_relfield;
                    _view.IncludeFeaturesRel3 = modellen.IncludeFeaturesWithoutRelRecords;
                    _view.SelectionTypeRel3_selected = modellen.RelationSearchType;
                    _view.SpatialTypeRel3_selected = modellen.SpatialRelationType1;
                    _view.BufferDistanceRel3 = modellen.BufferDistance;
                    break;
                case 4: 
                    _view.LyrNameRel4_selected = modellen.Layername;
                    _view.ObjectClassName4_selected = modellen.ObjectClassName;
                    _view.RelationType4_selected = modellen.RelationType;
                    _view.ObjectClassRelField4_selected = modellen.ObjectClass_relfield;
                    _view.MainObjectClass_relField4_selected = modellen.MainObjectClass_relfield;
                    _view.IncludeFeaturesRel4 = modellen.IncludeFeaturesWithoutRelRecords;
                    _view.SelectionTypeRel4_selected = modellen.RelationSearchType;
                    _view.SpatialTypeRel4_selected = modellen.SpatialRelationType1;
                    _view.BufferDistanceRel4 = modellen.BufferDistance;
                    break;
                case 5: 
                    _view.LyrNameRel5_selected = modellen.Layername;
                    _view.ObjectClassName5_selected = modellen.ObjectClassName;
                    _view.RelationType5_selected = modellen.RelationType;
                    _view.ObjectClassRelField5_selected = modellen.ObjectClass_relfield;
                    _view.MainObjectClass_relField5_selected = modellen.MainObjectClass_relfield;
                    _view.IncludeFeaturesRel5 = modellen.IncludeFeaturesWithoutRelRecords;
                    _view.SelectionTypeRel5_selected = modellen.RelationSearchType;
                    _view.SpatialTypeRel5_selected = modellen.SpatialRelationType1;
                    _view.BufferDistanceRel5 = modellen.BufferDistance;
                    break;
                case 6: 
                    _view.LyrNameRel6_selected = modellen.Layername;
                    _view.ObjectClassName6_selected = modellen.ObjectClassName;
                    _view.RelationType6_selected = modellen.RelationType;
                    _view.ObjectClassRelField6_selected = modellen.ObjectClass_relfield;
                    _view.MainObjectClass_relField6_selected = modellen.MainObjectClass_relfield;
                    _view.IncludeFeaturesRel6 = modellen.IncludeFeaturesWithoutRelRecords;
                    _view.SelectionTypeRel6_selected = modellen.RelationSearchType;
                    _view.SpatialTypeRel6_selected = modellen.SpatialRelationType1;
                    _view.BufferDistanceRel6 = modellen.BufferDistance;
                    break;
                case 7: 
                    _view.LyrNameRel7_selected = modellen.Layername;
                    _view.ObjectClassName7_selected = modellen.ObjectClassName;
                    _view.RelationType7_selected = modellen.RelationType;
                    _view.ObjectClassRelField7_selected = modellen.ObjectClass_relfield;
                    _view.MainObjectClass_relField7_selected = modellen.MainObjectClass_relfield;
                    _view.IncludeFeaturesRel7 = modellen.IncludeFeaturesWithoutRelRecords;
                    _view.SelectionTypeRel7_selected = modellen.RelationSearchType;
                    _view.SpatialTypeRel7_selected = modellen.SpatialRelationType1;
                    _view.BufferDistanceRel7 = modellen.BufferDistance;
                    break;
                case 8: 
                    _view.LyrNameRel8_selected = modellen.Layername;
                    _view.ObjectClassName8_selected = modellen.ObjectClassName;
                    _view.RelationType8_selected = modellen.RelationType;
                    _view.ObjectClassRelField8_selected = modellen.ObjectClass_relfield;
                    _view.MainObjectClass_relField8_selected = modellen.MainObjectClass_relfield;
                    _view.IncludeFeaturesRel8 = modellen.IncludeFeaturesWithoutRelRecords;
                    _view.SelectionTypeRel8_selected= modellen.RelationSearchType;
                    _view.SpatialTypeRel8_selected = modellen.SpatialRelationType1;
                    _view.BufferDistanceRel8 = modellen.BufferDistance;
                    break;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="i"></param>
        public void resetPageForRelatedTable(int i)
        {
            try
            {
                _view.resetPages();
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }
        /// <summary>
        /// Lagrer relasjon
        /// </summary>
        /// <returns></returns>
        public bool saveRelationRel()
        {
            return true;   
        }

        /// <summary>
        /// Brukeren har byttet relasjonsfane. Det gjøres ulike tester på om det er valgt en modell og 
        /// lagene fra TOC legges inn i kombinasjonsboksene i relasjonsfanene.
        /// </summary>
        public void tabChanged()
        {
            try
            {
                string modelID = _view.ModelId;
                int modelIndex = _view.ModelListIndex;
                int oid = int.Parse(_view.OIDModel1);
                string pageName = _view.PageName;
                List<string> listen = new List<string>();

                System.Windows.Forms.FormCollection userForms = System.Windows.Forms.Application.OpenForms;
                foreach (System.Windows.Forms.Form vindu in userForms)
                {
                    if (vindu.Name.Equals("EditFieldQueryView"))
                    {
                        vindu.Close();
                    }
                }

                if (!pageName.Equals("AnalysisInfo"))
                {
                    if (string.IsNullOrEmpty(oid.ToString()))
                    {
                        throw new Exception("Modell er ikke angitt / valgt. Du må velge en analysemodell.");
                    }
                    if (modelIndex == -1)
                    {
                        throw new Exception("Modell er ikke angitt / valgt. Du må velge en analysemodell.");
                    }
                    if (string.IsNullOrEmpty(modelID))
                    {
                        throw new Exception("ModellID er ikke angitt.");
                    }
                }
                switch (pageName)
                {
                    case "tabPageRel1":
                        //listen = _view.LyrNameRel1;
                        relTypeChange(pageName);
                        //_view.LyrNameRel1 = _analyse.TOCFeatureLayerTableListToComboBox(listen, _view.MainLyrName);
                        break;
                    case "tabPageRel2":
                        //listen = _view.LyrNameRel2;
                        relTypeChange(pageName);
                        //_view.LyrNameRel2 = _analyse.TOCFeatureLayerTableListToComboBox(listen, _view.MainLyrName);
                        break;
                    case "tabPageRel3":
                        //listen = _view.LyrNameRel3;
                        relTypeChange(pageName);
                        //_view.LyrNameRel3 = _analyse.TOCFeatureLayerTableListToComboBox(listen, _view.MainLyrName);
                        break;
                    case "tabPageRel4":
                        //listen = _view.LyrNameRel4;
                        relTypeChange(pageName);
                        //_view.LyrNameRel4 = _analyse.TOCFeatureLayerTableListToComboBox(listen, _view.MainLyrName);
                        break;
                    case "tabPageRel5":
                        //listen = _view.LyrNameRel5;
                        relTypeChange(pageName);
                        //_view.LyrNameRel5 = _analyse.TOCFeatureLayerTableListToComboBox(listen, _view.MainLyrName);
                        break;
                    case "tabPageRel6":
                        //listen = _view.LyrNameRel6;
                        relTypeChange(pageName);
                        //_view.LyrNameRel6 = _analyse.TOCFeatureLayerTableListToComboBox(listen, _view.MainLyrName);
                        break;
                    case "tabPageRel7":
                        //listen = _view.LyrNameRel7;
                        relTypeChange(pageName);
                        //_view.LyrNameRel7 = _analyse.TOCFeatureLayerTableListToComboBox(listen, _view.MainLyrName);
                        break;
                    case "tabPageRel8":
                        //listen = _view.LyrNameRel8;
                        relTypeChange(pageName);
                        //_view.LyrNameRel8 = _analyse.TOCFeatureLayerTableListToComboBox(listen, _view.MainLyrName);
                        break;
                }
            }
            catch (System.ArgumentOutOfRangeException)
            {
                throw new Exception("Modell er ikke angitt / valgt. Du må velge en analysemodell fra listen.");
            }
            catch (Exception ex)
            {   
                throw ex;
            }
        }

        /// <summary>
        /// Sjekker at Attributt/felten er korrekt når man gjør endringer i et felt.
        /// </summary>
        /// <param name="pageName">Navn på fanen</param>
        public void relObjectClass_relField_changed(string pageName)
        {
            try
            {
                string layerTableName1;
                string layerTableName2;
                string fieldName1;
                string fieldName2;

                switch (pageName)
                {
                    case "tabPageRel1":
                        if (_view.RelationType1_selected.Equals("Attributt/felt") == false)
                        {
                            break;
                        }
                        layerTableName1 = _view.MainLyrName;
                        layerTableName2 = _view.LyrNameRel1_selected;
                        fieldName1 = _view.MainObjectClass_relField1_selected;
                        fieldName2 = _view.ObjectClassRelField1_selected;

                        if(layerTableName1.Equals("") || layerTableName2.Equals("") || fieldName1.Equals("") || fieldName2.Equals(""))
                        {
                            break;
                        }
                        _analyse.relFieldTypeEvaluation(layerTableName1, fieldName1, layerTableName2, fieldName2,pageName);
                        break;
                    case "tabPageRel2":
                        if (_view.RelationType2_selected.Equals("Attributt/felt") == false)
                        {
                            break;
                        }
                        layerTableName1 = _view.MainLyrName;
                        layerTableName2 = _view.LyrNameRel2_selected;
                        fieldName1 = _view.MainObjectClass_relField2_selected;
                        fieldName2 = _view.ObjectClassRelField2_selected;

                        if (layerTableName1.Equals("") || layerTableName2.Equals("") || fieldName1.Equals("") || fieldName2.Equals(""))
                        {
                            break;
                        }
                        _analyse.relFieldTypeEvaluation(layerTableName1, fieldName1, layerTableName2, fieldName2, pageName);
                        break;
                    case "tabPageRel3":
                        if (_view.RelationType3_selected.Equals("Attributt/felt") == false)
                        {
                            break;
                        }
                        layerTableName1 = _view.MainLyrName;
                        layerTableName2 = _view.LyrNameRel3_selected;
                        fieldName1 = _view.MainObjectClass_relField3_selected;
                        fieldName2 = _view.ObjectClassRelField3_selected;

                        if (layerTableName1.Equals("") || layerTableName2.Equals("") || fieldName1.Equals("") || fieldName2.Equals(""))
                        {
                            break;
                        }
                        _analyse.relFieldTypeEvaluation(layerTableName1, fieldName1, layerTableName2, fieldName2, pageName);
                        break;
                    case "tabPageRel4":
                        if (_view.RelationType4_selected.Equals("Attributt/felt") == false)
                        {
                            break;
                        }
                        layerTableName1 = _view.MainLyrName;
                        layerTableName2 = _view.LyrNameRel4_selected;
                        fieldName1 = _view.MainObjectClass_relField4_selected;
                        fieldName2 = _view.ObjectClassRelField4_selected;

                        if (layerTableName1.Equals("") || layerTableName2.Equals("") || fieldName1.Equals("") || fieldName2.Equals(""))
                        {
                            break;
                        }
                        _analyse.relFieldTypeEvaluation(layerTableName1, fieldName1, layerTableName2, fieldName2, pageName);
                        break;
                    case "tabPageRel5":
                        if (_view.RelationType5_selected.Equals("Attributt/felt") == false)
                        {
                            break;
                        }
                        layerTableName1 = _view.MainLyrName;
                        layerTableName2 = _view.LyrNameRel5_selected;
                        fieldName1 = _view.MainObjectClass_relField5_selected;
                        fieldName2 = _view.ObjectClassRelField5_selected;

                        if (layerTableName1.Equals("") || layerTableName2.Equals("") || fieldName1.Equals("") || fieldName2.Equals(""))
                        {
                            break;
                        }
                        _analyse.relFieldTypeEvaluation(layerTableName1, fieldName1, layerTableName2, fieldName2, pageName);
                        break;
                    case "tabPageRel6":
                        if (_view.RelationType6_selected.Equals("Attributt/felt") == false)
                        {
                            break;
                        }
                        layerTableName1 = _view.MainLyrName;
                        layerTableName2 = _view.LyrNameRel6_selected;
                        fieldName1 = _view.MainObjectClass_relField6_selected;
                        fieldName2 = _view.ObjectClassRelField6_selected;

                        if (layerTableName1.Equals("") || layerTableName2.Equals("") || fieldName1.Equals("") || fieldName2.Equals(""))
                        {
                            break;
                        }
                        _analyse.relFieldTypeEvaluation(layerTableName1, fieldName1, layerTableName2, fieldName2, pageName);
                        break;
                    case "tabPageRel7":
                        if (_view.RelationType7_selected.Equals("Attributt/felt") == false)
                        {
                            break;
                        }
                        layerTableName1 = _view.MainLyrName;
                        layerTableName2 = _view.LyrNameRel7_selected;
                        fieldName1 = _view.MainObjectClass_relField7_selected;
                        fieldName2 = _view.ObjectClassRelField7_selected;

                        if (layerTableName1.Equals("") || layerTableName2.Equals("") || fieldName1.Equals("") || fieldName2.Equals(""))
                        {
                            break;
                        }
                        _analyse.relFieldTypeEvaluation(layerTableName1, fieldName1, layerTableName2, fieldName2, pageName);
                        break;
                    case "tabPageRel8":
                        if (_view.RelationType8_selected.Equals("Attributt/felt") == false)
                        {
                            break;
                        }
                        layerTableName1 = _view.MainLyrName;
                        layerTableName2 = _view.LyrNameRel8_selected;
                        fieldName1 = _view.MainObjectClass_relField8_selected;
                        fieldName2 = _view.ObjectClassRelField8_selected;

                        if (layerTableName1.Equals("") || layerTableName2.Equals("") || fieldName1.Equals("") || fieldName2.Equals(""))
                        {
                            break;
                        }
                        _analyse.relFieldTypeEvaluation(layerTableName1, fieldName1, layerTableName2, fieldName2, pageName);
                        break;
                }
            }
            catch (Exception ex)
            {   
                throw ex;
            }
        }

        /// <summary>
        /// Det er valgt en annen relasjonstype (attributt eller romlig). Feltene i relasjonsfanen 
        /// oppdateres tilsvarende for om de skal kunne brukes (enabled/disabled).
        /// </summary>
        public void relTypeChange(string pageName)
        {
            try
            {
                if (!_view.MainLyrName.Equals(""))
                {
                    _view.relationTypeVisibility();
                    switch (pageName)
                    {
                        case "tabPageRel1":
                            if (_view.RelationType1_selected.Equals("Attributt/felt"))
                            {
                                List<string> relaterteTabeller = _analyse.getRelatedFeatureLayersAndTables(_view.MainLyrName);
                                _view.LyrNameRel1 = relaterteTabeller;
                            }
                            else
                            {
                                List<string> alleTabeller = _analyse.TOCFeatureLayerListToComboBox(null,null);
                                _view.LyrNameRel1 = alleTabeller;
                                _view.LyrNameRel1_selected = "";
                            }
                            break;
                        case "tabPageRel2":
                            if (_view.RelationType2_selected.Equals("Attributt/felt"))
                            {
                                List<string> relaterteTabeller = _analyse.getRelatedFeatureLayersAndTables(_view.MainLyrName);
                                _view.LyrNameRel2 = relaterteTabeller;
                            }
                            else
                            {
                                List<string> alleTabeller = _analyse.TOCFeatureLayerListToComboBox(null, null);
                                _view.LyrNameRel2 = alleTabeller;
                            }
                            break;
                        case "tabPageRel3":
                            if (_view.RelationType3_selected.Equals("Attributt/felt"))
                            {
                                List<string> relaterteTabeller = _analyse.getRelatedFeatureLayersAndTables(_view.MainLyrName);
                                _view.LyrNameRel3 = relaterteTabeller;
                            }
                            else
                            {
                                List<string> alleTabeller = _analyse.TOCFeatureLayerListToComboBox(null, null);
                                _view.LyrNameRel3 = alleTabeller;
                            }
                            break;
                        case "tabPageRel4":
                            if (_view.RelationType4_selected.Equals("Attributt/felt"))
                            {
                                List<string> relaterteTabeller = _analyse.getRelatedFeatureLayersAndTables(_view.MainLyrName);
                                _view.LyrNameRel4 = relaterteTabeller;
                            }
                            else
                            {
                                List<string> alleTabeller = _analyse.TOCFeatureLayerListToComboBox(null, null);
                                _view.LyrNameRel4 = alleTabeller;
                            }
                            break;
                        case "tabPageRel5":
                            if (_view.RelationType5_selected.Equals("Attributt/felt"))
                            {
                                List<string> relaterteTabeller = _analyse.getRelatedFeatureLayersAndTables(_view.MainLyrName);
                                _view.LyrNameRel5 = relaterteTabeller;
                            }
                            else
                            {
                                List<string> alleTabeller = _analyse.TOCFeatureLayerListToComboBox(null, null);
                                _view.LyrNameRel5 = alleTabeller;
                            }
                            break;
                        case "tabPageRel6":
                            if (_view.RelationType6_selected.Equals("Attributt/felt"))
                            {
                                List<string> relaterteTabeller = _analyse.getRelatedFeatureLayersAndTables(_view.MainLyrName);
                                _view.LyrNameRel6 = relaterteTabeller;
                            }
                            else
                            {
                                List<string> alleTabeller = _analyse.TOCFeatureLayerListToComboBox(null, null);
                                _view.LyrNameRel6 = alleTabeller;
                            }
                            break;
                        case "tabPageRel7":
                            if (_view.RelationType7_selected.Equals("Attributt/felt"))
                            {
                                List<string> relaterteTabeller = _analyse.getRelatedFeatureLayersAndTables(_view.MainLyrName);
                                _view.LyrNameRel7 = relaterteTabeller;
                            }
                            else
                            {
                                List<string> alleTabeller = _analyse.TOCFeatureLayerListToComboBox(null, null);
                                _view.LyrNameRel7 = alleTabeller;
                            }
                            break;
                        case "tabPageRel8":
                            if (_view.RelationType8_selected.Equals("Attributt/felt"))
                            {
                                List<string> relaterteTabeller = _analyse.getRelatedFeatureLayersAndTables(_view.MainLyrName);
                                _view.LyrNameRel8 = relaterteTabeller;
                            }
                            else
                            {
                                List<string> alleTabeller = _analyse.TOCFeatureLayerListToComboBox(null, null);
                                _view.LyrNameRel8 = alleTabeller;
                            }
                            break;
                    }
                    
                    
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Henter data fra de ulike tekstboksene som inneholder modellinformasjon og starter prosessen
        /// med å legge inn disse i korrekte tabeller/database.
        /// </summary>
        /// <returns></returns>
        public void createNewModel()
        {
            try
            {
                if (_view.ModelOwnerList_selected == null)
                {
                    throw new Exception("Du må velge en modell eier fra listen ModelOwner.");
                }
                _paalogging.ModelOwner = _view.ModelOwner;
                _paalogging.ModelOwner = _view.ModelOwnerList_selected;
                // sjekk om pålogget bruker samsvarer med modelOwner
                if (_paalogging.CheckUserRight_NewModel())
                {
                    string modelId = _view.ModelId;
                    string modelName = _view.ModelName;
                    string modelDescr = _view.ModelOwner;
                    string modelOwner = _view.ModelOwner;
                    string mainObjectClassName = _view.MainObjectClassName1;
                    string mainLayerName = _view.MainLyrName;

                    if (modelId == null)
                    {
                        throw new Exception("ModellId kan ikke være tom når du lagrer en ny modell.");
                    }
                    if (modelName == null)
                    {
                        throw new Exception("modelName kan ikke være tom når du lagrer en ny modell.");
                    }
                    if (modelDescr == null)
                    {
                        throw new Exception("modelDescr kan ikke være tom når du lagrer en ny modell.");
                    }
                    if (modelOwner == null)
                    {
                        throw new Exception("modelOwner kan ikke være tom når du lagrer en ny modell.");
                    }
                    if (mainObjectClassName == null)
                    {
                        throw new Exception("mainObjectClassName kan ikke være tom når du lagrer en ny modell.");
                    }
                    if (mainLayerName == null)
                    {
                        throw new Exception("mainLayerName kan ikke være tom når du lagrer en ny modell.");
                    }

                    _analyse.SaveModel(null, modelId, modelName, modelDescr, modelOwner, mainObjectClassName, mainLayerName);

                    _view.clearList();

                    List<string> listen = new List<string>();
                    modellene = _analyse.modelList_update(listen,null,null);
                    modelList_update();
                }
                else
                {
                    throw new Exception("Du har ikke rettighet til å opprette modell med annen modelleier (ModelOwner) enn deg selv.");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        /// <summary>
        /// Kjører modellen som er angitt i listen over modeller.
        /// </summary>
        public void runModel()
        {
            try
            {
                string modelId = _view.ModelId;
                if (string.IsNullOrEmpty(modelId))
                {
                    throw new Exception("Analyse er ikke valgt i listeboks / Model ID er ikke angitt. Modell kan ikke kjøres");
                }

                bool ok = _analyse.runAnalysisModel(modelId);
                _analyse.AnalysisModel_RegRunDate(_view.OIDModel1);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        /// <summary>
        /// Brukeren ønsker å opprette/redigere en spørring. Vinduet editFieldQueryView åpnes og fylles 
        /// ut med relevant informasjon.
        /// </summary>
        /// <param name="buttonNavn"></param>
        public void editQuery(string tabName)
        {
            try
            {
                if (_view.OIDModel1.Equals(""))
                    throw new Exception("Du må først velge en modell fra listen.");
                else
                {
                    _editFieldQueryView = new EditFieldQueryView();

                    _paalogging.ModelId = _view.ModelId;
                    _editFieldQueryView.Oid = int.Parse(_view.OIDModel1);
                    _editFieldQueryView.ModelId = _view.ModelId;
                    _editFieldQueryView._controller.Logon = _paalogging;
                    _editFieldQueryView._controller.Analyse = _analyse;
                    string relationType = "";
                    switch (tabName)
                    {
                        case "tabPageAnalyse":
                            _editFieldQueryView.TableNr = "0";
                            _editFieldQueryView.MainLyrName = _view.MainLyrName;
                            _editFieldQueryView.MainObjectClassName = _view.MainObjectClassName1;
                            break;
                        case "tabPageRel1":
                            _editFieldQueryView.TableNr = "1";
                            _editFieldQueryView.MainLyrName = _view.LyrNameRel1_selected;
                            _editFieldQueryView.MainObjectClassName = _view.ObjectClassName1_selected;
                            relationType = _view.RelationType1_selected;
                            break;
                        case "tabPageRel2":
                            _editFieldQueryView.TableNr = "2";
                            _editFieldQueryView.MainLyrName = _view.LyrNameRel2_selected;
                            _editFieldQueryView.MainObjectClassName = _view.ObjectClassName2_selected;
                            relationType = _view.RelationType2_selected;
                            break;
                        case "tabPageRel3":
                            _editFieldQueryView.TableNr = "3";
                            _editFieldQueryView.MainLyrName = _view.LyrNameRel3_selected;
                            _editFieldQueryView.MainObjectClassName = _view.ObjectClassName3_selected;
                            relationType = _view.RelationType3_selected;
                            break;
                        case "tabPageRel4":
                            _editFieldQueryView.TableNr = "4";
                            _editFieldQueryView.MainLyrName = _view.LyrNameRel4_selected;
                            _editFieldQueryView.MainObjectClassName = _view.ObjectClassName4_selected;
                            relationType = _view.RelationType4_selected;
                            break;
                        case "tabPageRel5":
                            _editFieldQueryView.TableNr = "5";
                            _editFieldQueryView.MainLyrName = _view.LyrNameRel5_selected;
                            _editFieldQueryView.MainObjectClassName = _view.ObjectClassName5_selected;
                            relationType = _view.RelationType5_selected;
                            break;
                        case "tabPageRel6":
                            _editFieldQueryView.TableNr = "6";
                            _editFieldQueryView.MainLyrName = _view.LyrNameRel6_selected;
                            _editFieldQueryView.MainObjectClassName = _view.ObjectClassName6_selected;
                            relationType = _view.RelationType6_selected;
                            break;
                        case "tabPageRel7":
                            _editFieldQueryView.TableNr = "7";
                            _editFieldQueryView.MainLyrName = _view.LyrNameRel7_selected;
                            _editFieldQueryView.MainObjectClassName = _view.ObjectClassName7_selected;
                            relationType = _view.RelationType7_selected;
                            break;
                        case "tabPageRel8":
                            _editFieldQueryView.TableNr = "8";
                            _editFieldQueryView.MainLyrName = _view.LyrNameRel8_selected;
                            _editFieldQueryView.MainObjectClassName = _view.ObjectClassName8_selected;
                            relationType = _view.RelationType8_selected;
                            break;
                    }
                    if (_editFieldQueryView.TableNr.Equals("0") == false)
                    {
                        _analyse.editFieldQuery_Open(relationType, _view.ModelId, int.Parse(_editFieldQueryView.TableNr));
                    }
                    _editFieldQueryView.Show();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        /// <summary>
        /// Brukeren har gjort endringer i modellinformasjonen og denne modellen starter prosessen med 
        /// å lagre endringene i de korrekte tabellene/databasen.
        /// </summary>
        public void saveEdits()
        {
            try
            {
                object oid = _view.OIDModel1;
                int selectedModel = _view.ModelListIndex;
                Modell modellen = modellene[selectedModel];


                if (_paalogging.CheckUserRight() == false)
                {
                    throw new Exception("Du har ikke rettigheter til å lagre endringer i denne modellen.");
                }

                string modelId = _view.ModelId;
                string modelName = _view.ModelName;
                string modelDescr = _view.ModelOwner;
                string modelOwner = _view.ModelOwner;
                string mainObjectClassName = _view.MainObjectClassName1;
                string mainLayerName = _view.MainLyrName;

                if (modelId == null)
                {
                    throw new Exception("ModellId kan ikke være tom når du lagrer en ny modell.");
                }
                if (modelName == null)
                {
                    throw new Exception("modelName kan ikke være tom når du lagrer en ny modell.");
                }
                if (modelDescr == null)
                {
                    throw new Exception("modelDescr kan ikke være tom når du lagrer en ny modell.");
                }
                if (modelOwner == null)
                {
                    throw new Exception("modelOwner kan ikke være tom når du lagrer en ny modell.");
                }
                if (mainObjectClassName == null)
                {
                    throw new Exception("mainObjectClassName kan ikke være tom når du lagrer en ny modell.");
                }
                if (mainLayerName == null)
                {
                    throw new Exception("mainLayerName kan ikke være tom når du lagrer en ny modell.");
                }

                if (oid != null)
                {
                    _analyse.SaveModel(oid,modelId,modelName,modelDescr,modelOwner,mainObjectClassName,mainLayerName);

                    if (selectedModel > 0)
                    {
                        editModel(selectedModel, modellen);
                    }
                    else
                    {
                        throw new Exception("Kan ikke lagre fordi modell ikke er valgt.");
                    }
                    _view.clearModelList();
                    List<string> listen = new List<string>();
                    modellene = _analyse.modelList_update(listen, null, null);
                    modelList_update();
                }
                else
                {
                    throw new Exception("Kan ikke lagre ettersom modell ikke er valgt.");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Oppretter tilkobling til vinduet Options som brukes for å definere hvordan kjøring av 
        /// spørringene skal gjøres.
        /// </summary>
        public void modelOptions()
        {
            try
            {
                _optionsView = new OptionsView();
                _optionsView.Controller.Analyse = _analyse;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        /// <summary>
        /// Brukeren ønsker å slette en modell og denne modellen sjekker om den aktuelle brukeren har 
        /// tillatelse til å slette modellen, samt starter prosessen med å slette modellen fra databasen.
        /// </summary>
        public void deleteModel()
        {
            try
            {
                _paalogging.ModelOwner = _view.ModelOwnerList_selected;
                _paalogging.ModelId = _view.ModelId;
                if (_view.ModelId == null || _view.ModelId.Equals(""))
                {
                    throw new Exception("ModelID er ikke angitt. Kan ikke slette");
                }
                if (!_paalogging.CheckUserRight())
                {
                    throw new Exception("Du har ikke rettigheter til å slette denne modellen!");
                }
                _analyse.deleteAnalaysisModel(_view.ModelId);

                modellene = _analyse.modelList_update(null, null, null);
                _view.ModelListItems.Clear();
                modelList_update();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        /// <summary>
        /// Oppretter tilkobling til vinduet ModelInfo som brukes for å legge inn en beskrivelse og 
        /// eventuell dokumentasjon av modellen.
        /// </summary>
        public void editInfo()
        {
            try
            {
                _modelInfoView.Logon = _paalogging;
                _modelInfoView._control.setAnalyse(_analyse);
                _modelInfoView.Oid = int.Parse(_view.OIDModel1);
                _modelInfoView.Show();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="i"></param>
        /// <param name="modellen"></param>
        public void editModel(int i, Modell modellen)
        {
            try
            {
                bool updateModelDescr;

                updateModelDescr = false;

                _view.OIDModel1 = modellen.Oid.ToString();
                _view.ModelId = modellen.ModelID;
                _view.ModelName = modellen.ModelName;
                _view.ModelOwner = modellen.ModelOwner;
                _view.RegDate = modellen.RegDate.Value.Date.ToString();
                _view.ChDate = modellen.ChDate.Value.Date.ToString();

                _view.FirstRunDate = (modellen.FirstRunDate.Value.Date.ToString());
                _view.LastRunDate = modellen.LastRunDate.Value.Date.ToString();

                _view.ModelDescr = modellen.ModelDescr;
                _view.MainObjectClassName1 = modellen.MainFcl;
                _view.MainLyrName = modellen.Mainlyr;

                System.Windows.Forms.FormCollection userForms = System.Windows.Forms.Application.OpenForms;
                foreach (System.Windows.Forms.Form vindu in userForms)
                {
                    if (vindu.Name.Equals("ModelInfoView"))
                    {
                        updateModelDescr = true;
                    }
                }

                if (updateModelDescr == true)
                {
                    _modelInfoView.ModelDescription = _analyse.getModelDescr(modellen.Oid);
                    _modelInfoView.ModelInfoPath = _analyse.getModelDescrFilePath(modellen.Oid);
                }
            }
            catch (Exception ex)
            {
                _analyse.WriteErrorLog("DesignDialogControl", "EditModel", ex.Message);
                throw new Exception("Det skjedde noe feil under lagring av endring. Kontakt GUF. \n"+ex.Message);
            }   
        }
        
        /// <summary>
        /// Starter prosessen med å åpne dokumentet som er tilknyttet modellen.
        /// </summary>
        public void openDoc()
        {
            try
            {
                _analyse.openDocument(int.Parse(_view.OIDModel1));
            }
            catch (Exception ex)
            {   throw ex;
            }
        }
        
        /// <summary>
        /// Sjekker at den påloggede brukeren har tillatelse til å redigere på modellen og 
        /// setter alle relasjonsfanene aktive.
        /// </summary>
        public void addRelations()
        {
            try
            {
                _paalogging.ModelId = _view.ModelId;
                if (_paalogging.CheckUserRight())
                {
                    _view.allTabs(true);
                }
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public void copyModel(string nyModelId)
        {
            try
            {
                
                _analyse.copyModel(_view.OIDModel1, _view.ModelId, nyModelId, _view.UserName);
                _view.clearModelList();
                List<string> listen = new List<string>();
                modellene = _analyse.modelList_update(listen, null, null);
                modelList_update();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        
        /// <summary>
        /// Navn på relasjonslag er endret i en av relasjonsfanene. Feltene i fanen oppdateres
        /// med korrekt informasjon (feltnavn etc.)
        /// </summary>
        /// <param name="pageName">Navn på fanen</param>
        public void relLayerName_Changed(string pageName)
        {
            try
            {
                List<string> felter;
                switch (pageName)
                {
                    case "tabPageRel1":
                        _view.ObjectClassName1_selected = _analyse.ObjectClassNameForLayer(_view.LyrNameRel1_selected);
                        _view.DataSourceRel1 = _analyse.workspacePathNameForLayer(_view.LyrNameRel1_selected);

                        // Validering av valgt layer/tabell
                        _analyse.objectClassCategoryEvaluation(_view.LyrNameRel1_selected);

                        // Hent valgbare felter for feltet "Rel.tab-rel.felt" (RelObjectClass_RelField)
                         felter = _view.ObjectClassRelField1;
                         
                        _view.ObjectClassRelField1 = _analyse.LayerTableFieldListToComboBox(_view.LyrNameRel1_selected, felter);
                        break;
                    case "tabPageRel2":
                        _view.ObjectClassName2_selected = _analyse.ObjectClassNameForLayer(_view.LyrNameRel2_selected);
                        _view.DataSourceRel2 = _analyse.workspacePathNameForLayer(_view.LyrNameRel2_selected);

                        // Validering av valgt layer/tabell
                        _analyse.objectClassCategoryEvaluation(_view.LyrNameRel2_selected);

                        // Hent valgbare felter for feltet "Rel.tab-rel.felt" (RelObjectClass_RelField)
                        felter = _view.ObjectClassRelField2;
                        _view.ObjectClassRelField2 = _analyse.LayerTableFieldListToComboBox(_view.LyrNameRel2_selected, felter);
                        break;
                    case "tabPageRel3":
                        _view.ObjectClassName3_selected = _analyse.ObjectClassNameForLayer(_view.LyrNameRel3_selected);
                        _view.DataSourceRel3 = _analyse.workspacePathNameForLayer(_view.LyrNameRel3_selected);

                        // Validering av valgt layer/tabell
                        _analyse.objectClassCategoryEvaluation(_view.LyrNameRel3_selected);

                        // Hent valgbare felter for feltet "Rel.tab-rel.felt" (RelObjectClass_RelField)
                        felter = _view.ObjectClassRelField3;
                        _view.ObjectClassRelField3 = _analyse.LayerTableFieldListToComboBox(_view.LyrNameRel3_selected, felter);
                        break;
                    case "tabPageRel4":
                        _view.ObjectClassName4_selected = _analyse.ObjectClassNameForLayer(_view.LyrNameRel4_selected);
                        _view.DataSourceRel4 = _analyse.workspacePathNameForLayer(_view.LyrNameRel4_selected);

                        // Validering av valgt layer/tabell
                        _analyse.objectClassCategoryEvaluation(_view.LyrNameRel4_selected);

                        // Hent valgbare felter for feltet "Rel.tab-rel.felt" (RelObjectClass_RelField)
                        felter = _view.ObjectClassRelField4;
                        _view.ObjectClassRelField4 = _analyse.LayerTableFieldListToComboBox(_view.LyrNameRel4_selected, felter);
                        break;
                    case "tabPageRel5":
                        _view.ObjectClassName5_selected = _analyse.ObjectClassNameForLayer(_view.LyrNameRel5_selected);
                        _view.DataSourceRel5 = _analyse.workspacePathNameForLayer(_view.LyrNameRel5_selected);

                        // Validering av valgt layer/tabell
                        _analyse.objectClassCategoryEvaluation(_view.LyrNameRel5_selected);

                        // Hent valgbare felter for feltet "Rel.tab-rel.felt" (RelObjectClass_RelField)
                        felter = _view.ObjectClassRelField5;
                        _view.ObjectClassRelField5 = _analyse.LayerTableFieldListToComboBox(_view.LyrNameRel5_selected, felter);
                        break;
                    case "tabPageRel6":
                        _view.ObjectClassName6_selected = _analyse.ObjectClassNameForLayer(_view.LyrNameRel6_selected);
                        _view.DataSourceRel6 = _analyse.workspacePathNameForLayer(_view.LyrNameRel6_selected);

                        // Validering av valgt layer/tabell
                        _analyse.objectClassCategoryEvaluation(_view.LyrNameRel6_selected);

                        // Hent valgbare felter for feltet "Rel.tab-rel.felt" (RelObjectClass_RelField)
                        felter = _view.ObjectClassRelField6;
                        _view.ObjectClassRelField6 = _analyse.LayerTableFieldListToComboBox(_view.LyrNameRel6_selected, felter);
                        break;
                    case "tabPageRel7":
                        _view.ObjectClassName7_selected = _analyse.ObjectClassNameForLayer(_view.LyrNameRel7_selected);
                        _view.DataSourceRel7 = _analyse.workspacePathNameForLayer(_view.LyrNameRel7_selected);

                        // Validering av valgt layer/tabell
                        _analyse.objectClassCategoryEvaluation(_view.LyrNameRel7_selected);

                        // Hent valgbare felter for feltet "Rel.tab-rel.felt" (RelObjectClass_RelField)
                        felter = _view.ObjectClassRelField7;
                        _view.ObjectClassRelField7 = _analyse.LayerTableFieldListToComboBox(_view.LyrNameRel7_selected, felter);
                        break;
                    case "tabPageRel8":
                        _view.ObjectClassName8_selected = _analyse.ObjectClassNameForLayer(_view.LyrNameRel8_selected);
                        _view.DataSourceRel8 = _analyse.workspacePathNameForLayer(_view.LyrNameRel8_selected);

                        // Validering av valgt layer/tabell
                        _analyse.objectClassCategoryEvaluation(_view.LyrNameRel8_selected);

                        // Hent valgbare felter for feltet "Rel.tab-rel.felt" (RelObjectClass_RelField)
                        felter = _view.ObjectClassRelField8;
                        _view.ObjectClassRelField8 = _analyse.LayerTableFieldListToComboBox(_view.LyrNameRel8_selected, felter);
                        break;
                }
            }
            catch (Exception ex)
            {   
                throw ex;
            }
        }

        /// <summary>
        /// Brukeren ønsker å slette en relasjonsspørring. Det sjekkes først om brukeren har tillatelse til
        /// å redigere på modellen, og deretter startes prosessen for å slette relatert informasjon fra
        /// tabellene/databasen.
        /// </summary>
        public void deleteQueryRelation(string pageName)
        {
            try
            {
                if (_paalogging.CheckUserRight() == false)
                {
                    throw new Exception("Du har ikke rettigheter til å utføre endringer i denne modellen.");
                }
                string modelId = _view.ModelId;
                int tabNr = 0;

                switch (pageName)
                {
                    case "tabPageRel1": tabNr = 1;
                        break;
                    case "tabPageRel2": tabNr = 2;
                        break;
                    case "tabPageRel3": tabNr = 3;
                        break;
                    case "tabPageRel4": tabNr = 4;
                        break;
                    case "tabPageRel5": tabNr = 5;
                        break;
                    case "tabPageRel6": tabNr = 6;
                        break;
                    case "tabPageRel7": tabNr = 7;
                        break;
                    case "tabPageRel8": tabNr = 8;
                        break;
                }

                foreach (System.Windows.Forms.Form vindu in System.Windows.Forms.Application.OpenForms)
                {
                    if (vindu.Name.Equals("EditFieldQueryView"))
                    {
                        vindu.Close();
                    }
                }

                _analyse.deleteRelatedTableInfo(modelId, tabNr);
                resetPageForRelatedTable(tabNr);
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        /// <summary>
        /// Brukeren ønsker å lagre en relasjon. Henter inn all informasjon fra den aktuelle fanen
        /// og starter prosessen som lagrer informasjonen i aktuell tabell/database.
        /// </summary>
        public  void saveRelation(string pageName)
        {
            try
            {
                string modelId = _view.ModelId;
                string layername = "";
                string mainField = "";
                string relationField = "";
                string relationType="";
                string searchType="";
                string relTabl = "";
                int antRelations = 0;
                bool inclFeature=false;
                string spatialRelType="";
                double bufferDistance=-1;
                int tabNr = 0;
                _paalogging.ModelId = modelId;

                if (modelId == null)
                {
                    throw new Exception("ModellID er ikke angitt. Kan ikke lagre relasjon uten modellid.");
                }

                switch (pageName)
                {
                    case "tabPageRel1": 
                        tabNr = 1;
                        relTabl = _view.ObjectClassName1_selected;
                        layername = _view.LyrNameRel1_selected;
                        mainField = _view.MainObjectClass_relField1_selected;
                        relationField = _view.ObjectClassRelField1_selected;
                        relationType = _view.RelationType1_selected;
                        searchType = _view.SelectionTypeRel1_selected;
                        inclFeature = _view.IncludeFeaturesRel1;
                        antRelations = _view.AntallRelaterte;
                        spatialRelType = _view.SpatialTypeRel1_selected;
                        bufferDistance = _view.BufferDistanceRel1;
                        break;
                    case "tabPageRel2": 
                        tabNr = 2;
                        relTabl = _view.ObjectClassName2_selected;
                        layername = _view.LyrNameRel2_selected;
                        mainField = _view.MainObjectClass_relField2_selected;
                        relationField = _view.ObjectClassRelField2_selected;
                        relationType = _view.RelationType2_selected;
                        searchType = _view.SelectionTypeRel2_selected;
                        inclFeature = _view.IncludeFeaturesRel2;
                        spatialRelType = _view.SpatialTypeRel2_selected;
                        bufferDistance = _view.BufferDistanceRel2;
                        break;
                    case "tabPageRel3": 
                        tabNr = 3;
                        relTabl = _view.ObjectClassName3_selected;
                        layername = _view.LyrNameRel3_selected;
                        mainField = _view.MainObjectClass_relField3_selected;
                        relationField = _view.ObjectClassRelField3_selected;
                        relationType = _view.RelationType3_selected;
                        searchType = _view.SelectionTypeRel3_selected;
                        inclFeature = _view.IncludeFeaturesRel3;
                        spatialRelType = _view.SpatialTypeRel3_selected;
                        bufferDistance = _view.BufferDistanceRel3;
                        break;
                    case "tabPageRel4": 
                        tabNr = 4;
                        relTabl = _view.ObjectClassName4_selected;
                        layername = _view.LyrNameRel4_selected;
                        mainField = _view.MainObjectClass_relField4_selected;
                        relationField = _view.ObjectClassRelField4_selected;
                        relationType = _view.RelationType4_selected;
                        searchType = _view.SelectionTypeRel4_selected;
                        inclFeature = _view.IncludeFeaturesRel4;
                        spatialRelType = _view.SpatialTypeRel4_selected;
                        bufferDistance = _view.BufferDistanceRel4;
                        break;
                    case "tabPageRel5": 
                        tabNr = 5;
                        relTabl = _view.ObjectClassName5_selected;
                        layername = _view.LyrNameRel5_selected;
                        mainField = _view.MainObjectClass_relField5_selected;
                        relationField = _view.ObjectClassRelField5_selected;
                        relationType = _view.RelationType5_selected;
                        searchType = _view.SelectionTypeRel5_selected;
                        inclFeature = _view.IncludeFeaturesRel5;
                        spatialRelType = _view.SpatialTypeRel5_selected;
                        bufferDistance = _view.BufferDistanceRel5;
                        break;
                    case "tabPageRel6": 
                        tabNr = 6;
                        relTabl = _view.ObjectClassName6_selected;
                        layername = _view.LyrNameRel6_selected;
                        mainField = _view.MainObjectClass_relField6_selected;
                        relationField = _view.ObjectClassRelField6_selected;
                        relationType = _view.RelationType6_selected;
                        searchType = _view.SelectionTypeRel6_selected;
                        inclFeature = _view.IncludeFeaturesRel6;
                        spatialRelType = _view.SpatialTypeRel6_selected;
                        bufferDistance = _view.BufferDistanceRel6;
                        break;
                    case "tabPageRel7": 
                        tabNr = 7;
                        relTabl = _view.ObjectClassName7_selected;
                        layername = _view.LyrNameRel7_selected;
                        mainField = _view.MainObjectClass_relField7_selected;
                        relationField = _view.ObjectClassRelField7_selected;
                        relationType = _view.RelationType7_selected;
                        searchType = _view.SelectionTypeRel7_selected;
                        inclFeature = _view.IncludeFeaturesRel7;
                        spatialRelType = _view.SpatialTypeRel7_selected;
                        bufferDistance = _view.BufferDistanceRel7;
                        break;
                    case "tabPageRel8": 
                        tabNr = 8;
                        relTabl = _view.ObjectClassName8_selected;
                        layername = _view.LyrNameRel8_selected;
                        mainField = _view.MainObjectClass_relField8_selected;
                        relationField = _view.ObjectClassRelField8_selected;
                        relationType = _view.RelationType8_selected;
                        searchType = _view.SelectionTypeRel8_selected;
                        inclFeature = _view.IncludeFeaturesRel8;
                        spatialRelType = _view.SpatialTypeRel8_selected;
                        bufferDistance = _view.BufferDistanceRel8;
                        break;
                }
                if (_paalogging.CheckUserRight() == false)
                {
                    throw new Exception("Du har ikke rettigheter til å lagre endringer i denne modellen");
                }
                _analyse.saveRelToTable(modelId, tabNr, relTabl,layername,mainField,relationField, relationType, searchType, inclFeature, antRelations, spatialRelType, bufferDistance);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Logger av eksisterende bruker, og logger på en annen.
        /// </summary>
        public void changeUser()
        {
            string brukernavn = "";
            _paalogging.AnalyseModulLogout();

            if (_loginView.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                brukernavn = _loginView.Brukernavn;
            }

            if (_paalogging.VerifiserBrukernavn(brukernavn) == true)
            {
                _view.Brukernavn = brukernavn;
            }
        }

        /// <summary>
        /// Tømmer alle felter
        /// </summary>
        public void clearAll()
        {
            _view.ModelId = null;
            _view.ModelName = null;
            _view.ModelDescr = null;
            _view.RegDate = null;
            _view.ChDate = null;
            _view.FirstRunDate = null;
            _view.LastRunDate = null;
            _view.MainObjectClassName1 = "";
            _view.MainObjectClassDataSource = "";
            
        }
    }
}
