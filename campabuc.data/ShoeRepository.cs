using System.Data;
using System.Linq.Expressions;
using campabuc.data.interfaces;
using campabuc.model;
using Dapper;
using Npgsql;

namespace campabuc.data;

public class ShoeRepository : IShoeRepository
{
    private readonly IDbConnection connection;
    public ShoeRepository(string connectionString)
    {
        connection = new NpgsqlConnection(connectionString);
    }

    public async Task<IEnumerable<Shoe>> Filter(Expression<Func<Shoe, bool>> predicate)
    {
        var sqlFilter = SqlPredicateBuilder.ToSqlFilter(predicate);
        if (connection.State != ConnectionState.Open)
            connection.Open();

        string query = $"SELECT * from shoes WHERE {sqlFilter.Sql}";

        var result = await connection.QueryAsync<Shoe>(query, sqlFilter.Parameters);

        connection.Close();

        return result;
    }

    public async Task<Shoe> Find(object id)
    {
        if (connection.State != ConnectionState.Open)
            connection.Open();

        string query = "SELECT * from shoes where id=@id";

        var item = await connection.QuerySingleAsync<Shoe>(query, new { id });

        connection.Close();

        return item;
    }

    public async Task<IEnumerable<Shoe>> GetAll()
    {
        if (connection.State != ConnectionState.Open)
            connection.Open();

        string query = "SELECT * from shoes";
        var list = await connection.QueryAsync<Shoe>(query);

        connection.Close();

        return list;
    }
}
