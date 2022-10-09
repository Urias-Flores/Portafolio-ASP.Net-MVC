using Portafolio_MVC.Models;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace Portafolio_MVC.Services
{
    public interface ISendGridService
    {
        Task Send(ContactoDTO contacto);
    }

    public class SendGridService : ISendGridService
    {
        public readonly IConfiguration configuration;

        public SendGridService(IConfiguration configuration) {
            this.configuration = configuration;
        }

        public async Task Send(ContactoDTO contacto)
        {
            var APIkey = configuration.GetValue<string>("SENDGRID_API_KEY");
            var Email = configuration.GetValue<string>("SENDGRID_FROM");
            var Name = configuration.GetValue<string>("SENDGRID_NAME");

            var client = new SendGridClient(APIkey);
            var from = new EmailAddress(Email, Name);
            var to = new EmailAddress(Email, Name);
            var subject = $"El cliente {contacto.Nombre} quiere contactarse contigo.";
            var message = contacto.Mensaje;
            var HTMLcontent = @$"De: {contacto.Nombre}
                                 Email: {contacto.Correo}
                                 Mensaje: {contacto.Mensaje}";

            var singleEmail = MailHelper.CreateSingleEmail(from, to, subject, message, HTMLcontent);
            var result = await client.SendEmailAsync(singleEmail);
        }
    }
}
