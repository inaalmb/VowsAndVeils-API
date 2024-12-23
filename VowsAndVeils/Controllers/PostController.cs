using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VowsAndVeils.Data.Models;
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
        [HttpGet("appoitments/{SalonOwnerId}")]
        [Authorize]
        public async Task<IActionResult> GetAppointmentForOwner(int SalonOwnerId)
        {
            var appointments = await _postService.GetAppointmentForOwner(SalonOwnerId);

            return Ok(appointments);
        }

        [HttpDelete("{weddingDressId}")]
        [Authorize]
        public async Task<IActionResult> DeleteWeddingDress(int weddingDressId)
        {
            try
            {
                // Preuzmi ID trenutnog korisnika iz tokena
                var SalonOwnerId = int.Parse(User.FindFirst("id")?.Value ?? "0");

                await _postService.DeleteWeddingDress(weddingDressId, SalonOwnerId);
                return Ok(new { Message = "WeddingDress deleted successfully." });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { Message = ex.Message });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }

        }
    }
}
