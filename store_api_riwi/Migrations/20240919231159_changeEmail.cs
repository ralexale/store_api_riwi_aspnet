using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace store_api_riwi.Migrations
{
    /// <inheritdoc />
    public partial class changeEmail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Emil",
                table: "Users",
                newName: "Email");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Users",
                newName: "Emil");
        }
    }
}
