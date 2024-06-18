using AutoMapper;
using Hotelier.BusinessLayer.Abstracts;
using Hotelier.DataAccessLayer.Repositories.Abstracts;
using Hotelier.DtoLayer.Subscribes;
using Hotelier.EntityLayer.Concretes;

namespace Hotelier.BusinessLayer.Concretes;

public class SubscribeManager : ISubscribeService
{
	private readonly ISubscribeDal _subscribeDal;
	private readonly IMapper _mapper;

	public SubscribeManager(
		ISubscribeDal subscribeDal,
		IMapper mapper)
	{
		_subscribeDal = subscribeDal;
		_mapper = mapper;
	}

	public void Delete(int subscribeId)
	{
		var deletedSubscribe = _subscribeDal.GetById(subscribeId);
		_subscribeDal.Delete(deletedSubscribe);
	}

	public SubscribeGetDto GetById(int subscribeId)
	{
		Subscribe subscribe =
			_subscribeDal.GetById(subscribeId);

		SubscribeGetDto response =
			_mapper.Map<SubscribeGetDto>(subscribe);
		return response;
	}

	public List<SubscribeGetDto> GetList()
	{
		List<Subscribe> subscribes =
			_subscribeDal.GetList();

		List<SubscribeGetDto> response =
			_mapper.Map<List<SubscribeGetDto>>(subscribes);
		return response;
	}

	public void Insert(SubscribeAddDto subscribeAddDto)
	{
		Subscribe subscribe =
			_mapper.Map<Subscribe>(subscribeAddDto);
		_subscribeDal.Insert(subscribe);
	}

	public void Update(SubscribeUpdateDto subscribeUpdateDto)
	{
		Subscribe subscribe =
		   _mapper.Map<Subscribe>(subscribeUpdateDto);

		_subscribeDal.Update(subscribe);
	}
}