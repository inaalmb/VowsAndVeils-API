using VowsAndVeils.Data.Models;
using AutoMapper;
using VowsAndVeils.DTOs;
namespace VowsAndVeils.Profiles
{
    public class WeddingDressMappingProfile : Profile
    {
        public WeddingDressMappingProfile()
        {
            CreateMap<WeddingDress, WeddingDressResponseDTO>();
            CreateMap<WeddingDressRequestDTO, WeddingDress>();
        }
    }
}
