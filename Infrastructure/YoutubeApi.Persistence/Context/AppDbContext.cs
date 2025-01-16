using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Reflection;
using YoutubeApi.Domain.Entities;


namespace YoutubeApi.Persistence.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<Brand> Brand { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Detail> Detail { get; set; }
        public DbSet<Product> Product { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer("server=CSAHIN\\MSSQLSERVER2022; database=YoutubeApi; integrated security=true; MultipleActiveResultSets=true; Trusted_Connection=True; TrustServerCertificate=True;")
                .ConfigureWarnings(warnings => warnings.Ignore(RelationalEventId.PendingModelChangesWarning)); //migration yaparken dinamik verilerden (new DateTime(), DateTime.Now, Guid.NewGuid()) kaynaklı hata vermesin diye ekledik. 

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //YoutubeApi.Persistence altında tanımladığımız ayarlamaları geçerli kılması için yazdık.
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }
    }
}