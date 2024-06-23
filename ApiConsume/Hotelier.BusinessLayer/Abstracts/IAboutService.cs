using Hotelier.DtoLayer.Abouts;

namespace Hotelier.BusinessLayer.Abstracts;

public interface IAboutService
{
    void Insert(AboutAddDto aboutAddDto);
    void Delete(int aboutId);
    void Update(AboutUpdateDto aboutUpdateDto);
    List<AboutGetDto> GetList();
    AboutGetDto GetById(int aboutId);
}
