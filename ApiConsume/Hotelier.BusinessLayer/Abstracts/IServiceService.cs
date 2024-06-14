using Hotelier.EntityLayer.Concretes;

namespace Hotelier.BusinessLayer.Abstracts;

public interface IServiceService
{
	void Insert(Service service);
	void Delete(Service service);
	void Update(Service service);
	List<Service> GetList();
	Service GetById(int serviceId);
}
