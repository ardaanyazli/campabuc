using System.Data;
using System.Linq.Expressions;
using campabuc.data.interfaces;
using campabuc.model;
using Dapper;
using Npgsql;

namespace campabuc.data;

public class OrderItemRepository : IOrderItemRepository
{
    private readonly IDbConnection connection;

    public OrderItemRepository(string connectionString)
    {
        connection = new NpgsqlConnection(connectionString);
    }

    public Task<int> AddOrderItem()
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteOrderItem()
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<OrderItem>> Filter(Expression<Func<OrderItem, bool>> predicate)
    {
        var sqlFilter = SqlPredicateBuilder.ToSqlFilter(predicate);

        if (connection.State != ConnectionState.Open)
            connection.Open();

        string query = $"SELECT * from order_items WHERE {sqlFilter.Sql}";

        var result = await connection.QueryAsync<OrderItem>(query, sqlFilter.Parameters);

        connection.Close();

        return result;
    }

    public async Task<OrderItem> Find(object id)
    {
        if (connection.State != ConnectionState.Open)
            connection.Open();

        string query = "SELECT * from order_items where id=@id";

        var item = await connection.QuerySingleAsync<OrderItem>(query, new { id });

        connection.Close();

        return item;
    }

    public async Task<IEnumerable<OrderItem>> GetAll()
    {
        if (connection.State != ConnectionState.Open)
            connection.Open();

        string query = "SELECT * from order_items";
        var list = await connection.QueryAsync<OrderItem>(query);

        connection.Close();

        return list;
    }

    public Task<bool> UpdateOrderItem()
    {
        throw new NotImplementedException();
    }
}
