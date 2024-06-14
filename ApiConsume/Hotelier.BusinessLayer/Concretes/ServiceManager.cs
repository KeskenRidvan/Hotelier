using Hotelier.BusinessLayer.Abstracts;
using Hotelier.DataAccessLayer.Repositories.Abstracts;
using Hotelier.EntityLayer.Concretes;

namespace Hotelier.BusinessLayer.Concretes;

public class ServiceManager : IServiceService
{
	private readonly IServiceDal _serviceDal;

	public ServiceManager(IServiceDal serviceDal)
	{
		_serviceDal = serviceDal;
	}

	public void Delete(Service service)
	{
		_serviceDal.Delete(service);
	}

	public Service GetById(int serviceId)
	{
		return _serviceDal.GetById(serviceId);
	}

	public List<Service> GetList()
	{
		return _serviceDal.GetList();
	}

	public void Insert(Service service)
	{
		_serviceDal.Insert(service);
	}

	public void Update(Service service)
	{
		_serviceDal.Update(service);
	}
}