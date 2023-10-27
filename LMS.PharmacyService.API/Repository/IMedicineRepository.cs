using LMS.PharmacyService.API.Models;

namespace LMS.PharmacyService.API.Repository
{
    public interface IMedicineRepository
    {
        public Task<IEnumerable<Medicine>> GetMedicines();

        public Task<Medicine> GetMedicineById(int id);

        public Task<Medicine> CreateMedicine(Medicine med);

    }
}
