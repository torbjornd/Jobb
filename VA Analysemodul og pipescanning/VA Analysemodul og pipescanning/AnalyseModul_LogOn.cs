using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.GeoDatabaseUI;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.esriSystem;

namespace VA_Analysemodul
{
    public class AnalyseModul_LogOn
    {
        private string WG_brukernavn;
        private DesignDialogView modulForm;
        private VAAnalyseModul analyseModul;
        private string brukernavn;
        private string modelId;
        private string modelOwner;

        public string ModelOwner
        {
            get { return modelOwner; }
            set { modelOwner = value; }
        }

        public string ModelId
        {
            get { return modelId; }
            set { modelId = value; }
        }


        public string Brukernavn
        {
            get { return brukernavn; }
            set { brukernavn = value; }
        }

        public AnalyseModul_LogOn()
        {
        }

        public AnalyseModul_LogOn(VAAnalyseModul modul)
        {
            this.analyseModul = modul;
        }

        public VAAnalyseModul AnalyseModul
        {
            get { return analyseModul; }
            set { analyseModul = value; }
        }
        
        public DesignDialogView ModulForm
        {
            get { return modulForm; }
            set { modulForm = value; }
        }

        /// <summary>
        /// Sjekker om brukeren har rettigheter for å lage ny modell.
        /// </summary>
        /// <returns></returns>
        public bool CheckUserRight_NewModel()
        {
            try
            {
                bool checkUserRight_NewModel = false;


                if ((modelOwner == null) || (modelOwner.Equals("")))
                {
                    throw new Exception("ModelOwner er ikke angitt. Kan ikke lagre endringer.");
                }
                else
                {
                    if (modelOwner.Equals(WG_brukernavn))
                        checkUserRight_NewModel = true;
                }
                return checkUserRight_NewModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Sjekker om brukeren har rettigheter for å gjøre endringer i modell.
        /// </summary>
        /// <returns></returns>
        public bool CheckUserRight()
        {
            try
            {
                bool checkUserRight = false;

                if (string.IsNullOrEmpty(modelId))
                {
                    throw new Exception("ModelID er ikke angitt. Kan ikke lagre endringer!");
                }

                string modelOwner = GetModelOwnerFromDatabase(modelId);

                if (modelOwner == null || modelOwner.Equals(""))
                {
                    throw new Exception("ModelOwner er ikke angitt. Kan ikke lagre endringer!");
                }

                if (modelOwner.Equals(WG_brukernavn))
                    checkUserRight = true;

                return checkUserRight;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Henter ut eier av modell fra databasen
        /// </summary>
        /// <param name="modelID"></param>
        /// <returns></returns>
        public string GetModelOwnerFromDatabase(string modelID)
        {
            IStandaloneTable pStandaloneTable;
            ITable pTable;
            IRow pRow;
            ICursor pCursor;
            IQueryFilter pQueryFilter;
            string modelOwnerFromDatabase = null;
            
            pStandaloneTable = analyseModul.HentStdAloneTableFraTOC("AnalysisModel");
            pTable = pStandaloneTable.Table;
            pQueryFilter = new QueryFilter();

            pQueryFilter.WhereClause = "MODELID = "+"\"" + modelID +"\"";
            pCursor = pTable.Search(pQueryFilter, false);
            pRow = pCursor.NextRow();

            if (pRow != null)
                modelOwnerFromDatabase = pRow.get_Value(pRow.Fields.FindField("MODELOWNER")).ToString();
            
            return modelOwnerFromDatabase;
        }

        /// <summary>
        /// Logger brukeren på systemet
        /// </summary>
        /// <returns></returns>
        public bool Paalogging(string id)
        {
            try
            {
                IStandaloneTable pStandaloneTable;
                ITable pTable;
                IRow pRow;
                IQueryFilter pQueryFilter;
                bool paalogging;
                Brukernavn = id;

                paalogging = false;
                WG_brukernavn = null;

                pStandaloneTable = analyseModul.HentStdAloneTableFraTOC("USERS");
                pTable = pStandaloneTable.Table;
                pQueryFilter = new QueryFilter();

                paalogging = true;

                if ((brukernavn != null) && (!brukernavn.Equals("")))
                {
                    pQueryFilter.WhereClause = "USERNAME = " + "\"" + brukernavn + "\"";
                    if (pTable.RowCount(pQueryFilter) == 0)
                        paalogging = false;
                    else
                        paalogging = true;
                }
                WG_brukernavn = brukernavn;
                return paalogging;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Henter brukernavn
        /// </summary>
        /// <returns></returns>
        public string HentBrukernavn()
        {
            return WG_brukernavn;
        }

        /// <summary>
        /// Logger ut av analysemodulen
        /// </summary>
        public void AnalyseModulLogout()
        {
            WG_brukernavn = null;
        }
        
        /// <summary>
        /// Verifiserer at brukeren eksisterer
        /// </summary>
        public bool VerifiserBrukernavn(string brukernavn)
        {
            if ((brukernavn != null) && (!brukernavn.Equals("")))
            {
                if (Paalogging(brukernavn) == false)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
