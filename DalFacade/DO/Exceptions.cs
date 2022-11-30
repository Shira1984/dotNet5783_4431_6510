using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO
{
    public  class NoFindException : Exception
    {
      public NoFindException(string? message) : base(message) { }
    }
    public class AlredyFindException : Exception
    {
        public AlredyFindException(string? message) : base(message) { }
    }

}
