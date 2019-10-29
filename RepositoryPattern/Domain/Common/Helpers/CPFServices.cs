using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryPattern.Domain.Common.Helpers
{
   public class CPFServices
    { 
        public static bool IsValid(string cpf)
        {
            return true;
        }
        public static string Prepare(string cpf)
        {
            return cpf;
        }
        public static string Format(string cpf)
        {
            return cpf;
        }
    }
}
