namespace Hotelier.DtoLayer.Contacts;
public class ContactAddDto
{
    public string Name { get; set; }
    public string Mail { get; set; }
    public string Subject { get; set; }
    public string Message { get; set; }
    public DateTime Date { get; set; }
    public int MessageCategoryID { get; set; }
}
