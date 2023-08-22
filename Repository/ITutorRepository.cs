using Aplication.Client.API.Models;

namespace Aplication.Client.API.Repository
{
    public interface ITutorRepository
    {
        Task<int> AddTutor(Tutor tutor);
    }
}
