using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Data.OleDb;
using System.Data.Common;
using Excel = Microsoft.Office.Interop.Excel;

namespace DataScrambler.Code
{
    public class Scramble
    {
        public Scramble()
        {
        }

        #region variables

        private Excel.Application myExcel;
        private int _columnNumber;        
        private int _lnamecolumnNumber;
        private int _empStatuscolumnNumber;
        private int _startIndex;
        private int _endIndex;
        private string _sheetname;
        private string _fileName;
        private string _key;
        private object missing = Type.Missing;
        private bool _wageWorks = false;
        private bool _prismFile = false;
        private bool _watsonWyatts = false;

        #endregion

        #region properties

        public string FileName
        {
            get
            {
                return _fileName;
            }
            set
            {
                _fileName = value;
            }
        }

        public string Key
        {
            get
            {
                return _key;
            }
            set
            {
                _key = value;
            }
        }

        public string SheetName
        {
            get
            {
                return _sheetname;
            }
            set
            {
                _sheetname = value;
            }
        }

        public int ColumnNumber
        {
            get
            {
                return _columnNumber;
            }
            set
            {
                _columnNumber = value;
            }
        }        

        public int LastNameColNo
        {
            get
            {
                return _lnamecolumnNumber;
            }
            set
            {
                _lnamecolumnNumber = value;
            }
        }

        public int EmpStatus
        {
            get
            {
                return _empStatuscolumnNumber;
            }
            set
            {
                _empStatuscolumnNumber = value;
            }
        }

        public int StartIndex
        {
            get
            {
                return _startIndex;
            }
            set
            {
                _startIndex = value;
            }
        }

        public int EndIndex
        {
            get
            {
                return _endIndex;
            }
            set
            {
                _endIndex = value;
            }
        }

        public bool WageWorks
        {
            get
            {
                return _wageWorks;
            }
            set
            {
                _wageWorks = value;
            }
        }

        public bool PrismImport
        {
            get
            {
                return _prismFile;
            }
            set
            {
                _prismFile = value;
            }
        }

        public bool WatsonWyatts
        {
            get
            {
                return _watsonWyatts;
            }
            set
            {
                _watsonWyatts = value;
            }
        }

        #endregion

        #region Methods

        public void scrambleTextFile()
        {
            if (!_prismFile)
                scrambleTextNormal();
            else
                scrambleTextPrism();
        }

