using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shoes_project.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MembershipLevels",
                columns: table => new
                {
                    MembershipLevelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DiscountPercentage = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MinimumSpend = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Benefits = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MembershipLevels", x => x.MembershipLevelId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MembershipLevels");
        }
    }
}
