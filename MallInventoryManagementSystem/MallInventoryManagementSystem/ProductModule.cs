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
    public partial class ProductModule : Form
    {

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\NII\Documents\dbMS.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;
        public ProductModule()
        {
            InitializeComponent();
            LoadCategory();
        }

        public void LoadCategory()
        {
            comboQty.Items.Clear();
            cm = new SqlCommand("SELECT catname FROM CatTb", con);
            con.Open();
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                comboQty.Items.Add(dr[0].ToString());
            }
            dr.Close();
            con.Close();
        }
           

        public void Clear()
        {
            txtBoxPname.Clear();
            txtBoxQty.Clear();
            txtBoxPrice.Clear();
            txtBoxDesc.Clear();
            comboQty.Text = "";
        }

        

        private void label5_Click_1(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
            btnSave.Enabled = true;
            btnUpdate.Enabled = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure you want to save this Product?", "Saving Product", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    SqlCommand cm = new SqlCommand("INSERT INTO ProductTb(pname,pqty,pprice,pdescription,pcategory)VALUES(@pname,@pqty,@pprice,@pdescription,@pcategory)", con);
                    cm.Parameters.AddWithValue("@pname", txtBoxPname.Text);
                    cm.Parameters.AddWithValue("@pqty", Convert.ToInt16(txtBoxQty.Text));
                    cm.Parameters.AddWithValue("@pprice", Convert.ToInt16(txtBoxPrice.Text));
                    cm.Parameters.AddWithValue("@pdescription", txtBoxDesc.Text);
                    cm.Parameters.AddWithValue("@pcategory", comboQty.Text);
                    con.Open();
                    cm.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Product has been successfully added");
                    Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure you want to Edit this Product?", "Saving Product", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    SqlCommand cm = new SqlCommand("UPDATE ProductTb SET pname=@pname,pqty=@pqty,pprice=@pprice, pdescription=@pdescription,pcategory=@pcategory WHERE  pid LIKE '" + labelProdID.Text + "'", con);
                    cm.Parameters.AddWithValue("@pname", txtBoxPname.Text);
                    cm.Parameters.AddWithValue("@pqty", Convert.ToInt16(txtBoxQty.Text));
                    cm.Parameters.AddWithValue("@pprice", Convert.ToInt16(txtBoxPrice.Text));
                    cm.Parameters.AddWithValue("@pdescription", txtBoxDesc.Text);
                    cm.Parameters.AddWithValue("@pcategory", comboQty.Text);
                    con.Open();
                    cm.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Product has been successfully Updated");
                    this.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
