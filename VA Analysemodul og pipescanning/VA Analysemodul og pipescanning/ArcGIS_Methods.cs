using ESRI.ArcGIS.esriSystem;
using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Text;
using ESRI.ArcGIS.Geoprocessor;
using ESRI.ArcGIS.DataManagementTools;

namespace VA_Analysemodul
{
    class ArcGIS_Methods
    {
        public ArcGIS_Methods()
        {
        }

        /// <summary>
        /// Kjører geoprosesseringsverktøyet "Select Layer By Location"
        /// //TODO: legges i en egen klasse?
        /// </summary>
        /// <param name="mainLyrName"></param>
        /// <param name="lyrName"></param>
        /// <param name="spatialSelType"></param>
        /// <param name="bufferDistance"></param>
        /// <param name="selType"></param>
        public void runGPTool_selectionLayerByLocation(string inputLyrName, string selectFeaturesLyrName, string spatialSelType, string bufferDistance, string selType)
        {
            try
            {
                Geoprocessor gp2 = new Geoprocessor();
                SelectLayerByLocation selectByLocation = new SelectLayerByLocation();
                selectByLocation.in_layer = inputLyrName;
                selectByLocation.select_features = selectFeaturesLyrName;
                selectByLocation.selection_type = spatialSelType;
                selectByLocation.search_distance = bufferDistance;
                selectByLocation.selection_type = selType;
                RunTool(gp2, selectByLocation, null);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        private static void RunTool(Geoprocessor geoprocessor, IGPProcess process, ITrackCancel TC)
        {

            // Set the overwrite output option to true
            geoprocessor.OverwriteOutput = true;

            // Execute the tool            
            try
            {
                geoprocessor.Execute(process, null);
            }
            catch (Exception)
            {
                ReturnMessages(geoprocessor);
            }
        }
        // Function for returning the tool messages.
        private static void ReturnMessages(Geoprocessor gp)
        {
            string feilmelding = "";
            if (gp.MessageCount > 0)
            {
                for (int Count = 0; Count <= gp.MessageCount - 1; Count++)
                {
                   feilmelding += (gp.GetMessage(Count))+"\n";
                }
            }
            throw new Exception(feilmelding);

        }

    }
}
