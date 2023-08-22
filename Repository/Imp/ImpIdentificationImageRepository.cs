using Aplication.Client.API.Context;
using Aplication.Client.API.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Aplication.Client.API.Repository.Imp
{
    public class ImpIdentificationImageRepository : IIdentificationImageRepository
    {
        DBContext _context;


        public ImpIdentificationImageRepository(DBContext context)
        {
            _context = context;
        }

        public async Task<int> AddIdentificationImage(IdentificationImage identificationImage)
        {
            try
            {
                EntityEntry<IdentificationImage> entityEntry = _context.Add(identificationImage);
                await _context.SaveChangesAsync();
                return entityEntry.Entity.Id;
            }
            catch (Exception ex)
            {
                var e = ex;
                return 0;
            }
        }
    }
}
