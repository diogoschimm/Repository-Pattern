using Microsoft.EntityFrameworkCore;
using RepositoryPattern.Domain.Interfaces;
using RepositoryPattern.Infra.Contexto;

namespace RepositoryPattern.Repositories.Infra.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly ModeloContext modeloContext;

        public Repository(ModeloContext modeloContext)
        {
            this.modeloContext = modeloContext;
        }

        public void Delete(T entity)
        {
            this.modeloContext.Remove(entity); 
        }

        public void Save(T entity)
        {
            this.modeloContext.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            this.modeloContext.Entry(entity).State = EntityState.Modified;
        }

        public void Commit()
        {
            this.modeloContext.SaveChanges();
        }
    }
}
