using Microsoft.EntityFrameworkCore;
using System;

namespace ProductMobile
{
    public class productDbContext:DbContext
    {
        public DbSet<Product>Products { get; set; }
        private string dbFilePath;
        public productDbContext()
        {

        }

        public productDbContext( string dbFilePath)
        {
            this.dbFilePath = dbFilePath;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlite($"filename ={ dbFilePath}");
        }
    }
}
