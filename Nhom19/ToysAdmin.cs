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
    public partial class ToysAdmin : Form
    {
        public ToysAdmin()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int toy_id = Convert.ToInt32(txt1.Text);

            int result = ToysDB.delToy(toy_id);
            if (result == 1)
            {
                MessageBox.Show("Delete thành công!");
            }
            else
            {
                MessageBox.Show("Toy ID ko hợp lệ");
                this.Hide();
                ToysAdmin ta = new ToysAdmin();
                ta.Show();
            }

        }

        private void ToysAdmin_Load(object sender, EventArgs e)
        {
            dgvCart.DefaultCellStyle.Font = new Font("Tahoma", 12);
            dgvCart.Rows.Clear();
            //
            List<Toys> toys = ToysDB.allToys();
            foreach (Toys toy in toys)
            {
                int numrow = dgvCart.Rows.Add();
                dgvCart.Rows[numrow].Cells[0].Value = toy.Toy_id;
                dgvCart.Rows[numrow].Cells[1].Value = toy.Toy_name;
                dgvCart.Rows[numrow].Cells[2].Value = toy.Category;
                dgvCart.Rows[numrow].Cells[3].Value = toy.Desscription;
                dgvCart.Rows[numrow].Cells[4].Value = toy.Price;
                dgvCart.Rows[numrow].Cells[5].Value = toy.Image;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            HomeAdmin home = new HomeAdmin();
            home.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddToy addtoy = new AddToy();
            addtoy.Show();
        }

        private void dgvCart_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = (int)dgvCart.CurrentRow.Cells[0].Value;
            UpdatePrice up = new UpdatePrice();
            up.toy_id = rowIndex;
            up.Show();
        }
    }
}
