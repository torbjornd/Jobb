namespace VA_Analysemodul
{
    partial class DesignDialogView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DesignDialogView));
            this.label1 = new System.Windows.Forms.Label();
            this.tbcRelations = new System.Windows.Forms.TabControl();
            this.tabPageAnalyse = new System.Windows.Forms.TabPage();
            this.lstModelList = new System.Windows.Forms.ListView();
            this.modelIDHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.modelNameHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.modelOwnerHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.txtMainObjectClassDataSource = new System.Windows.Forms.TextBox();
            this.lblDatasource = new System.Windows.Forms.Label();
            this.btnEditQueryAnalysis = new System.Windows.Forms.Button();
            this.txtOIDModel = new System.Windows.Forms.TextBox();
            this.txtModelDescription = new System.Windows.Forms.TextBox();
            this.lblModelDescription = new System.Windows.Forms.Label();
            this.txtLastRun = new System.Windows.Forms.TextBox();
            this.txtFirstRun = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMainObjectClass = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.chxLayerName = new System.Windows.Forms.ComboBox();
            this.lblLayername = new System.Windows.Forms.Label();
            this.chxModelOwner = new System.Windows.Forms.ComboBox();
            this.lblOwner2 = new System.Windows.Forms.Label();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSaveEdits = new System.Windows.Forms.Button();
            this.btnCreateNewModel = new System.Windows.Forms.Button();
            this.btnDeleteModel = new System.Windows.Forms.Button();
            this.btnKopierModell = new System.Windows.Forms.Button();
            this.btnEditInfo = new System.Windows.Forms.Button();
            this.btnOpenDoc = new System.Windows.Forms.Button();
            this.txtChangedDate = new System.Windows.Forms.TextBox();
            this.txtCreatedDate = new System.Windows.Forms.TextBox();
            this.lblDateCreatedChanged = new System.Windows.Forms.Label();
            this.txtModelName = new System.Windows.Forms.TextBox();
            this.lblModelName = new System.Windows.Forms.Label();
            this.txtModelId = new System.Windows.Forms.TextBox();
            this.lblModelId = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.lblModel = new System.Windows.Forms.Label();
            this.cbxModelName = new System.Windows.Forms.ComboBox();
            this.lblOwner = new System.Windows.Forms.Label();
            this.chxSearchModelOwner = new System.Windows.Forms.ComboBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnAddRelations = new System.Windows.Forms.Button();
            this.btnOptions = new System.Windows.Forms.Button();
            this.btnChangeUser = new System.Windows.Forms.Button();
            this.btnRunModel = new System.Windows.Forms.Button();
            this.tabPageRel1 = new System.Windows.Forms.TabPage();
            this.rCtrlRelation1 = new VA_Analysemodul.RelationControl();
            this.tabPageRel2 = new System.Windows.Forms.TabPage();
            this.rCtrlRelation2 = new VA_Analysemodul.RelationControl();
            this.tabPageRel3 = new System.Windows.Forms.TabPage();
            this.rCtrlRelation3 = new VA_Analysemodul.RelationControl();
            this.tabPageRel4 = new System.Windows.Forms.TabPage();
            this.rCtrlRelation4 = new VA_Analysemodul.RelationControl();
            this.tabPageRel5 = new System.Windows.Forms.TabPage();
            this.rCtrlRelation5 = new VA_Analysemodul.RelationControl();
            this.tabPageRel6 = new System.Windows.Forms.TabPage();
            this.rCtrlRelation6 = new VA_Analysemodul.RelationControl();
            this.tabPageRel7 = new System.Windows.Forms.TabPage();
            this.rCtrlRelation7 = new VA_Analysemodul.RelationControl();
            this.tabPageRel8 = new System.Windows.Forms.TabPage();
            this.rCtrlRelation8 = new VA_Analysemodul.RelationControl();
            this.lblBrukernavn = new System.Windows.Forms.Label();
            this.btnCopyModel = new System.Windows.Forms.Button();
            this.tbcRelations.SuspendLayout();
            this.tabPageAnalyse.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.tabPageRel1.SuspendLayout();
            this.tabPageRel2.SuspendLayout();
            this.tabPageRel3.SuspendLayout();
            this.tabPageRel4.SuspendLayout();
            this.tabPageRel5.SuspendLayout();
            this.tabPageRel6.SuspendLayout();
            this.tabPageRel7.SuspendLayout();
            this.tabPageRel8.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Bruker:";
            // 
            // tbcRelations
            // 
            this.tbcRelations.Controls.Add(this.tabPageAnalyse);
            this.tbcRelations.Controls.Add(this.tabPageRel1);
            this.tbcRelations.Controls.Add(this.tabPageRel2);
            this.tbcRelations.Controls.Add(this.tabPageRel3);
            this.tbcRelations.Controls.Add(this.tabPageRel4);
            this.tbcRelations.Controls.Add(this.tabPageRel5);
            this.tbcRelations.Controls.Add(this.tabPageRel6);
            this.tbcRelations.Controls.Add(this.tabPageRel7);
            this.tbcRelations.Controls.Add(this.tabPageRel8);
            this.tbcRelations.Location = new System.Drawing.Point(16, 42);
            this.tbcRelations.Name = "tbcRelations";
            this.tbcRelations.SelectedIndex = 0;
            this.tbcRelations.Size = new System.Drawing.Size(857, 494);
            this.tbcRelations.TabIndex = 1;
            this.tbcRelations.SelectedIndexChanged += new System.EventHandler(this.tbcRelations_TabIndexChanged);
            this.tbcRelations.TabIndexChanged += new System.EventHandler(this.tbcRelations_TabIndexChanged);
            // 
            // tabPageAnalyse
            // 
            this.tabPageAnalyse.Controls.Add(this.lstModelList);
            this.tabPageAnalyse.Controls.Add(this.txtMainObjectClassDataSource);
            this.tabPageAnalyse.Controls.Add(this.lblDatasource);
            this.tabPageAnalyse.Controls.Add(this.btnEditQueryAnalysis);
            this.tabPageAnalyse.Controls.Add(this.txtOIDModel);
            this.tabPageAnalyse.Controls.Add(this.txtModelDescription);
            this.tabPageAnalyse.Controls.Add(this.lblModelDescription);
            this.tabPageAnalyse.Controls.Add(this.txtLastRun);
            this.tabPageAnalyse.Controls.Add(this.txtFirstRun);
            this.tabPageAnalyse.Controls.Add(this.label3);
            this.tabPageAnalyse.Controls.Add(this.txtMainObjectClass);
            this.tabPageAnalyse.Controls.Add(this.label2);
            this.tabPageAnalyse.Controls.Add(this.chxLayerName);
            this.tabPageAnalyse.Controls.Add(this.lblLayername);
            this.tabPageAnalyse.Controls.Add(this.chxModelOwner);
            this.tabPageAnalyse.Controls.Add(this.lblOwner2);
            this.tabPageAnalyse.Controls.Add(this.flowLayoutPanel2);
            this.tabPageAnalyse.Controls.Add(this.txtChangedDate);
            this.tabPageAnalyse.Controls.Add(this.txtCreatedDate);
            this.tabPageAnalyse.Controls.Add(this.lblDateCreatedChanged);
            this.tabPageAnalyse.Controls.Add(this.txtModelName);
            this.tabPageAnalyse.Controls.Add(this.lblModelName);
            this.tabPageAnalyse.Controls.Add(this.txtModelId);
            this.tabPageAnalyse.Controls.Add(this.lblModelId);
            this.tabPageAnalyse.Controls.Add(this.flowLayoutPanel1);
            this.tabPageAnalyse.Location = new System.Drawing.Point(4, 22);
            this.tabPageAnalyse.Name = "tabPageAnalyse";
            this.tabPageAnalyse.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAnalyse.Size = new System.Drawing.Size(849, 468);
            this.tabPageAnalyse.TabIndex = 0;
            this.tabPageAnalyse.Text = "Analyse info";
            this.tabPageAnalyse.UseVisualStyleBackColor = true;
            // 
            // lstModelList
            // 
            this.lstModelList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.modelIDHeader,
            this.modelNameHeader,
            this.modelOwnerHeader});
            this.lstModelList.Location = new System.Drawing.Point(7, 54);
            this.lstModelList.Name = "lstModelList";
            this.lstModelList.Size = new System.Drawing.Size(783, 169);
            this.lstModelList.TabIndex = 25;
            this.lstModelList.UseCompatibleStateImageBehavior = false;
            this.lstModelList.View = System.Windows.Forms.View.Details;
            this.lstModelList.Click += new System.EventHandler(this.lstModelList_Click);
            // 
            // modelIDHeader
            // 
            this.modelIDHeader.Text = "ModelID";
            // 
            // modelNameHeader
            // 
            this.modelNameHeader.Text = "Model Name";
            // 
            // modelOwnerHeader
            // 
            this.modelOwnerHeader.Text = "Model Owner";
            this.modelOwnerHeader.Width = 85;
            // 
            // txtMainObjectClassDataSource
            // 
            this.txtMainObjectClassDataSource.Enabled = false;
            this.txtMainObjectClassDataSource.Location = new System.Drawing.Point(349, 408);
            this.txtMainObjectClassDataSource.Multiline = true;
            this.txtMainObjectClassDataSource.Name = "txtMainObjectClassDataSource";
            this.txtMainObjectClassDataSource.Size = new System.Drawing.Size(284, 37);
            this.txtMainObjectClassDataSource.TabIndex = 14;
            // 
            // lblDatasource
            // 
            this.lblDatasource.AutoSize = true;
            this.lblDatasource.Location = new System.Drawing.Point(346, 392);
            this.lblDatasource.Name = "lblDatasource";
            this.lblDatasource.Size = new System.Drawing.Size(52, 13);
            this.lblDatasource.TabIndex = 23;
            this.lblDatasource.Text = "Datakilde";
            // 
            // btnEditQueryAnalysis
            // 
            this.btnEditQueryAnalysis.Location = new System.Drawing.Point(97, 360);
            this.btnEditQueryAnalysis.Name = "btnEditQueryAnalysis";
            this.btnEditQueryAnalysis.Size = new System.Drawing.Size(150, 23);
            this.btnEditQueryAnalysis.TabIndex = 22;
            this.btnEditQueryAnalysis.Text = global::VA_Analysemodul.Properties.Resources.EditQuery;
            this.btnEditQueryAnalysis.UseVisualStyleBackColor = true;
            this.btnEditQueryAnalysis.Click += new System.EventHandler(this.btnEditQuery_Click);
            // 
            // txtOIDModel
            // 
            this.txtOIDModel.Enabled = false;
            this.txtOIDModel.Location = new System.Drawing.Point(43, 361);
            this.txtOIDModel.Name = "txtOIDModel";
            this.txtOIDModel.Size = new System.Drawing.Size(36, 20);
            this.txtOIDModel.TabIndex = 8;
            // 
            // txtModelDescription
            // 
            this.txtModelDescription.Enabled = false;
            this.txtModelDescription.Location = new System.Drawing.Point(349, 318);
            this.txtModelDescription.Multiline = true;
            this.txtModelDescription.Name = "txtModelDescription";
            this.txtModelDescription.Size = new System.Drawing.Size(284, 63);
            this.txtModelDescription.TabIndex = 13;
            // 
            // lblModelDescription
            // 
            this.lblModelDescription.AutoSize = true;
            this.lblModelDescription.Location = new System.Drawing.Point(346, 301);
            this.lblModelDescription.Name = "lblModelDescription";
            this.lblModelDescription.Size = new System.Drawing.Size(94, 13);
            this.lblModelDescription.TabIndex = 19;
            this.lblModelDescription.Text = "Modell beskrivelse";
            // 
            // txtLastRun
            // 
            this.txtLastRun.Enabled = false;
            this.txtLastRun.Location = new System.Drawing.Point(564, 272);
            this.txtLastRun.Name = "txtLastRun";
            this.txtLastRun.Size = new System.Drawing.Size(72, 20);
            this.txtLastRun.TabIndex = 12;
            // 
            // txtFirstRun
            // 
            this.txtFirstRun.Enabled = false;
            this.txtFirstRun.Location = new System.Drawing.Point(475, 272);
            this.txtFirstRun.Name = "txtFirstRun";
            this.txtFirstRun.Size = new System.Drawing.Size(72, 20);
            this.txtFirstRun.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(374, 275);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Dato først - sist kjørt";
            // 
            // txtMainObjectClass
            // 
            this.txtMainObjectClass.Location = new System.Drawing.Point(97, 333);
            this.txtMainObjectClass.Name = "txtMainObjectClass";
            this.txtMainObjectClass.Size = new System.Drawing.Size(150, 20);
            this.txtMainObjectClass.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 336);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Objektklasse";
            // 
            // chxLayerName
            // 
            this.chxLayerName.FormattingEnabled = true;
            this.chxLayerName.Location = new System.Drawing.Point(97, 302);
            this.chxLayerName.Name = "chxLayerName";
            this.chxLayerName.Size = new System.Drawing.Size(150, 21);
            this.chxLayerName.TabIndex = 6;
            this.chxLayerName.SelectedValueChanged += new System.EventHandler(this.chxLayerName_SelectedValueChanged);
            // 
            // lblLayername
            // 
            this.lblLayername.AutoSize = true;
            this.lblLayername.Location = new System.Drawing.Point(26, 305);
            this.lblLayername.Name = "lblLayername";
            this.lblLayername.Size = new System.Drawing.Size(49, 13);
            this.lblLayername.TabIndex = 12;
            this.lblLayername.Text = "Lagnavn";
            // 
            // chxModelOwner
            // 
            this.chxModelOwner.FormattingEnabled = true;
            this.chxModelOwner.Location = new System.Drawing.Point(97, 272);
            this.chxModelOwner.Name = "chxModelOwner";
            this.chxModelOwner.Size = new System.Drawing.Size(150, 21);
            this.chxModelOwner.TabIndex = 5;
            this.chxModelOwner.SelectedValueChanged += new System.EventHandler(this.chxModelOwner_SelectedValueChanged);
            // 
            // lblOwner2
            // 
            this.lblOwner2.AutoSize = true;
            this.lblOwner2.Location = new System.Drawing.Point(44, 276);
            this.lblOwner2.Name = "lblOwner2";
            this.lblOwner2.Size = new System.Drawing.Size(25, 13);
            this.lblOwner2.TabIndex = 10;
            this.lblOwner2.Text = "Eier";
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.btnClear);
            this.flowLayoutPanel2.Controls.Add(this.btnSaveEdits);
            this.flowLayoutPanel2.Controls.Add(this.btnCreateNewModel);
            this.flowLayoutPanel2.Controls.Add(this.btnDeleteModel);
            this.flowLayoutPanel2.Controls.Add(this.btnKopierModell);
            this.flowLayoutPanel2.Controls.Add(this.btnEditInfo);
            this.flowLayoutPanel2.Controls.Add(this.btnOpenDoc);
            this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(667, 242);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(123, 203);
            this.flowLayoutPanel2.TabIndex = 9;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(3, 3);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(120, 23);
            this.btnClear.TabIndex = 20;
            this.btnClear.Text = global::VA_Analysemodul.Properties.Resources.Clear;
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSaveEdits
            // 
            this.btnSaveEdits.Location = new System.Drawing.Point(3, 32);
            this.btnSaveEdits.Name = "btnSaveEdits";
            this.btnSaveEdits.Size = new System.Drawing.Size(120, 23);
            this.btnSaveEdits.TabIndex = 15;
            this.btnSaveEdits.Text = global::VA_Analysemodul.Properties.Resources.SaveEdits;
            this.btnSaveEdits.UseVisualStyleBackColor = true;
            this.btnSaveEdits.Click += new System.EventHandler(this.btnSaveEdits_Click);
            // 
            // btnCreateNewModel
            // 
            this.btnCreateNewModel.Location = new System.Drawing.Point(3, 61);
            this.btnCreateNewModel.Name = "btnCreateNewModel";
            this.btnCreateNewModel.Size = new System.Drawing.Size(120, 23);
            this.btnCreateNewModel.TabIndex = 16;
            this.btnCreateNewModel.Text = global::VA_Analysemodul.Properties.Resources.CreateNewModel;
            this.btnCreateNewModel.UseVisualStyleBackColor = true;
            this.btnCreateNewModel.Click += new System.EventHandler(this.btnCreateNewModel_Click);
            // 
            // btnDeleteModel
            // 
            this.btnDeleteModel.Location = new System.Drawing.Point(3, 90);
            this.btnDeleteModel.Name = "btnDeleteModel";
            this.btnDeleteModel.Size = new System.Drawing.Size(120, 23);
            this.btnDeleteModel.TabIndex = 17;
            this.btnDeleteModel.Text = global::VA_Analysemodul.Properties.Resources.DeleteModel;
            this.btnDeleteModel.UseVisualStyleBackColor = true;
            this.btnDeleteModel.Click += new System.EventHandler(this.btnDeleteModel_Click);
            // 
            // btnKopierModell
            // 
            this.btnKopierModell.Location = new System.Drawing.Point(3, 119);
            this.btnKopierModell.Name = "btnKopierModell";
            this.btnKopierModell.Size = new System.Drawing.Size(120, 23);
            this.btnKopierModell.TabIndex = 21;
            this.btnKopierModell.Text = "Kopier modell";
            this.btnKopierModell.UseVisualStyleBackColor = true;
            this.btnKopierModell.Click += new System.EventHandler(this.btnCopyModel_Click);
            // 
            // btnEditInfo
            // 
            this.btnEditInfo.Location = new System.Drawing.Point(3, 148);
            this.btnEditInfo.Name = "btnEditInfo";
            this.btnEditInfo.Size = new System.Drawing.Size(120, 23);
            this.btnEditInfo.TabIndex = 18;
            this.btnEditInfo.Text = global::VA_Analysemodul.Properties.Resources.EditDesc;
            this.btnEditInfo.UseVisualStyleBackColor = true;
            this.btnEditInfo.Click += new System.EventHandler(this.btnEditInfo_Click);
            // 
            // btnOpenDoc
            // 
            this.btnOpenDoc.Location = new System.Drawing.Point(3, 177);
            this.btnOpenDoc.Name = "btnOpenDoc";
            this.btnOpenDoc.Size = new System.Drawing.Size(120, 23);
            this.btnOpenDoc.TabIndex = 19;
            this.btnOpenDoc.Text = global::VA_Analysemodul.Properties.Resources.OpenDoc;
            this.btnOpenDoc.UseVisualStyleBackColor = true;
            this.btnOpenDoc.Click += new System.EventHandler(this.btnOpenDoc_Click);
            // 
            // txtChangedDate
            // 
            this.txtChangedDate.Enabled = false;
            this.txtChangedDate.Location = new System.Drawing.Point(564, 243);
            this.txtChangedDate.Name = "txtChangedDate";
            this.txtChangedDate.Size = new System.Drawing.Size(72, 20);
            this.txtChangedDate.TabIndex = 10;
            // 
            // txtCreatedDate
            // 
            this.txtCreatedDate.Enabled = false;
            this.txtCreatedDate.Location = new System.Drawing.Point(475, 243);
            this.txtCreatedDate.Name = "txtCreatedDate";
            this.txtCreatedDate.Size = new System.Drawing.Size(72, 20);
            this.txtCreatedDate.TabIndex = 9;
            this.txtCreatedDate.TextChanged += new System.EventHandler(this.txtCreatedDate_TextChanged);
            // 
            // lblDateCreatedChanged
            // 
            this.lblDateCreatedChanged.AutoSize = true;
            this.lblDateCreatedChanged.Location = new System.Drawing.Point(346, 246);
            this.lblDateCreatedChanged.Name = "lblDateCreatedChanged";
            this.lblDateCreatedChanged.Size = new System.Drawing.Size(114, 13);
            this.lblDateCreatedChanged.TabIndex = 6;
            this.lblDateCreatedChanged.Text = "Dato opprettet - endret";
            // 
            // txtModelName
            // 
            this.txtModelName.Location = new System.Drawing.Point(97, 242);
            this.txtModelName.Name = "txtModelName";
            this.txtModelName.Size = new System.Drawing.Size(150, 20);
            this.txtModelName.TabIndex = 4;
            // 
            // lblModelName
            // 
            this.lblModelName.AutoSize = true;
            this.lblModelName.Location = new System.Drawing.Point(94, 226);
            this.lblModelName.Name = "lblModelName";
            this.lblModelName.Size = new System.Drawing.Size(62, 13);
            this.lblModelName.TabIndex = 4;
            this.lblModelName.Text = "Modellnavn";
            // 
            // txtModelId
            // 
            this.txtModelId.Location = new System.Drawing.Point(13, 242);
            this.txtModelId.Name = "txtModelId";
            this.txtModelId.Size = new System.Drawing.Size(66, 20);
            this.txtModelId.TabIndex = 3;
            this.txtModelId.TextChanged += new System.EventHandler(this.txtModelId_TextChanged);
            // 
            // lblModelId
            // 
            this.lblModelId.AutoSize = true;
            this.lblModelId.Location = new System.Drawing.Point(10, 226);
            this.lblModelId.Name = "lblModelId";
            this.lblModelId.Size = new System.Drawing.Size(49, 13);
            this.lblModelId.TabIndex = 2;
            this.lblModelId.Text = "Modell id";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.lblModel);
            this.flowLayoutPanel1.Controls.Add(this.cbxModelName);
            this.flowLayoutPanel1.Controls.Add(this.lblOwner);
            this.flowLayoutPanel1.Controls.Add(this.chxSearchModelOwner);
            this.flowLayoutPanel1.Controls.Add(this.btnSearch);
            this.flowLayoutPanel1.Controls.Add(this.btnAddRelations);
            this.flowLayoutPanel1.Controls.Add(this.btnOptions);
            this.flowLayoutPanel1.Controls.Add(this.btnChangeUser);
            this.flowLayoutPanel1.Controls.Add(this.btnRunModel);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(7, 16);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(836, 31);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // lblModel
            // 
            this.lblModel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblModel.AutoSize = true;
            this.lblModel.Location = new System.Drawing.Point(3, 8);
            this.lblModel.Name = "lblModel";
            this.lblModel.Size = new System.Drawing.Size(38, 13);
            this.lblModel.TabIndex = 0;
            this.lblModel.Text = "Modell";
            // 
            // cbxModelName
            // 
            this.cbxModelName.FormattingEnabled = true;
            this.cbxModelName.Location = new System.Drawing.Point(47, 3);
            this.cbxModelName.Name = "cbxModelName";
            this.cbxModelName.Size = new System.Drawing.Size(121, 21);
            this.cbxModelName.TabIndex = 1;
            // 
            // lblOwner
            // 
            this.lblOwner.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblOwner.AutoSize = true;
            this.lblOwner.Location = new System.Drawing.Point(174, 8);
            this.lblOwner.Name = "lblOwner";
            this.lblOwner.Size = new System.Drawing.Size(25, 13);
            this.lblOwner.TabIndex = 2;
            this.lblOwner.Text = "Eier";
            this.lblOwner.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chxSearchModelOwner
            // 
            this.chxSearchModelOwner.FormattingEnabled = true;
            this.chxSearchModelOwner.Location = new System.Drawing.Point(205, 3);
            this.chxSearchModelOwner.Name = "chxSearchModelOwner";
            this.chxSearchModelOwner.Size = new System.Drawing.Size(121, 21);
            this.chxSearchModelOwner.TabIndex = 3;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(354, 3);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(25, 3, 3, 3);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = global::VA_Analysemodul.Properties.Resources.Search;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnAddRelations
            // 
            this.btnAddRelations.Location = new System.Drawing.Point(435, 3);
            this.btnAddRelations.Name = "btnAddRelations";
            this.btnAddRelations.Size = new System.Drawing.Size(88, 23);
            this.btnAddRelations.TabIndex = 5;
            this.btnAddRelations.Text = global::VA_Analysemodul.Properties.Resources.AddRelation;
            this.btnAddRelations.UseVisualStyleBackColor = true;
            this.btnAddRelations.Click += new System.EventHandler(this.btnAddRelations_Click);
            // 
            // btnOptions
            // 
            this.btnOptions.Location = new System.Drawing.Point(529, 3);
            this.btnOptions.Name = "btnOptions";
            this.btnOptions.Size = new System.Drawing.Size(75, 23);
            this.btnOptions.TabIndex = 6;
            this.btnOptions.Text = global::VA_Analysemodul.Properties.Resources.Option;
            this.btnOptions.UseVisualStyleBackColor = true;
            this.btnOptions.Click += new System.EventHandler(this.btnOptions_Click);
            // 
            // btnChangeUser
            // 
            this.btnChangeUser.Location = new System.Drawing.Point(610, 3);
            this.btnChangeUser.Name = "btnChangeUser";
            this.btnChangeUser.Size = new System.Drawing.Size(85, 23);
            this.btnChangeUser.TabIndex = 7;
            this.btnChangeUser.Text = global::VA_Analysemodul.Properties.Resources.ChangeUser;
            this.btnChangeUser.UseVisualStyleBackColor = true;
            this.btnChangeUser.Click += new System.EventHandler(this.btnChangeUser_Click);
            // 
            // btnRunModel
            // 
            this.btnRunModel.Location = new System.Drawing.Point(701, 3);
            this.btnRunModel.Name = "btnRunModel";
            this.btnRunModel.Size = new System.Drawing.Size(75, 23);
            this.btnRunModel.TabIndex = 8;
            this.btnRunModel.Text = global::VA_Analysemodul.Properties.Resources.RunModel;
            this.btnRunModel.UseVisualStyleBackColor = true;
            this.btnRunModel.Click += new System.EventHandler(this.btnRunModel_Click);
            // 
            // tabPageRel1
            // 
            this.tabPageRel1.Controls.Add(this.rCtrlRelation1);
            this.tabPageRel1.Location = new System.Drawing.Point(4, 22);
            this.tabPageRel1.Name = "tabPageRel1";
            this.tabPageRel1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageRel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tabPageRel1.Size = new System.Drawing.Size(849, 468);
            this.tabPageRel1.TabIndex = 1;
            this.tabPageRel1.Text = "Rel. 1";
            this.tabPageRel1.UseVisualStyleBackColor = true;
            // 
            // rCtrlRelation1
            // 
            this.rCtrlRelation1.AntallRelaterte = 0;
            this.rCtrlRelation1.BufferDistanceRel_visible = false;
            this.rCtrlRelation1.BufferDistanceRelation = 0D;
            this.rCtrlRelation1.DataSourceRel = "";
            this.rCtrlRelation1.IncludeFeaturesRel = false;
            this.rCtrlRelation1.IncludeFeaturesRel_visible = false;
            this.rCtrlRelation1.Location = new System.Drawing.Point(4, 4);
            this.rCtrlRelation1.LyrNameRel = ((System.Collections.Generic.List<string>)(resources.GetObject("rCtrlRelation1.LyrNameRel")));
            this.rCtrlRelation1.LyrNameRel_selected = "";
            this.rCtrlRelation1.MainObjectClass_relField = ((System.Collections.Generic.List<string>)(resources.GetObject("rCtrlRelation1.MainObjectClass_relField")));
            this.rCtrlRelation1.MainObjectClass_relField_selected = "";
            this.rCtrlRelation1.MainObjectClass_relField_visible = false;
            this.rCtrlRelation1.Name = "rCtrlRelation1";
            this.rCtrlRelation1.ObjectClassName = ((System.Collections.Generic.List<string>)(resources.GetObject("rCtrlRelation1.ObjectClassName")));
            this.rCtrlRelation1.ObjectClassName_selected = "";
            this.rCtrlRelation1.ObjectClassRelField = ((System.Collections.Generic.List<string>)(resources.GetObject("rCtrlRelation1.ObjectClassRelField")));
            this.rCtrlRelation1.ObjectClassRelField_selected = "";
            this.rCtrlRelation1.ObjectClassRelField_visible = false;
            this.rCtrlRelation1.RelationType = ((System.Collections.Generic.List<string>)(resources.GetObject("rCtrlRelation1.RelationType")));
            this.rCtrlRelation1.RelationType_selected = "";
            this.rCtrlRelation1.SelectionTypeRel = ((System.Collections.Generic.List<string>)(resources.GetObject("rCtrlRelation1.SelectionTypeRel")));
            this.rCtrlRelation1.SelectionTypeRel_selected = "";
            this.rCtrlRelation1.Size = new System.Drawing.Size(778, 380);
            this.rCtrlRelation1.SpatialTypeRel = ((System.Collections.Generic.List<string>)(resources.GetObject("rCtrlRelation1.SpatialTypeRel")));
            this.rCtrlRelation1.SpatialTypeRel_selected = "";
            this.rCtrlRelation1.SpatialTypeRel_visible = false;
            this.rCtrlRelation1.TabIndex = 0;
            // 
            // tabPageRel2
            // 
            this.tabPageRel2.Controls.Add(this.rCtrlRelation2);
            this.tabPageRel2.Location = new System.Drawing.Point(4, 22);
            this.tabPageRel2.Name = "tabPageRel2";
            this.tabPageRel2.Size = new System.Drawing.Size(849, 468);
            this.tabPageRel2.TabIndex = 2;
            this.tabPageRel2.Text = "Rel. 2";
            this.tabPageRel2.UseVisualStyleBackColor = true;
            // 
            // rCtrlRelation2
            // 
            this.rCtrlRelation2.AntallRelaterte = 0;
            this.rCtrlRelation2.BufferDistanceRel_visible = false;
            this.rCtrlRelation2.BufferDistanceRelation = 0D;
            this.rCtrlRelation2.DataSourceRel = "";
            this.rCtrlRelation2.IncludeFeaturesRel = false;
            this.rCtrlRelation2.IncludeFeaturesRel_visible = false;
            this.rCtrlRelation2.Location = new System.Drawing.Point(4, 4);
            this.rCtrlRelation2.LyrNameRel = ((System.Collections.Generic.List<string>)(resources.GetObject("rCtrlRelation2.LyrNameRel")));
            this.rCtrlRelation2.LyrNameRel_selected = "";
            this.rCtrlRelation2.MainObjectClass_relField = ((System.Collections.Generic.List<string>)(resources.GetObject("rCtrlRelation2.MainObjectClass_relField")));
            this.rCtrlRelation2.MainObjectClass_relField_selected = "";
            this.rCtrlRelation2.MainObjectClass_relField_visible = false;
            this.rCtrlRelation2.Name = "rCtrlRelation2";
            this.rCtrlRelation2.ObjectClassName = ((System.Collections.Generic.List<string>)(resources.GetObject("rCtrlRelation2.ObjectClassName")));
            this.rCtrlRelation2.ObjectClassName_selected = "";
            this.rCtrlRelation2.ObjectClassRelField = ((System.Collections.Generic.List<string>)(resources.GetObject("rCtrlRelation2.ObjectClassRelField")));
            this.rCtrlRelation2.ObjectClassRelField_selected = "";
            this.rCtrlRelation2.ObjectClassRelField_visible = false;
            this.rCtrlRelation2.RelationType = ((System.Collections.Generic.List<string>)(resources.GetObject("rCtrlRelation2.RelationType")));
            this.rCtrlRelation2.RelationType_selected = "";
            this.rCtrlRelation2.SelectionTypeRel = ((System.Collections.Generic.List<string>)(resources.GetObject("rCtrlRelation2.SelectionTypeRel")));
            this.rCtrlRelation2.SelectionTypeRel_selected = "";
            this.rCtrlRelation2.Size = new System.Drawing.Size(778, 380);
            this.rCtrlRelation2.SpatialTypeRel = ((System.Collections.Generic.List<string>)(resources.GetObject("rCtrlRelation2.SpatialTypeRel")));
            this.rCtrlRelation2.SpatialTypeRel_selected = "";
            this.rCtrlRelation2.SpatialTypeRel_visible = false;
            this.rCtrlRelation2.TabIndex = 0;
            // 
            // tabPageRel3
            // 
            this.tabPageRel3.Controls.Add(this.rCtrlRelation3);
            this.tabPageRel3.Location = new System.Drawing.Point(4, 22);
            this.tabPageRel3.Name = "tabPageRel3";
            this.tabPageRel3.Size = new System.Drawing.Size(849, 468);
            this.tabPageRel3.TabIndex = 3;
            this.tabPageRel3.Text = "Rel 3";
            this.tabPageRel3.UseVisualStyleBackColor = true;
            // 
            // rCtrlRelation3
            // 
            this.rCtrlRelation3.AntallRelaterte = 0;
            this.rCtrlRelation3.BufferDistanceRel_visible = false;
            this.rCtrlRelation3.BufferDistanceRelation = 0D;
            this.rCtrlRelation3.DataSourceRel = "";
            this.rCtrlRelation3.IncludeFeaturesRel = false;
            this.rCtrlRelation3.IncludeFeaturesRel_visible = false;
            this.rCtrlRelation3.Location = new System.Drawing.Point(4, 4);
            this.rCtrlRelation3.LyrNameRel = ((System.Collections.Generic.List<string>)(resources.GetObject("rCtrlRelation3.LyrNameRel")));
            this.rCtrlRelation3.LyrNameRel_selected = "";
            this.rCtrlRelation3.MainObjectClass_relField = ((System.Collections.Generic.List<string>)(resources.GetObject("rCtrlRelation3.MainObjectClass_relField")));
            this.rCtrlRelation3.MainObjectClass_relField_selected = "";
            this.rCtrlRelation3.MainObjectClass_relField_visible = false;
            this.rCtrlRelation3.Name = "rCtrlRelation3";
            this.rCtrlRelation3.ObjectClassName = ((System.Collections.Generic.List<string>)(resources.GetObject("rCtrlRelation3.ObjectClassName")));
            this.rCtrlRelation3.ObjectClassName_selected = "";
            this.rCtrlRelation3.ObjectClassRelField = ((System.Collections.Generic.List<string>)(resources.GetObject("rCtrlRelation3.ObjectClassRelField")));
            this.rCtrlRelation3.ObjectClassRelField_selected = "";
            this.rCtrlRelation3.ObjectClassRelField_visible = false;
            this.rCtrlRelation3.RelationType = ((System.Collections.Generic.List<string>)(resources.GetObject("rCtrlRelation3.RelationType")));
            this.rCtrlRelation3.RelationType_selected = "";
            this.rCtrlRelation3.SelectionTypeRel = ((System.Collections.Generic.List<string>)(resources.GetObject("rCtrlRelation3.SelectionTypeRel")));
            this.rCtrlRelation3.SelectionTypeRel_selected = "";
            this.rCtrlRelation3.Size = new System.Drawing.Size(778, 380);
            this.rCtrlRelation3.SpatialTypeRel = ((System.Collections.Generic.List<string>)(resources.GetObject("rCtrlRelation3.SpatialTypeRel")));
            this.rCtrlRelation3.SpatialTypeRel_selected = "";
            this.rCtrlRelation3.SpatialTypeRel_visible = false;
            this.rCtrlRelation3.TabIndex = 0;
            // 
            // tabPageRel4
            // 
            this.tabPageRel4.Controls.Add(this.rCtrlRelation4);
            this.tabPageRel4.Location = new System.Drawing.Point(4, 22);
            this.tabPageRel4.Name = "tabPageRel4";
            this.tabPageRel4.Size = new System.Drawing.Size(849, 468);
            this.tabPageRel4.TabIndex = 4;
            this.tabPageRel4.Text = "Rel. 4";
            this.tabPageRel4.UseVisualStyleBackColor = true;
            // 
            // rCtrlRelation4
            // 
            this.rCtrlRelation4.AntallRelaterte = 0;
            this.rCtrlRelation4.BufferDistanceRel_visible = false;
            this.rCtrlRelation4.BufferDistanceRelation = 0D;
            this.rCtrlRelation4.DataSourceRel = "";
            this.rCtrlRelation4.IncludeFeaturesRel = false;
            this.rCtrlRelation4.IncludeFeaturesRel_visible = false;
            this.rCtrlRelation4.Location = new System.Drawing.Point(4, 4);
            this.rCtrlRelation4.LyrNameRel = ((System.Collections.Generic.List<string>)(resources.GetObject("rCtrlRelation4.LyrNameRel")));
            this.rCtrlRelation4.LyrNameRel_selected = "";
            this.rCtrlRelation4.MainObjectClass_relField = ((System.Collections.Generic.List<string>)(resources.GetObject("rCtrlRelation4.MainObjectClass_relField")));
            this.rCtrlRelation4.MainObjectClass_relField_selected = "";
            this.rCtrlRelation4.MainObjectClass_relField_visible = false;
            this.rCtrlRelation4.Name = "rCtrlRelation4";
            this.rCtrlRelation4.ObjectClassName = ((System.Collections.Generic.List<string>)(resources.GetObject("rCtrlRelation4.ObjectClassName")));
            this.rCtrlRelation4.ObjectClassName_selected = "";
            this.rCtrlRelation4.ObjectClassRelField = ((System.Collections.Generic.List<string>)(resources.GetObject("rCtrlRelation4.ObjectClassRelField")));
            this.rCtrlRelation4.ObjectClassRelField_selected = "";
            this.rCtrlRelation4.ObjectClassRelField_visible = false;
            this.rCtrlRelation4.RelationType = ((System.Collections.Generic.List<string>)(resources.GetObject("rCtrlRelation4.RelationType")));
            this.rCtrlRelation4.RelationType_selected = "";
            this.rCtrlRelation4.SelectionTypeRel = ((System.Collections.Generic.List<string>)(resources.GetObject("rCtrlRelation4.SelectionTypeRel")));
            this.rCtrlRelation4.SelectionTypeRel_selected = "";
            this.rCtrlRelation4.Size = new System.Drawing.Size(778, 380);
            this.rCtrlRelation4.SpatialTypeRel = ((System.Collections.Generic.List<string>)(resources.GetObject("rCtrlRelation4.SpatialTypeRel")));
            this.rCtrlRelation4.SpatialTypeRel_selected = "";
            this.rCtrlRelation4.SpatialTypeRel_visible = false;
            this.rCtrlRelation4.TabIndex = 0;
            // 
            // tabPageRel5
            // 
            this.tabPageRel5.Controls.Add(this.rCtrlRelation5);
            this.tabPageRel5.Location = new System.Drawing.Point(4, 22);
            this.tabPageRel5.Name = "tabPageRel5";
            this.tabPageRel5.Size = new System.Drawing.Size(849, 468);
            this.tabPageRel5.TabIndex = 5;
            this.tabPageRel5.Text = "Rel. 5";
            this.tabPageRel5.UseVisualStyleBackColor = true;
            // 
            // rCtrlRelation5
            // 
            this.rCtrlRelation5.AntallRelaterte = 0;
            this.rCtrlRelation5.BufferDistanceRel_visible = false;
            this.rCtrlRelation5.BufferDistanceRelation = 0D;
            this.rCtrlRelation5.DataSourceRel = "";
            this.rCtrlRelation5.IncludeFeaturesRel = false;
            this.rCtrlRelation5.IncludeFeaturesRel_visible = false;
            this.rCtrlRelation5.Location = new System.Drawing.Point(4, 4);
            this.rCtrlRelation5.LyrNameRel = ((System.Collections.Generic.List<string>)(resources.GetObject("rCtrlRelation5.LyrNameRel")));
            this.rCtrlRelation5.LyrNameRel_selected = "";
            this.rCtrlRelation5.MainObjectClass_relField = ((System.Collections.Generic.List<string>)(resources.GetObject("rCtrlRelation5.MainObjectClass_relField")));
            this.rCtrlRelation5.MainObjectClass_relField_selected = "";
            this.rCtrlRelation5.MainObjectClass_relField_visible = false;
            this.rCtrlRelation5.Name = "rCtrlRelation5";
            this.rCtrlRelation5.ObjectClassName = ((System.Collections.Generic.List<string>)(resources.GetObject("rCtrlRelation5.ObjectClassName")));
            this.rCtrlRelation5.ObjectClassName_selected = "";
            this.rCtrlRelation5.ObjectClassRelField = ((System.Collections.Generic.List<string>)(resources.GetObject("rCtrlRelation5.ObjectClassRelField")));
            this.rCtrlRelation5.ObjectClassRelField_selected = "";
            this.rCtrlRelation5.ObjectClassRelField_visible = false;
            this.rCtrlRelation5.RelationType = ((System.Collections.Generic.List<string>)(resources.GetObject("rCtrlRelation5.RelationType")));
            this.rCtrlRelation5.RelationType_selected = "";
            this.rCtrlRelation5.SelectionTypeRel = ((System.Collections.Generic.List<string>)(resources.GetObject("rCtrlRelation5.SelectionTypeRel")));
            this.rCtrlRelation5.SelectionTypeRel_selected = "";
            this.rCtrlRelation5.Size = new System.Drawing.Size(778, 380);
            this.rCtrlRelation5.SpatialTypeRel = ((System.Collections.Generic.List<string>)(resources.GetObject("rCtrlRelation5.SpatialTypeRel")));
            this.rCtrlRelation5.SpatialTypeRel_selected = "";
            this.rCtrlRelation5.SpatialTypeRel_visible = false;
            this.rCtrlRelation5.TabIndex = 0;
            // 
            // tabPageRel6
            // 
            this.tabPageRel6.Controls.Add(this.rCtrlRelation6);
            this.tabPageRel6.Location = new System.Drawing.Point(4, 22);
            this.tabPageRel6.Name = "tabPageRel6";
            this.tabPageRel6.Size = new System.Drawing.Size(849, 468);
            this.tabPageRel6.TabIndex = 6;
            this.tabPageRel6.Text = "Rel. 6";
            this.tabPageRel6.UseVisualStyleBackColor = true;
            // 
            // rCtrlRelation6
            // 
            this.rCtrlRelation6.AntallRelaterte = 0;
            this.rCtrlRelation6.BufferDistanceRel_visible = false;
            this.rCtrlRelation6.BufferDistanceRelation = 0D;
            this.rCtrlRelation6.DataSourceRel = "";
            this.rCtrlRelation6.IncludeFeaturesRel = false;
            this.rCtrlRelation6.IncludeFeaturesRel_visible = false;
            this.rCtrlRelation6.Location = new System.Drawing.Point(4, 4);
            this.rCtrlRelation6.LyrNameRel = ((System.Collections.Generic.List<string>)(resources.GetObject("rCtrlRelation6.LyrNameRel")));
            this.rCtrlRelation6.LyrNameRel_selected = "";
            this.rCtrlRelation6.MainObjectClass_relField = ((System.Collections.Generic.List<string>)(resources.GetObject("rCtrlRelation6.MainObjectClass_relField")));
            this.rCtrlRelation6.MainObjectClass_relField_selected = "";
            this.rCtrlRelation6.MainObjectClass_relField_visible = false;
            this.rCtrlRelation6.Name = "rCtrlRelation6";
            this.rCtrlRelation6.ObjectClassName = ((System.Collections.Generic.List<string>)(resources.GetObject("rCtrlRelation6.ObjectClassName")));
            this.rCtrlRelation6.ObjectClassName_selected = "";
            this.rCtrlRelation6.ObjectClassRelField = ((System.Collections.Generic.List<string>)(resources.GetObject("rCtrlRelation6.ObjectClassRelField")));
            this.rCtrlRelation6.ObjectClassRelField_selected = "";
            this.rCtrlRelation6.ObjectClassRelField_visible = false;
            this.rCtrlRelation6.RelationType = ((System.Collections.Generic.List<string>)(resources.GetObject("rCtrlRelation6.RelationType")));
            this.rCtrlRelation6.RelationType_selected = "";
            this.rCtrlRelation6.SelectionTypeRel = ((System.Collections.Generic.List<string>)(resources.GetObject("rCtrlRelation6.SelectionTypeRel")));
            this.rCtrlRelation6.SelectionTypeRel_selected = "";
            this.rCtrlRelation6.Size = new System.Drawing.Size(778, 380);
            this.rCtrlRelation6.SpatialTypeRel = ((System.Collections.Generic.List<string>)(resources.GetObject("rCtrlRelation6.SpatialTypeRel")));
            this.rCtrlRelation6.SpatialTypeRel_selected = "";
            this.rCtrlRelation6.SpatialTypeRel_visible = false;
            this.rCtrlRelation6.TabIndex = 0;
            // 
            // tabPageRel7
            // 
            this.tabPageRel7.Controls.Add(this.rCtrlRelation7);
            this.tabPageRel7.Location = new System.Drawing.Point(4, 22);
            this.tabPageRel7.Name = "tabPageRel7";
            this.tabPageRel7.Size = new System.Drawing.Size(849, 468);
            this.tabPageRel7.TabIndex = 7;
            this.tabPageRel7.Text = "Rel. 7";
            this.tabPageRel7.UseVisualStyleBackColor = true;
            // 
            // rCtrlRelation7
            // 
            this.rCtrlRelation7.AntallRelaterte = 0;
            this.rCtrlRelation7.BufferDistanceRel_visible = false;
            this.rCtrlRelation7.BufferDistanceRelation = 0D;
            this.rCtrlRelation7.DataSourceRel = "";
            this.rCtrlRelation7.IncludeFeaturesRel = false;
            this.rCtrlRelation7.IncludeFeaturesRel_visible = false;
            this.rCtrlRelation7.Location = new System.Drawing.Point(4, 4);
            this.rCtrlRelation7.LyrNameRel = ((System.Collections.Generic.List<string>)(resources.GetObject("rCtrlRelation7.LyrNameRel")));
            this.rCtrlRelation7.LyrNameRel_selected = "";
            this.rCtrlRelation7.MainObjectClass_relField = ((System.Collections.Generic.List<string>)(resources.GetObject("rCtrlRelation7.MainObjectClass_relField")));
            this.rCtrlRelation7.MainObjectClass_relField_selected = "";
            this.rCtrlRelation7.MainObjectClass_relField_visible = false;
            this.rCtrlRelation7.Name = "rCtrlRelation7";
            this.rCtrlRelation7.ObjectClassName = ((System.Collections.Generic.List<string>)(resources.GetObject("rCtrlRelation7.ObjectClassName")));
            this.rCtrlRelation7.ObjectClassName_selected = "";
            this.rCtrlRelation7.ObjectClassRelField = ((System.Collections.Generic.List<string>)(resources.GetObject("rCtrlRelation7.ObjectClassRelField")));
            this.rCtrlRelation7.ObjectClassRelField_selected = "";
            this.rCtrlRelation7.ObjectClassRelField_visible = false;
            this.rCtrlRelation7.RelationType = ((System.Collections.Generic.List<string>)(resources.GetObject("rCtrlRelation7.RelationType")));
            this.rCtrlRelation7.RelationType_selected = "";
            this.rCtrlRelation7.SelectionTypeRel = ((System.Collections.Generic.List<string>)(resources.GetObject("rCtrlRelation7.SelectionTypeRel")));
            this.rCtrlRelation7.SelectionTypeRel_selected = "";
            this.rCtrlRelation7.Size = new System.Drawing.Size(778, 380);
            this.rCtrlRelation7.SpatialTypeRel = ((System.Collections.Generic.List<string>)(resources.GetObject("rCtrlRelation7.SpatialTypeRel")));
            this.rCtrlRelation7.SpatialTypeRel_selected = "";
            this.rCtrlRelation7.SpatialTypeRel_visible = false;
            this.rCtrlRelation7.TabIndex = 0;
            // 
            // tabPageRel8
            // 
            this.tabPageRel8.Controls.Add(this.rCtrlRelation8);
            this.tabPageRel8.Location = new System.Drawing.Point(4, 22);
            this.tabPageRel8.Name = "tabPageRel8";
            this.tabPageRel8.Size = new System.Drawing.Size(849, 468);
            this.tabPageRel8.TabIndex = 8;
            this.tabPageRel8.Text = "Rel. 8";
            this.tabPageRel8.UseVisualStyleBackColor = true;
            // 
            // rCtrlRelation8
            // 
            this.rCtrlRelation8.AntallRelaterte = 0;
            this.rCtrlRelation8.BufferDistanceRel_visible = false;
            this.rCtrlRelation8.BufferDistanceRelation = 0D;
            this.rCtrlRelation8.DataSourceRel = "";
            this.rCtrlRelation8.IncludeFeaturesRel = false;
            this.rCtrlRelation8.IncludeFeaturesRel_visible = false;
            this.rCtrlRelation8.Location = new System.Drawing.Point(4, 4);
            this.rCtrlRelation8.LyrNameRel = ((System.Collections.Generic.List<string>)(resources.GetObject("rCtrlRelation8.LyrNameRel")));
            this.rCtrlRelation8.LyrNameRel_selected = "";
            this.rCtrlRelation8.MainObjectClass_relField = ((System.Collections.Generic.List<string>)(resources.GetObject("rCtrlRelation8.MainObjectClass_relField")));
            this.rCtrlRelation8.MainObjectClass_relField_selected = "";
            this.rCtrlRelation8.MainObjectClass_relField_visible = false;
            this.rCtrlRelation8.Name = "rCtrlRelation8";
            this.rCtrlRelation8.ObjectClassName = ((System.Collections.Generic.List<string>)(resources.GetObject("rCtrlRelation8.ObjectClassName")));
            this.rCtrlRelation8.ObjectClassName_selected = "";
            this.rCtrlRelation8.ObjectClassRelField = ((System.Collections.Generic.List<string>)(resources.GetObject("rCtrlRelation8.ObjectClassRelField")));
            this.rCtrlRelation8.ObjectClassRelField_selected = "";
            this.rCtrlRelation8.ObjectClassRelField_visible = false;
            this.rCtrlRelation8.RelationType = ((System.Collections.Generic.List<string>)(resources.GetObject("rCtrlRelation8.RelationType")));
            this.rCtrlRelation8.RelationType_selected = "";
            this.rCtrlRelation8.SelectionTypeRel = ((System.Collections.Generic.List<string>)(resources.GetObject("rCtrlRelation8.SelectionTypeRel")));
            this.rCtrlRelation8.SelectionTypeRel_selected = "";
            this.rCtrlRelation8.Size = new System.Drawing.Size(778, 380);
            this.rCtrlRelation8.SpatialTypeRel = ((System.Collections.Generic.List<string>)(resources.GetObject("rCtrlRelation8.SpatialTypeRel")));
            this.rCtrlRelation8.SpatialTypeRel_selected = "";
            this.rCtrlRelation8.SpatialTypeRel_visible = false;
            this.rCtrlRelation8.TabIndex = 0;
            // 
            // lblBrukernavn
            // 
            this.lblBrukernavn.AutoSize = true;
            this.lblBrukernavn.Location = new System.Drawing.Point(58, 13);
            this.lblBrukernavn.Name = "lblBrukernavn";
            this.lblBrukernavn.Size = new System.Drawing.Size(0, 13);
            this.lblBrukernavn.TabIndex = 2;
            // 
            // btnCopyModel
            // 
            this.btnCopyModel.Location = new System.Drawing.Point(3, 119);
            this.btnCopyModel.Name = "btnCopyModel";
            this.btnCopyModel.Size = new System.Drawing.Size(120, 23);
            this.btnCopyModel.TabIndex = 21;
            this.btnCopyModel.Text = "button1";
            this.btnCopyModel.UseVisualStyleBackColor = true;
            this.btnCopyModel.Click += new System.EventHandler(this.btnCopyModel_Click);
            // 
            // DesignDialogView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(887, 545);
            this.Controls.Add(this.lblBrukernavn);
            this.Controls.Add(this.tbcRelations);
            this.Controls.Add(this.label1);
            this.Name = "DesignDialogView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Opprett eller rediger modell";
            this.Load += new System.EventHandler(this.VaAnalyseModulForm_Load);
            this.tbcRelations.ResumeLayout(false);
            this.tabPageAnalyse.ResumeLayout(false);
            this.tabPageAnalyse.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.tabPageRel1.ResumeLayout(false);
            this.tabPageRel2.ResumeLayout(false);
            this.tabPageRel3.ResumeLayout(false);
            this.tabPageRel4.ResumeLayout(false);
            this.tabPageRel5.ResumeLayout(false);
            this.tabPageRel6.ResumeLayout(false);
            this.tabPageRel7.ResumeLayout(false);
            this.tabPageRel8.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        

        #endregion

        public System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tbcRelations;
        private System.Windows.Forms.TabPage tabPageAnalyse;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label lblModel;
        private System.Windows.Forms.ComboBox cbxModelName;
        private System.Windows.Forms.Label lblOwner;
        private System.Windows.Forms.ComboBox chxSearchModelOwner;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnAddRelations;
        private System.Windows.Forms.Button btnOptions;
        private System.Windows.Forms.Button btnChangeUser;
        private System.Windows.Forms.Button btnRunModel;
        private System.Windows.Forms.TabPage tabPageRel1;
        private System.Windows.Forms.TabPage tabPageRel2;
        private System.Windows.Forms.TabPage tabPageRel3;
        private System.Windows.Forms.TabPage tabPageRel4;
        private System.Windows.Forms.TabPage tabPageRel5;
        private System.Windows.Forms.TabPage tabPageRel6;
        private System.Windows.Forms.TabPage tabPageRel7;
        private System.Windows.Forms.TabPage tabPageRel8;
        private System.Windows.Forms.TextBox txtChangedDate;
        private System.Windows.Forms.TextBox txtCreatedDate;
        private System.Windows.Forms.Label lblDateCreatedChanged;
        private System.Windows.Forms.TextBox txtModelName;
        private System.Windows.Forms.Label lblModelName;
        private System.Windows.Forms.TextBox txtModelId;
        private System.Windows.Forms.Label lblModelId;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Button btnSaveEdits;
        private System.Windows.Forms.Button btnCreateNewModel;
        private System.Windows.Forms.Button btnDeleteModel;
        private System.Windows.Forms.ComboBox chxModelOwner;
        private System.Windows.Forms.Label lblOwner2;
        private System.Windows.Forms.TextBox txtMainObjectClassDataSource;
        private System.Windows.Forms.Label lblDatasource;
        private System.Windows.Forms.Button btnEditQueryAnalysis;
        private System.Windows.Forms.TextBox txtOIDModel;
        private System.Windows.Forms.TextBox txtModelDescription;
        private System.Windows.Forms.Label lblModelDescription;
        private System.Windows.Forms.TextBox txtLastRun;
        private System.Windows.Forms.TextBox txtFirstRun;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMainObjectClass;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox chxLayerName;
        private System.Windows.Forms.Label lblLayername;
        private System.Windows.Forms.Button btnEditInfo;
        private System.Windows.Forms.Button btnOpenDoc;
        private System.Windows.Forms.Label lblBrukernavn;
        private System.Windows.Forms.ListView lstModelList;
        private System.Windows.Forms.ColumnHeader modelIDHeader;
        private System.Windows.Forms.ColumnHeader modelNameHeader;
        private System.Windows.Forms.ColumnHeader modelOwnerHeader;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnKopierModell;
        private System.Windows.Forms.Button btnCopyModel;
        private RelationControl rCtrlRelation1;
        private RelationControl rCtrlRelation2;
        private RelationControl rCtrlRelation3;
        private RelationControl rCtrlRelation4;
        private RelationControl rCtrlRelation5;
        private RelationControl rCtrlRelation6;
        private RelationControl rCtrlRelation7;
        private RelationControl rCtrlRelation8;
    }
}