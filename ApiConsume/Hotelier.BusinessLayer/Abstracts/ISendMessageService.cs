using Hotelier.DtoLayer.SendMessages;

namespace Hotelier.BusinessLayer.Abstracts;

public interface ISendMessageService
{
    void Insert(SendMessageAddDto sendMessageAddDto);
    void Delete(int sendMessageId);
    void Update(SendMessageUpdateDto sendMessageUpdateDto);
    List<SendMessageGetDto> GetList();
    SendMessageGetDto GetById(int sendMessageId);
    int GetSendMessageCount();
}