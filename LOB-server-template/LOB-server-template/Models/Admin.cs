using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LOB_server_template.Models
{
    public class Admin
    {
        [BsonId]    //in this way we can name our key (_id) something else
        public string AdminReferenceNumber { get; set; }

        //[BsonRepresentation(BsonType.ObjectId)]     //reference to UserAccount
        [Required]
        public UserAccount UserAccount { get; set; }

        //maybe put position
    }
}
