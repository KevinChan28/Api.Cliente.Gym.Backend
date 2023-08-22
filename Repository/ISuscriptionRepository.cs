using System.Threading.Tasks;
using Aplication.Client.API.DTO;
using Aplication.Client.API.Models;

namespace Aplication.Client.API.Repository
{
    public interface ISuscriptionRepository
    {
        Task<List<SuscriptionToExpireData>> GetSuscriptionToExpire(DateTime dateExpire, int numberPage, int numberRecords, bool isAsc);
        Task<List<SuscriptionToExpireData>> GetSuscriptionToNameUser(String nameUser, int numberPage, int numberRecords, bool isAsc);
    }
}
