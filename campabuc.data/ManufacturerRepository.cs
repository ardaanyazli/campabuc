using System.Data;
using System.Linq.Expressions;
using campabuc.data.interfaces;
using campabuc.model;
using Dapper;
using Npgsql;

namespace campabuc.data;

public class ManufacturerRepository : IManufacturerRepository
{
    private readonly IDbConnection connection;

    public ManufacturerRepository(string connectionString)
    {
        connection = new NpgsqlConnection(connectionString);
    }

    public async Task<IEnumerable<Manufacturer>> Filter(Expression<Func<Manufacturer, bool>> predicate)
    {
        var sqlFilter = SqlPredicateBuilder.ToSqlFilter(predicate);

        if (connection.State != ConnectionState.Open)
            connection.Open();

        string query = $"SELECT * from manufacturers WHERE {sqlFilter.Sql}";

        var result = await connection.QueryAsync<Manufacturer>(query, sqlFilter.Parameters);

        connection.Close();

        return result;
    }

    public async Task<Manufacturer> Find(object id)
    {
        if (connection.State != ConnectionState.Open)
            connection.Open();

        string query = "SELECT * from manufacturers where id=@id";

        var item = await connection.QuerySingleAsync<Manufacturer>(query, new { id });

        connection.Close();

        return item;
    }

    public async Task<IEnumerable<Manufacturer>> GetAll()
    {
        if (connection.State != ConnectionState.Open)
            connection.Open();

        string query = "SELECT * from manufacturers";
        var list = await connection.QueryAsync<Manufacturer>(query);

        connection.Close();

        return list;
    }

}
