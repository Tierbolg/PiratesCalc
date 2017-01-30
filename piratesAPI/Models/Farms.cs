using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace piratesAPI.Models
{
    public class Farms
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }

        public double collectInHoursTime { get; set; }
        public String collectName { get; set; }
        public List<Level> levels { get; set; }

        public override string ToString()
        {
            return "collectInHoursTime: " + collectInHoursTime + " " + "collectName: " + collectName;
        }
    }
}