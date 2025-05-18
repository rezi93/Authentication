using System;
using System.Data;
using System.Data.SqlClient;

namespace AuthECAPI.Repositories
{
  public class UserRepository
  {
    private readonly string _connectionString;

    public UserRepository(string connectionString)
    {
      _connectionString = connectionString;
    }

    public void AddUser(string fullname, string email, string password, string confirmpassword)
    {
      using (SqlConnection connection = new SqlConnection(_connectionString))
      {
        SqlCommand command = new SqlCommand("INSERT INTO Users (Fullname, Email, Password, ConfirmPassword) VALUES (@Fullname, @Email, @Password, @ConfirmPassword)", connection);
        command.Parameters.AddWithValue("@Fullname", fullname);
        command.Parameters.AddWithValue("@Email", email);
        command.Parameters.AddWithValue("@Password", password);
        command.Parameters.AddWithValue("@ConfirmPassword", confirmpassword);
        connection.Open();
        command.ExecuteNonQuery();
      }
    }
  }
}
