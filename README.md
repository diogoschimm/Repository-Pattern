# Repository-Pattern
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




