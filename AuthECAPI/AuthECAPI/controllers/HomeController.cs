using AuthECAPI.Models;
using AuthECAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace AuthECAPI.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class HomeController : Controller
  {
    private readonly UserService _userService;

    public HomeController(UserService userService)
    {
      _userService = userService;
    }

    [HttpPost("postuser")]
    public IActionResult AddUser([FromBody] RegUsers userRequest)
    {
      try
      {
        _userService.SaveUser(userRequest.Fullname, userRequest.Email, userRequest.Password, userRequest.Confirmpassword);
        return Ok(new
        {
          success = true,
          message = "User created successfully"
        });
      }
      catch (Exception ex)
      {
        return BadRequest(new
        {
          success = false,
          message = $"Error: {ex.Message}"
        });
      }
    }
  }
}
