using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.DAL
{
    class SingletonContext
    {
        private SingletonContext()
        {

        }
        private static NorthwindDbContext _context;
        public static NorthwindDbContext Context
        {
            get
            {
                if(_context==null)
                {
                    _context = new NorthwindDbContext();
                }
                return _context;
            }
        }
    }
}
