using ESRI.ArcGIS.SystemUI;
using System.Runtime.InteropServices;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Catalog;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.ArcMapUI;

using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.IO;
using System.Diagnostics;



namespace VA_Analysemodul
{
    public class VAAnalyseModul : ESRI.ArcGIS.Desktop.AddIns.Button
    {
        AnalyseModul_LogOn paalogging;

        public VAAnalyseModul()
        {
            paalogging = new AnalyseModul_LogOn(this);
            paalogging.AnalyseModul = (VAAnalyseModul)this;
        }

        /// <summary>
        /// Registrerer datoen for når analysemodellen ble kjørt for første gang, og legger
        /// denne inn i tabellen 'AnalysisModel' sammen med annen modellinformasjon.
        /// </summary>
        public void AnalysisModel_RegRunDate(string oid)
        {
            try
            {
                IStandaloneTable pStandaloneTable;
                ITable pTable;
                IRow pRow;

                if (oid == null || oid == "")
                {
                    return;
                }
                pStandaloneTable = HentStdAloneTableFraTOC("AnalysisModel");
                pTable = pStandaloneTable.Table;
                pRow = pTable.GetRow(int.Parse(oid));
                string a = pRow.Value[pRow.Fields.FindField("FIRSTRUNDATE")].ToString();
                if (pRow.Value[pRow.Fields.FindField("FIRSTRUNDATE")].ToString().Equals(""))
                    pRow.Value[pRow.Fields.FindField("FIRSTRUNDATE")] = DateTime.Now;
                // Sett designdialog
                {
                }
                if (pRow.Value[pRow.Fields.FindField("LASTRUNDATE")].ToString().Equals(""))
                {
                    pRow.Value[pRow.Fields.FindField("LASTRUNDATE")] = DateTime.Now;
                    // Sett designdialog 
                }
                pRow.Store();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        /// <summary>
        /// Sletter analysemodellen som brukeren har angitt, basert på en gitt modelID
        /// </summary>
        /// <param name="modelid">Unik identifikator på modellen som skal slettes</param>
        public void deleteAnalaysisModel(string modelid)
        {
            try
            {
                IStandaloneTable pStandaloneTable;
                ITable pTable;
                IQueryFilter pQueryFilter;

                // Sletter rad i tabellen 'AnalysisModel'
                pStandaloneTable = HentStdAloneTableFraTOC("AnalysisModel");
                pTable = pStandaloneTable.Table;
                pQueryFilter = new QueryFilter();
                pQueryFilter.WhereClause = "MODELID = \"" + modelid + "\"";
                pTable.DeleteSearchedRows(pQueryFilter);

                // Sletter evt. poster i tabellen "AnalysisModelInputTables" med angitt ModelId
                pStandaloneTable = HentStdAloneTableFraTOC("AnalysisModelInputTables");
                pTable = pStandaloneTable.Table;
                pQueryFilter = new QueryFilter();
                pQueryFilter.WhereClause = "MODELID = \"" + modelid + "\"";
                pTable.DeleteSearchedRows(pQueryFilter);

                // Sletter evt. poster i tabellen "FieldAttributeQueryDesign" med angitt modelId
                pStandaloneTable = HentStdAloneTableFraTOC("FieldAttributeQueryDesign");
                pTable = pStandaloneTable.Table;
                pQueryFilter = new QueryFilter();
                pQueryFilter.WhereClause = "MODELID = \"" + modelid + "\"";
                pTable.DeleteSearchedRows(pQueryFilter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Oppdaterer en liste med feltspørringer (fieldqueries), som er knyttet til en gitt modell.
        /// </summary>
        /// <param name="listen">En liste basert på tekststrenger</param>
        /// <param name="oid">Modellens objektid</param>
        /// <param name="modelId">Modellens unike identifikator</param>
        /// <param name="tableNr">Heltall som forteller hvilken relasjon som spørringene skal oppdateres fra</param>
        /// <returns>En todimensjonal tekststreng-array med informasjon om feltspørringene.</returns>
        public string[,] fieldQueryList_values(string modelId)
        {
            try
            {
                IStandaloneTable pStandaloneTable;
                ITable pTable;
                IRow pRow;
                ICursor pCursor;
                IQueryFilter pQueryFilter = null;
                string SQL_string;
                int postAntall;
                string[,] liste = null;

                pStandaloneTable = HentStdAloneTableFraTOC("FieldAttributeQueryDesign");
                pTable = pStandaloneTable.Table;
                // ObjectID for post som skal oppdateres i listeboksen er ikke angitt. Alle 
                // postene i listeboksen skal derfor oppdateres.
                pQueryFilter = new QueryFilterClass();

                SQL_string = "MODELID = \"" + modelId + "\"";
                pQueryFilter.WhereClause = SQL_string;
                postAntall = pTable.RowCount(pQueryFilter);

                // Hent oppdaterte data for alle poster
                pCursor = pTable.Search(pQueryFilter, false);
                pRow = pCursor.NextRow();
                liste = new string[postAntall, 12];
                int i = 0;
                while (pRow != null)
                {

                    liste[i, 0] = pRow.OID.ToString();
                    liste[i, 1] = pRow.Value[pRow.Fields.FindField("P1")].ToString();
                    liste[i, 2] = pRow.Value[pRow.Fields.FindField("FIELDNAME")].ToString();
                    liste[i, 3] = pRow.Value[pRow.Fields.FindField("OPERATOR")].ToString();
                    liste[i, 4] = pRow.Value[pRow.Fields.FindField("FIELDVALUE")].ToString();
                    liste[i, 5] = pRow.Value[pRow.Fields.FindField("FIELDVALUELIST")].ToString();
                    liste[i, 6] = pRow.Value[pRow.Fields.FindField("AND_OR")].ToString();
                    liste[i, 7] = pRow.Value[pRow.Fields.FindField("P2")].ToString();
                    liste[i, 8] = pRow.Value[pRow.Fields.FindField("MODELID")].ToString();
                    liste[i, 9] = pRow.Value[pRow.Fields.FindField("TABLENAME")].ToString();
                    liste[i, 10] = pRow.Value[pRow.Fields.FindField("LAYERNAME")].ToString();
                    liste[i, 11] = pRow.Value[pRow.Fields.FindField("TABLENO")].ToString();
                    i = i + 1;
                    pRow = pCursor.NextRow();
                }

                    return liste;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        /// <summary>
        /// Oppdaterer en liste med feltspørringer (fieldqueries), som er knyttet til en gitt modell.
        /// </summary>
        /// <param name="listen">En liste basert på tekststrenger</param>
        /// <param name="oid">Modellens objektid</param>
        /// <param name="modelId">Modellens unike identifikator</param>
        /// <param name="tableNr">Heltall som forteller hvilken relasjon som spørringene skal oppdateres fra</param>
        /// <returns>En todimensjonal tekststreng-array med informasjon om feltspørringene.</returns>
        public string[,] fieldQueryList_update(List<string> listen, object oid, string modelId, int tableNr)
        {
            try
            {
                IStandaloneTable pStandaloneTable;
                ITable pTable;
                IRow pRow;
                ICursor pCursor;
                IQueryFilter pQueryFilter = null;
                string SQL_string;
                int postAntall;
                string[,] liste = null;

                pStandaloneTable = HentStdAloneTableFraTOC("FieldAttributeQueryDesign");
                pTable = pStandaloneTable.Table;

                if (oid == null)
                {
                    // ObjectID for post som skal oppdateres i listeboksen er ikke angitt. Alle 
                    // postene i listeboksen skal derfor oppdateres.
                    pQueryFilter = new QueryFilter();

                    SQL_string = "MODELID = \"" + modelId + "\" AND TABLENO = " + tableNr.ToString();
                    pQueryFilter.WhereClause = SQL_string;
                    postAntall = pTable.RowCount(pQueryFilter);
                    liste = new string[postAntall+1, 8];
                    liste[0, 0] = "(";
                    liste[0, 1] = "Field name";
                    liste[0, 2] = "Operator";
                    liste[0, 3] = "Value";
                    liste[0, 4] = "FIELDVALUELIST";
                    liste[0, 5] = ")";
                    liste[0, 6] = "AND/OR";
                    liste[0, 7] = "OBJECTID";

                    // Hent oppdaterte data for alle poster
                    pCursor = pTable.Search(pQueryFilter, false);
                    pRow = pCursor.NextRow();
                    int i = 1;
                    while (pRow != null)
                    {
                        
                        liste[i, 0] = pRow.Value[pRow.Fields.FindField("P1")].ToString();
                        liste[i, 1] = pRow.Value[pRow.Fields.FindField("FIELDNAME")].ToString();
                        liste[i, 2] = pRow.Value[pRow.Fields.FindField("OPERATOR")].ToString();
                        liste[i, 3] = pRow.Value[pRow.Fields.FindField("FIELDVALUE")].ToString();
                        liste[i, 4] = pRow.Value[pRow.Fields.FindField("FIELDVALUELIST")].ToString();
                        liste[i, 5] = pRow.Value[pRow.Fields.FindField("P2")].ToString();
                        liste[i, 6] = pRow.Value[pRow.Fields.FindField("AND_OR")].ToString();
                        liste[i, 7] = pRow.OID.ToString();
                        i = i + 1;
                        pRow = pCursor.NextRow();
                    }
                    
                    return liste;
                }
                else
                {
                    pRow = pTable.GetRow(int.Parse(oid.ToString()));
                    int selektert = 0;
                    if (selektert >= 0)
                    {
                        liste = new string[1, 8];
                        
                        if (pRow.Value[pRow.Fields.FindField("P1")] != null)
                        {
                            liste[0, 0] = pRow.Value[pRow.Fields.FindField("P1")].ToString();
                        }
                        liste[0, 1] = pRow.Value[pRow.Fields.FindField("FIELDNAME")].ToString();
                        liste[0, 2] = pRow.Value[pRow.Fields.FindField("OPERATOR")].ToString();
                        liste[0, 3] = pRow.Value[pRow.Fields.FindField("FIELDVALUE")].ToString();
                        liste[0, 4] = pRow.Value[pRow.Fields.FindField("FIELDVALUELIST")].ToString();
                        if (pRow.Value[pRow.Fields.FindField("P2")] != null)
                        {
                            liste[0, 5] = pRow.Value[pRow.Fields.FindField("P2")].ToString();
                        }
                        liste[0, 6] = pRow.Value[pRow.Fields.FindField("AND_OR")].ToString();
                        liste[0, 7] = pRow.OID.ToString();   
                    }
                    return liste;
                }
            }
            catch (Exception ex)
            {   
                throw ex;
            }
        }
        
        /// <summary>
        /// Sjekker om en gitt modells relasjonsfelt har verdi for alle poster.
        /// </summary>
        /// <param name="modelId">Modellens unike identifikator</param>
        /// <returns>True dersom relasjonsfeltet har verdi for alle poster, ellers false.</returns>
        public bool RelFieldQA(string modelId)
        {
            IStandaloneTable pStandaloneTable = HentStdAloneTableFraTOC("AnalysisModelInputTables");
            IStandaloneTable standaloneTable_RelTable;
            ITable pTable = pStandaloneTable.Table;
            IQueryFilter pQueryFilter = new QueryFilter();
            ITable relTable;

            bool RelFieldQA = true;
            bool RelFieldFormatTest = false;

            int ErrCount = 0;

            string MainLyrName = "";

            MainLyrName = modelInputTablesGetLyrName(modelId, 0);
            if (MainLyrName.Equals(""))
            {
                RelFieldQA = false;
                WriteToLogicalErrorLog(modelId,
                    "",
                    "Featurelayeret som det skal selekteres i er ikke angitt. Kan derfor ikke kjøre analysemodell");
            }
            else
            {
                // Sjekk at relasjonsfelt i featureklassen MainLyName har verdi for alle poster
                IFeatureLayer originFeatureLayer = HentFeatureLayerFraTOC(MainLyrName);
                if (originFeatureLayer == null)
                {
                    RelFieldQA = false;
                    return RelFieldQA;
                }
                ITable originTable = originFeatureLayer as ITable;

                RelFieldQA_OriginTable(pTable, modelId, MainLyrName, originTable);
                
                pQueryFilter.WhereClause = "RELTYPE = 'Attributt/felt' AND MODELID = \"" + modelId + "\"";
                ICursor pCursor = pTable.Search(pQueryFilter, false);
                IRow pRow = pCursor.NextRow();

                while (pRow != null)
                {
                    for(int i = 0; i < pRow.Fields.FieldCount;i++)
                    {
                        Console.WriteLine(pRow.Fields.Field[i].Name);
                    }
                    // sjekker relasjonsfelt
                    string originFieldName = pRow.Value[pRow.Fields.FindField("MAINFCL_RELFLD")].ToString();
                    if (originFieldName == null || originFieldName.Equals(""))
                    {
                        RelFieldQA = false;
                        WriteToLogicalErrorLog(modelId, MainLyrName, "Relasjonsfelt er ikke angitt. Kan derfor ikke kjøre analysemodell");
                        return RelFieldQA;
                    }
                    string originRelFieldNameStr = originFieldName;

                    // sjekker relatert objektklasse
                    string relLyrName = pRow.Value[pRow.Fields.FindField("RELLYR")].ToString();
                    if (relLyrName == null || relLyrName.Equals(""))
                    {
                        RelFieldQA = false;
                        WriteToLogicalErrorLog(modelId, MainLyrName, "Relatert objektklasse er ikke angitt. Kan derfor ikke kjøre analysemodell");
                        return RelFieldQA;
                    }

                    // sjekker relasjonsfelt.
                    string destinationRelFieldName = pRow.Value[pRow.Fields.FindField("RELTAB1_RELFLD")].ToString();
                    if (destinationRelFieldName == null || destinationRelFieldName.Equals(""))
                    {
                        RelFieldQA = false;
                        WriteToLogicalErrorLog(modelId, relLyrName, "Relasjonfelt er ikke angitt. Kan derfor ikke kjøre analysemodell");
                        return RelFieldQA;
                    }

                    IFeatureLayer relFeatureLayer = HentFeatureLayerFraTOC(relLyrName);
                    if (relFeatureLayer != null)
                    {
                        relTable = relFeatureLayer as ITable;
                    }
                    else
                    {
                        standaloneTable_RelTable = HentStdAloneTableFraTOC(relLyrName);
                        if (standaloneTable_RelTable != null)
                        {
                            relTable = relFeatureLayer as ITable;
                        }
                        else
                        {
                            RelFieldQA = false;
                            WriteToLogicalErrorLog(modelId, relLyrName, "Finner ikke relatert objektklasse " + relLyrName + " i TOC. Kan ikke kjøre analysemodell");
                            return RelFieldQA;
                        }

                        // sjekk samsvarende / gylde format for relasjonsfelt
                        // RelFieldFormatTest = RelFieldTypeEvaluation2(mainlyr)
                        if (RelFieldFormatTest == false)
                        {
                            RelFieldQA = false;
                            WriteToLogicalErrorLog(modelId, MainLyrName, "Ikke samsvarende/gyldige format for relasjonsfelt. Kan ikke kjøre analysemodell");
                            return RelFieldQA;
                        }
                        //sjekk at relasjonsfelt "DestinationRelFieldName" i featureklassen "RelLyrName" har verdi for alle poster

                        
                    }
                    pRow = pCursor.NextRow();
                }
            }
            

            return RelFieldQA;
        }

        /// <summary>
        /// Sjekker om et feltet har verdi for alle poster. Dersom ikke verdi, skriv til logg.
        /// </summary>
        /// <param name="LayerTableName">Navnet på kartlaget som skal finnes</param>
        /// <param name="pTable">Tabellen som skal finnes</param>
        /// <param name="fieldName">Feltnavnet som det skal sjekkes mot.</param>
        /// <returns>True dersom feltet har verdi for alle poster, ellers false.</returns>
        public bool FieldValueTest(string LayerTableName, ITable pTable, string fieldName)
        {
            bool FieldValueTestValue = true;
            IStandaloneTable pStandaloneTable = HentStdAloneTableFraTOC("AnalysisModulRecWithEmptyRelFields");
            if (pStandaloneTable == null)
            {
                FieldValueTestValue = false;
                return FieldValueTestValue;
            }

            ITable pTAbleOutput = pStandaloneTable.Table;
            ICursor pInsertRowCursor = pTAbleOutput.Insert(true);
            IRowBuffer pRowBuffer = pTAbleOutput.CreateRowBuffer();
            pRowBuffer.Value[pTAbleOutput.FindField("LyrName")] = LayerTableName;

            IQueryFilter pQueryFilter = new QueryFilter();
            fieldName = QuotedFieldName(fieldName, LayerTableName);
            pQueryFilter.WhereClause = fieldName + " IS NULL";

            ICursor pCursor = pTable.Search(pQueryFilter, false);
            IRow pRow = pCursor.NextRow();

            if (pRow != null)
            {
                if (pRow.HasOID == false)
                {
                    pRowBuffer = null;
                    FieldValueTestValue = false;
                    return FieldValueTestValue;
                }
            }

            do
            {
                pRowBuffer.Value[pTAbleOutput.FindField("OBJID")] = pRow.OID;
                pInsertRowCursor.InsertRow(pRowBuffer);
                pRow = pCursor.NextRow();
            } while (pRow != null);
            
            pInsertRowCursor.Flush();
            pRowBuffer = null;

            long EmptyRelFieldRecCount = pTable.RowCount(pQueryFilter);

            if (EmptyRelFieldRecCount > 0)
            {
                // Messagebox

                openStandaloneTable("AnalysisModulRecWithEmptyRelFields");
            }

            return FieldValueTestValue;
        }

        /// <summary>
        /// Finner ukike verdier i feltet MAINFCL_RELFLD
        /// </summary>
        /// <param name="pTable">Tabellen som brukes</param>
        /// <param name="modelId">Modellens unike identifikator</param>
        /// <param name="originTableName">Opprinnelig tabellnavn</param>
        /// <param name="originTable">Opprinnelig tabell</param>
        public void RelFieldQA_OriginTable(ITable pTable, string modelId, string originTableName, ITable originTable)
        {
            try{
                IQueryFilter pQueryFilter = new QueryFilter();
                IRow pRow;
                ICursor pCursor;
                object pUniqueRelFieldName;
                string pUniqueRelFieldNameString;
                IDataStatistics pData;
            
                if (pTable.RowCount(null) == 0)
                {
                    return;
                }

                pQueryFilter.WhereClause = "RELTYPE = 'Attributt/felt' AND MODELID = \"" + modelId + "\"";
                pCursor = pTable.Search(pQueryFilter, false);
                int i = pCursor.Fields.FieldCount;
                pData = new DataStatistics();

                pData.Field = "MAINFCL_RELFLD";
                pData.Cursor = pCursor;

                IEnumerator uniqueValues = pData.UniqueValues;
                IEnumVariantSimple pEnumVar = pData.UniqueValues as IEnumVariantSimple;
                uniqueValues.MoveNext();

                while (uniqueValues.Current != null)
                {
                    if (uniqueValues.Current != null && (uniqueValues.Current.ToString().Equals("") == false))
                    {
                        pUniqueRelFieldNameString = uniqueValues.Current.ToString();
                        FieldValueTest(originTableName, originTable, pUniqueRelFieldNameString);
                    }
                    uniqueValues.MoveNext();
                }

                /*uniqueValues = pData.UniqueValues;
                IVar
                pUniqueRelFieldName = pEnumVar.Next();

                while (pUniqueRelFieldName != null)
                {
                    if (pUniqueRelFieldName != null && (pUniqueRelFieldName.ToString().Equals("") == false))
                    {
                        pUniqueRelFieldNameString = pUniqueRelFieldName.ToString();
                        FieldValueTest(originTableName, originTable, pUniqueRelFieldNameString);
                    }
                    pUniqueRelFieldName = pEnumVar.Next();
                }*/
            }
            catch(Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="table"></param>
        public void openStandaloneTable(string table)
        {
           
        }

        /// <summary>
        /// Åpner dokumentet som hører til modellen som er angitt med modellens objektid.
        /// </summary>
        /// <param name="oid">Modellens objektid.</param>
        public void openDocument(int oid)
        {
            try
            {
                if (string.IsNullOrEmpty(oid.ToString()))
                {
                    throw new Exception("Du har ikke valgt noen modell.");
                }
                IStandaloneTable pStandaloneTable = HentStdAloneTableFraTOC("AnalysisModel");
                ITable pTable = pStandaloneTable.Table;
                IRow pRow = pTable.GetRow(oid);
                if (pRow == null)
                {
                    return;
                }

                if (pRow.Value[pRow.Fields.FindField("MODELDOC_FILEPATH")] == null)
                {
                    //Messagebox: Filadresse ikke angitt
                    throw new Exception("Det er ikke oppgitt noe dokument");
                }
                string descFilePath = pRow.Value[pRow.Fields.FindField("MODELDOC_FILEPATH")].ToString();
                if (descFilePath.Equals(""))
                {
                    //Messagebox: Filadresse ikke angitt
                    throw new Exception("Katalogen til filen er ikke angitt.");
                }
                if (!File.Exists(descFilePath))
                {
                    //Messagebox: Filen finnes ikke
                    throw new Exception("Filen finnes ikke på katalogen.");
                }
                openDocumentByPath(descFilePath);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Åpner dokumentet som er angitt med stien "path"
        /// </summary>
        /// <param name="path">Stien til dokumentet</param>
        public void openDocumentByPath(string path)
        {
            Process.Start(path);
        }

        /// <summary>
        /// Søker etter eksisterende modeller med et gitt navn.
        /// </summary>
        /// <param name="name">Navnet eller endel av navnet det skal søkes etter</param>
        /// <param name="owner">Eieren av modellen</param>
        /// <returns>En liste med modeller som tilfredsstiller kriteriet (navn)</returns>
        public List<Modell> modelNameSearch(string name, string owner)
        {
            try
            {
                IQueryFilter pQueryFilter;

                if (string.IsNullOrEmpty(name) && string.IsNullOrEmpty(owner))
                {
                    pQueryFilter = null;
                }
                else
                {
                    pQueryFilter = new QueryFilter();
                    if (!name.Equals("") && !owner.Equals(""))
                    {
                        pQueryFilter.WhereClause = "MODELNAME LIKE \"" + name + "*\" AND MODELOWNER LIKE \"" + owner + "\"";
                    }
                    else if (!name.Equals(""))
                    {
                        pQueryFilter.WhereClause = "MODELNAME LIKE \"" + name + "*\"";
                    }
                    else
                    {
                        pQueryFilter.WhereClause = "MODELOWNER LIKE \"" + owner + "\"";
                    }
                }
                List<string> listen = new List<string>();
                List<Modell> modellene = modelList_update(listen, null, pQueryFilter);
                return modellene;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void copyModel(string oidObject,string modelId, string newModelID, string newOwner)
        {
            Modell modellen = null;
            IStandaloneTable pStandaloneTable;
            ITable pTable;
            IRow pRow;
            ICursor pCursor;
            IQueryFilter pQueryfilter = new QueryFilter();
            pStandaloneTable = HentStdAloneTableFraTOC("AnalysisModel");
            pTable = pStandaloneTable.Table;
            pRow = pTable.GetRow(int.Parse(oidObject));
            string query= "MODELID = \"" + modelId + "\"";

            if (pRow != null)
            {
                DateTime? regDate = new DateTime();

                string id = pRow.Value[pRow.Fields.FindField("MODELID")].ToString();
                string name = pRow.Value[pRow.Fields.FindField("MODELNAME")].ToString();

                regDate = DateTime.Today;

                var mxdNameObj = (pRow.Value[pRow.Fields.FindField("MXDNAME")]);

                string mxdName = mxdNameObj.ToString();
                string mxdPath = (pRow.Value[pRow.Fields.FindField("MXDPATH")]).ToString();
                string result = (pRow.Value[pRow.Fields.FindField("RESULTLYR")]).ToString();
                string fcl = (pRow.Value[pRow.Fields.FindField("MAINFCL")]).ToString();
                string lyr = (pRow.Value[pRow.Fields.FindField("MAINLYR")]).ToString();
                string fclDescr = (pRow.Value[pRow.Fields.FindField("MAINFCLDESCR")]).ToString();
                string modelDescr = (pRow.Value[pRow.Fields.FindField("MODELDESCR")]).ToString();
                int oid = pRow.OID;

                modellen = new Modell(id, name, newOwner, regDate, null, null, null, mxdName, mxdPath, result, fcl, lyr, fclDescr, modelDescr, 0);
            }
            SaveModelToTable(null, newModelID, modellen.ModelName, modellen.ModelDescr, modellen.ModelOwner, modellen.MainFcl, modellen.Mainlyr);
            
            // Kopierer verdiene fra tabellen AnalysisModelInputTables
            pStandaloneTable = HentStdAloneTableFraTOC("AnalysisModelInputTables");
            pTable = pStandaloneTable.Table;

            pQueryfilter = new QueryFilter();
            pQueryfilter.WhereClause = query;
            pCursor = pTable.Search(pQueryfilter, false);
            int a = pTable.RowCount(pQueryfilter);
            while ((pRow = pCursor.NextRow()) != null)
            {
                    int relTabNo = Convert.ToInt32(pRow.Value[pRow.Fields.FindField("RELTABNO")]);
                    string relationTable = pRow.Value[pRow.Fields.FindField("RELTABL")].ToString();
                    string relationLyr = pRow.Value[pRow.Fields.FindField("RELLYR")].ToString();
                    string mainFeatureClassLayer_RelationField = pRow.Value[pRow.Fields.FindField("MAINFCL_RELFLD")].ToString();
                    string relationTab_relationField = pRow.Value[pRow.Fields.FindField("RELTAB1_RELFLD")].ToString();
                    string relationType = pRow.Value[pRow.Fields.FindField("RELTYPE")].ToString();
                    string relationSearchType = pRow.Value[pRow.Fields.FindField("RELSEARCHTYPE")].ToString();
                    int inclFeatureWithoutRelation_int = Convert.ToInt32(pRow.Value[pRow.Fields.FindField("INCLFEATWITHOUTREL")]);
                    int antRelations = Convert.ToInt32(pRow.Value[pRow.Fields.FindField("RELATIONCOUNT")]);
                    object spatial = pRow.Value[pRow.Fields.FindField("SPATIALRELTYPE")].ToString();
                    string spatialRelationType = spatial.ToString();
                    double bufferDistance = (double)pRow.Value[pRow.Fields.FindField("BUFFERDISTANCE")];

                    if (relationSearchType.Equals("AND"))
                    {
                        relationSearchType = "AND: Selection criteria in origin objectclass and in related table";
                    }
                    else
                    {
                        relationSearchType = "OR: Selection criteria in origin objectclass or in related table";
                    }
                    bool inclFeatureWithoutRelation_bool = false;
                    if (inclFeatureWithoutRelation_int == 1)
                    {
                         inclFeatureWithoutRelation_bool = true;
                    }
                    else
                    {
                        inclFeatureWithoutRelation_bool = false;
                    }
                    saveRelToTable(newModelID, relTabNo, relationLyr, relationLyr,
                    mainFeatureClassLayer_RelationField, relationTab_relationField, relationType,
                    relationSearchType, inclFeatureWithoutRelation_bool, antRelations,
                    spatialRelationType,bufferDistance);

                    pRow = pCursor.NextRow();
                }

            List<Modell> modellene = readFromTab_AnalysisModelInputTables(modelId);
            if (modellene.Count > 0)
            {
                modellen = modellene[0];

                // Kopierer verdiene fra tabellen "FieldAttributeQueryDesign"
                string[,] fieldQuery = fieldQueryList_values(modelId);
                for (int i = 0; i < fieldQuery.GetLength(0); i++)
                {
                    string oid = fieldQuery[i, 0];
                    string p1String =fieldQuery[i, 1];
                    string fieldName = fieldQuery[i, 2];
                    string op = fieldQuery[i, 3];
                    string fieldValue = fieldQuery[i, 4];
                    string fieldValueList = fieldQuery[i, 5];
                    string andOr = fieldQuery[i, 6];
                    string p2string = fieldQuery[i, 7];
                    string modelid = fieldQuery[i, 8];
                    string tableName = fieldQuery[i, 9];
                    string layername = fieldQuery[i, 10];
                    int tablenr = int.Parse(fieldQuery[i, 11]);
                    bool p1, p2;
                    if (p1String.Equals(""))
                        p1 = false;
                    else
                        p1 = true;

                    if (p2string.Equals(""))
                        p2 = false;
                    else
                        p2 = true;

                    saveFieldQueryToTable(null, newModelID, tableName, layername, p1, fieldName, op, fieldValue, fieldValueList, p2, andOr, tablenr);
                }
            }
        }

        /// <summary>
        /// Oppdaterer en liste med modeller
        /// </summary>
        /// <param name="listBox">Listen som inneholder modeller</param>
        /// <param name="oidObject">objektid</param>
        /// <param name="pQueryFilter">en spørring etter...</param>
        /// <returns>Liste med modellobjekter</returns>
        public List<Modell> modelList_update(List<string> listBox, object oidObject, IQueryFilter pQueryFilter)
        {
            try
            {
                List<Modell> modellene = new List<Modell>();
                IStandaloneTable pStandaloneTable;
                ITable pTable;
                IRow pRow;
                ICursor pCursor;
                int postAntall;

                pStandaloneTable = HentStdAloneTableFraTOC("AnalysisModel");
                pTable = pStandaloneTable.Table;

                if (oidObject == null)
                {
                    // OBJECTID for post som skal oppdateres i listeboks er ikke angitt
                    // Alle poster i listeboksen skal derfor oppdateres.
                    postAntall = pTable.RowCount(null);

                    // Hent oppdaterte data for alle poster.
                    pCursor = pTable.Search(pQueryFilter, false);
                    if (pCursor.NextRow() != null)
                    {
                        pRow = pCursor.NextRow();
                        while(pRow != null)
                        {
                            DateTime? regDate = new DateTime();
                            DateTime? chDate = new DateTime();
                            DateTime? lastRun = new DateTime();
                            DateTime? firstRun = new DateTime();
                            string id = pRow.Value[pRow.Fields.FindField("MODELID")].ToString();
                            string name = pRow.Value[pRow.Fields.FindField("MODELNAME")].ToString();
                            string owner = pRow.Value[pRow.Fields.FindField("MODELOWNER")].ToString();

                            var regDateObj = pRow.Value[pRow.Fields.FindField("REGDATE")];

                            if (!regDateObj.Equals(DBNull.Value))
                                regDate = (DateTime?) regDateObj;

                            var chDateObj = pRow.Value[pRow.Fields.FindField("CHDATE")];
                            if (!chDateObj.Equals(DBNull.Value))
                                chDate = (DateTime? )chDateObj;

                            var lastRunObj = pRow.Value[pRow.Fields.FindField("LASTRUNDATE")];
                            if (!lastRunObj.Equals(DBNull.Value))
                                lastRun = (DateTime) lastRunObj;

                            var firstRunObj = pRow.Value[pRow.Fields.FindField("FIRSTRUNDATE")];
                            if (!firstRunObj.Equals(DBNull.Value))
                                firstRun = (DateTime?)pRow.Value[pRow.Fields.FindField("FIRSTRUNDATE")];

                            var mxdNameObj = (pRow.Value[pRow.Fields.FindField("MXDNAME")]);

                            string mxdName = mxdNameObj.ToString();
                            string mxdPath = (pRow.Value[pRow.Fields.FindField("MXDPATH")]).ToString();
                            string result = (pRow.Value[pRow.Fields.FindField("RESULTLYR")]).ToString();
                            string fcl = (pRow.Value[pRow.Fields.FindField("MAINFCL")]).ToString();
                            string lyr = (pRow.Value[pRow.Fields.FindField("MAINLYR")]).ToString();
                            string fclDescr = (pRow.Value[pRow.Fields.FindField("MAINFCLDESCR")]).ToString();
                            string modelDescr = (pRow.Value[pRow.Fields.FindField("MODELDESCR")]).ToString();
                            int oid = pRow.OID;

                            modellene.Add(new Modell(id, name, owner, regDate, chDate, lastRun, firstRun, mxdName, mxdPath, result, fcl, lyr, fclDescr, modelDescr, oid));

                            pRow = pCursor.NextRow();
                        }
                    }
                }
                else
                {
                    // Oppdater selektert rad i listeboksen for angitt OID
                }
                return modellene;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Returnerer modelbeskrivelse (verdi i feltet "MODELDESCR") for angitt modell.
        /// </summary>
        /// <param name="oid">modellens objektid.</param>
        /// <returns>returnerer modellbeskrivelsen</returns>
        public string getModelDescr(int oid)
        {
            string desc = "";
            if (oid == null)
            {
                return null;
            }
            IStandaloneTable pStandaloneTable = HentStdAloneTableFraTOC("AnalysisModel");
            ITable pTable = pStandaloneTable.Table;
            IRow pRow = pTable.GetRow(oid);

            
            if (pRow == null)
            {
                return null;
            }

            if (pRow.Value[pRow.Fields.FindField("MODELDESCR")] != null)
                desc = pRow.Value[pRow.Fields.FindField("MODELDESCR")].ToString(); 

            return desc;
        }

        /// <summary>
        /// Returnerer modelbeskrivelsefilepath (verdi i feltet "MODELDOC_FILEPATH") for angitt modell
        /// </summary>
        /// <param name="oid">modellens objektid.</param>
        /// <returns>returnerer stien til filen</returns>
        public string getModelDescrFilePath(int oid)
        {
            string path = "";
            IStandaloneTable pStandaloneTable = HentStdAloneTableFraTOC("AnalysisModel");
            ITable pTable = pStandaloneTable.Table;
            IRow pRow = pTable.GetRow(oid);

            if (pRow == null)
            {
                return null;
            }
            if (pRow.Value[pRow.Fields.FindField("MODELDOC_FILEPATH")] != null)
                path = pRow.Value[pRow.Fields.FindField("MODELDOC_FILEPATH")].ToString();

            return path;
        }

        /// <summary>
        /// Legger til et anforselstegn foran og etter feltnavnet dersom laget er en dbase-database
        /// shapefil eller excel fil.
        /// </summary>
        /// <param name="fieldname">Feltnavnet som skal brukes i spørring</param>
        /// <param name="layertablename">Navnet på tabellen/featureklassen som inneholder feltnavnet</param>
        /// <returns>En tekststreng som inneholder feltnavnet og evnt. anførselstegn. </returns>
        public string QuotedFieldName(string fieldname, string layerTablename)
        {
            ITable pTable;
            string objClassCat;
            string quote;
            pTable = tableForLayerTable(layerTablename);
            objClassCat = objectClassCategory(layerTablename);

            switch (objClassCat)
            {
                case "dBase": case "Shapefile": case "Excel Table": 
                    quote = "\"";
                    break;
                default:
                    quote="";
                    break;
            }
            if (quote.Equals("") == false)
            {
                return quote + fieldname + quote;
            }
            else
            {
                return fieldname;
            }
        }

        /// <summary>
        /// Henter tabellen som blir henvist av layerTableName.
        /// </summary>
        /// <param name="layerTablename">Navnet på tabellen som skal hentes</param>
        /// <returns>Returnerer en tabell</returns>
        private ITable tableForLayerTable(string layerTablename)
        {
            try
            {
                IFeatureLayer pFeatureLayer;
                IStandaloneTable pStandaloneTable;

                if(layerTablename.Equals("")){
                    return null;
                }

                pStandaloneTable = HentStdAloneTableFraTOC(layerTablename);
                //dersom layerTableName henviser til en tabell i TOC
                if (pStandaloneTable != null)
                {
                    return pStandaloneTable.Table;
                }
                else
                {
                    //sjekk om layerTableName henviser til en featureklasse
                    pFeatureLayer = HentFeatureLayerFraTOC(layerTablename);
                    if (pFeatureLayer != null)
                    {
                        return pFeatureLayer as ITable;
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Legger til et nytt kartlag i dokumentet
        /// </summary>
        /// <param name="path">Stien til kartlaget som skal legges til dokumentet.</param>
        public void AddLayerFromFile(string path)
        {
            IMxDocument pMxDocument;
            IMap pMap;
            IGxLayer pGxLayer = new GxLayer();
            IGxFile pGxFile = pGxLayer as IGxFile;
            pGxFile.Path = path;

            if (pGxLayer.Layer != null)
            {
                pMxDocument = ArcMap.Application.Document as IMxDocument;
                pMap = pMxDocument.FocusMap;
                pMap.AddLayer(pGxLayer.Layer);
            }
        }

        /// <summary>
        /// Lagrerer en relasjonene til tabell
        /// </summary>
        /// <param name="modelId">Modellens unike identifikator</param>
        /// <param name="relTabNo">Nummeret på fanen / tab for relasjon</param>
        /// <param name="relTabl">Navn på relasjonstabell</param>
        /// <param name="relLyr">Navn på relasjonslag</param>
        /// <param name="mainFCL_RelField">Navn på felt i hovedlaget</param>
        /// <param name="relTab1_RelFld">Navn på felt i relasjonstabellen</param>
        /// <param name="relType">Relasjonstype (romlig, attributt)</param>
        /// <param name="relSearchType">Søketype</param>
        /// <param name="inclFeatWithoutRel">Indluderes objekter uten relasjon?</param>
        /// <param name="spatialRelType">Romlig relasjonstype</param>
        /// <param name="bufferDistance">Bufferstørrelse</param>
        public void saveRelToTable(string modelid, int relTabNo, 
            string relTabl, string relLyr, string mainFCL_RelField, 
            string relTab1_RelFld, string relType, string relSearchType, 
            bool inclFeatWithoutRel, int antRelaterte, string spatialRelType, double bufferDistance)
        {
            try
            {
                relInputTablesSave(modelid, relTabNo, relTabl, relLyr, mainFCL_RelField, 
                    relTab1_RelFld, relType, relSearchType, inclFeatWithoutRel, antRelaterte,
                    spatialRelType, bufferDistance);
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
        
        /// <summary>
        /// Lagrer en ny post i tabellen 'AnalysisModelInputTables'
        /// </summary>
        /// <param name="modelid">Modellens unike identifikator</param>
        /// <param name="relTabNo">Heltall som angir relasjonnummer</param>
        /// <param name="relTabl">Navn på tabell/featureklasse som er med i relasjonen</param>
        /// <param name="relLyr">Navn på tabell/featureklasse som er med i relasjonen</param>
        /// <param name="mainFCL_RelField">Navn på felt i hovedlaget</param>
        /// <param name="relTab1_RelFld">Navn på felt i relasjonstabell</param>
        /// <param name="relType">Relasjonstype (romlig, attributt)</param>
        /// <param name="relSearchType">Søketype</param>
        /// <param name="inclFeatWithoutRel">Inkluderes objekter uten relasjon?</param>
        /// <param name="spatialRelType">Romlig relasjonstype</param>
        /// <param name="bufferDistance">Størrelsen på buffer</param>
        public string relInputTablesSave(string modelid, int relTabNo, 
            string relTabl, string relLyr, string mainFCL_RelField, 
            string relTab1_RelFld, string relType, string relSearchType, 
            bool inclFeatWithoutRel, int antRelaterte, string spatialRelType, double bufferDistance)
        {
            try
            {
                IRow pRow;
                if (modelid == null)
                {
                    // messagebox
                    throw new Exception("ModellID er ikke angitt");
                }
                if(relTabNo == -1)
                {
                    throw new Exception("Feil med fanenummer");
                }
                if (relTabl.Equals("") || relTabl == null)
                {
                    throw new Exception("Relatert tabell er ikke angitt");
                }
                if (relLyr.Equals("") || relLyr == null)
                {
                    throw new Exception("Relasjonsklasse er ikke angitt");
                }
                if (relType.Equals("") || relType == null)
                {
                    throw new Exception("Reltype mangler. Kan ikke lagre");
                }
                if (relSearchType.Equals("") || relSearchType == null)
                {
                    throw new Exception("RelSearchType mangler. Kan ikke lagre.");
                }
                if (relSearchType.Equals("AND: Selection criteria in origin objectclass and in related table"))
                    relSearchType = "AND";
                else
                    relSearchType = "OR";
                if (relType.Equals("Romlig"))
                {
                    if (spatialRelType.Equals(""))
                    {
                        throw new Exception("SpatialRefType mangler. Kan ikke lagre");
                    }
                    if (spatialRelType.Equals("Are within a distance of"))
                    {
                        if (bufferDistance == null)
                        {
                            throw new Exception("Bufferdistance mangler. Kan ikke lagre.");
                        }
                    }
                }
                else
                {
                    if (mainFCL_RelField.Equals(""))
                    {
                        throw new Exception("MainFCL_RelFld mangler. Kan ikke lagre.");
                    }
                    if (relTab1_RelFld.Equals(""))
                    {
                        throw new Exception("RelTab1_RelFld mangler. Kan ikke lagre.");
                    }
                }
                IStandaloneTable pStandaloneTable = HentStdAloneTableFraTOC("AnalysisModelInputTables");
                ITable pTable = pStandaloneTable.Table;

                // sjekker om det allerede er reg. opplysninger om angitt relatert tabell (angitt med reltabno)
                // må også søke på modelid ved sjekk på om info om reltab er lagret
                if (RelTabInfoIsSaved(modelid, relTabNo) == false) //er ikke reg. opplysninger om angitt relasjon.
                {
                    // Oppretter ny post i tabellen "AnalysisModelInputTables"
                    pRow = pTable.CreateRow();
                    pRow.Value[pRow.Fields.FindField("MODELID")] = modelid;
                    pRow.Value[pRow.Fields.FindField("RELTABNO")] = relTabNo;
                }
                else
                {
                    // Lagre endringer i opplysninger for eksisterende relasjon
                    long relTabNo_long = relTabNo;
                    pRow = TableGetRow("AnalysisModelInputTables",relTabNo_long, "RELTABNO",modelid,"MODELID");
                    if (pRow == null)
                    {
                        return "Feil";
                    }
                }

                pRow.Value[pRow.Fields.FindField("RELTABL")] = relTabl;
                pRow.Value[pRow.Fields.FindField("RELLYR")] = relLyr;
                pRow.Value[pRow.Fields.FindField("MAINFCL_RELFLD")] = mainFCL_RelField;
                pRow.Value[pRow.Fields.FindField("RELTAB1_RELFLD")] = relTab1_RelFld;
                pRow.Value[pRow.Fields.FindField("RELTYPE")] = relType;
                pRow.Value[pRow.Fields.FindField("RELSEARCHTYPE")] = relSearchType;
                pRow.Value[pRow.Fields.FindField("INCLFEATWITHOUTREL")] = inclFeatWithoutRel;
                pRow.Value[pRow.Fields.FindField("RELATIONCOUNT")] = antRelaterte;
                
                if (!spatialRelType.Equals(""))
                    pRow.Value[pRow.Fields.FindField("SPATIALRELTYPE")] = spatialRelType;

                if(bufferDistance != -1)
                    pRow.Value[pRow.Fields.FindField("BUFFERDISTANCE")] = bufferDistance;
                pRow.Store();
                
                return "ok";
            }
            catch (Exception ex)
            {
                throw new Exception("Det skjedde noe feil: "+ex.Message);
            }
        }

        /// <summary>
        /// Henter en gitt rad fra tabellen som tilfredsstiller kriteriene.
        /// </summary>
        /// <param name="tabell">Navnet på tabellen som skal hentes</param>
        /// <param name="uniqueFieldValue">Heltall som forteller det skal hentes unike verdier</param>
        /// <param name="fieldname">Feltnavn</param>
        /// <param name="modelid">Modellens unike identifikator</param>
        /// <param name="fieldname2">Det andre feltnavnet</param>
        /// <returns></returns>
        public IRow TableGetRow(string tabell, long uniqueFieldValue, string fieldname, string modelid, string fieldname2)
        {
            IStandaloneTable pStandaloneTable = HentStdAloneTableFraTOC(tabell);
            ITable pTable = pStandaloneTable.Table;
            IQueryFilter pQueryFilter = new QueryFilter();

            pQueryFilter.WhereClause = fieldname + " = " + modelid+" AND "+fieldname+" = \""+uniqueFieldValue+"\"";
            ICursor pCursor = pTable.Search(pQueryFilter, false);

            return pCursor.NextRow();
        }

        /// <summary>
        /// Lager en sortert liste over modellnavn, for å brukes i kombinasjonsboksen "modelName" i DesignDialogView.
        /// </summary>
        /// <returns>Sortert liste med modellnavn</returns>
        public List<string> modelNameList()
        {
            List<string> nameList = new List<string>();
            try
            {
                IStandaloneTable pStandaloneTable;
                ITable pTable;
                ITableSort pTableSort;
                IRow pRow;
                ICursor pCursor;
                string fieldName;


                pStandaloneTable = HentStdAloneTableFraTOC("AnalysisModel");
                pTable = pStandaloneTable.Table;
                pTableSort = new TableSort();

                fieldName = "ModelName";

                pTableSort.Fields = fieldName;
                pTableSort.set_Ascending(fieldName, true);
                pTableSort.Table = pTable;
                pTableSort.Sort(null);
                pCursor = pTableSort.Rows;
                pRow = pCursor.NextRow();

                while (pRow != null)
                {
                    nameList.Add(pRow.Value[pRow.Fields.FindField("MODELNAME")].ToString());
                    pRow = pCursor.NextRow();
                };

                return nameList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Lager en sortert liste over brukernavn knyttet til modellen, for å brukes i
        /// kombinasjonsboksene modelOwner.
        /// </summary>
        /// <returns>Sortert liste med brukernavn</returns>
        public List<string> modelOwnerList()
        {
            List<string> nameList = new List<string>();
            try
            {
                IStandaloneTable pStandaloneTable;
                ITable pTable;
                ITableSort pTableSort;
                IRow pRow;
                ICursor pCursor;
                string fieldName;
                string username;


                pStandaloneTable = HentStdAloneTableFraTOC("Users");
                pTable = pStandaloneTable.Table;
                pTableSort = new TableSort();

                fieldName = "USERNAME";

                pTableSort.Fields = fieldName;
                pTableSort.set_Ascending(fieldName, true);
                pTableSort.Table = pTable;
                pTableSort.Sort(null);
                pCursor = pTableSort.Rows;
                pRow = pCursor.NextRow();

                do
                {
                    username =pRow.Value[pRow.Fields.FindField("USERNAME")].ToString();
                    if (string.IsNullOrEmpty(username) == false)
                    {
                        nameList.Add(username);
                    }
                    pRow = pCursor.NextRow();
                } while (pRow != null);

                return nameList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Finner stien til workspace (katalogen) hvor en gitt featureklasse ligger.
        /// </summary>
        /// <param name="layerTableName">Featureklassen det skal letes etter.</param>
        /// <returns>Stien til featureklassen</returns>
        public string workspacePathNameForLayer(string layerTableName)
        {
            try
            {
                IWorkspace pWorkspace;
                IFeatureClass pFeatureClass;
                IFeatureLayer pFeatureLayer;
                IStandaloneTable pStandaloneTable;
                IDataset pDataset = null;
                ITable pTable;

                if (layerTableName.Equals(""))
                {
                    return "";
                }
                pStandaloneTable = HentStdAloneTableFraTOC(layerTableName);

                // Dersom layerTableName henviser til en tabell i TOC
                if (pStandaloneTable != null)
                {
                    pTable = pStandaloneTable.Table;
                    pDataset = pTable as IDataset;
                }
                else
                {
                    pFeatureLayer = HentFeatureLayerFraTOC(layerTableName);
                    if (pFeatureLayer != null)
                    {
                        pFeatureClass = pFeatureLayer.FeatureClass;
                        pDataset = pFeatureClass as IDataset;
                    }
                }
                if (pDataset != null)
                {
                    pWorkspace = pDataset.Workspace;
                    return pWorkspace.PathName;
                }
                else
                {
                    return "";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        /// <summary>
        /// Sjekker om informasjon fra relasjonen (for en gitt modell) er lagret i tabellen 'AnalsisModelInputTables'
        /// </summary>
        /// <param name="modelId">Modellens unike identifikator</param>
        /// <param name="relTabNo">Nummeret på relasjonen.</param>
        /// <returns>Sann (true) dersom informasjon er lagret, ellers usann (false)</returns>
        public bool RelTabInfoIsSaved(string modelId,  int relTabNo)
        {
            try
            {
                IStandaloneTable pStandaloneTable;
                ITable pTable;
                IQueryFilter pQueryFilter;

                pStandaloneTable = HentStdAloneTableFraTOC("AnalysisModelInputTables");
                pTable = pStandaloneTable.Table;

                pQueryFilter = new QueryFilter();
                pQueryFilter.WhereClause = "RELTABNO = " + relTabNo + " AND MODELID = \"" + modelId + "\"";
                if (pTable.RowCount(pQueryFilter) > 0)
                {
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
        /// Lagrer informasjon om modell/filsti til dokument som beskriver modellen
        /// </summary>
        /// <param name="oid">Modellens objektid</param>
        /// <param name="modelDescr">Beskrivelse av modellen</param>
        /// <param name="DescrFilePath">Dokumentet som beskriver modellen</param>
        public void saveModelInfo(int oid, string modelDescr, string DescrFilePath)
        {
            try
            {
                IStandaloneTable pStandaloneTable = HentStdAloneTableFraTOC("AnalysisModel");
                ITable pTable = pStandaloneTable.Table;
                IRow pRow = pTable.GetRow(oid);

                if (pRow == null)
                {
                    // Messagebox: Finner ikke angitt modell i tabellen 'AnalysisModel'. Kan ikke lagre
                    return;
                }

                pRow.Value[pRow.Fields.FindField("CHDATE")] = DateTime.Now;
                pRow.Value[pRow.Fields.FindField("MODELDESCR")] = modelDescr;
                pRow.Value[pRow.Fields.FindField("MODELDOC_FILEPATH")] = DescrFilePath;
                pRow.Store();

                //vaAnalyseDialog.ModelDescr = modelDescr;
            }
            catch (Exception ex)
            {
                WriteToLogicalErrorLog("VAanalysemodul", "SaveModelInfo", ex.Message);
            }
        }


        #region ArcGIS funksjoner
        /// <summary>
        /// Henter standalonetable fra TOC
        /// </summary>
        /// <param name="table">Navnet på tabellen</param>
        /// <returns>En standalonetabell som er hentet fra TOC</returns>
        public IStandaloneTable HentStdAloneTableFraTOC(string table)
        {
            IMxDocument pMxDocument = ArcMap.Application.Document as IMxDocument;
            IActiveView activeView = pMxDocument.ActiveView;
            IMap pMAp = activeView.FocusMap;

            int layerCount = pMAp.LayerCount;

            IStandaloneTableCollection coll = pMAp as IStandaloneTableCollection;
            for (int i = 0; i < coll.StandaloneTableCount; i++)
            {
                string navn = coll.StandaloneTable[i].Name;
                if (coll.StandaloneTable[i].Name.ToLower().Equals(table.ToLower()))
                {
                    return coll.StandaloneTable[i];
                }
            }

            /*for (int i = 0; i < pMAp.LayerCount; i++)
            {
                ILayer pLayer = pMAp.Layer[i];
                if (pLayer.Name.Equals(table))
                    return pLayer as IStandaloneTable;
            }*/

            return null;
        }

        /// <summary>
        /// Henter featurelayer fra TOC
        /// </summary>
        /// <param name="layerName">Navn på featurelayer</param>
        /// <returns>Featurelayer</returns>
        public IFeatureLayer HentFeatureLayerFraTOC(string layerName)
        {
            try
            {
                IMxDocument pMxDocument = ArcMap.Application.Document as IMxDocument;
                IActiveView activeView = pMxDocument.ActiveView;
                IMap pMap = activeView.FocusMap;
                IEnumLayer pEnumLayer;
                ILayer pLayer;
                pEnumLayer = pMap.get_Layers(null, true);
                pEnumLayer.Reset();
                pLayer = pEnumLayer.Next();
                while (pLayer != null)
                {
                    if (pLayer.Name.Equals(layerName))
                        return pLayer as IFeatureLayer;
                    pLayer = pEnumLayer.Next();
                }

                /*
                for (int i = 0; i < pMap.LayerCount; i++)
                {
                    ILayer pLayer = pMap.Layer[i];
                    if (pLayer.Name.Equals(layerName))
                        return pLayer as IFeatureLayer;
                }*/
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        #endregion

        /// <summary>
        /// Finner alle feltene i en gitt tabell og legger disse inn i en liste som brukes i en kombinasjonsboks
        /// </summary>
        /// <param name="layerTableName">Navnet på featureklasse/tabell som feltene skal hentes fra</param>
        /// <param name="liste">Listen som informasjonen skal legges inn i.</param>
        /// <returns>Listen som inneholder feltnavn fra featureklassen.</returns>
        public List<string> LayerTableFieldListToComboBox(string layerTableName, List<string> liste)
        {
            try
            {
                List<string> feltNavn = new List<string>();
                IStandaloneTable pStandaloneTable;
                IFeatureLayer pFeatureLayer;
                ITable pTable = null;
                IFields pFields;
                IField pField;

                // Slett evt. eksisterende feltnavn i listeboksen

                // Henter tilbake verdi etter sletting av innhold
                pStandaloneTable = HentStdAloneTableFraTOC(layerTableName);

                //Dersom layerTableName henviser til en tabell i TOC
                if (pStandaloneTable != null)
                {
                    pTable = pStandaloneTable.Table;
                }
                else
                {
                    pFeatureLayer = HentFeatureLayerFraTOC(layerTableName);

                    // Dersom pFeatureLayer henviser til et FeatureLayer i TOC
                    if (pFeatureLayer != null)
                    {
                        pTable = pFeatureLayer as ITable;
                    }
                }

                if (pTable == null)
                {
                    return null;
                }

                pFields = pTable.Fields;

                for (int i = 0; i < pFields.FieldCount - 1; i++)
                {
                    pField = pFields.Field[i];
                    if (!pField.Name.Equals("SHAPE"))
                    {
                        feltNavn.Add(pField.AliasName);
                    }
                }
                return feltNavn;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        /// <summary>
        /// Sjekker om den gitte featureklassen/tabellen kan inngå analysemodellen.
        /// </summary>
        /// <param name="layerTableName">Navnet på featureklassen som skal sjekkes</param>
        /// <returns>Sann(true) dersom den kan inngå i modellen, ellers usann (false).</returns>
        public bool objectClassCategoryEvaluation(string layerTableName)
        {
            try
            {
                string objClassCategory = objectClassCategory(layerTableName);
                switch (objClassCategory)
                {
                    case "":
                        throw new Exception("Finner ikke layer/tabell i TOC i ArcMap-prosjektet."); 
                    case "Excel table":
                        throw new Exception(@"ADVARSEL: Excel tabeller bør ikke inngå i analysemodeller. Gir lav ytelse og stor sannsynlighet for feil.\n"
                            + "Anbefaler konverteting til dBASE- eller MS-Access tabell.");
                }
                return true;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        /// <summary>
        /// Returnerer kategori (Dataset.Category) for angitt LayerTableName
        /// Dataset.Category tilsvarer verdi i type-felt i Contents-vindu ved klikk på en objektklasse i ArcCatalog
        /// </summary>
        /// <param name="layerTableName">navnet på laget som skal finnes</param>
        /// <returns>En tekststreng som beskrive kategori</returns>
        public string objectClassCategory(string layerTableName)
        {
            try
            {
                IFeatureClass pFeatureClass = null;
                IFeatureLayer pFeatureLayer = null;
                IStandaloneTable pStandaloneTable = null;
                IDataset pDataset = null;
                ITable pTable = null;

                pStandaloneTable = HentStdAloneTableFraTOC(layerTableName);

                // Dersom layerTableName henviser til en tabell i TOC
                if (pStandaloneTable != null)
                {
                    pTable = pStandaloneTable.Table;
                    pDataset = pTable as IDataset;
                }
                else
                {
                    // sjekk om layerTableName henviser til en featureklasse
                    pFeatureLayer = HentFeatureLayerFraTOC(layerTableName);
                    if (pFeatureLayer != null)
                    {
                        pFeatureClass = pFeatureLayer.FeatureClass;
                        pDataset = pFeatureClass as IDataset;
                    }
                }
                if (pDataset != null)
                {
                    return pDataset.Category;
                }
                else
                {
                    return "";
                }
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }
        
        /// <summary>
        /// Henter objectclass 
        /// </summary>
        /// <param name="layerTableName">Navn på tabell eller layer</param>
        /// <returns>Objektklassen for layeret eller tabellen</returns>
        public IObjectClass objectClassFromLayerOrStandaloneTable(string layerTableName)
        {
            try
            {
                IFeatureLayer pFeatureLayer;
                IStandaloneTable pStandaloneTable;
                ITable pTable;

                pStandaloneTable = HentStdAloneTableFraTOC(layerTableName);
                if (pStandaloneTable != null)
                {
                    return pStandaloneTable.Table as IObjectClass;
                }
                else
                {
                    pFeatureLayer = HentFeatureLayerFraTOC(layerTableName);
                    if(pFeatureLayer != null)
                    {
                        return pFeatureLayer.FeatureClass as IObjectClass;
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Finner objektklassetypen for et gitt lag
        /// </summary>
        /// <param name="LayerTableName">Navnet på laget/tabellen</param>
        /// <returns>Tekst med objektklassetypen</returns>
        public string ObjectClassNameForLayer(string LayerTableName)
        {
            try
            {
                IFeatureLayer pFeatureLayer;
                IFeatureClass pFeatureClass;
                IStandaloneTable pStandaloneTable;
                ITable pTable;
                IDataset pDataset = null;

                if (LayerTableName.Equals(""))
                {
                    throw new Exception("LayerTableName kan ikke være null.");
                }
                pStandaloneTable = HentStdAloneTableFraTOC(LayerTableName);

                // Dersom LayerTableName henviser til en tabell i TOC
                if (pStandaloneTable != null)
                {
                    pTable = pStandaloneTable.Table;
                    pDataset = pTable as IDataset;
                }
                else
                {
                    pFeatureLayer = HentFeatureLayerFraTOC(LayerTableName);
                    if (pFeatureLayer != null)
                    {
                        pFeatureClass = pFeatureLayer.FeatureClass;
                        pDataset = pFeatureClass as IDataset;
                    }
                }
                if (pDataset != null)
                {
                    return pDataset.Name;
                }
                else
                {
                    return "";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Henter alle unike verdier som finnes i et gitt felt i den aktuelle tabellen/featureklassen.
        /// </summary>
        /// <param name="layerTableName">Navnet på featureklasse/tabell.</param>
        /// <param name="fieldName">Feltnavnet hvor verdier skal hentes fra</param>
        /// <param name="comboBox">Liste med tekststrenger hvor verdier skal legges.</param>
        /// <param name="cbSelected">Tekststreng med valgt verdi</param>
        /// <param name="sorter">Angir om listen skal sorteres eller ikke.</param>
        /// <param name="deleteFieldValue">Angir om listen skal slettes først.</param>
        /// <returns>En liste med unike verdier som finnes i et gitt felt.</returns>
        public List<string> fieldValueListToComboBox(string layerTableName, string fieldName, 
            List<string> comboBox, string cbSelected, bool sorter, bool deleteFieldValue)
        {
            try
            {
                IFeatureLayer pFeatureLayer;
                IStandaloneTable pStandaloneTable;
                ITable pTable = null;
                ITableSort pTablesort;
                IRow pRow;
                ICursor pCursor;
                object unikVerdi;
                IDataStatistics pData;
                IEnumVariantSimple pEnumVar;
                string fieldValue = "";
                bool alias = false;
                if (deleteFieldValue == false)
                {
                    fieldValue = cbSelected;
                }

                if (deleteFieldValue == false)
                {
                    comboBox.Add(fieldValue);
                }

                pStandaloneTable = HentStdAloneTableFraTOC(layerTableName);

                // Dersom layerTableNAme henviser til en tabell i TOC
                if (pStandaloneTable != null)
                {
                    pTable = pStandaloneTable.Table;
                }
                else
                {
                    // Dersom layerTableName henviser til en featureklasse
                    pFeatureLayer = HentFeatureLayerFraTOC(layerTableName);
                    if (pFeatureLayer != null)
                    {
                        pTable = pFeatureLayer as ITable;
                    }
                }

                // layerTableName ble ikke funnet i TOC, og metoden kan derfor ikke kjøre videre.
                if (pTable == null)
                {
                    throw new Exception("layerTableName: "+layerTableName+" ble ikke funnet i prosjektet. Kan ikke fortsette.");
                }

                // sjekk om feltet eksisterer enten som vanlig feltnavn eller som alias.
                if (pTable.FindField(fieldName) == -1)
                {
                    if (pTable.Fields.FindFieldByAliasName(fieldName) == -1)
                    {
                        throw new Exception("Feltet " + fieldName + " finnes ikke i " + layerTableName + ". Kan ikke fortsette.");
                    }
                    else
                    {
                        alias = true;
                    }
                }

                // finn unike feltverdier
                if (pTable.RowCount(null) == 0)
                {
                    throw new Exception("Feltet " + fieldName + " finnes ikke i " + layerTableName + ". Kan ikke fortsette.");
                }

                // Henter det virkelige navnet til feltnavnet dersom det er er alias.
                if (alias == true)
                {
                    fieldName = pTable.Fields.Field[pTable.Fields.FindFieldByAliasName(fieldName)].Name;
                }
                // sorter på stigende feltverdi
                if (sorter == true)
                {
                    pTablesort = new TableSort();
                    pTablesort.Fields = fieldName;
                    pTablesort.Ascending[fieldName] = true;
                    pTablesort.Table = pTable;
                    pTablesort.Sort(null);
                    pCursor = pTablesort.Rows;
                }
                else
                {
                    pCursor = pTable.Search(null, false);
                }

                List<string> unikeFeltVerdier = new List<string>();

                // Henter eventuelle domeneverdier
                IField pField = pTable.Fields.Field[pTable.FindField(fieldName)];
                List<string> domainValues = new List<string>();
                if (pField.Domain != null)
                {
                    IDomain pDomain = pField.Domain;
                    ICodedValueDomain codedValueDomain = pField.Domain as ICodedValueDomain;
                    for (int i = 0; i < codedValueDomain.CodeCount; i++)
                    {
                        domainValues.Add(codedValueDomain.get_Value(i)+"-"+codedValueDomain.get_Name(i));
                    }

                    // Det finnes ikke domeneverdier, og vanlige verdier blir hentet.
                    pData = new DataStatistics();

                    pData.Field = fieldName;
                    pData.Cursor = pCursor;
                    IEnumerator uniqueValues = pData.UniqueValues;
                    pEnumVar = pData.UniqueValues as IEnumVariantSimple;
                    uniqueValues.MoveNext();

                    while (uniqueValues.Current != null)
                    {
                        unikeFeltVerdier.Add(uniqueValues.Current.ToString());
                        unikVerdi = uniqueValues.MoveNext();
                    }

                    foreach (string domain in domainValues)
                    {
                        string[] tmpVerdier = domain.Split('-');
                        foreach (string unikFeltVerdi in unikeFeltVerdier)
                        {
                            if (tmpVerdier[0].Equals(unikFeltVerdi))
                            {
                                comboBox.Add(domain);
                            }
                        }

                    }
                }
                else
                {
                    // Det finnes ikke domeneverdier, og vanlige verdier blir hentet.
                    pData = new DataStatistics();

                    pData.Field = fieldName;
                    pData.Cursor = pCursor;
                    IEnumerator uniqueValues = pData.UniqueValues;
                    pEnumVar = pData.UniqueValues as IEnumVariantSimple;
                    uniqueValues.MoveNext();

                    while (uniqueValues.Current != null)
                    {
                        comboBox.Add(uniqueValues.Current.ToString());
                        unikVerdi = uniqueValues.MoveNext();
                    }
                }
                return comboBox;

            }
            catch (Exception ex)
            {
                WriteErrorLog("VAAnalysemodul", "FieldValueListToCombobox", ex.Message);
                throw ex;
            }
        }

        /// <summary>
        /// Sletter angitt post i tabellen "FieldAttribtueQueryDesign"
        /// </summary>
        /// <param name="OID">Modellens objektid</param>
        /// <param name="clearListBox">Angir om listeboksen skal tømmes.</param>
        /// <param name="modelId">Modellens unike identifikator</param>
        /// <param name="tableNr">Angir relasjonsnummer</param>
        public void deleteFieldQuery(object OID, bool clearListBox, string modelID, int tableNr)
        {
            try
            {
                IStandaloneTable pStandaloneTable;
                ITable pTable;
                IRow pRow;

                pStandaloneTable = HentStdAloneTableFraTOC("FieldAttributeQueryDesign");
                pTable = pStandaloneTable.Table;

                if (OID != null)
                {
                    pRow = pTable.GetRow((int)OID);
                    pRow.Delete();
                }
                else
                {
                    throw new Exception("OID for post som skal sletes er ikke angitt. Kan ikke slette.");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Lagrerer spørreuttrykk for et felt. Uttrykket lagres i tabellen 'FieldAttributeQueryDesign'
        /// </summary>
        /// <param name="OID"></param>
        /// <param name="modelId">Modellens unike identifikator</param>
        /// <param name="tableName">Navn på tabell</param>
        /// <param name="layerName">Navn på lag</param>
        /// <param name="p1">Angir om det skal være parentes i uttrykket</param>
        /// <param name="fieldName">Navn på felt</param>
        /// <param name="operatoren">Teksttreng med operator (LIKE, =, >, etc)</param>
        /// <param name="fieldValue">Tekststreng med feltverdi</param>
        /// <param name="fieldValueList">Liste med feltverdier</param>
        /// <param name="p2">Angir om det skal være parentes i uttrykket</param>
        /// <param name="andOr">Tekst som angir betingelse (AND, OR)</param>
        /// <param name="tableNr">Angir tabellnummer</param>
        public void saveFieldQueryToTable(object OID, string modelId, string tableName, 
            string layerName, bool p1, string fieldName, string operatoren, 
            string fieldValue, string fieldValueList, bool p2, string andOr, 
            int tableNr)
        {
            try
            {
                IStandaloneTable pStandaloneTable;
                ITable pTable;
                IRow pRow;

                if (modelId.Equals(""))
                {
                    throw new Exception("ModelID mangler. Kan ikke lagre");
                }
                if (tableName.Equals(""))
                {
                    throw new Exception("TableName mangler. Kan ikke lagre");
                }
                if (layerName.Equals(""))
                {
                    throw new Exception("Layername mangler. Kan ikke lagre");
                }
                if (fieldName.Equals(""))
                {
                    throw new Exception("FieldName mangler. Kan ikke lagre");
                }
                if (operatoren.Equals(""))
                {
                    throw new Exception("Operatoren mangler. Kan ikke lagre");
                }
                if(fieldValue.Equals("") && (fieldValueList.Equals("")))
                {
                    throw new Exception("FieldValue / FieldValueList mangler. Kan ikke lagre");
                }

                pStandaloneTable = HentStdAloneTableFraTOC("FieldAttributeQueryDesign");
                pTable = pStandaloneTable.Table;

                if (OID == null)
                {
                    pRow = pTable.CreateRow();
                    pRow.Value[pRow.Fields.FindField("MODELID")] = modelId;
                    pRow.Value[pRow.Fields.FindField("TABLENO")] = tableNr;
                }
                else
                {
                    pRow = pTable.GetRow((int)OID);
                }

                pRow.Value[pRow.Fields.FindField("TABLENAME")] = tableName;
                pRow.Value[pRow.Fields.FindField("LAYERNAME")] = layerName;

                if (p1 == true)
                {
                    pRow.Value[pRow.Fields.FindField("P1")] = "(";
                }
                else
                {
                    pRow.Value[pRow.Fields.FindField("P1")] = "";
                }

                pRow.Value[pRow.Fields.FindField("FIELDNAME")] = fieldName;
                pRow.Value[pRow.Fields.FindField("OPERATOR")] = operatoren;
                pRow.Value[pRow.Fields.FindField("FIELDVALUE")] = fieldValue;
                pRow.Value[pRow.Fields.FindField("FIELDVALUELIST")] = fieldValueList;

                if (p2 == true)
                {
                    pRow.Value[pRow.Fields.FindField("P2")] = ")";
                }
                else
                {
                    pRow.Value[pRow.Fields.FindField("P2")] = "";
                }
                pRow.Value[pRow.Fields.FindField("AND_OR")] = andOr;

                pRow.Store();
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        /// <summary>
        /// Lagrer informasjon om hvordan brukeren ønsker or-seleksjonsmodell.
        /// </summary>
        /// <param name="value">Verdi fra OptionsControl</param>
        public void saveLocalSettings(string value)
        {
            try
            {
                IStandaloneTable pStandaloneTable;
                ITable pTable;
                IRow pRow;
                ICursor pCursor;

                pStandaloneTable = HentStdAloneTableFraTOC("LocalSettings");
                if (pStandaloneTable == null)
                {
                    throw new Exception("Finner ikke taballen 'LocalSettings'");
                }
                pTable = pStandaloneTable.Table;

                if (value == null)
                {
                    throw new Exception("'OR-attribute selectionmode for related tables' er ikke angitt.");
                }

                if (pTable.RowCount(null) == 0)
                {
                    pRow = pTable.CreateRow();
                }
                else
                {
                    pCursor = pTable.Search(null, false);
                    pRow = pCursor.NextRow();
                }

                pRow.Value[pRow.Fields.FindField("ORqueryMd")] = value;
                pRow.Store();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Lagrer modellen
        /// </summary>
        /// <param name="OID">OID på modellen</param>
        /// <param name="clearListBox">Angir om listen skal tømmes.</param>
        public void SaveModel(object OID, string modelId, string modelName, string modelDescr, 
            string modelOwner, string mainObjectClassName, string mainLayerName)
        {
            try
            {
                if (OID == null) 
                {
                    //Registrering av ny model (ny post i tabellen "AnalysisModel"
                    if (modelId.Equals(""))
                    {
                        throw new Exception("Kan ikke opprette ny modell dersom unik ModellID ikke er angitt");
                    }
                }

                SaveModelToTable(OID, modelId, modelName, modelDescr, modelOwner, mainObjectClassName, mainLayerName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Lagrer modellen i korrekt tabell
        /// </summary>
        /// <param name="OID">Modellens objektid</param>
        /// <param name="modelId">Modellens unike identifikator</param>
        /// <param name="ModelName">Modellens navn</param>
        /// <param name="ModelDescr">Beskrivelse av modellen</param>
        /// <param name="ModelOwner">Eier av modellen</param>
        /// <param name="MainObjectClassName">Hovedklassen i modellen</param>
        /// <param name="MainLyrName">Hovedlaget i modellen</param>
        public void SaveModelToTable(object OID, string ModelID, string ModelName,string ModelDescr,
            string ModelOwner, string MainObjectClassName, string MainLyrName)
        {
            try
            {
                ITable pTable;
                IStandaloneTable pStandAloneTable;
                IRow pRow;

                pStandAloneTable = HentStdAloneTableFraTOC("AnalysisModel");
                pTable = pStandAloneTable.Table;

                if (OID == null)
                {
                    //Opprett en ny modell (ny post i tabellen "AnalysisModel")
                    pRow = pTable.CreateRow();
                    if (ModelID == "")
                    {
                        //Messagebox
                    }
                    pRow.Value[pRow.Fields.FindField("MODELID")] = ModelID;
                    pRow.Value[pRow.Fields.FindField("REGDATE")] = DateTime.Now.Date;
                }
                else
                {
                    //Lagre endringer i opplysninger for eksisterende modell
                    int OIDInt = int.Parse(OID.ToString());
                    pRow = pTable.GetRow(OIDInt);
                    pRow.Value[pRow.Fields.FindField("CHDATE")] = DateTime.Now;
                }
                pRow.Value[pRow.Fields.FindField("MODELNAME")] = ModelName;
                pRow.Value[pRow.Fields.FindField("MODELOWNER")] = ModelOwner;
                pRow.Value[pRow.Fields.FindField("MAINFCL")] = MainObjectClassName;
                pRow.Value[pRow.Fields.FindField("MAINLYR")] = MainLyrName;
                pRow.Store();
            }
            catch (InvalidCastException)
            {
                throw new Exception("Feil ved konvertertering mellom to verdier. Kunne ikke lagre endring");
            }
            catch (Exception ex)
            {
                throw new Exception("Noe feil skjedde under lagring av endring. Kontakt GES. \n"+ex.Message);
            }
        }

        /// <summary>
        /// Utfører ulike sjekker på modellen og relasjonene før vinduet for feltspørring åpnes
        /// </summary>
        /// <param name="relationType">Angir relasjonstypen</param>
        /// <param name="modelId">Angir modell id</param>
        /// <param name="relTabNr">Angir nummeret på relasjons-fanene</param>
        public void editFieldQuery_Open(string relationType, string modelId, int relTabNr)
        {
            try
            {
                IStandaloneTable pStandalonetable;
                ITable pTable;
                IQueryFilter pQueryfilter;
                ICursor pCursor;
                IRow pRow;

                pStandalonetable = HentStdAloneTableFraTOC("AnalysisModelInputTables");
                pTable = pStandalonetable.Table;
                pQueryfilter = new QueryFilter();

                if (relationType.Equals("Attributt/felt"))
                {
                    pQueryfilter.WhereClause = "RELTYPE = 'Attributt/felt' AND MODELID = \"" + modelId + "\" AND RELTABNO = " + relTabNr.ToString();
                    pCursor = pTable.Search(pQueryfilter, false);
                    pRow = pCursor.NextRow();

                    if (pRow == null)
                    {
                        throw new Exception("Gyldig attributt-relasjon er ikke lagret. Kan ikke redigere attributt-spørring.");
                    }

                    string reltab = pRow.Value[pRow.Fields.FindField("RELLYR")].ToString();
                    string originRelField = pRow.Value[pRow.Fields.FindField("MAINFCL_RELFLD")].ToString();
                    string destRelField = pRow.Value[pRow.Fields.FindField("RELTAB1_RELFLD")].ToString();

                    if (string.IsNullOrEmpty(reltab) || string.IsNullOrEmpty(originRelField) || string.IsNullOrEmpty(destRelField))
                    {
                        throw new Exception("Gydlig attributt-relasjon er ikke lagret. Kan ikke redigere attributt-spørring.");
                    }
                }
                else
                {
                    pQueryfilter.WhereClause = "RELTYPE = 'Romlig' AND MODELID = \"" + modelId + "\" AND RELTABNO = " + relTabNr.ToString();
                    pCursor = pTable.Search(pQueryfilter, false);
                    pRow = pCursor.NextRow();

                    if (pRow == null)
                    {
                        throw new Exception("Gyldig spatial-relasjon er ikke lagret. Kan ikke redigere attributt-spørring.");
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
                
        /// <summary>
        /// Sletter post i tabellen "AnalysisModelInputTables" og evt "FieldAttributeQueryDesign" for den
        /// angitte modellen.
        /// </summary>
        /// <param name="modelId">Modellens unike id</param>
        /// <param name="tabNr">Nummer på relasjonstabellen</param>
        public void deleteRelatedTableInfo(string modelId, int tabNr)
        {
            try
            {
                IStandaloneTable pStandaloneTable;
                ITable pTable;
                IQueryFilter pQueryFilter;

                pStandaloneTable = HentStdAloneTableFraTOC("AnalysisModelInputTables");
                pTable = pStandaloneTable.Table;
                pQueryFilter = new QueryFilter();
                pQueryFilter.WhereClause = "RELTABNO = " + tabNr + " AND MODELID = \"" + modelId + "\"";
                pTable.DeleteSearchedRows(pQueryFilter);

                // Sletter evt. poster i tabellen "FieldAttributeQueryDesign" med angitt modellId og TabNr
                pStandaloneTable = HentStdAloneTableFraTOC("FieldAttributeQueryDesign");
                pTable = pStandaloneTable.Table;
                pQueryFilter = new QueryFilter();
                pQueryFilter.WhereClause = "TABLENO = " + tabNr + " AND MODELID = \"" + modelId + "\"";
                pTable.DeleteSearchedRows(pQueryFilter);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public List<string> getOriginAndDestinationFields(string featureLayer, string relClass)
        {
            List<string> originAndDestination = new List<string>();
            IFeatureLayer pFeatureLayer = HentFeatureLayerFraTOC(featureLayer);
            IFeatureClass pFeatureClass = pFeatureLayer.FeatureClass;

            IEnumRelationshipClass pEnumRelationshipClass = pFeatureClass.get_RelationshipClasses(esriRelRole.esriRelRoleAny);
            IRelationshipClass pRelationshipClass = pEnumRelationshipClass.Next();
            while (pRelationshipClass != null)
            {
                if (featureLayer.Equals(pRelationshipClass.OriginClass.AliasName) && relClass.Equals(pRelationshipClass.DestinationClass.AliasName))
                {
                    string originField = pRelationshipClass.OriginPrimaryKey;
                    string destinationField = pRelationshipClass.OriginForeignKey;
                    originAndDestination.Add(originField);
                    originAndDestination.Add(destinationField);
                }
                pRelationshipClass = pEnumRelationshipClass.Next();
            }
            return originAndDestination;
        }

        public List<string> getRelatedFeatureLayersAndTables(string featureLayer)
        {
            List<string> relatedLayers = new List<string>();
            IFeatureLayer pFeatureLayer = HentFeatureLayerFraTOC(featureLayer);
            IFeatureClass pFeatureClass = pFeatureLayer.FeatureClass;

            IEnumRelationshipClass pEnumRelationshipClass = pFeatureClass.get_RelationshipClasses(esriRelRole.esriRelRoleAny);
            IRelationshipClass pRelationshipClass = pEnumRelationshipClass.Next();
            while(pRelationshipClass != null)
            {
                string origin = pRelationshipClass.OriginClass.AliasName;
                string destination = pRelationshipClass.DestinationClass.AliasName;
                string originField = pRelationshipClass.OriginPrimaryKey;
                string destinationField = pRelationshipClass.DestinationPrimaryKey;
                Console.Write("");
                relatedLayers.Add(destination);
                pRelationshipClass = pEnumRelationshipClass.Next();
            }

            return relatedLayers;
        }


        /// <summary>
        /// Opprett liste over featurelayers og standalonetables som skal skrives til kombinasjonsboks
        /// </summary>
        /// <param name="listbox">Liste som skal inneholde navn på featurelayers/tabeller</param>
        /// <param name="selected">Tekst med valgt lag </param>
        /// <returns>En liste med navn på featurelayers i TOC</returns>
        public List<string> TOCFeatureLayerTableListToComboBox(List<string> listbox, string selected)
        {
            try
            {
                IMxDocument pMxDocument;
                IMap pMap;
                ILayer pLayer;
                IEnumLayer pEnumLayer;
                IStandaloneTableCollection pStandaloneTableCollection;

                pMxDocument = ArcMap.Application.Document as IMxDocument;
                pMap = pMxDocument.FocusMap;
                pStandaloneTableCollection = pMap as IStandaloneTableCollection;

                // slett evt. eksisterende featurelayernavn i listen
                listbox = new List<string>();

                // legg inn igjen eksisterende verdi
                listbox.Add(selected);

                pEnumLayer = pMap.get_Layers(null, true);
                pEnumLayer.Reset();
                pLayer = pEnumLayer.Next();
                while (pLayer != null)
                {
                    if (pLayer.Name.Equals("") == false)
                    {
                        listbox.Add(pLayer.Name);
                    }
                    pLayer = pEnumLayer.Next();
                }
                return listbox;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Opprett liste over featurelayers som skal skrives til kombinasjonsboks
        /// </summary>
        /// <param name="combobox">Liste som skal inneholde navn på featurelayers</param>
        /// <param name="selected">Tekst med valgt lag</param>
        /// <returns>Liste med navn på featurelayer i TOC</returns>
        public List<string> TOCFeatureLayerListToComboBox(List<string> combobox, string selected)
        {
            try
            {
                IMxDocument pMxDocument;
                IMap pMap;
                ILayer pLayer;
                IEnumLayer pEnumLayer;
                IStandaloneTableCollection pStandaloneTableCollection;

                pMxDocument = ArcMap.Application.Document as IMxDocument;
                pMap = pMxDocument.FocusMap;
                pStandaloneTableCollection = pMap as IStandaloneTableCollection;

                // slett evt. eksisterende featurelayernavn i listen
                combobox = new List<string>();

                // legg inn igjen eksisterende verdi
                combobox.Add(selected);

                pEnumLayer = pMap.get_Layers(null, true);
                pEnumLayer.Reset();
                pLayer = pEnumLayer.Next();
                while (pLayer != null)
                {
                    combobox.Add(pLayer.Name);
                    pLayer = pEnumLayer.Next();
                }
                return combobox;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        /// <summary>
        /// Leser inn informasjon om relasjonene til en gitt modell
        /// </summary>
        /// <param name="modelId">Modellens id</param>
        /// <returns>Liste med modellobjekter</returns>
        public List<Modell> readFromTab_AnalysisModelInputTables(string modelId)
        {
            try
            {
                List<Modell> modellene = new List<Modell>();

                IStandaloneTable pStandaloneTable;
                ITable pTable;
                IRow pRow;
                ICursor pCursor;
                IQueryFilter pQueryFilter;

                int relTabNo;
                bool inclFeatureWithoutRelation_bool;
                int antRelations;
                int inclFeatureWithoutRelation_int;
                string relationSearchType;

                string relationTable;
                string relationLyr;
                string mainFeatureClassLayer_RelationField;
                string relationTab_relationField;
                string relationType;

                string spatialRelationType;
                double bufferDistance;

                pStandaloneTable = HentStdAloneTableFraTOC("AnalysisModelInputTables");
                pTable = pStandaloneTable.Table;
                pQueryFilter = new QueryFilterClass();
                pQueryFilter.WhereClause = "MODELID = " + "'" + modelId.ToString() + "'";

                pCursor = pTable.Search(pQueryFilter, false);
                pRow = pCursor.NextRow();

                if (pRow != null)
                {
                    do
                    {
                        relTabNo = Convert.ToInt32(pRow.Value[pRow.Fields.FindField("RELTABNO")]);
                        relationTable = pRow.Value[pRow.Fields.FindField("RELTABL")].ToString();
                        relationLyr = pRow.Value[pRow.Fields.FindField("RELLYR")].ToString();
                        mainFeatureClassLayer_RelationField = pRow.Value[pRow.Fields.FindField("MAINFCL_RELFLD")].ToString();
                        relationTab_relationField = pRow.Value[pRow.Fields.FindField("RELTAB1_RELFLD")].ToString();
                        relationType = pRow.Value[pRow.Fields.FindField("RELTYPE")].ToString();
                        relationSearchType = pRow.Value[pRow.Fields.FindField("RELSEARCHTYPE")].ToString();
                        inclFeatureWithoutRelation_int = Convert.ToInt32(pRow.Value[pRow.Fields.FindField("INCLFEATWITHOUTREL")]);
                        antRelations = Convert.ToInt32(pRow.Value[pRow.Fields.FindField("RELATIONCOUNT")]);
                        object spatial = pRow.Value[pRow.Fields.FindField("SPATIALRELTYPE")].ToString();
                        spatialRelationType = spatial.ToString();
                        bufferDistance = (double) pRow.Value[pRow.Fields.FindField("BUFFERDISTANCE")];

                        if (relationSearchType.Equals("AND"))
                        {
                            relationSearchType = "AND: Selection criteria in origin objectclass and in related table";
                        }
                        else
                        {
                            relationSearchType = "OR: Selection criteria in origin objectclass or in related table";
                        }

                        if (inclFeatureWithoutRelation_int == 1)
                        {
                            inclFeatureWithoutRelation_bool = true;
                        }
                        else
                        {
                            inclFeatureWithoutRelation_bool = false;
                        }
                        modellene.Add(new Modell(relTabNo, relationLyr, relationTable, relationType, relationTab_relationField, mainFeatureClassLayer_RelationField,
                            relationSearchType, inclFeatureWithoutRelation_bool, antRelations, spatialRelationType, bufferDistance));

                        pRow = pCursor.NextRow();

                    } while (pRow != null);
                }

                return modellene;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Skriv feil i funksjon/metode til dBase-tabellen "AnalysisModulErrorLog"
        /// </summary>
        /// <param name="modulName">Navn på modul hvor feilen oppstod</param>
        /// <param name="funcName">Navn på metode hvor feilen oppstod</param>
        /// <param name="errText">Teksten som beskriver feilen.</param>
        public void WriteErrorLog(string modulName, string funcName, string errText)
        {
            try
            {
                string modelID;
                IStandaloneTable pStandaloneTable;
                ITable pTable;
                IRow pRow;

                pStandaloneTable = HentStdAloneTableFraTOC("AnalysisModulErrorLog");

                if (pStandaloneTable == null)
                {
                    //Finner ikke tabellen 'AnalysisModulErrorLog" i TOC
                    return;
                }
                modelID = null;

                //løkke gjennom forms

                pTable = pStandaloneTable.Table;
                pRow = pTable.CreateRow();
                if (modelID != null)
                {
                    pRow.Value[pRow.Fields.FindField("ModelID")] = modelID;
                }
                pRow.Value[pRow.Fields.FindField("ModuleName")] = modulName;
                pRow.Value[pRow.Fields.FindField("FuncName")] = funcName;
                pRow.Value[pRow.Fields.FindField("ErrText")] = errText;
                pRow.Value[pRow.Fields.FindField("RegDate")] = DateTime.Now;
                pRow.Store();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Lagrer en fornuftig feilmelding i tabellen "AnalysisModulLogicalErrorLog"
        /// </summary>
        /// <param name="modelId">Modellens unike identifikator</param>
        /// <param name="lyrName">Navn på laget</param>
        /// <param name="ErrText">Tekst som beskriver feilen</param>
        public void WriteToLogicalErrorLog(string ModelId, string lyrName, string ErrText)
        {
            try
            {
                IStandaloneTable pStandaloneTable = HentStdAloneTableFraTOC("AnalysisModulLogicalErrorLog");
                if (pStandaloneTable == null)
                {
                    // Messagebox
                }
                else
                {
                    ITable pTable = pStandaloneTable.Table;
                    IRow pRow = pTable.CreateRow();
                    if (ModelId != null)
                    {
                        pRow.Value[pRow.Fields.FindField("ModelID")] = ModelId;
                        pRow.Value[pRow.Fields.FindField("LyrName")] = lyrName;
                        pRow.Value[pRow.Fields.FindField("ErrText")] = ErrText;
                        pRow.Value[pRow.Fields.FindField("RegDate")] = DateTime.Now;
                        pRow.Store();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Sjekker at det er samsvar mellom feltene som skal brukes i relasjonen.
        /// </summary>
        /// <param name="layerTableName1">Navn på tabell 1</param>
        /// <param name="fieldName1">Feltnavn i tabell 1</param>
        /// <param name="layerTableName2">Navn på tabell 2</param>
        /// <param name="fieldName2">Feltnavn i tabell 2</param>
        public void relFieldTypeEvaluation(string layerTableName1, string fieldName1, 
            string layerTableName2, string fieldName2, string pageName)
        {
            try
            {
                ITable pTable1;
                ITable pTable2;
                string fldType1;
                string fldType2;

                pTable1 = tableFromLayerOrStandaloneTable(layerTableName1);
                pTable2 = tableFromLayerOrStandaloneTable(layerTableName2);

                fldType1 = getFieldType(pTable1, fieldName1);
                fldType2 = getFieldType(pTable2, fieldName2);

                if (fldType1.Equals(fieldName2))
                {
                    throw new Exception("Ikke samsvarende felttyper for angitte relasjonsfelt.");
                }
                switch (fldType1)
                {
                    case "NotSupportedRelField":
                        throw new Exception("Ikke supportert felttype for rel.klasser");
                    case "Double":
                        throw new Exception("Double (desimalfelt) anbefales ikke som relasjonfelt");
                    case "Single":
                        throw new Exception("Single (desimalfelt) anbefales ikke som relasjonsfelt");
                }
            }
            catch (Exception ex)
            {
                WriteErrorLog("VAanalyseModul", "relFieldTypeEvaluation", ex.Message);
                throw ex;
            }
        }

        /// <summary>
        /// Henter ut informasjon om hvilken type felt fieldname er.
        /// </summary>
        /// <param name="pTable">Tabellen som feltet befinner seg i.</param>
        /// <param name="fieldName">Feltnavnet som skal finnes.</param>
        /// <returns>Tekststreng som sier hvilken type feltet er.</returns>
        private string getFieldType(ITable pTable, string fieldName)
        {
            try
            {
                IFields pFields;
                IField pField;

                int index = pTable.FindField(fieldName);
                if (index == -1)
                {
                    throw new Exception("Feltet fantes ikke.");
                }
                pFields = pTable.Fields;
                pField = pFields.Field[index];

                switch (pField.Type)
                {
                    case esriFieldType.esriFieldTypeSmallInteger:
                        return "Short Integer";
                    case esriFieldType.esriFieldTypeInteger:
                        return "Long Integer";
                    case esriFieldType.esriFieldTypeString:
                        return "Text";
                    case esriFieldType.esriFieldTypeOID:
                        return "Long integer";
                    case esriFieldType.esriFieldTypeDouble:
                        return "Double";
                    case esriFieldType.esriFieldTypeSingle:
                        return "Single";
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Leter gjennom TOC (table of contents) for å finne tabellen som er angitt
        /// ved layerTableName.
        /// </summary>
        /// <param name="layerTableName">Navnet på tabellen som skal finnes</param>
        /// <returns>Tabellen som ble funnet.</returns>
        private ITable tableFromLayerOrStandaloneTable(string layerTableName)
        {
            try
            {
                IFeatureLayer pFeatureLayer;
                IStandaloneTable pStandaloneTable;

                pStandaloneTable = HentStdAloneTableFraTOC(layerTableName);

                // Dersom layerTableNAme henviser til en tabell i TOC
                if (pStandaloneTable != null)
                {
                    return pStandaloneTable.Table;
                }
                else
                {
                    // sjekk om layerTableName henviser til et featurelayer
                    pFeatureLayer = HentFeatureLayerFraTOC(layerTableName);
                    if (pFeatureLayer != null)
                    {
                        return pFeatureLayer as ITable;
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Kjører hele analysemodellen
        /// </summary>
        /// <param name="modelId">Modellens id</param>
        /// <returns>Angir at modellen er kjørt</returns>
        public bool runAnalysisModel(string modelId)
        {
            try
            {
                ArcGIS_Methods arcgis = new ArcGIS_Methods();
                IStandaloneTable pStandaloneTable;
                ITable pTable;
                ITable pTableInput;
                IQueryFilter pQueryfilter;
                ICursor pCursor;
                IRow pRow;

                string relTabNr;
                string lyrName;
                string relSearchType;
                string spatialSelType = "";
                string spatialRelType = "";
                int antRelasjoner;
                string bufferDistance;
                string selType = "";
                string relTableName;
                string relFieldName;
                string relType;
                string originRelFieldName;
                int includeFeaturesWithoutRel;

                string or_AttributeRelationQueryMode = getOrAttributeSelectionMode();
                if (or_AttributeRelationQueryMode != null || or_AttributeRelationQueryMode.Equals(""))
                {
                    or_AttributeRelationQueryMode = "After";
                }
                if (RelFieldQA(modelId) == false)
                {
                    throw new Exception("Kan ikke kjøre modellen på grunn av feil.");
                }

                // 1. Ufør featureselection i hoved-obj. klasse, "select all" dersom det ikke er satt egenskapskriterie
                // Bygg  egenskapsspørring

                string totalStr = buildAttributeQuery(modelId, 0);
                string mainLyrName = modelInputTablesGetLyrName(modelId, 0);
                if (mainLyrName.Equals(""))
                {
                    throw new Exception("Modelnavn er ikke angitt. Kan ikke kjøre modellen på grunn av feil.");
                }

                if (totalStr.Equals(""))
                {
                    totalStr = null;
                }

                // Selekterer alle features i featurelayer "LyrNAme" 
                // Selekterer features som tilfredsstiller SQL-spørringen TotalStr
                featureLayerSQLSelection(mainLyrName, totalStr, false);

                // 2. sjekk om analysemodellen kun involverer hoved-obj.kl
                if (relatedTables(modelId) == false)
                {
                    //Analysemodellen involverer kun hoved-obj.kl
                    goto refreshAndMessage;
                }

                // utfør seleksjon i hoved-obj-klasse basert på evt. OR-attributt relasjoner, dersom
                // OR_attributeRelationQueryMode = "Before Spatial Queries and before OR-attribute
                // relation queries
                if (or_AttributeRelationQueryMode.Equals("Before"))
                {
                    runAnalysisModel_AttributeSearchOR(modelId);
                }


                // loop  gjennom alle poster i AnalysisModelInputTables der RELTYPE = 'Spatial relation' for angitt ModelID
                pStandaloneTable = HentStdAloneTableFraTOC("AnalysisModelInputTables");
                pTable = pStandaloneTable.Table;
                pQueryfilter = new QueryFilter();


                // RELTYPE = 'spatial relation'
                pQueryfilter.WhereClause = "RELTYPE = 'Romlig' AND MODELID = \"" + modelId + "\"";
                pCursor = pTable.Search(pQueryfilter, false);
                pRow = pCursor.NextRow();

                while (pRow != null)
                {
                    relTabNr = Convert.ToString(pRow.Value[pRow.Fields.FindField("RELTABNO")].ToString());

                    if (pRow.Value[pRow.Fields.FindField("RELLYR")] != null)
                    {
                        lyrName = pRow.Value[pRow.Fields.FindField("RELLYR")].ToString();
                    }
                    else
                    {
                        lyrName = "";
                    }
                    relSearchType = pRow.Value[pRow.Fields.FindField("RELSEARCHTYPE")].ToString(); // AND/OR
                    spatialRelType = pRow.Value[pRow.Fields.FindField("SPATIALRELTYPE")].ToString(); // Intersects / Are within a distance of

                    if (pRow.Value[pRow.Fields.FindField("BUFFERDISTANCE")] != null)
                    {
                        bufferDistance = ((double)pRow.Value[pRow.Fields.FindField("BUFFERDISTANCE")]).ToString();
                    }
                    else
                    {
                        bufferDistance = "0";
                    }

                    totalStr = buildAttributeQuery(modelId, int.Parse(relTabNr));
                    //totalStr = buildAttributeQuery(modelId, 0);
                    if (totalStr.Equals(""))
                    {
                        totalStr = "";
                    }

                    // Utfør featureselection (attribute selection) i relatert tabell som input til select by location
                    featureLayerSQLSelection(lyrName, totalStr, false);

                    switch (spatialRelType)
                    {
                        case "Intersects":
                            spatialSelType = "INTERSECT";
                            break;
                        case "Are within a distance of":
                            spatialSelType = "WITHIN_A_DISTANCE";
                            break;
                    }
                    switch (relSearchType)
                    {
                        case "AND":
                            selType = "SUBSET_SELECTION";
                            break;
                        case "OR":
                            selType = "ADD_TO_SELECTION";
                            break;
                    }

                    // Utfør "Select By Location", søk mainLyr (selekter poster i mainLyr basert på geografi i Lyr)
                    arcgis.runGPTool_selectionLayerByLocation(mainLyrName, lyrName, spatialSelType, bufferDistance, selType);

                    pRow = pCursor.NextRow();
                }

                pQueryfilter = new QueryFilter();
                pQueryfilter.WhereClause = "RELTYPE = 'Attributt/felt' AND RELSEARCHTYPE = 'AND' AND MODELID = \"" + modelId + "\"";

                if (pTable.RowCount(pQueryfilter) == 0)
                {
                    goto refreshAndMessage;
                }

                // RELTYPE = 'Attributt/felt'
                pCursor = pTable.Search(pQueryfilter, false);
                pRow = pCursor.NextRow();

                while (pRow != null)
                {
                    relTabNr = ((short)pRow.Value[pRow.Fields.FindField("RELTABNO")]).ToString();

                    if (pRow.Value[pRow.Fields.FindField("RELLYR")] != null)
                    {
                        lyrName = pRow.Value[pRow.Fields.FindField("RELLYR")].ToString();
                    }
                    else
                    {
                        lyrName = "";
                    }
                    if (pRow.Value[pRow.Fields.FindField("RELTABL")] != null)
                    {
                        relTableName = pRow.Value[pRow.Fields.FindField("RELTABL")].ToString();
                    }
                    else
                    {
                        relTableName = "";
                    }
                    if (pRow.Value[pRow.Fields.FindField("RELTAB1_RELFLD")] != null)
                    {
                        relFieldName = pRow.Value[pRow.Fields.FindField("RELTAB1_RELFLD")].ToString();
                    }
                    else
                    {
                        relFieldName = "";
                    }

                    if (pRow.Value[pRow.Fields.FindField("MAINFCL_RELFLD")] != null)
                    {
                        originRelFieldName = pRow.Value[pRow.Fields.FindField("MAINFCL_RELFLD")].ToString();
                    }
                    else
                    {
                        originRelFieldName = "";
                    }
                    antRelasjoner = Convert.ToInt32(pRow.Value[pRow.Fields.FindField("RELATIONCOUNT")]);
                    relType = pRow.Value[pRow.Fields.FindField("RELTYPE")].ToString();
                    relSearchType = pRow.Value[pRow.Fields.FindField("RELSEARCHTYPE")].ToString();
                    includeFeaturesWithoutRel = Convert.ToInt32(pRow.Value[pRow.Fields.FindField("INCLFEATWITHOUTREL")]);

                    totalStr = buildAttributeQuery(modelId, int.Parse(relTabNr));
                    if (totalStr.Equals(""))
                    {
                        totalStr = null;
                    }

                    objectClassSqlSearch_SelectRelatedFeatureInOriginLayer2(relTabNr, mainLyrName, originRelFieldName, lyrName, relFieldName, totalStr, esriSetOperation.esriSetIntersection, includeFeaturesWithoutRel, antRelasjoner);

                    pRow = pCursor.NextRow();
                }
                if (or_AttributeRelationQueryMode.Equals("After"))
                {
                    runAnalysisModel_AttributeSearchOR(modelId);
                }

            refreshAndMessage:
                featureSelectionRefreshView(mainLyrName);

                return true;
            }
            catch (COMException ce)
            {
                if ((uint)ce.ErrorCode == 0x80041538)
                {
                    throw new Exception("Kunne ikke gjennomføre spørringen. Har du AND/OR på feil plass?");
                }
                else
                {
                    throw new Exception("Det skjedde noe feil med spørringen. Feilmeldingen er \n"+ce.ErrorCode);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Det skjedde dessverre noe feil. Feilmeldingen er \n"+ex.Message);
            }
            
        }

        /// <summary>
        /// Oppdaterer skjermbildet med utført seleksjon
        /// </summary>
        /// <param name="mainLyrName">Navn på hovedlayer</param>
        private bool featureSelectionRefreshView(string mainLyrName)
        {
            try
            {
                IMxDocument pMxDoc = ArcMap.Application.Document as IMxDocument;
                IMap pMap = pMxDoc.FocusMap;
                IActiveView pActiveView = pMap as IActiveView;
                IFeatureLayer pFeatureLayer;
                IFeatureSelection pFeatureSelection;
                ISelectionEvents pSelectionEvents = pMap as ISelectionEvents;

                pFeatureLayer = HentFeatureLayerFraTOC(mainLyrName);
                pFeatureSelection = pFeatureLayer as IFeatureSelection;

                pSelectionEvents.SelectionChanged();
                pActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeoSelection, pFeatureLayer, null);
                pActiveView.ShowSelection = true;

                return true;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
                                
        /// <summary>
        /// Kjører attributtsøk
        /// </summary>
        /// <param name="modelId">Modellens unike identifikator</param>
        private void runAnalysisModel_AttributeSearchOR(string modelId)
        {
            try
            {
                IStandaloneTable pStandaloneTable;
                ITable pTable;
                ITable pTableInput;
                IQueryFilter pQueryfilter;
                ICursor pCursor;
                IRow pRow;

                string totalStr;
                string mainLyrName;
                string originRelFieldName;
                string layerName;
                string relFieldName;
                string relTabNr;

                mainLyrName = modelInputTablesGetLyrName(modelId, 0);

                if (mainLyrName == null)
                {
                    return;
                }

                pStandaloneTable = HentStdAloneTableFraTOC("AnalysisModelInputTables");
                pTable = pStandaloneTable.Table;

                pQueryfilter = new QueryFilter();
                pQueryfilter.WhereClause = "RELTYPE = 'Attributt/felt' AND RELSEARCHTYPE = 'OR' AND MODELID = \"" + modelId + "\"";

                pCursor = pTable.Search(pQueryfilter, false);
                pRow = pCursor.NextRow();

                while (pRow != null)
                {
                    relTabNr = pRow.Value[pRow.Fields.FindField("RELTABNO")].ToString();

                    if (pRow.Value[pRow.Fields.FindField("RELLYR")] != null)
                    {
                        layerName = pRow.Value[pRow.Fields.FindField("RELLYR")].ToString();
                    }
                    else
                    {
                        layerName = "";
                    }


                    if (pRow.Value[pRow.Fields.FindField("RELTAB1_RELFLD")] != null)
                    {
                        relFieldName = pRow.Value[pRow.Fields.FindField("RELTAB1_RELFLD")].ToString();
                    }
                    else
                    {
                        relFieldName = "";
                    }

                    if (pRow.Value[pRow.Fields.FindField("MAINFCL_RELFLD")] != null)
                    {
                        originRelFieldName = pRow.Value[pRow.Fields.FindField("MAINFCL_RELFLD")].ToString();
                    }
                    else
                    {
                        originRelFieldName = "";
                    }

                    totalStr = buildAttributeQuery(modelId, int.Parse(relTabNr));
                    if (totalStr.Equals(""))
                    {
                        totalStr = null;
                    }

                    objectClassSqlSearch_SelectRelatedFeatureInOriginLayer2(relTabNr, mainLyrName, originRelFieldName, layerName, relFieldName, totalStr, esriSetOperation.esriSetUnion, 0,0);

                    pRow = pCursor.NextRow();
                }
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        /// <summary>
        /// Selekterer relaterte objekter i "originLayer"
        /// </summary>
        /// <param name="relTabNr">Nummeret på relasjonsfanen</param>
        /// <param name="originLayerName">Navn på hovedtabell/layer</param>
        /// <param name="originRelFieldName">Navn på felt i hovedtabell/layer</param>
        /// <param name="destinationLayerName">Navn på koblingstabell</param>
        /// <param name="relFieldName">Feltnavn i koblingstabell</param>
        /// <param name="sqlString">SQL-spørring</param>
        /// <param name="esriSetOperation"></param>
        /// <param name="inclcudeFeatureWithoutRel">Inkluderer objekter uten relasjon?</param>
        private void objectClassSqlSearch_SelectRelatedFeatureInOriginLayer2(string relTabNr, string originLayerName, 
            string originRelFieldName, string destinationLayerName, string relFieldName, string sqlString, 
            esriSetOperation esriSetOperation, int inclcudeFeatureWithoutRel, int antRelasjoner)
        {
            try
            {
                IFeatureLayer pFeaturelayer;
                IFeatureSelection pFeatureSelection = null;
                IStandaloneTable pStandaloneTable;
                ITable pTableInput = null;
                ITable pTableFeatureLayer;
                ITableSelection pTableSelection = null;
                ISelectionSet2 pSelectionSet;
                ISelectionSet2 pSelectionSetIni = null;
                ISelectionSet2 pSelectionSetNew;
                ISelectionSet pSelectionSetTmp = null;
                ISelectionSet pSelectionSetHasNotRelatedRecords;
                IObjectClass pObjClass_OriginLayer;
                IObjectClass pObjClass_DestLayer;

                IMemoryRelationshipClassFactory pMemRelFact;
                IRelationshipClass pRelationClass;
                ISet pRelateSet;

                IQueryFilter pQueryfilter;
                IRow pRow;
                IRow pRow2;
                ICursor pCursor;

                // Definer relatert layer / tabell (DestinationLayer), som det skal søkes etter
                pTableInput = tableFromLayerOrStandaloneTable(destinationLayerName);
                if (pTableInput == null)
                {
                    throw new Exception("Finner ikke tabell/layer '"+destinationLayerName+"'. Kan ikke gjennomføre analyse");
                }
                pObjClass_DestLayer = objectClassFromLayerOrStandaloneTable(destinationLayerName) as IObjectClass;

                // Definer originLayer det skal selekteres i, basert på søk i destinationLayer

                string objClassType = objectClassType(originLayerName);
                switch (objClassType)
                {
                    case "FeatureLayer":
                        pFeaturelayer = HentFeatureLayerFraTOC(originLayerName);
                        if (pFeaturelayer == null)
                        {
                            throw new Exception("Finner ikke layer '" + originLayerName + "'. Kan ikke gjennomføre analyse");
                        }
                        pTableFeatureLayer = pFeaturelayer as ITable;

                        // Hent opprinnelig selectionSet, som inneholder OIDs for allerede selekterte features
                        pFeatureSelection = pFeaturelayer as IFeatureSelection;
                        pSelectionSet = pFeatureSelection.SelectionSet as ISelectionSet2;
                        if(inclcudeFeatureWithoutRel == 1)
                        {
                            pSelectionSetIni = pFeatureSelection.SelectionSet as ISelectionSet2;
                        }
                        break;
                    case "Stanalonetable":
                        pStandaloneTable = HentStdAloneTableFraTOC(originLayerName);
                        pTableFeatureLayer = pStandaloneTable.Table;
                        pTableSelection = pStandaloneTable as ITableSelection;
                        pSelectionSet = pTableSelection.SelectionSet as ISelectionSet2;
                        if (inclcudeFeatureWithoutRel == 1)
                        {
                            pSelectionSetIni = pTableSelection.SelectionSet as ISelectionSet2;
                        }
                        break;
                    default:
                        throw new Exception("OriginLayerName '" + originLayerName + "' er verken Standalonetable eller Featurelayer. Kan ikke gjennomføre analysen.");
                }

                // Opprett nytt og tomt selectionset for originLayer (dvs. for layer/tabell det skal selekteres i)
                pSelectionSetNew = pTableFeatureLayer.Select(null, esriSelectionType.esriSelectionTypeSnapshot, esriSelectionOption.esriSelectionOptionEmpty, null) as ISelectionSet2;

                // Opprett virituell 1-m relasjon mellom relatert layer/tabell (destinationLayer) og hoved-layer (originLayer)
                pObjClass_OriginLayer = objectClassFromLayerOrStandaloneTable(originLayerName);
                pMemRelFact = new MemoryRelationshipClassFactory();
                pRelationClass = pMemRelFact.Open("TabletoLayer", pObjClass_DestLayer, relFieldName, pObjClass_OriginLayer, originRelFieldName, "forward", "backward", esriRelCardinality.esriRelCardinalityOneToMany);
                //pRelationClass = pMemRelFact.Open("TabletoLayer", pObjClass_OriginLayer, originRelFieldName, pObjClass_DestLayer, relFieldName, "forward", "backward", esriRelCardinality.esriRelCardinalityOneToMany);

                // definer søk i destinationLayer
                if (string.IsNullOrEmpty(sqlString))
                {
                    pQueryfilter = null;
                }
                else
                {
                    pQueryfilter = new QueryFilter();
                    pQueryfilter.WhereClause = sqlString;
                }
                pCursor = pTableInput.Search(pQueryfilter, false);
                ICursor pCursor2 = pTableInput.Search(pQueryfilter, false);
                //Loop gjennom alle features/poster i relatert layer/tabell (destinationLayer) som tilfredsstiller søkekritere
                // Finn OID for relaterte features / poster i originLayer og legg OID til selectionSet (pSelectionSetNew)
                pRow = pCursor.NextRow();
                int antall = 0;
                ISet pSet = new Set();
                Dictionary<string, int> testDict = new Dictionary<string, int>();
                
                int countTmp = 2;
                
                List<int> oidsList = new List<int>();
                try
                {
                    if (antRelasjoner > 0)
                    {
                        while ((pRow = pCursor.NextRow()) != null)
                        {
                            string sid = pRow.get_Value(pRow.Fields.FindField("SID")).ToString();
                            if (testDict.ContainsKey(sid) == false)
                            {
                                testDict.Add(sid, 1);
                            }
                            else
                            {
                                testDict[sid] = testDict[sid] + 1;
                            }
                        }
                    }

                    
                    IRow pRow3 = pCursor2.NextRow();
                    while ((pRow3 = pCursor2.NextRow()) != null){
                        if (oidsList.Contains(pRow3.OID) == false)
                        {
                            if (antRelasjoner > 0)
                            {
                                string sid = pRow3.get_Value(pRow3.Fields.FindField("SID")).ToString();
                                if (testDict[sid] >= antRelasjoner)
                                {
                                    pSet.Add(pRow3);
                                }
                            }
                            else
                            {
                                oidsList.Add(pRow3.OID);
                                pSet.Add(pRow3);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Fantes allerede");
                        }
                    }
                }
                catch (COMException comException)
                {
                    throw comException;
                }


                ISet pRelatedSet = pRelationClass.GetObjectsRelatedToObjectSet(pSet);
                
                IRow pRelatedRow = pRelatedSet.Next() as IRow;
                while ((pRelatedRow = pRelatedSet.Next() as IRow) != null)
                {
                    pSelectionSetNew.Add(pRelatedRow.OID);
                    pRelatedRow = pRelatedSet.Next() as IRow;
                }
                int relatedCount = pRelatedSet.Count;

                // Kombiner opprinnelig selectionSet for originLayer med selectionSet for relatert søk (pSelectionSetNew)
                // som inneholder OIDer for features/poster i originLayer som er relatert til features/poster i destinationLayer
                //som tilfredsstiller søkekriterie. Opprinnelig selectionSet (pSelectionSet) settes lik det nye resultat-settet (pSelectionSelTmp)
                pSelectionSet.Combine(pSelectionSetNew, esriSetOperation, out pSelectionSetTmp);
                
                pSelectionSet = pSelectionSetTmp as ISelectionSet2;

                if(inclcudeFeatureWithoutRel == 1)
                {
                    pSelectionSetTmp = null;
                    pSelectionSetHasNotRelatedRecords = selectionSetHasNotRelatedRecords2(pSelectionSetIni, pTableFeatureLayer, pObjClass_DestLayer, relFieldName, pObjClass_OriginLayer, originRelFieldName);
                    if (pSelectionSetHasNotRelatedRecords != null)
                    {
                        pSelectionSet.Combine(pSelectionSetHasNotRelatedRecords, esriSetOperation.esriSetUnion, out pSelectionSetTmp);
                        pSelectionSet = pSelectionSetTmp as ISelectionSet2;
                    }
                }
                if (objClassType.Equals("FeatureLayer"))
                {
                    pFeatureSelection.SelectionSet = pSelectionSet;
                    pFeatureSelection.SelectionChanged();
                }
                else
                {
                    pTableSelection.SelectionSet = pSelectionSet;
                    pTableSelection.SelectionChanged();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Genererer et selectionSet for alle selekterte features/records i OriginLAyer som ikke har relaterte poster i 
        /// destinationLayer. 
        /// </summary>
        /// <param name="pSelectionSetIni">Eksisterende seleksjon</param>
        /// <param name="pTableFeatureLayer">Tabell/Layer med eksisterende seleksjon</param>
        /// <param name="pObjClass_DestLayer">Objektklassen/laget det skal selekteres på</param>
        /// <param name="relFieldName">Feltnavnet som relasjonen bygges på i "nytt datasett"</param>
        /// <param name="pObjClass_OriginLayer">Tabellen/layer som inneholder de opprinnelige dataene</param>
        /// <param name="originRelFieldName">Navn på feltet som det skal bygges selekson på i opprinnelig datasett</param>
        /// <returns>En ny seleksjon</returns>
        private ISelectionSet selectionSetHasNotRelatedRecords2(ISelectionSet2 pSelectionSetIni, ITable pTableFeatureLayer, 
            IObjectClass pObjClass_DestLayer, string relFieldName, IObjectClass pObjClass_OriginLayer, string originRelFieldName)
        {
            try
            {
                ISelectionSet2 pSelectionSetNew;
                ISet pRelateSet;
                IRow pRow;
                ICursor pCursor;
                IMemoryRelationshipClassFactory pMemRelFact;
                IRelationshipClass pRelClass;
                ISelectionSet pSelectionSetHasNotRelatedRecords2;

                // Opprett nytt og tomt selectionSet for originLayer
                pSelectionSetNew = pTableFeatureLayer.Select(null, esriSelectionType.esriSelectionTypeSnapshot, esriSelectionOption.esriSelectionOptionEmpty, null) as ISelectionSet2;

                // Opprett virituell 1-m relasjon mellom OriginLayer og DestinationLayer
                pMemRelFact = new MemoryRelationshipClassFactory();
                pRelClass = pMemRelFact.Open("TabletoLayer", pObjClass_OriginLayer, originRelFieldName, pObjClass_DestLayer, relFieldName, "forward", "backward", esriRelCardinality.esriRelCardinalityOneToMany);

                // Loop i gjennom alle poster i pSelectionSetIni (OriginLayer) og sjekk om det er relaterte features / poster i DestinationLayer
                // Dersom relatert(e) post(er) i DestinationLayer: Legg OID for feature/row i OriginLayer til pSelectionSetNew
                pSelectionSetIni.Search(null, false, out pCursor);
                pRow = pCursor.NextRow();
                while (pRow != null)
                {
                    pRelateSet = pRelClass.GetObjectsRelatedToObject(pRow as IObject);
                    if (pRelateSet.Count > 0)
                    {
                        pSelectionSetNew.Add(pRow.OID);
                    }
                    pRow = pCursor.NextRow();
                }

                // Resultat SelectionSet: SelSetHasNotRelatedRecords2 = pSelectionSetIni - pSelectionSetNew
                // Dvs. initielt selekterte poster i OriginLayer - poster som har relasjon = Poster som ikke har relasjon i DestinationLayer
                pSelectionSetIni.Combine(pSelectionSetNew as ISelectionSet, esriSetOperation.esriSetDifference, out pSelectionSetHasNotRelatedRecords2);
                return pSelectionSetHasNotRelatedRecords2;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Sjekker om layerTableName er Standalonetable eller Featurelayer.
        /// </summary>
        /// <param name="layerTableName">Navn på layer</param>
        /// <returns>Tekst</returns>
        private string objectClassType(string layerTableName)
        {
            try
            {
                IFeatureLayer pFeatureLayer;
                IStandaloneTable pStandaloneTable;

                pStandaloneTable = HentStdAloneTableFraTOC(layerTableName);

                // Dersom layerTableName henviser til en tabell i TOC
                if (pStandaloneTable != null)
                {
                    return "StandaloneTable";
                }
                else
                {
                    // LayerTableName henviser til en featureklasse
                    pFeatureLayer = HentFeatureLayerFraTOC(layerTableName);
                    if (pFeatureLayer != null)
                    {
                        return "FeatureLayer";
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Sjekker ut om modellen med gitt modelId har relaterte tabeller eller ikke. Dette
        /// finnes det informasjon om i 'AnalaysisModelInputTables'
        /// </summary>
        /// <param name="modelId">Modellens unike identifikator</param>
        /// <returns>Informasjon om det ble funnet forekomster av relaterte tabeller</returns>
        private bool relatedTables(string modelId)
        {
            try
            {
                IStandaloneTable pStandaloneTable;
                ITable pTable;
                IQueryFilter pQueryfilter;

                pStandaloneTable = HentStdAloneTableFraTOC("AnalysisModelInputTables");
                pTable = pStandaloneTable.Table;
                pQueryfilter = new QueryFilter();
                pQueryfilter.WhereClause = "MODELID = \"" + modelId + "\"";

                // sjekker om det ble funnet noen forekomster av relaterte tabeller til modellen
                if (pTable.RowCount(pQueryfilter) > 0)
                {
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
        /// Selekterer features som tilfredsstiller SQL-spørringen TotalStr
        /// </summary>
        /// <param name="mainLyrName">Hovedlag i analysen</param>
        /// <param name="totalStr">SQL-spørring</param>
        /// <param name="existingSelection">Angir om eksisterende seleksjon skal være med i utvalget</param>
        private void featureLayerSQLSelection(string featureLayerName, string sqlString, bool existingSelection)
        {
            try
            {
                IFeatureLayer pFeatureLayer;
                IFeatureSelection pFeatureSelection;
                ISelectionSet pSelectionSet;
                IQueryFilter pQueryfilter;

                pFeatureLayer = HentFeatureLayerFraTOC(featureLayerName);
                pFeatureSelection = pFeatureLayer as IFeatureSelection;

                // Sjekker om det er definert noen sql-setning.
                if (string.IsNullOrEmpty(sqlString) == true)
                {
                    pQueryfilter = null;
                }
                else
                {
                    pQueryfilter = new QueryFilter();
                    pQueryfilter.WhereClause = sqlString;
                }

                // Brukeren har huket av for valg i eksisterende utvalg, og existingSelection er derfor true
                if (existingSelection == true)
                {
                    // Søk i eksisterende utvalg
                    if (pFeatureSelection.SelectionSet.Count == 0)
                    {
                        throw new Exception("Featureklassen har ingen selekterte objekter. Kan derfor ikke søke i eksisterende utvalg.");
                    }
                    else
                    {
                        pFeatureSelection.SelectFeatures(pQueryfilter, esriSelectionResultEnum.esriSelectionResultAnd, false);
                    }
                }
                else
                {
                    pFeatureSelection.SelectFeatures(pQueryfilter, esriSelectionResultEnum.esriSelectionResultNew, false);
                }
                pFeatureSelection.SelectionChanged();
            }
            catch (Exception ex)
            {
                WriteErrorLog("VAAnalyseModul", "featureLayerSQLSelection", ex.Message);
                throw ex;
            }
        }

        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fieldName"></param>
        /// <param name="description"></param>
        /// <param name="pTable"></param>
        /// <returns></returns>
        private string getDomainCode(string tabellnavn, string fieldName, string description, ITable pTable)
        {
            string verdi = "";
            if (description.Contains("-"))
            {
                string[] feltVerdi = description.Split('-');
                verdi = feltVerdi[0];
            }
            else
            {
                verdi = description;
            }
            return verdi;
        }

        /// <summary>
        /// Lager en attributtspørring basert på informasjonen som tilhører modelid.
        /// </summary>
        /// <param name="modelId">Modellens unike identifikator</param>
        /// <param name="relTabNr">Nummeret på relasjonsfanen</param>
        /// <returns>SQL-spørring basert på informasjonen til modellen</returns>
        private string buildAttributeQuery(string modelId, int relTabNr)
        {
            try
            {
                IStandaloneTable pStandaloneTable;
                ITable pTable;
                IRow pRow;
                ICursor pCursor;
                IQueryFilter pQueryfilter;
                string layerTableName;
                string str1;
                string str2;
                string str3;
                string str4;
                string str5;
                string str6;
                string str7;
                string strPart;
                string totalString;
                string listeUttrykk;
                string liste;
                string listeVerdi ="";
                string searchChar;
                int pos;

                layerTableName = modelInputTablesGetLyrName(modelId, relTabNr);
                pStandaloneTable = HentStdAloneTableFraTOC("FieldAttributeQueryDesign");
                pTable = pStandaloneTable.Table;

                pQueryfilter = new QueryFilter();

                //Lager sammensatt egenskapsspørring
                pQueryfilter.WhereClause = "TABLENO = " + relTabNr + " AND MODELID = \"" + modelId + "\"";

                pCursor = pTable.Search(pQueryfilter, false);
                pRow = pCursor.NextRow();

                totalString = "";
                
                while (pRow != null)
                {
                    string tabell = pRow.Value[pRow.Fields.FindField("TABLENAME")].ToString();
                    str1 = pRow.Value[pRow.Fields.FindField("AND_OR")].ToString();
                    str2 = pRow.Value[pRow.Fields.FindField("P1")].ToString();
                    str3 = pRow.Value[pRow.Fields.FindField("FIELDNAME")].ToString();
                    str3 = findFieldName(layerTableName, str3);
                    str3 = QuotedFieldName(str3, layerTableName);
                    str4 = pRow.Value[pRow.Fields.FindField("OPERATOR")].ToString();
                    str5 = pRow.Value[pRow.Fields.FindField("FIELDVALUE")].ToString();
                    string test = getDomainCode(layerTableName, str3, str5,pTable);
                    str5 = quotedFieldValue(test, str3, layerTableName);

                    str6 = pRow.Value[pRow.Fields.FindField("P2")].ToString();
                    str7 = pRow.Value[pRow.Fields.FindField("FIELDVALUELIST")].ToString();

                    if ((str1 != null) && (str1.Equals("") == false))
                    {
                        str1 = " " + str1 + " ";
                    }

                    if ((str6 != null) && (str6.Equals("") == false))
                    {
                        if (string.IsNullOrEmpty(str1))
                        {
                            str6 = str6 + " ";
                        }
                    }

                    if ((str7 != null) && (str7.Equals("") == false))
                    {
                        // Eksempel:
                        // (FELTNAVN = 125 Or FELTNAVN = 170 Or FELTNAVN = 200)
                        // StrPart = Str1 & "(" & Str3 & " = " ListValue1 & " " & Str3 & " = " & ListValue2  & " " & Str3 & " = " & ListValue3 & ")"
                        // 'Loop i gjennom verdier i semikolon-separert liste i Str7

                        listeUttrykk = str1 + "(";
                        liste = str7 + ";";
                        searchChar = ";";
                        pos = liste.IndexOf(searchChar);

                        while (pos >= 0)
                        {
                            listeVerdi = liste.Substring(0,Math.Min(pos,liste.Length));
                            listeVerdi = quotedFieldValue(listeVerdi, str3, layerTableName);
                            liste = liste.Substring(0, pos);
                            pos = liste.IndexOf(searchChar);
                            listeUttrykk = listeUttrykk + str3 + " = " + listeVerdi + " OR ";
                        }

                        // sletter siste forekomst av " OR "
                        listeUttrykk = listeUttrykk + ";";
                        searchChar = " OR ;";
                        pos = listeUttrykk.IndexOf(searchChar);
                        listeUttrykk = listeUttrykk.Substring(0, pos);
                        strPart = listeUttrykk + ")";
                    }
                    else
                    {
                        strPart = str2 + str3 + " " + str4 + " " + str5 + str6 + str1;
                    }

                    totalString = totalString + strPart;
                    pRow = pCursor.NextRow();
                }
                return totalString;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Finner ut hvilken type feltet er, og setter på tilhørende apostrof dersom feltet er et
        /// tekstfelt.
        /// </summary>
        /// <param name="fieldValue">Tekststreng med feltverdi</param>
        /// <param name="fieldName">Navn på feltet</param>
        /// <param name="layerTableName">Navn på laget/tabeleln</param>
        /// <returns>Tekststreng med feltverdi</returns>
        private string quotedFieldValue(string fieldValue, string fieldName, string layerTableName)
        {
            try
            {
                ITable pTable;
                string fldType;
                string quote ="";

                pTable = tableForLayerTable(layerTableName);
                fldType = fieldType(pTable, fieldName);

                if (fldType.Equals("Text"))
                {
                    quote = "'";
                }
                if (quote.Equals("") == false)
                {
                    return quote + fieldValue + quote;
                }
                else
                {
                    return fieldValue;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private string findFieldName(string table, string fieldName)
        {
            ITable pTable;
            IFeatureLayer2 pFeatureLayer = HentFeatureLayerFraTOC(table) as IFeatureLayer2;
            if (pFeatureLayer != null)
            {
                pTable = pFeatureLayer as ITable;
            }
            else
            {
                IStandaloneTable pStandaloneTable = HentStdAloneTableFraTOC(table);
                pTable = pStandaloneTable.Table;
            }


            for (int i = 0; i < pTable.Fields.FieldCount; i++)
            {
                if (pTable.Fields.Field[i].AliasName == fieldName)
                {
                    return pTable.Fields.Field[i].Name;
                }
            }
            return null;
        }

        /// <summary>
        /// Sjekker hvilket formatet feltet det spørres om er i.
        /// </summary>
        /// <param name="pTable">Navn på tabellen</param>
        /// <param name="fieldName">Navn på feltet</param>
        /// <returns>Beskrivelse av format på feltet</returns>
        private string fieldType(ITable pTable, string fieldName)
        {
            try
            {
                IFields pFields;
                IField pField;
                if (pTable == null)
                {
                    return null;
                }
                if (fieldName == null)
                {
                    return null;
                }
                List<string> fields = new List<string>();
                for (int j = 0; j < pTable.Fields.FieldCount; j++)
                {
                    fields.Add(pTable.Fields.Field[j].Name);
                }
                int fieldIndex = -1;

                if (pTable.FindField(fieldName) > -1)
                {
                    fieldIndex = pTable.FindField(fieldName);
                }
                else
                {
                    fieldIndex = pTable.FindField(fieldName);
                }

                int i = pTable.FindField(fieldName);
                pFields = pTable.Fields;
                pField = pFields.Field[i];
                switch (pField.Type)
                {
                    case esriFieldType.esriFieldTypeSmallInteger:
                        return "Long Integer";
                    case esriFieldType.esriFieldTypeInteger:
                        return "Long Integer";
                    case esriFieldType.esriFieldTypeString:
                        return "Text";
                    case esriFieldType.esriFieldTypeOID:
                        return "Long Integer";
                    default:
                        return "NotSupportedRelField";
                }
            }
            catch (ArgumentException)
            {
                throw new Exception("Fant ikke feltnavnet i klassen/tabellen, hverken som originalnavn eller alias.");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Henter layername fra tabellen hvor det er lagret. Dersom tab = 0 hentes navnet fra
        /// AnalysisModel, hvis ikke AnalysisModelInputTables.
        /// </summary>
        /// <param name="modelId">Modellens unike identifikator</param>
        /// <param name="relTabNr">Nummeret på relasjonsfanen</param>
        /// <returns>Navn på lag/layer</returns>
        private string modelInputTablesGetLyrName(string modelId, int relTabNr)
        {
            try
            {
                IStandaloneTable pStandaloneTable;
                ITable pTable;
                ICursor pCursor;
                IRow pRow;
                IQueryFilter pQueryfilter;

                pQueryfilter = new QueryFilter();

                if (relTabNr == 0)
                {
                    pStandaloneTable = HentStdAloneTableFraTOC("AnalysisModel");
                    pTable = pStandaloneTable.Table;
                    pQueryfilter.WhereClause = "MODELID = \"" + modelId + "\"";
                    pCursor = pTable.Search(pQueryfilter, false);
                    pRow = pCursor.NextRow();

                    if (pRow != null)
                    {
                        if (pRow.Value[pRow.Fields.FindField("MAINLYR")] != null)
                        {
                            return pRow.Value[pRow.Fields.FindField("MAINLYR")].ToString();
                        }
                    }
                }
                else
                {
                    pStandaloneTable = HentStdAloneTableFraTOC("AnalysisModelInputTables");
                    pTable = pStandaloneTable.Table;
                    pQueryfilter.WhereClause = "RELTABNO = " + relTabNr + " AND MODELID = \"" + modelId + "\"";
                    pCursor = pTable.Search(pQueryfilter, false);
                    pRow = pCursor.NextRow();

                    if (pRow != null)
                    {
                        if (pRow.Value[pRow.Fields.FindField("RELLYR")] != null)
                        {
                            return pRow.Value[pRow.Fields.FindField("RELLYR")].ToString();
                        }
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Leter opp feltet ORqueryMd i tabellen LocalSettings.
        /// </summary>
        /// <returns>Innholdet i feltet ORqueryMd</returns>
        private string getOrAttributeSelectionMode()
        {
            try
            {
                IStandaloneTable pStandaloneTable;
                ITable pTable;
                ICursor pCursor;
                IRow pRow;

                pStandaloneTable = HentStdAloneTableFraTOC("LocalSettings");
                if (pStandaloneTable == null)
                {
                    throw new Exception("Finner ikke tabellen 'LocalSettings'.");
                }
                pTable = pStandaloneTable.Table;

                pCursor = pTable.Search(null, false);
                pRow = pCursor.NextRow();

                if (pRow != null)
                {
                    if (string.IsNullOrEmpty(pRow.Value[pRow.Fields.FindField("ORqueryMd")].ToString()) == false)
                    {
                        return pRow.Value[pRow.Fields.FindField("ORqueryMd")].ToString();
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        
    }

}
