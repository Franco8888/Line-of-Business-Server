﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LOB_server_template.Models
{
    public class SalesPerson
    {
        [BsonId]    //in this way we can name our key (_id) something else
        public string SalesPersonReference { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        [Required]
        public UserAccount UserAccount { get; set; }

        public long SalesLevel { get; set; }

    }
}
