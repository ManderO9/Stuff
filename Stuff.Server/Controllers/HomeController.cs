using Microsoft.AspNetCore.Mvc;

namespace Stuff.Server;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
