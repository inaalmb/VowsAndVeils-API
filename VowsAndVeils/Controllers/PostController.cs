using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VowsAndVeils.DTOs;
using VowsAndVeils.Interfaces;

namespace VowsAndVeils.Controllers
{ 
    [ApiController]
    [Route("api/[controller]")]
    public class PostController : ControllerBase
    {
        private readonly IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpPost("create")]
        [Authorize]
        public async Task<IActionResult> CreateWeddingDress([FromBody] WeddingDressRequestDTO request)
        {
            var post = await _postService.CreateWeddingDress(request);
            return Ok(post);
        }

        [HttpGet("owner/{SalonOwnerId}")]
        [Authorize]
        public async Task<IActionResult> GetSalonOwner(int salonOwnerId)
        {
            var post = await _postService.GetSalonOwner(salonOwnerId);
            return Ok(post);
        }
    }
}
