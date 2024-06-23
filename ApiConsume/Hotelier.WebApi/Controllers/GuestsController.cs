using Hotelier.BusinessLayer.Abstracts;
using Hotelier.DtoLayer.Guests;
using Microsoft.AspNetCore.Mvc;

namespace Hotelier.WebApi.Controllers;

[Route("api/guests")]
[ApiController]
public class GuestsController : ControllerBase
{
    private readonly IGuestService _guestService;

    public GuestsController(IGuestService guestService)
    {
        _guestService = guestService;
    }

    [HttpGet("{id}")]
    public IActionResult Get([FromRoute] int id)
    {
        var response = _guestService.GetById(id);
        return Ok(response);
    }

    [HttpGet]
    public IActionResult GetList()
    {
        var response = _guestService.GetList();
        return Ok(response);
    }

    [HttpPost]
    public IActionResult Add([FromBody] GuestAddDto guestAddDto)
    {
        _guestService.Insert(guestAddDto);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete([FromRoute] int id)
    {
        _guestService.Delete(id);
        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult Update(
        [FromRoute] int id,
        [FromBody] GuestUpdateDto guestUpdateDto)
    {
        _guestService.Update(guestUpdateDto);
        return Ok();
    }
}
