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
    public partial class Payment_Method : Form
    {
        public String order_number;
        public Double money_total;
        public Boolean is_payment;
        public Payment_Method()
        {
            InitializeComponent();
        }

        private void Payment_Method_Load(object sender, EventArgs e)
        {
            if(this.is_payment == false)
            {
                label1.Hide();
            }
            else
            {
                button1.Hide();
            }
            label2.Text = "Total: "+this.money_total+"$";


        }

        private void button1_Click(object sender, EventArgs e)
        {
            String payment_method = txt1.Text;

            int result = PaymentDB.addPayment(this.order_number, payment_method);
            if (result == 1)
            {
                MessageBox.Show("Pay unsuccessfully!");
            }
            else
            {
                MessageBox.Show("Pay Successfull");
                this.Hide();
                Payment payment = new Payment();
                payment.Show();
            }
        }
    }
}
