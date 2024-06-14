using Hotelier.BusinessLayer.Abstracts;
using Hotelier.DataAccessLayer.Repositories.Abstracts;
using Hotelier.EntityLayer.Concretes;

namespace Hotelier.BusinessLayer.Concretes;

public class SubscribeManager : ISubscribeService
{
	private readonly ISubscribeDal _subscribeDal;

	public SubscribeManager(ISubscribeDal subscribeDal)
	{
		_subscribeDal = subscribeDal;
	}

	public void Delete(Subscribe subscribe)
	{
		_subscribeDal.Delete(subscribe);
	}

	public Subscribe GetById(int subscribeId)
	{
		return _subscribeDal.GetById(subscribeId);
	}

	public List<Subscribe> GetList()
	{
		return _subscribeDal.GetList();
	}

	public void Insert(Subscribe subscribe)
	{
		_subscribeDal.Insert(subscribe);
	}

	public void Update(Subscribe subscribe)
	{
		_subscribeDal.Update(subscribe);
	}
}
