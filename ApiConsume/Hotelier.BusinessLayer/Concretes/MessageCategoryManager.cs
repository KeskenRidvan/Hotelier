using AutoMapper;
using Hotelier.BusinessLayer.Abstracts;
using Hotelier.DataAccessLayer.Repositories.Abstracts;
using Hotelier.DtoLayer.MessageCategories;
using Hotelier.EntityLayer.Concretes;

namespace Hotelier.BusinessLayer.Concretes;
public class MessageCategoryManager : IMessageCategoryService
{
    private readonly IMessageCategoryDal _messageCategoryDal;
    private readonly IMapper _mapper;

    public MessageCategoryManager(
        IMessageCategoryDal messageCategoryDal,
        IMapper mapper)
    {
        _messageCategoryDal = messageCategoryDal;
        _mapper = mapper;
    }

    public void Delete(int messageCategoryId)
    {
        var deletedMessageCategory = _messageCategoryDal.GetById(messageCategoryId);
        _messageCategoryDal.Delete(deletedMessageCategory);
    }

    public MessageCategoryGetDto GetById(int messageCategoryId)
    {
        MessageCategory messageCategory =
            _messageCategoryDal.GetById(messageCategoryId);

        MessageCategoryGetDto response =
            _mapper.Map<MessageCategoryGetDto>(messageCategory);
        return response;
    }

    public List<MessageCategoryGetDto> GetList()
    {
        List<MessageCategory> messageCategories =
            _messageCategoryDal.GetList();

        List<MessageCategoryGetDto> response =
            _mapper.Map<List<MessageCategoryGetDto>>(messageCategories);
        return response;
    }

    public void Insert(MessageCategoryAddDto messageCategoryAddDto)
    {
        MessageCategory messageCategory =
            _mapper.Map<MessageCategory>(messageCategoryAddDto);
        _messageCategoryDal.Insert(messageCategory);
    }

    public void Update(MessageCategoryUpdateDto messageCategoryUpdateDto)
    {
        MessageCategory messageCategory =
           _mapper.Map<MessageCategory>(messageCategoryUpdateDto);

        _messageCategoryDal.Update(messageCategory);
    }
}