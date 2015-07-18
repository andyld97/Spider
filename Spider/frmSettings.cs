using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Spider
{
    public partial class frmSettings : Form
    {
        private string filePath = Path.Combine(Application.StartupPath, "Settings.xml");
        private Class.Save saveInstance = null;
        private frmMain owner = null;

        public frmSettings(frmMain owner)
        {
            InitializeComponent();
            this.owner = owner;
        }

        private void frmSettings_Load(object sender, EventArgs e)
        {
            if (File.Exists(this.filePath))
            {
                Serialization.Serialization<Class.Save> s = new Serialization.Serialization<Class.Save>();
                saveInstance = s.Read(this.filePath, Serialization.Serialization<Class.Save>.Typ.Normal) as Class.Save;
                if (saveInstance.Background == string.Empty)
                    txtBackground.Text = "Standart";
                else
                    txtBackground.Text = saveInstance.Background;
            }
            else
                txtBackground.Text = "Standart";
            if (saveInstance == null)
                saveInstance = new Class.Save();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { FileName = ".png" })
            {
                if (ofd.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    txtBackground.Text = ofd.FileName;
                    saveInstance.Background = ofd.FileName;
                    this.Save();
                }
            }
        }

        private void btnStandard_Click(object sender, EventArgs e)
        {
            txtBackground.Text = "Standart";
            saveInstance.Background = string.Empty;
            this.Save();
        }

        private void Save()
        {
            try
            {
                Serialization.Serialization<Class.Save> s = new Serialization.Serialization<Class.Save>();
                s.Save(this.filePath, this.saveInstance, Serialization.Serialization<Class.Save>.Typ.Normal);
                MessageBox.Show(this, "Die Einstellungen wurden erfolgreich gespeichert!", "Erfolg!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (this.owner != null)
                    this.owner.ReadSettings();
            }
            catch  (Exception es) {
                MessageBox.Show("Leider ist der folgende Fehler aufgetreten: " + es.Message);
            }
            
        }
    }
}
