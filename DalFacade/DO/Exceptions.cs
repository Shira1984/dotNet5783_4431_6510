using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO
{
    public  class NoFind:Exception
    {
      public NoFind(string? message) : base(message) { }
    }
    public class AlredyFind : Exception
    {
        public AlredyFind(string? message) : base(message) { }
    }

}
