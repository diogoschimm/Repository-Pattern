using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryPattern.Domain.Common.Exceptions
{
    public class ExceptionWarning : Exception
    {
        public string Codigo { get { return "3"; } }

        public ExceptionWarning(string mensagem) : base(mensagem)
        {
        }
    }
}
