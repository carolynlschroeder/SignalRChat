using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SignalRChat.Data.Migrations
{
    public partial class ChangeMessage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_AspNetUsers_UserId",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_UserId",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Messages");

            migrationBuilder.RenameColumn(
                name: "Text",
                table: "Messages",
                newName: "Body");

            migrationBuilder.RenameColumn(
                name: "DateTime",
                table: "Messages",
                newName: "DateSent");

            migrationBuilder.AddColumn<string>(
                name: "From",
                table: "Messages",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "To",
                table: "Messages",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "From",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "To",
                table: "Messages");

            migrationBuilder.RenameColumn(
                name: "DateSent",
                table: "Messages",
                newName: "DateTime");

            migrationBuilder.RenameColumn(
                name: "Body",
                table: "Messages",
                newName: "Text");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Messages",
                type: "nvarchar(450)",
                maxLength: 450,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_UserId",
                table: "Messages",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_AspNetUsers_UserId",
                table: "Messages",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
