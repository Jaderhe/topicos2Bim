using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace trpTopicos.Models
{
    [BsonIgnoreExtraElements]
    public class Pessoa
    {
        public ObjectId Id { get; set; }
        public string id { get; set; }
        public string nome { get; set; }
        public string idade { get; set; }

    }
}
