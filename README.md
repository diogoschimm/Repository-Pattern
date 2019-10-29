# Repository Pattern & Unit Of Work
Exemplo de Repository Pattern para Cadastro de Aluno

## Padrões utilizados

### Unit Of Work

Para a unidade de trabalho foi adicionado a Interface IUnitOfWork contendo um único método.

```c#
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
```

A classe de serviço do domínio implementa o contrato do IUnitOfWork

```C#
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

            ...
 
            public void Commit()
            {
                this.alunoRepository.Commit();
            }
        }
    }

```

## Repository Pattern (Repository Base)

Foi adicionado uma Interface Generica para Trabalhar os Métodos Save, Update e Delete.
Os Métodos para Localizar um Registro serão responsábilidades das Interfaces dos repositórios das entidades e não do Repositorio Base.

```c#
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
```

O Repository Base Implementa a Interface IUnitOfWork isso irá fazer com que cada repositório possua o Método Commit() responsável por Confirmar a Transação de uma única vez. Isso também irá obrigar os repositorios a implementarem o padrão Unit Of Work.

E a implementação concreta para a Interface IRepository<T>

```c#
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

``` 

## Repository Pattern (Repository Especializado)

Para cada entidade será criado um Repositório especializado, com os métodos necessários para o contexto da entidade.

Cada entidade irá possuir uma interface do repositório

```c#
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

```

E a implementação concreta da Interface

```c#
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
```




