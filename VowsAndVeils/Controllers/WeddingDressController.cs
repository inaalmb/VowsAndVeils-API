using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VowsAndVeils.Data.Models;
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

        [HttpPost("reserve")]
        [Authorize]
        public async Task<IActionResult> MakeAnAppointment([FromBody] AppointmentRequestDTO request)
        {
            try
            {
                var appointment = new Appointment
                {
                    WeddingDressId = request.WeddingDressId,
                    UserId = request.UserId,
                    StartDate = request.StartDate,
                    EndDate = request.EndDate,
                };
                await _weddingDressService.MakeAnAppointment(appointment);
                return Ok(new { Message = "Successfully created an appointment" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }
        [HttpPost("rate")]
        [Authorize]
        public async Task<IActionResult> RateWeddingDress([FromBody] RatingRequestDTO request)
        {
            var rating = new Rating
            {
                UserId = request.UserId,
                WeddingDressId = request.WeddingDressId,
                Score = request.Score,
            };

            await _weddingDressService.AddRating(rating);
            return Ok(new { Message = "Hvala na povratnim informacijama" });
        }
    }
}
