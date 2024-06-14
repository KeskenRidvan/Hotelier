using Hotelier.DataAccessLayer.Contexts;
using Hotelier.DataAccessLayer.Repositories.Abstracts;
using Hotelier.EntityLayer.Concretes;

namespace Hotelier.DataAccessLayer.Repositories.Concretes;

public class SubscribeDal : Repository<Subscribe>, ISubscribeDal
{
	public SubscribeDal(BaseDbContext context) : base(context)
	{
	}
}
