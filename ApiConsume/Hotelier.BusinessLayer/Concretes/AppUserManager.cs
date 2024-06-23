using AutoMapper;
using Hotelier.BusinessLayer.Abstracts;
using Hotelier.DataAccessLayer.Repositories.Abstracts;
using Hotelier.DtoLayer.AppUsers;
using Hotelier.EntityLayer.Concretes;

namespace Hotelier.BusinessLayer.Concretes;
public class AppUserManager : IAppUserService
{
    private readonly IAppUserDal _appUserDal;
    private readonly IMapper _mapper;

    public AppUserManager(
        IAppUserDal appUserDal,
        IMapper mapper)
    {
        _appUserDal = appUserDal;
        _mapper = mapper;
    }

    public void Delete(int appUserId)
    {
        var deletedAppUser = _appUserDal.GetById(appUserId);
        _appUserDal.Delete(deletedAppUser);
    }

    public AppUserGetDto GetById(int appUserId)
    {
        AppUser appUser =
            _appUserDal.GetById(appUserId);

        AppUserGetDto response =
            _mapper.Map<AppUserGetDto>(appUser);
        return response;
    }

    public List<AppUserGetDto> GetList()
    {
        List<AppUser> appUsers =
            _appUserDal.GetList();

        List<AppUserGetDto> response =
            _mapper.Map<List<AppUserGetDto>>(appUsers);
        return response;
    }

    public void Insert(AppUserAddDto appUserAddDto)
    {
        AppUser appUser =
            _mapper.Map<AppUser>(appUserAddDto);
        _appUserDal.Insert(appUser);
    }

    public void Update(AppUserUpdateDto appUserUpdateDto)
    {
        AppUser appUser =
           _mapper.Map<AppUser>(appUserUpdateDto);

        _appUserDal.Update(appUser);
    }
}