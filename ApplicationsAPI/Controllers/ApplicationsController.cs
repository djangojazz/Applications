using ApplicationsDataAccess;
using ApplicationsDataAccess.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationsAPI.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class ApplicationsController : ControllerBase
    {
        private readonly IApplicationsRepository _applicationsRepository;

        public ApplicationsController(IApplicationsRepository applicationsRepository) => _applicationsRepository = applicationsRepository;

        [HttpGet]
        public async Task<IEnumerable<VCompanyRole>> GetRoles() => await _applicationsRepository.GetRolesAsync(x => x.CompanyId >= 0);
    }
}
