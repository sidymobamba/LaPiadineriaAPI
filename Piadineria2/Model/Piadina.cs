namespace Piadineria2.Model
{
    public class Piadina : IProdotto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Prezzo { get; set; }
        public List<string> Ingredienti { get; set; }
        public string Forma { get; set; }
    }
}
