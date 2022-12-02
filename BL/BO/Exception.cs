using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
   
    
        [Serializable]
        public class BlNagtiveException : Exception
        {
           public BlNagtiveException() : base() { }
           public BlNagtiveException(string? message) : base(message) { }
           public BlNagtiveException(string message, Exception inner) : base(message, inner) { }
           protected BlNagtiveException(SerializationInfo info, StreamingContext context) : base(info, context) { }

    }

        [Serializable]
        public class BlNotWriteException : Exception
        {
           public BlNotWriteException() : base() { }
           public BlNotWriteException(string? message) : base(message) { }
           public BlNotWriteException(string message, Exception inner) : base(message, inner) { }
           protected BlNotWriteException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }

        [Serializable]
        public class BlNoFindException : Exception
        {
          public BlNoFindException() : base() { }
          public BlNoFindException(string? message) : base(message) { }
          public BlNoFindException(string message, Exception inner) : base(message, inner) { }
          protected BlNoFindException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }

    [Serializable]
    public class BlAlredyFindException : Exception
    {
        public BlAlredyFindException() : base() { }
        public BlAlredyFindException(string? message) : base(message) { }
        public BlAlredyFindException(string message, Exception inner) : base(message, inner) { }
        protected BlAlredyFindException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
    public class BlNotGoodValueException : Exception
    {
        public BlNotGoodValueException() : base() { }
        public BlNotGoodValueException(string? message) : base(message) { }
        public BlNotGoodValueException(string message, Exception inner) : base(message, inner) { }
        protected BlNotGoodValueException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }



}
