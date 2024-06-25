namespace dal.dao
{
    using entities;
    public interface ProdottoDao
    {
        Prodotto Create(int id, string nome, decimal prezzo, string categoria);
        Prodotto Update(int id);
        Prodotto ReadById(int id);
        List<Prodotto> GetAll();
        Prodotto Delete(int id);



    }
}
