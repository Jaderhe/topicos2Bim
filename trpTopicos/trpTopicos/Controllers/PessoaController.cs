using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using trpTopicos.Models;

namespace trpTopicos.Controllers
{
    public class PessoaController : Controller
    {
        private readonly MongoContext _mongoDBContext = new MongoContext();
        public IActionResult Index()
        {
            return View(_mongoDBContext.Pessoas.Find(s => true).ToList());
        }

        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(Pessoa pessoa)
        {
            if (ModelState.IsValid)
            {
                _mongoDBContext.Pessoas.InsertOne(pessoa);
                return RedirectToAction("Index");
            }

            return View();
        }


        [HttpGet]
        public IActionResult Delete(string Id)
        {
            var pessoaDel = _mongoDBContext.Pessoas
                .Find(s => s.Id == ObjectId.Parse(Id)).FirstOrDefault();
            return View(pessoaDel);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(string Id)
        {
            var pessoaDel = _mongoDBContext.Pessoas
                .DeleteOne(s => s.Id == ObjectId.Parse(Id));
            return RedirectToAction("Index");
        }


        public ActionResult Edit(string Id)
        {
            var pess = _mongoDBContext.Pessoas.Find(s => s.Id == ObjectId.Parse(Id)).FirstOrDefault();
            return View(pess);
        }

        [HttpPost]
        public ActionResult Edit(Pessoa pessoa, string id)
        {
            if (ModelState.IsValid)
            {
                pessoa.Id = ObjectId.Parse(id);
                var filter = new BsonDocument("_id", ObjectId.Parse(id));
                //var filter = Builders<Servidor>.Filter.Eq(s => s.Id, servidor.Id);
                _mongoDBContext.Pessoas.ReplaceOne(filter, pessoa);

                return RedirectToAction("Index");
            }
            return View();
        }

    }
}