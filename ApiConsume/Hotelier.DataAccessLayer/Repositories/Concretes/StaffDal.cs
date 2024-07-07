using Hotelier.DataAccessLayer.Contexts;
using Hotelier.DataAccessLayer.Repositories.Abstracts;
using Hotelier.EntityLayer.Concretes;

namespace Hotelier.DataAccessLayer.Repositories.Concretes;

public class StaffDal : Repository<Staff>, IStaffDal
{
    public StaffDal(BaseDbContext context) : base(context)
    {
    }

    public int GetStaffCount()
    {
        using (var context = new BaseDbContext())
        {
            return context.Staffs.Count();
        }
    }

    public List<Staff> Last4Staff()
    {
        using (var context = new BaseDbContext())
        {
            return context.Staffs.OrderByDescending(x => x.StaffID).Take(4).ToList();
        }
    }
}
