using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Nutrimeal.Repository.Ef.Context;
using Nutrimeal.Domain.Entities;

namespace Nutrimeal.Repository.Migrations
{
    [DbContext(typeof(RepositoryContext))]
    partial class RepositoryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Nutrimeal.Domain.Entities.Alimento", b =>
                {
                    b.Property<Guid>("AlimentoId")
                        .ValueGeneratedOnAdd();

                    b.Property<float>("Acucar");

                    b.Property<float>("Calorias");

                    b.Property<float>("Carboidrato");

                    b.Property<float>("Colestrol");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("CreatedBy");

                    b.Property<float>("Fibra");

                    b.Property<float>("Gordura");

                    b.Property<int>("Grupo");

                    b.Property<DateTime>("ModifiedAt");

                    b.Property<string>("ModifiedBy");

                    b.Property<string>("Nome");

                    b.Property<float>("Potassio");

                    b.Property<float>("Proteina");

                    b.Property<float>("Sodio");

                    b.HasKey("AlimentoId");

                    b.HasIndex("Grupo");

                    b.ToTable("Alimento");
                });

            modelBuilder.Entity("Nutrimeal.Domain.Entities.Atributo", b =>
                {
                    b.Property<Guid>("AtributoId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("ModifiedAt");

                    b.Property<string>("ModifiedBy");

                    b.Property<string>("Nome");

                    b.HasKey("AtributoId");

                    b.HasIndex("Nome");

                    b.ToTable("Atributo");
                });

            modelBuilder.Entity("Nutrimeal.Domain.Entities.Exercicio", b =>
                {
                    b.Property<Guid>("ExercicioId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("CreatedBy");

                    b.Property<string>("Descricao");

                    b.Property<DateTime>("ModifiedAt");

                    b.Property<string>("ModifiedBy");

                    b.Property<string>("Nome");

                    b.Property<int>("Tipo");

                    b.HasKey("ExercicioId");

                    b.HasIndex("Nome");

                    b.ToTable("Exercicio");
                });

            modelBuilder.Entity("Nutrimeal.Domain.Entities.ExercicioAtributo", b =>
                {
                    b.Property<Guid>("ExercicioAtributoId")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("AtributoId");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("CreatedBy");

                    b.Property<Guid>("MetaExercicioId");

                    b.Property<DateTime>("ModifiedAt");

                    b.Property<string>("ModifiedBy");

                    b.Property<float>("Valor");

                    b.HasKey("ExercicioAtributoId");

                    b.HasIndex("AtributoId");

                    b.HasIndex("MetaExercicioId");

                    b.ToTable("ExercicioAtributo");
                });

            modelBuilder.Entity("Nutrimeal.Domain.Entities.Medidas", b =>
                {
                    b.Property<Guid>("MedidaId")
                        .ValueGeneratedOnAdd();

                    b.Property<float>("Altura");

                    b.Property<float>("Cintura");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("DataMedicao");

                    b.Property<DateTime>("ModifiedAt");

                    b.Property<string>("ModifiedBy");

                    b.Property<float>("Pescoco");

                    b.Property<float>("Peso");

                    b.Property<float>("Quadris");

                    b.Property<string>("UserId");

                    b.HasKey("MedidaId");

                    b.HasIndex("UserId");

                    b.ToTable("Medidas");
                });

            modelBuilder.Entity("Nutrimeal.Domain.Entities.MetaExercicio", b =>
                {
                    b.Property<Guid>("MetaExercicioId")
                        .ValueGeneratedOnAdd();

                    b.Property<float>("Calorias");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("CreatedBy");

                    b.Property<Guid>("ExercicioId");

                    b.Property<DateTime>("ModifiedAt");

                    b.Property<string>("ModifiedBy");

                    b.Property<Guid>("PerfilFisicoId");

                    b.HasKey("MetaExercicioId");

                    b.HasIndex("PerfilFisicoId");

                    b.ToTable("MetaExercicio");
                });

            modelBuilder.Entity("Nutrimeal.Domain.Entities.Objetivos", b =>
                {
                    b.Property<Guid>("ObjetivosId")
                        .ValueGeneratedOnAdd();

                    b.Property<float>("Cintura");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("DataObjetivo");

                    b.Property<DateTime>("ModifiedAt");

                    b.Property<string>("ModifiedBy");

                    b.Property<float>("Pescoco");

                    b.Property<float>("Peso");

                    b.Property<float>("Quadris");

                    b.Property<string>("UserId");

                    b.HasKey("ObjetivosId");

                    b.HasIndex("UserId");

                    b.ToTable("Objetivos");
                });

            modelBuilder.Entity("Nutrimeal.Domain.Entities.PerfilAlimentar", b =>
                {
                    b.Property<Guid>("PerfilAlimentarId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("Data");

                    b.Property<DateTime>("ModifiedAt");

                    b.Property<string>("ModifiedBy");

                    b.Property<string>("Nome");

                    b.Property<string>("UserId");

                    b.HasKey("PerfilAlimentarId");

                    b.HasIndex("UserId");

                    b.ToTable("PerfilAlimentar");
                });

            modelBuilder.Entity("Nutrimeal.Domain.Entities.PerfilFisico", b =>
                {
                    b.Property<Guid>("PerfilFisicoId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("Data");

                    b.Property<DateTime>("ModifiedAt");

                    b.Property<string>("ModifiedBy");

                    b.Property<string>("Nome");

                    b.Property<string>("UserId");

                    b.HasKey("PerfilFisicoId");

                    b.HasIndex("UserId");

                    b.ToTable("PerfilFisico");
                });

            modelBuilder.Entity("Nutrimeal.Domain.Entities.QuantidadeAlimentar", b =>
                {
                    b.Property<Guid>("QuantidadeAlimentarId")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("AlimentoId");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("ModifiedAt");

                    b.Property<string>("ModifiedBy");

                    b.Property<float>("Quantidade");

                    b.Property<Guid>("RefeicaoId");

                    b.Property<int>("TipoMedida");

                    b.HasKey("QuantidadeAlimentarId");

                    b.HasIndex("AlimentoId");

                    b.HasIndex("RefeicaoId");

                    b.ToTable("QuantidadeAlimentar");
                });

            modelBuilder.Entity("Nutrimeal.Domain.Entities.Refeicao", b =>
                {
                    b.Property<Guid>("RefeicaoId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("ModifiedAt");

                    b.Property<string>("ModifiedBy");

                    b.Property<string>("Nome");

                    b.Property<Guid>("PerfilAlimentarId");

                    b.HasKey("RefeicaoId");

                    b.HasIndex("PerfilAlimentarId");

                    b.ToTable("Refeicao");
                });
        }
    }
}
