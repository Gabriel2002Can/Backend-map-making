using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Backend_map.Models;

namespace Backend_map.Data
{
    public class Backend_mapContext : DbContext
    {
        public Backend_mapContext (DbContextOptions<Backend_mapContext> options)
            : base(options)
        {
        }

        public DbSet<Backend_map.Models.Map> Maps { get; set; } = default!;
        public DbSet<Backend_map.Models.Floor> Floors { get; set; } = default!;
        public DbSet<Backend_map.Models.Cell> Cells { get; set; } = default!;
        public DbSet<Backend_map.Models.Room> Rooms { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Map>()
                .HasMany(m => m.Floors)
                .WithOne(f => f.Map)
                .HasForeignKey(f => f.MapId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Floor>()
                .HasMany(f => f.Cells)
                .WithOne(c => c.Floor)
                .HasForeignKey(c => c.FloorId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Floor>()
                .HasMany(f => f.Rooms)
                .WithOne(r => r.Floor)
                .HasForeignKey(r => r.FloorId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Map>().HasData(
                new Map { Id = 1, Name = "Sample Map" }
            );

            modelBuilder.Entity<Floor>().HasData(
                new Floor { Id = 1, Number = 1, DimensionX = 10, DimensionY = 10, MapId = 1 }
            );

            modelBuilder.Entity<Cell>().HasData(
                new Cell { Id = 1, X = 1, Y = 1, IsFilled = false, FloorId = 1 },
                new Cell { Id = 2, X = 1, Y = 2, IsFilled = true, FloorId = 1 },
                new Cell { Id = 3, X = 2, Y = 1, IsFilled = false, FloorId = 1 },
                new Cell { Id = 4, X = 2, Y = 2, IsFilled = true, FloorId = 1 }
            );
        }

    }
}
