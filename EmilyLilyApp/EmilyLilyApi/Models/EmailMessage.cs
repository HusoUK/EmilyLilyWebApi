﻿namespace EmilyLilyApi.Models
{
    public class EmailMessage : IMessage
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
    }
}
