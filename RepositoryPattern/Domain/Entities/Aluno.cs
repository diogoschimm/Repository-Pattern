using RepositoryPattern.Domain.Common.Exceptions;
using RepositoryPattern.Domain.Common.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryPattern.Domain.Entities
{
    public class Aluno
    {
        public int AlunoId { get; set; }
        public String Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string CPF { get; set; }

        public void Prepare()
        {
            this.CPF = CPFServices.Prepare(this.CPF);
        }

        public bool Validate()
        {
            if (!CPFServices.IsValid(this.CPF))
                throw new ExceptionWarning("CPF Inválido");

            if (String.IsNullOrEmpty(this.Nome))
                throw new ExceptionWarning("Nome do Aluno é inválido");

            return true;
        }

        public override string ToString()
        {
            return this.AlunoId + " - (" + this.CPF + ") " + this.Nome;
        }
    }
}
