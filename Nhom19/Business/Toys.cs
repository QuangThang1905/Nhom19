using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nhom19.Business
{
    public class Toys
    {
        private int toy_id;
        private String toy_name;
        private String category;
        private String desscription;
        private double price;
        private String image;
        private int stock;
        private String is_available;
        private DateTime created_date;
        private DateTime modified_date;

        public int Toy_id { get => toy_id; set => toy_id = value; }
        public string Toy_name { get => toy_name; set => toy_name = value; }
        public string Category { get => category; set => category = value; }
        public string Desscription { get => desscription; set => desscription = value; }
        public double Price { get => price; set => price = value; }
        public string Image { get => image; set => image = value; }
        public int Stock { get => stock; set => stock = value; }
        public string Is_available { get => is_available; set => is_available = value; }
        public DateTime Created_date { get => created_date; set => created_date = value; }
        public DateTime Modified_date { get => modified_date; set => modified_date = value; }
    }
}
