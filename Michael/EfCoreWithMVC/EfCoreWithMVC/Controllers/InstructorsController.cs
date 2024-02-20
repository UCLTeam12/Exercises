using Microsoft.AspNetCore.Mvc;

namespace EfCoreWithMVC.Controllers;

public class InstructorsController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}