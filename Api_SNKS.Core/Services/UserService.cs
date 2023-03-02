using Api_SNKS.Core.Intrerfaces.Users;
using Api_SNKS.Core.Models;

namespace Api_SNKS.Core.Services
{
    public class UserService : IUserService
    {
        public IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> GetProfileUserAsync(string id)
        {
            return await _userRepository.GetProfileUserAsync(id);
        }

    }
}
