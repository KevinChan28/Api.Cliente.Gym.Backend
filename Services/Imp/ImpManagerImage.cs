using Aplication.Client.API.DTO;
using Microsoft.Extensions.Options;

namespace Aplication.Client.API.Services.Imp
{
    public class ImpManagerImage : IManagerImage
    {
        private readonly Image _image;
        private readonly ServerMode _serverMode;

        public ImpManagerImage(IOptionsMonitor<ServerMode> oMServerMode, IOptionsMonitor<Image> oMImage)
        {
            _serverMode = oMServerMode.CurrentValue;
            _image = oMImage.CurrentValue;
        }


        public async Task<string> GenerateImageName(string customerEmail)
        {
            string imageName = $"{customerEmail}-{DateTimeOffset.UtcNow.ToUnixTimeMilliseconds()}";
            return imageName;
        }

        public async Task<string> GetImageToBase64(string pathImage)
        {
            try
            {
                if (!_serverMode.IsOnlineServer)
                {
                    byte[] imageArray = System.IO.File.ReadAllBytes(pathImage);
                    return Convert.ToBase64String(imageArray);
                }
                else
                {
                    return _image.DefaultEncodedBase64;
                }

            } catch(Exception ex)
            {
                return null;
            }
        }

        public async Task<PathImageInformation> SaveImage(IdentificationImageData imageData)
        {
            try
            {
                string pathImage;
                if (!_serverMode.IsOnlineServer)
                {
                    pathImage = $"{_image.PathToSave}\\{await GenerateImageName(imageData.CustomerEmail)}.{imageData.MimeType.Substring(imageData.MimeType.IndexOf('/') + 1)}";
                    int indexOfComa = imageData.Base64ImageString.IndexOf(',');
                    string base64 = imageData.Base64ImageString.Substring(indexOfComa + 1);
                    await File.WriteAllBytesAsync(pathImage, Convert.FromBase64String(base64));
                } 
                else
                {
                    pathImage = $"{_image.PathToSave}\\DefaultImage.{imageData.MimeType.Substring(imageData.MimeType.IndexOf('/') + 1)}";
                }
                return new PathImageInformation
                {
                    PathImage = pathImage
                };
            }
            catch(Exception ex)
            {
                return null;
            }
        }
    }
}
