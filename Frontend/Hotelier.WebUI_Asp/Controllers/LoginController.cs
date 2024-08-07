﻿using Hotelier.DtoLayer.AppUsers;
using Hotelier.EntityLayer.Concretes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Hotelier.WebUI_Asp.Controllers;

[AllowAnonymous]
public class LoginController : Controller
{
    private readonly SignInManager<AppUser> _signInManager;

    public LoginController(SignInManager<AppUser> signInManager)
    {
        _signInManager = signInManager;
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Index(LoginDto login)
    {
        if (!ModelState.IsValid)
            return View();

        var result =
                await _signInManager.PasswordSignInAsync(
                        login.Username,
                        login.Password,
                        false,
                        false);

        if (result.Succeeded)
            return RedirectToAction("Index", "Home");

        return View();
    }
}
