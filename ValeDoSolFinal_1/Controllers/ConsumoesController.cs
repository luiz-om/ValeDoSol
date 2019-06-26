using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ValeDoSolFinal_1.Context;
using ValeDoSolFinal_1.Models;

namespace ValeDoSolFinal_1.Controllers
{
    public class ConsumoesController : Controller
    {
        private Context2 db = new Context2();

        // GET: Consumoes
        public ActionResult Index()
        {
            var consumo = db.Consumo.Include(c => c.Leitura);
            return View(consumo.ToList());
        }

        // GET: Consumoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Consumo consumo = db.Consumo.Find(id);
            if (consumo == null)
            {
                return HttpNotFound();
            }
            return View(consumo);
        }

        // GET: Consumoes/Create
        public ActionResult Create()        
        {
            ViewBag.Id = new SelectList(db.Leitura, "Id", "Id");
            return View();
        }

        // POST: Consumoes/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Valor,DataPagamento")] Consumo consumo)
        {
            if (ModelState.IsValid)
            {
                db.Consumo.Add(consumo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id = new SelectList(db.Leitura, "Id", "Id", consumo.Id);
            return View(consumo);
        }

        // GET: Consumoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Consumo consumo = db.Consumo.Find(id);
            if (consumo == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id = new SelectList(db.Leitura, "Id", "Id", consumo.Id);
            return View(consumo);
        }

        // POST: Consumoes/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Valor,DataPagamento")] Consumo consumo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(consumo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id = new SelectList(db.Leitura, "Id", "Id", consumo.Id);
            return View(consumo);
        }

        // GET: Consumoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Consumo consumo = db.Consumo.Find(id);
            if (consumo == null)
            {
                return HttpNotFound();
            }
            return View(consumo);
        }

        // POST: Consumoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Consumo consumo = db.Consumo.Find(id);
            db.Consumo.Remove(consumo);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
