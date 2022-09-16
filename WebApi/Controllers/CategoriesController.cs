using Domain;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;
[ApiController]
[Route("[controller]")]

public class CategoriesController:ControllerBase
{
 private CategoriesServices _categoriesService;
 public CategoriesController()
 {
    _categoriesService = new CategoriesServices();
 }

 [HttpGet]
 public List<Categories> GetCategoriess()
 {
   return _categoriesService.GetCategoriess();
 }
 

 [HttpPost]
public int  AddCategoriess(Categories categories)
{
   return _categoriesService.AddCategoriess(categories);
}

[HttpPut]
public int UpdateCategoriess(Categories categories)
{
   return _categoriesService.UpdateCategoriess(categories);
}

[HttpDelete]
public int DeleteCategoriess(int id)
{
 return _categoriesService.DeleteCategoriess(id);
}

}
