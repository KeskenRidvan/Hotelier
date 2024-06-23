using Hotelier.BusinessLayer.Abstracts;
using Hotelier.DtoLayer.AppUsers;
using Microsoft.AspNetCore.Mvc;

namespace Hotelier.WebApi.Controllers;

[Route("api/appusers")]
[ApiController]
public class AppUsersController : ControllerBase
{
    private readonly IAppUserService _appUserService;

    public AppUsersController(IAppUserService appUserService)
    {
        _appUserService = appUserService;
    }

    [HttpGet("{id}")]
    public IActionResult Get([FromRoute] int id)
    {
        var response = _appUserService.GetById(id);
        return Ok(response);
    }

    [HttpGet]
    public IActionResult GetList()
    {
        var response = _appUserService.GetList();
        return Ok(response);
    }

    [HttpPost]
    public IActionResult Add([FromBody] AppUserAddDto appUserAddDto)
    {
        _appUserService.Insert(appUserAddDto);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete([FromRoute] int id)
    {
        _appUserService.Delete(id);
        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult Update(
        [FromRoute] int id,
        [FromBody] AppUserUpdateDto appUserUpdateDto)
    {
        _appUserService.Update(appUserUpdateDto);
        return Ok();
    }
}
