using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nutrimeal.Repository
{
    public class Program
    {
        public static void Main(string[] args)
        {
        }
    }

    public class TemporaryDbContextFactory : IDbContextFactory<Ef.Context.RepositoryContext>
    {
        public Ef.Context.RepositoryContext Create(DbContextFactoryOptions options)
        {
            var builder = new DbContextOptionsBuilder<Ef.Context.RepositoryContext>();
            builder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=aspnet-Nutrimeal-b114d821-d0a0-447f-b9a4-c97aafd46d94;Trusted_Connection=True;MultipleActiveResultSets=true");
            return new Ef.Context.RepositoryContext(builder.Options);
        }

        Ef.Context.RepositoryContext IDbContextFactory<Ef.Context.RepositoryContext>.Create(DbContextFactoryOptions options)
        {
            var builder = new DbContextOptionsBuilder<Ef.Context.RepositoryContext>();
            builder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=aspnet-Nutrimeal-b114d821-d0a0-447f-b9a4-c97aafd46d94;Trusted_Connection=True;MultipleActiveResultSets=true");
            return new Ef.Context.RepositoryContext(builder.Options);
        }
    }
}
