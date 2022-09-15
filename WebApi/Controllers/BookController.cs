using Domain;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;
[ApiController]
[Route("[controller]")]

public class BookController:ControllerBase
{
 private BookServices _bookService;
 public BookController()
 {
    _bookService = new BookServices();
 }

 [HttpGet]
 public List<Books> GetBookss()
 {
   return _bookService.GetBooks();
 }
 

 [HttpPost]
public int  AddBooks(Books book)
{
   return _bookService.AddBooks(book);
}

[HttpPut]
public int UpdateBooks(Books book)
{
   return _bookService.UpdateBooks(book);
}

[HttpDelete]
public int DeleteBooks(int id)
{
 return _bookService.DeleteBooks(id);
}

}
