using Hotelier.DataAccessLayer.Contexts;
using Hotelier.DataAccessLayer.Repositories.Abstracts;
using Hotelier.EntityLayer.Concretes;

namespace Hotelier.DataAccessLayer.Repositories.Concretes;

public class MessageCategoryDal : Repository<MessageCategory>, IMessageCategoryDal
{
    public MessageCategoryDal(BaseDbContext context) : base(context)
    {
    }
}
