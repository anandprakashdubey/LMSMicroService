using LMS.PharmacyService.API.Database;
using LMS.PharmacyService.API.Models;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using MongoFramework.Linq;
using SharpCompress.Common;
using System;

namespace LMS.PharmacyService.API.Repository
{
    public class PharmacyServiceRepository : IPharmacyServiceRepository
    {
        private readonly PharmacyServiceApiContext _context;
        public PharmacyServiceRepository(PharmacyServiceApiContext context)
        {
            _context = context;
        }
        public async Task<PharmacyServiceModel> CreatePharmacy(PharmacyServiceModel pharmacy)
        {
            
            var isAlreadyExists = await _context.Pharmacy.Where(x => x.Id == pharmacy.Id).FirstOrDefaultAsync();
            if(isAlreadyExists == null)
            {
                _context.Pharmacy.Add(pharmacy);
            }
            else
            {
                _context.Pharmacy.Update(pharmacy);
            }
            
            await _context.SaveChangesAsync();
            return pharmacy;
        }

        public async Task<IEnumerable<PharmacyServiceModel>> GetPharmacies()
        {
            return await _context.Pharmacy.ToListAsync();
        }

        public async Task<PharmacyServiceModel> GetPharmacyById(int id)
        {
            return await _context.Pharmacy.Where(x => x.Id == id).FirstOrDefaultAsync();
        }
    }
}
