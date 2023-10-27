using LMS.UserProfile.API.Models;
using MongoFramework;

namespace LMS.UserProfile.API.Database
{
    public class UserProfileApiContext : MongoDbContext
    {
        public UserProfileApiContext(IMongoDbConnection connection) : base(connection)
        {
        }

        public MongoDbSet<UserProfileModel> Users { get; set; }
    }
}
