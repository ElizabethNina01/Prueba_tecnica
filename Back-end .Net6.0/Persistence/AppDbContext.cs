using System.Net.Mail;
using prueba_back.Domain.Model;
using prueba_back.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;

namespace prueba_back.Persistence
{
    public class AppDbContext : DbContext
    {
        protected readonly IConfiguration _configuration;
       
        public  DbSet<Item> Items { get; set; }
       public AppDbContext(DbContextOptions options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            builder.Entity<Item>().ToTable("Items");
            builder.Entity<Item>().HasKey(p => p.ID);
            builder.Entity<Item>().Property(p => p.ID).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Item>().Property(p => p.Cod).IsRequired().HasMaxLength(50);
            builder.Entity<Item>().Property(p => p.Cant).IsRequired();
            builder.Entity<Item>().Property(p => p.NameArt).IsRequired().HasMaxLength(50);
            builder.Entity<Item>().Property(p => p.DescArt).IsRequired().HasMaxLength(50);
          ;
          

           // builder.UseSnakeCaseNamingConvention();
        }
    }
}

