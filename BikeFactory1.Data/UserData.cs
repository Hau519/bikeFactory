
using BikeFactory1.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeFactory1.Data
{
    public class UserData
    {
        public static bool UserAndPasswordAreValid(User user, string cnString)
        {
            bool result = false;
            using (var cn = new SqlConnection(cnString))
            {
                using (var cmd = new SqlCommand("SELECT * FROM Users WHERE Email=@Email AND Password=@Password", cn))
                {
                    cmd.Parameters.Add(new SqlParameter("Email", System.Data.SqlDbType.VarChar, 50) { Value = user.Email });
                    cmd.Parameters.Add(new SqlParameter("Password", System.Data.SqlDbType.VarChar, 50) { Value = user.Password });
                    if (cn.State != System.Data.ConnectionState.Open)
                        cn.Open();
                    using (var dr = cmd.ExecuteReader())
                    {
                        result = dr.HasRows;
                    }
                }
            }
            return result;
        }

        public static bool UserIsUnique(string email, string cnString)
        {
            bool result = false;
            using (var cn = new SqlConnection(cnString))
            {
                using (var cmd = new SqlCommand("SELECT COUNT(Email) FROM Users WHERE Email=@Email", cn))
                {
                    cmd.Parameters.Add(new SqlParameter("Email", System.Data.SqlDbType.VarChar, 50) { Value = email });
                    cn.Open();
                    var count = (int)cmd.ExecuteScalar();
                    result = count == 0;
                }
            }
            return result;
        }

        public static void Insert(User user, string cnString)
        {
            using (var cn = new SqlConnection(cnString))
            {
                using (var cmd = new SqlCommand("INSERT INTO Users (Email, Password) VALUES (@Email, @Password)", cn))
                {
                    cmd.Parameters.Add(new SqlParameter("Email", System.Data.SqlDbType.VarChar, 50) { Value = user.Email.Trim() });
                    cmd.Parameters.Add(new SqlParameter("Password", System.Data.SqlDbType.VarChar, 50) { Value = user.Password });
                    cn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
