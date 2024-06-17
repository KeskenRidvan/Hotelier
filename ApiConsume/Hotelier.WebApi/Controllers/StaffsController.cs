using Hotelier.BusinessLayer.Abstracts;
using Hotelier.DtoLayer.Staffs;
using Microsoft.AspNetCore.Mvc;

namespace Hotelier.WebApi.Controllers;

[Route("api/staffs")]
[ApiController]
public class StaffsController : Controller
{
	private readonly IStaffService _staffService;

	public StaffsController(IStaffService staffService)
	{
		_staffService = staffService;
	}

	[HttpGet("{id}")]
	public IActionResult Get([FromRoute] int id)
	{
		var response = _staffService.GetById(id);
		return Ok(response);
	}

	[HttpGet]
	public IActionResult GetList()
	{
		var response = _staffService.GetList();
		return Ok(response);
	}

	[HttpPost]
	public IActionResult Add([FromBody] StaffAddDto staffAddDto)
	{
		_staffService.Insert(staffAddDto);
		return Ok();
	}

	[HttpDelete("{id}")]
	public IActionResult Delete([FromRoute] int id)
	{
		_staffService.Delete(id);
		return Ok();
	}

	[HttpPut("{id}")]
	public IActionResult Update(
		[FromRoute] int id,
		[FromBody] StaffUpdateDto staffUpdateDto)
	{
		_staffService.Update(staffUpdateDto);
		return Ok();
	}
}