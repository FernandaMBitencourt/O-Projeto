using Npgsql;

public class DbConnection
{
    public NpgsqlConnection Connection { get; set; }
    public string ConnectionString { get; } 

    public DbConnection()
    {
        string connectionString = "Host=localhost;Port=5432;Database=postgres;Username=fernandabitencourt";
        Connection = new NpgsqlConnection(connectionString);
        Connection.Open();
    }
    
    public void Dispose()
    {
        Connection.Dispose();
    }
}
