using Hotelier.DtoLayer.Subscribes;

namespace Hotelier.BusinessLayer.Abstracts;

public interface ISubscribeService
{
	void Insert(SubscribeAddDto subscribeAddDto);
	void Delete(int subscribeId);
	void Update(SubscribeUpdateDto subscribeUpdateDto);
	List<SubscribeGetDto> GetList();
	SubscribeGetDto GetById(int subscribeId);
}