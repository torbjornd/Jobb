using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VA_Analysemodul
{
    public class ModelInfoControl
    {
        private ModelInfoView _view;
        private VAAnalyseModul _analyse;
        private AnalyseModul_LogOn _logon;

        public void setView(ModelInfoView view)
        {
            _view = view;
        }
        public void setAnalyse(VAAnalyseModul analyse)
        {
            _analyse = analyse;
        }
        public void setLogon(AnalyseModul_LogOn logon)
        {
            _logon = logon;
        }

        /// <summary>
        /// Åpner dokumentet som er angitt.
        /// </summary>
        public void openDocument()
        {
            try
            {
                _analyse.openDocumentByPath(_view.ModelInfoPath);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Lagrer endringer som er gjort i modelInfo
        /// </summary>
        public void saveEdits()
        {
            try
            {
                if (_logon.CheckUserRight())
                {
                    _analyse.saveModelInfo(_view.Oid, _view.ModelDescription, _view.ModelInfoPath);
                }
                else
                {
                    throw new Exception("Du har ikke rettigheter til å lagre endringer i denne modellen.");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void load()
        {
            _view.ModelDescription = _analyse.getModelDescr(_view.Oid);
            _view.ModelInfoPath = _analyse.getModelDescrFilePath(_view.Oid);
        }
    }
}
