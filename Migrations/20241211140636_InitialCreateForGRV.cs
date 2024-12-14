using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Speciality_Metals_Back_End.Migrations
{
    public partial class InitialCreateForGRV : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GRVs",
                columns: table => new
                {
                    GRV_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GRV_Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GRVs", x => x.GRV_ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GRVs");
        }
    }
}
