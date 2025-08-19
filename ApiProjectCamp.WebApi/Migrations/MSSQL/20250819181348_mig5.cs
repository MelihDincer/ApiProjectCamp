using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiProjectCamp.WebApi.Migrations.MSSQL
{
    public partial class mig5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Abouts",
                columns: table => new
                {
                    AboutId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AboutTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AboutImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AboutVideoCoverImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AboutVideoUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AboutDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AboutReservationNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Abouts", x => x.AboutId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Abouts");
        }
    }
}
