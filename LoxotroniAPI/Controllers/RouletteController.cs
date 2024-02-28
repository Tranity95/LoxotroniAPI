using Loxotron;
using LoxotroniAPI.DTO;
using Microsoft.AspNetCore.Components.Web.Virtualization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;

namespace LoxotroniAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RouletteController : ControllerBase
    {
        private readonly User21Context _context;

        public RouletteController(User21Context context)
        {
            _context = context;
        }

        [HttpPut("Classic")]
        public ActionResult<UserDTO> ClassicRoulette(string color, decimal stake, UserDTO user)
        {
            var data = _context.Users.Find(user.Id);
            user.Balance = data.Balance - stake;
            user.Win = false;
            Random random = new Random();
            int number = random.Next(1, 101); // Генерируем случайное число от  1 до  100

            if (number <= 49 && color == "Red")
            {
                user.Win = true;
                user.Balance = user.Balance + stake * 1.2m;
            }
            else if (number <= 99 && number > 49 && color == "Black")
            {

                user.Win = true;
                user.Balance = user.Balance + stake * 1.2m;

            }
            else if (number > 99 && color == "Green")
            {
                user.Win = true;
                user.Balance = user.Balance + stake * 2;
            }

            data.Balance = user.Balance;
            _context.SaveChanges();
            return Ok(user);
        }
        
        [HttpPut("Wheel")]
        public ActionResult<UserDTO> WheelRoulette(decimal stake, UserDTO user) 
        {
            var data = _context.Users.Find(user.Id);
            user.Balance = data.Balance - stake;
            Random random = new Random();
            int number = random.Next(1, 17);

            if (number <= 6)
            {
                user.Balance = user.Balance + stake * 0.5m;
            }
            else if (number > 6 && number <= 10)
            {
                user.Balance = user.Balance + stake * 1.2m;
            }
            else if (number >10 && number <= 14)
            {

            }
            else if (number == 15)
            {
                user.Balance = user.Balance - stake * 2;
            }
            else if (number == 16)
            {
                user.Balance = user.Balance + stake * 3;
            }
            data.Balance = user.Balance;
            _context.SaveChanges();
            return Ok(user);
        }
        

    }
}
