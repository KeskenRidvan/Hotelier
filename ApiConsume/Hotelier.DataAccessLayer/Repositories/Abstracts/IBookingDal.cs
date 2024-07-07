using Hotelier.EntityLayer.Concretes;

namespace Hotelier.DataAccessLayer.Repositories.Abstracts;

public interface IBookingDal : IRepository<Booking>
{
    int GetBookingCount();
    List<Booking> Last6Bookings();
}