using Microsoft.AspNetCore.Mvc;

namespace ASP_Web_App.Controllers;

public class MoviesController : Controller
{
    // GET: /Movies/
    public IActionResult Index()
    {
        return View();
    }
}