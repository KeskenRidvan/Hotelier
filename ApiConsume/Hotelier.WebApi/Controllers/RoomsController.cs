using Hotelier.BusinessLayer.Abstracts;
using Hotelier.EntityLayer.Concretes;
using Microsoft.AspNetCore.Mvc;

namespace Hotelier.WebApi.Controllers;

[Route("api/rooms")]
[ApiController]
public class RoomsController : ControllerBase
{
	private readonly IRoomService _roomService;

	public RoomsController(IRoomService roomService)
	{
		_roomService = roomService;
	}

	[HttpGet("{id}")]
	public IActionResult Get([FromRoute] int id)
	{
		var response = _roomService.GetById(id);
		return Ok(response);
	}

	[HttpGet]
	public IActionResult GetList()
	{
		var response = _roomService.GetList();
		return Ok(response);
	}

	[HttpPost]
	public IActionResult Add([FromBody] Room room)
	{
		_roomService.Insert(room);
		return Ok();
	}

	[HttpDelete("{id}")]
	public IActionResult Delete([FromRoute] int id)
	{
		var response = _roomService.GetById(id);
		_roomService.Delete(response);
		return Ok();
	}

	[HttpPut("{id}")]
	public IActionResult Update([FromRoute] int id, [FromBody] Room room)
	{
		_roomService.Update(room);
		return Ok();
	}
}
