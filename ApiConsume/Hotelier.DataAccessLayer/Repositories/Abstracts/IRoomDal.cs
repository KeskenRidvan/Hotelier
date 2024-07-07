using Hotelier.EntityLayer.Concretes;

namespace Hotelier.DataAccessLayer.Repositories.Abstracts;
public interface IRoomDal : IRepository<Room>
{
    int RoomCount();
}
