using AutoMapper;
using Hotelier.BusinessLayer.Abstracts;
using Hotelier.DataAccessLayer.Repositories.Abstracts;
using Hotelier.DtoLayer.Services;
using Hotelier.EntityLayer.Concretes;

namespace Hotelier.BusinessLayer.Concretes;

public class ServiceManager : IServiceService
{
	private readonly IServiceDal _serviceDal;
	private readonly IMapper _mapper;

	public ServiceManager(
		IServiceDal serviceDal,
		IMapper mapper)
	{
		_serviceDal = serviceDal;
		_mapper = mapper;
	}

	public void Delete(int serviceId)
	{
		var deletedService = _serviceDal.GetById(serviceId);
		_serviceDal.Delete(deletedService);
	}

	public ServiceGetDto GetById(int serviceId)
	{
		Service service =
			_serviceDal.GetById(serviceId);

		ServiceGetDto response =
			_mapper.Map<ServiceGetDto>(service);
		return response;
	}

	public List<ServiceGetDto> GetList()
	{
		List<Service> services =
			_serviceDal.GetList();

		List<ServiceGetDto> response =
			_mapper.Map<List<ServiceGetDto>>(services);
		return response;
	}

	public void Insert(ServiceAddDto serviceAddDto)
	{
		Service service =
			_mapper.Map<Service>(serviceAddDto);
		_serviceDal.Insert(service);
	}

	public void Update(ServiceUpdateDto serviceUpdateDto)
	{
		Service service =
		   _mapper.Map<Service>(serviceUpdateDto);

		_serviceDal.Update(service);
	}
}