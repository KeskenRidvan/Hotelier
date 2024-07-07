using Hotelier.DtoLayer.Rooms;

namespace Hotelier.BusinessLayer.Abstracts;
public interface IRoomService
{
    void Insert(RoomAddDto roomAddDto);
    void Delete(int roomId);
    void Update(RoomUpdateDto roomUpdateDto);
    List<RoomGetDto> GetList();
    RoomGetDto GetById(int roomId);
    int RoomCount();
}