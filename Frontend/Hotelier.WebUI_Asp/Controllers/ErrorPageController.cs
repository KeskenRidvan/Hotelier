using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hotelier.WebUI_Asp.Controllers;

[AllowAnonymous]
public class ErrorPageController : Controller
{
    public IActionResult Error404()
    {
        return View();
    }
}
