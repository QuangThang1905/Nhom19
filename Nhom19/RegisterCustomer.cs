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
    public partial class RegisterCustomer : Form
    {
        public RegisterCustomer()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String user_id = txt1.Text;
            String pass = txt2.Text;
            String firstname = txt3.Text;
            String lastname = txt4.Text;
            String email = txt5.Text;
            String phone_number = txt6.Text;

            int result = UserDB.registerCustomer(user_id,pass,firstname,lastname,email,phone_number);
            if (result == 1)
            {      
                MessageBox.Show("Đăng ký thành công");
                this.Hide();
            }
            else
            {
                MessageBox.Show("Đăng ký không thành công!\n Kiểm tra lại các thông tin hoặc user đã tồn tại");
            }
        }
    }
}
