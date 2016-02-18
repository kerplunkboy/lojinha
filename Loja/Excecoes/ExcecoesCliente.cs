using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja.Excecoes
{

    [Serializable]
    public class ValidacaoException : Exception
    {
        public ValidacaoException() { }
        public ValidacaoException(string message) : base(message) { }
        public ValidacaoException(string message, Exception inner) : base(message, inner) { }
        protected ValidacaoException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }
    [Serializable]
    public class NotCrudException : Exception
    {
        public NotCrudException() { }
        public NotCrudException(string message) : base(message) { }
        public NotCrudException(string message, Exception inner) : base(message, inner) { }
        protected NotCrudException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }
}
