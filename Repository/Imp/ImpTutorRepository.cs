using Aplication.Client.API.Models;
using Aplication.Client.API.Context;
using Aplication.Client.API.Services;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Aplication.Client.API.Repository.Imp
{
    public class ImpTutorRepository : ITutorRepository
    {
        DBContext _context;


        public ImpTutorRepository(DBContext context)
        {
            _context = context;
        }


        public async Task<int> AddTutor(Tutor tutor)
        {
            EntityEntry<Tutor> entityEntryTutor = await _context.Tutor.AddAsync(tutor);
            await _context.SaveChangesAsync();

            return entityEntryTutor.Entity.Id;
        }
    }
}
