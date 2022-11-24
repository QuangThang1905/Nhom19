using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nhom19.Business
{
    public class Variation
    {
        private String variation_id;
        private int product;
        private String color;
        private String size;
        private int variation_stock;
        private bool is_active;
        private DateTime creaded_date;

        public string Variation_id { get => variation_id; set => variation_id = value; }
        public int Product { get => product; set => product = value; }
        public string Color { get => color; set => color = value; }
        public string Size { get => size; set => size = value; }
        public int Variation_stock { get => variation_stock; set => variation_stock = value; }
        public bool Is_active { get => is_active; set => is_active = value; }
        public DateTime Creaded_date { get => creaded_date; set => creaded_date = value; }
    }
}
