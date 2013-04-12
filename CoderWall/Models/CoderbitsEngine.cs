using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoderWall.Models
{
    public class CoderbitsEngine
    {
        private CoderbitsAPI _coderbits;

        public CoderbitsEngine(string userName)
        {
            _coderbits = new CoderbitsAPI(userName);
        }

        public CoderbitsModel CoderbitsInfo()
        {
            return _coderbits.GetInfo();
        }
    }
}