using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Data.OleDb;
using utilities; 
using DataScrambler.Code;

namespace DataScrambler
{
    public partial class ScramblerMain : Form
    {
        private bool _ww = false; //Wageworks
        private bool _watsonW = false; // Watson Wyatts
        private string _strExcelFilename = "";
        private ExcelReader _exr = null;
        private Scramble _scr = null;
        private DataTable _dt;
       

        public ScramblerMain()
        {
            InitializeComponent();
            clearMessages();
        }        
        
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Exit Application?",
                            "Exit",
                             MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes) Application.Exit();           
        }

        #region ExcelTab

        private void InitExcel(ref ExcelReader exr)
        {
            //Excel must be open
            if (exr == null)
            {
                exr = new ExcelReader();
                exr.ExcelFilename = _strExcelFilename;
                exr.Headers = false;
                exr.MixedData = true;
            }
            if (_dt == null) _dt = new DataTable("sheet");
            exr.KeepConnectionOpen = false;

            //Check excel sheetname is selected
            if (this.cboSheetnames.SelectedIndex > -1)
                exr.SheetName = this.cboSheetnames.Text;
            else
                throw new Exception("Select a sheet first!");

            //Set excel sheet range
            //exr.SheetRange = this.txtRangeE.Text;
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog f = new OpenFileDialog();
            f.Filter = "Excel files | *.xls";
            //f.InitialDirectory = "C:";

            if (f.ShowDialog() == DialogResult.OK)
                if (f.FileName != null && f.CheckFileExists == true)
                {
                    clearMessages();
                    cbxWatsonW.Checked = false;
                    cboWW.Checked = false;
                    txtColS.Text = "";
                    this._strExcelFilename = f.FileName;
                    this.txtFileExcel.Text = f.FileName;
                    RetrieveSheetnames();
                    if (this.cboSheetnames.Items.Count > 0)
                        cboSheetnames.SelectedIndex = 0;
                }

        }

        private void RetrieveSheetnames()
        {
            try
            {
                this.cboSheetnames.Items.Clear();

                if (_exr != null)
                {
                    _exr.Dispose();
                    _exr = null;
                }

                _exr = new ExcelReader();
                _exr.ExcelFilename = _strExcelFilename;
                _exr.Headers = false;
                _exr.MixedData = true;
                _exr.KeepConnectionOpen = false;
                string[] sheetnames = this._exr.GetExcelSheetNames();
                this.cboSheetnames.Items.AddRange(sheetnames);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnScrambleEx_Click(object sender, EventArgs e)
        {
            try
            {
                checkSSN();
                validateKey();                
                checkWW();
                checkWatsonW();
                if (showConfirm() == DialogResult.OK)
                {
                    _scr = new Scramble();
                    _scr.FileName = txtFileExcel.Text;
                    _scr.Key = txtKey.Text;
                    _scr.SheetName = cboSheetnames.SelectedItem.ToString();

                    //create a backup copy
                    _scr.createExcelcopy();

                    if (_exr == null)
                    {
                        _exr = new ExcelReader();
                    }
                    int _colno = _exr.ColNumber(txtColS.Text) + 1;
                    int _fcolno = 0;
                    int _lcolno = 0;

                    //set wageworks variables
                    if (_ww)
                    {
                        _lcolno = _exr.ColNumber(txtLn.Text) + 1;
                        _scr.WageWorks = true;
                        _scr.LastNameColNo = _lcolno;
                    }
                    //set watson wyatts variables
                    if (_watsonW)
                    {
                        int _estatcolno = _exr.ColNumber(txtEmplStat.Text) + 1;
                        _scr.WatsonWyatts = true;
                        _scr.EmpStatus = _estatcolno;
                    }

                    //set ssn column number
                    _scr.ColumnNumber = _colno;

                    //scramble
                    _scr.scrambleExcelFile();

                    MessageBox.Show("Scrambled SSN Column successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region TextTab

        private void btnText_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog f = new OpenFileDialog();
            f.Filter = "Text files | *.txt | All Files | *.*";
            //f.InitialDirectory = Application.ExecutablePath;
            if (f.ShowDialog() == DialogResult.OK)
            {
                this.txttextFile.Text = f.FileName;
            }
        }

        private void btnScrambleText_Click(object sender, EventArgs e)
        {
            try
            {
                validateKey();
                _scr = new Scramble();
                _scr.FileName = txttextFile.Text;
                _scr.Key = txtKey.Text;
                if (cbxPrism.Checked)
                {
                    _scr.PrismImport = true;
                }
                _scr.scrambleTextFile();
                MessageBox.Show("Scrambled SSN Column successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Database

        private void btnDBScramble_Click(object sender, EventArgs e)
        {
            try
            {
                validateKey();
                checkTableColumn();
                ScrambleDAL.openDB();
                ScrambleDAL.scrambledDataBase(txtTable.Text, txtColumn.Text, txtKey.Text);
                MessageBox.Show("Scrambled Column - " + txtColumn.Text + " successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                ScrambleDAL.closeDB();
            }
        }

        #endregion

        #region Validation

        //Check if SSN column is enetred
        void checkSSN()
        {
            string _message = string.Empty;
            if (txtColS.Text.Equals(""))
            {
                _message += "Enter SSN Column.\n ";
            }            
            if (!_message.Equals(""))
            {
                throw (new Exception(_message));
            }
        }

        //Check if Scrambling Key is entered
        void validateKey()
        {            
            string _message = string.Empty;
             if (txtKey.Text.Equals(""))
            {
                _message += "Enter Scrambling Key.\n ";                
            }

            if (!txtKey.Text.Equals(""))
            {
                if (txtKey.Text.Length < 9)
                {
                    _message += "Required Key length is 9.\n";                    
                }
                if (txtKey.Text.Length == 9 && calculateSum(txtKey.Text) != 45)
                {
                    _message += "Invalid Key. Key should contain all unique numbers from 1-9.";                    
                }
            }
            if (!_message.Equals(""))
            {
                throw (new Exception(_message));
            }
            
        }

        //WageWorks
        void checkWW()
        {            
            _ww = false;
            bool _error = false;
            string _message = string.Empty;
            if (cboWW.Checked)
            {               
                if (txtLn.Text.Equals(""))
                {
                    _message += "Enter LastName Column.\n ";
                    _error = true;
                }
                if (!_error)
                {
                    _ww = true; //Set WW flag to true
                }
            }
            if (!_message.Equals(""))
            {
                throw (new Exception(_message));
            }            
        }

        //WatsonWyatt
        void checkWatsonW()
        {
            _watsonW = false;
            bool _error = false;
            string _message = string.Empty;
            if (cbxWatsonW.Checked)
            {
                if (txtEmplStat.Text.Equals(""))
                {
                    _message += "Enter Employee Status Column.\n ";
                    _error = true;
                }                
                if (!_error)
                {
                    _watsonW = true; //Set WatsonW flag to true
                }
            }
            if (!_message.Equals(""))
            {
                throw (new Exception(_message));
            }
        }

        //Validate Scrambling key
        Int64 calculateSum(string _number)
        {
            Int64 _x = 0;

            for (int i = 0; i < 9; i++)
            {
                _x += Convert.ToInt64(_number.Substring(i, 1));
            }

            return _x;
        }

        //Confirm before scrambling
        DialogResult showConfirm()
        {
            return MessageBox.Show("Selected Sheet will be scrambled.\n If you selected wrong sheet, hit cancel and select correct sheet.", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
        }

        //Check if Column Name and Table Name are entered
        void checkTableColumn()
        {  
            string _message = string.Empty;
            
            if (txtTable.Text.Equals(""))
            {
                _message += "Enter Table Name.\n ";                
            }
            if (txtColumn.Text.Equals(""))
            {
                _message += "Enter Column Name.\n ";                
            }
            if (!_message.Equals(""))
            {
                throw (new Exception(_message));
            }
        }

        #endregion

        
        protected void tabForms_indexChange(Object sender, EventArgs e)
        {
            clearMessages();
            cbxWatsonW.Checked = false;
            cboWW.Checked = false;
        }

        void clearMessages()
        {  
            _ww = false;
            _watsonW = false;

            lblLn.Visible = false;
            txtLn.Visible = false;
            txtLn.Text = "";
            lblLnErr.Visible = false;

            lblEmplStat.Visible = false;
            txtEmplStat.Visible = false;
            txtEmplStat.Text = "";
            lblEmpStatErr.Visible = false;
        }

        private void cboWW_CheckedChanged(object sender, EventArgs e)
        {
            clearMessages();
            cbxWatsonW.Checked = false;
            if (cboWW.Checked)
            { 
                lblLn.Visible = true;
                txtLn.Visible = true;
                lblLnErr.Visible = true;
            }
        }

        private void cbxWatsonW_CheckedChanged(object sender, EventArgs e)
        {
            clearMessages();
            cboWW.Checked = false;
            if (cbxWatsonW.Checked)
            {
                lblEmplStat.Visible = true;
                txtEmplStat.Visible = true;
                lblEmpStatErr.Visible = true;
            }
        }
       
    }
}