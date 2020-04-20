using MongoDB.Bson.Serialization.Attributes;

namespace Mongo.Models
{
    public class Employee
    {
        [BsonElement("email")]
        public string Email { get; set; }
        [BsonElement("firstName")]
        public string FirstName { get; set; }
        [BsonElement("lastName")]
        public string LastName { get; set; }
        [BsonElement("position")]
        public string Position { get; set; }

        public Employee()
        {
            
        }

        public Employee(Employee employee)
        {
            Email = employee.Email;
            FirstName = employee.FirstName;
            LastName = employee.LastName;
            Position = employee.Position;
        }
    }
}