using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace trpTopicos.Models
{
    [BsonIgnoreExtraElements]
    public class Produto
    {
        public ObjectId Id { get; set; }
        public string id { get; set; }
        public string desc { get; set; }

    }
}
