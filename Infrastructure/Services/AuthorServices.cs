namespace Infrastructure.Services;
using Dapper;
using Domain;
using Npgsql;

public class AuthorServices
{
 
    private string _connectionString;
    public AuthorServices()
    {
        _connectionString = "Server=127.0.0.1;Port=5432;Database=Dapper;User Id=postgres;Password=1234;";
    }

    public List<Authors> GetAuthors()
    {
          using (NpgsqlConnection connection  = new NpgsqlConnection(_connectionString))
        {
            connection.Open();
          
            var response  = connection.Query<Authors>($"select * from Authors ;").ToList();
            return response;
        }
    }

    public int AddAuthor(Authors author)
    {
        // Add author to database
        using (NpgsqlConnection connection  = new NpgsqlConnection(_connectionString))
        {
            connection.Open();
            string sql = $"INSERT INTO authors (name, surname) VALUES ('{author.Name}', '{author.Surname}')";
            var response  = connection.Execute(sql);
            return response;
        }
    }
     public int DeleteAuthor(int id)
    {
        // Add contact to database
        using (NpgsqlConnection connection  = new NpgsqlConnection(_connectionString))
        {
            connection.Open();
            string sql = $"delete from authors where id = '{id}';";
            var response  = connection.Execute(sql);
            return response;
        }
    }
    public int UpdateAuthor(Authors author)
    {
        // Add contact to database
        using (NpgsqlConnection connection  = new NpgsqlConnection(_connectionString))
        {
            connection.Open();
            string sql = $"UPDATE Authors SET name = '{author.Name}', surname = '{author.Surname}' WHERE id = {author.id};";
            var response  = connection.Execute(sql);
            return response;
        }
    }
}

