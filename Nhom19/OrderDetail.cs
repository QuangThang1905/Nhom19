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
    public partial class OrderDetail : Form
    {
        public String order_number;
        public OrderDetail()
        {
            InitializeComponent();
        }

        private void OrderProduct_Load(object sender, EventArgs e)
        {
            dgvCart.DefaultCellStyle.Font = new Font("Tahoma", 12);
            dgvCart.Rows.Clear();
            //
            List<OrderProduct> orderproducts = OrderProductDB.getOrderDetail(this.order_number);
            foreach (OrderProduct orderproduct in orderproducts)
            {
                int numrow = dgvCart.Rows.Add();
                dgvCart.Rows[numrow].Cells[0].Value = orderproduct.Order;
                dgvCart.Rows[numrow].Cells[1].Value = orderproduct.Payment;
                dgvCart.Rows[numrow].Cells[2].Value = orderproduct.Toy_name;
                dgvCart.Rows[numrow].Cells[3].Value = orderproduct.Color;
                dgvCart.Rows[numrow].Cells[4].Value = orderproduct.Size;
                dgvCart.Rows[numrow].Cells[5].Value = orderproduct.Quantity;
                dgvCart.Rows[numrow].Cells[6].Value = orderproduct.Product_price;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool result = UserDB.isAdmin();

            if (result)
            {
                this.Hide();
                HomeAdmin home = new HomeAdmin();
                home.Show();
            }
            else
            {
                this.Hide();
                Home home = new Home();
                home.Show();
            }
        }
    }
}
