using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Chat.Persistence.Migrations
{
    public partial class chat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChatList_AspNetUsers_ToUserId",
                table: "ChatList");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_ChatList_ChatListId",
                table: "Messages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChatList",
                table: "ChatList");

            migrationBuilder.RenameTable(
                name: "ChatList",
                newName: "ChatLists");

            migrationBuilder.RenameIndex(
                name: "IX_ChatList_ToUserId",
                table: "ChatLists",
                newName: "IX_ChatLists_ToUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChatLists",
                table: "ChatLists",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ChatLists_AspNetUsers_ToUserId",
                table: "ChatLists",
                column: "ToUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_ChatLists_ChatListId",
                table: "Messages",
                column: "ChatListId",
                principalTable: "ChatLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChatLists_AspNetUsers_ToUserId",
                table: "ChatLists");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_ChatLists_ChatListId",
                table: "Messages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChatLists",
                table: "ChatLists");

            migrationBuilder.RenameTable(
                name: "ChatLists",
                newName: "ChatList");

            migrationBuilder.RenameIndex(
                name: "IX_ChatLists_ToUserId",
                table: "ChatList",
                newName: "IX_ChatList_ToUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChatList",
                table: "ChatList",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ChatList_AspNetUsers_ToUserId",
                table: "ChatList",
                column: "ToUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_ChatList_ChatListId",
                table: "Messages",
                column: "ChatListId",
                principalTable: "ChatList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
