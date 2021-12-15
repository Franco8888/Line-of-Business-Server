using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LOB_server_template.Models
{
    public enum AccountType
    {
        Unverified = 0,
        User, 
        SalesPerson,
        Admin,
    }

    public class UserAccount
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string? UserName { get; set; } = null;

        [Required]
        public string? Password { get; set; }

        public string? AdminPassword { get; set; } = null;

        [Required]
        public string? Email { get; set; }

        [Required]
        public bool IsEmailVerified { get; set; } = false;

        [Required]
        public string? Name { get; set; }    

        [Required]
        public string? Surname { get; set; }   

        [Required]
        public AccountType AccountType { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
