using Hotelier.DataAccessLayer.Contexts;
using Hotelier.DataAccessLayer.Repositories.Abstracts;
using Hotelier.EntityLayer.Concretes;

namespace Hotelier.DataAccessLayer.Repositories.Concretes;

public class StaffDal : Repository<Staff>, IStaffDal
{
	public StaffDal(BaseDbContext context) : base(context)
	{
	}
}
