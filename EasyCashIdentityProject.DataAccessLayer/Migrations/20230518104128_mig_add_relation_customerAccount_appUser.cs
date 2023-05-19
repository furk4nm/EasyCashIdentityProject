using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyCashIdentityProject.DataAccessLayer.Migrations
{
    public partial class mig_add_relation_customerAccount_appUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AppUserID",
                table: "CustomerAccount",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CustomerAccount_AppUserID",
                table: "CustomerAccount",
                column: "AppUserID");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerAccount_AspNetUsers_AppUserID",
                table: "CustomerAccount",
                column: "AppUserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerAccount_AspNetUsers_AppUserID",
                table: "CustomerAccount");

            migrationBuilder.DropIndex(
                name: "IX_CustomerAccount_AppUserID",
                table: "CustomerAccount");

            migrationBuilder.DropColumn(
                name: "AppUserID",
                table: "CustomerAccount");
        }
    }
}
