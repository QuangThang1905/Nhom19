using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nhom19.Business
{
    public class Order
    {
        private String order_number;
        private String user;
        private String payment;
        private String firstname;
        private String lastname;
        private String phone;
        private String email;
        private String address;
        private String order_note;
        private Double order_total;
        private Double tax;
        private String status;
        private bool is_payment;
        private DateTime created_date;
        private DateTime update_date;

        private Double money_total;

        public string Order_number { get => order_number; set => order_number = value; }
        public string User { get => user; set => user = value; }
        public string Payment { get => payment; set => payment = value; }
        public string Firstname { get => firstname; set => firstname = value; }
        public string Lastname { get => lastname; set => lastname = value; }
        public string Phone { get => phone; set => phone = value; }
        public string Email { get => email; set => email = value; }
        public string Address { get => address; set => address = value; }
        public string Order_note { get => order_note; set => order_note = value; }
        public double Order_total { get => order_total; set => order_total = value; }
        public double Tax { get => tax; set => tax = value; }
        public string Status { get => status; set => status = value; }
        public bool Is_payment { get => is_payment; set => is_payment = value; }
        public DateTime Created_date { get => created_date; set => created_date = value; }
        public DateTime Update_date { get => update_date; set => update_date = value; }
        public double Money_total { get => money_total; set => money_total = value; }
    }
}
