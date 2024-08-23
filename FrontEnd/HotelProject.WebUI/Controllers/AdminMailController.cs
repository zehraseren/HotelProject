using MimeKit;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using HotelProject.WebUI.Models.Mail;

namespace HotelProject.WebUI.Controllers
{
    public class AdminMailController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(AdminMailViewModel amvm)
        {
            MimeMessage mimeMessage = new MimeMessage();

            MailboxAddress mailboxAddress = new MailboxAddress("HotelierAdmin", "fatmazehraseren@gmail.com");
            mimeMessage.From.Add(mailboxAddress);

            MailboxAddress mailboxAddressTo = new MailboxAddress("User", amvm.ReceiverMail);
            mimeMessage.To.Add(mailboxAddressTo);

            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = amvm.Body;
            mimeMessage.Body = bodyBuilder.ToMessageBody();

            mimeMessage.Subject = amvm.Subject;

            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Connect("smtp.gmail.com", 587, false);
            smtpClient.Authenticate("fatmazehraseren@gmail.com", "xyuvmkdnumyfpndu");
            smtpClient.Send(mimeMessage);
            smtpClient.Disconnect(true);

            // Gönderilen mailin database'e kaydedilmesi

            return View();
        }
    }
}
