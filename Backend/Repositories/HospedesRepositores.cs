using System;
using System.Collections.Generic;
using System.Data.SqlClient;

public class HospedeRepository
{
    private string connectionString;

    public HospedeRepository(string connectionString)
    {
        this.connectionString = connectionString;
    }

    public void AdicionarHospede(Hospede hospede)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = "INSERT INTO Hospedes (Nome, Email, Telefone, DataCheckIn, DataCheckOut) " +
                           "VALUES (@Nome, @Email, @Telefone, @DataCheckIn, @DataCheckOut)";
            
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Nome", hospede.Nome);
            command.Parameters.AddWithValue("@Email", hospede.Email);
            command.Parameters.AddWithValue("@Telefone", hospede.Telefone);
            command.Parameters.AddWithValue("@DataCheckIn", hospede.DataCheckIn);
            command.Parameters.AddWithValue("@DataCheckOut", hospede.DataCheckOut);
            
            connection.Open();
            command.ExecuteNonQuery();
        }
    }

    // Adicione métodos para outras operações CRUD conforme necessário
}
