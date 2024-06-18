using Hotelier.BusinessLayer.Abstracts;
using Hotelier.DtoLayer.Rooms;
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
	public IActionResult Add([FromBody] RoomAddDto roomAddDto)
	{
		_roomService.Insert(roomAddDto);
		return Ok();
	}

	[HttpDelete("{id}")]
	public IActionResult Delete([FromRoute] int id)
	{
		_roomService.Delete(id);
		return Ok();
	}

	[HttpPut("{id}")]
	public IActionResult Update(
		[FromRoute] int id,
		[FromBody] RoomUpdateDto roomUpdateDto)
	{
		_roomService.Update(roomUpdateDto);
		return Ok();
	}
}