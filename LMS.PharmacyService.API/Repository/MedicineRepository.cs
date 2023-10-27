using LMS.PharmacyService.API.Database;
using LMS.PharmacyService.API.Models;
using MongoFramework.Linq;

namespace LMS.PharmacyService.API.Repository
{
    public class MedicineRepository : IMedicineRepository
    {
        private readonly PharmacyServiceApiContext _context;
        public MedicineRepository(PharmacyServiceApiContext context)
        {
            _context = context;
        }

        public async Task<Medicine> CreateMedicine(Medicine med)
        {
            var isAlreadyExists = await _context.Medicine.Where(x => x.Id == med.Id).FirstOrDefaultAsync();
            if (isAlreadyExists == null)
            {
                _context.Medicine.Add(med);
            }
            else
            {
                _context.Medicine.Update(med);
            }

            await _context.SaveChangesAsync();
            return med;
        }

        public async Task<Medicine> GetMedicineById(int id)
        {
            return await _context.Medicine.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Medicine>> GetMedicines()
        {
            return await _context.Medicine.ToListAsync();
        }
    }
}
