using Hotelier.DtoLayer.Bookings;

namespace Hotelier.BusinessLayer.Abstracts;

public interface IBookingService
{
    void Insert(BookingAddDto bookingAddDto);
    void Delete(int bookingId);
    void Update(BookingUpdateDto bookingUpdateDto);
    List<BookingGetDto> GetList();
    BookingGetDto GetById(int bookingId);
}