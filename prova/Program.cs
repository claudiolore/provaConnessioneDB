using entities;
using dal;

ProdottoDaoImpl pdi = new ProdottoDaoImpl();

var p = pdi.ReadById(2);

Console.WriteLine($"ID: {p.Id}, Nome: {p.Nome}, Prezzo: {p.Prezzo}, Categoria: {p.Categoria}");
Console.WriteLine("\n\n");
var lista = pdi.GetAll();

foreach ( var item in lista )
{
    Console.WriteLine($"ID: {item.Id}, Nome: {item.Nome}, Prezzo: {item.Prezzo}, Categoria: {item.Categoria}");

}