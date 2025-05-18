using AuthECAPI.Models;
using AuthECAPI.Repositories;

namespace AuthECAPI.Services
{
  public class UserService
  {
    private readonly UserRepository _userRepository;

    public UserService(string connectionString)
    {
      _userRepository = new UserRepository(connectionString);
    }

    public void SaveUser(string fullname, string email, string password, string confirmpassword)
    {
      _userRepository.AddUser(fullname, email, password, confirmpassword);
    }
  }
}
