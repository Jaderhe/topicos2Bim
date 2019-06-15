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
    public class ProdutoController : Controller
    {
        private readonly MongoContext _mongoDBContext = new MongoContext();
        public IActionResult Index()
        {
            return View(_mongoDBContext.Produtos.Find(s => true).ToList());
        }

        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(Produto produto)
        {
            if (ModelState.IsValid)
            {
                _mongoDBContext.Produtos.InsertOne(produto);
                return RedirectToAction("Index");
            }

            return View();
        }


        [HttpGet]
        public IActionResult Delete(string Id)
        {
            var produtoDel = _mongoDBContext.Produtos
                .Find(s => s.Id == ObjectId.Parse(Id)).FirstOrDefault();
            return View(produtoDel);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(string Id)
        {
            var produtoDel = _mongoDBContext.Produtos
                .DeleteOne(s => s.Id == ObjectId.Parse(Id));
            return RedirectToAction("Index");
        }


        public ActionResult Edit(string Id)
        {
            var prod = _mongoDBContext.Produtos.Find(s => s.Id == ObjectId.Parse(Id)).FirstOrDefault();
            return View(prod);
        }

        [HttpPost]
        public ActionResult Edit(Produto produto, string id)
        {
            if (ModelState.IsValid)
            {
                produto.Id = ObjectId.Parse(id);
                var filter = new BsonDocument("_id", ObjectId.Parse(id));
                //var filter = Builders<Servidor>.Filter.Eq(s => s.Id, servidor.Id);
                _mongoDBContext.Produtos.ReplaceOne(filter, produto);

                return RedirectToAction("Index");
            }
            return View();
        }

    }


}