using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Text;

namespace VA_Analysemodul
{
    public class Modell
    {

        #region "Properties"

        private int oid;

        /// <summary>
        /// ObjektID
        /// </summary>
        public int Oid
        {
            get { return oid; }
            set { oid = value; }
        }


        private string modelID;

        public string ModelID
        {
            get { return modelID; }
            set { modelID = value; }
        }

        private string modelName;

        public string ModelName
        {
            get { return modelName; }
            set { modelName = value; }
        }

        private string modelOwner;

        public string ModelOwner
        {
            get { return modelOwner; }
            set { modelOwner = value; }
        }

        private DateTime? regDate;

        public DateTime? RegDate
        {
            get { return regDate; }
            set { regDate = value; }
        }

        private DateTime? chDate;

        public DateTime? ChDate
        {
            get { return chDate; }
            set { chDate = value; }
        }

        private DateTime? lastRunDate;

        public DateTime? LastRunDate
        {
            get { return lastRunDate; }
            set { lastRunDate = value; }
        }

        private DateTime? firstRunDate;

        public DateTime? FirstRunDate
        {
            get { return firstRunDate; }
            set { firstRunDate = value; }
        }

        private string mxdName;

        public string MxdName
        {
            get { return mxdName; }
            set { mxdName = value; }
        }

        private string mxdPath;

        public string MxdPath
        {
            get { return mxdPath; }
            set { mxdPath = value; }
        }

        private string resultlyr;

        public string Resultlyr
        {
            get { return resultlyr; }
            set { resultlyr = value; }
        }

        private string mainFcl;

        public string MainFcl
        {
            get { return mainFcl; }
            set { mainFcl = value; }
        }

        private string mainlyr;

        public string Mainlyr
        {
            get { return mainlyr; }
            set { mainlyr = value; }
        }

        private string mainFclDescr;

        public string MainFclDescr
        {
            get { return mainFclDescr; }
            set { mainFclDescr = value; }
        }

        private string modelDescr;

        public string ModelDescr
        {
            get { return modelDescr; }
            set { modelDescr = value; }
        }

        private int relationTabNo;

        public int RelationTabNo
        {
            get { return relationTabNo; }
            set { relationTabNo = value; }
        }
        private string layername;

        public string Layername
        {
            get { return layername; }
            set { layername = value; }
        }
        private string objectClassName;

        public string ObjectClassName
        {
            get { return objectClassName; }
            set { objectClassName = value; }
        }
        private string relationType;

        public string RelationType
        {
            get { return relationType; }
            set { relationType = value; }
        }
        private string objectClass_relfield;

        public string ObjectClass_relfield
        {
            get { return objectClass_relfield; }
            set { objectClass_relfield = value; }
        }
        private string mainObjectClass_relfield;

        public string MainObjectClass_relfield
        {
            get { return mainObjectClass_relfield; }
            set { mainObjectClass_relfield = value; }
        }
        private string relationSearchType;

        public string RelationSearchType
        {
            get { return relationSearchType; }
            set { relationSearchType = value; }
        }

        private int antRelasjoner;

        public int AntRelasjoner
        {
            get { return antRelasjoner; }
            set { antRelasjoner = value; }
        }

        private bool includeFeaturesWithoutRelRecords;

        public bool IncludeFeaturesWithoutRelRecords
        {
            get { return includeFeaturesWithoutRelRecords; }
            set { includeFeaturesWithoutRelRecords = value; }
        }
        private string SpatialRelationType;

        public string SpatialRelationType1
        {
            get { return SpatialRelationType; }
            set { SpatialRelationType = value; }
        }
        private double bufferDistance;

        public double BufferDistance
        {
            get { return bufferDistance; }
            set { bufferDistance = value; }
        }
        #endregion


        public Modell(string modelID, string name, string owner, DateTime? regDate, DateTime? chDate, 
            DateTime? lastRun, DateTime? firstRun, string mxdName, string mxdPath, string result, 
            string fcl, string lyr, string fclDescr, string descr, int oid)
        {
            this.modelID = modelID;
            this.modelName = name;
            this.modelOwner = owner;
            this.regDate = regDate;
            this.chDate = chDate;
            this.lastRunDate = lastRun;
            this.firstRunDate = firstRun;
            this.mxdName = mxdName;
            this.mxdPath = mxdPath;
            this.resultlyr = result;
            this.mainFcl = fcl;
            this.mainlyr = lyr;
            this.mainFclDescr = fclDescr;
            this.modelDescr = descr;
            this.oid = oid;
        }

        public Modell(int relTabNo, string lyr, string objectClassName, string relType, string object_relField, string m_relField,
            string relSearchType, bool inclFeatWithoutRel, int antRelations, string spatialRelType, double buffer)
        {

            this.relationTabNo = relTabNo;
            this.layername = lyr;
            this.objectClassName = objectClassName;
            this.relationType = relType;
            this.objectClass_relfield = object_relField;
            this.mainObjectClass_relfield = m_relField;
            this.relationSearchType = relSearchType;
            this.includeFeaturesWithoutRelRecords = inclFeatWithoutRel;
            this.SpatialRelationType = spatialRelType;
            this.bufferDistance = buffer;
            this.antRelasjoner = antRelations;
        }

        public ListViewItem makeKey()
        {
            return new ListViewItem(modelID);
        }
    
    }
}
