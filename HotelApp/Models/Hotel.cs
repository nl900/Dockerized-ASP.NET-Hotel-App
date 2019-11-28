using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace HotelsApi.Models
{
    public class Hotel
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Name")]
        public string HotelName { get; set; }

        public int StarRating { get; set; }

        public string Address { get; set; }

        public string Description { get; set; }

    }
}