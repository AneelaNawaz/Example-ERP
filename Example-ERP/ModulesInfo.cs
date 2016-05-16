using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Example_ERP
{
    public partial class ModulesInfo : Form
    {
        public ModulesInfo()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Product_Details pd = new Product_Details();
            pd.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RecordInsertUpdate riu = new RecordInsertUpdate();
            riu.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SerchForm sf = new SerchForm();
            sf.Show();
        }
    }
}
