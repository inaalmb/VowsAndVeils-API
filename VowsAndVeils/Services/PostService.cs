using Azure.Core;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using VowsAndVeils.Data;
using VowsAndVeils.Data.Models;
using VowsAndVeils.DTOs;
using VowsAndVeils.Interfaces;

namespace VowsAndVeils.Services
{
    public class PostService : IPostService
    {
        private readonly DatabaseContext _databaseContext;

        public PostService(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<WeddingDressResponseDTO> CreateWeddingDress(WeddingDressRequestDTO request)
        {
            var weddingDress = new WeddingDress
            {
                UrlPhoto = request.UrlPhoto,
                Name = request.Name,
                Price = request.Price,
                Status = true,
                Size = request.Size,
                SalonOwnerId = request.SalonOwnerId,
                DressLength = request.DressLength
            };

            await _databaseContext.WeddingDresses.AddAsync(weddingDress);
            await _databaseContext.SaveChangesAsync();

            return new WeddingDressResponseDTO
            {
                Id = weddingDress.Id,
                UrlPhoto = request.UrlPhoto,
                Name = request.Name,
                Price = request.Price,
                Status = true,
                Size = request.Size,
                SalonOwnerId = request.SalonOwnerId,
                DressLength = request.DressLength
            };
        }


        public async Task<List<WeddingDressResponseDTO>> GetSalonOwner(int salonOwnerId)
        {
            var weddingDress = await _databaseContext.WeddingDresses
                .Where(wd => wd.SalonOwnerId == salonOwnerId)
                .Select(wd => new WeddingDressResponseDTO
                {
                    Id = wd.Id,
                    UrlPhoto = wd.UrlPhoto,
                    Name = wd.Name,
                    Price = wd.Price,
                    Status = true,
                    Size = wd.Size,
                    SalonOwnerId = wd.SalonOwnerId,
                    DressLength = wd.DressLength
                })
                .ToListAsync();
            return weddingDress;
        }
    }
}
  