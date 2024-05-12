using Backend.Models;
using Npgsql;
using System;

namespace Backend.DataAccess
{
    public class QuartoRepository
    {
        private readonly string _connectionString;

        public QuartoRepository(string connectionString)
        {
            _connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
        }

        public void CriarQuarto(Quarto quarto)
        {
            if (quarto == null)
            {
                throw new ArgumentNullException(nameof(quarto));
            }

            string query = "INSERT INTO Quartos (Numero, Tipo, Diaria, Disponivel) " +
                           "VALUES (@Numero, @Tipo, @Diaria, @Disponivel)";

            using (NpgsqlConnection connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();

                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Numero", quarto.Numero);
                    command.Parameters.AddWithValue("@Tipo", quarto.Tipo);
                    command.Parameters.AddWithValue("@Diaria", quarto.Diaria);
                    command.Parameters.AddWithValue("@Disponivel", quarto.Disponivel);

                    command.ExecuteNonQuery();
                }
            }
        }

        public Quarto ObterQuartoPorNumero(string numero)
        {
            if (string.IsNullOrEmpty(numero))
            {
                throw new ArgumentException("O número do quarto não pode ser vazio ou nulo.", nameof(numero));
            }

            string query = "SELECT * FROM Quartos WHERE Numero = @Numero";

            using (NpgsqlConnection connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();

                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Numero", numero);

                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Mapeie os dados do resultado para um objeto Quarto
                            Quarto quarto = new Quarto
                            {
                                Numero = reader["Numero"] != DBNull.Value ? Convert.ToInt32(reader["Numero"]) : (int?)null,
                                Tipo = reader["Tipo"].ToString(),
                                Diaria = Convert.ToDecimal(reader["Diaria"]),
                                Disponivel = Convert.ToBoolean(reader["Disponivel"])
                            };

                            return quarto;
                        }
                        else
                        {
                            // Se nenhum quarto for encontrado com o número especificado, retorne null
                            return null;
                        }
                    }
                }
            }
        }

    }
}
