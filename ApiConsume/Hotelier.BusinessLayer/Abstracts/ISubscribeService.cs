using Hotelier.EntityLayer.Concretes;

namespace Hotelier.BusinessLayer.Abstracts;

public interface ISubscribeService
{
	void Insert(Subscribe subscribe);
	void Delete(Subscribe subscribe);
	void Update(Subscribe subscribe);
	List<Subscribe> GetList();
	Subscribe GetById(int subscribeId);
}
