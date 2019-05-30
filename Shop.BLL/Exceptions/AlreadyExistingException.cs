using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.BLL.Exceptions
{
    class AlreadyExistingException: Exception
    {
        public AlreadyExistingException(string message) : base(message)
        {
        }
    }
}
