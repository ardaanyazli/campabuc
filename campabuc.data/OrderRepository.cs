using System.Data;
using System.Linq.Expressions;
using campabuc.data.interfaces;
using campabuc.model;
using Dapper;
using Npgsql;

namespace campabuc.data;

public class OrderRepository : IOrderRepository
{
    private readonly IDbConnection connection;

    public OrderRepository(string connectionString)
    {
        connection = new NpgsqlConnection(connectionString);
    }

    public async Task<IEnumerable<Order>> Filter(Expression<Func<Order, bool>> predicate)
    {
        var sqlFilter = SqlPredicateBuilder.ToSqlFilter(predicate);

        if (connection.State != ConnectionState.Open)
            connection.Open();

        string query = $"SELECT * from orders WHERE {sqlFilter.Sql}";

        var result = await connection.QueryAsync<Order>(query, sqlFilter.Parameters);

        connection.Close();

        return result;
    }

    public async Task<Order> Find(object id)
    {
        if (connection.State != ConnectionState.Open)
            connection.Open();

        string query = "SELECT * from orders where id=@id";

        var item = await connection.QuerySingleAsync<Order>(query, new { id });

        connection.Close();

        return item;
    }

    public async Task<IEnumerable<Order>> GetAll()
    {
        if (connection.State != ConnectionState.Open)
            connection.Open();

        string query = "SELECT * from orders";
        var list = await connection.QueryAsync<Order>(query);

        connection.Close();

        return list;
    }

}
