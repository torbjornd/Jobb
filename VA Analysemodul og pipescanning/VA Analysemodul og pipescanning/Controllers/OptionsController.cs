using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VA_Analysemodul
{
    class OptionsController
    {
        #region Properties
        private OptionsView _view;
        private VAAnalyseModul _analyse;

        public VAAnalyseModul Analyse
        {
            get { return _analyse; }
            set { _analyse = value; }
        }


        public OptionsView View
        {
            get { return _view; }
            set { _view = value; }
        }
        #endregion

        public void loadForm()
        {
            try
            {
                List<string> listen = new List<string>();
                listen.Add("Before");
                listen.Add("Before spatial Queries and before AND-Attributtrelasjon queries");
                listen.Add("After");
                listen.Add("After all other queries on related tables");
                _view.OptionsList = listen;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void saveOptions()
        {
            try
            {
                _analyse.saveLocalSettings(_view.OptionsList_selected);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
