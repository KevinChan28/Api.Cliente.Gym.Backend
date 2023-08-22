using Aplication.Client.API.Models;
using Aplication.Client.API.Repository;

namespace Aplication.Client.API.Services.Imp
{
    public class ImpTrainingShift : ITrainingShift
    {
        private ITrainingShiftRepository _trainingShiftRepository;


        public ImpTrainingShift(ITrainingShiftRepository trainingShiftRepository)
        {
            _trainingShiftRepository = trainingShiftRepository;
        }


        public async Task<List<TrainingShift>> GetTrainingShifts()
        {
            List<TrainingShift> trainingShifts = await _trainingShiftRepository.GetAllTrainingShifts();
            return trainingShifts;
        }
    }
}
