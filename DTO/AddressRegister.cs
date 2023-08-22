namespace Aplication.Client.API.DTO
{
    public class AddressRegister
    {
        public string Nationality { get; set; }
        public string? Municipaly { get; set; }
        public string? Locality { get; set; }
        public string ZipCode { get; set; }
        public string Street { get; set; }
        public string Neighborhood { get; set; }
        public string InteriorNumber { get; set; }
        public string OutdoorNumber { get; set; }
    }
}
