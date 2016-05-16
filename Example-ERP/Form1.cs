using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Example_ERP
{
    public partial class Form1 : Form
    {
        public OleDbConnection con = new OleDbConnection();

        public Form1()
        {
            InitializeComponent();

            String strCon = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\Goods.accdb";

            con = new OleDbConnection(strCon);
            try
            {
                con.Open();
            }
            catch (OleDbException e)
            {
                MessageBox.Show("Access Error");
                MessageBox.Show("Error Code" + e.ErrorCode);
                MessageBox.Show("Error Message: " + e.Message);
            }
            catch (InvalidOperationException ie)
            {
                MessageBox.Show("Invalid Message: " + ie.Message);

            }
            if (con.State != ConnectionState.Open)
            {
                MessageBox.Show("Database Connection is Failed");
                Application.Exit();
            }
           
        }




        private void Form1_Load(object sender, EventArgs e)
        {


        }

        private void Login_Button_Click(object sender, EventArgs e)
        {
            String strCmd = "Select * from Login where username= @username AND password = @password";
            //   strCmd += "WHERE (username = @param2) AND (password = @param2)";

            OleDbDataAdapter da = new OleDbDataAdapter();
            DataTable dt = new DataTable();
            OleDbCommand command = new OleDbCommand();
            command.Connection = con;
            command.CommandType = CommandType.Text;
            command.CommandText = strCmd;
            //command.Parameters.Add("@param2", OleDbType.Char).Value = User_Box.Text;
            //command.Parameters.Add("@param3", OleDbType.Char).Value = Psw_Box.Text;
            command.Parameters.AddWithValue("@Username", User_Box.Text);
            command.Parameters.AddWithValue("@Password", Psw_Box.Text);
             


            da.SelectCommand = command;
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                // MessageBox.Show("Login is successfull");
                ModulesInfo mi = new ModulesInfo();
                mi.Show();
                this.Hide();
            }

            else
            {
                MessageBox.Show("Not Matched");
                dt.Dispose();
                command.Dispose();
                da.Dispose();
            }






        }

    }

}
   