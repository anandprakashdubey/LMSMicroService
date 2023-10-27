using LMS.PharmacyService.API.Models;
using LMS.PharmacyService.API.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LMS.PharmacyService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicineController : ControllerBase
    {
        private readonly IMedicineRepository _repository;
        public MedicineController(IMedicineRepository repository)
        {
            _repository = repository;
        }

        [HttpPost("createmedicine")]
        public async Task<Medicine> CreateMedicine(Medicine med)
        {
            return await _repository.CreateMedicine(med);
        }

        [HttpGet("medicinebyid")]
        public async Task<Medicine> GetMedicineById(int id)
        {
            return await _repository.GetMedicineById(id);
        }

        [HttpGet("medicines")]
        public async Task<IEnumerable<Medicine>> GetMedicines()
        {
            return await _repository.GetMedicines();
        }
    }
}
