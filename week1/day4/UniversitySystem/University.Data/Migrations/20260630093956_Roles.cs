using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace University.Data.Migrations
{
    /// <inheritdoc />
    public partial class Roles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO AspNetRoles (Name, NormalizedName, ConcurrencyStamp) VALUES ('Student', 'STUDENT', NEWID())");
            migrationBuilder.Sql("INSERT INTO AspNetRoles (Name, NormalizedName, ConcurrencyStamp) VALUES ('Teacher', 'TEACHER', NEWID())");


        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM AspNetRoles WHERE NormalizedName IN ('STUDENT', 'TEACHER')");
        }
    }
}
