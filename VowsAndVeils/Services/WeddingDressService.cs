using Microsoft.EntityFrameworkCore;
using VowsAndVeils.Data;
using VowsAndVeils.Data.Models;
using VowsAndVeils.DTOs;
using VowsAndVeils.Interfaces;
namespace VowsAndVeils.Services
{
    public class WeddingDressService : IWeddingDressService
    {
        private readonly DatabaseContext databaseContext;
        private DatabaseContext _databaseContext;

        public WeddingDressService(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }
        public async Task<List<WeddingDress>> SearchWeddingDresses(SearchCriteriaDTO criteria)
        {
            var query = _databaseContext.WeddingDresses.AsQueryable();

            if (criteria.MinPrice.HasValue)
            {
                query = query.Where(wd => wd.Price >= criteria.MinPrice.Value);
            }
            if (criteria.MaxPrice.HasValue)
            {
                query = query.Where(wd => wd.Price <= criteria.MaxPrice.Value);
            }
            if (!string.IsNullOrEmpty(criteria.DressLength))
            {
                query = query.Where(wd => wd.DressLength == criteria.DressLength);
            }
            if (!string.IsNullOrEmpty(criteria.Size))
            {
                query = query.Where(wd => wd.Size == criteria.Size);
            }

            return await query.ToListAsync();
        }

        public async Task MakeAnAppointment(Appointment appointment)
        {
            var existingAppointment = await _databaseContext.Appointment
                .Where(a => a.AdvertisementId == appointment.AdvertisementId)
                .Where(a => a.StartDate < appointment.EndDate && a.EndDate > appointment.StartDate).FirstOrDefaultAsync();

            if (existingAppointment != null)
            {
                throw new InvalidOperationException("Termin je već zakazan");
            }

            await _databaseContext.Appointment.AddAsync(appointment);
            await _databaseContext.SaveChangesAsync();

        }

    }
}
