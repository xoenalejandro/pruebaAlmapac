namespace ApiUsers.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public DateTime LastLogin { get; set; }
        public string Token { get; set; }
        public bool IsActive { get; set; }
        public ICollection<phones> phones { get; set; }
    }

    public class phones
    {
        public Guid Id { get; set; }
        public string Number { get; set; }
        public string CityCode { get; set; }
        public string ContryCode { get; set; }
        public Guid UserId { get; set; }
    }
}
