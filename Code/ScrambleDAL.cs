using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections;


namespace DataScrambler.Code
{
    class ScrambleDAL
    {
        private static SqlConnection connect = new SqlConnection("Data Source=svcdsql1;Initial Catalog=EBA; Uid=EBA_User; Pwd=abE62544uet;");
        private static SqlConnection connectProd = new SqlConnection("Data Source=ebs-sql1.corp.ds.acme.com;Initial Catalog=EBA; Uid=EBA_User; Pwd=VpljXx5s;");
        private static SqlCommand cmd = null;
        
        public ScrambleDAL()
        {

        }

        public static void openDB()
        {
            if (connect == null || connect.State == ConnectionState.Closed)
            {
                connect.Open();
            }
        }

        public static void closeDB()
        {
            connect.Close();
        }

        public static string scrambledData(string _data, string _key)
        {
            bool _dashed = false;

            if(_data.Contains("-"))
            {
                _dashed = true;
                _data = _data.Replace("-","");
            }
            if (_data.Length < 9)
            {
                _data = _data.PadLeft(9, '0');
            }
           
            string _scrambleddata = "";
            //string _cmdstr = "SELECT [dbo].[ScramblerAlgo](@key,@data) ";
           
            try
            {
                openDB();
                cmd = new SqlCommand("[dbo].[RunScramblerAlgo]", connect);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@key", _key);
                cmd.Parameters.AddWithValue("@data", _data);
                object _dataobj = cmd.ExecuteScalar();               
                if (_dataobj != null && _dataobj != DBNull.Value)
                {
                    _scrambleddata = _dataobj.ToString();
                }
                if (_dashed)
                {
                    _scrambleddata = _scrambleddata.Substring(0, 3) + "-" + _scrambleddata.Substring(3, 2) + "-" + _scrambleddata.Substring(5, 4);
                }
                return _scrambleddata;
            }
            catch (Exception ex)
            {
                throw ex;
            }            
        }

        public static void scrambledDataBase(string _table, string _column, string _key)
        {            

            try
            {
                openDB();
                cmd = new SqlCommand("[dbo].[RunScramblerAlgo4DB]", connect);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Table", _table);
                cmd.Parameters.AddWithValue("@Column", _column);
                cmd.Parameters.AddWithValue("@key", _key);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Gets Real SSN before scrambling by Cross referencing to Production Table
        /// </summary>
        /// <param name="_ssn">4 Digit SSN (if WageWorks)</param>
        /// <param name="_crefValue">Employee Name (if WageWorks)</param>
        /// <param name="_key">Scrambling Key</param>
        /// <returns>Scrambled SSN</returns>
        public static string scrambledDataCREF(string _ssn, string _crefValue, string _key)
        {
            bool _dashed = false;
            string _newssn = "";

            _newssn = GetSSN(_ssn, _crefValue);

            if(_newssn.Equals(""))
            {
                throw (new Exception("SSN (" + _ssn.ToString() + ") not found in production Employee table. "));
            }

            if (_newssn.Contains("-"))
            {
                _dashed = true;
                _newssn.Replace("-", "");
            }

            if (_newssn.Length < 9)
            {
                _newssn.PadLeft(9, '0');
            }

            string _scrambleddata = "";
            try
            {
                openDB();
                cmd = new SqlCommand("[dbo].[RunScramblerAlgo]", connect);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@key", _key);
                cmd.Parameters.AddWithValue("@data", _newssn);
                object _dataobj = cmd.ExecuteScalar();
                if (_dataobj != null && _dataobj != DBNull.Value)
                {
                    _scrambleddata = _dataobj.ToString();
                }
                if (_dashed)
                {
                    _scrambleddata = _scrambleddata.Substring(0, 3) + "-" + _scrambleddata.Substring(3, 2) + "-" + _scrambleddata.Substring(5,4);
                }
                
                _scrambleddata = _scrambleddata.Substring((_scrambleddata.Length - 4), 4).PadLeft(4,'0');
                return _scrambleddata;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        static string GetSSN(string last4ssn, string first3lname)
        {
            string _ssn = string.Empty;
            last4ssn = last4ssn.PadLeft(4, '0');

            string cmdstr = "SELECT empl_ssn AS [SSN] "
                                + "FROM Employee  WHERE "
                                + "SUBSTRING(CONVERT(VARCHAR(10),empl_ssn), LEN(CONVERT(VARCHAR(10),empl_ssn)) - 3 , 4) = @last4ssn "
                                + "AND empl_hra_part = 1 "
                                + "AND SUBSTRING(empl_lname, 1, 3) = @first3lname";
            try
            {
                if (connectProd == null || connectProd.State == ConnectionState.Closed)
                {
                    connectProd.Open();
                }

                cmd = new SqlCommand(cmdstr, connectProd);
                cmd.Parameters.AddWithValue("@last4ssn", last4ssn);
                cmd.Parameters.AddWithValue("@first3lname", first3lname);
                object result = cmd.ExecuteScalar();

                if ((result != null) && (result != DBNull.Value))
                {
                    _ssn = result.ToString();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connectProd.Close();
            }

            return _ssn;
        }

        public static string GetSSN(string empNum)
        {
            string _ssn = string.Empty;            

            string cmdstr = "SELECT empl_ssn AS [SSN] "
                                + "FROM Employee  WHERE "
                                + "empl_empno = @empno ";
            try
            {
                if (connectProd == null || connectProd.State == ConnectionState.Closed)
                {
                    connectProd.Open();
                }

                cmd = new SqlCommand(cmdstr, connectProd);
                cmd.Parameters.AddWithValue("@empno", empNum);
                
                object result = cmd.ExecuteScalar();
                if ((result != null) && (result != DBNull.Value))
                {
                    _ssn = result.ToString();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connectProd.Close();
            }

            return _ssn;
        }
    }
}
