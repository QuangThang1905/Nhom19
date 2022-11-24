using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Nhom19.Business;
namespace Nhom19.Model
{
    public class CartItemsDB
    {
        public static int addCart(String variation_id, int quantity)
        {
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection("data source=localhost; database=" + ConnectionP.database + ";User ID = " + ConnectionP.user_id + "; Password = " + ConnectionP.pass);
                conn.Open();

                SqlCommand cm = new SqlCommand();
                cm.CommandText = "AddCartItems";
                cm.CommandType = CommandType.StoredProcedure;
                cm.Connection = conn;

                cm.Parameters.Add("@variation_id", SqlDbType.NVarChar).Value = variation_id;
                cm.Parameters.Add("@quantity", SqlDbType.Int).Value = quantity;

                return cm.ExecuteNonQuery();
            }
            catch (Exception)
            {
                return 1;
            }
            finally
            {
                conn.Close();
            }
        }
        public static List<CartItems> myCart()
        {
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection("data source=localhost; database=" + ConnectionP.database + ";User ID = " + ConnectionP.user_id + "; Password = " + ConnectionP.pass);
                conn.Open();

                SqlCommand cm = new SqlCommand();
                cm.CommandText = "MyCart";
                cm.CommandType = CommandType.StoredProcedure;
                cm.Connection = conn;

                //cm.Parameters.Add("@user_id", SqlDbType.NVarChar).Value = user_id;

                List<CartItems> cartitems = new List<CartItems>();
                SqlDataReader sdr = cm.ExecuteReader();
                while (sdr.Read())
                {
                    CartItems cartitem = new CartItems();
                    cartitem.Variation = Convert.ToString(sdr["variation"]);
                    cartitem.Product_name = Convert.ToString(sdr["toy_name"]);
                    cartitem.Color = Convert.ToString(sdr["color"]);
                    cartitem.Size = Convert.ToString(sdr["size"]);
                    cartitem.Tong = Convert.ToInt32(sdr["tong"]);

                    cartitems.Add(cartitem);
                }

                return cartitems;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
