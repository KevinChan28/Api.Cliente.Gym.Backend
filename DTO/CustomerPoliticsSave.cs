namespace Aplication.Client.API.DTO
{
    public class CustomerPoliticsSave
    {
        public int CustomerId { get; set; }
        public int TutorId { get; set; }
        public int PoliticsId { get; set; }
        public bool IsAccepted { get; set; }
    }
}
