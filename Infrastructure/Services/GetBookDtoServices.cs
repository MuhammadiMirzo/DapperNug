namespace Infrastructure.Services;
using Dapper;
using Domain.Dtos;
using Npgsql;

public class GetBookDtoServices
{
 
    private string _connectionString;
    public GetBookDtoServices()
    {
        _connectionString = "Server=127.0.0.1;Port=5432;Database=Dapper;User Id=postgres;Password=1234;";
    }

    public List<GetBookDto> GetGetBookDtos()
    {
          using (NpgsqlConnection connection  = new NpgsqlConnection(_connectionString))
        {
            connection.Open();
        
            var response  = connection.Query<GetBookDto>($"select b.id,b.Title,concat(a.Name,' ',a.Surname) as AuthorFullName from books as b join authors as a on b.authorid = a.id;").ToList();
            return response;
        }
    }

   }

