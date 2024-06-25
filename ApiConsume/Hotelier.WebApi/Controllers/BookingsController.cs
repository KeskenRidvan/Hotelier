using Hotelier.BusinessLayer.Abstracts;
using Hotelier.DtoLayer.Bookings;
using Microsoft.AspNetCore.Mvc;

namespace Hotelier.WebApi.Controllers;

[Route("api/bookings")]
[ApiController]
public class BookingsController : ControllerBase
{
    private readonly IBookingService _bookingService;

    public BookingsController(IBookingService bookingService)
    {
        _bookingService = bookingService;
    }

    [HttpGet("{id}")]
    public IActionResult Get([FromRoute] int id)
    {
        var response = _bookingService.GetById(id);
        return Ok(response);
    }

    [HttpGet]
    public IActionResult GetList()
    {
        var response = _bookingService.GetList();
        return Ok(response);
    }

    [HttpPost]
    public IActionResult Add([FromBody] BookingAddDto bookingAddDto)
    {
        _bookingService.Insert(bookingAddDto);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete([FromRoute] int id)
    {
        _bookingService.Delete(id);
        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult Update(
        [FromRoute] int id,
        [FromBody] BookingUpdateDto bookingUpdateDto)
    {
        _bookingService.Update(bookingUpdateDto);
        return Ok();
    }

    [HttpPut("status/{id}")]
    public IActionResult UpdateStatus(
       [FromRoute] int id,
       [FromBody] BookingUpdateStatus bookingUpdateStatus)
    {
        _bookingService.BookingUpdateStatus(bookingUpdateStatus);
        return Ok();
    }
}
