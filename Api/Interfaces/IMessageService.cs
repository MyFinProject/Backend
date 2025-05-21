namespace Api.Interfaces
{
    public interface IMessageService
    {
        public Task<string> SendMail(string email);
    }
}
