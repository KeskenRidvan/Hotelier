using Hotelier.DtoLayer.Services;

namespace Hotelier.BusinessLayer.Abstracts;

public interface IServiceService
{
	void Insert(ServiceAddDto serviceAddDto);
	void Delete(int serviceId);
	void Update(ServiceUpdateDto serviceUpdateDto);
	List<ServiceGetDto> GetList();
	ServiceGetDto GetById(int serviceId);
}