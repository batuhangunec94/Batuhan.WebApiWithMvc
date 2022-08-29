using Microsoft.EntityFrameworkCore;
using System;

namespace Batuhan.WebApi.Entities
{
    public class ApiDbContext: Microsoft.EntityFrameworkCore.DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> opt):base(opt)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(new Category[]
            {
                new Category(){Id = 1, Name = "Otomobil"}
            });
            modelBuilder.Entity<Car>().Property(x => x.Price).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<Car>().HasData(new Car[]
            {
                new(){Id = 1, Name = "Bmw M8",Price = 60000,Hp = 450,CreatedDate = DateTime.Now.AddDays(-3),CategoryId = 1},
                new(){Id=2, Name ="Ford Mustang",Price = 50000,Hp = 550,CreatedDate = DateTime.Now.AddDays(-12),CategoryId = 1},
                new(){Id = 3, Name ="Porche",Price = 130000 , Hp = 432,CreatedDate = DateTime.Now.AddDays(-36),CategoryId = 1}
            });
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
