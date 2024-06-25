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
        private string connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=prova;Integrated Security=True;Encrypt=False";

        //--------------------------------------------------------------------------------------
        public Prodotto Create(int id, string nome, decimal prezzo, string categoria)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    Console.WriteLine("Connessione aperta con successo");

                    string query = "INSERT INTO Prodotti (Id, Nome, Prezzo, Categoria) VALUES (@Id, @Nome, @Prezzo, @Categoria)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Id", id);
                        command.Parameters.AddWithValue("@Nome", nome);
                        command.Parameters.AddWithValue("@Prezzo", prezzo);
                        command.Parameters.AddWithValue("@Categoria", categoria);

                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            return new Prodotto
                            {
                                Id = id,
                                Nome = nome,
                                Prezzo = prezzo,
                                Categoria = categoria
                            };
                        }
                        else
                        {
                            throw new Exception("No rows affected.");
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
        }
        //--------------------------------------------------------------------------------------

        public List<Prodotto> GetAll()
        {
            try
            {
                List<Prodotto> listProdotti = new();
                var query = "SELECT * FROM Prodotti";

                using(var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    Console.WriteLine("Connessione aperta con successo");

                    var command = new SqlCommand(query,connection);
                    var reader = command.ExecuteReader();

                    while (reader.Read()) 
                    {
                        var p = new Prodotto();
                        
                        p.Id = (int)reader[0];   
                        p.Nome = (string)reader[1] ?? string.Empty;
                        p.Prezzo = (decimal)reader[2];
                        p.Categoria = (string)reader[3] ?? string.Empty;

                        listProdotti.Add(p);
                    }
                    connection.Close();
                }
                return listProdotti;
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
        }

//--------------------------------------------------------------------------------------
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

//--------------------------------------------------------------------------------------
        public Prodotto Update(int id)
        {
            throw new NotImplementedException();
        }
        //--------------------------------------------------------------------------------------
        public Prodotto Delete(int id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    Console.WriteLine("Connessione aperta con successo.");

                    string sqlQuery = "DELETE FROM Prodotti WHERE Id = @Id";
                    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Id", id);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            Console.WriteLine("Prodotto eliminato con successo.");
                            return new Prodotto { Id = id };
                        }
                        else
                        {
                            Console.WriteLine("Nessun prodotto trovato con l'ID specificato.");
                            return null;
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
        }

        //--------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------
    }
}
