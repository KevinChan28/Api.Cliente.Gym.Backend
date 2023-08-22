using Aplication.Client.API.Models;

namespace Aplication.Client.API.Services
{
    public interface ITrainingShift
    {
        Task<List<TrainingShift>> GetTrainingShifts();
    }
}
