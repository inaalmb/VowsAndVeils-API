using System.Collections.Generic;
using System.Threading.Tasks;
using VowsAndVeils.Data.Models;
using VowsAndVeils.DTOs;

namespace VowsAndVeils.Interfaces
{
    public interface IWeddingDressService
    {
        Task<List<WeddingDress>> SearchWeddingDresses(SearchCriteriaDTO criteria);
        Task MakeAnAppointment(Appointment appointment);
    }
}
