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
    public class LeiturasController : Controller
    {
        private Context2 db = new Context2();
        private Context2 db2 = new Context2();


        // GET: Leituras
        public ActionResult Index()
        {
            var leitura = db.Leitura.Include(l => l.Lote);
            return View(leitura.ToList());
        }

        // GET: Leituras/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Leitura leitura = db.Leitura.Find(id);

            
            if (leitura == null)
            {
                return HttpNotFound();
            }
           
            return View(leitura);
        }

        // GET: Leituras/Create
        public ActionResult Create()
        {
            ViewBag.LoteId = new SelectList(db.Lote, "Id", "Id");
            ViewBag.ConsumoAntigo = new SelectList(db.Leitura, "id", "NumeroLeitura");

            return View();
        }

        // POST: Leituras/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,LoteId,DataLeitura,NumeroLeitura")] Leitura leitura)
        {
            //[Bind(Include = "Id,LoteId,DataLeitura,NumeroLeitura")] 
            if (ModelState.IsValid)
            {
                //aki tudo que ja tentei
                /*
                 *  var leitura2 = from l in db.Leitura select l;
                 leitura2 = leitura2.OrderByDescending(l => l.Id);
                 db.Leitura.Where(l => l.LoteId == leitura.LoteId).OrderByDescending(l=> l.NumeroLeitura);
                 // db.Leitura.leitura2.NumeroLeitura = db.Leitura.Where(l => l.LoteId == leitura.LoteId).FirstAsync;
                //  db2.Leitura.Find(leitura2.LoteId).;
                var sql =  db.Leitura.SqlQuery("select ID from Leitura Order by ID DESC;");
                 */
                //int n = Convert.ToInt32(ViewBag.ConsumoAntigo = new SelectList(db.Leitura.OrderByDescending(l => l.LoteId)));


                var consumo = new Consumo();
                consumo.Leitura = leitura;

                // Query for the Blog named ADO.NET Blog
                var ConsumoAntigo = db2.Leitura 
                                .Where(b => b.NumeroLeitura == leitura.LoteId)
                                .FirstOrDefault();

                if (ConsumoAntigo == null)
                {
                    consumo.Valor = (leitura.NumeroLeitura) * 0.71;
                }
                //Essa parte que faz a conta apra salvar o consumo
                consumo.Valor =(leitura.NumeroLeitura - ConsumoAntigo.NumeroLeitura ) * 0.71;
                db.Leitura.Add(leitura);
                db.Consumo.Add(consumo);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
          
            ViewBag.LoteId = new SelectList(db.Lote, "Id", "CPF", leitura.LoteId);
            return View(leitura);
        }

        // GET: Leituras/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Leitura leitura = db.Leitura.Find(id);
            if (leitura == null)
            {
                return HttpNotFound();
            }
            ViewBag.LoteId = new SelectList(db.Lote, "Id", "CPF", leitura.LoteId);
            return View(leitura);
        }

        // POST: Leituras/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,LoteId,DataLeitura,NumeroLeitura")] Leitura leitura)
        {
            if (ModelState.IsValid)
            {
                db.Entry(leitura).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LoteId = new SelectList(db.Lote, "Id", "CPF", leitura.LoteId);
            return View(leitura);
        }

        // GET: Leituras/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Leitura leitura = db.Leitura.Find(id);
            if (leitura == null)
            {
                return HttpNotFound();
            }
            return View(leitura);
        }

        // POST: Leituras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
           
            Leitura leitura = db.Leitura.Find(id);
            db.Leitura.Remove(leitura);
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
