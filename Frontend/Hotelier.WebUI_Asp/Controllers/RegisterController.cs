using Hotelier.DtoLayer.AppUsers;
using Hotelier.EntityLayer.Concretes;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Hotelier.WebUI_Asp.Controllers;
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
    public async Task<IActionResult> Index(RegisterDto registerDto)
    {
        var appUser = new AppUser()
        {
            Name = registerDto.Name,
            Email = registerDto.Email,
            Surname = registerDto.Surname,
            UserName = registerDto.Username,
        };

        var result =
                await _userManager.CreateAsync(appUser, registerDto.Password);

        if (result.Succeeded)
            return RedirectToAction("Index", "Login");

        return View();
    }
}
