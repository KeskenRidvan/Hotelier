using Hotelier.EntityLayer.Concretes;
using Hotelier.WebUI_Asp.Models.Roles;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Hotelier.WebUI_Asp.Controllers;
public class AdminRoleAssingsController : Controller
{
    private readonly UserManager<AppUser> _userManager;
    private readonly RoleManager<AppRole> _roleManager;

    public AdminRoleAssingsController(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
    }

    [HttpGet]
    public IActionResult Index()
    {
        var values = _userManager.Users.ToList();
        return View(values);
    }

    [HttpGet]
    public async Task<IActionResult> AssignRole(int id)
    {
        var user = _userManager.Users.FirstOrDefault(x => x.Id.Equals(id));
        TempData["userId"] = user.Id;

        var roles = _roleManager.Roles.ToList();
        var userRoles = await _userManager.GetRolesAsync(user);

        List<RoleAssignViewModel> roleAssignViewModels = new();

        foreach (var item in roles)
        {
            RoleAssignViewModel model = new RoleAssignViewModel();
            model.RoleID = item.Id;
            model.RoleName = item.Name;
            model.RoleExist = userRoles.Contains(item.Name);
            roleAssignViewModels.Add(model);
        }
        return View(roleAssignViewModels);
    }

    [HttpPost]
    public async Task<IActionResult> AssignRole(List<RoleAssignViewModel> roleAssignViewModel)
    {
        var userId = (int)TempData["userId"];
        var user = _userManager.Users.FirstOrDefault(x => x.Id.Equals(userId));
        foreach (var item in roleAssignViewModel)
        {
            if (item.RoleExist)
                await _userManager.AddToRoleAsync(user, item.RoleName);

            await _userManager.RemoveFromRoleAsync(user, item.RoleName);
        }
        return RedirectToAction("Index");
    }
}
