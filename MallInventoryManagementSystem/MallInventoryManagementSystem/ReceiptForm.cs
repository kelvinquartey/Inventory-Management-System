using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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
            LoadTotal();
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
                    LoadTotal();


                }
            }
            LoadReceipt();
        }

        Bitmap bitmaptoprint;

        public void CaptureFormShot()
        {
            bitmaptoprint = new Bitmap(this.Width, this.Height);
            this.DrawToBitmap(bitmaptoprint, new Rectangle(0, 0, this.Width, this.Height));
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.PrintPreviewControl.Zoom = 1;
            printPreviewDialog1.ShowDialog();
        }
        public void LoadTotal()
        {
            con.Open();
            string total = "SELECT SUM(total) FROM ReceiptTb";

            SqlCommand command = new SqlCommand(total, con);
            SqlDataReader da = command.ExecuteReader();
            while(da.Read())
            {
                txtBxGrandTotal.Text = da.GetValue(0).ToString();
            }

            con.Close();
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            delete();
            this.Hide();
            SalesForm form = new SalesForm();
            form.ShowDialog();
        }

        public void LoadChange()
        {
            int cash;
            cash = int.Parse(textBxCash.Text);
            int GrandTotal;
            GrandTotal = int.Parse(txtBxGrandTotal.Text);
            int change;
            change = GrandTotal - cash;
            string total1 = Convert.ToString(change);
            txtBxGrandTotal.Text = total1;
        }

        private void textBxCash_TextChanged(object sender, EventArgs e)
        {

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap imagebmp = new Bitmap(dgvReceipt.Width, dgvReceipt.Height);
            dgvReceipt.DrawToBitmap(imagebmp, new Rectangle(0, 0, dgvReceipt.Width, dgvReceipt.Height));
            e.Graphics.DrawImage(imagebmp, 120, 0);
            delete();
        }
        


        private void ReceiptForm_Load(object sender, EventArgs e)
        {

        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

        }
    }
}
