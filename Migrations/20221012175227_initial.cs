using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CFA_CORE.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Cust_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cust_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cust_Age = table.Column<int>(type: "int", nullable: false),
                    OrderdDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Cust_DOB = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Cust_MobileNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cust_Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cust_Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cust_ConfirmPassword = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Cust_Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
