using Lunch.Entities;
using Lunch.Models;

namespace Lunch.Mappers
{
    public static class UserMapper
    {
        public static UserModel GetUserMap(User user)
        {
            return new UserModel()
            {
                Id = user.Id,
                Username = user.Username,
                Password = user.Password,
                FirstName = user.FirstName,
                LastName = user.LastName,
            };
        }

        public static ICollection<UserModel> GetUsersMap(IEnumerable<User> users)
        {
            ICollection<UserModel> userList = new List<UserModel>();

            foreach (var user in users)
            {
                userList.Add(new UserModel()
                {
                    Id = user.Id,
                    Username = user.Username,
                    Password = user.Password,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                });
            }

            return userList;
        }

        public static User CreateOrUpdateUserMap(UserModel userModel)
        {
            return new User()
            {
                Username = userModel.Username,
                Password = userModel.Password,
                FirstName = userModel.FirstName,
                LastName = userModel.LastName,
            };
        }
    }
}