using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Checkpoint2DotNet_Biblioteca.Migrations
{
    /// <inheritdoc />
    public partial class AutorAndLivro : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "T_NET_Autores",
                columns: table => new
                {
                    AutorId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nome = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_NET_Autores", x => x.AutorId);
                });

            migrationBuilder.CreateTable(
                name: "T_NET_Livros",
                columns: table => new
                {
                    LivroId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Titulo = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Genero = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    DataLancamento = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_NET_Livros", x => x.LivroId);
                });

            migrationBuilder.CreateTable(
                name: "AutorLivro",
                columns: table => new
                {
                    AutoresAutorId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LivrosLivroId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutorLivro", x => new { x.AutoresAutorId, x.LivrosLivroId });
                    table.ForeignKey(
                        name: "FK_AutorLivro_T_NET_Autores_AutoresAutorId",
                        column: x => x.AutoresAutorId,
                        principalTable: "T_NET_Autores",
                        principalColumn: "AutorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AutorLivro_T_NET_Livros_LivrosLivroId",
                        column: x => x.LivrosLivroId,
                        principalTable: "T_NET_Livros",
                        principalColumn: "LivroId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AutorLivro_LivrosLivroId",
                table: "AutorLivro",
                column: "LivrosLivroId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AutorLivro");

            migrationBuilder.DropTable(
                name: "T_NET_Autores");

            migrationBuilder.DropTable(
                name: "T_NET_Livros");
        }
    }
}
