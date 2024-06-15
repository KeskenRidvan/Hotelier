using Hotelier.BusinessLayer.Abstracts;
using Hotelier.EntityLayer.Concretes;
using Microsoft.AspNetCore.Mvc;

namespace Hotelier.WebApi.Controllers;

[Route("api/services")]
[ApiController]
public class ServicesController : ControllerBase
{
	private readonly IServiceService _serviceService;

	public ServicesController(IServiceService serviceService)
	{
		_serviceService = serviceService;
	}

	[HttpGet("{id}")]
	public IActionResult Get([FromRoute] int id)
	{
		var response = _serviceService.GetById(id);
		return Ok(response);
	}

	[HttpGet]
	public IActionResult GetList()
	{
		var response = _serviceService.GetList();
		return Ok(response);
	}

	[HttpPost]
	public IActionResult Add([FromBody] Service service)
	{
		_serviceService.Insert(service);
		return Ok();
	}

	[HttpDelete("{id}")]
	public IActionResult Delete([FromRoute] int id)
	{
		var response = _serviceService.GetById(id);
		_serviceService.Delete(response);
		return Ok();
	}

	[HttpPut("{id}")]
	public IActionResult Update([FromRoute] int id, [FromBody] Service service)
	{
		_serviceService.Update(service);
		return Ok();
	}
}
