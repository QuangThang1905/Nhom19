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
    public partial class AddToy : Form
    {
        public AddToy()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            ToysAdmin ta = new ToysAdmin();
            ta.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String toy_name = txt6.Text;
            String category = txt7.Text;
            String description = txt10.Text;
            Double price = Convert.ToDouble(txt8.Text);
            String image = txt9.Text;

            int result = ToysDB.addToy(toy_name, category, description, price, image);
            if (result == 1) 
            {
                MessageBox.Show("Add thành công!");
            }
            else
            {
                MessageBox.Show("Kiểm tra thông tin");
                this.Hide();
                ToysAdmin ta = new ToysAdmin();
                ta.Show();
            }
        }
    }
}
