using Hotelier.DtoLayer.Contacts;

namespace Hotelier.BusinessLayer.Abstracts;

public interface IContactService
{
    void Insert(ContactAddDto contactAddDto);
    void Delete(int contactId);
    void Update(ContactUpdateDto contactUpdateDto);
    List<ContactGetDto> GetList();
    ContactGetDto GetById(int contactId);
}