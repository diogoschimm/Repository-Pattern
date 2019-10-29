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

