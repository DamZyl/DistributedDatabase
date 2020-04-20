using MongoDB.Bson.Serialization.Attributes;

namespace Mongo.Models
{
    public class Room
    {
        [BsonElement("number")]
        public int Number { get; set; }
        [BsonElement("floor")]
        public int Floor { get; set; }
        [BsonElement("type")]
        public string Type { get; set; }
        [BsonElement("price")]
        public int Price { get; set; }

        public Room()
        {

        }

        public Room(Room room)
        {
            Number = room.Number;
            Floor = room.Floor;
            Type = room.Type;
            Price = room.Price;
        }
    }
}