using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Manager.Migrations
{
    public partial class initialCreateSeedingData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Department = table.Column<int>(type: "int", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Department",
                columns: new[] { "Id", "Location", "Name" },
                values: new object[,]
                {
                    { 1, "SCS Company", "HR" },
                    { 2, "Microsoft Company", "CEO" },
                    { 3, "Tichnical Company", "TICH" },
                    { 4, "Enginerrnig Company", "ENGINNER" },
                    { 5, " SCS Company", "IT" },
                    { 6, "Google Company", "CEO" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Age", "Department", "Email", "ImagePath", "Name", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, 24, 1, "Ali@gmail.com", "", "Ali", "0777777777" },
                    { 2, 33, 5, "Khaled@gmail.com", "", "khaled", "0792999999" },
                    { 3, 56, 2, "Sam@gmail.com", "", "Sam", "0792346332" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Department");

            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
