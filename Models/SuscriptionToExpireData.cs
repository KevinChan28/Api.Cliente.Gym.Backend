using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Aplication.Client.API.Models
{
    public class SuscriptionToExpireData
    {
        public int SuscriptionId { get; set; }
        public int CustomerId { get; set; }
        public DateTime EndDate { get; set; }
        public string FullName { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public string PathImage { get; set; }
        public string MimeType { get; set; }
        public bool? IsPayUp { get; set; }
        public int TotalCount { get; set; }
        public bool HasNextPage { get; set; }
        public bool HasPreviusPage { get; set; }
    }
}
