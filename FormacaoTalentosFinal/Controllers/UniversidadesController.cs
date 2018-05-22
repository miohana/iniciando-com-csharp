using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FormacaoTalentosFinal.Dao;
using FormacaoTalentosFinal.Models;

namespace FormacaoTalentosFinal.Controllers
{
    public class UniversidadesController : Controller
    {
        private EFContext db = new EFContext();

        // GET: Universidades
        public ActionResult Index()
        {
            return View(db.Universidades.ToList());
        }

        // GET: Universidades/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Universidade universidade = db.Universidades.Find(id);
            if (universidade == null)
            {
                return HttpNotFound();
            }
            return View(universidade);
        }

        // GET: Universidades/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Universidades/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UniversidadeID,Nome,Cidade,UF")] Universidade universidade)
        {
            if (ModelState.IsValid)
            {
                db.Universidades.Add(universidade);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(universidade);
        }

        // GET: Universidades/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Universidade universidade = db.Universidades.Find(id);
            if (universidade == null)
            {
                return HttpNotFound();
            }
            return View(universidade);
        }

        // POST: Universidades/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UniversidadeID,Nome,Cidade,UF")] Universidade universidade)
        {
            if (ModelState.IsValid)
            {
                db.Entry(universidade).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(universidade);
        }

        // GET: Universidades/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Universidade universidade = db.Universidades.Find(id);
            if (universidade == null)
            {
                return HttpNotFound();
            }
            return View(universidade);
        }

        // POST: Universidades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Universidade universidade = db.Universidades.Find(id);
            db.Universidades.Remove(universidade);
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
