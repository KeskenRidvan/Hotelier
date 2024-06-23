using AutoMapper;
using Hotelier.BusinessLayer.Abstracts;
using Hotelier.DataAccessLayer.Repositories.Abstracts;
using Hotelier.DtoLayer.Guests;
using Hotelier.EntityLayer.Concretes;

namespace Hotelier.BusinessLayer.Concretes;
public class GuestManager : IGuestService
{
    private readonly IGuestDal _guestDal;
    private readonly IMapper _mapper;

    public GuestManager(
        IGuestDal guestDal,
        IMapper mapper)
    {
        _guestDal = guestDal;
        _mapper = mapper;
    }

    public void Delete(int guestId)
    {
        var deletedGuest = _guestDal.GetById(guestId);
        _guestDal.Delete(deletedGuest);
    }

    public GuestGetDto GetById(int guestId)
    {
        Guest guest =
            _guestDal.GetById(guestId);

        GuestGetDto response =
            _mapper.Map<GuestGetDto>(guest);
        return response;
    }

    public List<GuestGetDto> GetList()
    {
        List<Guest> guests =
            _guestDal.GetList();

        List<GuestGetDto> response =
            _mapper.Map<List<GuestGetDto>>(guests);
        return response;
    }

    public void Insert(GuestAddDto guestAddDto)
    {
        Guest guest =
            _mapper.Map<Guest>(guestAddDto);
        _guestDal.Insert(guest);
    }

    public void Update(GuestUpdateDto guestUpdateDto)
    {
        Guest guest =
           _mapper.Map<Guest>(guestUpdateDto);

        _guestDal.Update(guest);
    }
}