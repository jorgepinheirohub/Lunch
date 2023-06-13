using Lunch.Interfaces;
using Lunch.Mappers;
using Lunch.Models;
using Lunch.Repositories;

namespace Lunch.Services
{
    public class UserService : IUserService
    {
        private readonly UserRepository _userRepository;

        public UserService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserModel> CreateUser(UserModel userModel)
        {
            var user = await _userRepository.CreateUser(UserMapper.CreateOrUpdateUserMap(userModel));
            return UserMapper.GetUserMap(user);
        }

        public async Task<UserModel?> GetUserById(Guid userId)
        {
            var user = await _userRepository.GetUserById(userId);
            
            if (user == null)
                return null;

            return UserMapper.GetUserMap(user);
        }

        public async Task<IEnumerable<UserModel>> GetUsers()
        {
            var users = await _userRepository.GetUsers();

            return UserMapper.GetUsersMap(users);
        }

        public async Task<UserModel?> UpdateUser(UserModel userModel)
        {
            var user = await _userRepository.GetUserById(userModel.Id);

            if (user == null)
                return null;

            await _userRepository.UpdateUser(UserMapper.CreateOrUpdateUserMap(userModel));

            return userModel;
        }

        public async Task<bool> DeleteUser(Guid userId)
        {
            var user = await _userRepository.GetUserById(userId);

            if (user == null)
                return false;

            await _userRepository.DeleteUser(user);

            return true;
        }
    }
}