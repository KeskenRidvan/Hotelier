using Hotelier.BusinessLayer.Abstracts;
using Hotelier.DtoLayer.Abouts;
using Microsoft.AspNetCore.Mvc;

namespace Hotelier.WebApi.Controllers;

[Route("api/abouts")]
[ApiController]
public class AboutsController : ControllerBase
{
    private readonly IAboutService _aboutService;

    public AboutsController(IAboutService aboutService)
    {
        _aboutService = aboutService;
    }

    [HttpGet("{id}")]
    public IActionResult Get([FromRoute] int id)
    {
        var response = _aboutService.GetById(id);
        return Ok(response);
    }

    [HttpGet]
    public IActionResult GetList()
    {
        var response = _aboutService.GetList();
        return Ok(response);
    }

    [HttpPost]
    public IActionResult Add([FromBody] AboutAddDto aboutAddDto)
    {
        _aboutService.Insert(aboutAddDto);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete([FromRoute] int id)
    {
        _aboutService.Delete(id);
        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult Update(
        [FromRoute] int id,
        [FromBody] AboutUpdateDto aboutUpdateDto)
    {
        _aboutService.Update(aboutUpdateDto);
        return Ok();
    }
}