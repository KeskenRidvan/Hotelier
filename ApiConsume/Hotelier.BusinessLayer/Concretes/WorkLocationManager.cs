using AutoMapper;
using Hotelier.BusinessLayer.Abstracts;
using Hotelier.DataAccessLayer.Repositories.Abstracts;
using Hotelier.DtoLayer.WorkLocations;
using Hotelier.EntityLayer.Concretes;

namespace Hotelier.BusinessLayer.Concretes;
public class WorkLocationManager : IWorkLocationService
{
    private readonly IWorkLocationDal _workLocationDal;
    private readonly IMapper _mapper;

    public WorkLocationManager(
        IWorkLocationDal workLocationDal,
        IMapper mapper)
    {
        _workLocationDal = workLocationDal;
        _mapper = mapper;
    }

    public void Delete(int workLocationId)
    {
        var deletedWorkLocation = _workLocationDal.GetById(workLocationId);
        _workLocationDal.Delete(deletedWorkLocation);
    }

    public WorkLocationGetDto GetById(int workLocationId)
    {
        WorkLocation workLocation =
            _workLocationDal.GetById(workLocationId);

        WorkLocationGetDto response =
            _mapper.Map<WorkLocationGetDto>(workLocation);
        return response;
    }

    public List<WorkLocationGetDto> GetList()
    {
        List<WorkLocation> workLocations =
            _workLocationDal.GetList();

        List<WorkLocationGetDto> response =
            _mapper.Map<List<WorkLocationGetDto>>(workLocations);
        return response;
    }

    public void Insert(WorkLocationAddDto workLocationAddDto)
    {
        WorkLocation workLocation =
            _mapper.Map<WorkLocation>(workLocationAddDto);
        _workLocationDal.Insert(workLocation);
    }

    public void Update(WorkLocationUpdateDto workLocationUpdateDto)
    {
        WorkLocation workLocation =
           _mapper.Map<WorkLocation>(workLocationUpdateDto);

        _workLocationDal.Update(workLocation);
    }
}