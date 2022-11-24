using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Nhom19.Business;
using Nhom19.Model;
namespace Nhom19
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void lblDangNhap_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtTenDangNhap.Text = String.Empty;
            txtMatKhau.Text = String.Empty;
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            //
            ConnectionP.user_id = txtTenDangNhap.Text;
            ConnectionP.pass = txtMatKhau.Text;
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection("data source=localhost; database=" + ConnectionP.database + ";User ID = " + ConnectionP.user_id + "; Password = " + ConnectionP.pass);
                conn.Open();

                Home home = new Home();
                this.Hide();
                home.Show();
                
            }
            catch (Exception)
            {
                MessageBox.Show("Tai khoan hoac mat khau khong hop le");
            }
            finally
            {
                conn.Close();
            }

            //
            /*Boolean isexistuser = UserDB.isExistUser(txtTenDangNhap.Text);
            string message = null;
            if (!isexistuser)
            {
                message = "Tai khoan khong hop le";
            }
            else
            {
                Boolean isvalidpassword = UserDB.isValidPassword(txtTenDangNhap.Text, txtMatKhau.Text);
                if (!isvalidpassword)
                {
                    message = "Mat khau khong hop le";
                }
                else
                {
                    Boolean isadmin = UserDB.isAdmin(txtTenDangNhap.Text);
                    if (!isadmin)
                    {
                        ConnectionP.user_id = "customer";
                        ConnectionP.pass = "123456";
                        message = "Dang nhap voi tu cach la khach hang";
                    }
                    else
                    {
                        message = "Dang nhap voi tu cach la ADMIN";
                    }
                    
                }
            }
            MessageBox.Show(message); */

        }

        private void txtMatKhau_TextChanged(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RegisterCustomer rg = new RegisterCustomer();
            rg.Show();

        }
    }
}
