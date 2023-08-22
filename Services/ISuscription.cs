using Aplication.Client.API.DTO;
using Aplication.Client.API.Models;

namespace Aplication.Client.API.Services
{
    public interface ISuscription
    {
        Task<SuscriptionExpire> GetSuscriptionToExpire(DateTime dateExpire, int numberPage, int numberRecords, bool isAsc);
        Task<SuscriptionExpire> GetSuscriptionToUser(String nameUser, int numberPage, int numberRecords, bool isAsc);

    }
}
