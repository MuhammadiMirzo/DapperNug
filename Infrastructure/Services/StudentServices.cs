namespace Infrastructure.Services;
using Dapper;
using Domain;
using Npgsql;

public class StudentServices
{
 
    private string _connectionString;
    public StudentServices()
    {
        _connectionString = "Server=127.0.0.1;Port=5432;Database=Dapper;User Id=postgres;Password=1234;";
    }

    public List<Students> GetStudents()
    {
          using (NpgsqlConnection connection  = new NpgsqlConnection(_connectionString))
        {
            connection.Open();
          
            var response  = connection.Query<Students>($"select * from Students;").ToList();
            return response;
        }
    }

    public int AddStudents(Students student)
    {
        // Add Students to database
        using (NpgsqlConnection connection  = new NpgsqlConnection(_connectionString))
        {
            connection.Open();
            string sql = $"insert into Students (Firstname,Lastname,FatherName,BirthDate) values ('{student.Firstname}', '{student.Lastname}','{student.FatherName}','{student.BirthDate}')";
            var response  = connection.Execute(sql);
            return response;
        }
    }
     public int DeleteStudents(int id)
    {
        // Add contact to database
        using (NpgsqlConnection connection  = new NpgsqlConnection(_connectionString))
        {
            connection.Open();
            string sql = $"delete from Students where id = '{id}';";
            var response  = connection.Execute(sql);
            return response;
        }
    }
    public int UpdateStudents(Students student)
    {
        // Add contact to database
        using (NpgsqlConnection connection  = new NpgsqlConnection(_connectionString))
        {
            connection.Open();
            string sql = $"UPDATE Students SET Firstname = '{student.Firstname}',Lastname='{student.Lastname}',FatherName='{student.FatherName}',BirthDate='{student.BirthDate}'  WHERE id = {student.id};";
            var response  = connection.Execute(sql);
            return response;
        }
    }
}

