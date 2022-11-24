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
    public partial class AddCart : Form
    {
        public String variation_id;
        public String color;
        public String size;
        public AddCart()
        {
            InitializeComponent();
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void AddCart_Load(object sender, EventArgs e)
        {
            label12.Text = this.color;
            label13.Text = this.size;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int quantity = Convert.ToInt32(txt14.Text);

            int result = CartItemsDB.addCart(this.variation_id, quantity);
            if (result == 1)
            {
                MessageBox.Show("Phải lớn hơn 0\nKo đủ hàng, giảm số lượng please!");
            }
            else
            {
                MessageBox.Show("Add Successfull");
                this.Hide();
                MyCart myCart = new MyCart();
                myCart.Show();
            }
        }
    }
}
