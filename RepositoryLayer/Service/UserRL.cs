using CommonLayer.Model.UserModel;
using Microsoft.Extensions.Configuration;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace RepositoryLayer.Service
{
    public class UserRL : IUserRL
    {
        private readonly IConfiguration Configuration;
        private readonly IConfiguration _Appsetting;
        public UserRL(IConfiguration Configuration, IConfiguration _Appsetting)
        {
            this.Configuration = Configuration;
            this._Appsetting = _Appsetting;
        }
        public static string connectionstring = "Data Source=(localdb)\\ProjectModels;Initial Catalog=AddressBookDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        private readonly SqlConnection connection = new SqlConnection(connectionstring);

        public UserRegistrationModel UserRegistration(UserRegistrationModel registrationModel)
        {
            try
            {
                using (connection)
                {
                    SqlCommand command = new SqlCommand("spUserRegistration", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@FirstName", registrationModel.FirstName);
                    command.Parameters.AddWithValue("@LastName", registrationModel.LastName);
                    command.Parameters.AddWithValue("@Address", registrationModel.Address);
                    command.Parameters.AddWithValue("@City", registrationModel.City);
                    command.Parameters.AddWithValue("@State", registrationModel.State);
                    command.Parameters.AddWithValue("@Zip", registrationModel.Zip);
                    command.Parameters.AddWithValue("@Phone", registrationModel.Phone);
                    command.Parameters.AddWithValue("@Email", registrationModel.Email);

                    connection.Open();
                    int result = command.ExecuteNonQuery();
                    connection.Close();
                    if (result != 0)
                    {
                        return registrationModel;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<UserRetrieveModel> GetAllAddress()
        {
            List<UserRetrieveModel> addressList = new List<UserRetrieveModel>();
            SqlConnection connection = new SqlConnection(connectionstring);
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("spRetrieveAddress", connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    UserRetrieveModel addressModel = new UserRetrieveModel();
                    addressModel.FirstName = reader["FirstName"] == DBNull.Value ? default : reader.GetString("FirstName");
                    addressModel.LastName = reader["LastName"] == DBNull.Value ? default : reader.GetString("LastName");
                    addressModel.Address = reader["Address"] == DBNull.Value ? default : reader.GetString("Address");
                    addressModel.City = reader["City"] == DBNull.Value ? default : reader.GetString("City");
                    addressModel.State = reader["State"] == DBNull.Value ? default : reader.GetString("State");
                    addressModel.Zip = reader["Zip"] == DBNull.Value ? default : reader.GetInt32("Zip");
                    addressModel.Phone = reader["Phone"] == DBNull.Value ? default : reader.GetInt64("Phone");
                    addressModel.Email = reader["Email"] == DBNull.Value ? default : reader.GetString("Email");
                    addressList.Add(addressModel);
                };
                return addressList;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
