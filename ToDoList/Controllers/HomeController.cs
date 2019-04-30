using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ToDoList.Controllers;
using ToDoList.Models;

namespace ToDoList.Controllers
{
  public class HomeController : Controller
  {

    [HttpGet("/")]
    public ActionResult Index()
    {
      List<Item> testList = new List<Item>();
      return View(testList);
    }

  }
}
