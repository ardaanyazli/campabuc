using System.Data;
using System.Linq.Expressions;
using campabuc.data.interfaces;
using campabuc.model;
using Dapper;
using Npgsql;

namespace campabuc.data;

public class ShoeSizeRepository : IShoeSizeRepository
{
    private readonly IDbConnection connection;

    public ShoeSizeRepository(string connectionString)
    {
        connection = new NpgsqlConnection(connectionString);
    }

    public async Task<IEnumerable<ShoeSize>> Filter(Expression<Func<ShoeSize, bool>> predicate)
    {
        var sqlFilter = SqlPredicateBuilder.ToSqlFilter(predicate);

        if (connection.State != ConnectionState.Open)
            connection.Open();

        string query = $"SELECT * from shoe_sizes WHERE {sqlFilter.Sql}";

        var result = await connection.QueryAsync<ShoeSize>(query, sqlFilter.Parameters);

        connection.Close();

        return result;
    }

    public async Task<ShoeSize> Find(object id)
    {
        if (connection.State != ConnectionState.Open)
            connection.Open();

        string query = "SELECT * from shoe_sizes where id=@id";

        var item = await connection.QuerySingleAsync<ShoeSize>(query, new { id });

        connection.Close();

        return item;
    }

    public async Task<IEnumerable<ShoeSize>> GetAll()
    {
        if (connection.State != ConnectionState.Open)
            connection.Open();

        string query = "SELECT * from shoe_sizes";
        var list = await connection.QueryAsync<ShoeSize>(query);

        connection.Close();

        return list;
    }

}
