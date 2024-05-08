using System;
using System.Collections.Generic;
using System.Data.SqlClient;

public class QuartoRepository
{
    private string connectionString;

    public QuartoRepository(string connectionString)
    {
        this.connectionString = connectionString;
    }

    public void CriarQuarto(string numero, string tipo, decimal precoDiaria, bool disponivel)
    {
        string query = "INSERT INTO Quartos (Numero, Tipo, PrecoDiaria, Disponivel) " +
                       "VALUES (@Numero, @Tipo, @PrecoDiaria, @Disponivel)";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Numero", numero);
            command.Parameters.AddWithValue("@Tipo", tipo);
            command.Parameters.AddWithValue("@PrecoDiaria", precoDiaria);
            command.Parameters.AddWithValue("@Disponivel", disponivel);

            connection.Open();
            command.ExecuteNonQuery();
        }
    }

    // Adicione métodos para outras operações CRUD conforme necessário
}
