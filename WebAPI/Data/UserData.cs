using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebAPI.Models;

namespace WebAPI.Data
{
    public class UserData
    {

        public static bool Add(Users users)
        {
            using (SqlConnection connection = new SqlConnection(
            Connection.connectionString))
            {
                SqlCommand command = new SqlCommand("[General].[SP_Add_User]", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Identification", users.Identification);
                command.Parameters.AddWithValue("@Name", users.Name);
                command.Parameters.AddWithValue("@Phone", users.Phone);
                command.Parameters.AddWithValue("@Email", users.Email);
                command.Parameters.AddWithValue("@City", users.City);
                command.Parameters.AddWithValue("@InsertDate", users.InsertDate);
                try
                {
                    command.Connection.Open();
                    //command.ExecuteNonQuery();
                    return true;
                }
                catch (Exception)
                {

                    return false;
                }
            }
        }

        public static bool Edit(Users users)
        {
            using (SqlConnection connection = new SqlConnection(
            Connection.connectionString))
            {
                SqlCommand command = new SqlCommand("[General].[SP_Edit_User]", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@pIdUser", users.IdUser);
                command.Parameters.AddWithValue("@pIdentification", users.Identification);
                command.Parameters.AddWithValue("@pName", users.Name);
                command.Parameters.AddWithValue("@pPhone", users.Phone);
                command.Parameters.AddWithValue("@pEmail", users.Email);
                command.Parameters.AddWithValue("@pCity", users.City);
              
                try
                {
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                    return true;
                }
                catch (Exception e)
                {

                    return false;
                }
            }
        }

        public static List<Users> GetList()
        {
            List<Users> listUsers = new List<Users>();
            using (SqlConnection connection = new SqlConnection(
            Connection.connectionString))
            {
                SqlCommand command = new SqlCommand("[General].[SP_Get_Users]", connection);
                 command.CommandType = CommandType.StoredProcedure;

                try
                {
                    command.Connection.Open();
                    ////command.ExecuteNonQuery();

                    using (SqlDataReader dr = command.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            listUsers.Add(new Users()
                            {
                                IdUser = Convert.ToInt32(dr["IdUser"]),
                                Identification = dr["Identification"].ToString(),
                                Name = dr["Name"].ToString(),
                                Phone = dr["Phone"].ToString(),
                                Email = dr["Email"].ToString(),
                                City = dr["City"].ToString(),
                                InsertDate = Convert.ToDateTime(dr["InsertDate"].ToString())

                            });
                           
                        }
                    }
                    return listUsers;
                }
                catch (Exception e)
                {

                   return  listUsers;
                }

            }

      
        }

        public static Users Get(int IdUser)
        {
            Users user = new Users();
            using (SqlConnection connection = new SqlConnection(
            Connection.connectionString))
            {
                SqlCommand command = new SqlCommand("[General].[SP_Get_User]", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@pIdUser", IdUser);


                try
                {
                    command.Connection.Open();
                    //command.ExecuteNonQuery();

                    using (SqlDataReader dr = command.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            user = new Users() {
                                IdUser = Convert.ToInt32(dr["IdUser"]),
                                Identification = dr["Identification"].ToString(),
                                Name = dr["Name"].ToString(),
                                Phone = dr["Phone"].ToString(),
                                Email = dr["Email"].ToString(),
                                City = dr["City"].ToString(),
                                InsertDate = Convert.ToDateTime(dr["InsertDate"].ToString())
                            };
                         
                        }
                    }
                    return user;

                }
                catch (Exception)
                {

                    return user;
                }
            }
        }

        public static bool Delete(int IdUser)
        {
            using (SqlConnection connection = new SqlConnection(Connection.connectionString))
            {
                SqlCommand command = new SqlCommand("[General].[SP_Delete_User]", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@pIdUser", IdUser);

                try
                {
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                    return true;
                }
                catch (Exception)
                {

                    return false;
                }
            }

        }
    }
}