namespace VA_Analysemodul
{
    partial class EditFieldQueryView
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
            this.lblLayerName = new System.Windows.Forms.Label();
            this.txtLayerName = new System.Windows.Forms.TextBox();
            this.txtObjectClass = new System.Windows.Forms.TextBox();
            this.lblObjectClass = new System.Windows.Forms.Label();
            this.chxP1 = new System.Windows.Forms.CheckBox();
            this.lblFieldName = new System.Windows.Forms.Label();
            this.cbxFieldName = new System.Windows.Forms.ComboBox();
            this.cbxOperator = new System.Windows.Forms.ComboBox();
            this.lblOperator = new System.Windows.Forms.Label();
            this.cbxMainObjectClassValue = new System.Windows.Forms.ComboBox();
            this.lblValue = new System.Windows.Forms.Label();
            this.chxUnique = new System.Windows.Forms.CheckBox();
            this.chxSort = new System.Windows.Forms.CheckBox();
            this.lblValueList = new System.Windows.Forms.Label();
            this.lbxValueList = new System.Windows.Forms.ListBox();
            this.chxP2 = new System.Windows.Forms.CheckBox();
            this.lblAndOr = new System.Windows.Forms.Label();
            this.cbxAndOr = new System.Windows.Forms.ComboBox();
            this.btnSaveEdits = new System.Windows.Forms.Button();
            this.btnNewFieldQuery = new System.Windows.Forms.Button();
            this.btnDeleteFieldQuery = new System.Windows.Forms.Button();
            this.txtOID = new System.Windows.Forms.TextBox();
            this.txtTableNo = new System.Windows.Forms.TextBox();
            this.lsvFieldQueryList = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // lblLayerName
            // 
            this.lblLayerName.AutoSize = true;
            this.lblLayerName.Location = new System.Drawing.Point(13, 24);
            this.lblLayerName.Name = "lblLayerName";
            this.lblLayerName.Size = new System.Drawing.Size(49, 13);
            this.lblLayerName.TabIndex = 0;
            this.lblLayerName.Text = "Lagnavn";
            // 
            // txtLayerName
            // 
            this.txtLayerName.Enabled = false;
            this.txtLayerName.Location = new System.Drawing.Point(84, 21);
            this.txtLayerName.Name = "txtLayerName";
            this.txtLayerName.Size = new System.Drawing.Size(206, 20);
            this.txtLayerName.TabIndex = 1;
            this.txtLayerName.TextChanged += new System.EventHandler(this.txtLayerName_TextChanged);
            // 
            // txtObjectClass
            // 
            this.txtObjectClass.Enabled = false;
            this.txtObjectClass.Location = new System.Drawing.Point(472, 21);
            this.txtObjectClass.Name = "txtObjectClass";
            this.txtObjectClass.Size = new System.Drawing.Size(206, 20);
            this.txtObjectClass.TabIndex = 3;
            // 
            // lblObjectClass
            // 
            this.lblObjectClass.AutoSize = true;
            this.lblObjectClass.Location = new System.Drawing.Point(367, 24);
            this.lblObjectClass.Name = "lblObjectClass";
            this.lblObjectClass.Size = new System.Drawing.Size(68, 13);
            this.lblObjectClass.TabIndex = 2;
            this.lblObjectClass.Text = "Objektklasse";
            // 
            // chxP1
            // 
            this.chxP1.AutoSize = true;
            this.chxP1.Location = new System.Drawing.Point(16, 304);
            this.chxP1.Name = "chxP1";
            this.chxP1.Size = new System.Drawing.Size(29, 17);
            this.chxP1.TabIndex = 5;
            this.chxP1.Text = global::VA_Analysemodul.Properties.Resources.PStart;
            this.chxP1.UseVisualStyleBackColor = true;
            // 
            // lblFieldName
            // 
            this.lblFieldName.AutoSize = true;
            this.lblFieldName.Location = new System.Drawing.Point(51, 286);
            this.lblFieldName.Name = "lblFieldName";
            this.lblFieldName.Size = new System.Drawing.Size(48, 13);
            this.lblFieldName.TabIndex = 6;
            this.lblFieldName.Text = "Feltnavn";
            // 
            // cbxFieldName
            // 
            this.cbxFieldName.FormattingEnabled = true;
            this.cbxFieldName.Location = new System.Drawing.Point(54, 302);
            this.cbxFieldName.Name = "cbxFieldName";
            this.cbxFieldName.Size = new System.Drawing.Size(150, 21);
            this.cbxFieldName.TabIndex = 7;
            this.cbxFieldName.SelectedValueChanged += new System.EventHandler(this.cbxFieldName_SelectedValueChanged);
            // 
            // cbxOperator
            // 
            this.cbxOperator.FormattingEnabled = true;
            this.cbxOperator.Items.AddRange(new object[] {
            "=",
            ">",
            "<",
            "<>",
            ">=",
            "<=",
            "LIKE",
            "IS",
            "NOT"});
            this.cbxOperator.Location = new System.Drawing.Point(225, 302);
            this.cbxOperator.Name = "cbxOperator";
            this.cbxOperator.Size = new System.Drawing.Size(72, 21);
            this.cbxOperator.TabIndex = 9;
            // 
            // lblOperator
            // 
            this.lblOperator.AutoSize = true;
            this.lblOperator.Location = new System.Drawing.Point(222, 286);
            this.lblOperator.Name = "lblOperator";
            this.lblOperator.Size = new System.Drawing.Size(48, 13);
            this.lblOperator.TabIndex = 8;
            this.lblOperator.Text = "Operatør";
            // 
            // cbxMainObjectClassValue
            // 
            this.cbxMainObjectClassValue.FormattingEnabled = true;
            this.cbxMainObjectClassValue.Location = new System.Drawing.Point(304, 302);
            this.cbxMainObjectClassValue.Name = "cbxMainObjectClassValue";
            this.cbxMainObjectClassValue.Size = new System.Drawing.Size(150, 21);
            this.cbxMainObjectClassValue.TabIndex = 11;
            // 
            // lblValue
            // 
            this.lblValue.AutoSize = true;
            this.lblValue.Location = new System.Drawing.Point(301, 286);
            this.lblValue.Name = "lblValue";
            this.lblValue.Size = new System.Drawing.Size(47, 13);
            this.lblValue.TabIndex = 10;
            this.lblValue.Text = "Feltverdi";
            // 
            // chxUnique
            // 
            this.chxUnique.AutoSize = true;
            this.chxUnique.Location = new System.Drawing.Point(480, 302);
            this.chxUnique.Name = "chxUnique";
            this.chxUnique.Size = new System.Drawing.Size(48, 17);
            this.chxUnique.TabIndex = 12;
            this.chxUnique.Text = global::VA_Analysemodul.Properties.Resources.Unique;
            this.chxUnique.UseVisualStyleBackColor = true;
            this.chxUnique.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // chxSort
            // 
            this.chxSort.AutoSize = true;
            this.chxSort.Location = new System.Drawing.Point(534, 302);
            this.chxSort.Name = "chxSort";
            this.chxSort.Size = new System.Drawing.Size(54, 17);
            this.chxSort.TabIndex = 13;
            this.chxSort.Text = global::VA_Analysemodul.Properties.Resources.Sort;
            this.chxSort.UseVisualStyleBackColor = true;
            this.chxSort.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // lblValueList
            // 
            this.lblValueList.AutoSize = true;
            this.lblValueList.Location = new System.Drawing.Point(585, 286);
            this.lblValueList.Name = "lblValueList";
            this.lblValueList.Size = new System.Drawing.Size(65, 13);
            this.lblValueList.TabIndex = 14;
            this.lblValueList.Text = "Feltverdiliste";
            // 
            // lbxValueList
            // 
            this.lbxValueList.FormattingEnabled = true;
            this.lbxValueList.Location = new System.Drawing.Point(588, 302);
            this.lbxValueList.Name = "lbxValueList";
            this.lbxValueList.Size = new System.Drawing.Size(167, 95);
            this.lbxValueList.TabIndex = 15;
            // 
            // chxP2
            // 
            this.chxP2.AutoSize = true;
            this.chxP2.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chxP2.Location = new System.Drawing.Point(761, 304);
            this.chxP2.Name = "chxP2";
            this.chxP2.Size = new System.Drawing.Size(29, 17);
            this.chxP2.TabIndex = 16;
            this.chxP2.Text = global::VA_Analysemodul.Properties.Resources.PEnd;
            this.chxP2.UseVisualStyleBackColor = true;
            // 
            // lblAndOr
            // 
            this.lblAndOr.AutoSize = true;
            this.lblAndOr.Location = new System.Drawing.Point(818, 286);
            this.lblAndOr.Name = "lblAndOr";
            this.lblAndOr.Size = new System.Drawing.Size(48, 13);
            this.lblAndOr.TabIndex = 17;
            this.lblAndOr.Text = "And / Or";
            // 
            // cbxAndOr
            // 
            this.cbxAndOr.FormattingEnabled = true;
            this.cbxAndOr.Items.AddRange(new object[] {
            "AND",
            "OR"});
            this.cbxAndOr.Location = new System.Drawing.Point(821, 301);
            this.cbxAndOr.Name = "cbxAndOr";
            this.cbxAndOr.Size = new System.Drawing.Size(54, 21);
            this.cbxAndOr.TabIndex = 18;
            // 
            // btnSaveEdits
            // 
            this.btnSaveEdits.Location = new System.Drawing.Point(881, 131);
            this.btnSaveEdits.Name = "btnSaveEdits";
            this.btnSaveEdits.Size = new System.Drawing.Size(99, 23);
            this.btnSaveEdits.TabIndex = 19;
            this.btnSaveEdits.Text = global::VA_Analysemodul.Properties.Resources.SaveEdits;
            this.btnSaveEdits.UseVisualStyleBackColor = true;
            this.btnSaveEdits.Click += new System.EventHandler(this.btnSaveEdits_Click);
            // 
            // btnNewFieldQuery
            // 
            this.btnNewFieldQuery.Location = new System.Drawing.Point(881, 160);
            this.btnNewFieldQuery.Name = "btnNewFieldQuery";
            this.btnNewFieldQuery.Size = new System.Drawing.Size(99, 23);
            this.btnNewFieldQuery.TabIndex = 20;
            this.btnNewFieldQuery.Text = global::VA_Analysemodul.Properties.Resources.NewFieldQuery;
            this.btnNewFieldQuery.UseVisualStyleBackColor = true;
            this.btnNewFieldQuery.Click += new System.EventHandler(this.btnNewFieldQuery_Click);
            // 
            // btnDeleteFieldQuery
            // 
            this.btnDeleteFieldQuery.Location = new System.Drawing.Point(881, 189);
            this.btnDeleteFieldQuery.Name = "btnDeleteFieldQuery";
            this.btnDeleteFieldQuery.Size = new System.Drawing.Size(99, 23);
            this.btnDeleteFieldQuery.TabIndex = 21;
            this.btnDeleteFieldQuery.Text = global::VA_Analysemodul.Properties.Resources.DeleteFieldQuery;
            this.btnDeleteFieldQuery.UseVisualStyleBackColor = true;
            this.btnDeleteFieldQuery.Click += new System.EventHandler(this.btnDeleteFieldQuery_Click);
            // 
            // txtOID
            // 
            this.txtOID.Location = new System.Drawing.Point(761, 342);
            this.txtOID.Name = "txtOID";
            this.txtOID.Size = new System.Drawing.Size(34, 20);
            this.txtOID.TabIndex = 22;
            // 
            // txtTableNo
            // 
            this.txtTableNo.Location = new System.Drawing.Point(839, 342);
            this.txtTableNo.Name = "txtTableNo";
            this.txtTableNo.Size = new System.Drawing.Size(36, 20);
            this.txtTableNo.TabIndex = 23;
            // 
            // lsvFieldQueryList
            // 
            this.lsvFieldQueryList.Location = new System.Drawing.Point(16, 58);
            this.lsvFieldQueryList.Name = "lsvFieldQueryList";
            this.lsvFieldQueryList.Size = new System.Drawing.Size(859, 215);
            this.lsvFieldQueryList.TabIndex = 24;
            this.lsvFieldQueryList.UseCompatibleStateImageBehavior = false;
            this.lsvFieldQueryList.View = System.Windows.Forms.View.Details;
            this.lsvFieldQueryList.SelectedIndexChanged += new System.EventHandler(this.lsvFieldQueryList_SelectedIndexChanged);
            this.lsvFieldQueryList.Click += new System.EventHandler(this.lsvFieldQueryList_Click);
            // 
            // EditFieldQueryView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 413);
            this.Controls.Add(this.lsvFieldQueryList);
            this.Controls.Add(this.txtTableNo);
            this.Controls.Add(this.txtOID);
            this.Controls.Add(this.btnDeleteFieldQuery);
            this.Controls.Add(this.btnNewFieldQuery);
            this.Controls.Add(this.btnSaveEdits);
            this.Controls.Add(this.cbxAndOr);
            this.Controls.Add(this.lblAndOr);
            this.Controls.Add(this.chxP2);
            this.Controls.Add(this.lbxValueList);
            this.Controls.Add(this.lblValueList);
            this.Controls.Add(this.chxSort);
            this.Controls.Add(this.chxUnique);
            this.Controls.Add(this.cbxMainObjectClassValue);
            this.Controls.Add(this.lblValue);
            this.Controls.Add(this.cbxOperator);
            this.Controls.Add(this.lblOperator);
            this.Controls.Add(this.cbxFieldName);
            this.Controls.Add(this.lblFieldName);
            this.Controls.Add(this.chxP1);
            this.Controls.Add(this.txtObjectClass);
            this.Controls.Add(this.lblObjectClass);
            this.Controls.Add(this.txtLayerName);
            this.Controls.Add(this.lblLayerName);
            this.Name = "EditFieldQueryView";
            this.Text = "Opprett eller rediger spørring";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EditFieldQueryView_FormClosing);
            this.Load += new System.EventHandler(this.VaAnalyseModul_EditFieldQuery_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblLayerName;
        private System.Windows.Forms.TextBox txtLayerName;
        private System.Windows.Forms.TextBox txtObjectClass;
        private System.Windows.Forms.Label lblObjectClass;
        private System.Windows.Forms.CheckBox chxP1;
        private System.Windows.Forms.Label lblFieldName;
        private System.Windows.Forms.ComboBox cbxFieldName;
        private System.Windows.Forms.ComboBox cbxOperator;
        private System.Windows.Forms.Label lblOperator;
        private System.Windows.Forms.ComboBox cbxMainObjectClassValue;
        private System.Windows.Forms.Label lblValue;
        private System.Windows.Forms.CheckBox chxUnique;
        private System.Windows.Forms.CheckBox chxSort;
        private System.Windows.Forms.Label lblValueList;
        private System.Windows.Forms.ListBox lbxValueList;
        private System.Windows.Forms.CheckBox chxP2;
        private System.Windows.Forms.Label lblAndOr;
        private System.Windows.Forms.ComboBox cbxAndOr;
        private System.Windows.Forms.Button btnSaveEdits;
        private System.Windows.Forms.Button btnNewFieldQuery;
        private System.Windows.Forms.Button btnDeleteFieldQuery;
        private System.Windows.Forms.TextBox txtOID;
        private System.Windows.Forms.TextBox txtTableNo;
        private System.Windows.Forms.ListView lsvFieldQueryList;
    }
}