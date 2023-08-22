using Aplication.Client.API.Models;

namespace Aplication.Client.API.Repository
{
    public interface ITrainingShiftRepository
    {
        Task<List<TrainingShift>> GetAllTrainingShifts();
    }
}
