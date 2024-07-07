using Hotelier.DataAccessLayer.Contexts;
using Hotelier.DataAccessLayer.Repositories.Abstracts;
using Hotelier.EntityLayer.Concretes;
using Microsoft.EntityFrameworkCore;

namespace Hotelier.DataAccessLayer.Repositories.Concretes;

public class AppUserDal : Repository<AppUser>, IAppUserDal
{
    public AppUserDal(BaseDbContext context) : base(context)
    {
    }

    public int AppUserCount()
    {
        using (var context = new BaseDbContext())
        {
            return context.Users.Count();
        }
    }

    public List<AppUser> UserListWithWorkLocation()
    {
        using (var context = new BaseDbContext())
        {
            return context.Users.Include(x => x.WorkLocation).ToList();
        }
    }
}