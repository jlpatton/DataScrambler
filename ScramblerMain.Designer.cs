namespace DataScrambler
{
    partial class ScramblerMain
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupKey = new System.Windows.Forms.GroupBox();
            this.txtKey = new System.Windows.Forms.TextBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblEmpStatErr = new System.Windows.Forms.Label();
            this.lblLnErr = new System.Windows.Forms.Label();
            this.txtEmplStat = new System.Windows.Forms.TextBox();
            this.lblEmplStat = new System.Windows.Forms.Label();
            this.txtLn = new System.Windows.Forms.TextBox();
            this.btnScrambleEx = new System.Windows.Forms.Button();
            this.lblLn = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbxWatsonW = new System.Windows.Forms.CheckBox();
            this.cboWW = new System.Windows.Forms.CheckBox();
            this.txtColS = new System.Windows.Forms.TextBox();
            this.lblColumn = new System.Windows.Forms.Label();
            this.lblSheetNames = new System.Windows.Forms.Label();
            this.cboSheetnames = new System.Windows.Forms.ComboBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.txtFileExcel = new System.Windows.Forms.TextBox();
            this.lblFileNameE = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnDBScramble = new System.Windows.Forms.Button();
            this.txtTable = new System.Windows.Forms.TextBox();
            this.txtColumn = new System.Windows.Forms.TextBox();
            this.lblDBColumn = new System.Windows.Forms.Label();
            this.lblDBTable = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.textPanel = new System.Windows.Forms.Panel();
            this.cbxPrism = new System.Windows.Forms.CheckBox();
            this.txttextFile = new System.Windows.Forms.TextBox();
            this.btnScrambleText = new System.Windows.Forms.Button();
            this.lblTextFile = new System.Windows.Forms.Label();
            this.btnText = new System.Windows.Forms.Button();
            this.tabForms = new System.Windows.Forms.TabControl();
            this.menuStrip1.SuspendLayout();
            this.groupKey.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.textPanel.SuspendLayout();
            this.tabForms.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(815, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // groupKey
            // 
            this.groupKey.Controls.Add(this.txtKey);
            this.groupKey.Location = new System.Drawing.Point(267, 326);
            this.groupKey.Name = "groupKey";
            this.groupKey.Size = new System.Drawing.Size(218, 75);
            this.groupKey.TabIndex = 2;
            this.groupKey.TabStop = false;
            this.groupKey.Text = "Scrambling Key";
            // 
            // txtKey
            // 
            this.txtKey.Location = new System.Drawing.Point(17, 28);
            this.txtKey.Name = "txtKey";
            this.txtKey.Size = new System.Drawing.Size(175, 20);
            this.txtKey.TabIndex = 1;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.panel1);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(807, 255);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Excel";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblEmpStatErr);
            this.panel1.Controls.Add(this.lblLnErr);
            this.panel1.Controls.Add(this.txtEmplStat);
            this.panel1.Controls.Add(this.lblEmplStat);
            this.panel1.Controls.Add(this.txtLn);
            this.panel1.Controls.Add(this.btnScrambleEx);
            this.panel1.Controls.Add(this.lblLn);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.txtColS);
            this.panel1.Controls.Add(this.lblColumn);
            this.panel1.Controls.Add(this.lblSheetNames);
            this.panel1.Controls.Add(this.cboSheetnames);
            this.panel1.Controls.Add(this.btnBrowse);
            this.panel1.Controls.Add(this.txtFileExcel);
            this.panel1.Controls.Add(this.lblFileNameE);
            this.panel1.Location = new System.Drawing.Point(8, 16);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(791, 202);
            this.panel1.TabIndex = 0;
            // 
            // lblEmpStatErr
            // 
            this.lblEmpStatErr.AutoSize = true;
            this.lblEmpStatErr.ForeColor = System.Drawing.Color.DarkRed;
            this.lblEmpStatErr.Location = new System.Drawing.Point(348, 128);
            this.lblEmpStatErr.Name = "lblEmpStatErr";
            this.lblEmpStatErr.Size = new System.Drawing.Size(56, 13);
            this.lblEmpStatErr.TabIndex = 22;
            this.lblEmpStatErr.Text = "(Required)";
            this.lblEmpStatErr.Visible = false;
            // 
            // lblLnErr
            // 
            this.lblLnErr.AutoSize = true;
            this.lblLnErr.ForeColor = System.Drawing.Color.DarkRed;
            this.lblLnErr.Location = new System.Drawing.Point(348, 102);
            this.lblLnErr.Name = "lblLnErr";
            this.lblLnErr.Size = new System.Drawing.Size(56, 13);
            this.lblLnErr.TabIndex = 4;
            this.lblLnErr.Text = "(Required)";
            this.lblLnErr.Visible = false;
            // 
            // txtEmplStat
            // 
            this.txtEmplStat.Location = new System.Drawing.Point(291, 125);
            this.txtEmplStat.Name = "txtEmplStat";
            this.txtEmplStat.Size = new System.Drawing.Size(51, 20);
            this.txtEmplStat.TabIndex = 5;
            this.txtEmplStat.Visible = false;
            // 
            // lblEmplStat
            // 
            this.lblEmplStat.AutoSize = true;
            this.lblEmplStat.Location = new System.Drawing.Point(185, 128);
            this.lblEmplStat.Name = "lblEmplStat";
            this.lblEmplStat.Size = new System.Drawing.Size(101, 13);
            this.lblEmplStat.TabIndex = 20;
            this.lblEmplStat.Text = "Empl Status Column";
            this.lblEmplStat.Visible = false;
            // 
            // txtLn
            // 
            this.txtLn.Location = new System.Drawing.Point(291, 99);
            this.txtLn.Name = "txtLn";
            this.txtLn.Size = new System.Drawing.Size(51, 20);
            this.txtLn.TabIndex = 4;
            this.txtLn.Visible = false;
            // 
            // btnScrambleEx
            // 
            this.btnScrambleEx.Location = new System.Drawing.Point(10, 168);
            this.btnScrambleEx.Name = "btnScrambleEx";
            this.btnScrambleEx.Size = new System.Drawing.Size(75, 23);
            this.btnScrambleEx.TabIndex = 6;
            this.btnScrambleEx.Text = "Scramble";
            this.btnScrambleEx.UseVisualStyleBackColor = true;
            this.btnScrambleEx.Click += new System.EventHandler(this.btnScrambleEx_Click);
            // 
            // lblLn
            // 
            this.lblLn.AutoSize = true;
            this.lblLn.Location = new System.Drawing.Point(185, 102);
            this.lblLn.Name = "lblLn";
            this.lblLn.Size = new System.Drawing.Size(77, 13);
            this.lblLn.TabIndex = 2;
            this.lblLn.Text = "Lname Column";
            this.lblLn.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbxWatsonW);
            this.groupBox1.Controls.Add(this.cboWW);
            this.groupBox1.Location = new System.Drawing.Point(10, 85);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(148, 71);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filter";
            // 
            // cbxWatsonW
            // 
            this.cbxWatsonW.AutoSize = true;
            this.cbxWatsonW.Location = new System.Drawing.Point(9, 42);
            this.cbxWatsonW.Name = "cbxWatsonW";
            this.cbxWatsonW.Size = new System.Drawing.Size(132, 17);
            this.cbxWatsonW.TabIndex = 1;
            this.cbxWatsonW.Text = "Watson Wyatt Import?";
            this.cbxWatsonW.UseVisualStyleBackColor = true;
            this.cbxWatsonW.CheckedChanged += new System.EventHandler(this.cbxWatsonW_CheckedChanged);
            // 
            // cboWW
            // 
            this.cboWW.AutoSize = true;
            this.cboWW.Location = new System.Drawing.Point(9, 19);
            this.cboWW.Name = "cboWW";
            this.cboWW.Size = new System.Drawing.Size(134, 17);
            this.cboWW.TabIndex = 0;
            this.cboWW.Text = "HRA Wageworks File?";
            this.cboWW.UseVisualStyleBackColor = true;
            this.cboWW.CheckedChanged += new System.EventHandler(this.cboWW_CheckedChanged);
            // 
            // txtColS
            // 
            this.txtColS.Location = new System.Drawing.Point(361, 48);
            this.txtColS.Name = "txtColS";
            this.txtColS.Size = new System.Drawing.Size(61, 20);
            this.txtColS.TabIndex = 3;
            // 
            // lblColumn
            // 
            this.lblColumn.AutoSize = true;
            this.lblColumn.Location = new System.Drawing.Point(288, 51);
            this.lblColumn.Name = "lblColumn";
            this.lblColumn.Size = new System.Drawing.Size(67, 13);
            this.lblColumn.TabIndex = 9;
            this.lblColumn.Text = "SSN Column";
            // 
            // lblSheetNames
            // 
            this.lblSheetNames.AutoSize = true;
            this.lblSheetNames.Location = new System.Drawing.Point(7, 51);
            this.lblSheetNames.Name = "lblSheetNames";
            this.lblSheetNames.Size = new System.Drawing.Size(40, 13);
            this.lblSheetNames.TabIndex = 4;
            this.lblSheetNames.Text = "Sheets";
            // 
            // cboSheetnames
            // 
            this.cboSheetnames.FormattingEnabled = true;
            this.cboSheetnames.Location = new System.Drawing.Point(65, 48);
            this.cboSheetnames.Name = "cboSheetnames";
            this.cboSheetnames.Size = new System.Drawing.Size(217, 21);
            this.cboSheetnames.TabIndex = 2;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(612, 9);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 1;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // txtFileExcel
            // 
            this.txtFileExcel.Location = new System.Drawing.Point(65, 11);
            this.txtFileExcel.Name = "txtFileExcel";
            this.txtFileExcel.Size = new System.Drawing.Size(520, 20);
            this.txtFileExcel.TabIndex = 0;
            // 
            // lblFileNameE
            // 
            this.lblFileNameE.AutoSize = true;
            this.lblFileNameE.Location = new System.Drawing.Point(7, 14);
            this.lblFileNameE.Name = "lblFileNameE";
            this.lblFileNameE.Size = new System.Drawing.Size(52, 13);
            this.lblFileNameE.TabIndex = 0;
            this.lblFileNameE.Text = "File name";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.panel2);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(807, 255);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "SQL Database";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnDBScramble);
            this.panel2.Controls.Add(this.txtTable);
            this.panel2.Controls.Add(this.txtColumn);
            this.panel2.Controls.Add(this.lblDBColumn);
            this.panel2.Controls.Add(this.lblDBTable);
            this.panel2.Location = new System.Drawing.Point(18, 18);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(765, 114);
            this.panel2.TabIndex = 0;
            // 
            // btnDBScramble
            // 
            this.btnDBScramble.Location = new System.Drawing.Point(608, 10);
            this.btnDBScramble.Name = "btnDBScramble";
            this.btnDBScramble.Size = new System.Drawing.Size(75, 23);
            this.btnDBScramble.TabIndex = 4;
            this.btnDBScramble.Text = "Scramble";
            this.btnDBScramble.UseVisualStyleBackColor = true;
            this.btnDBScramble.Click += new System.EventHandler(this.btnDBScramble_Click);
            // 
            // txtTable
            // 
            this.txtTable.Location = new System.Drawing.Point(85, 12);
            this.txtTable.Name = "txtTable";
            this.txtTable.Size = new System.Drawing.Size(174, 20);
            this.txtTable.TabIndex = 1;
            // 
            // txtColumn
            // 
            this.txtColumn.Location = new System.Drawing.Point(358, 12);
            this.txtColumn.Name = "txtColumn";
            this.txtColumn.Size = new System.Drawing.Size(184, 20);
            this.txtColumn.TabIndex = 3;
            // 
            // lblDBColumn
            // 
            this.lblDBColumn.AutoSize = true;
            this.lblDBColumn.Location = new System.Drawing.Point(279, 16);
            this.lblDBColumn.Name = "lblDBColumn";
            this.lblDBColumn.Size = new System.Drawing.Size(73, 13);
            this.lblDBColumn.TabIndex = 2;
            this.lblDBColumn.Text = "Column Name";
            // 
            // lblDBTable
            // 
            this.lblDBTable.AutoSize = true;
            this.lblDBTable.Location = new System.Drawing.Point(14, 16);
            this.lblDBTable.Name = "lblDBTable";
            this.lblDBTable.Size = new System.Drawing.Size(65, 13);
            this.lblDBTable.TabIndex = 0;
            this.lblDBTable.Text = "Table Name";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.textPanel);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(807, 255);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Text Files";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // textPanel
            // 
            this.textPanel.Controls.Add(this.cbxPrism);
            this.textPanel.Controls.Add(this.txttextFile);
            this.textPanel.Controls.Add(this.btnScrambleText);
            this.textPanel.Controls.Add(this.lblTextFile);
            this.textPanel.Controls.Add(this.btnText);
            this.textPanel.Location = new System.Drawing.Point(27, 22);
            this.textPanel.Name = "textPanel";
            this.textPanel.Size = new System.Drawing.Size(737, 197);
            this.textPanel.TabIndex = 4;
            // 
            // cbxPrism
            // 
            this.cbxPrism.AutoSize = true;
            this.cbxPrism.Location = new System.Drawing.Point(175, 55);
            this.cbxPrism.Name = "cbxPrism";
            this.cbxPrism.Size = new System.Drawing.Size(112, 17);
            this.cbxPrism.TabIndex = 5;
            this.cbxPrism.Text = "Check if Prism File";
            this.cbxPrism.UseVisualStyleBackColor = true;
            // 
            // txttextFile
            // 
            this.txttextFile.Location = new System.Drawing.Point(74, 15);
            this.txttextFile.Name = "txttextFile";
            this.txttextFile.Size = new System.Drawing.Size(520, 20);
            this.txttextFile.TabIndex = 16;
            // 
            // btnScrambleText
            // 
            this.btnScrambleText.Location = new System.Drawing.Point(74, 51);
            this.btnScrambleText.Name = "btnScrambleText";
            this.btnScrambleText.Size = new System.Drawing.Size(75, 23);
            this.btnScrambleText.TabIndex = 15;
            this.btnScrambleText.Text = "Scramble";
            this.btnScrambleText.UseVisualStyleBackColor = true;
            this.btnScrambleText.Click += new System.EventHandler(this.btnScrambleText_Click);
            // 
            // lblTextFile
            // 
            this.lblTextFile.AutoSize = true;
            this.lblTextFile.Location = new System.Drawing.Point(14, 18);
            this.lblTextFile.Name = "lblTextFile";
            this.lblTextFile.Size = new System.Drawing.Size(54, 13);
            this.lblTextFile.TabIndex = 2;
            this.lblTextFile.Text = "File Name";
            // 
            // btnText
            // 
            this.btnText.Location = new System.Drawing.Point(610, 13);
            this.btnText.Name = "btnText";
            this.btnText.Size = new System.Drawing.Size(75, 23);
            this.btnText.TabIndex = 1;
            this.btnText.Text = "Browse";
            this.btnText.UseVisualStyleBackColor = true;
            this.btnText.Click += new System.EventHandler(this.btnText_Click_1);
            // 
            // tabForms
            // 
            this.tabForms.Controls.Add(this.tabPage4);
            this.tabForms.Controls.Add(this.tabPage2);
            this.tabForms.Controls.Add(this.tabPage3);
            this.tabForms.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabForms.Location = new System.Drawing.Point(0, 24);
            this.tabForms.Name = "tabForms";
            this.tabForms.SelectedIndex = 0;
            this.tabForms.Size = new System.Drawing.Size(815, 281);
            this.tabForms.TabIndex = 2;
            this.tabForms.SelectedIndexChanged += new System.EventHandler(this.tabForms_indexChange);
            // 
            // ScramblerMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(815, 447);
            this.Controls.Add(this.groupKey);
            this.Controls.Add(this.tabForms);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ScramblerMain";
            this.Text = "EBNet Scrambler";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupKey.ResumeLayout(false);
            this.groupKey.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.textPanel.ResumeLayout(false);
            this.textPanel.PerformLayout();
            this.tabForms.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupKey;
        private System.Windows.Forms.TextBox txtKey;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnScrambleEx;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtLn;
        private System.Windows.Forms.Label lblLn;
        private System.Windows.Forms.CheckBox cboWW;
        private System.Windows.Forms.TextBox txtColS;
        private System.Windows.Forms.Label lblColumn;
        private System.Windows.Forms.Label lblSheetNames;
        private System.Windows.Forms.ComboBox cboSheetnames;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TextBox txtFileExcel;
        private System.Windows.Forms.Label lblFileNameE;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel textPanel;
        private System.Windows.Forms.Button btnScrambleText;
        private System.Windows.Forms.Label lblTextFile;
        private System.Windows.Forms.Button btnText;
        private System.Windows.Forms.TabControl tabForms;
        private System.Windows.Forms.TextBox txttextFile;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnDBScramble;
        private System.Windows.Forms.TextBox txtTable;
        private System.Windows.Forms.TextBox txtColumn;
        private System.Windows.Forms.Label lblDBColumn;
        private System.Windows.Forms.Label lblDBTable;
        private System.Windows.Forms.CheckBox cbxPrism;
        private System.Windows.Forms.TextBox txtEmplStat;
        private System.Windows.Forms.Label lblEmplStat;
        private System.Windows.Forms.CheckBox cbxWatsonW;
        private System.Windows.Forms.Label lblLnErr;
        private System.Windows.Forms.Label lblEmpStatErr;
    }
}