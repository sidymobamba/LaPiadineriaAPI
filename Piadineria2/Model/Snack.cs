namespace Piadineria2.Model
{
    public class Snack : IProdotto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Prezzo { get; set; }
    }
}
