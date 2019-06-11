﻿// <auto-generated />
using System;
using DataAccesLayer.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Ethereum_Betting.Migrations
{
    [DbContext(typeof(EthereumBettingContext))]
    [Migration("20190522153408_secondMigrate")]
    partial class secondMigrate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DomainLayer.Models.Achievement", b =>
                {
                    b.Property<Guid>("AchievementId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AchievementDescription");

                    b.Property<string>("AchievementTitle");

                    b.Property<int>("Points");

                    b.HasKey("AchievementId");

                    b.ToTable("Achievements");
                });

            modelBuilder.Entity("DomainLayer.Models.Bet", b =>
                {
                    b.Property<string>("BetAddress")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("UserAddress");

                    b.HasKey("BetAddress");

                    b.HasIndex("UserAddress");

                    b.ToTable("Bets");
                });

            modelBuilder.Entity("DomainLayer.Models.Friend", b =>
                {
                    b.Property<Guid>("UserId");

                    b.Property<Guid>("UserFriendId");

                    b.Property<string>("UserAddress");

                    b.Property<string>("UserFriendUserAddress");

                    b.HasKey("UserId", "UserFriendId");

                    b.HasIndex("UserAddress");

                    b.HasIndex("UserFriendUserAddress");

                    b.ToTable("Friends");
                });

            modelBuilder.Entity("DomainLayer.Models.FriendRequest", b =>
                {
                    b.Property<Guid>("UserCallerId");

                    b.Property<Guid>("UserReceiverId");

                    b.Property<string>("UserCallerUserAddress");

                    b.Property<string>("UserReceiverUserAddress");

                    b.HasKey("UserCallerId", "UserReceiverId");

                    b.HasIndex("UserCallerUserAddress");

                    b.HasIndex("UserReceiverUserAddress");

                    b.ToTable("FriendRequests");
                });

            modelBuilder.Entity("DomainLayer.Models.User", b =>
                {
                    b.Property<string>("UserAddress")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("GeneratedName");

                    b.Property<string>("Password");

                    b.HasKey("UserAddress");

                    b.HasIndex("GeneratedName")
                        .IsUnique()
                        .HasFilter("[GeneratedName] IS NOT NULL");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("DomainLayer.Models.UserAchievement", b =>
                {
                    b.Property<Guid>("AchievementId");

                    b.Property<Guid>("UserId");

                    b.Property<string>("UserAddress");

                    b.HasKey("AchievementId", "UserId");

                    b.HasIndex("UserAddress");

                    b.ToTable("UserAchievements");
                });

            modelBuilder.Entity("DomainLayer.Models.Bet", b =>
                {
                    b.HasOne("DomainLayer.Models.User", "Owner")
                        .WithMany("OwnedBets")
                        .HasForeignKey("UserAddress")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("DomainLayer.Models.Friend", b =>
                {
                    b.HasOne("DomainLayer.Models.User", "User")
                        .WithMany("Friends")
                        .HasForeignKey("UserAddress");

                    b.HasOne("DomainLayer.Models.User", "UserFriend")
                        .WithMany("SelfFriends")
                        .HasForeignKey("UserFriendUserAddress");
                });

            modelBuilder.Entity("DomainLayer.Models.FriendRequest", b =>
                {
                    b.HasOne("DomainLayer.Models.User", "UserCaller")
                        .WithMany("ReceivedFriendRequests")
                        .HasForeignKey("UserCallerUserAddress");

                    b.HasOne("DomainLayer.Models.User", "UserReceiver")
                        .WithMany("SentFriendRequests")
                        .HasForeignKey("UserReceiverUserAddress");
                });

            modelBuilder.Entity("DomainLayer.Models.UserAchievement", b =>
                {
                    b.HasOne("DomainLayer.Models.Achievement", "Achievement")
                        .WithMany()
                        .HasForeignKey("AchievementId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("DomainLayer.Models.User", "User")
                        .WithMany("Achievements")
                        .HasForeignKey("UserAddress")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}