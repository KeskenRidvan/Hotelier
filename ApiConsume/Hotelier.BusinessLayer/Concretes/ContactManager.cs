using AutoMapper;
using Hotelier.BusinessLayer.Abstracts;
using Hotelier.DataAccessLayer.Repositories.Abstracts;
using Hotelier.DtoLayer.Contacts;
using Hotelier.EntityLayer.Concretes;

namespace Hotelier.BusinessLayer.Concretes;
public class ContactManager : IContactService
{
    private readonly IContactDal _contactDal;
    private readonly IMapper _mapper;

    public ContactManager(
        IContactDal contactDal,
        IMapper mapper)
    {
        _contactDal = contactDal;
        _mapper = mapper;
    }

    public void Delete(int contactId)
    {
        var deletedContact = _contactDal.GetById(contactId);
        _contactDal.Delete(deletedContact);
    }

    public ContactGetDto GetById(int contactId)
    {
        Contact contact =
            _contactDal.GetById(contactId);

        ContactGetDto response =
            _mapper.Map<ContactGetDto>(contact);
        return response;
    }

    public List<ContactGetDto> GetList()
    {
        List<Contact> contacts =
            _contactDal.GetList();

        List<ContactGetDto> response =
            _mapper.Map<List<ContactGetDto>>(contacts);
        return response;
    }

    public void Insert(ContactAddDto contactAddDto)
    {
        Contact contact =
            _mapper.Map<Contact>(contactAddDto);
        _contactDal.Insert(contact);
    }

    public void Update(ContactUpdateDto contactUpdateDto)
    {
        Contact contact =
           _mapper.Map<Contact>(contactUpdateDto);

        _contactDal.Update(contact);
    }
}