using VowsAndVeils.DTOs;

namespace VowsAndVeils.Interfaces
{
    public interface IPostService
    {
        Task<WeddingDressResponseDTO> CreateWeddingDress(WeddingDressRequestDTO request);
        Task<List<WeddingDressResponseDTO>> GetSalonOwner(int SalonOwnerId);

    }
}
