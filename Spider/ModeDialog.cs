using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Spider
{
    public class ModeDialog : Form
    {
        private Label label1;
        private RadioButton r1;
        private RadioButton r2;
        private RadioButton r4;
        private Button btnOkay;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
        private Panel panel1;
        private Panel panel2;
        private PictureBox pictureBox4;
        private Panel panel3;
        private PictureBox pictureBox7;
        private PictureBox pictureBox5;
        private PictureBox pictureBox6;
        private PictureBox pictureBox1;

        public Spider.Class.Game.Mode SelectedMode
        {
            get
            {
                if (r1.Checked)
                    return Class.Game.Mode.OneSuit;
                else if (r2.Checked)
                    return Class.Game.Mode.TwoSuits;
                else
                    return Class.Game.Mode.FourSuits;                
            }
        }

        public ModeDialog()
        {
            this.InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.r1 = new System.Windows.Forms.RadioButton();
            this.r2 = new System.Windows.Forms.RadioButton();
            this.r4 = new System.Windows.Forms.RadioButton();
            this.btnOkay = new System.Windows.Forms.Button();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(247, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "Bitte wählen Sie aus, welchen Spielmodus Sie \r\nspielen möchten:";
            // 
            // r1
            // 
            this.r1.AutoSize = true;
            this.r1.Checked = true;
            this.r1.Location = new System.Drawing.Point(12, 47);
            this.r1.Name = "r1";
            this.r1.Size = new System.Drawing.Size(118, 19);
            this.r1.TabIndex = 1;
            this.r1.TabStop = true;
            this.r1.Text = "1 Deck (einfarbig)";
            this.r1.UseVisualStyleBackColor = true;
            // 
            // r2
            // 
            this.r2.AutoSize = true;
            this.r2.Location = new System.Drawing.Point(12, 165);
            this.r2.Name = "r2";
            this.r2.Size = new System.Drawing.Size(130, 19);
            this.r2.TabIndex = 2;
            this.r2.Text = "2 Decks (zweifarbig)";
            this.r2.UseVisualStyleBackColor = true;
            // 
            // r4
            // 
            this.r4.AutoSize = true;
            this.r4.Enabled = false;
            this.r4.Location = new System.Drawing.Point(12, 283);
            this.r4.Name = "r4";
            this.r4.Size = new System.Drawing.Size(130, 19);
            this.r4.TabIndex = 3;
            this.r4.Text = "4 Decks (zweifarbig)";
            this.r4.UseVisualStyleBackColor = true;
            this.r4.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // btnOkay
            // 
            this.btnOkay.Location = new System.Drawing.Point(201, 403);
            this.btnOkay.Name = "btnOkay";
            this.btnOkay.Size = new System.Drawing.Size(75, 23);
            this.btnOkay.TabIndex = 5;
            this.btnOkay.Text = "OK";
            this.btnOkay.UseVisualStyleBackColor = true;
            this.btnOkay.Click += new System.EventHandler(this.btnOkay_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackgroundImage = global::Spider.Properties.Resources.One2;
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox3.Location = new System.Drawing.Point(71, 8);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(56, 73);
            this.pictureBox3.TabIndex = 8;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = global::Spider.Properties.Resources.One1;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Location = new System.Drawing.Point(133, 8);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(56, 73);
            this.pictureBox2.TabIndex = 7;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::Spider.Properties.Resources.One1;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(9, 8);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(56, 73);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkGreen;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(15, 70);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(261, 89);
            this.panel1.TabIndex = 9;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DarkGreen;
            this.panel2.Controls.Add(this.pictureBox4);
            this.panel2.Controls.Add(this.pictureBox3);
            this.panel2.Location = new System.Drawing.Point(15, 190);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(261, 89);
            this.panel2.TabIndex = 10;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackgroundImage = global::Spider.Properties.Resources.One1;
            this.pictureBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox4.Location = new System.Drawing.Point(9, 8);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(56, 73);
            this.pictureBox4.TabIndex = 6;
            this.pictureBox4.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.DarkGreen;
            this.panel3.Controls.Add(this.pictureBox7);
            this.panel3.Controls.Add(this.pictureBox5);
            this.panel3.Controls.Add(this.pictureBox6);
            this.panel3.Controls.Add(this.pictureBox2);
            this.panel3.Location = new System.Drawing.Point(12, 308);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(264, 89);
            this.panel3.TabIndex = 11;
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackgroundImage = global::Spider.Properties.Resources.One1;
            this.pictureBox5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox5.Location = new System.Drawing.Point(9, 8);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(56, 73);
            this.pictureBox5.TabIndex = 6;
            this.pictureBox5.TabStop = false;
            // 
            // pictureBox6
            // 
            this.pictureBox6.BackgroundImage = global::Spider.Properties.Resources.One2;
            this.pictureBox6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox6.Location = new System.Drawing.Point(71, 8);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(56, 73);
            this.pictureBox6.TabIndex = 8;
            this.pictureBox6.TabStop = false;
            // 
            // pictureBox7
            // 
            this.pictureBox7.BackgroundImage = global::Spider.Properties.Resources.One2;
            this.pictureBox7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox7.Location = new System.Drawing.Point(195, 8);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(56, 73);
            this.pictureBox7.TabIndex = 9;
            this.pictureBox7.TabStop = false;
            // 
            // ModeDialog
            // 
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(286, 433);
            this.ControlBox = false;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnOkay);
            this.Controls.Add(this.r4);
            this.Controls.Add(this.r2);
            this.Controls.Add(this.r1);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ModeDialog";
            this.Text = "Spiel starten";
            this.Load += new System.EventHandler(this.ModeDialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void ModeDialog_Load(object sender, EventArgs e)
        {

        }

        private void btnOkay_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
