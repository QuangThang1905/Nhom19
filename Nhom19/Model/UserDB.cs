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
    public class UserDB
    {
        public static bool isAdmin()
        {
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection("data source=localhost; database=" + ConnectionP.database + ";User ID = " + ConnectionP.user_id + "; Password = " + ConnectionP.pass);
                conn.Open();

                SqlCommand cm = new SqlCommand();
                cm.CommandText = "IsAdmin";
                cm.CommandType = CommandType.StoredProcedure;
                cm.Connection = conn;

                //cm.Parameters.Add("@variation_id", SqlDbType.NVarChar).Value = variation_id;

                bool result = true;
                SqlDataReader sdr = cm.ExecuteReader();
                while (sdr.Read())
                {
                    result = Convert.ToBoolean(sdr["is_admin"]);
                }

                return result;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                conn.Close();
            }
        }
        public static String getCurrentUser()
        {
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection("data source=localhost; database=" + ConnectionP.database + ";User ID = " + ConnectionP.user_id + "; Password = " + ConnectionP.pass);
                conn.Open();

                SqlCommand cm = new SqlCommand();
                cm.CommandText = "GetCurrentUser";
                cm.CommandType = CommandType.StoredProcedure;
                cm.Connection = conn;

               // cm.Parameters.Add("@user_id", SqlDbType.NVarChar).Value = user_id;

                return (String)cm.ExecuteScalar();
            }
            catch (Exception)
            {
                return "";
            }
            finally
            {
                conn.Close();
            }
        }
        public static int registerCustomer(String user_id, String pass, String firstname, String lastname, String email, String phone_number)
        {
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection("data source=localhost; database=" + ConnectionP.database + ";User ID =  bo; Password = 123456");
                conn.Open();

                SqlCommand cm = new SqlCommand();
                cm.CommandText = "RegistCustomer";
                cm.CommandType = CommandType.StoredProcedure;
                cm.Connection = conn;

                cm.Parameters.Add("@user_id", SqlDbType.NVarChar).Value = user_id;
                cm.Parameters.Add("@pass", SqlDbType.NVarChar).Value = pass;
                cm.Parameters.Add("@firstname", SqlDbType.NVarChar).Value = firstname;
                cm.Parameters.Add("@lastname", SqlDbType.NVarChar).Value = lastname;
                cm.Parameters.Add("@email", SqlDbType.NVarChar).Value = email;
                cm.Parameters.Add("@phone_number", SqlDbType.NVarChar).Value = phone_number;

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
        public static User getUser()
        {
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection("data source=localhost; database=" + ConnectionP.database + ";User ID = " + ConnectionP.user_id + "; Password = " + ConnectionP.pass);
                conn.Open();

                SqlCommand cm = new SqlCommand();
                cm.CommandText = "MyUser";
                cm.CommandType = CommandType.StoredProcedure;
                cm.Connection = conn;

                //cm.Parameters.Add("@variation_id", SqlDbType.NVarChar).Value = variation_id;

                User user = new User();
                SqlDataReader sdr = cm.ExecuteReader();
                while (sdr.Read())
                {
                    user.User_id = Convert.ToString(sdr["user_id"]);
                    user.Firstname = Convert.ToString(sdr["firstname"]);
                    user.Lastname = Convert.ToString(sdr["lastname"]);
                    user.Email = Convert.ToString(sdr["email"]);
                    user.Phone_number = Convert.ToString(sdr["phone_number"]);
                }

                return user;
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
        public static int editProfile(String firstname, String lastname, String phone_number, String email)
        {
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection("data source=localhost; database=" + ConnectionP.database + ";User ID = " + ConnectionP.user_id + "; Password = " + ConnectionP.pass);
                conn.Open();

                SqlCommand cm = new SqlCommand();
                cm.CommandText = "EditProfile";
                cm.CommandType = CommandType.StoredProcedure;
                cm.Connection = conn;

                cm.Parameters.Add("@first_name", SqlDbType.NVarChar).Value = firstname;
                cm.Parameters.Add("@last_name", SqlDbType.NVarChar).Value = lastname;
                cm.Parameters.Add("@email", SqlDbType.NVarChar).Value = email;
                cm.Parameters.Add("@phone_number", SqlDbType.NVarChar).Value = phone_number;

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
