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
    public partial class VariationsAdmin : Form
    {
        public VariationsAdmin()
        {
            InitializeComponent();
        }

        private void VariationsAdmin_Load(object sender, EventArgs e)
        {
            dgvCart.DefaultCellStyle.Font = new Font("Tahoma", 12);
            dgvCart.Rows.Clear();
            //
            List<Variation> variations = VariationDB.allVariationsAdmin();
            foreach (Variation variation in variations)
            {
                int numrow = dgvCart.Rows.Add();
                dgvCart.Rows[numrow].Cells[0].Value = variation.Variation_id;
                dgvCart.Rows[numrow].Cells[1].Value = variation.Toy_name;
                dgvCart.Rows[numrow].Cells[2].Value = variation.Color;
                dgvCart.Rows[numrow].Cells[3].Value = variation.Size;
                dgvCart.Rows[numrow].Cells[4].Value = variation.Variation_stock;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            HomeAdmin ha = new HomeAdmin();
            ha.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddVariations av = new AddVariations();
            av.Show();
        }

        private void dgvCart_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            String rowIndex = (String)dgvCart.CurrentRow.Cells[0].Value;
            UpdateStock us = new UpdateStock();
            us.variation_id = rowIndex;
            us.Show();
        }
    }
}
