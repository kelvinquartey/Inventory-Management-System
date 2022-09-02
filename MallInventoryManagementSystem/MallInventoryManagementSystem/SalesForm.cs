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
    public partial class SalesForm : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\NII\Documents\dbMS.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;


        public SalesForm()
        {
            InitializeComponent();
            LoadProduct();
        }

        private void SalesForm_Load(object sender, EventArgs e)
        {

        }

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

        

        

        /** private void LoadData()
         {
             SqlCommand cd = new SqlCommand("INSERT INTO ReceiptTb(pname,pprice,pqty,total)VALUES(@pname,@pprice,@pqty,@total)", con);
             cd.Parameters.AddWithValue("@pname", textBoxProdName.Text);
             cd.Parameters.AddWithValue("@pprice", Convert.ToInt16(textBxPrice.Text));
             cd.Parameters.AddWithValue("@pqty", Convert.ToInt16(textBxQty.Text));
             cd.Parameters.AddWithValue("@total", txtBxTotal.Text);
             con.Open();
             cd.ExecuteNonQuery();
             con.Close();

         }**/

        

        public void Clear()
        {
            textBoxProdName.Clear();
            textBxQty.Clear();
            txtBxTotal.Clear();
            textBxPrice.Clear();
            textBxCash.Clear();
        }

        private void label5_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            AttendantHome attendantHome = new AttendantHome();
            attendantHome.ShowDialog();
        }

        private void btnGo_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            ReceiptForm receiptForm = new ReceiptForm();
            receiptForm.ShowDialog();
            Clear();
        }

        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            SqlCommand cm = new SqlCommand("INSERT INTO TransTb(pname,pprice,pqty,date)VALUES(@pname,@pprice,@pqty,@date)", con);
            cm.Parameters.AddWithValue("@pname", textBoxProdName.Text);
            cm.Parameters.AddWithValue("@pprice", Convert.ToInt16(textBxPrice.Text));
            cm.Parameters.AddWithValue("@pqty", Convert.ToInt16(textBxQty.Text));
            cm.Parameters.AddWithValue("@date", this.dateTimePicker1.Text);
            con.Open();
            cm.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Product has been successfully added");
            SqlCommand cd = new SqlCommand("INSERT INTO ReceiptTb(pname,pprice,pqty,total)VALUES(@pname,@pprice,@pqty,@total)", con);
            cd.Parameters.AddWithValue("@pname", textBoxProdName.Text);
            cd.Parameters.AddWithValue("@pprice", textBxPrice.Text);
            cd.Parameters.AddWithValue("@pqty", Convert.ToInt16(textBxQty.Text));
            cd.Parameters.AddWithValue("@total", txtBxTotal.Text);
            con.Open();
            cd.ExecuteNonQuery();
            con.Close();
            Clear();
            ;
        }

        private void dgvProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            LoadProduct();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadProduct();
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            try
            {
                cm = new SqlCommand("SELECT * FROM ProductTb WHERE pname=@pname AND pprice=@pprice", con);
                cm.Parameters.AddWithValue("@pname", textBoxProdName.Text);
                cm.Parameters.AddWithValue("@pprice", textBxPrice.Text);
                con.Open();
                dr = cm.ExecuteReader();
                dr.Read();

                if (dr.HasRows)
                {
                    MessageBox.Show("Product Details are CORRECT!", "PROCEED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Product Details are Incorrect!", "TRY AGAIN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonHome_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("End Till", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Hide();
                AttendantHome adminForm = new AttendantHome();
                adminForm.ShowDialog();
            }
        }

        /**private void LoadData()
        {
            SqlCommand cd = new SqlCommand("INSERT INTO ReceiptTb(pname,pprice,pqty,total)VALUES(@pname,@pprice,@pqty,@total)", con);
            cd.Parameters.AddWithValue("@pname", textBoxProdName.Text);
            cd.Parameters.AddWithValue("@pprice", textBxPrice.Text);
            cd.Parameters.AddWithValue("@pqty", Convert.ToInt16(textBxQty.Text));
            cd.Parameters.AddWithValue("@total", txtBxTotal.Text);
            con.Open();
            cd.ExecuteNonQuery();
            con.Close();

        }**/

    }
}
