namespace Api.Models.Entities
{
    public class Account
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }

        public string? PhoneNumber { get; set; }
        public DateTime CreatedAt { get; set; }


    }
}
