using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VA_Analysemodul
{
    public class EditFieldQueryController
    {
        #region "Properites"
        EditFieldQueryView _view;
        AnalyseModul_LogOn _logon;
        string[,] fieldQueryList;

        public AnalyseModul_LogOn Logon
        {
            get { return _logon; }
            set { _logon = value; }
        }
        private VAAnalyseModul _analyse;

        public VAAnalyseModul Analyse
        {
            get { return _analyse; }
            set { _analyse = value; }
        }

        List<string> valueList;
        private string tmpFieldName;
        private string tmpOperator;
        private string tmpValue;
        private string tmpAndOr;
        private bool tmpP1;
        private bool tmpP2;
        private int selIdListCount;
        private string[] selekterte;
        private string relObject;

        public string RelObject
        {
            get { return relObject; }
            set { relObject = value; }
        }

        private string modelID;

        public string ModelID
        {
            get { return modelID; }
            set { modelID = value; }
        }

        #endregion

        public EditFieldQueryController(EditFieldQueryView view)
        {
            _view = view;
        }
             
        /// <summary>
        /// Oppretter ny post i tabellen "FieldAttributeQueryDesign", og oppdaterer
        /// listeboksen "MainObjectClass_FieldQueryList.
        /// </summary>
        public void newFieldQuery()
        {
            string OID = _view.Oid.ToString();
            try
            {
                if (!_logon.CheckUserRight())
                {
                    throw new Exception("Du har ikke rettigheter til å lagre endrigner i denne modellen");
                }
                
                if (string.IsNullOrEmpty(_view.TableNr))
                {
                    throw new Exception("TabellNr er ikke angitt. Kan ikke lagre.");
                }
                saveQuery(null, true, int.Parse(_view.TableNr));

                _view.MainObjectClass_AndOr_selected = "AND";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Henter informasjon fra feltene som definerer spørringen og starter prosessen
        /// som lagrer dataene i korrekt tabell.
        /// </summary>
        /// <param name="OID">Modellens objektid (OID)</param>
        /// <param name="clear">Skal listen tømmes?</param>
        /// <param name="tableNr">Angir hvilken relasjonsfane spørringen hører til</param>
        private void saveQuery(object OID, bool clear, int tableNr)
        {
            try
            {
                string fieldValueList = _view.ValueList_toSeparatedString;
                
                if (_view.ValueList_isSelected)
                {
                    _view.Operatoren_selected = "=";
                    _view.MainObjectClassValue_selected = "";
                }
                string tmpAndOr;
                if (_view.AndOr.Equals(" "))
                {
                    tmpAndOr = "";
                }
                else
                {
                    tmpAndOr = _view.AndOr;
                }
                _analyse.saveFieldQueryToTable(OID, _view.ModelId, _view.MainObjectClassName,
                        _view.MainLyrName, _view.P1, _view.FieldNameItems_selected,
                        _view.Operatoren_selected, _view.MainObjectClassValue_selected,
                        fieldValueList, _view.P2, tmpAndOr, int.Parse(_view.TableNr));
                
                if (clear == true)
                {
                    _view.clearList();
                }
                OID = null;
                _view.FieldQueryList = _analyse.fieldQueryList_update(null, OID, _view.ModelId, int.Parse(_view.TableNr));
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        /// <summary>
        /// Lagrer endringer for felt-spørring (endre post i tabellen 
        /// "FieldAttributeQueryDesign".
        /// </summary>
        public void saveFieldQueryEdits()
        {
            try
            {
                object OID;
                string tableNr;

                if (_logon.CheckUserRight() == false)
                {
                    throw new Exception("Du har ikke rettigheter til å lagre endringer i denne modellen");
                }

                tableNr = _view.TableNr;

                if (string.IsNullOrEmpty(tableNr))
                {
                    throw new Exception("TableNr er ikke angitt. Kan ikke lagre");
                }

                OID = _view.Oid;

                if (string.IsNullOrEmpty(OID.ToString()) == false)
                {
                    tempSaveFormParameterValues();

                    saveQuery(OID, true, int.Parse(tableNr));
                    getTempSaveFormParameters();
                }
                else
                {
                    throw new Exception("Kan ikke lagre fordi felt ikke er valgt.");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Slett felt-spørring. Slett post i tabellen "FieldAttributeQueryDesign"
        /// </summary>
        public void slettFieldQuery()
        {
            int oid;
            string modelid="";
            string tableNr;
            try
            {
                oid = _view.Oid;
                tableNr = _view.TableNr;
                modelid = _view.ModelId;

                if (!_logon.CheckUserRight())
                {
                    throw new Exception("Du har ikke rettigheter til å utføre endringer i denne modellen");
                }

                if (string.IsNullOrEmpty(modelid))
                {
                    throw new Exception("ModelID er ikke angitt. Kan ikke slette.");
                }
                
                if (string.IsNullOrEmpty(tableNr))
                {
                    throw new Exception("TableNr er ikke angitt.");
                }
                

                if (string.IsNullOrEmpty(oid.ToString()) == false)
                {
                    _analyse.deleteFieldQuery(oid, false, modelid, int.Parse(tableNr));
                    editFieldQueryClear();
                    _view.FieldQueryList = _analyse.fieldQueryList_update(_view.FieldNameItems,null,_view.ModelId,int.Parse(_view.TableNr));   
                }
                else
                {
                    throw new Exception("Kan ikke slette fordi felt/post er ikke valgt.");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Fjerner all informasjon fra skjemaet
        /// </summary>
        private void editFieldQueryClear()
        {
            try
            {
                _view.Oid = -1;
                _view.FieldNameItems.Clear();
                _view.Operatoren.Clear();
                _view.clearFieldValues();
                _view.clearList();
                _view.MainObjectClass_AndOr.Clear();
                _view.P1 = false;
                _view.P2 = false;
                _view.lsvFieldQueryList_Clear();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Lagrer dataene som finnes i skjemaet midlertidig
        /// </summary>
        private void tempSaveFormParameterValues()
        {
            try
            {
                valueList = _view.ValueList;
                selIdListCount = _view.ValueList_selectedCount;
                selekterte = _view.ValueList_selectedArray;
                tmpFieldName = _view.FieldNameItems_selected;
                tmpOperator = _view.Operatoren_selected;
                tmpAndOr = _view.MainObjectClass_AndOr_selected;
                tmpValue = _view.MainObjectClassValue_selected;
                if (_view.ValueList_selectedCount > 0)
                {
                    selekterte = _view.ValueList_selectedArray;
                }
                tmpP1 = _view.P1;
                tmpP2 = _view.P2;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Henter frem midlertidig lagrede data
        /// </summary>
        private void getTempSaveFormParameters()
        {
            try
            {
                for (int i = 0; i < selIdListCount - 1; i++)
                {
                    //_view.ValueList_selected = selekterte[i];
                }
                _view.ValueList = selekterte.Cast<string>().ToList();

                //_view.setSelectedIndexes(selekterte);

                //_view.FieldName = tmpFieldName;
                _view.Operatoren_selected = tmpOperator;
                _view.MainObjectClass_AndOr_selected = tmpAndOr;
                _view.P1 = tmpP1;
                _view.P2 = tmpP2;
            }
            catch (Exception ex)
            {   
                throw ex;
            }
        }

        /// <summary>
        /// Kartlaget er endret og derfor må feltnavnene fra laget leses på nytt og legges inn i 
        /// kombinasjonsboksen for feltnavn.
        /// </summary>
        public void mainLyrName_Change()
        {
            try
            {
                List<string> feltNavn = new List<string>();
                feltNavn =_analyse.LayerTableFieldListToComboBox(_view.MainLyrName,feltNavn);
                _view.FieldNameItems = feltNavn;

                _view.MainObjectClassName = _analyse.ObjectClassNameForLayer(_view.MainLyrName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Henter endringer som er gjort i spørringen og legger nye verdier i variablene.
        /// </summary>
        /// <param name="selected"></param>
        private void editFieldQuery(int selected)
        {
            bool p1Bool;
            string p1;
            bool p2Bool;
            string p2;

            

            p1 = fieldQueryList[selected, 0];
            if (p1.Equals(")"))
            {
                p1Bool = true;
            }
            else
            {
                p1Bool = false;
            }
            _view.P1 = p1Bool;
            
            _view.FieldNameItems_selected = fieldQueryList[selected, 1];
            _view.Operatoren_selected = fieldQueryList[selected, 2];
            _view.MainObjectClassValue_selected = fieldQueryList[selected, 3];
            
            p2 = fieldQueryList[selected, 5];
            if (p1.Equals(")"))
            {
                p2Bool = true;
            }
            else 
            {
                p2Bool = false;
            }
            _view.P2 = p2Bool;
            _view.MainObjectClass_AndOr_selected = fieldQueryList[selected, 6];
            _view.Oid = int.Parse(fieldQueryList[selected, 7]);
        }

        /// <summary>
        /// 
        /// </summary>
        public void mainObjectClass_FieldQueryList_clicked()
        {
            try
            {
                int selectedIndex = _view.FieldQueryList_selected;

                if (selectedIndex >= 0)
                {
                    editFieldQuery(selectedIndex + 1);
                    mainObjectClass_FieldNameChange(false);
                }
                else
                {
                    editFieldQueryClear();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="endring"></param>
        public void mainObjectClass_FieldNameChange(bool endring)
        {
            string layerTableName=null;
            string fieldName=null;
            List<string> valueList = _view.ValueList;
            List<string> values = _view.MainObjectClassValue;
            string selected = _view.MainObjectClassValue_selected;
            bool sort = _view.Sort;

            if (_view.Unique == true)
            {
                layerTableName = _view.MainLyrName;
                fieldName = _view.FieldNameItems_selected;

                if (!layerTableName.Equals("") && !fieldName.Equals(""))
                {
                    _view.clearFieldValues();
                    List<string> fieldValues = _analyse.fieldValueListToComboBox(layerTableName, fieldName, _view.MainObjectClassValue, selected, _view.Sort, false);
                    fieldValues.Sort();
                    _view.MainObjectClassValue = fieldValues;
                    _view.ValueList = _analyse.fieldValueListToComboBox(layerTableName, fieldName, _view.ValueList, selected, _view.Sort, false);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void load()
        {
            int oid;
            string modelID;
            string pageName;
            try
            {
                bool isOpen = true;
                foreach (System.Windows.Forms.Form form in System.Windows.Forms.Application.OpenForms)
                {
                    if (form.Name.Equals("DesignDialogView"))
                    {
                        isOpen = true;
                    }
                }
                if (isOpen == false)
                {
                    throw new Exception("Du kan ikke editere i \"EditFieldQuery\" fordi vinduet \"DesignDialog\" ikke er åpnet.");
                }
                oid = _view.Oid;
                if (string.IsNullOrEmpty(oid.ToString()))
                {
                    throw new Exception("Modell er ikke angitt/valgt. Du må velge en analysemodell.");
                }
                modelID = _view.ModelId;
                if (string.IsNullOrEmpty(modelID))
                {
                    throw new Exception("Modell er ikke angitt/valgt. Du må velge en analysemodell.");
                }
                /*List<string> fieldValues = _analyse.fieldValueListToComboBox(_view.LayerName,null, _view.FieldNameItems, "", _view.ValueList, _view.Sort, false);
                _view.ValueList = fieldValues;
                _view.MainObjectClassValue = fieldValues;*/

                _view.Operatoren.Add("=");
                _view.Operatoren.Add(">");
                _view.Operatoren.Add("<");
                _view.Operatoren.Add("<>");
                _view.Operatoren.Add(">=");
                _view.Operatoren.Add("<=");
                _view.Operatoren.Add("LIKE");
                _view.Operatoren.Add("IS");
                _view.Operatoren.Add("NOT");


                _view.MainObjectClass_AndOr.Add(" ");
                _view.MainObjectClass_AndOr.Add("AND");
                _view.MainObjectClass_AndOr.Add("OR");
                

                _view.P1 = false;
                _view.P2 = false;

                _view.Sort = false;
                _view.Unique = true;

                // Hent data til listeboksen "mainObjectClass_FieldQueryList"
                fieldQueryList = _analyse.fieldQueryList_update(_view.FieldNameItems, null, modelID, int.Parse(_view.TableNr));

                _view.FieldQueryList = fieldQueryList;

                int antall = _view.FieldQueryList_itemsCount;
                //if (antall >= 1)
                //{
                 //   _view.MainObjectClass_AndOr_selected = "AND";
                //}
                //else 
                //{
                    _view.MainObjectClass_AndOr_selected = " "; ;
                //}
            }
            catch (Exception ex)
            {
                _analyse.WriteErrorLog("EditFieldQueryController", "load", ex.Message);
                throw ex;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        public void checkBox_checkChanged(string name)
        {
            if (name.Equals("chxUnique"))
            {
                mainObjectClass_FieldNameChange(true);
            }
            else if (name.Equals("chxSort"))
            {
                if (_view.Unique == true && _view.Sort == true)
                {
                    mainObjectClass_FieldNameChange(true);
                }
            }
        }

        
    }
}
