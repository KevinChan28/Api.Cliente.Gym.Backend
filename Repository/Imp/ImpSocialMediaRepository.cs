using Aplication.Client.API.Context;
using Aplication.Client.API.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Aplication.Client.API.Repository.Imp
{
    public class ImpSocialMediaRepository : ISocialMediaRepository
    {
        DBContext _context;
        
        
        public ImpSocialMediaRepository(DBContext context)
        {
            _context = context;
        }


        public async Task<int> RegisterSocialMedia(SocialMedia socialMedia)
        {
            EntityEntry<SocialMedia> entityEntrySocialMedia = await _context.SocialMedia.AddAsync(socialMedia);
            await _context.SaveChangesAsync();

            return entityEntrySocialMedia.Entity.Id;
        }
    }
}
