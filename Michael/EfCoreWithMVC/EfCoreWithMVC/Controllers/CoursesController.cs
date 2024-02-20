using Microsoft.AspNetCore.Mvc;

namespace EfCoreWithMVC.Controllers;

public class CoursesController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}