using Piadineria2.Repositories;

namespace Piadineria2.Model
{
    public class ProductRepository : IProductRepository
    {
        private List<Snack> snacks;
        private List<Bibita> bibite;
        private List<Piadina> piadine;

        public ProductRepository()
        {
            InitializeProducts();
        }

        private void InitializeProducts()
        {
            snacks = new List<Snack>
            {
                new Snack { Id = 1, Nome = "Patatine", Prezzo = 2.50m },
                new Snack { Id = 2, Nome = "Popcorn", Prezzo = 3.00m },
                new Snack { Id = 3, Nome = "Salsa", Prezzo = 5.00m }
            };

            bibite = new List<Bibita>
            {
                new Bibita { Id = 1, Nome = "Coca Cola", Prezzo = 2.00m },
                new Bibita { Id = 2, Nome = "Fanta", Prezzo = 2.00m }
            };

            piadine = new List<Piadina>
            {
                new Piadina
                {
                    Id = 1,
                    Nome = "Piadina Prosciutto e Formaggio",
                    Prezzo = 5.50m,
                    Ingredienti = new List<string> { "Prosciutto", "Formaggio" },
                    Forma = "Aperta"
                },
                new Piadina
                {
                    Id = 2,
                    Nome = "Piadina Tacchino e Maionese",
                    Prezzo = 6.00m,
                    Ingredienti = new List<string> { "Tacchino", "Maionese" },
                    Forma = "Aperta"
                }
            };
        }

        public List<Snack> GetAllSnacks()
        {
            return snacks;
        }

        public List<Bibita> GetAllBibite()
        {
            return bibite;
        }

        public List<Piadina> GetAllPiadine()
        {
            return piadine;
        }
    }
}
