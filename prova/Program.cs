using entities;
using dal;

ProdottoDaoImpl pdi = new ProdottoDaoImpl();
//-------------------------------------------READBYID PRODOTTO------------------------------------
//var p = pdi.ReadById(1);
//Console.WriteLine($"ID: {p.Id}, Nome: {p.Nome}, Prezzo: {p.Prezzo}, Categoria: {p.Categoria}");
//Console.WriteLine("\n\n");

//-------------------------------------------GETALL PRODOTTO--------------------------------------
//var lista = pdi.GetAll();

//Console.WriteLine("\n");
//foreach ( var item in lista )
//{
//    Console.WriteLine($"ID: {item.Id}, Nome: {item.Nome}, Prezzo: {item.Prezzo}, Categoria: {item.Categoria}");

//}
//-------------------------------------------CREEATE PRODOTTO------------------------------------
//var prodotto = pdi.Create(6, "brola", 10.00m, "persone");
//Console.WriteLine("\n");
//Console.WriteLine($"ID: {prodotto.Id}, Nome: {prodotto.Nome}, Prezzo: {prodotto.Prezzo}, Categoria: {prodotto.Categoria}");
//-------------------------------------------DELETE PRODOTTO-------------------------------------
//var p1 = pdi.Delete(6);
//var lista1 = pdi.GetAll();
//Console.WriteLine("\n");
//foreach (var item in lista1)
//{
//    Console.WriteLine($"ID: {item.Id}, Nome: {item.Nome}, Prezzo: {item.Prezzo}, Categoria: {item.Categoria}");
//}