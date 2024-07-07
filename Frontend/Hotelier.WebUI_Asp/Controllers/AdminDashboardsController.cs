using Microsoft.AspNetCore.Mvc;

namespace Hotelier.WebUI_Asp.Controllers;
public class AdminDashboardsController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
