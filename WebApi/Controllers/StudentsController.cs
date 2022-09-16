using Domain;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;
[ApiController]
[Route("[controller]")]

public class StudentController:ControllerBase
{
 private StudentServices _studentService;
 public StudentController()
 {
    _studentService = new StudentServices();
 }

 [HttpGet]
 public List<Students> GetStudents()
 {
   return _studentService.GetStudents();
 }
 

 [HttpPost]
public int  AddStudents(Students student)
{
   return _studentService.AddStudents(student);
}

[HttpPut]
public int UpdateStudents(Students student)
{
   return _studentService.UpdateStudents(student);
}

[HttpDelete]
public int DeleteStudents(int id)
{
 return _studentService.DeleteStudents(id);
}

}
