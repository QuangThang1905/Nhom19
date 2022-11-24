using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nhom19.Business
{
    public class CartItems
    {
        private String user;
        private int product;
        private String product_name;
        private String variation;
        private DateTime cart_items_id;
        private int quantity;
        private bool is_active;
        private String color;
        private String size;
        private int tong;
        private int variation_stock;

        public string User { get => user; set => user = value; }
        public int Product { get => product; set => product = value; }
        public string Product_name { get => product_name; set => product_name = value; }
        public string Variation { get => variation; set => variation = value; }
        public DateTime Cart_items_id { get => cart_items_id; set => cart_items_id = value; }
        public int Quantity { get => quantity; set => quantity = value; }
        public bool Is_active { get => is_active; set => is_active = value; }
        public string Color { get => color; set => color = value; }
        public string Size { get => size; set => size = value; }
        public int Tong { get => tong; set => tong = value; }
        public int Variation_stock { get => variation_stock; set => variation_stock = value; }


    }
}
