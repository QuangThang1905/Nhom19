using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Nhom19.Business;
using Nhom19.Model;
namespace Nhom19
{
    public partial class MyCart : Form
    {
        public MyCart()
        {
            InitializeComponent();
        }

        private void MyCart_Load(object sender, EventArgs e)
        {
            dgvCart.DefaultCellStyle.Font = new Font("Tahoma", 12);
            dgvCart.Rows.Clear();
            //
            List<CartItems> cartitems = CartItemsDB.myCart();
            foreach (CartItems cartitem in cartitems)
            {
                int numrow = dgvCart.Rows.Add();
                dgvCart.Rows[numrow].Cells[0].Value = cartitem.Variation;
                dgvCart.Rows[numrow].Cells[1].Value = cartitem.Product_name;
                dgvCart.Rows[numrow].Cells[2].Value = cartitem.Color;
                dgvCart.Rows[numrow].Cells[3].Value = cartitem.Size;
                dgvCart.Rows[numrow].Cells[4].Value = cartitem.Tong;
            }

        }

        private void dgvCart_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home home = new Home();
            home.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home home = new Home();
            home.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            CheckOut checkout = new CheckOut();
            checkout.Show();
        }
    }
}
