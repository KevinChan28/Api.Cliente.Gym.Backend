namespace Aplication.Client.API.DTO
{
    public class CustomerUpdate
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string? Phone { get; set; }
        public DateTime Birthdate { get; set; }
    }
}
