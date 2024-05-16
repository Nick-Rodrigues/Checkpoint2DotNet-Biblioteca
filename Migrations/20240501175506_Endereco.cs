using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Checkpoint2DotNet_Biblioteca.Migrations
{
    /// <inheritdoc />
    public partial class Endereco : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "T_NET_Endereços",
                columns: table => new
                {
                    EnderecoId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    CEP = table.Column<int>(type: "NUMBER(10)", maxLength: 9, nullable: false),
                    Numero = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Complemento = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_NET_Endereços", x => x.EnderecoId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "T_NET_Endereços");
        }
    }
}
