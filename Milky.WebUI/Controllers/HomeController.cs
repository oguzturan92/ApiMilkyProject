using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace Milky.WebUI.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        ViewBag.homeActive = "active";
        return View();
    }
}
