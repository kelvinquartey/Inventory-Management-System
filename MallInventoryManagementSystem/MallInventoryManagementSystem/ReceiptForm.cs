using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MallInventoryManagementSystem
{
    public partial class ReceiptForm : Form
    {

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\NII\Documents\dbMS.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;

        public void LoadReceipt()
        {
            int i = 0;
            dgvReceipt.Rows.Clear();
            cm = new SqlCommand("SELECT * FROM ReceiptTb", con);
            con.Open();
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dgvReceipt.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString());
            }
            dr.Close();
            con.Close();
        }
        public ReceiptForm()
        {
            InitializeComponent();
            LoadReceipt();
        }
        private void delete()
        {
            con.Open();
            cm = new SqlCommand("DELETE FROM ReceiptTb", con);
            cm.ExecuteNonQuery();
            con.Close();
        }

        private void dgvReceipt_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvReceipt.Columns[e.ColumnIndex].Name;
            if (colName == "Delete")
            {
                if (MessageBox.Show("Are you sure you want to delete this purchase?", "Deleting Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    con.Open();
                    cm = new SqlCommand("DELETE FROM ReceiptTb WHERE id LIKE '" + dgvReceipt.Rows[e.RowIndex].Cells[1].Value.ToString() + "'", con);
                    cm.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Purchase has been succesfully deleted!");



                }
            }
            LoadReceipt();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            delete();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            delete();
            this.Hide();
            SalesForm form = new SalesForm();
            form.ShowDialog();
        }
    }
}
