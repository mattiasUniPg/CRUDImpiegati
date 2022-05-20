using CRUDImpiegati.Models;
using System.Data.SqlClient;

namespace CRUDImpiegati.Repository
{
    public class DBManager
    {
        private static string connectionString = @"Server = ACADEMYNETPD04\SQLEXPRESS; Database = Impiegati; Trusted_Connection = True;";

        public List<ImpiegatoViewModel> GetAllImpiegati()
        {
            List<ImpiegatoViewModel> impiegatiList = new List<ImpiegatoViewModel>();
            string sql = @"Select * from Impiegato";

            using var connection = new SqlConnection(connectionString);
            connection.Open();
            using var command = new SqlCommand(sql, connection);
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                var impiegato = new ImpiegatoViewModel
                {
                    ID = Convert.ToInt32(reader["ID"]),
                    Nome = reader["Nome"].ToString(),
                    Cognome = reader["Cognome"].ToString(),
                    Città = reader["Citta"].ToString(),
                    Salario =Decimal.Parse(reader["Salario"].ToString())
                };
                impiegatiList.Add(impiegato);
            }
            return impiegatiList;
        }

        public int EditImpiegato(ImpiegatoViewModel impiegato)
        {
            string sql = @"UPDATE Impiegato
                       SET [Nome] = @Nome
                          ,[Cognome] = @Cognome
                          ,[Salario] = @Salario
                          ,[Citta] = @Citta
                     WHERE ID =@ID";
            using var connection = new SqlConnection(connectionString);
            connection.Open();
            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@Nome", impiegato.Nome);
            command.Parameters.AddWithValue("@Cognome", impiegato.Cognome);
            command.Parameters.AddWithValue("@Citta", impiegato.Città);
            command.Parameters.AddWithValue("@Salario", impiegato.Salario);
            command.Parameters.AddWithValue("@ID", impiegato.ID);

            return command.ExecuteNonQuery();
        }
        public int AggiungiImpiegato(ImpiegatoViewModel impiegato)
        {
            string sql = @"INSERT INTO Impiegato
            ([Nome]
           ,[Cognome]
           ,[Citta]
           ,[Salario])
                       VALUES (@Nome,@Cognome,@Citta,@Salario) ";
            using var connection = new SqlConnection(connectionString);
            connection.Open();
            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@Nome", impiegato.Nome);
            command.Parameters.AddWithValue("@Cognome", impiegato.Cognome);
            command.Parameters.AddWithValue("@Citta", impiegato.Città);
            command.Parameters.AddWithValue("@Salario", impiegato.Salario);

            return command.ExecuteNonQuery();
        }
        public int VisualizzaImpiegato(ImpiegatoViewModel impiegato)
        {
            string sql = @"Select * from Impiegato WHERE ID =@ID ";
            using var connection = new SqlConnection(connectionString);
            connection.Open();
            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@Nome", impiegato.Nome);
            command.Parameters.AddWithValue("@Cognome", impiegato.Cognome);
            command.Parameters.AddWithValue("@Citta", impiegato.Città);
            command.Parameters.AddWithValue("@Salario", impiegato.Salario);
            command.Parameters.AddWithValue("@ID", impiegato.ID);

            return command.ExecuteNonQuery();
        }
        public int CancellaImpiegato(ImpiegatoViewModel impiegato)
        {
            string sql = @"DELETE FROM [dbo].[Impiegato] WHERE ID =@ID ";
            using var connection = new SqlConnection(connectionString);
            connection.Open();
            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@Nome", impiegato.Nome);
            command.Parameters.AddWithValue("@Cognome", impiegato.Cognome);
            command.Parameters.AddWithValue("@Citta", impiegato.Città);
            command.Parameters.AddWithValue("@Salario", impiegato.Salario);
            command.Parameters.AddWithValue("@ID", impiegato.ID);

            return command.ExecuteNonQuery();
        }

    }

}