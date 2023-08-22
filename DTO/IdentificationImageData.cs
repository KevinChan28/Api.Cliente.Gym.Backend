namespace Aplication.Client.API.DTO
{
    public class IdentificationImageData
    {
        public string? CustomerEmail { get; set; }
        public string MimeType { get; set; }
        public string Base64ImageString { get; set; }
    }

    public class PathImageInformation
    {
        public string PathImage { get; set; }
    }
}
