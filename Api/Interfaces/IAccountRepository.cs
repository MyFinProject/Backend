namespace Api.Interfaces
{
    public interface IAccountRepository
    {
        public Task<Boolean> CheckEmail(string Email);
    }
}
