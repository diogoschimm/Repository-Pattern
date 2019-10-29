using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RepositoryPattern.Domain.Entities;
using RepositoryPattern.Domain.Interfaces;
using RepositoryPattern.Domain.Services;
using RepositoryPattern.Infra.Contexto;
using RepositoryPattern.Repositories.Infra.Repositories;
using System;

namespace RepositoryPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            var scp = GetServiceProvider();
            var service = GetAlunoService(scp);

            while (true)
            { 
                //// Inputs 
                Console.Write("Informe o Id do Cliente: ");
                string id = Console.ReadLine();

                Console.Write("Informe o Nome do Cliente: ");
                string nome = Console.ReadLine();

                Console.Write("Informe o CPF do Cliente: ");
                string CPF = Console.ReadLine();

                Console.Write("Informe a Data de Nascimento do Cliente: ");
                string dataNascimento = Console.ReadLine();

                //// Domain
                var aluno = new Aluno();
                aluno.AlunoId = int.Parse(id);
                aluno.Nome = nome;
                aluno.CPF = CPF;
                aluno.DataNascimento = DateTime.Parse(dataNascimento);

                //// Services
                service.Save(aluno);
                service.Commit();

                Console.WriteLine("Informe X para Sair ou Enter para Continuar.... ");
                if (Console.ReadLine() == "X")
                    break;

                Console.Clear();
            }

            Console.WriteLine("");
            Console.WriteLine("Clientes Cadastrados: ");

            foreach (var item in service.GetAll())
            {
                Console.WriteLine(item.ToString());
            }

            Console.ReadKey();
        }

        public static AlunoService GetAlunoService(ServiceProvider scp)
        {
            return new AlunoService(scp.GetService<IAlunoRepository>());
        }

        private static ServiceProvider GetServiceProvider()
        {
            return new ServiceCollection()
                .AddSingleton<IAlunoRepository, AlunoRepository>()
                .AddDbContext<ModeloContext>(opt => opt.UseInMemoryDatabase(Guid.NewGuid().ToString()))
                .BuildServiceProvider();
        }
    }
}
