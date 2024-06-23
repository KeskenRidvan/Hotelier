using Microsoft.AspNetCore.Mvc;

namespace Hotelier.WebUI_Asp.Controllers;
public class DefaultController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}