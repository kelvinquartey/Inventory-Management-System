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
    public partial class ManageProducts : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\NII\Documents\dbMS.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;

        public void LoadProduct()
        {
            int i = 0;
            dgvProducts.Rows.Clear();
            cm = new SqlCommand("SELECT * FROM ProductTb WHERE CONCAT(pname, pprice, pdescription, pcategory) LIKE '%" + txtSearch.Text + "%'  ", con);
            con.Open();
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dgvProducts.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString());
            }
            dr.Close();
            con.Close();
        }
        public ManageProducts()
        {
            InitializeComponent();
            LoadProduct();
        }

        private void dgvProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvProducts.Columns[e.ColumnIndex].Name;
            if (colName == "Edit")
            {
                ProductModule productModule = new ProductModule();
                productModule.labelProdID.Text = dgvProducts.Rows[e.RowIndex].Cells[1].Value.ToString();
                productModule.txtBoxPname.Text = dgvProducts.Rows[e.RowIndex].Cells[2].Value.ToString();
                productModule.txtBoxQty.Text = dgvProducts.Rows[e.RowIndex].Cells[3].Value.ToString();
                productModule.txtBoxPrice.Text = dgvProducts.Rows[e.RowIndex].Cells[4].Value.ToString();
                productModule.txtBoxDesc.Text = dgvProducts.Rows[e.RowIndex].Cells[5].Value.ToString();
                productModule.comboQty.Text = dgvProducts.Rows[e.RowIndex].Cells[6].Value.ToString();

                productModule.btnSave.Enabled = false;
                productModule.btnUpdate.Enabled = true;
                productModule.ShowDialog();
            }
            else if (colName == "Delete")
            {
                if (MessageBox.Show("Are you sure you want to delete this Product?", "Deleting Product", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    con.Open();
                    cm = new SqlCommand("DELETE FROM ProductTb WHERE pid LIKE '" + dgvProducts.Rows[e.RowIndex].Cells[1].Value.ToString() + "'", con);
                    cm.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("User has been succesfully deleted!");
                }
            }
            LoadProduct();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminHome af = new AdminHome();
            af.Show();
        }

        private void txtSearch_TextChanged_1(object sender, EventArgs e)
        {
            LoadProduct();
        }

        private void btnAddUsers_Click(object sender, EventArgs e)
        {
            ProductModule formModule = new ProductModule();
            formModule.btnSave.Enabled = true;
            formModule.btnUpdate.Enabled = false;
            formModule.ShowDialog();
            LoadProduct();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
