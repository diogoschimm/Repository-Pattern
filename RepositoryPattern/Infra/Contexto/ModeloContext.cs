using Microsoft.EntityFrameworkCore;
using RepositoryPattern.Domain.Entities;

namespace RepositoryPattern.Infra.Contexto
{
    public class ModeloContext: DbContext
    {
        public ModeloContext(DbContextOptions<ModeloContext> options): base(options)
        {

        }
        public DbSet<Aluno> Aluno { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
