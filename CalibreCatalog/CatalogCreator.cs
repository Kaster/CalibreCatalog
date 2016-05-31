using CalibreCatalogBusinessLogic;
using KasterUtil;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalibreCatalog {
    public partial class frmCalibreCatalog : Form {
        public frmCalibreCatalog() {
            InitializeComponent();
        }

        private void btnCalibreXMLFile_Click(object sender, EventArgs e) {
            // Create an instance of the open file dialog box.
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            // Set filter options and filter index.
            openFileDialog1.Filter = "XML Files (.xml)|*.xml|All Files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;

            openFileDialog1.Multiselect = true;

            // Call the ShowDialog method to show the dialog box.
            DialogResult clicked = openFileDialog1.ShowDialog();
            bool? userClickedOK = DialogResult.OK == clicked;

            // Process input if the user clicked OK.
            if (userClickedOK == true) {
                // Open the selected file to read.
                String fileName = openFileDialog1.FileName;
                fieldXMLFile.Text = openFileDialog1.FileName;
                checkCreateCatalogEnable();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            Application.Exit();
        }

        private void btnCreateCatalog_Click(object sender, EventArgs e) {
            String filename = fieldXMLFile.Text;
            if (filename != null && filename.Length > 0 && File.Exists(filename)) {
                try {
                    Facade.Instance.generatePdfCatalog(filename, fieldTargetDirectory.Text);
                    MessageBox.Show("PDF catalog was created.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                } catch (Exception ex) {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            } else {
                MessageBox.Show("Calibre-XML-File-Path is wrong. ");
            }
        }

        private bool checkCreateCatalogEnable() {
            bool buttonCreateCatalogEnabled = File.Exists(fieldXMLFile.Text) && Directory.Exists(fieldTargetDirectory.Text);
            btnCreateCatalog.Enabled = buttonCreateCatalogEnabled;
            return buttonCreateCatalogEnabled;
        }

        private void btnCalibreSelectTargetDirectory_Click(object sender, EventArgs e) {
            FolderBrowserDialog openFolderDialog = new FolderBrowserDialog();
            openFolderDialog.Description =
            "Select target directory for generated PDF file.";
            openFolderDialog.ShowNewFolderButton = true;
            openFolderDialog.RootFolder = Environment.SpecialFolder.Personal;
            DialogResult result = openFolderDialog.ShowDialog();
            if (result == DialogResult.OK) {
                fieldTargetDirectory.Text = openFolderDialog.SelectedPath;
                checkCreateCatalogEnable();
            }
        }

        private void fieldXMLFile_TextChanged(object sender, EventArgs e) {
            checkCreateCatalogEnable();
        }

        private void fieldTargetDirectory_TextChanged(object sender, EventArgs e) {
            checkCreateCatalogEnable();
        }
    }
}
