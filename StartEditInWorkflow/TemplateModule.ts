/// <reference path="../../../Libs/Framework.d.ts" />
/// <reference path="../../../Libs/Mapping.Infrastructure.d.ts" />

module quickStart.template {

    export class TemplateModule extends geocortex.framework.application.ModuleBase {

        app: geocortex.essentialsHtmlViewer.ViewerApplication;
        featureSetJson: esri.tasks.FeatureSet;
        featureName: string;
        

        constructor(app: geocortex.essentialsHtmlViewer.ViewerApplication, lib: string) {
            super(app, lib);
        }

        initialize(config: any): void {
            var _this = this;
            //alert(this.app.getResource(this.libraryId, "hello-world-initialized"));
            this.app.registerActivityIdHandler("StartEditingInWorkflow", dojo.hitch(this, this.startEditingInWorkflow));
            //this.app.registerActivityIdHandler("StartEditingInWorkflow", (_this, this.startEditingInWorkflow));
            this.app.commandRegistry.command("StartEditingInWorkflow").register(this, this.startEditingInWorkflow);
            console.log("Registrert activityidhandler");
        }
        
        // Starter redigering og behandler resulteter
        startEditingInWorkflow(context: geocortex.workflow.ActivityContext): void {
            var esriFeatureSet = context.getValue("featureSet");
            var inspFeatureLayerName: string = context.getValue("layerName");
            var featureServiceUrl:string = context.getValue("featureServiceURL");
            this.app.commandRegistry.command("RemoveHighlightLayer").execute("defaultHighlightLayer");
            var esriFeatureLayer:esri.layers.FeatureLayer = Utilities.getFeatureLayer(inspFeatureLayerName, featureServiceUrl, this.app.site);
            
            esriFeatureSet.features[0].attributes["OBJECTID"] = parseInt(esriFeatureSet.features[0].attributes["OBJECTID"], 10);
            var esriFeature: esri.Graphic = esriFeatureSet.features[0];
            var symbol = new esri.symbol.SimpleFillSymbol();
            symbol.setColor(new esri.Color([255, 0, 0]));
            esriFeature.setSymbol(symbol);
            if (esriFeature && esriFeatureLayer) {
                
                console.log("DefaultHighlights er fjernet");
                // Starter redigering av geometrien til feature
                this.app.commandRegistry.command("StartEditingGraphicGeometry").execute(esriFeature, esriFeatureLayer);

                // Lytter etter hendelsen 'GeometryEditCompletedEvent'
                this.app.eventRegistry.event("GeometryEditCompletedEvent").subscribe(this,(eventArgs: geocortex.essentialsHtmlViewer.mapping.infrastructure.eventArgs.GeometryEditCompletedEventArg) => {
                    if (esriFeature && esriFeature === eventArgs.originalGraphic) {
                        context.setValue("EditedGeometry", eventArgs.editedGraphic.geometry);
                        context.setValue("Success", true);
                        
                    } else {
                        context.setValue("Success", false);
                    }
                    context.completeActivity();
                });
            } else {
                context.setValue("Success", false);
                context.completeActivity();
            }
        }
    }
    
    class Utilities {
        // Finner kartlaget som skal endres
        static getFeatureLayer(featurelayerName: string, featureServiceUrl: string, site: geocortex.essentials.Site): esri.layers.FeatureLayer {
            console.log("finn lag");
            var featureLayer: esri.layers.FeatureLayer = new esri.layers.FeatureLayer(featureServiceUrl);
            featureLayer.setVisibility(true);
            var map = site.getMap();
            var layers = new Array<esri.layers.Layer>();
            layers.push(featureLayer);
            site.essentialsMap.addServiceLayers(layers, "Operational");
            var layer = site.essentialsMap.getMap().addLayer(featureLayer);
            
            return featureLayer;
        }
        static sleep(miliseconds):void {
            var start = new Date().getTime();
            for (var i = 0; i < 1e7; i++) {
                if ((new Date().getTime() - start) > miliseconds) {
                    break;
                }
            }
        }
    }
}