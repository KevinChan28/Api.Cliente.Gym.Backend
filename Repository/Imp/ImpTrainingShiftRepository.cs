using Aplication.Client.API.Context;
using Aplication.Client.API.Models;

namespace Aplication.Client.API.Repository.Imp
{
    public class ImpTrainingShiftRepository : ITrainingShiftRepository
    {
        DBContext _context;


        public ImpTrainingShiftRepository(DBContext context)
        {
            _context = context;
        }


        public async Task<List<TrainingShift>> GetAllTrainingShifts()
        {
            return _context.TrainingShift.AsEnumerable<TrainingShift>().ToList();
        }
    }
    
}
