using Hotelier.EntityLayer.Concretes;
using Hotelier.WebUI_Asp.Models.Roles;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Hotelier.WebUI_Asp.Controllers;
public class AdminRolesController : Controller
{
    private readonly RoleManager<AppRole> _roleManager;

    public AdminRolesController(RoleManager<AppRole> roleManager)
    {
        _roleManager = roleManager;
    }

    [HttpGet]
    public IActionResult Index()
    {
        var values = _roleManager.Roles.ToList();
        return View(values);
    }

    [HttpGet]
    public IActionResult AddRole()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> AddRole(AddRoleViewModel addRoleViewModel)
    {
        AppRole appRole = new AppRole
        {
            Name = addRoleViewModel.RoleName
        };

        var result = await _roleManager.CreateAsync(appRole);

        if (result.Succeeded)
            return RedirectToAction("Index");

        return View();
    }

    [HttpPost]
    public async Task<IActionResult> DeleteRole(int id)
    {
        var value = _roleManager.Roles.FirstOrDefault(x => x.Id.Equals(id));
        await _roleManager.DeleteAsync(value);

        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult UpdateRole(int id)
    {
        var value = _roleManager.Roles.FirstOrDefault(x => x.Id.Equals(id));

        UpdateRoleViewModel updateRoleViewModel = new()
        {
            RoleID = value.Id,
            RoleName = value.Name
        };
        return View(updateRoleViewModel);
    }

    [HttpPost]
    public async Task<IActionResult> UpdateRole(UpdateRoleViewModel updateRoleViewModel)
    {
        var value = _roleManager.Roles.FirstOrDefault(x => x.Id.Equals(updateRoleViewModel.RoleID));
        value.Name = updateRoleViewModel.RoleName;

        await _roleManager.UpdateAsync(value);

        return RedirectToAction("Index");
    }
}
