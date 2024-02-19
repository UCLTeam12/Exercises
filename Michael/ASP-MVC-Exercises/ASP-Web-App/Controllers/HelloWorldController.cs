using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Mvc;

namespace ASP_Web_App.Controllers;

public class HelloWorldController : Controller
{
    // GET: /HelloWorld/
    public IActionResult Index()
    {
        return View();
    }

    // GET: /HelloWorld/Welcome/ 
    public string Welcome(string name, int ID = 1)
    {
        return HtmlEncoder.Default.Encode($"Hello {name}, NumTimes is: {ID}");
    }
}
