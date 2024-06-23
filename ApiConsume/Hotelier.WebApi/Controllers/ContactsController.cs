using Hotelier.BusinessLayer.Abstracts;
using Hotelier.DtoLayer.Contacts;
using Microsoft.AspNetCore.Mvc;

namespace Hotelier.WebApi.Controllers;

[Route("api/contacts")]
[ApiController]
public class ContactsController : ControllerBase
{
    private readonly IContactService _contactService;

    public ContactsController(IContactService contactService)
    {
        _contactService = contactService;
    }

    [HttpGet("{id}")]
    public IActionResult Get([FromRoute] int id)
    {
        var response = _contactService.GetById(id);
        return Ok(response);
    }

    [HttpGet]
    public IActionResult GetList()
    {
        var response = _contactService.GetList();
        return Ok(response);
    }

    [HttpPost]
    public IActionResult Add([FromBody] ContactAddDto contactAddDto)
    {
        _contactService.Insert(contactAddDto);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete([FromRoute] int id)
    {
        _contactService.Delete(id);
        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult Update(
        [FromRoute] int id,
        [FromBody] ContactUpdateDto contactUpdateDto)
    {
        _contactService.Update(contactUpdateDto);
        return Ok();
    }
}
