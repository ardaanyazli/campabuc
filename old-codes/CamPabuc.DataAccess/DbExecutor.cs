using Dapper;
using System.Configuration;
using System.Data.SQLite;

namespace CamPabuc.DataAccess
{
    public class DbExecutor
    {
        private static readonly string CONNECTION_STRING = ConfigurationManager.ConnectionStrings["db"].ConnectionString;
        public static IEnumerable<T> QueryList<T>(string sql, object parameters = null)
        {
            using SQLiteConnection conn = new(CONNECTION_STRING);
            return conn.Query<T>(sql, parameters ??= new DynamicParameters());
        }

        public static IEnumerable<T> QueryAll<T>(string tableName)
        {
            using SQLiteConnection conn = new(CONNECTION_STRING);
            return conn.Query<T>($@"SELECT * FROM {tableName}");
        }

        public static T GetById<T>(string tableName, int id)
        {
            using SQLiteConnection conn = new(CONNECTION_STRING);
            return conn.QueryFirst<T>($@"SELECT * FROM {tableName} WHERE Id=@Id", new { Id = id });
        }

        public static T QueryFirst<T>(string sql, object paramters = null)
        {
            using SQLiteConnection conn = new(CONNECTION_STRING);
            return conn.Query<T>(sql, paramters ??= new DynamicParameters()).FirstOrDefault();
        }

        public static bool Insert<T>(string tableName, T model)
        {
            using SQLiteConnection conn = new(CONNECTION_STRING);
            return conn.Execute(GenerateInsertQuery(tableName, model), model) > 0;
        }

        public static bool Update<T>(string tableName, T model)
        {
            using SQLiteConnection conn = new(CONNECTION_STRING);
            return conn.Execute(GenerateUpdateQuery(tableName, model), model) > 0;
        }

        public static bool Delete(string tableName, int Id)
        {
            using SQLiteConnection conn = new(CONNECTION_STRING);
            return conn.Execute($"DELETE FROM {tableName} WHERE Id=@Id", Id) > 0;
        }

        public static bool BulkInsert<T>(string tableName, params T[] items)
        {
            using SQLiteConnection conn = new(CONNECTION_STRING);
            return conn.Execute(GenerateBulkInsertQuery(tableName, items), items) > 0;
        }

        public static bool Execute(string sql, object? param = null)
        {
            using SQLiteConnection conn = new(CONNECTION_STRING);
            return conn.Execute(sql, param) > 0;
        }

        private static string[] GetPropertyList<T>(T model)
        {
            return model.GetType().GetProperties().Select(x => x.Name).Where(p => !p.Equals("Id", StringComparison.OrdinalIgnoreCase)).ToArray();
        }

        private static string GenerateInsertQuery<T>(string tableName, T model)
        {
            var propertyList = GetPropertyList(model);
            return $@"INSERT INTO {tableName} ({string.Join(",", propertyList)}) VALUES ({string.Join(",", propertyList.Select(x => $"@{x}"))});";
        }
        
        private static string GenerateBulkInsertQuery<T>(string tableName, params T[] models)
        {
            var propertyList = GetPropertyList(models[0]);
            return $@"INSERT INTO {tableName} ({string.Join(",", propertyList)}) VALUES ({string.Join(",", propertyList.Select(x => $"@{x}"))});";
        }

        private static string GenerateUpdateQuery<T>(string tableName, T model)
        {
            var propertyList = GetPropertyList(model);
            return $@"UPDATE {tableName} SET {string.Join(",", propertyList.Select(x => $"{x} = @{x}"))} WHERE Id=@Id;";
        }
    }
}
