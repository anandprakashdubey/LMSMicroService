using LMS.PharmacyService.API.Models;

namespace LMS.PharmacyService.API.Repository
{
    public interface IPharmacyServiceRepository
    {
        public Task<IEnumerable<PharmacyServiceModel>> GetPharmacies();

        public Task<PharmacyServiceModel> GetPharmacyById(int id);

        public Task<PharmacyServiceModel> CreatePharmacy(PharmacyServiceModel pharmacy);

    }
}
