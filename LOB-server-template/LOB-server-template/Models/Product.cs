using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace LOB_server_template.Models
{
    public class Product
    {
        [BsonId]
        public string ProductId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Cultivar { get; set; }

        [Required]
        public double SellPrice { get; set; }

        [Required]
        public double CostPrice { get; set; }

        public string ProductImage { get; set; }

    }
}
