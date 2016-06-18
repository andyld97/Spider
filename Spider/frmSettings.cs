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
        private bool dontAct = false;

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
                this.saveInstance = s.Read(this.filePath, Serialization.Serialization<Class.Save>.Typ.Normal) as Class.Save;
                if (string.IsNullOrWhiteSpace(saveInstance.Background))
                    txtBackground.Text = "Standard";
                else
                    txtBackground.Text = saveInstance.Background;

                this.refresh(false);
            }
            else
                txtBackground.Text = "Standard";
            if (saveInstance == null)
                saveInstance = new Class.Save();
        }

        private void refresh(bool save = false)
        {
            this.pnlFont.BackColor = this.saveInstance.FontColor;
            this.pnlNotActive.BackColor = this.saveInstance.ActiveCardsColor;
            this.pnlSelect.BackColor = this.saveInstance.SelectColor;
            this.pnlTip.BackColor = this.saveInstance.TipColor;
            this.dontAct = true;
            this.chkHWK.Checked = this.saveInstance.HW_ACC;
            this.dontAct = false;
            this.lblHWInfo.Text = (this.saveInstance.HW_ACC ? "SlimDX" : "GDI+");

            if (save)
                this.Save();
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

        private void lnkSelect_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (ColorDialog cld = new ColorDialog())
            {
                if (cld.ShowDialog(this) == DialogResult.OK)
                {
                    this.saveInstance.SelectColor = cld.Color;
                    this.refresh(true);
                }
            }
        }

        private void lnkNotActive_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (ColorDialog cld = new ColorDialog())
            {
                if (cld.ShowDialog(this) == DialogResult.OK)
                {
                    this.saveInstance.ActiveCardsColor = cld.Color;
                    this.refresh(true);
                }
            }
        }

        private void lnkTip_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (ColorDialog cld = new ColorDialog())
            {
                if (cld.ShowDialog(this) == DialogResult.OK)
                {
                    this.saveInstance.TipColor = cld.Color;
                    this.refresh(true);
                }
            }
        }

        private void lnkFont_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (ColorDialog cld = new ColorDialog())
            {
                if (cld.ShowDialog(this) == DialogResult.OK)
                {
                    this.saveInstance.FontColor = cld.Color;
                    this.refresh(true);
                }
            }
        }

        private void chkHWK_CheckedChanged(object sender, EventArgs e)
        {
            this.saveInstance.HW_ACC = (sender as CheckBox).Checked;
            this.lblHWInfo.Text = (this.saveInstance.HW_ACC ? "SlimDX" : "GDI+");
            if (!this.dontAct)
                this.Save();
        }
    }
}
