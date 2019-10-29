using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryPattern.Domain.Common.Exceptions
{
    public class ExceptionInfo : Exception
    {
        public string Codigo { get { return "4"; } }

        public ExceptionInfo(string mensagem) : base(mensagem)
        {
        }
    }
}
