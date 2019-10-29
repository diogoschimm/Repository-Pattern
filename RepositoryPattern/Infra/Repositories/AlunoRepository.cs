using RepositoryPattern.Domain.Entities;
using RepositoryPattern.Domain.Interfaces;
using RepositoryPattern.Infra.Contexto;
using System.Collections.Generic;

namespace RepositoryPattern.Repositories.Infra.Repositories
{
    public class AlunoRepository : Repository<Aluno>, IAlunoRepository
    {
        public AlunoRepository(ModeloContext modeloContext) : base(modeloContext)
        {
        }

        public Aluno Get(int alunoId)
        {
            return this.modeloContext.Aluno.Find(alunoId);
        }

        public IEnumerable<Aluno> GetAll()
        {
            return this.modeloContext.Aluno;
        }
    }
}
