using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ethereum_Betting.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Achievement",
                columns: table => new
                {
                    AchievementId = table.Column<Guid>(nullable: false),
                    AchievementTitle = table.Column<string>(nullable: true),
                    AchievementDescription = table.Column<string>(nullable: true),
                    Points = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Achievement", x => x.AchievementId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserAddress = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: true),
                    GeneratedName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserAddress);
                });

            migrationBuilder.CreateTable(
                name: "Friend",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    UserFriendId = table.Column<Guid>(nullable: false),
                    UserAddress = table.Column<string>(nullable: true),
                    UserFriendUserAddress = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Friend", x => new { x.UserId, x.UserFriendId });
                    table.ForeignKey(
                        name: "FK_Friend_Users_UserAddress",
                        column: x => x.UserAddress,
                        principalTable: "Users",
                        principalColumn: "UserAddress",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Friend_Users_UserFriendUserAddress",
                        column: x => x.UserFriendUserAddress,
                        principalTable: "Users",
                        principalColumn: "UserAddress",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FriendRequest",
                columns: table => new
                {
                    UserCallerId = table.Column<Guid>(nullable: false),
                    UserReceiverId = table.Column<Guid>(nullable: false),
                    UserCallerUserAddress = table.Column<string>(nullable: true),
                    UserReceiverUserAddress = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FriendRequest", x => new { x.UserCallerId, x.UserReceiverId });
                    table.ForeignKey(
                        name: "FK_FriendRequest_Users_UserCallerUserAddress",
                        column: x => x.UserCallerUserAddress,
                        principalTable: "Users",
                        principalColumn: "UserAddress",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FriendRequest_Users_UserReceiverUserAddress",
                        column: x => x.UserReceiverUserAddress,
                        principalTable: "Users",
                        principalColumn: "UserAddress",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserAchievement",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    AchievementId = table.Column<Guid>(nullable: false),
                    UserAddress = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAchievement", x => new { x.AchievementId, x.UserId });
                    table.ForeignKey(
                        name: "FK_UserAchievement_Achievement_AchievementId",
                        column: x => x.AchievementId,
                        principalTable: "Achievement",
                        principalColumn: "AchievementId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserAchievement_Users_UserAddress",
                        column: x => x.UserAddress,
                        principalTable: "Users",
                        principalColumn: "UserAddress",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Friend_UserAddress",
                table: "Friend",
                column: "UserAddress");

            migrationBuilder.CreateIndex(
                name: "IX_Friend_UserFriendUserAddress",
                table: "Friend",
                column: "UserFriendUserAddress");

            migrationBuilder.CreateIndex(
                name: "IX_FriendRequest_UserCallerUserAddress",
                table: "FriendRequest",
                column: "UserCallerUserAddress");

            migrationBuilder.CreateIndex(
                name: "IX_FriendRequest_UserReceiverUserAddress",
                table: "FriendRequest",
                column: "UserReceiverUserAddress");

            migrationBuilder.CreateIndex(
                name: "IX_UserAchievement_UserAddress",
                table: "UserAchievement",
                column: "UserAddress");

            migrationBuilder.CreateIndex(
                name: "IX_Users_GeneratedName",
                table: "Users",
                column: "GeneratedName",
                unique: true,
                filter: "[GeneratedName] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Friend");

            migrationBuilder.DropTable(
                name: "FriendRequest");

            migrationBuilder.DropTable(
                name: "UserAchievement");

            migrationBuilder.DropTable(
                name: "Achievement");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
