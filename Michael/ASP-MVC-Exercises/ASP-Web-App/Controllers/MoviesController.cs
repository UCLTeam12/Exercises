using Microsoft.AspNetCore.Mvc;

namespace ASP_Web_App.Controllers;

public class MoviesController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
    // GET: /HelloWorld/Welcome/
    public IActionResult Welcome(string name, int numTimes = 1)
    {
        ViewData["Message"] = "Hello " + name;
        ViewData["NumTimes"] = numTimes;

        return View();
    }
}