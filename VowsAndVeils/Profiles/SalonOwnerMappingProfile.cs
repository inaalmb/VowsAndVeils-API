using VowsAndVeils.Data.Models;
using AutoMapper;
using VowsAndVeils.DTOs;
namespace VowsAndVeils.Profiles
{
    public class SalonOwnerMappingProfile : Profile
    {
        public SalonOwnerMappingProfile()
        {
            CreateMap<SalonOwner, SalonOwnerResponseDTO>();
            CreateMap<SalonOwnerRequestDTO, SalonOwner>();
        }
    }
}
