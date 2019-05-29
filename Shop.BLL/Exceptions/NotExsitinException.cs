using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.BLL.Exceptions
{
    class NotExsitinException : Exception
    {
        public NotExsitinException(string message) : base(message)
        {
        }
    }
}
