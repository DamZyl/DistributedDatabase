using System;
using System.Diagnostics;
using Mongo.Models;
using MongoDB.Driver;
using System.Linq;

namespace Mongo
{
    class Program
    {
        static void Main(string[] args)
        {
            var settings = new MongoClientSettings
            {
                Servers = new[]
               {
                    new MongoServerAddress("mongo-node1", 27017),
                    new MongoServerAddress("mongo-node2", 27017),
                    new MongoServerAddress("mongo-node3", 27017)
                },
                ConnectionMode = ConnectionMode.ReplicaSet,
                ReplicaSetName = "rs0"
            };

            var client = new MongoClient(settings);
            var database = client.GetDatabase("guesthouse");
            var collection = database.GetCollection<Reservation>("reservations")
                .AsQueryable(new AggregateOptions
                    {
                        AllowDiskUse = true
                    }
                );

            var timerFirstQuery = Stopwatch.StartNew();
            
            var firstQuery = collection.GroupBy(x => new
                   {
                           x.Guest.FirstName, 
                           x.Guest.LastName
                   }
               )
               .Select(x => new
                   {
                           Guest = x.Key.FirstName + x.Key.LastName,
                           Reservations = x.Count()
                   }
               )
               .ToList();
            
            timerFirstQuery.Stop();

           foreach (var item in firstQuery)
           {
               Console.WriteLine("Guest: " + item.Guest + " Reservations: " + item.Reservations);
           }
           
           Console.WriteLine("Time: " + timerFirstQuery.ElapsedMilliseconds);

           var tmp = collection.ToList();
           var timerSecondQuery = Stopwatch.StartNew();

           var secondQuery = tmp.GroupBy(x => new 
                   {
                       x.Guest.PersonalId,
                       x.StartDate
                   }
               )
               .Select(x => new
                   {
                        Key = x.Key,
                        Guest = x.First().Guest.FirstName + x.First().Guest.LastName,
                        Employee = x.First().Employee.FirstName + x.First().Employee.LastName,
                        Position = x.First().Employee.Position,
                        StartDate = x.First().StartDate,
                        EndDate = x.First().EndDate,
                        Room = x.First().Room.Type,
                        Convenience = x.First().Conveniences.Count(),
                        Total = x.First().Conveniences
                            .Sum(c => c.Price) + 
                                (x.First().Room.Price * (x.First().EndDate.DayOfYear - x.First().StartDate.DayOfYear))
                   }
               )
               .ToList();
          
           timerSecondQuery.Stop();
           
           foreach (var item in secondQuery)
           {
               Console.WriteLine($"Guest: {item.Guest} Employee: {item.Employee} Position: {item.Position} StartDate: {item.StartDate:yyyy-MM-dd} EndDate: {item.EndDate:yyyy-MM-dd} Conveniences: {item.Convenience}");
           }
           
           Console.WriteLine($"Time: {timerSecondQuery.ElapsedMilliseconds}");

           var timerThirdQuery = Stopwatch.StartNew();
           
           var thirdQuery = collection.GroupBy(x => x.Room.Number)
               .Select(x => new
                   {
                       Number = x.Key,
                       Reservations = x.Count()
                   }
               )
               .ToList();
           
           timerThirdQuery.Stop();
           
           foreach (var item in thirdQuery)
           {
               Console.WriteLine($"Room: {item.Number} Reservations: {item.Reservations}");
           }
           
           Console.WriteLine($"Time: {timerThirdQuery.ElapsedMilliseconds}");
        }
    }
}

