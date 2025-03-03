using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.Domain.Entities
{
    public class Course
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string? Id { get; set; } 
        public string Name { get; set; }
        public string Description { get; set; }

        [BsonRepresentation(MongoDB.Bson.BsonType.Decimal128)]
        public decimal Price { get; set; }
        public string UserId { get; set; }
        public string Picture { get; set; }
        public DateTime CreatedDate { get; set; }

        public Feature Feature { get; set; }
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string CategoryId { get; set; }
        [BsonIgnore]
        public Category Category { get; set; }
    }
}
