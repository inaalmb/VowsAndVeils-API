using AutoMapper;
using VowsAndVeils.Data.Models;
using VowsAndVeils.DTOs;

namespace VowsAndVeils.Profiles
{
    public class AdminMappingProfile :Profile
    {
       public AdminMappingProfile()
        {
            CreateMap<Users, UserResponseDTO>();
            CreateMap<RegisterUserRequestDTO, Users>();
        }
    }
}
