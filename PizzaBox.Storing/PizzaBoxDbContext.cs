using Microsoft.EntityFrameworkCore;
using PizzaBox.Domain.Models;

namespace PizzaBox.Storing
{
    public class PizzaBoxDbContext : DbContext
    {
        private static PizzaBoxDbContext instance;

        private PizzaBoxDbContext()
        {
            
        }

        public static PizzaBoxDbContext Instance()
        {
            if (instance == null)
            {
               instance = new PizzaBoxDbContext();
            }
            return instance;
        }



        public DbSet<PizzaModel> Pizzas { get; set; } //create table

        public DbSet<UserModel> Users { get; set; }

        public DbSet<OrderModel> Orders { get; set; }

        public DbSet<StoreModel> Store { get; set; }

        public DbSet<CrustModel> Crust {get; set;}
        public DbSet<SizeModel> Size {get; set;}
        public DbSet<ToppingModel> Toppings {get; set;}

        public PizzaBoxDbContext(DbContextOptions options) : base(options) { } //dependency injection

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<PizzaModel>().HasKey(e => e.Id); //primary constraint
            builder.Entity<CrustModel>().HasKey(e => e.Id);
            builder.Entity<SizeModel>().HasKey(e => e.Id);
            builder.Entity<ToppingModel>().HasKey(e => e.Id);
            builder.Entity<UserModel>().HasKey(e => e.Id);
            builder.Entity<OrderModel>().HasKey(e => e.Id);
            builder.Entity<StoreModel>().HasKey(e => e.Id);
        }
    }
}