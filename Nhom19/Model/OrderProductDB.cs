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
    public class OrderProductDB
    {
        public static List<OrderProduct> getOrderDetail(String order_number)
        {
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection("data source=localhost; database=" + ConnectionP.database + ";User ID = " + ConnectionP.user_id + "; Password = " + ConnectionP.pass);
                conn.Open();

                SqlCommand cm = new SqlCommand();
                cm.CommandText = "OrderDetail";
                cm.CommandType = CommandType.StoredProcedure;
                cm.Connection = conn;

                cm.Parameters.Add("@order", SqlDbType.NVarChar).Value = order_number;

                List<OrderProduct> orderproducts = new List<OrderProduct>();
                SqlDataReader sdr = cm.ExecuteReader();
                while (sdr.Read())
                {
                    OrderProduct orderproduct = new OrderProduct();
                    orderproduct.Order = Convert.ToString(sdr["order"]);
                    orderproduct.Payment = Convert.ToString(sdr["payment"]);
                    orderproduct.Toy_name = Convert.ToString(sdr["toy_name"]);
                    orderproduct.Color = Convert.ToString(sdr["color"]);
                    orderproduct.Size = Convert.ToString(sdr["size"]);
                    orderproduct.Quantity = Convert.ToInt32(sdr["quantity"]);
                    orderproduct.Product_price = Convert.ToDouble(sdr["product_price"]);

                    orderproducts.Add(orderproduct);
                }

                return orderproducts;
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
