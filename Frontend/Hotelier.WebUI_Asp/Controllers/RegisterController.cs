using Hotelier.DtoLayer.AppUsers;
using Hotelier.EntityLayer.Concretes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Hotelier.WebUI_Asp.Controllers;

[AllowAnonymous]
public class RegisterController : Controller
{
    private readonly UserManager<AppUser> _userManager;

    public RegisterController(UserManager<AppUser> userManager)
    {
        _userManager = userManager;
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Index(RegisterDto register)
    {
        if (ModelState.IsValid)
            return View();

        var appUser = new AppUser()
        {
            Name = register.Name,
            Email = register.Email,
            Surname = register.Surname,
            UserName = register.Username,
        };

        var result =
                await _userManager.CreateAsync(appUser, register.Password);

        if (result.Succeeded)
            return RedirectToAction("Index", "Login");

        return View();
    }
}