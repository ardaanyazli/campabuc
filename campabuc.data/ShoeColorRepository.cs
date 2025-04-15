using System.Data;
using System.Linq.Expressions;
using campabuc.data.interfaces;
using campabuc.model;
using Dapper;
using Npgsql;

namespace campabuc.data;

public class ShoeColorRepository : IShoeColorRepository
{
    private readonly IDbConnection connection;
    public ShoeColorRepository(string connectionString)
    {
        connection = new NpgsqlConnection(connectionString);
    }

    public async Task<IEnumerable<ShoeColor>> Filter(Expression<Func<ShoeColor, bool>> predicate)
    {
        var sqlFilter = SqlPredicateBuilder.ToSqlFilter(predicate);
        if (connection.State != ConnectionState.Open)
            connection.Open();

        string query = $"SELECT * from shoe_colors WHERE {sqlFilter.Sql}";

        var result = await connection.QueryAsync<ShoeColor>(query, sqlFilter.Parameters);

        connection.Close();
        return result;

    }

    public async Task<ShoeColor> Find(object id)
    {
        if (connection.State != ConnectionState.Open)
            connection.Open();

        string query = "SELECT * from shoe_colors where id=@id";

        var item = await connection.QuerySingleAsync<ShoeColor>(query, new { id });

        connection.Close();
        return item;
    }


    public async Task<IEnumerable<ShoeColor>> GetAll()
    {
        if (connection.State != ConnectionState.Open)
            connection.Open();

        string query = "SELECT * from shoe_colors";
        var list = await connection.QueryAsync<ShoeColor>(query);

        connection.Close();

        return list;
    }

}
