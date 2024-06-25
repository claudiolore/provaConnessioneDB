namespace entities
{
    public class Prodotto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public Decimal Prezzo { get; set; }
        public string Categoria { get; set; }
        public Prodotto()
        {
            
        }
        public Prodotto(int id, string nome, Decimal prezzo, string categoria)
        {
            Id = id;
            Nome = nome;
            Prezzo = prezzo;
            Categoria = categoria;
        }

    }
}
