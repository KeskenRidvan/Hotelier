using Hotelier.DtoLayer.MessageCategories;

namespace Hotelier.BusinessLayer.Abstracts;

public interface IMessageCategoryService
{
    void Insert(MessageCategoryAddDto messageCategoryAddDto);
    void Delete(int messageCategoryId);
    void Update(MessageCategoryUpdateDto messageCategoryUpdateDto);
    List<MessageCategoryGetDto> GetList();
    MessageCategoryGetDto GetById(int messageCategoryId);
}