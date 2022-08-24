using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RedBadgeFinal.Data.Migrations
{
    public partial class RefactUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_UserEntity_UserEntityId",
                table: "Blogs");

            migrationBuilder.AlterColumn<string>(
                name: "UserEntityId",
                table: "Blogs",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "UserEntityId1",
                table: "Blogs",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_UserEntityId1",
                table: "Blogs",
                column: "UserEntityId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_AspNetUsers_UserEntityId",
                table: "Blogs",
                column: "UserEntityId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_UserEntity_UserEntityId1",
                table: "Blogs",
                column: "UserEntityId1",
                principalTable: "UserEntity",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_AspNetUsers_UserEntityId",
                table: "Blogs");

            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_UserEntity_UserEntityId1",
                table: "Blogs");

            migrationBuilder.DropIndex(
                name: "IX_Blogs_UserEntityId1",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "UserEntityId1",
                table: "Blogs");

            migrationBuilder.AlterColumn<int>(
                name: "UserEntityId",
                table: "Blogs",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_UserEntity_UserEntityId",
                table: "Blogs",
                column: "UserEntityId",
                principalTable: "UserEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
