namespace CalibreCatalog {
    partial class frmCalibreCatalog {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCalibreCatalog));
            this.fieldXMLFile = new System.Windows.Forms.TextBox();
            this.lblCalibreXMLFile = new System.Windows.Forms.Label();
            this.btnCalibreXMLFile = new System.Windows.Forms.Button();
            this.btnCreateCatalog = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.fieldTargetDirectory = new System.Windows.Forms.TextBox();
            this.lblTargetDirectory = new System.Windows.Forms.Label();
            this.btnCalibreSelectTargetDirectory = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // fieldXMLFile
            // 
            this.fieldXMLFile.Location = new System.Drawing.Point(117, 25);
            this.fieldXMLFile.Name = "fieldXMLFile";
            this.fieldXMLFile.Size = new System.Drawing.Size(231, 20);
            this.fieldXMLFile.TabIndex = 0;
            this.fieldXMLFile.TextChanged += new System.EventHandler(this.fieldXMLFile_TextChanged);
            // 
            // lblCalibreXMLFile
            // 
            this.lblCalibreXMLFile.AutoSize = true;
            this.lblCalibreXMLFile.Location = new System.Drawing.Point(47, 28);
            this.lblCalibreXMLFile.Name = "lblCalibreXMLFile";
            this.lblCalibreXMLFile.Size = new System.Drawing.Size(64, 13);
            this.lblCalibreXMLFile.TabIndex = 1;
            this.lblCalibreXMLFile.Text = "Calibre XML";
            // 
            // btnCalibreXMLFile
            // 
            this.btnCalibreXMLFile.Location = new System.Drawing.Point(352, 24);
            this.btnCalibreXMLFile.Name = "btnCalibreXMLFile";
            this.btnCalibreXMLFile.Size = new System.Drawing.Size(145, 21);
            this.btnCalibreXMLFile.TabIndex = 2;
            this.btnCalibreXMLFile.Text = "Select Calibre XML ...";
            this.btnCalibreXMLFile.UseVisualStyleBackColor = true;
            this.btnCalibreXMLFile.Click += new System.EventHandler(this.btnCalibreXMLFile_Click);
            // 
            // btnCreateCatalog
            // 
            this.btnCreateCatalog.Enabled = false;
            this.btnCreateCatalog.Location = new System.Drawing.Point(352, 138);
            this.btnCreateCatalog.Name = "btnCreateCatalog";
            this.btnCreateCatalog.Size = new System.Drawing.Size(145, 21);
            this.btnCreateCatalog.TabIndex = 3;
            this.btnCreateCatalog.Text = "Create Catalog";
            this.btnCreateCatalog.UseVisualStyleBackColor = true;
            this.btnCreateCatalog.Click += new System.EventHandler(this.btnCreateCatalog_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(31, 138);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 21);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // fieldTargetDirectory
            // 
            this.fieldTargetDirectory.Location = new System.Drawing.Point(117, 51);
            this.fieldTargetDirectory.Name = "fieldTargetDirectory";
            this.fieldTargetDirectory.Size = new System.Drawing.Size(231, 20);
            this.fieldTargetDirectory.TabIndex = 5;
            this.fieldTargetDirectory.TextChanged += new System.EventHandler(this.fieldTargetDirectory_TextChanged);
            // 
            // lblTargetDirectory
            // 
            this.lblTargetDirectory.AutoSize = true;
            this.lblTargetDirectory.Location = new System.Drawing.Point(28, 54);
            this.lblTargetDirectory.Name = "lblTargetDirectory";
            this.lblTargetDirectory.Size = new System.Drawing.Size(83, 13);
            this.lblTargetDirectory.TabIndex = 6;
            this.lblTargetDirectory.Text = "Target Directory";
            // 
            // btnCalibreSelectTargetDirectory
            // 
            this.btnCalibreSelectTargetDirectory.Location = new System.Drawing.Point(352, 51);
            this.btnCalibreSelectTargetDirectory.Name = "btnCalibreSelectTargetDirectory";
            this.btnCalibreSelectTargetDirectory.Size = new System.Drawing.Size(145, 21);
            this.btnCalibreSelectTargetDirectory.TabIndex = 7;
            this.btnCalibreSelectTargetDirectory.Text = "Select target Directory";
            this.btnCalibreSelectTargetDirectory.UseVisualStyleBackColor = true;
            this.btnCalibreSelectTargetDirectory.Click += new System.EventHandler(this.btnCalibreSelectTargetDirectory_Click);
            // 
            // frmCalibreCatalog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(509, 171);
            this.Controls.Add(this.btnCalibreSelectTargetDirectory);
            this.Controls.Add(this.lblTargetDirectory);
            this.Controls.Add(this.fieldTargetDirectory);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnCreateCatalog);
            this.Controls.Add(this.btnCalibreXMLFile);
            this.Controls.Add(this.lblCalibreXMLFile);
            this.Controls.Add(this.fieldXMLFile);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCalibreCatalog";
            this.Text = "Calibre - Catalog creator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox fieldXMLFile;
        private System.Windows.Forms.Label lblCalibreXMLFile;
        private System.Windows.Forms.Button btnCalibreXMLFile;
        private System.Windows.Forms.Button btnCreateCatalog;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox fieldTargetDirectory;
        private System.Windows.Forms.Label lblTargetDirectory;
        private System.Windows.Forms.Button btnCalibreSelectTargetDirectory;
    }
}

