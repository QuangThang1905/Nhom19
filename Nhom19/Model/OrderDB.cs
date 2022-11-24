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
    public class OrderDB
    {
        public static int addOrder(String firstname, String lastname, String phone, String email, String address, String order_note)
        {
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection("data source=localhost; database=" + ConnectionP.database + ";User ID = " + ConnectionP.user_id + "; Password = " + ConnectionP.pass);
                conn.Open();

                SqlCommand cm = new SqlCommand();
                cm.CommandText = "AddOrder";
                cm.CommandType = CommandType.StoredProcedure;
                cm.Connection = conn;

                cm.Parameters.Add("@first_name", SqlDbType.NVarChar).Value = firstname;
                cm.Parameters.Add("@last_name", SqlDbType.NVarChar).Value = lastname;
                cm.Parameters.Add("@phone", SqlDbType.NVarChar).Value = phone;
                cm.Parameters.Add("@email", SqlDbType.NVarChar).Value = email;
                cm.Parameters.Add("@address", SqlDbType.NVarChar).Value = address;
                cm.Parameters.Add("@order_note", SqlDbType.NVarChar).Value = order_note;

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
        public static List<Order> myOrder()
        {
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection("data source=localhost; database=" + ConnectionP.database + ";User ID = " + ConnectionP.user_id + "; Password = " + ConnectionP.pass);
                conn.Open();

                SqlCommand cm = new SqlCommand();
                cm.CommandText = "MyOrder_Proc";
                cm.CommandType = CommandType.StoredProcedure;
                cm.Connection = conn;

                //cm.Parameters.Add("@toy_id", SqlDbType.Int).Value = toy_id;

                List<Order> orders = new List<Order>();
                SqlDataReader sdr = cm.ExecuteReader();
                while (sdr.Read())
                {
                    Order order = new Order();
                    order.Order_number = Convert.ToString(sdr["order_number"]);
                    order.Payment = Convert.ToString(sdr["payment"]);
                    order.Firstname = Convert.ToString(sdr["first_name"]);
                    order.Lastname = Convert.ToString(sdr["last_name"]);
                    order.Phone = Convert.ToString(sdr["phone"]);
                    order.Email = Convert.ToString(sdr["email"]);
                    order.Address = Convert.ToString(sdr["address"]);
                    order.Order_note = Convert.ToString(sdr["order_note"]);
                    order.Order_total = Convert.ToDouble(sdr["order_total"]);
                    order.Tax = Convert.ToDouble(sdr["tax"]);
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
        public static List<Order> allOrderAdmin()
        {
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection("data source=localhost; database=" + ConnectionP.database + ";User ID = " + ConnectionP.user_id + "; Password = " + ConnectionP.pass);
                conn.Open();

                SqlCommand cm = new SqlCommand();
                cm.CommandText = "AllOders_Proc";
                cm.CommandType = CommandType.StoredProcedure;
                cm.Connection = conn;

                //cm.Parameters.Add("@toy_id", SqlDbType.Int).Value = toy_id;

                List<Order> orders = new List<Order>();
                SqlDataReader sdr = cm.ExecuteReader();
                while (sdr.Read())
                {
                    Order order = new Order();
                    order.Order_number = Convert.ToString(sdr["order_number"]);
                    order.Payment_method = Convert.ToString(sdr["payment_method"]);
                    order.Firstname = Convert.ToString(sdr["first_name"]);
                    order.Lastname = Convert.ToString(sdr["last_name"]);
                    order.Phone = Convert.ToString(sdr["phone"]);
                    order.Email = Convert.ToString(sdr["email"]);
                    order.Address = Convert.ToString(sdr["address"]);
                    order.Order_note = Convert.ToString(sdr["order_note"]);
                    order.Order_total = Convert.ToDouble(sdr["order_total"]);
                    order.Tax = Convert.ToDouble(sdr["tax"]);


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
        public static List<Order> allOrderAdminToday()
        {
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection("data source=localhost; database=" + ConnectionP.database + ";User ID = " + ConnectionP.user_id + "; Password = " + ConnectionP.pass);
                conn.Open();

                SqlCommand cm = new SqlCommand();
                cm.CommandText = "AllOrdersToday_Proc";
                cm.CommandType = CommandType.StoredProcedure;
                cm.Connection = conn;

                //cm.Parameters.Add("@toy_id", SqlDbType.Int).Value = toy_id;

                List<Order> orders = new List<Order>();
                SqlDataReader sdr = cm.ExecuteReader();
                while (sdr.Read())
                {
                    Order order = new Order();
                    order.Order_number = Convert.ToString(sdr["order_number"]);
                    order.Payment_method = Convert.ToString(sdr["payment_method"]);
                    order.Firstname = Convert.ToString(sdr["first_name"]);
                    order.Lastname = Convert.ToString(sdr["last_name"]);
                    order.Phone = Convert.ToString(sdr["phone"]);
                    order.Email = Convert.ToString(sdr["email"]);
                    order.Address = Convert.ToString(sdr["address"]);
                    order.Order_note = Convert.ToString(sdr["order_note"]);
                    order.Order_total = Convert.ToDouble(sdr["order_total"]);
                    order.Tax = Convert.ToDouble(sdr["tax"]);


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
    }
}
