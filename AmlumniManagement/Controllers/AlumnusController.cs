using Business;
using DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AmlumniManagement.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AlumnusController : ControllerBase
    {
        private readonly ILogger<AlumnusController> _logger;
        private readonly AlumniBusiness alumniBusiness;

        public AlumnusController(ILogger<AlumnusController> logger)
        {
            _logger = logger;
            alumniBusiness = new AlumniBusiness();
        }

        [HttpGet(Name = "GetAmlumnus")]
        public async Task<IActionResult> GetById(int alumnusId)
        {
            var alumnus = await alumniBusiness.GetAlumnusAsync(alumnusId);
            return Ok(alumnus);
        }
    }
}