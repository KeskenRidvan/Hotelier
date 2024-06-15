using Hotelier.BusinessLayer.Abstracts;
using Hotelier.EntityLayer.Concretes;
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
	public IActionResult Add([FromBody] Subscribe subscribe)
	{
		_subscribeService.Insert(subscribe);
		return Ok();
	}

	[HttpDelete("{id}")]
	public IActionResult Delete([FromRoute] int id)
	{
		var response = _subscribeService.GetById(id);
		_subscribeService.Delete(response);
		return Ok();
	}

	[HttpPut("{id}")]
	public IActionResult Update([FromRoute] int id, [FromBody] Subscribe subscribe)
	{
		_subscribeService.Update(subscribe);
		return Ok();
	}
}
