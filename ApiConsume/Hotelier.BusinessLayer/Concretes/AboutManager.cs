using AutoMapper;
using Hotelier.BusinessLayer.Abstracts;
using Hotelier.DataAccessLayer.Repositories.Abstracts;
using Hotelier.DtoLayer.Abouts;
using Hotelier.EntityLayer.Concretes;

namespace Hotelier.BusinessLayer.Concretes;
public class AboutManager : IAboutService
{
    private readonly IAboutDal _aboutDal;
    private readonly IMapper _mapper;

    public AboutManager(
        IAboutDal aboutDal,
        IMapper mapper)
    {
        _aboutDal = aboutDal;
        _mapper = mapper;
    }

    public void Delete(int aboutId)
    {
        var deletedAbout = _aboutDal.GetById(aboutId);
        _aboutDal.Delete(deletedAbout);
    }

    public AboutGetDto GetById(int aboutId)
    {
        About about =
            _aboutDal.GetById(aboutId);

        AboutGetDto response =
            _mapper.Map<AboutGetDto>(about);
        return response;
    }

    public List<AboutGetDto> GetList()
    {
        List<About> abouts =
            _aboutDal.GetList();

        List<AboutGetDto> response =
            _mapper.Map<List<AboutGetDto>>(abouts);
        return response;
    }

    public void Insert(AboutAddDto aboutAddDto)
    {
        About about =
            _mapper.Map<About>(aboutAddDto);
        _aboutDal.Insert(about);
    }

    public void Update(AboutUpdateDto aboutUpdateDto)
    {
        About about =
           _mapper.Map<About>(aboutUpdateDto);

        _aboutDal.Update(about);
    }
}