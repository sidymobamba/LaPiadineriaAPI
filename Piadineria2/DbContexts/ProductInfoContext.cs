using Microsoft.EntityFrameworkCore;
using Piadineria2.Entities;

namespace Piadineria2.DbContexts
{
    public class ProductInfoContext : DbContext
    {
        public DbSet<BibitaEntity> Bibite { get; set; } = null!;
        public DbSet<SnackEntity> Snacks { get; set; } = null!;
        public DbSet<PiadinaEntity> Piadine { get; set; } = null!;
        public DbSet<IngredientEntity> Ingredients { get; set; } = null!;

        public ProductInfoContext(DbContextOptions<ProductInfoContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BibitaEntity>().HasData(
                new BibitaEntity()
                {
                    Id = 1,
                    Nome = "Coca Cola",
                    Prezzo = 2.00m,
                    Sku = Guid.NewGuid().ToString()[^4..],
                },
                new BibitaEntity()
                {
                    Id = 2,
                    Nome = "Fanta",
                    Prezzo = 2.00m,
                    Sku = Guid.NewGuid().ToString()[^4..]
                },
                new BibitaEntity()
                {
                    Id = 3,
                    Nome = "Pepsi",
                    Prezzo = 2.50m,
                    Sku = Guid.NewGuid().ToString()[^4..]
                }
                );

            modelBuilder.Entity<SnackEntity>().HasData(
                new SnackEntity()
                {
                    Id = 1,
                    Nome = "Patatine",
                    Prezzo = 2.50m,
                    Sku = Guid.NewGuid().ToString()[^4..]
                },
                new SnackEntity()
                {
                    Id = 2,
                    Nome = "Popcorn",
                    Prezzo = 5.00m,
                    Sku =Guid.NewGuid().ToString()[^4..]
                },
                new SnackEntity()
                {
                    Id = 3,
                    Nome = "Salsa",
                    Prezzo = 2.00m,
                    Sku = Guid.NewGuid().ToString()[^4..]
                }
                );
            modelBuilder.Entity<PiadinaEntity>().HasData(
                 new PiadinaEntity
                 {
                     Id = 1,
                     Nome = "Piadina Prosciutto e Formaggio",
                     Prezzo = 5.50m,
                     Forma = "Aperta"
                     },
                 new PiadinaEntity
                 {
                     Id = 2,
                     Nome = "Piadina Tacchino e Maionese",
                     Prezzo = 6.00m,
                     Forma = "Rotolo"
                 },
                 new PiadinaEntity
                 {
                     Id = 3,
                     Nome = "Piadina MegaTwist",
                     Prezzo = 7.00m,
                     Forma = "Aperta"
                 }
                );

            modelBuilder.Entity<IngredientEntity>().HasData(
                new IngredientEntity { Id = 1, Name = "Prosciutto", PiadinaId = 1 }, 
                new IngredientEntity { Id = 2, Name = "Formaggio", PiadinaId = 1 },  
                new IngredientEntity { Id = 3, Name = "Tacchino", PiadinaId = 2 },   
                new IngredientEntity { Id = 4, Name = "Maionese", PiadinaId = 2 },    
                new IngredientEntity { Id = 5, Name = "Tacchino", PiadinaId = 3 },   
                new IngredientEntity { Id = 6, Name = "Maionese", PiadinaId = 3 },    
                new IngredientEntity { Id = 7, Name = "Formaggio", PiadinaId = 3 }    
            );
        }
    }

    
}
