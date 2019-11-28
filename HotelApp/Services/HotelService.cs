using HotelsApi.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;


namespace HotelsApi.Services
{
    public class HotelService
    {
        private readonly IMongoCollection<Hotel> _hotels;

        public HotelService(IHotelDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _hotels = database.GetCollection<Hotel>(settings.HotelsCollectionName);
        }

        public List<Hotel> Get() =>
            _hotels.Find(listing => true).ToList();

        public Hotel Get(string id) =>
            _hotels.Find<Hotel>(listing => listing.Id == id).FirstOrDefault();

        public Hotel Create(Hotel hotel)
        {
            _hotels.InsertOne(hotel);
            return hotel;
        }

        public void Update(string id, Hotel hotelIn) =>
            _hotels.ReplaceOne(hotel => hotel.Id == id, hotelIn);

        public void Remove(Hotel hotelIn) =>
            _hotels.DeleteOne(hotel => hotel.Id == hotelIn.Id);

        public void Remove(string id) =>
            _hotels.DeleteOne(hotel => hotel.Id == id);
    }
}