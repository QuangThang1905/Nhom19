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
    public partial class Home : Form
    {
        public List<Toys> toys = ToysDB.random6toys();
        public Toys findToy;
        public Home()
        {
            InitializeComponent();
        }

        private void Home_Load(object sender, EventArgs e)
        {
            //
            button1.Text = "Chao " + UserDB.getCurrentUser();

            string imageFolder = Path.Combine(System.IO.Path.GetDirectoryName(Application.ExecutablePath), "Images");
            string fileDefaultImage = Path.Combine(imageFolder, "add.png");
            
            if(findToy != null)
            {
                //1
                txtToyName1.Text = findToy.Toy_name;
                txtToyPrice1.Text = "$" + Convert.ToString(findToy.Price);
                string filePath0 = Path.Combine(imageFolder, findToy.Image);
                picBook1.Image = Image.FromFile(filePath0);
            }
            else
            {
                //1
                txtToyName1.Text = toys[0].Toy_name;
                txtToyPrice1.Text = "$" + Convert.ToString(toys[0].Price);
                string filePath1 = Path.Combine(imageFolder, toys[0].Image);
                picBook1.Image = Image.FromFile(filePath1);

                //2
                txtToyName2.Text = toys[1].Toy_name;
                txtToyPrice2.Text = "$" + Convert.ToString(toys[1].Price);
                string filePath2 = Path.Combine(imageFolder, toys[1].Image);
                picBook2.Image = Image.FromFile(filePath2);


                //3
                txtToyName3.Text = toys[2].Toy_name;
                txtToyPrice3.Text = "$" + Convert.ToString(toys[2].Price);
                string filePath3 = Path.Combine(imageFolder, toys[2].Image);
                picBook3.Image = Image.FromFile(filePath3);


                //4
                txtToyName4.Text = toys[3].Toy_name;
                txtToyPrice4.Text = "$" + Convert.ToString(toys[3].Price);
                string filePath4 = Path.Combine(imageFolder, toys[3].Image);
                picBook4.Image = Image.FromFile(filePath4);


                //5
                txtToyName5.Text = toys[4].Toy_name;
                txtToyPrice5.Text = "$" + Convert.ToString(toys[4].Price);
                string filePath5 = Path.Combine(imageFolder, toys[4].Image);
                picBook5.Image = Image.FromFile(filePath5);


                //6
                txtToyName6.Text = toys[5].Toy_name;
                txtToyPrice6.Text = "$" + Convert.ToString(toys[5].Price);
                string filePath6 = Path.Combine(imageFolder, toys[5].Image);
                picBook6.Image = Image.FromFile(filePath6);
            }                   
        }

        private void picBook1_Click(object sender, EventArgs e)
        {
            Product_Detail product_detail = null;
            if (findToy != null)
            {
                product_detail = new Product_Detail(findToy.Toy_id);
            }
            else
            {
                product_detail = new Product_Detail(toys[0].Toy_id);
            }
            this.Hide();
            product_detail.Show();
        }
        private void picBook2_Click(object sender, EventArgs e)
        {
            Product_Detail product_detail = new Product_Detail(toys[1].Toy_id);
            this.Hide();
            product_detail.Show();
        }
        private void picBook3_Click(object sender, EventArgs e)
        {
            Product_Detail product_detail = new Product_Detail(toys[2].Toy_id);
            this.Hide();
            product_detail.Show();
        }
        private void picBook4_Click(object sender, EventArgs e)
        {
            Product_Detail product_detail = new Product_Detail(toys[3].Toy_id);
            this.Hide();
            product_detail.Show();
        }

        private void picBook5_Click(object sender, EventArgs e)
        {
            Product_Detail product_detail = new Product_Detail(toys[4].Toy_id);
            this.Hide();
            product_detail.Show();
        }

        private void picBook6_Click(object sender, EventArgs e)
        {
            Product_Detail product_detail = new Product_Detail(toys[5].Toy_id);
            this.Hide();
            product_detail.Show();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.findToy = ToysDB.findToy(txtTimkiem.Text);
            this.Hide();
            home.Show();
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home home = new Home();
            home.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            MyCart mycart = new MyCart();
            mycart.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            MyOrder myorder = new MyOrder();
            myorder.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Payment payment = new Payment();
            payment.Show();
        }

        private void btnAccount_Click(object sender, EventArgs e)
        {
            this.Hide();
            MyUser myuser = new MyUser();
            myuser.Show();
        }
    }
}
