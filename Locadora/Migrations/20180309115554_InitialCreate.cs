using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Locadora.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true),
                    Telefone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Filmes",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filmes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Funcionarios",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Cpf = table.Column<string>(nullable: true),
                    Nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Devolucoes",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClienteId = table.Column<int>(nullable: false),
                    ClienteId1 = table.Column<long>(nullable: true),
                    DataEntrega = table.Column<string>(nullable: true),
                    FilmeId = table.Column<int>(nullable: false),
                    FilmeId1 = table.Column<long>(nullable: true),
                    FuncionarioId = table.Column<int>(nullable: false),
                    FuncionarioId1 = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Devolucoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Devolucoes_Clientes_ClienteId1",
                        column: x => x.ClienteId1,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Devolucoes_Filmes_FilmeId1",
                        column: x => x.FilmeId1,
                        principalTable: "Filmes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Devolucoes_Funcionarios_FuncionarioId1",
                        column: x => x.FuncionarioId1,
                        principalTable: "Funcionarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Locacoes",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClienteId = table.Column<int>(nullable: false),
                    ClienteId1 = table.Column<long>(nullable: true),
                    Data = table.Column<string>(nullable: true),
                    FilmeLocacaoId = table.Column<int>(nullable: false),
                    FuncionarioId = table.Column<int>(nullable: false),
                    FuncionarioId1 = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locacoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Locacoes_Clientes_ClienteId1",
                        column: x => x.ClienteId1,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Locacoes_Funcionarios_FuncionarioId1",
                        column: x => x.FuncionarioId1,
                        principalTable: "Funcionarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FilmeLocacoes",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Data = table.Column<string>(nullable: true),
                    FilmeId = table.Column<int>(nullable: false),
                    FilmeId1 = table.Column<long>(nullable: true),
                    LocacaoId = table.Column<int>(nullable: false),
                    LocacaoId1 = table.Column<long>(nullable: true),
                    Valor = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmeLocacoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FilmeLocacoes_Filmes_FilmeId1",
                        column: x => x.FilmeId1,
                        principalTable: "Filmes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FilmeLocacoes_Locacoes_LocacaoId1",
                        column: x => x.LocacaoId1,
                        principalTable: "Locacoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Devolucoes_ClienteId1",
                table: "Devolucoes",
                column: "ClienteId1");

            migrationBuilder.CreateIndex(
                name: "IX_Devolucoes_FilmeId1",
                table: "Devolucoes",
                column: "FilmeId1");

            migrationBuilder.CreateIndex(
                name: "IX_Devolucoes_FuncionarioId1",
                table: "Devolucoes",
                column: "FuncionarioId1");

            migrationBuilder.CreateIndex(
                name: "IX_FilmeLocacoes_FilmeId1",
                table: "FilmeLocacoes",
                column: "FilmeId1");

            migrationBuilder.CreateIndex(
                name: "IX_FilmeLocacoes_LocacaoId1",
                table: "FilmeLocacoes",
                column: "LocacaoId1",
                unique: true,
                filter: "[LocacaoId1] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Locacoes_ClienteId1",
                table: "Locacoes",
                column: "ClienteId1");

            migrationBuilder.CreateIndex(
                name: "IX_Locacoes_FuncionarioId1",
                table: "Locacoes",
                column: "FuncionarioId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Devolucoes");

            migrationBuilder.DropTable(
                name: "FilmeLocacoes");

            migrationBuilder.DropTable(
                name: "Filmes");

            migrationBuilder.DropTable(
                name: "Locacoes");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Funcionarios");
        }
    }
}
