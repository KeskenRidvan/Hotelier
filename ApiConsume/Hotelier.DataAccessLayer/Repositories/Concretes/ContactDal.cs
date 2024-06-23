using Hotelier.DataAccessLayer.Contexts;
using Hotelier.DataAccessLayer.Repositories.Abstracts;
using Hotelier.EntityLayer.Concretes;

namespace Hotelier.DataAccessLayer.Repositories.Concretes;

public class ContactDal : Repository<Contact>, IContactDal
{
    public ContactDal(BaseDbContext context) : base(context)
    {
    }
}
