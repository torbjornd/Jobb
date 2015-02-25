namespace VA_Analysemodul
{
    partial class RelationControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label67 = new System.Windows.Forms.Label();
            this.cbxLyrRel = new System.Windows.Forms.ComboBox();
            this.label68 = new System.Windows.Forms.Label();
            this.label69 = new System.Windows.Forms.Label();
            this.cbxRelTypeRel = new System.Windows.Forms.ComboBox();
            this.cbxObjClassName = new System.Windows.Forms.ComboBox();
            this.label70 = new System.Windows.Forms.Label();
            this.label71 = new System.Windows.Forms.Label();
            this.cbxObjectClass_RelField = new System.Windows.Forms.ComboBox();
            this.txtDatasourceRel = new System.Windows.Forms.TextBox();
            this.label72 = new System.Windows.Forms.Label();
            this.label73 = new System.Windows.Forms.Label();
            this.label74 = new System.Windows.Forms.Label();
            this.cbxMainObjectClass_relField = new System.Windows.Forms.ComboBox();
            this.cbxSelectionTypeRel = new System.Windows.Forms.ComboBox();
            this.cbxSpatialRelTypeRel = new System.Windows.Forms.ComboBox();
            this.chxIncludeFeaturesRel = new System.Windows.Forms.CheckBox();
            this.btnEditQuery = new System.Windows.Forms.Button();
            this.label75 = new System.Windows.Forms.Label();
            this.btnSaveRelation = new System.Windows.Forms.Button();
            this.txtBufferDistanceRel = new System.Windows.Forms.TextBox();
            this.btnDeleteRelation = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtAntallRelasjoner = new System.Windows.Forms.TextBox();
            this.chxAntallRelaterte = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label67
            // 
            this.label67.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label67.AutoSize = true;
            this.label67.Location = new System.Drawing.Point(13, 62);
            this.label67.Name = "label67";
            this.label67.Size = new System.Drawing.Size(49, 13);
            this.label67.TabIndex = 55;
            this.label67.Text = "Lagnavn";
            // 
            // cbxLyrRel
            // 
            this.cbxLyrRel.FormattingEnabled = true;
            this.cbxLyrRel.Location = new System.Drawing.Point(100, 55);
            this.cbxLyrRel.Name = "cbxLyrRel";
            this.cbxLyrRel.Size = new System.Drawing.Size(167, 21);
            this.cbxLyrRel.TabIndex = 66;
            this.cbxLyrRel.SelectedIndexChanged += new System.EventHandler(this.cbxLyrRel_SelectedIndexChanged);
            // 
            // label68
            // 
            this.label68.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label68.AutoSize = true;
            this.label68.Location = new System.Drawing.Point(13, 22);
            this.label68.Name = "label68";
            this.label68.Size = new System.Drawing.Size(73, 13);
            this.label68.TabIndex = 54;
            this.label68.Text = "Relasjonstype";
            // 
            // label69
            // 
            this.label69.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label69.AutoSize = true;
            this.label69.Location = new System.Drawing.Point(335, 62);
            this.label69.Margin = new System.Windows.Forms.Padding(45, 0, 3, 0);
            this.label69.Name = "label69";
            this.label69.Size = new System.Drawing.Size(82, 13);
            this.label69.TabIndex = 60;
            this.label69.Text = "Obj.class name:";
            this.label69.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbxRelTypeRel
            // 
            this.cbxRelTypeRel.FormattingEnabled = true;
            this.cbxRelTypeRel.Location = new System.Drawing.Point(100, 15);
            this.cbxRelTypeRel.Name = "cbxRelTypeRel";
            this.cbxRelTypeRel.Size = new System.Drawing.Size(167, 21);
            this.cbxRelTypeRel.TabIndex = 65;
            this.cbxRelTypeRel.SelectedValueChanged += new System.EventHandler(this.cbxRelTypeRel_SelectedValueChanged);
            // 
            // cbxObjClassName
            // 
            this.cbxObjClassName.Enabled = false;
            this.cbxObjClassName.FormattingEnabled = true;
            this.cbxObjClassName.Location = new System.Drawing.Point(419, 55);
            this.cbxObjClassName.Margin = new System.Windows.Forms.Padding(49, 3, 3, 3);
            this.cbxObjClassName.Name = "cbxObjClassName";
            this.cbxObjClassName.Size = new System.Drawing.Size(348, 21);
            this.cbxObjClassName.TabIndex = 71;
            // 
            // label70
            // 
            this.label70.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label70.AutoSize = true;
            this.label70.Location = new System.Drawing.Point(6, 25);
            this.label70.Name = "label70";
            this.label70.Size = new System.Drawing.Size(100, 13);
            this.label70.TabIndex = 51;
            this.label70.Text = "Kobling relasjosnfelt";
            // 
            // label71
            // 
            this.label71.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label71.AutoSize = true;
            this.label71.Location = new System.Drawing.Point(335, 93);
            this.label71.Margin = new System.Windows.Forms.Padding(45, 0, 3, 0);
            this.label71.Name = "label71";
            this.label71.Size = new System.Drawing.Size(52, 13);
            this.label71.TabIndex = 61;
            this.label71.Text = "Datakilde";
            // 
            // cbxObjectClass_RelField
            // 
            this.cbxObjectClass_RelField.FormattingEnabled = true;
            this.cbxObjectClass_RelField.Location = new System.Drawing.Point(112, 22);
            this.cbxObjectClass_RelField.Name = "cbxObjectClass_RelField";
            this.cbxObjectClass_RelField.Size = new System.Drawing.Size(167, 21);
            this.cbxObjectClass_RelField.TabIndex = 64;
            // 
            // txtDatasourceRel
            // 
            this.txtDatasourceRel.Enabled = false;
            this.txtDatasourceRel.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDatasourceRel.Location = new System.Drawing.Point(419, 90);
            this.txtDatasourceRel.Margin = new System.Windows.Forms.Padding(29, 3, 3, 3);
            this.txtDatasourceRel.Name = "txtDatasourceRel";
            this.txtDatasourceRel.Size = new System.Drawing.Size(348, 17);
            this.txtDatasourceRel.TabIndex = 70;
            // 
            // label72
            // 
            this.label72.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label72.AutoSize = true;
            this.label72.Location = new System.Drawing.Point(6, 60);
            this.label72.Name = "label72";
            this.label72.Size = new System.Drawing.Size(78, 13);
            this.label72.TabIndex = 50;
            this.label72.Text = "Seleksjonstype";
            // 
            // label73
            // 
            this.label73.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label73.AutoSize = true;
            this.label73.Location = new System.Drawing.Point(311, 25);
            this.label73.Margin = new System.Windows.Forms.Padding(25, 0, 3, 0);
            this.label73.Name = "label73";
            this.label73.Size = new System.Drawing.Size(118, 13);
            this.label73.TabIndex = 57;
            this.label73.Text = "Opprinnelig relasjonsfelt";
            this.label73.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label74
            // 
            this.label74.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label74.AutoSize = true;
            this.label74.Location = new System.Drawing.Point(6, 26);
            this.label74.Name = "label74";
            this.label74.Size = new System.Drawing.Size(73, 13);
            this.label74.TabIndex = 53;
            this.label74.Text = "Relasjonstype";
            // 
            // cbxMainObjectClass_relField
            // 
            this.cbxMainObjectClass_relField.FormattingEnabled = true;
            this.cbxMainObjectClass_relField.Location = new System.Drawing.Point(435, 17);
            this.cbxMainObjectClass_relField.Name = "cbxMainObjectClass_relField";
            this.cbxMainObjectClass_relField.Size = new System.Drawing.Size(181, 21);
            this.cbxMainObjectClass_relField.TabIndex = 69;
            // 
            // cbxSelectionTypeRel
            // 
            this.cbxSelectionTypeRel.FormattingEnabled = true;
            this.cbxSelectionTypeRel.Location = new System.Drawing.Point(112, 57);
            this.cbxSelectionTypeRel.Name = "cbxSelectionTypeRel";
            this.cbxSelectionTypeRel.Size = new System.Drawing.Size(247, 21);
            this.cbxSelectionTypeRel.TabIndex = 62;
            // 
            // cbxSpatialRelTypeRel
            // 
            this.cbxSpatialRelTypeRel.FormattingEnabled = true;
            this.cbxSpatialRelTypeRel.Location = new System.Drawing.Point(112, 23);
            this.cbxSpatialRelTypeRel.Name = "cbxSpatialRelTypeRel";
            this.cbxSpatialRelTypeRel.Size = new System.Drawing.Size(167, 21);
            this.cbxSpatialRelTypeRel.TabIndex = 63;
            // 
            // chxIncludeFeaturesRel
            // 
            this.chxIncludeFeaturesRel.AutoSize = true;
            this.chxIncludeFeaturesRel.Location = new System.Drawing.Point(13, 112);
            this.chxIncludeFeaturesRel.Name = "chxIncludeFeaturesRel";
            this.chxIncludeFeaturesRel.Size = new System.Drawing.Size(195, 17);
            this.chxIncludeFeaturesRel.TabIndex = 68;
            this.chxIncludeFeaturesRel.Text = global::VA_Analysemodul.Properties.Resources.IncludeFeatures;
            this.chxIncludeFeaturesRel.UseVisualStyleBackColor = true;
            // 
            // btnEditQuery
            // 
            this.btnEditQuery.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnEditQuery.Location = new System.Drawing.Point(100, 353);
            this.btnEditQuery.Name = "btnEditQuery";
            this.btnEditQuery.Size = new System.Drawing.Size(106, 23);
            this.btnEditQuery.TabIndex = 52;
            this.btnEditQuery.Text = global::VA_Analysemodul.Properties.Resources.EditQuery;
            this.btnEditQuery.UseVisualStyleBackColor = true;
            this.btnEditQuery.Click += new System.EventHandler(this.btnEditQuery_Click);
            // 
            // label75
            // 
            this.label75.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label75.AutoSize = true;
            this.label75.Location = new System.Drawing.Point(307, 26);
            this.label75.Margin = new System.Windows.Forms.Padding(25, 0, 3, 0);
            this.label75.Name = "label75";
            this.label75.Size = new System.Drawing.Size(74, 13);
            this.label75.TabIndex = 58;
            this.label75.Text = "Bufferstørrelse";
            this.label75.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnSaveRelation
            // 
            this.btnSaveRelation.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSaveRelation.Location = new System.Drawing.Point(272, 353);
            this.btnSaveRelation.Margin = new System.Windows.Forms.Padding(53, 3, 3, 3);
            this.btnSaveRelation.Name = "btnSaveRelation";
            this.btnSaveRelation.Size = new System.Drawing.Size(105, 23);
            this.btnSaveRelation.TabIndex = 56;
            this.btnSaveRelation.Text = global::VA_Analysemodul.Properties.Resources.SaveRelation;
            this.btnSaveRelation.UseVisualStyleBackColor = true;
            this.btnSaveRelation.Click += new System.EventHandler(this.btnSaveRelation_Click);
            // 
            // txtBufferDistanceRel
            // 
            this.txtBufferDistanceRel.Location = new System.Drawing.Point(431, 23);
            this.txtBufferDistanceRel.Name = "txtBufferDistanceRel";
            this.txtBufferDistanceRel.Size = new System.Drawing.Size(140, 20);
            this.txtBufferDistanceRel.TabIndex = 67;
            // 
            // btnDeleteRelation
            // 
            this.btnDeleteRelation.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnDeleteRelation.Location = new System.Drawing.Point(413, 353);
            this.btnDeleteRelation.Margin = new System.Windows.Forms.Padding(53, 3, 3, 3);
            this.btnDeleteRelation.Name = "btnDeleteRelation";
            this.btnDeleteRelation.Size = new System.Drawing.Size(120, 23);
            this.btnDeleteRelation.TabIndex = 59;
            this.btnDeleteRelation.Text = global::VA_Analysemodul.Properties.Resources.DeleteRelation;
            this.btnDeleteRelation.UseVisualStyleBackColor = true;
            this.btnDeleteRelation.Click += new System.EventHandler(this.btnDeleteRelation_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtAntallRelasjoner);
            this.groupBox1.Controls.Add(this.chxAntallRelaterte);
            this.groupBox1.Controls.Add(this.label70);
            this.groupBox1.Controls.Add(this.cbxObjectClass_RelField);
            this.groupBox1.Controls.Add(this.label73);
            this.groupBox1.Controls.Add(this.cbxMainObjectClass_relField);
            this.groupBox1.Controls.Add(this.chxIncludeFeaturesRel);
            this.groupBox1.Controls.Add(this.cbxSelectionTypeRel);
            this.groupBox1.Controls.Add(this.label72);
            this.groupBox1.Location = new System.Drawing.Point(14, 113);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(753, 135);
            this.groupBox1.TabIndex = 72;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Relasjon";
            // 
            // txtAntallRelasjoner
            // 
            this.txtAntallRelasjoner.Enabled = false;
            this.txtAntallRelasjoner.Location = new System.Drawing.Point(112, 85);
            this.txtAntallRelasjoner.Name = "txtAntallRelasjoner";
            this.txtAntallRelasjoner.Size = new System.Drawing.Size(100, 20);
            this.txtAntallRelasjoner.TabIndex = 71;
            this.txtAntallRelasjoner.Text = "0";
            // 
            // chxAntallRelaterte
            // 
            this.chxAntallRelaterte.AutoSize = true;
            this.chxAntallRelaterte.Location = new System.Drawing.Point(13, 89);
            this.chxAntallRelaterte.Name = "chxAntallRelaterte";
            this.chxAntallRelaterte.Size = new System.Drawing.Size(52, 17);
            this.chxAntallRelaterte.TabIndex = 70;
            this.chxAntallRelaterte.Text = "Antall";
            this.chxAntallRelaterte.UseVisualStyleBackColor = true;
            this.chxAntallRelaterte.CheckedChanged += new System.EventHandler(this.chxAntallRelaterte_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label74);
            this.groupBox2.Controls.Add(this.cbxSpatialRelTypeRel);
            this.groupBox2.Controls.Add(this.label75);
            this.groupBox2.Controls.Add(this.txtBufferDistanceRel);
            this.groupBox2.Location = new System.Drawing.Point(7, 264);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(702, 67);
            this.groupBox2.TabIndex = 73;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Romlig spørring";
            // 
            // RelationControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label67);
            this.Controls.Add(this.cbxLyrRel);
            this.Controls.Add(this.label68);
            this.Controls.Add(this.label69);
            this.Controls.Add(this.cbxRelTypeRel);
            this.Controls.Add(this.cbxObjClassName);
            this.Controls.Add(this.label71);
            this.Controls.Add(this.txtDatasourceRel);
            this.Controls.Add(this.btnEditQuery);
            this.Controls.Add(this.btnSaveRelation);
            this.Controls.Add(this.btnDeleteRelation);
            this.Name = "RelationControl";
            this.Size = new System.Drawing.Size(778, 380);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label67;
        private System.Windows.Forms.ComboBox cbxLyrRel;
        private System.Windows.Forms.Label label68;
        private System.Windows.Forms.Label label69;
        private System.Windows.Forms.ComboBox cbxRelTypeRel;
        private System.Windows.Forms.ComboBox cbxObjClassName;
        private System.Windows.Forms.Label label70;
        private System.Windows.Forms.Label label71;
        private System.Windows.Forms.ComboBox cbxObjectClass_RelField;
        private System.Windows.Forms.TextBox txtDatasourceRel;
        private System.Windows.Forms.Label label72;
        private System.Windows.Forms.Label label73;
        private System.Windows.Forms.Label label74;
        private System.Windows.Forms.ComboBox cbxMainObjectClass_relField;
        private System.Windows.Forms.ComboBox cbxSelectionTypeRel;
        private System.Windows.Forms.ComboBox cbxSpatialRelTypeRel;
        private System.Windows.Forms.CheckBox chxIncludeFeaturesRel;
        private System.Windows.Forms.Button btnEditQuery;
        private System.Windows.Forms.Label label75;
        private System.Windows.Forms.Button btnSaveRelation;
        private System.Windows.Forms.TextBox txtBufferDistanceRel;
        private System.Windows.Forms.Button btnDeleteRelation;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtAntallRelasjoner;
        private System.Windows.Forms.CheckBox chxAntallRelaterte;
    }
}
