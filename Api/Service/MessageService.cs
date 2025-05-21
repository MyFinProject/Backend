using Api.Interfaces;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using System.Threading.Tasks;

namespace Api.Service
{
    public class MessageService : IMessageService
    {
        public string CreateCode()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            Random rnd = new Random();
            return new string(Enumerable.Repeat(chars, 5).Select(s => s[rnd.Next(s.Length)]).ToArray());
        }
        public async Task<string> SendMail(string email)
        {
            var message = new MimeMessage();
            var code = CreateCode();
            message.From.Add(new MailboxAddress("FinProject", "solovievyegor@yandex.ru"));
            message.To.Add(new MailboxAddress("", email));
            message.Subject = "Код подтверждения";

            message.Body = new TextPart()
            {
                Text = $"Код подтверждение: {code}"
            };

            using (var client = new SmtpClient())
            {
                await client.ConnectAsync("smtp.yandex.ru", 465, SecureSocketOptions.Auto);
                await client.AuthenticateAsync("solovievyegor@yandex.ru", "mnemidvkzfkekjhv");
                await client.SendAsync(message);
                await client.DisconnectAsync(true);
            }
            return code;
        }
    }
}
