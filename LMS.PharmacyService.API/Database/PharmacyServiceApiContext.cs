using LMS.PharmacyService.API.Models;
using MongoFramework;

namespace LMS.PharmacyService.API.Database
{
    public class PharmacyServiceApiContext : MongoDbContext
    {
        public PharmacyServiceApiContext(IMongoDbConnection connection) : base(connection)
        {
        }

        public MongoDbSet<PharmacyServiceModel> Pharmacy { get; set; }
        public MongoDbSet<Medicine> Medicine { get; set; }
    }
}
