using MongoDB.Bson.Serialization.Attributes;

namespace Mongo.Models
{
    public class Guest
    {
        [BsonElement("personalId")]
        public string PersonalId { get; set; }
        [BsonElement("firstName")]
        public string FirstName { get; set; }
        [BsonElement("lastName")]
        public string LastName { get; set; }
        [BsonElement("phoneNumber")]
        public string PhoneNumber { get; set; }

        public Guest()
        {
            
        }
        
        public Guest(Guest guest)
        {
            PersonalId = guest.PersonalId;
            FirstName = guest.FirstName;
            LastName = guest.LastName;
            PhoneNumber = guest.PhoneNumber;
        }
    }
}