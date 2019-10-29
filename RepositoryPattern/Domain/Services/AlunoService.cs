using RepositoryPattern.Domain.Common.Exceptions;
using RepositoryPattern.Domain.Entities;
using RepositoryPattern.Domain.Interfaces;
using RepositoryPattern.Repositories.Infra.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryPattern.Domain.Services
{
   public class AlunoService: IUnitOfWork
    {
        private readonly IAlunoRepository alunoRepository;

        public AlunoService(IAlunoRepository alunoRepository)
        {
            this.alunoRepository = alunoRepository;
        }

        public IEnumerable<Aluno> GetAll()
        {
            return this.alunoRepository.GetAll();
        }

        public Aluno Get(int idAluno)
        {
            var aluno = this.alunoRepository.Get(idAluno);
            if (aluno == null)
                throw new ExceptionWarning("Aluno não localizado");

            return aluno;
        }


        public bool Save(Aluno aluno)
        {
            aluno.Prepare();
            if (aluno.Validate())
            {
                this.alunoRepository.Save(aluno); 
            } 
            return true;
        }

        public bool Update(Aluno aluno)
        {
            aluno.Prepare();
            if (aluno.Validate())
            {
                this.alunoRepository.Update(aluno); 
            }
            return true;
        }

        public bool Delete(int alunoId)
        {
            var aluno = this.alunoRepository.Get(alunoId);
            if (aluno == null)
                throw new ExceptionWarning("Aluno não localizado no sistema");

            this.alunoRepository.Delete(aluno);

            return true;
        }

        public void Commit()
        {
            this.alunoRepository.Commit();
        }
    }
}
