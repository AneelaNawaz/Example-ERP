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
    public partial class RecordInsertUpdate : Form
    {
      //  public OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\Goods.accdb");
        public OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\Goods.accdb");
        public RecordInsertUpdate()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text == "")
            {
                MessageBox.Show("Bewakuuf! Pehle Name Enter Kro!");
               
            }
            else
            {

               // OleDbCommand cmd = new OleDbCommand("insert into Prod_Details (P_ID, P_name, P_type, P_unit, P_Qty, P_Price) values ('" + textBox1.Text + "', ' " + textBox2.Text + " ',' " + 
                    //textBox3.Text + " ', ' " + textBox4.Text + "', '" + textBox5.Text + "', '" + textBox6.Text + "')", con);


                OleDbCommand cmd1 = new OleDbCommand("insert into Prod_Details (P_ID, P_name, P_type, P_unit, P_Qty, P_Price) values (@P_ID, @P_name, @P_type, @P_unit, @P_Qty, @P_Price)", con);
                con.Open();
                cmd1.Parameters.AddWithValue("@P_ID", textBox1.Text);
                cmd1.Parameters.AddWithValue("@P_name", textBox2.Text);
                cmd1.Parameters.AddWithValue("@P_type", textBox3.Text);
                cmd1.Parameters.AddWithValue("@P_unit", textBox4.Text);
                cmd1.Parameters.AddWithValue("@P_Qty", textBox5.Text);
                cmd1.Parameters.AddWithValue("@P_Price", textBox6.Text);

                cmd1.ExecuteNonQuery();
                MessageBox.Show("Inserted");
                con.Close();
            }

        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {
            
        }

       

       

        
    }
}
