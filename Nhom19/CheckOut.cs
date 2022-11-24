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
    public partial class CheckOut : Form
    {
        public CheckOut()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String firstname = textBox0.Text;
            String lastname = textBox1.Text;
            String phone = textBox2.Text;
            String email = textBox3.Text;
            String address = textBox4.Text;
            String order_note = textBox5.Text;

            int result = OrderDB.addOrder(firstname, lastname, phone, email, address, order_note);
            if(result == 1)
            {
                MessageBox.Show("Vui lòng kiểm tra lại số lượng mặt hàng!");
            }
            else
            {
                MessageBox.Show("Order thành công!");
                this.Hide();
                MyOrder myorder = new MyOrder();
                myorder.Show();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home home = new Home();
            home.Show();
        }
    }
}
