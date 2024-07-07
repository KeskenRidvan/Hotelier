using Hotelier.BusinessLayer.Abstracts;
using Microsoft.AspNetCore.Mvc;

namespace Hotelier.WebApi.Controllers;

[Route("api/dashboardwidgets")]
[ApiController]
public class DashboardWidgetsController : ControllerBase
{
    private readonly IStaffService _staffService;
    private readonly IBookingService _bookingService;
    private readonly IAppUserService _appUserService;
    private readonly IRoomService _roomService;

    public DashboardWidgetsController(
        IStaffService staffService,
        IBookingService bookingService,
        IAppUserService appUserService,
        IRoomService roomService)
    {
        _staffService = staffService;
        _bookingService = bookingService;
        _appUserService = appUserService;
        _roomService = roomService;
    }

    [HttpGet("staffcount")]
    public IActionResult StaffCount()
    {
        return Ok(_staffService.GetStaffCount());
    }

    [HttpGet("bookingcount")]
    public IActionResult BookingCount()
    {
        return Ok(_bookingService.GetBookingCount());
    }

    [HttpGet("appusercount")]
    public IActionResult AppUserCount()
    {
        return Ok(_appUserService.AppUserCount());
    }

    [HttpGet("roomcount")]
    public IActionResult RoomCount()
    {
        return Ok(_roomService.RoomCount());
    }

    [HttpGet("last4staff")]
    public IActionResult Last4Staff()
    {
        return Ok(_staffService.Last4Staff());
    }

    [HttpGet("last6booking")]
    public IActionResult Last6Booking()
    {
        return Ok(_bookingService.Last6Bookings());
    }
}
