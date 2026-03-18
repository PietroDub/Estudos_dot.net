using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WebApiMongoDbDemo.Entities
{
    public class Customer
    {
        [BsonId]
        [BsonElement("_id"), BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        [BsonElement("_nome"), BsonRepresentation(BsonType.String)]
        public string? CustomerName { get; set; }
        [BsonElement("_email"), BsonRepresentation(BsonType.String)]
        public string? Email { get; set; }
    }
}
