namespace Piadineria2.Dto
{
    public class PiadinaWithIngredients
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Prezzo { get; set; }
        public string Forma { get; set; }
        public List<string> Ingredients { get; set; }
    }
}
