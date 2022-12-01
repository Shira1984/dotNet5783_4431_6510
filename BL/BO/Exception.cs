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
        public class NagtiveException : Exception
        {
           public NagtiveException() : base() { }
           public NagtiveException(string? message) : base(message) { }
           public NagtiveException(string message, Exception inner) : base(message, inner) { }
           protected NagtiveException(SerializationInfo info, StreamingContext context) : base(info, context) { }

    }

        [Serializable]
        public class NotWriteException : Exception
        {
           public NotWriteException() : base() { }
           public NotWriteException(string? message) : base(message) { }
           public NotWriteException(string message, Exception inner) : base(message, inner) { }
           protected NotWriteException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }

        [Serializable]
        public class NoFindException : Exception
        {
          public NoFindException() : base() { }
          public NoFindException(string? message) : base(message) { }
          public NoFindException(string message, Exception inner) : base(message, inner) { }
          protected NoFindException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }

    [Serializable]
    public class AlredyFindException : Exception
    {
        public AlredyFindException() : base() { }
        public AlredyFindException(string? message) : base(message) { }
        public AlredyFindException(string message, Exception inner) : base(message, inner) { }
        protected AlredyFindException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
    public class NotGoodValueException : Exception
    {
        public NotGoodValueException() : base() { }
        public NotGoodValueException(string? message) : base(message) { }
        public NotGoodValueException(string message, Exception inner) : base(message, inner) { }
        protected NotGoodValueException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }



}
