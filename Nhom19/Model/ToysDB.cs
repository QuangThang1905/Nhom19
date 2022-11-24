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
    public class ToysDB
    {
        public static int updatePrice(int toy_id, double price)
        {
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection("data source=localhost; database=" + ConnectionP.database + ";User ID = " + ConnectionP.user_id + "; Password = " + ConnectionP.pass);
                conn.Open();

                SqlCommand cm = new SqlCommand();
                cm.CommandText = "UpdatePrice";
                cm.CommandType = CommandType.StoredProcedure;
                cm.Connection = conn;

                cm.Parameters.Add("@toy_id", SqlDbType.Int).Value = toy_id;
                cm.Parameters.Add("@price", SqlDbType.Float).Value = price;

                return cm.ExecuteNonQuery();
            }
            catch (Exception)
            {
                return 0;
            }
            finally
            {
                conn.Close();
            }
        }
        public static int addToy(String toy_name, String category, String description, Double price, String image)
        {
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection("data source=localhost; database=" + ConnectionP.database + ";User ID = " + ConnectionP.user_id + "; Password = " + ConnectionP.pass);
                conn.Open();

                SqlCommand cm = new SqlCommand();
                cm.CommandText = "AddToys";
                cm.CommandType = CommandType.StoredProcedure;
                cm.Connection = conn;

                cm.Parameters.Add("@toy_name", SqlDbType.NVarChar).Value = toy_name;
                cm.Parameters.Add("@category", SqlDbType.NVarChar).Value = category;
                cm.Parameters.Add("@description", SqlDbType.NVarChar).Value = description;
                cm.Parameters.Add("@price", SqlDbType.Float).Value = price;
                cm.Parameters.Add("@image", SqlDbType.NVarChar).Value = image;

                return cm.ExecuteNonQuery();
            }
            catch (Exception)
            {
                return 0;
            }
            finally
            {
                conn.Close();
            }
        }
        public static int delToy(int toy_id)
        {
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection("data source=localhost; database=" + ConnectionP.database + ";User ID = " + ConnectionP.user_id + "; Password = " + ConnectionP.pass);
                conn.Open();

                SqlCommand cm = new SqlCommand();
                cm.CommandText = "DelToy";
                cm.CommandType = CommandType.StoredProcedure;
                cm.Connection = conn;

                cm.Parameters.Add("@toy_id", SqlDbType.NVarChar).Value = toy_id;


                return cm.ExecuteNonQuery();
            }
            catch (Exception)
            {
                return 0;
            }
            finally
            {
                conn.Close();
            }
        }
        public static List<Toys> allToys()
        {
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection("data source=localhost; database=" + ConnectionP.database + ";User ID = " + ConnectionP.user_id + "; Password = " + ConnectionP.pass);
                conn.Open();

                SqlCommand cm = new SqlCommand();
                cm.CommandText = "AllToysAdmin";
                cm.CommandType = CommandType.StoredProcedure;
                cm.Connection = conn;

                //cm.Parameters.Add("@user_id", SqlDbType.NVarChar).Value = user_id;

                List<Toys> toys = new List<Toys>();
                SqlDataReader sdr = cm.ExecuteReader();
                while (sdr.Read())
                {
                    Toys toy = new Toys();
                    toy.Toy_id = Convert.ToInt32(sdr["toy_id"]);
                    toy.Toy_name = Convert.ToString(sdr["toy_name"]);
                    toy.Category = Convert.ToString(sdr["category"]);
                    toy.Desscription = Convert.ToString(sdr["description"]);
                    toy.Price = Convert.ToDouble(sdr["price"]);
                    toy.Image = Convert.ToString(sdr["image"]);

                    toys.Add(toy);
                }

                return toys;
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
        public static List<Toys> random6toys()
        {
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection("data source=localhost; database=" + ConnectionP.database + ";User ID = " + ConnectionP.user_id + "; Password = " + ConnectionP.pass);
                conn.Open();

                SqlCommand cm = new SqlCommand();
                cm.CommandText = "Random6Toys_Proc";
                cm.CommandType = CommandType.StoredProcedure;
                cm.Connection = conn;

                //cm.Parameters.Add("@user_id", SqlDbType.NVarChar).Value = user_id;

                List<Toys> toys = new List<Toys>();
                SqlDataReader sdr = cm.ExecuteReader();
                while (sdr.Read())
                {
                    Toys toy = new Toys();
                    toy.Toy_id = Convert.ToInt32(sdr["toy_id"]);
                    toy.Toy_name = Convert.ToString(sdr["toy_name"]);
                    toy.Price = Convert.ToDouble(sdr["price"]);
                    toy.Image = Convert.ToString(sdr["image"]);

                    toys.Add(toy);
                }

                return toys;
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
        public static Toys getToy(int toy_id)
        {
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection("data source=localhost; database=" + ConnectionP.database + ";User ID = " + ConnectionP.user_id + "; Password = " + ConnectionP.pass);
                conn.Open();

                SqlCommand cm = new SqlCommand();
                cm.CommandText = "GetToy";
                cm.CommandType = CommandType.StoredProcedure;
                cm.Connection = conn;

                cm.Parameters.Add("@toy_id", SqlDbType.Int).Value = toy_id;

                Toys toy = new Toys();
                SqlDataReader sdr = cm.ExecuteReader();
                while (sdr.Read())
                {
                    toy.Image = Convert.ToString(sdr["image"]);
                    toy.Toy_id = Convert.ToInt32(sdr["toy_id"]);
                    toy.Toy_name = Convert.ToString(sdr["toy_name"]);
                    toy.Category = Convert.ToString(sdr["category"]);
                    toy.Price = Convert.ToDouble(sdr["price"]);
                    toy.Desscription = Convert.ToString(sdr["description"]);
                }

                return toy;
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
        public static Toys findToy(String tukhoa)
        {
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection("data source=localhost; database=" + ConnectionP.database + ";User ID = " + ConnectionP.user_id + "; Password = " + ConnectionP.pass);
                conn.Open();

                SqlCommand cm = new SqlCommand();
                cm.CommandText = "FindToy";
                cm.CommandType = CommandType.StoredProcedure;
                cm.Connection = conn;

                cm.Parameters.Add("@tukhoa", SqlDbType.NVarChar).Value = tukhoa;

                Toys toy = new Toys();
                SqlDataReader sdr = cm.ExecuteReader();
                while (sdr.Read())
                {
                    toy.Toy_id = Convert.ToInt32(sdr["toy_id"]);
                    toy.Toy_name = Convert.ToString(sdr["toy_name"]);
                    toy.Price = Convert.ToDouble(sdr["price"]);
                    toy.Image = Convert.ToString(sdr["image"]);
                }

                return toy;
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
