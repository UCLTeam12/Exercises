using Microsoft.AspNetCore.Mvc;

namespace EfCoreWithMVC.Controllers;

public class DepartmentsController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}