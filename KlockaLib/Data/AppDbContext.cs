using KlockaLib.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace KlockaLib.Data
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext()
        {

        }
        public DbSet<Host> Hosts { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var dbPath = Path.Combine(Environment.CurrentDirectory, "klocka.db");
            options.UseSqlite("Data Source = " + dbPath);
            base.OnConfiguring(options);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Inventory>(inventory =>
            {
                inventory.HasKey(i => i.Id);
            });

            builder.Entity<Host>(host =>
            {
                host.HasKey(h => h.Id);

                host.HasOne(h => h.Inventory)
                    .WithMany(i => i.Hosts)
                    .HasForeignKey(h => h.InventoryId);
            });

            builder.Entity<Inventory>(i =>
            {
                i.HasData(new Inventory
                {
                    Id = 1,
                    Name = "Demo Inventory",
                });
            });    
            


        }
    }
}
