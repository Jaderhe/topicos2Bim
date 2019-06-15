using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace trpTopicos.Models
{
    public class MongoContext { 
        private IMongoDatabase _database { get; }
        public MongoContext()
        {
            MongoClientSettings settings = MongoClientSettings.FromUrl(new MongoUrl("mongodb://localhost:27017"));
            var mongoClient = new MongoClient(settings);
            _database = mongoClient.GetDatabase("trbTopicos");
        }

        public IMongoCollection<Pessoa> Pessoas
        {
            get
            {
                return _database.GetCollection<Pessoa>("pessoa");
            }

        }

        public IMongoCollection<Produto> Produtos
        {
            get
            {   
                return _database.GetCollection<Produto>("produto");
            }

        }
    }
}
