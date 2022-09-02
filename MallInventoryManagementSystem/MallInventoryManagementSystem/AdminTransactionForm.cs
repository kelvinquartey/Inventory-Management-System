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
    public partial class AdminTransactionForm : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\NII\Documents\dbMS.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;

        public AdminTransactionForm()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminHome adminForm = new AdminHome();
            adminForm.ShowDialog();
        }

        private void dgvTransaction_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            LoadTransaction();
        }

        public void LoadTransaction()
        {
            int i = 0;
            dgvTransaction.Rows.Clear();
            cm = new SqlCommand("SELECT * FROM TransTb WHERE CONCAT(pname, pprice, date, pqty) LIKE '%" + txtBoxShowTransDate.Text + "%'  ", con);
            //cm = new SqlCommand("SELECT * FROM TransTb", con);
            con.Open();
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dgvTransaction.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString());
            }
            dr.Close();
            con.Close();
        }

        private void txtBoxShowTransDate_TextChanged(object sender, EventArgs e)
        {
            LoadTransaction();
        }
    }
}
