using System.Collections.Generic;
using System.Threading.Tasks;
using Speciality_Metals_Back_End.SpecialityMetals_Models.GRV;
namespace Speciality_Metals_Back_End.SpecialityMetals_Models.GRV
{
    public interface IGRVRepository
    {
        Task<IEnumerable<GRVS>> GetAllGRVsAsync();
        Task<GRVS> GetGRVByIdAsync(int id);
        Task<GRVS> AddGRVAsync(GRVS grv);
        Task<GRVS> UpdateGRVAsync(GRVS grv);
        Task<bool> DeleteGRVAsync(int id);
    }
}
