namespace Aplication.Client.API.DTO
{
    public class SuscriptionExpire
    {
        public int TotalCount { get; set; }
        public bool HasNextPage { get; set; }
        public bool HasPreviusPage { get; set; }
        public List<SuscriptionToExpireItem> Items { get; set; }    
    }
}
