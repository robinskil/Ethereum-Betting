using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //To define multi keys etc.

            //Generated name has to be unique
            modelBuilder.Entity<User>().HasIndex(u => u.GeneratedName).IsUnique();
        }

    }
}
