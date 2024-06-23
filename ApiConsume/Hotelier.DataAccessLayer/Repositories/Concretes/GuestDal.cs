using Hotelier.DataAccessLayer.Contexts;
using Hotelier.DataAccessLayer.Repositories.Abstracts;
using Hotelier.EntityLayer.Concretes;

namespace Hotelier.DataAccessLayer.Repositories.Concretes;

public class GuestDal : Repository<Guest>, IGuestDal
{
    public GuestDal(BaseDbContext context) : base(context)
    {
    }
}
