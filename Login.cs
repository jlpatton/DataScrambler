using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DataScrambler.Code;

namespace DataScrambler
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (Authorization.Authenticate(txtUser.Text, txtpswd.Text, "CORP"))
                {
                    this.Close();
                    this.DialogResult = DialogResult.OK;
                }
            }
            catch (Exception ex)
            {                
                MessageBox.Show(ex.Message + " Check your Employee Number or Password.");
            }
        }      

    }
}