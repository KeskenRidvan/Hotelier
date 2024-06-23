using Hotelier.DtoLayer.WorkLocations;

namespace Hotelier.BusinessLayer.Abstracts;

public interface IWorkLocationService
{
    void Insert(WorkLocationAddDto workLocationAddDto);
    void Delete(int workLocationId);
    void Update(WorkLocationUpdateDto workLocationUpdateDto);
    List<WorkLocationGetDto> GetList();
    WorkLocationGetDto GetById(int workLocationId);
}