namespace Infrastructure.Services;
using Dapper;
using Domain;
using Npgsql;

public class CategoriesServices
{
 
    private string _connectionString;
    public CategoriesServices()
    {
        _connectionString = "Server=127.0.0.1;Port=5432;Database=Dapper;User Id=postgres;Password=1234;";
    }

    public List<Categories> GetCategoriess()
    {
          using (NpgsqlConnection connection  = new NpgsqlConnection(_connectionString))
        {
            connection.Open();
          
            var response  = connection.Query<Categories>($"select * from Categories;").ToList();
            return response;
        }
    }

    public int AddCategoriess(Categories categories)
    {
        // Add Categoriess to database
        using (NpgsqlConnection connection  = new NpgsqlConnection(_connectionString))
        {
            connection.Open();
            string sql = $"insert into Categories (Name,BookId) values ('{categories.Name}', '{categories.BookId}')";
            var response  = connection.Execute(sql);
            return response;
        }
    }
     public int DeleteCategoriess(int id)
    {
        // Add contact to database
        using (NpgsqlConnection connection  = new NpgsqlConnection(_connectionString))
        {
            connection.Open();
            string sql = $"delete from Categories where id = '{id}';";
            var response  = connection.Execute(sql);
            return response;
        }
    }
    public int UpdateCategoriess(Categories categories)
    {
        // Add contact to database
        using (NpgsqlConnection connection  = new NpgsqlConnection(_connectionString))
        {
            connection.Open();
            string sql = $"UPDATE Categories SET Name = '{categories.Name}', BookId = '{categories.BookId}' WHERE id = {categories.id};";
            var response  = connection.Execute(sql);
            return response;
        }
    }
}

