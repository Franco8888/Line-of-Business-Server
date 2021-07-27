using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LOB_server_template.Models
{
    // Customer is only assigned when they have made a purchase
    public class Customer
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        public string TelephoneNumber { get; set; }

        public BillingAddress BillingAddress { get; set; } = new BillingAddress();

    }

    public sealed class BillingAddress
    {
        public string Street { get; set; }

        public string City { get; set; }

        public string PostalCode { get; set; }

        public string State { get; set; }

        public string Country { get; set; }
    }
}
