using LMS.UserProfile.API.Database;
using LMS.UserProfile.API.Models;
using MongoFramework.Linq;

namespace LMS.UserProfile.API.Repository
{
    public class UserProfileRepository : IUserProfileRepository
    {
        private readonly UserProfileApiContext _context;
        public UserProfileRepository(UserProfileApiContext context)
        {
            _context = context;
        }
        public async Task<UserProfileModel> CreateUser(UserProfileModel user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<UserProfileModel> GetUserByEmail(string email)
        {
            return await _context.Users.Where(x => x.Email.ToLower() == email.ToLower()).FirstOrDefaultAsync();
        }
    }
}
