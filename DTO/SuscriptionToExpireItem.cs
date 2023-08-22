using Microsoft.VisualBasic;

namespace Aplication.Client.API.DTO
{
    public class SuscriptionToExpireItem
    {
        public int SuscriptionId { get; set; }
        public int CustomerId { get; set; }
        public bool? IsDeptor { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public string EndDate { get; set; }
        public string PathImage { get; set; }
        public string MimeType { get; set; }
    }
}
