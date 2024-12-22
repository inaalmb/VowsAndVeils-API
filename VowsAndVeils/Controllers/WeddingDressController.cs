using Microsoft.AspNetCore.Mvc;
using VowsAndVeils.DTOs;
using VowsAndVeils.Interfaces;

namespace VowsAndVeils.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeddingDressController : ControllerBase
    {
        private readonly IWeddingDressService _weddingDressService;
        public WeddingDressController(IWeddingDressService weddingDressService)
        {
            _weddingDressService = weddingDressService;
        }

        [HttpGet("search")]
        public async Task<IActionResult> SearchWeddingDresses([FromQuery] SearchCriteriaDTO criteria)
        {
            var results = await _weddingDressService.SearchWeddingDresses(criteria);
            return Ok(results);
        }
    }
}