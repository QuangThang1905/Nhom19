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
    public partial class AddVariations : Form
    {
        public AddVariations()
        {
            InitializeComponent();
        }

        private void AddVariations_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            VariationsAdmin va = new VariationsAdmin();
            va.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int toy_id = Convert.ToInt32(txt6.Text);
            String color = txt7.Text;
            String size = txt8.Text;
            int variation_stock = Convert.ToInt32(txt9.Text);

            int result = VariationDB.addVariation(toy_id, color, size, variation_stock);
            if (result == 1)
            {
                MessageBox.Show("Add thành công!");
            }
            else
            {
                MessageBox.Show("Kiểm tra thông tin");
                this.Hide();
                VariationsAdmin va = new VariationsAdmin();
                va.Show();
            }
        }
    }
}
