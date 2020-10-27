using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace GunterBot.MongoDb.Models
{
    public class RateDB
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [Display(Name = "Дата получения")]
        public string TimeStamp { get; set; }
        [Display(Name = "Базовая валюта")]
        public string Base { get; set; }
        [Display(Name = "Курс")]
        public Dictionary<string, double> Rates { get; set; }
    }
}
