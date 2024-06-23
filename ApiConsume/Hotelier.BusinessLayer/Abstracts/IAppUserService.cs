using Hotelier.DtoLayer.AppUsers;

namespace Hotelier.BusinessLayer.Abstracts;

public interface IAppUserService
{
    void Insert(AppUserAddDto appUserAddDto);
    void Delete(int appUserId);
    void Update(AppUserUpdateDto appUserUpdateDto);
    List<AppUserGetDto> GetList();
    AppUserGetDto GetById(int appUserId);
}