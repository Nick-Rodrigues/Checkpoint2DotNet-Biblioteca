using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Checkpoint2DotNet_Biblioteca.Migrations
{
    /// <inheritdoc />
    public partial class BibliotecaAndCliente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "T_NET_Bibliotecas",
                columns: table => new
                {
                    BibliotecaId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nome = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    EnderecoId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LivroId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_NET_Bibliotecas", x => x.BibliotecaId);
                    table.ForeignKey(
                        name: "FK_T_NET_Bibliotecas_T_NET_Endereços_EnderecoId",
                        column: x => x.EnderecoId,
                        principalTable: "T_NET_Endereços",
                        principalColumn: "EnderecoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_T_NET_Bibliotecas_T_NET_Livros_LivroId",
                        column: x => x.LivroId,
                        principalTable: "T_NET_Livros",
                        principalColumn: "LivroId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "T_NET_Clientes",
                columns: table => new
                {
                    ClienteId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nome = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Email = table.Column<string>(type: "varchar(255)", nullable: false),
                    Cpf = table.Column<string>(type: "NVARCHAR2(11)", maxLength: 11, nullable: false),
                    EnderecoId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_NET_Clientes", x => x.ClienteId);
                    table.ForeignKey(
                        name: "FK_T_NET_Clientes_T_NET_Endereços_EnderecoId",
                        column: x => x.EnderecoId,
                        principalTable: "T_NET_Endereços",
                        principalColumn: "EnderecoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_T_NET_Bibliotecas_EnderecoId",
                table: "T_NET_Bibliotecas",
                column: "EnderecoId");

            migrationBuilder.CreateIndex(
                name: "IX_T_NET_Bibliotecas_LivroId",
                table: "T_NET_Bibliotecas",
                column: "LivroId");

            migrationBuilder.CreateIndex(
                name: "IX_T_NET_Clientes_EnderecoId",
                table: "T_NET_Clientes",
                column: "EnderecoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "T_NET_Bibliotecas");

            migrationBuilder.DropTable(
                name: "T_NET_Clientes");
        }
    }
}
