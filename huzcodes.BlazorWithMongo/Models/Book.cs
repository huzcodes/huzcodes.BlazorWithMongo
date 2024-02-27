using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using Newtonsoft.Json;

namespace huzcodes.BlazorWithMongo.Models
{
    public class Book
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [JsonProperty("id")]
        public string? Id { get; set; }

        [JsonProperty("bookName")]
        public string BookName { get; set; } = null!;
        [JsonProperty("price")]
        public decimal Price { get; set; }
        [JsonProperty("categort")]
        public string Category { get; set; } = null!;
        [JsonProperty("author")]
        public string Author { get; set; } = null!;
    }
}
