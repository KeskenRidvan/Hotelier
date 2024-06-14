using Hotelier.DataAccessLayer.Contexts;
using Hotelier.DataAccessLayer.Repositories.Abstracts;
using Hotelier.EntityLayer.Concretes;

namespace Hotelier.DataAccessLayer.Repositories.Concretes;

public class ServiceDal : Repository<Service>, IServiceDal
{
	public ServiceDal(BaseDbContext context) : base(context)
	{
	}
}
