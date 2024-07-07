using AutoMapper;
using Hotelier.BusinessLayer.Abstracts;
using Hotelier.DataAccessLayer.Repositories.Abstracts;
using Hotelier.DtoLayer.Rooms;
using Hotelier.EntityLayer.Concretes;

namespace Hotelier.BusinessLayer.Concretes;
public class RoomManager : IRoomService
{
    private readonly IRoomDal _roomDal;
    private readonly IMapper _mapper;

    public RoomManager(
        IRoomDal roomDal,
        IMapper mapper)
    {
        _roomDal = roomDal;
        _mapper = mapper;
    }

    public void Delete(int roomId)
    {
        var deletedRoom = _roomDal.GetById(roomId);
        _roomDal.Delete(deletedRoom);
    }

    public RoomGetDto GetById(int roomId)
    {
        Room room =
            _roomDal.GetById(roomId);

        RoomGetDto response =
            _mapper.Map<RoomGetDto>(room);
        return response;
    }

    public List<RoomGetDto> GetList()
    {
        List<Room> rooms =
            _roomDal.GetList();

        List<RoomGetDto> response =
            _mapper.Map<List<RoomGetDto>>(rooms);
        return response;
    }

    public void Insert(RoomAddDto roomAddDto)
    {
        Room room =
            _mapper.Map<Room>(roomAddDto);
        _roomDal.Insert(room);
    }

    public int RoomCount()
    {
        return _roomDal.RoomCount();
    }

    public void Update(RoomUpdateDto roomUpdateDto)
    {
        Room room =
           _mapper.Map<Room>(roomUpdateDto);

        _roomDal.Update(room);
    }
}