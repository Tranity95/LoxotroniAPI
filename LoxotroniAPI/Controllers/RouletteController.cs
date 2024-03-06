using Loxotron;
using LoxotroniAPI.DTO;
using Microsoft.AspNetCore.Components.Web.Virtualization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;

namespace LoxotroniAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RouletteController : ControllerBase
    {
        private readonly User21Context _context;

        public RouletteController(User21Context context)
        {
            _context = context;
        }

        [HttpPut("Classic")]
        public ActionResult<UserDTO> ClassicRoulette(ClassicWheel classicWheel)
        {
            var data = _context.Users.Find(classicWheel.User.Id);
            classicWheel.User.Balance = data.Balance - classicWheel.Stake;
            classicWheel.User.Win = false;
            if(classicWheel.WinColor == classicWheel.Color)
            {
                if (classicWheel.WinColor != "Green")
                {
                    classicWheel.User.Win = true;
                    classicWheel.User.Balance = classicWheel.User.Balance + classicWheel.Stake * 1.2m;
                }
                else if (classicWheel.WinColor == "Green")
                {
                    classicWheel.User.Win = true;
                    classicWheel.User.Balance = classicWheel.User.Balance + classicWheel.Stake * 2;
                }
            }
            data.Balance = classicWheel.User.Balance;
            _context.SaveChanges();
            return Ok(classicWheel.User);
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
