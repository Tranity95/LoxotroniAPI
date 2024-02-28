using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loxotron
{
    public static class DB
    {
        private static User21Context _context;
        public static User21Context Instance
        {
            get
            {
                if (_context == null)
                    _context = new User21Context();
                return _context;
            }
        }
    }
}
