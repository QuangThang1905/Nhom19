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
    public partial class MyUser : Form
    {
        public MyUser()
        {
            InitializeComponent();
        }

        private void MyUser_Load(object sender, EventArgs e)
        {
            String cur = UserDB.getCurrentUser();
            label6.Text = cur;

            User user = UserDB.getUser();
            txt7.Text = user.Firstname;
            txt8.Text = user.Lastname;
            txt9.Text = user.Email;
            txt10.Text = user.Phone_number;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home home = new Home();
            home.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String firstname = txt7.Text;
            String lastname = txt8.Text;
            String email = txt9.Text;
            String phone_number = txt10.Text;

            int result = UserDB.editProfile(firstname, lastname, email, phone_number);
            if (result == 1)
            {
                MessageBox.Show("Edit ko thành công!");
            }
            else
            {
                MessageBox.Show("Edit thành công!");
                this.Hide();
                MyUser myuser = new MyUser();
                myuser.Show();
            }
        }
    }
}
