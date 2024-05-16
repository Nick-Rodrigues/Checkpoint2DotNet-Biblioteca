using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Checkpoint2DotNet_Biblioteca.Migrations
{
    /// <inheritdoc />
    public partial class Endereco1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CEP",
                table: "T_NET_Endereços",
                type: "NVARCHAR2(9)",
                maxLength: 9,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)",
                oldMaxLength: 9);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "CEP",
                table: "T_NET_Endereços",
                type: "NUMBER(10)",
                maxLength: 9,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(9)",
                oldMaxLength: 9);
        }
    }
}
