using entities;
using dal;



ProdottoDaoImpl pdi = new ProdottoDaoImpl();

var p = pdi.ReadById(2);

Console.WriteLine($"ID: {p.Id}, Nome: {p.Nome}, Prezzo: {p.Prezzo}, Categoria: {p.Categoria}");