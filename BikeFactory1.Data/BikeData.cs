
using BikeFactory1.Models;
using BikeFactory1.Models.Enum;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeFactory1.Data
{
    public class BikeData
    {
        public static Bike SearchById(int bikeId, string cnString)
        {
            Bike result = null;
            using (var cn = new SqlConnection(cnString))
            {
                using (var cmd = new SqlCommand("SELECT * FROM Bikes WHERE Id=@Id", cn))
                {
                    cmd.Parameters.Add(new SqlParameter("Id", System.Data.SqlDbType.Int) { Value = bikeId }); 
                    cn.Open();
                    using (var dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            dr.Read();
                            result = new Bike()
                            {
                                Id = Convert.ToInt32(dr["Id"]),
                                Name = Convert.ToString(dr["Name"]),                             
                                SuspensionType = (ESuspensionType)dr["SuspensionType"],
                                TireType = (ETireType)dr["TireType"]
                                
                            };
                        }
                    }
                }
                cn.Close();
            }
            return result;
        }

        public static List<Bike> GetList(string cnString)
        {
            var result = new List<Bike>();

            using (var cn = new SqlConnection(cnString))
            {

                using (var cmd = new SqlCommand("SELECT * FROM Bikes", cn))
                {
                    cn.Open();
                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            result.Add(new Bike()
                            {
                                Id = Convert.ToInt32(dr["Id"]),
                                Name = Convert.ToString(dr["Name"]),
                                SuspensionType = (ESuspensionType)dr["SuspensionType"],
                                TireType = (ETireType)dr["TireType"]
                            });
                        }
                    }
                    cn.Close();
                }
            }
            return result;
        }

        public static void Insert(Bike bike, string cnString)
        {
            using (var cn = new SqlConnection(cnString))
            {
                using (var cmd = new SqlCommand("INSERT INTO Bikes (Name, SuspensionType, TireType ) VALUES (@Name, @SuspensionType, @SuspensionType)", cn))
                {
                    cmd.Parameters.Add(new SqlParameter("Name", System.Data.SqlDbType.VarChar, 50) { Value = bike.Name });
                    cmd.Parameters.Add(new SqlParameter("SuspensionType", System.Data.SqlDbType.Int) { Value = bike.SuspensionType });
                    cmd.Parameters.Add(new SqlParameter("TireType", System.Data.SqlDbType.Int) { Value = bike.SuspensionType });
                  
                    cn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void Update(Bike bike, string cnString)
        {
            using (var cn = new SqlConnection(cnString))
            {
                using (var cmd = new SqlCommand("UPDATE Bikes SET Name=@Name, SuspensionType=@SuspensionType, TireType = @TireType WHERE Id=@Id", cn))
                {
                    cmd.Parameters.Add(new SqlParameter("Id", System.Data.SqlDbType.Int) { Value = bike.Id });
                    cmd.Parameters.Add(new SqlParameter("Name", System.Data.SqlDbType.VarChar, 50) { Value = bike.Name });
                    cmd.Parameters.Add(new SqlParameter("SuspensionType", System.Data.SqlDbType.Int) { Value = bike.SuspensionType });
                    cmd.Parameters.Add(new SqlParameter("TireType", System.Data.SqlDbType.Int) { Value = bike.SuspensionType });
                    cn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void Delete(int bikeId, string cnString)
        {
            using (var cn = new SqlConnection(cnString))
            {
                using (var cmd = new SqlCommand("DELETE Bikes WHERE Id=@Id", cn))
                {
                    cmd.Parameters.Add(new SqlParameter("Id", System.Data.SqlDbType.Int) { Value = bikeId });
                    cn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
