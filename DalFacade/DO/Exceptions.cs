using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO
{
    public  class DlNoFindException : Exception
    {
      public DlNoFindException(string? message) : base(message) { }
    }
    public class DlAlredyFindException : Exception
    {
        public DlAlredyFindException(string? message) : base(message) { }
    }

    public class DlNagtiveException : Exception
    {
        public DlNagtiveException(string? message) : base(message) { }
    }
    public class DlNotWriteException : Exception
    {
        public DlNotWriteException(string? message) : base(message) { }
    }
    public class DlNotGoodValueException : Exception
    {
        public DlNotGoodValueException(string? message) : base(message) { }
    }
}
