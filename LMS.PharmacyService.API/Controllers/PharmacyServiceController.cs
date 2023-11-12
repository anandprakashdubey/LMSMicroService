using LMS.PharmacyService.API.Models;
using LMS.PharmacyService.API.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LMS.PharmacyService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PharmacyServiceController : ControllerBase
    {
        private readonly IPharmacyServiceRepository _repository;
        public PharmacyServiceController(IPharmacyServiceRepository repository)
        {
            _repository = repository;
        }

        [HttpPost("createpharmacy")]
        public async Task<PharmacyServiceModel> CreatePharmacy(PharmacyServiceModel pharmacy)
        {
            return await _repository.CreatePharmacy(pharmacy);
        }

        [HttpGet("pharmacybyid/{id:int}")]
        public async Task<PharmacyServiceModel> GetPharmacyById(int id)
        {
            return await _repository.GetPharmacyById(id);
        }

        [HttpGet("pharmacies")]
        public async Task<IEnumerable<PharmacyServiceModel>> GetPharmacies()
        {
            return await _repository.GetPharmacies();
        }
    }
}
