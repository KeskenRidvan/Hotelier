using Hotelier.DataAccessLayer.Contexts;
using Hotelier.DataAccessLayer.Repositories.Abstracts;
using Hotelier.EntityLayer.Concretes;

namespace Hotelier.DataAccessLayer.Repositories.Concretes;

public class BookingDal : Repository<Booking>, IBookingDal
{
    public BookingDal(BaseDbContext context) : base(context)
    {
    }

    public int GetBookingCount()
    {
        using (var context = new BaseDbContext())
        {
            return context.Bookings.Count();
        }
    }

    public List<Booking> Last6Bookings()
    {
        using (var context = new BaseDbContext())
        {
            return context.Bookings.OrderByDescending(x => x.BookingID).Take(6).ToList();
        }
    }
}
