using Hotelier.DataAccessLayer.Contexts;
using Hotelier.DataAccessLayer.Repositories.Abstracts;
using Hotelier.EntityLayer.Concretes;

namespace Hotelier.DataAccessLayer.Repositories.Concretes;

public class BookingDal : Repository<Booking>, IBookingDal
{
    public BookingDal(BaseDbContext context) : base(context)
    {
    }
}
