using Hotelier.DataAccessLayer.Contexts;
using Hotelier.DataAccessLayer.Repositories.Abstracts;
using Hotelier.EntityLayer.Concretes;

namespace Hotelier.DataAccessLayer.Repositories.Concretes;

public class AppUserDal : Repository<AppUser>, IAppUserDal
{
    public AppUserDal(BaseDbContext context) : base(context)
    {
    }
}
