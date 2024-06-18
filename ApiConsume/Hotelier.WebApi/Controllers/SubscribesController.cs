using Hotelier.BusinessLayer.Abstracts;
using Hotelier.DtoLayer.Subscribes;
using Microsoft.AspNetCore.Mvc;

namespace Hotelier.WebApi.Controllers;

[Route("api/subscribes")]
[ApiController]
public class SubscribesController : Controller
{
	private readonly ISubscribeService _subscribeService;

	public SubscribesController(ISubscribeService subscribeService)
	{
		_subscribeService = subscribeService;
	}

	[HttpGet("{id}")]
	public IActionResult Get([FromRoute] int id)
	{
		var response = _subscribeService.GetById(id);
		return Ok(response);
	}

	[HttpGet]
	public IActionResult GetList()
	{
		var response = _subscribeService.GetList();
		return Ok(response);
	}

	[HttpPost]
	public IActionResult Add([FromBody] SubscribeAddDto subscribeAddDto)
	{
		_subscribeService.Insert(subscribeAddDto);
		return Ok();
	}

	[HttpDelete("{id}")]
	public IActionResult Delete([FromRoute] int id)
	{
		_subscribeService.Delete(id);
		return Ok();
	}

	[HttpPut("{id}")]
	public IActionResult Update(
		[FromRoute] int id,
		[FromBody] SubscribeUpdateDto subscribeUpdateDto)
	{
		_subscribeService.Update(subscribeUpdateDto);
		return Ok();
	}
}
