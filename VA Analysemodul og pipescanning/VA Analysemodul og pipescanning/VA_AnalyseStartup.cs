using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VA_Analysemodul
{
    class VA_AnalyseStartup : ESRI.ArcGIS.Desktop.AddIns.Button
    {
        protected override void OnClick()
        {
            ArcMap.Application.CurrentTool = null;

            DesignDialogView designView = new DesignDialogView();
            DesignDialogControl designController = new DesignDialogControl();
            designView.SetController(designController);
            

            VAAnalyseModul analyse = new VAAnalyseModul();
            AnalyseModul_LogOn login = new AnalyseModul_LogOn();
            EditFieldQueryView editView = new EditFieldQueryView();
            ModelInfoView modelInfoView = new ModelInfoView();
            DesignDialogControl control = new DesignDialogControl(designView,login,analyse,editView,modelInfoView);
            designView.Show();
            
        }

        protected override void OnUpdate()
        {
            Enabled = ArcMap.Application != null;
        }
    }
}
