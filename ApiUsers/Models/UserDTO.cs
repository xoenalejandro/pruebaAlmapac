namespace ApiUsers.Models
{
    public class UserDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public ICollection<phonesDTO> phones { get; set; }
    }
    public class phonesDTO
    {
        public string Number { get; set; }
        public string CityCode { get; set; }
        public string ContryCode { get; set; }
    }
}
