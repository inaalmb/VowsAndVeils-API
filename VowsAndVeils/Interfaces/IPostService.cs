using VowsAndVeils.Data.Models;
using VowsAndVeils.DTOs;

namespace VowsAndVeils.Interfaces
{
    public interface IPostService
    {
        Task<WeddingDressResponseDTO> CreateWeddingDress(WeddingDressRequestDTO request);
        Task<List<WeddingDressResponseDTO>> GetSalonOwner(int SalonOwnerId);
        Task<List<Appointment>> GetAppointmentForOwner(int SalonOwnerId);
        Task DeleteWeddingDress(int weddingDressId, int SalonOwnerId);

    }
}
