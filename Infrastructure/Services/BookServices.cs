namespace Infrastructure.Services;
using Dapper;
using Domain;
using Npgsql;

public class BookServices
{
 
    private string _connectionString;
    public BookServices()
    {
        _connectionString = "Server=127.0.0.1;Port=5432;Database=Dapper;User Id=postgres;Password=1234;";
    }

    public List<Books> GetBooks()
    {
          using (NpgsqlConnection connection  = new NpgsqlConnection(_connectionString))
        {
            connection.Open();
          
            var response  = connection.Query<Books>($"select * from Books;").ToList();
            return response;
        }
    }

    public int AddBooks(Books book)
    {
        // Add Books to database
        using (NpgsqlConnection connection  = new NpgsqlConnection(_connectionString))
        {
            connection.Open();
            string sql = $"insert into books (Title,AuthorId) values ('{book.Title}', '{book.AuthorId}')";
            var response  = connection.Execute(sql);
            return response;
        }
    }
     public int DeleteBooks(int id)
    {
        // Add contact to database
        using (NpgsqlConnection connection  = new NpgsqlConnection(_connectionString))
        {
            connection.Open();
            string sql = $"delete from Books where id = '{id}';";
            var response  = connection.Execute(sql);
            return response;
        }
    }
    public int UpdateBooks(Books book)
    {
        // Add contact to database
        using (NpgsqlConnection connection  = new NpgsqlConnection(_connectionString))
        {
            connection.Open();
            string sql = $"UPDATE Books SET Title = '{book.Title}', AuthorId = '{book.AuthorId}' WHERE id = {book.id};";
            var response  = connection.Execute(sql);
            return response;
        }
    }
}

