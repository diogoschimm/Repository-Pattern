using RepositoryPattern.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryPattern.Domain.Interfaces
{
    public interface IAlunoRepository : IRepository<Aluno>
    {
        public IEnumerable<Aluno> GetAll();
        public Aluno Get(int alunoId);
    }
}
