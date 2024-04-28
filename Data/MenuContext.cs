using Microsoft.EntityFrameworkCore;
using TestCoreApp.Models;
namespace TestCoreApp.Data
{
    public class MenuContext : DbContext
    {
        public MenuContext(DbContextOptions<MenuContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DishIngredient>().HasKey(di => new
            {
                DishId = di.DishId,
                IngredientId = di.IngredientId
            });
            modelBuilder.Entity<DishIngredient>()
                .HasOne(di => di.Dish)
                .WithMany(d => d.DishIngredient) // Assuming there's a collection property named DishIngredients in Dish entity
                .HasForeignKey(di => di.DishId);

            modelBuilder.Entity<DishIngredient>()
                .HasOne(di => di.Ingredient)
                .WithMany(i => i.DishIngredient) // Assuming there's a collection property named DishIngredients in Ingredient entity
                .HasForeignKey(di => di.IngredientId);

            modelBuilder.Entity<Dish>().HasData(new Dish

            {
                Id = 1,
                Name = "Margherita",
                Price = 7.5,
                ImageUrl = "https://images.ctfassets.net/nw5k25xfqsik/64VwvKFqxMWQORE10Tn8pY/200c0538099dc4d1cf62fd07ce59c2af/20220211142754-margherita-9920.jpg?w=1024"

            });
            modelBuilder.Entity<Dish>().HasData(new Dish

            {
                Id = 2,
                Name = "Pepperoni",
                Price = 12.5,
                ImageUrl = "https://sp-ao.shortpixel.ai/client/to_webp,q_lossless,ret_img,w_509/https://distinctivecatering.net/wp-content/uploads/2024/01/Pepperoni-Pizza.jpg"

            });
            modelBuilder.Entity<Ingredient>().HasData(
                new Ingredient { Id = 1, Name = "Tomato Sauce" },
                new Ingredient { Id = 2, Name = "Mozzarella" },
                new Ingredient { Id = 3, Name = "Cheese" },
                new Ingredient { Id = 4, Name = "Pepperoni" }
                );
            modelBuilder.Entity<DishIngredient>().HasData(
                new DishIngredient { DishId = 1, IngredientId = 1 },
                new DishIngredient { DishId = 1, IngredientId = 2 },
                new DishIngredient { DishId = 2, IngredientId = 3 },
                new DishIngredient { DishId = 2, IngredientId = 4 }



                );
            base.OnModelCreating(modelBuilder);

        }
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<DishIngredient> DishIngredients { get; set; }
    }
}