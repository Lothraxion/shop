﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.BLL.Exceptions
{
   public class AddingException : Exception
    {
        public AddingException(string message) : base(message)
        {
        }
    }
}
