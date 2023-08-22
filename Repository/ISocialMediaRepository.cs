using Aplication.Client.API.Models;

namespace Aplication.Client.API.Repository
{
    public interface ISocialMediaRepository
    {
        public Task<int> RegisterSocialMedia(SocialMedia socialMedia);
    }
}
