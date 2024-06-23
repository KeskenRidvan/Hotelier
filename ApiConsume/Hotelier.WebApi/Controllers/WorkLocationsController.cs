using Hotelier.BusinessLayer.Abstracts;
using Hotelier.DtoLayer.WorkLocations;
using Microsoft.AspNetCore.Mvc;

namespace Hotelier.WebApi.Controllers;

[Route("api/worklocations")]
[ApiController]
public class WorkLocationsController : ControllerBase
{
    private readonly IWorkLocationService _workLocationService;

    public WorkLocationsController(IWorkLocationService workLocationService)
    {
        _workLocationService = workLocationService;
    }

    [HttpGet("{id}")]
    public IActionResult Get([FromRoute] int id)
    {
        var response = _workLocationService.GetById(id);
        return Ok(response);
    }

    [HttpGet]
    public IActionResult GetList()
    {
        var response = _workLocationService.GetList();
        return Ok(response);
    }

    [HttpPost]
    public IActionResult Add([FromBody] WorkLocationAddDto workLocationAddDto)
    {
        _workLocationService.Insert(workLocationAddDto);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete([FromRoute] int id)
    {
        _workLocationService.Delete(id);
        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult Update(
        [FromRoute] int id,
        [FromBody] WorkLocationUpdateDto workLocationUpdateDto)
    {
        _workLocationService.Update(workLocationUpdateDto);
        return Ok();
    }
}
