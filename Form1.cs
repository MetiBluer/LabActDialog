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

namespace LabAct2
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void importExcelFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFile.Title = "Open Excel";
            openFile.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            openFile.Filter = "All files (*.*)|*.*|Excel File (*.xlxs)|*.xlsx";
            openFile.FilterIndex = 2;
            openFile.ShowDialog();

            if (!string.IsNullOrEmpty(openFile.Filter))
            {
                OleDbConnection conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;" +
                    "Data Source=" + openFile.FileName + "; Extended Properties='Excel 12.0 Xml; HDR=Yes'");
                conn.Open();
                OleDbDataAdapter ada = new OleDbDataAdapter("SELECT * FROM [Sheet1$]", conn);
                DataTable dt = new DataTable();
                ada.Fill(dt);
                dgvDialog.DataSource = dt;
                conn.Close();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

      
                if (cbAdd.SelectedIndex == 0)
                {
                    OleDbConnection conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;" +
                       "Data Source=" + openFile.FileName + "; Extended Properties='Excel 12.0 Xml; HDR=Yes'");
                    string query = "SELECT * FROM [Sheet1$] WHERE idNumber LIKE '" + txtSearch.Text + "' ";
                    OleDbCommand cmd = new OleDbCommand(query, conn);
                    OleDbDataAdapter ada = new OleDbDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    ada.Fill(dt);
                    dgvDialog.DataSource = dt;
                    conn.Close();
                }
               else if (cbAdd.SelectedIndex == 1)
                {
                    OleDbConnection conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;" +
                       "Data Source=" + openFile.FileName + "; Extended Properties='Excel 12.0 Xml; HDR=Yes'");
                    string query = "SELECT * FROM [Sheet2$] WHERE code LIKE '" + txtSearch.Text + "' ";
                    OleDbCommand cmd = new OleDbCommand(query, conn);
                    OleDbDataAdapter ada = new OleDbDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    ada.Fill(dt);
                    dgvDialog.DataSource = dt;
                    conn.Close();

                }
                else
            {
                MessageBox.Show("Select a Data");
            }

        }

        private void cbAdd_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            cbAdd.Items.Add("Student");
            cbAdd.Items.Add("Subject");

        }

        private void subjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSubject frmSub = new frmSubject();
            frmSub.ShowDialog();
        }

        private void studentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmStudent frmStud = new frmStudent();
            frmStud.ShowDialog();
        }
    }
}
