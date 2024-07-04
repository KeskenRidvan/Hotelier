﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hotelier.WebUI_Asp.Controllers;

[AllowAnonymous]
public class DefaultController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}