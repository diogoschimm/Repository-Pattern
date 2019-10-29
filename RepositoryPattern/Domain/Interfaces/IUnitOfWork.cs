using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryPattern.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}
