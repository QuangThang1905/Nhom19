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
    public partial class Payment : Form
    {
        public Payment()
        {
            InitializeComponent();
        }

        private void Payment_Load(object sender, EventArgs e)
        {
            dgvCart.DefaultCellStyle.Font = new Font("Tahoma", 12);
            dgvCart.Rows.Clear();
            //
            List<Order> orders = PaymentDB.myPayment();
            foreach (Order order in orders)
            {
                int numrow = dgvCart.Rows.Add();
                dgvCart.Rows[numrow].Cells[0].Value = order.Order_number;
                dgvCart.Rows[numrow].Cells[1].Value = order.Firstname;
                dgvCart.Rows[numrow].Cells[2].Value = order.Lastname;
                dgvCart.Rows[numrow].Cells[3].Value = order.Money_total;
                dgvCart.Rows[numrow].Cells[4].Value = order.Is_payment;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home home = new Home();
            home.Show();
        }

        private void dgvCart_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string rowIndex0 = (string)dgvCart.CurrentRow.Cells[0].Value;
            Double rowIndex3 = (Double)dgvCart.CurrentRow.Cells[3].Value;
            Boolean rowIndex4 = (Boolean)dgvCart.CurrentRow.Cells[4].Value;
            Payment_Method pm = new Payment_Method();
            pm.order_number = rowIndex0;
            pm.money_total = rowIndex3;
            pm.is_payment = rowIndex4;
            pm.Show();
        }
    }
}
