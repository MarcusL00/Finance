﻿namespace Api.Models
{
    public class AccountDto
    {
        public required string Name { get; set; }
        public required string Email { get; set; }

        public string? PhoneNumber { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}
