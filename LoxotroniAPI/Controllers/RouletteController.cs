using Loxotron;
using LoxotroniAPI.DTO;
using Microsoft.AspNetCore.Authorization;
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

        //[Authorize]
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
        public ActionResult<UserDTO> WheelRoulette(Wheeel wheeel) 
        {
            var data = _context.Users.Find(wheeel.User.Id);
            wheeel.User.Balance = data.Balance - wheeel.Stake;
            Random random = new Random();
            int number = random.Next(1, 17);

            if (wheeel.Thing == "-x0.5")
            {
                wheeel.User.Balance = wheeel.User.Balance + wheeel.Stake * 0.5m;
            }
            else if (wheeel.Thing == "+x1.2")
            {
                wheeel.User.Balance = wheeel.User.Balance + wheeel.Stake * 1.2m;
            }
            else if (wheeel.Thing == "-stake")
            {

            }
            else if (wheeel.Thing == "-x2")
            {
                wheeel.User.Balance = wheeel.User.Balance - wheeel.Stake * 2;
            }
            else if (wheeel.Thing == "+x3")
            {
                wheeel.User.Balance = wheeel.User.Balance + wheeel.Stake * 3;
            }
            data.Balance = wheeel.User.Balance;
            _context.SaveChanges();
            return Ok(wheeel.User);
        }
        

    }
}
