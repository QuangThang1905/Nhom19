using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nhom19.Business
{
    public class Payment
    {
        private String payment_id;
        private String payment_method;
        private float amount_paid;
        private String status;
        private DateTime created_at;

        public string Payment_id { get => payment_id; set => payment_id = value; }
        public string Payment_method { get => payment_method; set => payment_method = value; }
        public float Amount_paid { get => amount_paid; set => amount_paid = value; }
        public string Status { get => status; set => status = value; }
        public DateTime Created_at { get => created_at; set => created_at = value; }
    }
}
