
using GoingTo_API_DP.Domain.Model.Accounts;
using GoingTo_API_DP.Domain.Services.Accounts;
using GoingTo_API_DP.Extensions;
using GoingTo_API_DP.Resources;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GoingTo_API_DP.Controllers
{
    [Route("/api/[controller]")]
    public class UserProfilesController : Controller
    {
        private readonly IUserProfileService _profileService;
        private readonly AutoMapper.IMapper _mapper;

        public UserProfilesController(IUserProfileService profileService, AutoMapper.IMapper mapper)
        {
            _profileService = profileService;
            _mapper = mapper;
        }


        /// <summary>
        /// returns all the profiles in the system
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<UserProfileResource>> GetAllAsync()
        {
            var profiles = await _profileService.ListAsync();
            var resource = _mapper.Map<IEnumerable<UserProfile>, IEnumerable<UserProfileResource>>(profiles);
            return resource;
        }


        /// <summary>
        /// add a profile in the system
        /// </summary>
        /// <param name="resource"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveProfileResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages()); 
            var profile = _mapper.Map<SaveProfileResource, UserProfile>(resource);
            var result = await _profileService.SaveAsync(profile); 

            if (!result.Success)
                return BadRequest(result.Message); 

            var profileResource = _mapper.Map<UserProfile, UserProfileResource>(result.Profile); 
            return Ok(profileResource);
        }


        /// <summary>
        /// modify a profile in the system
        /// </summary>
        /// <param name="id"></param>
        /// <param name="resource"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveProfileResource resource)
        {
            var profile = _mapper.Map<SaveProfileResource,UserProfile>(resource);
            var result = await _profileService.UpdateAsync(id, profile);

            if (!result.Success)
                return BadRequest(result.Message);

            var profileResource = _mapper.Map<UserProfile, UserProfileResource>(result.Profile);
            return Ok(profileResource);
        }


        /// <summary>
        /// remove a profile in the system
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _profileService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var profileResource = _mapper.Map<UserProfile, UserProfileResource>(result.Profile);
            return Ok(profileResource);
        }
    }
}
