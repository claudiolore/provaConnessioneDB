using dal.dao;
using entities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace dal
{
    public class ProdottoDaoImpl : ProdottoDao
    {
        public Prodotto Create(int id, string nome, decimal prezzo, string categoria)
        {
            return new Prodotto();
        }

        public Prodotto Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Prodotto> GetAll()
        {
            throw new NotImplementedException();
        }

        public Prodotto ReadById(int id)
        {


                try
                {
                    var connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=prova;Integrated Security=True;Encrypt=False";
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        // Open the connection
                        connection.Open();
                        Console.WriteLine("Connessione aperta con successo.");

                        // Create the SQL command
                        string sqlQuery = "SELECT Id, Nome, Prezzo, Categoria FROM Prodotti WHERE Id = @Id";
                        using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                        {
                            // Add the parameter to the SQL command
                            command.Parameters.AddWithValue("@Id", id);

                            // Execute the command and read the data
                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    Prodotto p = new Prodotto
                                    {
                                        Id = reader.GetInt32(0),
                                        Nome = reader.GetString(1),
                                        Prezzo = reader.GetDecimal(2),
                                        Categoria = reader.GetString(3)
                                    };
                                    return p;
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Exception: {ex.Message}");
                    return null;
                }
                finally
                {
                    Console.WriteLine("Esecuzione completata.");
                }
                return null; // Return null if no product is found
        }

        public Prodotto Update(int id)
        {
            throw new NotImplementedException();
        }
    }
}
