using MongoDB.Bson;
using MongoDB.Driver;
using piratesAPI.Models;
using piratesAPI.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace piratesAPI.Controllers
{
    public class PiratesController : ApiController
    {
        public PiratesController()
        {
            //Get the mongo Client
            var mongoClient = new MongoClient(Settings.Default.DBconnection);
            MongoDatabase = mongoClient.GetDatabase(Settings.Default.DBname);
        }

        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            var farmsColelction = MongoDatabase.GetCollection<BsonDocument>("Farms");
            var filter = Builders<BsonDocument>.Filter.Eq("collectName", "gold");
            var result = farmsColelction.Find(filter).ToList();

            var farm = new Farms();
            farm.collectName = result[0].GetElement("collectName").Value.ToString();
            farm.collectInHoursTime = result[0].GetElement("collectInHoursTime").Value.ToDouble();

            return farm.ToString();
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }

        public IMongoDatabase MongoDatabase { get; set; }
    }
}