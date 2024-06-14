using Hotelier.EntityLayer.Concretes;

namespace Hotelier.BusinessLayer.Abstracts;
public interface IRoomService
{
	void Insert(Room room);
	void Delete(Room room);
	void Update(Room room);
	List<Room> GetList();
	Room GetById(int roomId);
}
