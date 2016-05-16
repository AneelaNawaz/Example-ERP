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
    
    
    public partial class Product_Details : Form
    {   public OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\Goods.accdb");
        
        public Product_Details()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text == "")
            {
                MessageBox.Show("Please Enter your ID first");
            }
            else
            {
                ProductClass pc = new ProductClass();
                pc.ConnectionMethod();
                    
                OleDbCommand cmd = new OleDbCommand("SELECT * from Prod_Details;", con);


                DataTable table = new DataTable();
                OleDbDataAdapter adapter = new OleDbDataAdapter();
                adapter.SelectCommand = cmd;
                adapter.Fill(table);
                dataGridView1.DataSource = table;

                dataGridView1.ReadOnly = true;

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                
            }



        }

        
    }
}
