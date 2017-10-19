using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void btnAdaugare_Click(object sender, EventArgs e)
        {
            TreeNode animale = new TreeNode("animale");
            
            
            TreeNode pisici = new TreeNode("pisici");
            TreeNode pisiciNegre = new TreeNode("pisici negre");

            pisici.Nodes.Add(pisiciNegre);
            animale.Nodes.Add(pisici);

            TreeNode pisiciNegreMici = new TreeNode("pisici negre mici");

            pisiciNegre.Nodes.Add(pisiciNegreMici);

            treeView1.Nodes.Add(animale);


            String connection = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\Tables.accdb;Persist Security Info=True";
            string sql = "SELECT Clients  FROM Tables";
            using (OleDbConnection conn = new OleDbConnection(connection))
            {
                conn.Open();
                DataSet ds = new DataSet();
                DataGridView dataGridView1 = new DataGridView();
                using (OleDbDataAdapter adapter = new OleDbDataAdapter(sql, conn))
                {
                    adapter.Fill(ds);
                    dataGridView1.DataSource = ds;
                    // Of course, before addint the datagrid to the hosting form you need to 
                    // set position, location and other useful properties. 
                    // Why don't you create the DataGrid with the designer and use that instance instead?
                    this.Controls.Add(dataGridView1);
                }
            }


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
