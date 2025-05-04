using System.Data;
using System.Linq.Expressions;
using campabuc.data.interfaces;
using campabuc.model;
using Dapper;
using Npgsql;

namespace campabuc.data;

public class ShoeMaterialRepository : IShoeMaterialRepository
{
    private readonly IDbConnection connection;
    public ShoeMaterialRepository(string connectionString)
    {
        connection = new NpgsqlConnection(connectionString);
    }

    public Task<int> AddShoeMaterial()
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteShoeMaterial()
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<ShoeMaterial>> Filter(Expression<Func<ShoeMaterial, bool>> predicate)
    {
        var sqlFilter = SqlPredicateBuilder.ToSqlFilter(predicate);
        if (connection.State != ConnectionState.Open)
            connection.Open();

        string query = $"SELECT * from shoe_materials WHERE {sqlFilter.Sql}";

        var result = await connection.QueryAsync<ShoeMaterial>(query, sqlFilter.Parameters);

        connection.Close();
        return result;

    }

    public async Task<ShoeMaterial> Find(object id)
    {
        if (connection.State != ConnectionState.Open)
            connection.Open();

        string query = "SELECT * from shoe_materials where id=@id";

        var item = await connection.QuerySingleAsync<ShoeMaterial>(query, new { id });

        connection.Close();
        return item;
    }

    public async Task<IEnumerable<ShoeMaterial>> GetAll()
    {
        if (connection.State != ConnectionState.Open)
            connection.Open();

        string query = "SELECT * from shoe_materials";
        var list = await connection.QueryAsync<ShoeMaterial>(query);

        connection.Close();

        return list;
    }

    public Task<bool> UpdateShoeMaterial()
    {
        throw new NotImplementedException();
    }
}
