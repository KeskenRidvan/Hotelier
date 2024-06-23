using Hotelier.DataAccessLayer.Contexts;
using Hotelier.DataAccessLayer.Repositories.Abstracts;
using Hotelier.EntityLayer.Concretes;

namespace Hotelier.DataAccessLayer.Repositories.Concretes;

public class AboutDal : Repository<About>, IAboutDal
{
    public AboutDal(BaseDbContext context) : base(context)
    {
    }
}
