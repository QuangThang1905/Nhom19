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
    public partial class UpdatePrice : Form
    {
        public int toy_id;
        public UpdatePrice()
        {
            InitializeComponent();
        }

        private void UpdatePrice_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            double price = Convert.ToDouble(txt1.Text);
            int result = ToysDB.updatePrice(this.toy_id,price);

            if (result == 1)
            {
                MessageBox.Show("Update thành công");
                this.Hide();
            }
            else
            {
                MessageBox.Show("Không thành công");
            }
        }

        private void txt1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
