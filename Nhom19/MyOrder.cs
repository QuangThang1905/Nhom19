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
    public partial class MyOrder : Form
    {
        public MyOrder()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home home = new Home();
            home.Show();
        }

        private void MyOrder_Load(object sender, EventArgs e)
        {
            dgvCart.DefaultCellStyle.Font = new Font("Tahoma", 12);
            dgvCart.Rows.Clear();
            //
            List<Order> orders = OrderDB.myOrder();
            foreach (Order order in orders)
            {
                int numrow = dgvCart.Rows.Add();
                dgvCart.Rows[numrow].Cells[0].Value = order.Order_number;
                dgvCart.Rows[numrow].Cells[1].Value = order.Firstname;
                dgvCart.Rows[numrow].Cells[2].Value = order.Lastname;
                dgvCart.Rows[numrow].Cells[3].Value = order.Phone;
                dgvCart.Rows[numrow].Cells[4].Value = order.Email;
                dgvCart.Rows[numrow].Cells[5].Value = order.Address;
                dgvCart.Rows[numrow].Cells[6].Value = order.Order_note;
                dgvCart.Rows[numrow].Cells[7].Value = order.Order_total;
                dgvCart.Rows[numrow].Cells[8].Value = order.Tax;
                dgvCart.Rows[numrow].Cells[9].Value = order.Is_payment;
            }
        }

        private void dgvCart_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string rowIndex = (string)dgvCart.CurrentRow.Cells[0].Value;
            OrderDetail od = new OrderDetail();
            od.order_number = rowIndex;
            od.Show();
        }
    }
}
