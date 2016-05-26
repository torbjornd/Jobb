﻿/// <reference path="../../../Libs/Framework.d.ts" />
/// <reference path="../../../Libs/Mapping.Infrastructure.d.ts" />

module quickStart.template {

    export class TemplateModuleView extends geocortex.framework.ui.ViewBase {

        app: geocortex.essentialsHtmlViewer.ViewerApplication;
        
        constructor(app: geocortex.essentialsHtmlViewer.ViewerApplication, lib: string) {
            super(app, lib);
            console.log("View");
            //this.app.commandRegistry.command("StartEditingInWorkflow").execute("");
            
            
        }
        

    }
}