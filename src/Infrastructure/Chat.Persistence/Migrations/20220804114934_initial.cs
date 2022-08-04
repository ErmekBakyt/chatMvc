using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Chat.Persistence.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_ChatLists_ChatListId",
                table: "Messages");

            migrationBuilder.RenameColumn(
                name: "ChatListId",
                table: "Messages",
                newName: "CommonChatListId");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_ChatListId",
                table: "Messages",
                newName: "IX_Messages_CommonChatListId");

            migrationBuilder.RenameColumn(
                name: "CorrespondedUserId",
                table: "ChatLists",
                newName: "CommonChatListId");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_ChatLists_CommonChatListId",
                table: "Messages",
                column: "CommonChatListId",
                principalTable: "ChatLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_ChatLists_CommonChatListId",
                table: "Messages");

            migrationBuilder.RenameColumn(
                name: "CommonChatListId",
                table: "Messages",
                newName: "ChatListId");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_CommonChatListId",
                table: "Messages",
                newName: "IX_Messages_ChatListId");

            migrationBuilder.RenameColumn(
                name: "CommonChatListId",
                table: "ChatLists",
                newName: "CorrespondedUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_ChatLists_ChatListId",
                table: "Messages",
                column: "ChatListId",
                principalTable: "ChatLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
