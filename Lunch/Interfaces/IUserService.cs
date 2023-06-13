using Lunch.Models;

namespace Lunch.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserModel>> GetUsers();

        Task<UserModel?> GetUserById(Guid userId);

        Task<UserModel> CreateUser(UserModel userModel);

        Task<UserModel?> UpdateUser(UserModel userModel);

        Task<bool> DeleteUser(Guid userId);
    }
}