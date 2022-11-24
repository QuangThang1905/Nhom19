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
    public class VariationDB
    {
        public static int updateStock(String variation_id, int variation_stock)
        {
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection("data source=localhost; database=" + ConnectionP.database + ";User ID = " + ConnectionP.user_id + "; Password = " + ConnectionP.pass);
                conn.Open();

                SqlCommand cm = new SqlCommand();
                cm.CommandText = "UpdateStock";
                cm.CommandType = CommandType.StoredProcedure;
                cm.Connection = conn;

                cm.Parameters.Add("@variation_id", SqlDbType.NVarChar).Value = variation_id;
                cm.Parameters.Add("@variation_stock", SqlDbType.Int).Value = variation_stock;

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
        public static int addVariation(int toy_id, String color, String size, int variation_stock)
        {
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection("data source=localhost; database=" + ConnectionP.database + ";User ID = " + ConnectionP.user_id + "; Password = " + ConnectionP.pass);
                conn.Open();

                SqlCommand cm = new SqlCommand();
                cm.CommandText = "AddVariations";
                cm.CommandType = CommandType.StoredProcedure;
                cm.Connection = conn;

                cm.Parameters.Add("@toy_id", SqlDbType.Int).Value = toy_id;
                cm.Parameters.Add("@color", SqlDbType.NVarChar).Value = color;
                cm.Parameters.Add("@size", SqlDbType.NVarChar).Value = size;
                cm.Parameters.Add("@variation_stock", SqlDbType.Int).Value = variation_stock;

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
        public static Variation getVariation(String variation_id)
        {
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection("data source=localhost; database="+ConnectionP.database+";User ID = " + ConnectionP.user_id + "; Password = " + ConnectionP.pass);
                conn.Open();

                SqlCommand cm = new SqlCommand();
                cm.CommandText = "GetVariation";
                cm.CommandType = CommandType.StoredProcedure;
                cm.Connection = conn;

                cm.Parameters.Add("@variation_id", SqlDbType.NVarChar).Value = variation_id;

                Variation variation = new Variation();
                SqlDataReader sdr = cm.ExecuteReader();
                while (sdr.Read())
                {
                    variation.Variation_id = Convert.ToString(sdr["variation_id"]);
                    variation.Product = Convert.ToInt32(sdr["product"]);
                    variation.Color = Convert.ToString(sdr["color"]);
                    variation.Size = Convert.ToString(sdr["size"]);
                }

                return variation;
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
        public static List<Variation> getVariations(int toy_id)
        {
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection("data source=localhost; database=" + ConnectionP.database + ";User ID = " + ConnectionP.user_id + "; Password = " + ConnectionP.pass);
                conn.Open();

                SqlCommand cm = new SqlCommand();
                cm.CommandText = "GetVariations";
                cm.CommandType = CommandType.StoredProcedure;
                cm.Connection = conn;

                cm.Parameters.Add("@toy_id", SqlDbType.Int).Value = toy_id;

                List<Variation> variations = new List<Variation>();
                SqlDataReader sdr = cm.ExecuteReader();
                while (sdr.Read())
                {
                    Variation variation = new Variation();
                    variation.Variation_id = Convert.ToString(sdr["variation_id"]);
                    variation.Product = Convert.ToInt32(sdr["product"]);
                    variation.Color = Convert.ToString(sdr["color"]);
                    variation.Size = Convert.ToString(sdr["size"]);

                    variations.Add(variation);
                }

                return variations;
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
        public static bool isSoldOut(String variation_id)
        {
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection("data source=localhost; database=Hai;User ID = " + ConnectionP.user_id + "; Password = " + ConnectionP.pass);
                conn.Open();

                SqlCommand cm = new SqlCommand();
                cm.CommandText = "IsSoldOut_Proc";
                cm.CommandType = CommandType.StoredProcedure;
                cm.Connection = conn;

                cm.Parameters.Add("@variation_id", SqlDbType.NVarChar).Value = variation_id;

                return (bool)cm.ExecuteScalar();
            }
            catch (Exception)
            {
                return true;
            }
            finally
            {
                conn.Close();
            }
        }
        public static List<Variation> allVariationsAdmin()
        {
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection("data source=localhost; database=" + ConnectionP.database + ";User ID = " + ConnectionP.user_id + "; Password = " + ConnectionP.pass);
                conn.Open();

                SqlCommand cm = new SqlCommand();
                cm.CommandText = "AllVariationsAdmin";
                cm.CommandType = CommandType.StoredProcedure;
                cm.Connection = conn;

                //cm.Parameters.Add("@toy_id", SqlDbType.Int).Value = toy_id;

                List<Variation> variations = new List<Variation>();
                SqlDataReader sdr = cm.ExecuteReader();
                while (sdr.Read())
                {
                    Variation variation = new Variation();
                    variation.Variation_id = Convert.ToString(sdr["variation_id"]);
                    variation.Toy_name = Convert.ToString(sdr["toy_name"]);
                    variation.Color = Convert.ToString(sdr["color"]);
                    variation.Size = Convert.ToString(sdr["size"]);
                    variation.Variation_stock = Convert.ToInt32(sdr["variation_stock"]);

                    variations.Add(variation);
                }

                return variations;
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
