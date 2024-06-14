using Hotelier.BusinessLayer.Abstracts;
using Hotelier.DataAccessLayer.Repositories.Abstracts;
using Hotelier.EntityLayer.Concretes;

namespace Hotelier.BusinessLayer.Concretes;
public class RoomManager : IRoomService
{
	private readonly IRoomDal _roomDal;

	public RoomManager(IRoomDal roomDal)
	{
		_roomDal = roomDal;
	}

	public void Delete(Room room)
	{
		_roomDal.Delete(room);
	}

	public Room GetById(int roomId)
	{
		return _roomDal.GetById(roomId);
	}

	public List<Room> GetList()
	{
		return _roomDal.GetList();
	}

	public void Insert(Room room)
	{
		_roomDal.Insert(room);
	}

	public void Update(Room room)
	{
		_roomDal.Update(room);
	}
}