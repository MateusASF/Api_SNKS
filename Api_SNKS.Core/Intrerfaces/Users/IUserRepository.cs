using Api_SNKS.Core.Models;


namespace Api_SNKS.Core.Intrerfaces.Users
{
    public interface IUserRepository
    {
        Task <User> GetProfileUserAsync(string id);
    }
}
