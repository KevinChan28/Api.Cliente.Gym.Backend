using Aplication.Client.API.DTO;

namespace Aplication.Client.API.Services
{
    public interface IManagerImage
    {
        Task<PathImageInformation> SaveImage(IdentificationImageData imageData);
        Task<string> GenerateImageName(string customerEmail);
        Task<string> GetImageToBase64(string pathImage);
    }
}
