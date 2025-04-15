using System.Data;
using System.Linq.Expressions;
using campabuc.data.interfaces;
using campabuc.model;
using Dapper;
using Npgsql;

namespace campabuc.data;

public class ManufacturerRepository : IManufacturerRepository
{
    const string BASE_SELECT_QUERY = "SELECT id as Id,\"name\" as Name,address as Address,phone as Phone, contact_name as ContactName,created_at as CreatedAt,deleted_at as DeletedAt from manufacturers";
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

        string query = $"{BASE_SELECT_QUERY} WHERE {sqlFilter.Sql}";

        var result = await connection.QueryAsync<Manufacturer>(query, sqlFilter.Parameters);

        connection.Close();

        return result;
    }

    public async Task<Manufacturer> Find(object id)
    {
        if (connection.State != ConnectionState.Open)
            connection.Open();

        string query = $"{BASE_SELECT_QUERY} WHERE id=@id";

        var item = await connection.QuerySingleAsync<Manufacturer>(query, new { id });

        connection.Close();

        return item;
    }

    public async Task<IEnumerable<Manufacturer>> GetAll()
    {
        if (connection.State != ConnectionState.Open)
            connection.Open();

        var list = await connection.QueryAsync<Manufacturer>(BASE_SELECT_QUERY);

        connection.Close();

        return list;
    }

    public async Task<int> AddManufacturer(string name, string? address, string? phone, string? contact_name)
    {
        Dictionary<string, object> paramList = new Dictionary<string, object>();
        paramList.Add("\"name\"", name);

        if (!string.IsNullOrWhiteSpace(address))
        {
            paramList.Add("address", address);
        }
        if (!string.IsNullOrWhiteSpace(phone))
        {
            paramList.Add("phone", phone);
        }
        if (!string.IsNullOrWhiteSpace(contact_name))
        {
            paramList.Add("contact_name", contact_name);
        }

        string query = $"INSERT INTO manufacturers ({string.Join(",", paramList.Keys)}) VALUES ({string.Join(",", paramList.Keys.Select(x => x.Trim('"').Insert(0, "@")}) returning id";

        connection.ExecuteScalarAsync<int>(query, new { name, address, phone, contact_name });

    }

    public async Task<bool> UpdateManufacturer()
    {
        throw new NotImplementedException();
    }

    public async Task<bool> DeleteManufacturer()
    {
        throw new NotImplementedException();
    }
}
