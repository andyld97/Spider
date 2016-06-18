namespace Spider
{
    partial class frmSettings
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
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtBackground = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnStandard = new System.Windows.Forms.Button();
            this.grpColors = new System.Windows.Forms.GroupBox();
            this.lnkTip = new System.Windows.Forms.LinkLabel();
            this.lnkFont = new System.Windows.Forms.LinkLabel();
            this.lnkNotActive = new System.Windows.Forms.LinkLabel();
            this.lnkSelect = new System.Windows.Forms.LinkLabel();
            this.pnlFont = new System.Windows.Forms.Panel();
            this.pnlTip = new System.Windows.Forms.Panel();
            this.pnlNotActive = new System.Windows.Forms.Panel();
            this.pnlSelect = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkHWK = new System.Windows.Forms.CheckBox();
            this.lblHWInfo = new System.Windows.Forms.Label();
            this.grpColors.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(12, 54);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(130, 23);
            this.btnSearch.TabIndex = 0;
            this.btnSearch.Text = "Durchsuchen";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtBackground
            // 
            this.txtBackground.BackColor = System.Drawing.Color.White;
            this.txtBackground.Location = new System.Drawing.Point(12, 25);
            this.txtBackground.Name = "txtBackground";
            this.txtBackground.ReadOnly = true;
            this.txtBackground.Size = new System.Drawing.Size(308, 23);
            this.txtBackground.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Hintergrundbild:";
            // 
            // btnStandard
            // 
            this.btnStandard.Location = new System.Drawing.Point(148, 54);
            this.btnStandard.Name = "btnStandard";
            this.btnStandard.Size = new System.Drawing.Size(172, 23);
            this.btnStandard.TabIndex = 3;
            this.btnStandard.Text = "Standard verwenden";
            this.btnStandard.UseVisualStyleBackColor = true;
            this.btnStandard.Click += new System.EventHandler(this.btnStandard_Click);
            // 
            // grpColors
            // 
            this.grpColors.Controls.Add(this.lnkTip);
            this.grpColors.Controls.Add(this.lnkFont);
            this.grpColors.Controls.Add(this.lnkNotActive);
            this.grpColors.Controls.Add(this.lnkSelect);
            this.grpColors.Controls.Add(this.pnlFont);
            this.grpColors.Controls.Add(this.pnlTip);
            this.grpColors.Controls.Add(this.pnlNotActive);
            this.grpColors.Controls.Add(this.pnlSelect);
            this.grpColors.Location = new System.Drawing.Point(12, 83);
            this.grpColors.Name = "grpColors";
            this.grpColors.Size = new System.Drawing.Size(308, 117);
            this.grpColors.TabIndex = 4;
            this.grpColors.TabStop = false;
            this.grpColors.Text = "Farben";
            // 
            // lnkTip
            // 
            this.lnkTip.AutoSize = true;
            this.lnkTip.Location = new System.Drawing.Point(40, 67);
            this.lnkTip.Name = "lnkTip";
            this.lnkTip.Size = new System.Drawing.Size(88, 15);
            this.lnkTip.TabIndex = 5;
            this.lnkTip.TabStop = true;
            this.lnkTip.Text = "Farbe der Tipps";
            this.lnkTip.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkTip_LinkClicked);
            // 
            // lnkFont
            // 
            this.lnkFont.AutoSize = true;
            this.lnkFont.Location = new System.Drawing.Point(40, 87);
            this.lnkFont.Name = "lnkFont";
            this.lnkFont.Size = new System.Drawing.Size(68, 15);
            this.lnkFont.TabIndex = 4;
            this.lnkFont.TabStop = true;
            this.lnkFont.Text = "Schriftfarbe";
            this.lnkFont.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkFont_LinkClicked);
            // 
            // lnkNotActive
            // 
            this.lnkNotActive.AutoSize = true;
            this.lnkNotActive.Location = new System.Drawing.Point(40, 45);
            this.lnkNotActive.Name = "lnkNotActive";
            this.lnkNotActive.Size = new System.Drawing.Size(171, 15);
            this.lnkNotActive.TabIndex = 3;
            this.lnkNotActive.TabStop = true;
            this.lnkNotActive.Text = "Farbe der eingeklappten Karten";
            this.lnkNotActive.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkNotActive_LinkClicked);
            // 
            // lnkSelect
            // 
            this.lnkSelect.AutoSize = true;
            this.lnkSelect.Location = new System.Drawing.Point(40, 23);
            this.lnkSelect.Name = "lnkSelect";
            this.lnkSelect.Size = new System.Drawing.Size(136, 15);
            this.lnkSelect.TabIndex = 2;
            this.lnkSelect.TabStop = true;
            this.lnkSelect.Text = "Auswahlfarbe der Karten";
            this.lnkSelect.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkSelect_LinkClicked);
            // 
            // pnlFont
            // 
            this.pnlFont.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFont.Location = new System.Drawing.Point(18, 87);
            this.pnlFont.Name = "pnlFont";
            this.pnlFont.Size = new System.Drawing.Size(16, 16);
            this.pnlFont.TabIndex = 1;
            // 
            // pnlTip
            // 
            this.pnlTip.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTip.Location = new System.Drawing.Point(18, 66);
            this.pnlTip.Name = "pnlTip";
            this.pnlTip.Size = new System.Drawing.Size(16, 16);
            this.pnlTip.TabIndex = 1;
            // 
            // pnlNotActive
            // 
            this.pnlNotActive.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlNotActive.Location = new System.Drawing.Point(18, 44);
            this.pnlNotActive.Name = "pnlNotActive";
            this.pnlNotActive.Size = new System.Drawing.Size(16, 16);
            this.pnlNotActive.TabIndex = 1;
            // 
            // pnlSelect
            // 
            this.pnlSelect.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSelect.Location = new System.Drawing.Point(18, 22);
            this.pnlSelect.Name = "pnlSelect";
            this.pnlSelect.Size = new System.Drawing.Size(16, 16);
            this.pnlSelect.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblHWInfo);
            this.groupBox1.Controls.Add(this.chkHWK);
            this.groupBox1.Location = new System.Drawing.Point(12, 206);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(307, 61);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Hardwarebeschleunigung (Erst nach Neustart oder neuem Spiel wird umgestellt)";
            // 
            // chkHWK
            // 
            this.chkHWK.AutoSize = true;
            this.chkHWK.Location = new System.Drawing.Point(18, 36);
            this.chkHWK.Name = "chkHWK";
            this.chkHWK.Size = new System.Drawing.Size(70, 19);
            this.chkHWK.TabIndex = 0;
            this.chkHWK.Text = "Aktiviert";
            this.chkHWK.UseVisualStyleBackColor = true;
            this.chkHWK.CheckedChanged += new System.EventHandler(this.chkHWK_CheckedChanged);
            // 
            // lblHWInfo
            // 
            this.lblHWInfo.AutoSize = true;
            this.lblHWInfo.Location = new System.Drawing.Point(242, 37);
            this.lblHWInfo.Name = "lblHWInfo";
            this.lblHWInfo.Size = new System.Drawing.Size(59, 15);
            this.lblHWInfo.TabIndex = 6;
            this.lblHWInfo.Text = "HW_INFO";
            // 
            // frmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(331, 271);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grpColors);
            this.Controls.Add(this.btnStandard);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtBackground);
            this.Controls.Add(this.btnSearch);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSettings";
            this.ShowIcon = false;
            this.Text = "Einstellungen";
            this.Load += new System.EventHandler(this.frmSettings_Load);
            this.grpColors.ResumeLayout(false);
            this.grpColors.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtBackground;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnStandard;
        private System.Windows.Forms.GroupBox grpColors;
        private System.Windows.Forms.LinkLabel lnkTip;
        private System.Windows.Forms.LinkLabel lnkFont;
        private System.Windows.Forms.LinkLabel lnkNotActive;
        private System.Windows.Forms.LinkLabel lnkSelect;
        private System.Windows.Forms.Panel pnlFont;
        private System.Windows.Forms.Panel pnlTip;
        private System.Windows.Forms.Panel pnlNotActive;
        private System.Windows.Forms.Panel pnlSelect;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblHWInfo;
        private System.Windows.Forms.CheckBox chkHWK;
    }
}