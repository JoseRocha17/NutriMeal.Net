using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Nutrimeal.Repository.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alimento",
                columns: table => new
                {
                    AlimentoId = table.Column<Guid>(nullable: false),
                    Acucar = table.Column<float>(nullable: false),
                    Calorias = table.Column<float>(nullable: false),
                    Carboidrato = table.Column<float>(nullable: false),
                    Colestrol = table.Column<float>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    Fibra = table.Column<float>(nullable: false),
                    Gordura = table.Column<float>(nullable: false),
                    Grupo = table.Column<int>(nullable: false),
                    ModifiedAt = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    Nome = table.Column<string>(nullable: true),
                    Potassio = table.Column<float>(nullable: false),
                    Proteina = table.Column<float>(nullable: false),
                    Sodio = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alimento", x => x.AlimentoId);
                });

            migrationBuilder.CreateTable(
                name: "Atributo",
                columns: table => new
                {
                    AtributoId = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    ModifiedAt = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    Nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atributo", x => x.AtributoId);
                });

            migrationBuilder.CreateTable(
                name: "Exercicio",
                columns: table => new
                {
                    ExercicioId = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    Descricao = table.Column<string>(nullable: true),
                    ModifiedAt = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    Nome = table.Column<string>(nullable: true),
                    Tipo = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercicio", x => x.ExercicioId);
                });

            migrationBuilder.CreateTable(
                name: "ExercicioAtributo",
                columns: table => new
                {
                    ExercicioAtributoId = table.Column<Guid>(nullable: false),
                    AtributoId = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    MetaExercicioId = table.Column<Guid>(nullable: false),
                    ModifiedAt = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    Valor = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExercicioAtributo", x => x.ExercicioAtributoId);
                });

            migrationBuilder.CreateTable(
                name: "Medidas",
                columns: table => new
                {
                    MedidaId = table.Column<Guid>(nullable: false),
                    Altura = table.Column<float>(nullable: false),
                    Cintura = table.Column<float>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    DataMedicao = table.Column<DateTime>(nullable: false),
                    ModifiedAt = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    Pescoco = table.Column<float>(nullable: false),
                    Peso = table.Column<float>(nullable: false),
                    Quadris = table.Column<float>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medidas", x => x.MedidaId);
                });

            migrationBuilder.CreateTable(
                name: "MetaExercicio",
                columns: table => new
                {
                    MetaExercicioId = table.Column<Guid>(nullable: false),
                    Calorias = table.Column<float>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    ExercicioId = table.Column<Guid>(nullable: false),
                    ModifiedAt = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    PerfilFisicoId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MetaExercicio", x => x.MetaExercicioId);
                });

            migrationBuilder.CreateTable(
                name: "Objetivos",
                columns: table => new
                {
                    ObjetivosId = table.Column<Guid>(nullable: false),
                    Cintura = table.Column<float>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    DataObjetivo = table.Column<DateTime>(nullable: false),
                    ModifiedAt = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    Pescoco = table.Column<float>(nullable: false),
                    Peso = table.Column<float>(nullable: false),
                    Quadris = table.Column<float>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Objetivos", x => x.ObjetivosId);
                });

            migrationBuilder.CreateTable(
                name: "PerfilAlimentar",
                columns: table => new
                {
                    PerfilAlimentarId = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    Data = table.Column<DateTime>(nullable: false),
                    ModifiedAt = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    Nome = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PerfilAlimentar", x => x.PerfilAlimentarId);
                });

            migrationBuilder.CreateTable(
                name: "PerfilFisico",
                columns: table => new
                {
                    PerfilFisicoId = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    Data = table.Column<DateTime>(nullable: false),
                    ModifiedAt = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    Nome = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PerfilFisico", x => x.PerfilFisicoId);
                });

            migrationBuilder.CreateTable(
                name: "QuantidadeAlimentar",
                columns: table => new
                {
                    QuantidadeAlimentarId = table.Column<Guid>(nullable: false),
                    AlimentoId = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    ModifiedAt = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    Quantidade = table.Column<float>(nullable: false),
                    RefeicaoId = table.Column<Guid>(nullable: false),
                    TipoMedida = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuantidadeAlimentar", x => x.QuantidadeAlimentarId);
                });

            migrationBuilder.CreateTable(
                name: "Refeicao",
                columns: table => new
                {
                    RefeicaoId = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    ModifiedAt = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    Nome = table.Column<string>(nullable: true),
                    PerfilAlimentarId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Refeicao", x => x.RefeicaoId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alimento_Grupo",
                table: "Alimento",
                column: "Grupo");

            migrationBuilder.CreateIndex(
                name: "IX_Atributo_Nome",
                table: "Atributo",
                column: "Nome");

            migrationBuilder.CreateIndex(
                name: "IX_Exercicio_Nome",
                table: "Exercicio",
                column: "Nome");

            migrationBuilder.CreateIndex(
                name: "IX_ExercicioAtributo_AtributoId",
                table: "ExercicioAtributo",
                column: "AtributoId");

            migrationBuilder.CreateIndex(
                name: "IX_ExercicioAtributo_MetaExercicioId",
                table: "ExercicioAtributo",
                column: "MetaExercicioId");

            migrationBuilder.CreateIndex(
                name: "IX_Medidas_UserId",
                table: "Medidas",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_MetaExercicio_PerfilFisicoId",
                table: "MetaExercicio",
                column: "PerfilFisicoId");

            migrationBuilder.CreateIndex(
                name: "IX_Objetivos_UserId",
                table: "Objetivos",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PerfilAlimentar_UserId",
                table: "PerfilAlimentar",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PerfilFisico_UserId",
                table: "PerfilFisico",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_QuantidadeAlimentar_AlimentoId",
                table: "QuantidadeAlimentar",
                column: "AlimentoId");

            migrationBuilder.CreateIndex(
                name: "IX_QuantidadeAlimentar_RefeicaoId",
                table: "QuantidadeAlimentar",
                column: "RefeicaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Refeicao_PerfilAlimentarId",
                table: "Refeicao",
                column: "PerfilAlimentarId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alimento");

            migrationBuilder.DropTable(
                name: "Atributo");

            migrationBuilder.DropTable(
                name: "Exercicio");

            migrationBuilder.DropTable(
                name: "ExercicioAtributo");

            migrationBuilder.DropTable(
                name: "Medidas");

            migrationBuilder.DropTable(
                name: "MetaExercicio");

            migrationBuilder.DropTable(
                name: "Objetivos");

            migrationBuilder.DropTable(
                name: "PerfilAlimentar");

            migrationBuilder.DropTable(
                name: "PerfilFisico");

            migrationBuilder.DropTable(
                name: "QuantidadeAlimentar");

            migrationBuilder.DropTable(
                name: "Refeicao");
        }
    }
}
