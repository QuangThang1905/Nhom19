using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Nhom19.Business;
using Nhom19.Model;
namespace Nhom19
{
    public partial class Product_Detail : Form
    {
        public Toys toy;
        public List<Variation> variations;

        public Product_Detail(int toy_id)
        {
            this.toy = ToysDB.getToy(toy_id);
            this.variations = VariationDB.getVariations(toy_id);
            InitializeComponent();
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void Product_Detail_Load(object sender, EventArgs e)
        {
            //
            label10.Hide();
            button1.Hide();
            label14.Hide();
            label15.Hide();
            //

            label6.Text = Convert.ToString(toy.Toy_id);
            label7.Text = Convert.ToString(toy.Toy_name);
            label8.Text = Convert.ToString(toy.Category);
            label9.Text = Convert.ToString(toy.Price);
            label11.Text = Convert.ToString(toy.Desscription);
            string imageFolder = Path.Combine(System.IO.Path.GetDirectoryName(Application.ExecutablePath), "Images");
            string fileDefaultImage = Path.Combine(imageFolder, "add.png");
            string filePath1 = Path.Combine(imageFolder, toy.Image);
            picBook1.Image = Image.FromFile(filePath1);

            //cb1.Items.Add("");
            //cb2.Items.Add("");
            for(int i = 0; i < variations.Count; i++)
            {
                cb1.Items.Add(variations[i].Variation_id);
            }
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            button1.Show();

            Variation variation = VariationDB.getVariation(cb1.SelectedItem.ToString());
            label14.Text = variation.Color;
            label14.Show();
            label15.Text = variation.Size;
            label15.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home home = new Home();
            home.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddCart addcart = new AddCart();
            addcart.variation_id = cb1.SelectedItem.ToString();
            addcart.color = label14.Text;
            addcart.size = label15.Text;

            addcart.Show();



        }
    }
}
