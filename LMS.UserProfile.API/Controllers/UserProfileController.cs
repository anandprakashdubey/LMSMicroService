using LMS.UserProfile.API.Models;
using LMS.UserProfile.API.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LMS.UserProfile.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProfileController : ControllerBase
    {
        private readonly IUserProfileRepository _repository;
        public UserProfileController(IUserProfileRepository repository)
        {
            _repository = repository;
        }

        [HttpPost("createuser")]
        public async Task<UserProfileModel> CreateUser(UserProfileModel user)
        {
            return await _repository.CreateUser(user);
        }

        [HttpGet("userbyemail")]
        public async Task<UserProfileModel> GetUserProfileByEmail(string email)
        {
            return await _repository.GetUserByEmail(email);
        }
    }
}
