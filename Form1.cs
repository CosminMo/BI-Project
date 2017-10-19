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
        String conn_string = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source = C:\\Users\\Cosmin\\Desktop\\BI-Project\\tree view supp files\\test4t.accdb; Persist Security Info = False";
        String error_message = "";
        String q = "";
        OleDbConnection conexiune = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }


        

        private void btnAdaugare_Click(object sender, EventArgs e)
        {
           
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            connectToolStripMenuItem.PerformClick();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void connectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                conexiune = new OleDbConnection(conn_string);
                conexiune.Open();
                disconnectToolStripMenuItem.Enabled=true;
                connectToolStripMenuItem.Enabled = false;
            }
            catch(Exception Ex) { MessageBox.Show(Ex.Message); }
        }

        private void disconnectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                conexiune.Close();
                disconnectToolStripMenuItem.Enabled = false;
                connectToolStripMenuItem.Enabled = true;
            }
            catch(Exception Ex) { MessageBox.Show(Ex.Message); }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            disconnectToolStripMenuItem.PerformClick();
        }

        private void run_Query()
        {
            error_message = "";
            q = txtQuery.Text;
            try
            {
                OleDbCommand comanda = new OleDbCommand(q, conexiune);
                OleDbDataAdapter adaptor = new OleDbDataAdapter(comanda);

                DataTable dt = new DataTable();
                adaptor.SelectCommand = comanda;
                adaptor.Fill(dt);

                Rezultat.DataSource = dt;
                Rezultat.AutoResizeColumns();

            }
            catch(Exception Ex)
            {
                error_message = Ex.Message;
                MessageBox.Show(error_message);
            }
        }

        private void runQueryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            run_Query();
            this.Cursor = Cursors.Default;
        }
    }
}
