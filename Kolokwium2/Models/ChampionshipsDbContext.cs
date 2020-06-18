using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium2.Models
{
    public class ChampionshipsDbContext : DbContext
    {
        public DbSet<Championship> Championships { get; set; }
        public DbSet<Championship_Team> Championship_Teams { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Player_Team> Player_Teams { get; set; }
        public DbSet<Team> Teams { get; set; }
        public ChampionshipsDbContext()
        {

        }

        public ChampionshipsDbContext(DbContextOptions options)
                :base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Championship>(opt =>
            {
                opt.HasKey(p => p.IdChampionship);
                opt.Property(p => p.IdChampionship)
                .ValueGeneratedOnAdd();

                opt.Property(e => e.OfficialName)
                .HasMaxLength(100)
                .IsRequired();
        
            });


            modelBuilder.Entity<Team>(opt =>
            {
                opt.HasKey(p => p.IdTeam);
                opt.Property(p => p.IdTeam)
                .ValueGeneratedOnAdd();

                opt.Property(e => e.TeamName)
                .HasMaxLength(30)
                .IsRequired();
            });

            modelBuilder.Entity<Player>(opt =>
            {
                opt.HasKey(p => p.IdPlayer);
                opt.Property(p => p.IdPlayer)
                .ValueGeneratedOnAdd();

                opt.Property(e => e.FirstName)
                .HasMaxLength(30)
                .IsRequired();

                opt.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsRequired();
            });

            modelBuilder.Entity<Player_Team>(opt =>
            {
                opt.HasKey(p => new { p.IdPlayer, p.IdTeam });
                opt.Property(p => p.IdTeam)
                .ValueGeneratedOnAdd();

                opt.Property(e => e.Comment)
                .HasMaxLength(300);

                opt.HasOne(e => e.Player)
                .WithMany(e => e.Player_Teams)
                .HasForeignKey(e => e.IdPlayer);

                opt.HasOne(e => e.Team)
                .WithMany(e => e.Player_Teams)
                .HasForeignKey(e => e.IdTeam);


            });

            modelBuilder.Entity<Championship_Team>(opt =>
            {
                opt.HasKey(p => new { p.IdTeam, p.IdChampionship });
                opt.Property(p => p.IdTeam)
                .ValueGeneratedOnAdd();

                opt.HasOne(e => e.Championship)
                .WithMany(e => e.Championship_Teams)
                .HasForeignKey(e => e.IdChampionship);

                opt.HasOne(e => e.Team)
                .WithMany(e => e.Championship_Teams)
                .HasForeignKey(e => e.IdTeam);
            });








        }
    }
}
