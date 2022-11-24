using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nhom19.Business
{
    public class OrderProduct
    {
        private String order;
        private String payment;
        private int product;
        private String variations;
        private int quantity;
        private Double product_price;

        private String toy_name;
        private String color;
        private String size;

        public string Order { get => order; set => order = value; }
        public string Payment { get => payment; set => payment = value; }
        public int Product { get => product; set => product = value; }
        public string Variations { get => variations; set => variations = value; }
        public int Quantity { get => quantity; set => quantity = value; }
        public Double Product_price { get => product_price; set => product_price = value; }
        public string Toy_name { get => toy_name; set => toy_name = value; }
        public string Color { get => color; set => color = value; }
        public string Size { get => size; set => size = value; }
    }
}
