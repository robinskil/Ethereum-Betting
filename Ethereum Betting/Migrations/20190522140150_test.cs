using Microsoft.EntityFrameworkCore.Migrations;

namespace Ethereum_Betting.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Friend_Users_UserAddress",
                table: "Friend");

            migrationBuilder.DropForeignKey(
                name: "FK_Friend_Users_UserFriendUserAddress",
                table: "Friend");

            migrationBuilder.DropForeignKey(
                name: "FK_FriendRequest_Users_UserCallerUserAddress",
                table: "FriendRequest");

            migrationBuilder.DropForeignKey(
                name: "FK_FriendRequest_Users_UserReceiverUserAddress",
                table: "FriendRequest");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAchievement_Achievement_AchievementId",
                table: "UserAchievement");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAchievement_Users_UserAddress",
                table: "UserAchievement");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserAchievement",
                table: "UserAchievement");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FriendRequest",
                table: "FriendRequest");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Friend",
                table: "Friend");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Achievement",
                table: "Achievement");

            migrationBuilder.RenameTable(
                name: "UserAchievement",
                newName: "UserAchievements");

            migrationBuilder.RenameTable(
                name: "FriendRequest",
                newName: "FriendRequests");

            migrationBuilder.RenameTable(
                name: "Friend",
                newName: "Friends");

            migrationBuilder.RenameTable(
                name: "Achievement",
                newName: "Achievements");

            migrationBuilder.RenameIndex(
                name: "IX_UserAchievement_UserAddress",
                table: "UserAchievements",
                newName: "IX_UserAchievements_UserAddress");

            migrationBuilder.RenameIndex(
                name: "IX_FriendRequest_UserReceiverUserAddress",
                table: "FriendRequests",
                newName: "IX_FriendRequests_UserReceiverUserAddress");

            migrationBuilder.RenameIndex(
                name: "IX_FriendRequest_UserCallerUserAddress",
                table: "FriendRequests",
                newName: "IX_FriendRequests_UserCallerUserAddress");

            migrationBuilder.RenameIndex(
                name: "IX_Friend_UserFriendUserAddress",
                table: "Friends",
                newName: "IX_Friends_UserFriendUserAddress");

            migrationBuilder.RenameIndex(
                name: "IX_Friend_UserAddress",
                table: "Friends",
                newName: "IX_Friends_UserAddress");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserAchievements",
                table: "UserAchievements",
                columns: new[] { "AchievementId", "UserId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_FriendRequests",
                table: "FriendRequests",
                columns: new[] { "UserCallerId", "UserReceiverId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Friends",
                table: "Friends",
                columns: new[] { "UserId", "UserFriendId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Achievements",
                table: "Achievements",
                column: "AchievementId");

            migrationBuilder.CreateTable(
                name: "Bets",
                columns: table => new
                {
                    BetAddress = table.Column<string>(nullable: false),
                    UserAddress = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bets", x => x.BetAddress);
                    table.ForeignKey(
                        name: "FK_Bets_Users_UserAddress",
                        column: x => x.UserAddress,
                        principalTable: "Users",
                        principalColumn: "UserAddress",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bets_UserAddress",
                table: "Bets",
                column: "UserAddress");

            migrationBuilder.AddForeignKey(
                name: "FK_FriendRequests_Users_UserCallerUserAddress",
                table: "FriendRequests",
                column: "UserCallerUserAddress",
                principalTable: "Users",
                principalColumn: "UserAddress",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FriendRequests_Users_UserReceiverUserAddress",
                table: "FriendRequests",
                column: "UserReceiverUserAddress",
                principalTable: "Users",
                principalColumn: "UserAddress",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Friends_Users_UserAddress",
                table: "Friends",
                column: "UserAddress",
                principalTable: "Users",
                principalColumn: "UserAddress",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Friends_Users_UserFriendUserAddress",
                table: "Friends",
                column: "UserFriendUserAddress",
                principalTable: "Users",
                principalColumn: "UserAddress",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserAchievements_Achievements_AchievementId",
                table: "UserAchievements",
                column: "AchievementId",
                principalTable: "Achievements",
                principalColumn: "AchievementId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserAchievements_Users_UserAddress",
                table: "UserAchievements",
                column: "UserAddress",
                principalTable: "Users",
                principalColumn: "UserAddress",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FriendRequests_Users_UserCallerUserAddress",
                table: "FriendRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_FriendRequests_Users_UserReceiverUserAddress",
                table: "FriendRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_Friends_Users_UserAddress",
                table: "Friends");

            migrationBuilder.DropForeignKey(
                name: "FK_Friends_Users_UserFriendUserAddress",
                table: "Friends");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAchievements_Achievements_AchievementId",
                table: "UserAchievements");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAchievements_Users_UserAddress",
                table: "UserAchievements");

            migrationBuilder.DropTable(
                name: "Bets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserAchievements",
                table: "UserAchievements");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Friends",
                table: "Friends");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FriendRequests",
                table: "FriendRequests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Achievements",
                table: "Achievements");

            migrationBuilder.RenameTable(
                name: "UserAchievements",
                newName: "UserAchievement");

            migrationBuilder.RenameTable(
                name: "Friends",
                newName: "Friend");

            migrationBuilder.RenameTable(
                name: "FriendRequests",
                newName: "FriendRequest");

            migrationBuilder.RenameTable(
                name: "Achievements",
                newName: "Achievement");

            migrationBuilder.RenameIndex(
                name: "IX_UserAchievements_UserAddress",
                table: "UserAchievement",
                newName: "IX_UserAchievement_UserAddress");

            migrationBuilder.RenameIndex(
                name: "IX_Friends_UserFriendUserAddress",
                table: "Friend",
                newName: "IX_Friend_UserFriendUserAddress");

            migrationBuilder.RenameIndex(
                name: "IX_Friends_UserAddress",
                table: "Friend",
                newName: "IX_Friend_UserAddress");

            migrationBuilder.RenameIndex(
                name: "IX_FriendRequests_UserReceiverUserAddress",
                table: "FriendRequest",
                newName: "IX_FriendRequest_UserReceiverUserAddress");

            migrationBuilder.RenameIndex(
                name: "IX_FriendRequests_UserCallerUserAddress",
                table: "FriendRequest",
                newName: "IX_FriendRequest_UserCallerUserAddress");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserAchievement",
                table: "UserAchievement",
                columns: new[] { "AchievementId", "UserId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Friend",
                table: "Friend",
                columns: new[] { "UserId", "UserFriendId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_FriendRequest",
                table: "FriendRequest",
                columns: new[] { "UserCallerId", "UserReceiverId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Achievement",
                table: "Achievement",
                column: "AchievementId");

            migrationBuilder.AddForeignKey(
                name: "FK_Friend_Users_UserAddress",
                table: "Friend",
                column: "UserAddress",
                principalTable: "Users",
                principalColumn: "UserAddress",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Friend_Users_UserFriendUserAddress",
                table: "Friend",
                column: "UserFriendUserAddress",
                principalTable: "Users",
                principalColumn: "UserAddress",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FriendRequest_Users_UserCallerUserAddress",
                table: "FriendRequest",
                column: "UserCallerUserAddress",
                principalTable: "Users",
                principalColumn: "UserAddress",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FriendRequest_Users_UserReceiverUserAddress",
                table: "FriendRequest",
                column: "UserReceiverUserAddress",
                principalTable: "Users",
                principalColumn: "UserAddress",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserAchievement_Achievement_AchievementId",
                table: "UserAchievement",
                column: "AchievementId",
                principalTable: "Achievement",
                principalColumn: "AchievementId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserAchievement_Users_UserAddress",
                table: "UserAchievement",
                column: "UserAddress",
                principalTable: "Users",
                principalColumn: "UserAddress",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
