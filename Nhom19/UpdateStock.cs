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
    public partial class UpdateStock : Form
    {
        public String variation_id;
        public UpdateStock()
        {
            InitializeComponent();
        }

        private void UpdateStock_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int stock = Convert.ToInt32(txt1.Text);
            int result = VariationDB.updateStock(this.variation_id, stock);

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
    }
}
