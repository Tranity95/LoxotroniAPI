using Loxotron;
using LoxotroniAPI.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace LoxotroniAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly User21Context _context;

        public UserController(User21Context context)
        {
            _context = context;
        }
        [HttpGet("GetAllUsers")]
        public async Task<ActionResult<List<UserDTO>>> GetUsers()
        {
            List<UserDTO> users = _context.Users.ToList().Select(s => new UserDTO
            {
                Id = s.Id,
                Login = s.Login,
                Password = s.Password,
                Balance = s.Balance,
                CreatedAt = s.CreatedAt,
                UpdatedAt = s.UpdatedAt
            }).ToList();
            return users;
        }
        [HttpGet("GetUser")]
        public async Task<ActionResult<UserDTO>> GetUser(int id)
        {
            var s = _context.Users.FirstOrDefault(s => s.Id == id);
            if (s == null)
            {
                return NotFound();

            }
            return Ok(new UserDTO
            {
                Id = s.Id,
                Login = s.Login,
                Password = s.Password,
                Balance = s.Balance,
                CreatedAt = s.CreatedAt,
                UpdatedAt = s.UpdatedAt
            });
        }
        [HttpPost("UserLogin")]

        public ActionResult<UserDTO> UserLogin(LoginUser loginUser)
        {

            User user = _context.Users.FirstOrDefault(a => a.Login == loginUser.Login && a.Password == loginUser.Password);
            if (user != null)
            {
                return new UserDTO
                {
                    Id = user.Id,
                    Login = user.Login,
                    Password = user.Password,
                    Balance = user.Balance,
                    CreatedAt = user.CreatedAt,
                    UpdatedAt = user.UpdatedAt
                };
            }
            else
            {
                return BadRequest("нЕПРАВИЛЬНЫЙ лОгин или пароль");
            }

        }
    }
}
