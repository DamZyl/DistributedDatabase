using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Mongo.Models
{
    public class Reservation
    {
        [BsonId]
        [BsonElement("_id")]
        public ObjectId Id { get; set; }
        [BsonElement("startDate")]
        public DateTime StartDate { get; set; }
        [BsonElement("endDate")]
        public DateTime EndDate { get; set; }
        [BsonElement("description")]
        public string Description { get; set; }
        [BsonElement("guest")]
        public Guest Guest { get; set; }
        [BsonElement("employee")]
        public Employee Employee { get; set; }
        [BsonElement("room")]
        public Room Room { get; set; }
        [BsonElement("convenience")]
        public List<Convenience> Conveniences { get; set; }

        public Reservation()
        {
            Conveniences = new List<Convenience>();
        }
    }
}