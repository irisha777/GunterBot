namespace GunterBot.MongoDb.Models
{
    public interface IRateDBSettings
    {
        string CollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
