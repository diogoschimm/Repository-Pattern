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

