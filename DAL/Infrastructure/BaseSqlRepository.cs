using Microsoft.Data.SqlClient;

namespace DAL.Infrastructure;

public abstract class BaseSqlRepository
{
    private readonly string _connectionString;

    internal BaseSqlRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    protected SqlConnection OpenConnection()
    {
        var con = new SqlConnection(_connectionString);
        con.Open();
        return con;
    }
}