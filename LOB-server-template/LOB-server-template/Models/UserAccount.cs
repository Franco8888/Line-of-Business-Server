using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LOB_server_template.Models
{
    public enum LoginAccountType
    {
        Unverified = 0,
        SalesPerson,
        Admin,
    }

    public class UserAccount
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Name { get; set; }    

        [Required]
        public string Surname { get; set; }   

        [Required]
        public LoginAccountType AccountType { get; set; }
    }
}
