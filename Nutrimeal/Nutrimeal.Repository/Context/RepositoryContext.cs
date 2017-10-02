using Microsoft.EntityFrameworkCore;
using Nutrimeal.Domain.Entities;

namespace Nutrimeal.Repository.Ef.Context
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext()
        {
            // JUST TO BE USED BY THE Webforms project
            //var builder = new DbContextOptionsBuilder<RepositoryContext>();
            //builder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=aspnet-Nutrimeal;MultipleActiveResultSets=true");
        }
        public RepositoryContext(DbContextOptions<RepositoryContext> options)
          : base(options)
        {

        }

       
        public DbSet<Objetivos> Objetivos { get; set; }
        public DbSet<Medidas> Medidas { get; set; }
        public DbSet<PerfilAlimentar> PerfilAlimentar { get; set; }
        public DbSet<Refeicao> Refeicao { get; set; }
        public DbSet<Alimento> Alimento { get; set; }
        public DbSet<QuantidadeAlimentar> QuantidadeAlimentar { get; set; }
        public DbSet<PerfilFisico> PerfilFisico { get; set; }
        public DbSet<Exercicio> Exercicio { get; set; }
        public DbSet<MetaExercicio> MetaExercicio { get; set; }
        public DbSet<Atributo> Atributo { get; set; }
        public DbSet<ExercicioAtributo> ExercicioAtributo { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            // BUILDER - Objetivos
            builder.Entity<Objetivos>().HasKey(s => s.ObjetivosId);
            builder.Entity<Objetivos>().HasIndex(s => s.UserId);

            //Medidas
            builder.Entity<Medidas>().HasKey(s => s.MedidaId);
            builder.Entity<Medidas>().HasIndex(s => s.UserId);

            //Pefil Alimentar
            builder.Entity<PerfilAlimentar>().HasKey(s => s.PerfilAlimentarId);
            builder.Entity<PerfilAlimentar>().HasIndex(s => s.UserId);

            //Refeiçao
            builder.Entity<Refeicao>().HasKey(s => s.RefeicaoId);
            builder.Entity<Refeicao>().HasIndex(s => s.PerfilAlimentarId);


            //Alimento
            builder.Entity<Alimento>().HasKey(s => s.AlimentoId);
            builder.Entity<Alimento>().HasIndex(s => s.Grupo);

            //QuantidadeAlimentar
            builder.Entity<QuantidadeAlimentar>().HasKey(s => s.QuantidadeAlimentarId);
            builder.Entity<QuantidadeAlimentar>().HasIndex(s => s.RefeicaoId);
            builder.Entity<QuantidadeAlimentar>().HasIndex(s => s.AlimentoId);

            //Refeiçao
            builder.Entity<PerfilFisico>().HasKey(s => s.PerfilFisicoId);
            builder.Entity<PerfilFisico>().HasIndex(s => s.UserId);

            //Exercicio
            builder.Entity<Exercicio>().HasKey(s => s.ExercicioId);
            builder.Entity<Exercicio>().HasIndex(s => s.Nome);

            //MetaExercicio
            builder.Entity<MetaExercicio>().HasKey(s => s.MetaExercicioId);
            builder.Entity<MetaExercicio>().HasIndex(s => s.PerfilFisicoId);

            //Atributo
            builder.Entity<Atributo>().HasKey(s => s.AtributoId);
            builder.Entity<Atributo>().HasIndex(s => s.Nome);

            //ExercicioAtributo
            builder.Entity<ExercicioAtributo>().HasKey(s => s.ExercicioAtributoId);
            builder.Entity<ExercicioAtributo>().HasIndex(s => s.MetaExercicioId);
            builder.Entity<ExercicioAtributo>().HasIndex(s => s.AtributoId);



            base.OnModelCreating(builder);
        }
    }
}
