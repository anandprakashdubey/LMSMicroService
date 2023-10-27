using LMS.UserProfile.API.Models;

namespace LMS.UserProfile.API.Repository
{
    public interface IUserProfileRepository
    {
        public Task<UserProfileModel> GetUserByEmail(string email);

        public Task<UserProfileModel> CreateUser(UserProfileModel user);
    }
}
