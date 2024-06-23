using Hotelier.DtoLayer.Guests;

namespace Hotelier.BusinessLayer.Abstracts;

public interface IGuestService
{
    void Insert(GuestAddDto guestAddDto);
    void Delete(int guestId);
    void Update(GuestUpdateDto guestUpdateDto);
    List<GuestGetDto> GetList();
    GuestGetDto GetById(int guestId);
}