using Hotelier.DataAccessLayer.Contexts;
using Hotelier.DataAccessLayer.Repositories.Abstracts;
using Hotelier.EntityLayer.Concretes;

namespace Hotelier.DataAccessLayer.Repositories.Concretes;

public class WorkLocationDal : Repository<WorkLocation>, IWorkLocationDal
{
    public WorkLocationDal(BaseDbContext context) : base(context)
    {
    }
}