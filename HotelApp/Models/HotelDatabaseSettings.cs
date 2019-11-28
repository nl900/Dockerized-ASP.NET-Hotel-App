namespace HotelsApi.Models
{
    public class HotelDatabaseSettings : IHotelDatabaseSettings
    {
        public string HotelsCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IHotelDatabaseSettings
    {
        string HotelsCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}