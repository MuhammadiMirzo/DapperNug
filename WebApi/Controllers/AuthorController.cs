using Domain;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]

public class AuthorController : ControllerBase
{
    
 private AuthorServices _authorService;
 public AuthorController()
 {
    _authorService = new AuthorServices();
 }
 

 [HttpGet]
 public List<Authors> GetAuthors()
 {
   return _authorService.GetAuthors();
 }
 

 [HttpPost]
public int  AddAuthor(Authors author)
{
   return _authorService.AddAuthor(author);
}

[HttpPut]
public int UpdateAuthor(Authors author)
{
   return _authorService.UpdateAuthor(author);
}

[HttpDelete]
public int DeleteAuthor(int id)
{
 return _authorService.DeleteAuthor(id);
}
}



