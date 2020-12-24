using GlassValley.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlassValley
{
    public class ItemsContext : DbContext
    {
        public ItemsContext(DbContextOptions<ItemsContext> options) : base(options) => ChangeTracker.LazyLoadingEnabled = false;

        public DbSet<ItemModel> Items { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ItemModel>().HasKey(x => x.key);

            base.OnModelCreating(modelBuilder);
        }
    }
}