        private void scrambleTextNormal()
        {
            string _Pattern = @"(?<ssn>\d{3}-\d{2}-\d{4})";
            string line = string.Empty;

            TextReader reader = new StreamReader(File.OpenRead(_fileName));
            StringBuilder sb = new StringBuilder();
            try
            {
                while ((line = reader.ReadLine()) != null)
                {
                    Match parsed = Regex.Match(line, _Pattern);
                    if (parsed.Success)
                    {
                        string _scrambledssn = "";
                        string _realssn = parsed.Groups["ssn"].Value.ToString();
                        _scrambledssn = ScrambleDAL.scrambledData(_realssn, _key);
                        if (!_scrambledssn.Equals(""))
                        {
                            line = line.Replace(_realssn, _scrambledssn);
                        }
                    }
                    sb.AppendLine(line);
                }
                exportScrambledTextFile(sb.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                reader.Close();
            }
        }

        private void scrambleTextPrism()
        {           
            string line = string.Empty;

            TextReader reader = new StreamReader(File.OpenRead(_fileName));
            StringBuilder sb = new StringBuilder();
            try
            {
                while ((line = reader.ReadLine()) != null)
                {                    
                    string _scrambledssn = "";
                    string _start = line.Substring(0,1);
                    if (_start.Trim().Equals("2"))
                    {
                        string _realssn = line.Substring(11, 10);
                        _realssn = ScrambleDAL.GetSSN(_realssn);
                        _scrambledssn = ScrambleDAL.scrambledData(_realssn, _key).PadLeft(10, '0');
                        if (!_scrambledssn.Equals(""))
                        {
                            line = line.Substring(0, 11) + _scrambledssn + line.Substring(21, (line.Length - 21));
                        }
                    }
                    sb.AppendLine(line);
                }
                exportScrambledTextFile(sb.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                reader.Close();
            }
        }

        public void exportScrambledTextFile(string _content)
        {
            string _fname = string.Empty;
            if (_prismFile)
            {
                _fname = _fileName + "scrambled";
            }
            else
            {
                _fname = _fileName.Replace(".txt", "scrambled.txt");
            }
            FileInfo f = new FileInfo(_fname);
            StreamWriter sw = f.CreateText();
            sw.Write(_content);
            sw.Close();
        }

        public void scrambleExcelFile()
        {
            string _oldv = string.Empty;
            try
            {
                myExcel = new Excel.Application();

                myExcel.Workbooks.Open(_fileName, missing, missing, missing, missing, missing,
                                        missing, missing, missing, missing, missing, missing,
                                        missing, missing, missing);
               
                
                foreach (Excel.Worksheet sheet in myExcel.Sheets)
                {
                    if ((sheet.Name).Contains(_sheetname))
                    {
                        sheet.Select(Type.Missing);
                    }
                }

                Excel.Worksheet ws = (Excel.Worksheet)myExcel.ActiveSheet;
                _startIndex = 1;
                _endIndex = ws.Cells.Find("*", System.Reflection.Missing.Value,
                                            System.Reflection.Missing.Value, System.Reflection.Missing.Value, 
                                            Excel.XlSearchOrder.xlByRows, Excel.XlSearchDirection.xlPrevious, 
                                            false, System.Reflection.Missing.Value, System.Reflection.Missing.Value).Row;

                ScrambleDAL.openDB();
                for (int i = _startIndex; i <= _endIndex; i++)
                {
                    if (((Excel.Range)ws.Cells[i, _columnNumber]).Value2 != null)
                    {
                        _oldv = ((Excel.Range)ws.Cells[i, _columnNumber]).Value2.ToString();

                        
                        string _newv = string.Empty;
                        if ((!_wageWorks) && (!_watsonWyatts) && matchSSN(_oldv))
                        {
                            _newv = ScrambleDAL.scrambledData(_oldv, _key);
                        }
                        else if (_wageWorks && matchSSN(_oldv))
                        {
                            string _ln = ((Excel.Range)ws.Cells[i, _lnamecolumnNumber]).Value2.ToString();
                            _ln = _ln.Substring(0, 3);
                            _newv = ScrambleDAL.scrambledDataCREF(_oldv, _ln, _key);
                        }
                        else if (_watsonWyatts && matchSSN(_oldv))
                        {
                            string _emplStatus = ((Excel.Range)ws.Cells[i, _empStatuscolumnNumber]).Value2.ToString();
                            if (_emplStatus.Trim().Equals("R"))
                            {
                                _newv = ScrambleDAL.scrambledData(_oldv, _key).Substring(5, 4);
                            }
                            else
                            {
                                _newv = _oldv;
                            }
                        }
                        else if (!matchSSN(_oldv))
                        {
                            _newv = _oldv;
                        }
                        ((Excel.Range)ws.Cells[i, _columnNumber]).Value2 = _newv;
                        
                    }
                    
                }
                foreach (Excel.Workbook wb in myExcel.Workbooks)
                {
                    wb.Save();
                }
            }
            catch (Exception ex)
            {
                foreach (Excel.Workbook wb in myExcel.Workbooks)
                {
                    wb.Saved = true;
                }                
                throw ex;
            }
            finally
            {
                ScrambleDAL.closeDB();
                Close(myExcel);
            }

        }

        public void createExcelcopy()
        {
            if (File.Exists(_fileName))
            {
                string _copyfname = _fileName;
                _copyfname = _copyfname.Replace(".xls","copy.xls");
                if (!File.Exists(_copyfname))
                {
                    File.Copy(_fileName, _copyfname, true);
                }
            }
        }

        bool matchSSN(string _ssn)
        {
            if (!_ssn.Contains("-"))
            {
                if (_ssn.Length < 9)
                {
                    _ssn = _ssn.PadLeft(9, '0');
                }
                if(_ssn.Length == 9)
                    _ssn = _ssn.Substring(0, 3) + "-" + _ssn.Substring(3, 2) + "-" + _ssn.Substring(5, 4);
            }
            string _Pattern = @"(\d{3}-\d{2}-\d{4})";
            Match parsed = Regex.Match(_ssn, _Pattern);
            if (parsed.Success)
            {
                return true;
            }
            else
            {
                return false;
            }
        }       

        public static void Close(Excel.Application rpt)
        {
            if (rpt.Workbooks != null)
            {                
                rpt.Workbooks.Close();
            }
            if (rpt != null)
            {
                rpt.Quit();
                rpt = null;
            }
        }

        #endregion
    }
}
