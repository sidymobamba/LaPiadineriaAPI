namespace Piadineria2.Model
{
    public class Bibita : IProdotto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Prezzo { get; set; }
    }
}
