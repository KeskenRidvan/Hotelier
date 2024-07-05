using AutoMapper;
using Hotelier.BusinessLayer.Abstracts;
using Hotelier.DataAccessLayer.Repositories.Abstracts;
using Hotelier.DtoLayer.SendMessages;
using Hotelier.EntityLayer.Concretes;

namespace Hotelier.BusinessLayer.Concretes;
public class SendMessageManager : ISendMessageService
{
    private readonly ISendMessageDal _sendMessageDal;
    private readonly IMapper _mapper;

    public SendMessageManager(
        ISendMessageDal sendMessageDal,
        IMapper mapper)
    {
        _sendMessageDal = sendMessageDal;
        _mapper = mapper;
    }

    public void Delete(int sendMessageId)
    {
        var deletedSendMessage = _sendMessageDal.GetById(sendMessageId);
        _sendMessageDal.Delete(deletedSendMessage);
    }

    public SendMessageGetDto GetById(int sendMessageId)
    {
        SendMessage sendMessage =
            _sendMessageDal.GetById(sendMessageId);

        SendMessageGetDto response =
            _mapper.Map<SendMessageGetDto>(sendMessage);
        return response;
    }

    public List<SendMessageGetDto> GetList()
    {
        List<SendMessage> sendMessages =
            _sendMessageDal.GetList();

        List<SendMessageGetDto> response =
            _mapper.Map<List<SendMessageGetDto>>(sendMessages);
        return response;
    }

    public int GetSendMessageCount()
    {
        return _sendMessageDal.GetSendMessageCount();
    }

    public void Insert(SendMessageAddDto sendMessageAddDto)
    {
        SendMessage sendMessage =
            _mapper.Map<SendMessage>(sendMessageAddDto);
        _sendMessageDal.Insert(sendMessage);
    }

    public void Update(SendMessageUpdateDto sendMessageUpdateDto)
    {
        SendMessage sendMessage =
           _mapper.Map<SendMessage>(sendMessageUpdateDto);

        _sendMessageDal.Update(sendMessage);
    }
}