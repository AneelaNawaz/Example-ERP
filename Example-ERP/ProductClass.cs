using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;

namespace Example_ERP
{
    class ProductClass
    {

        public void ConnectionMethod()

        {
            OleDbConnection con = new OleDbConnection();
            String strCon = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\Goods.accdb";

            con = new OleDbConnection(strCon);
            try
            {
                con.Open();
            }
            catch (OleDbException e)
            {
                System.Windows.Forms.MessageBox.Show("Access Error");
               System.Windows.Forms.MessageBox.Show("Error Code" + e.ErrorCode);
               System.Windows.Forms.MessageBox.Show("Error Message: " + e.Message);
            }
            catch (InvalidOperationException ie)
            {
                System.Windows.Forms.MessageBox.Show("Invalid Message: " + ie.Message);

            }
            if (con.State != System.Data.ConnectionState.Open)
            {
                System.Windows.Forms.MessageBox.Show("Database Connection is Failed");
                System.Windows.Forms.Application.Exit();
            }
        }
    }
}
