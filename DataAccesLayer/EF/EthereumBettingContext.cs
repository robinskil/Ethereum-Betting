using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccesLayer.EF
{
    public class EthereumBettingContext : DbContext
    {
        public EthereumBettingContext(DbContextOptions<EthereumBettingContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Bet> Bets { get; set; }
        public DbSet<Achievement> Achievements { get; set; }
        public DbSet<UserAchievement> UserAchievements { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //To define multi keys etc.
            //Remove constraint on foreign key delete cascade.
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
            //Generated name has to be unique
            modelBuilder.Entity<User>().HasIndex(u => u.GeneratedName).IsUnique();
            modelBuilder.Entity<UserAchievement>().HasKey(p => new { p.AchievementId, p.UserId }); 
        }

    }
}
