using System;

namespace HelpMyStreet.Utils.Models
{
    public class UserCredential
    {
        public int CredentialId { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public int AuthorisedByUserId { get; set; }
        public string Reference { get; set; }
        public string Notes { get; set; }
    }
}