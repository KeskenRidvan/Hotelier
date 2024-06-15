using Microsoft.AspNetCore.Mvc;

namespace Hotelier.WebUI_Asp.Controllers;
public class StaffController : Controller
{
	public IActionResult Index()
	{
		return View();
	}
}
