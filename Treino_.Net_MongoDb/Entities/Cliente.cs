using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Treino_.Net_MongoDb.Entities
{
    public class Cliente
    {
        [BsonId]
        [BsonElement("_id"), BsonRepresentation(BsonType.ObjectId)]
        public string? Cliente_id { get; set; }

        [BsonElement("_nome"), BsonRepresentation(BsonType.String)]
        public string? Name { get; set; }

        [BsonElement("_email"), BsonRepresentation(BsonType.String)]
        public string? Email { get; set; }
    }
}
