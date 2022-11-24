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
    public class PaymentDB
    {
        public static List<Order> myPayment()
        {
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection("data source=localhost; database=" + ConnectionP.database + ";User ID = " + ConnectionP.user_id + "; Password = " + ConnectionP.pass);
                conn.Open();

                SqlCommand cm = new SqlCommand();
                cm.CommandText = "MyPayment_Proc";
                cm.CommandType = CommandType.StoredProcedure;
                cm.Connection = conn;

                //cm.Parameters.Add("@toy_id", SqlDbType.Int).Value = toy_id;

                List<Order> orders = new List<Order>();
                SqlDataReader sdr = cm.ExecuteReader();
                while (sdr.Read())
                {
                    Order order = new Order();
                    order.Order_number = Convert.ToString(sdr["order_number"]);
                    order.Firstname = Convert.ToString(sdr["first_name"]);
                    order.Lastname = Convert.ToString(sdr["last_name"]);
                    order.Money_total = Convert.ToDouble(sdr["money_total"]);
                    order.Is_payment = Convert.ToBoolean(sdr["is_payment"]);

                    orders.Add(order);
                }

                return orders;
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
        public static int addPayment(String order_number, String payment_method)
        {
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection("data source=localhost; database=" + ConnectionP.database + ";User ID = " + ConnectionP.user_id + "; Password = " + ConnectionP.pass);
                conn.Open();

                SqlCommand cm = new SqlCommand();
                cm.CommandText = "AddPayment";
                cm.CommandType = CommandType.StoredProcedure;
                cm.Connection = conn;

                cm.Parameters.Add("@order_number", SqlDbType.NVarChar).Value = order_number;
                cm.Parameters.Add("@payment_method", SqlDbType.NVarChar).Value = payment_method;

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
    }
}
