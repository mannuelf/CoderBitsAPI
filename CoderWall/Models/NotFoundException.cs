using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoderWall.Models
{
    public class NotFoundException : System.Exception
    {
        public NotFoundException(string message)
            : base(message)
        {
        }
    }
}