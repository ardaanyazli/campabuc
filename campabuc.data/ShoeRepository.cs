using System.Data;
using System.Linq.Expressions;
using campabuc.data.interfaces;
using campabuc.model;
using Dapper;
using Npgsql;

namespace campabuc.data;

public class ShoeRepository : IShoeRepository
{
    const string BASE_SELECT_QUERY = """
		SELECT  
		id as Id,
		category AS Category,
		material AS Material,
		color AS Color,
		size AS Size,
		manufacturer AS Manufacturer,
		price AS Price,
		inventory AS Inventory,
		created_at AS CreatedAt,
		deleted_at AS DeletedAt,
		barcode AS Barcode,
		img_url AS ImageUrl
		FROM shoes
		""";
    private readonly IDbConnection connection;
    public ShoeRepository(string connectionString)
    {
        connection = new NpgsqlConnection(connectionString);
    }

    public Task<int> AddShoe()
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteShoe()
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Shoe>> Filter(Expression<Func<Shoe, bool>> predicate)
    {
        var sqlFilter = SqlPredicateBuilder.ToSqlFilter(predicate);
        if (connection.State != ConnectionState.Open)
            connection.Open();

        string query = $"{BASE_SELECT_QUERY} WHERE {sqlFilter.Sql}";

        var result = await connection.QueryAsync<Shoe>(query, sqlFilter.Parameters);

        connection.Close();

        return result;
    }

    public async Task<Shoe> Find(object id)
    {
        if (connection.State != ConnectionState.Open)
            connection.Open();

        string query = $"{BASE_SELECT_QUERY} WHERE id=@id";

        var item = await connection.QuerySingleAsync<Shoe>(query, new { id });

        connection.Close();

        return item;
    }

    public async Task<IEnumerable<Shoe>> GetAll()
    {
        if (connection.State != ConnectionState.Open)
            connection.Open();

        var list = await connection.QueryAsync<Shoe>(BASE_SELECT_QUERY);

        connection.Close();

        return list;
    }

    public Task<bool> UpdateShoe()
    {
        throw new NotImplementedException();
    }
}
