using Hotelier.WebUI_Asp.Models.Mails;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;

namespace Hotelier.WebUI_Asp.Controllers;
public class AdminMailsController : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Index(AdminMailViewModel model)
    {
        MimeMessage mimeMessage = new MimeMessage();

        MailboxAddress mailboxAddressFrom = new MailboxAddress("HotelierAdmin", "birmailadresi@gmail.com");
        mimeMessage.From.Add(mailboxAddressFrom);

        MailboxAddress mailboxAddressTo = new MailboxAddress("User", model.ReceiverMail);
        mimeMessage.To.Add(mailboxAddressTo);

        var bodyBuilder = new BodyBuilder();
        bodyBuilder.TextBody = model.Body;
        mimeMessage.Body = bodyBuilder.ToMessageBody();

        mimeMessage.Subject = model.Subject;

        SmtpClient client = new SmtpClient();
        client.Connect("smtp.gmail.com", 587, false);
        client.Authenticate("birmailadresi@gmail.com", "mail adresi password key");
        client.Send(mimeMessage);
        client.Disconnect(true);

        //Gönderilen Mailin Veri Tabanına Kaydedilmesi.


        return View();
    }
}
