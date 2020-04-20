using MongoDB.Bson.Serialization.Attributes;

namespace Mongo.Models
{
    [BsonIgnoreExtraElements]
    public class Convenience
    {
        [BsonElement("id")]
        public int Id { get; set; }
        [BsonElement("name")]
        public string Name { get; set; }
        [BsonElement("price")]
        public int Price { get; set; }

        public Convenience()
        {
            
        }
        
        public Convenience(Convenience convenience)
        {
            Id = convenience.Id;
            Name = convenience.Name;
            Price = convenience.Price;
        }
    }
}