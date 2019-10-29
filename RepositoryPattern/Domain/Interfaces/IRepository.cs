using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryPattern.Domain.Interfaces
{
    public interface IRepository<T>: IUnitOfWork where T : class
    {
        public void Save(T entity);
        public void Update(T entity);
        public void Delete(T entity);
    }
}
