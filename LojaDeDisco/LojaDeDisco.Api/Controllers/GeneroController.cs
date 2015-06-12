using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LojaDeDisco.Api.Models;

namespace LojaDeDisco.Api.Controllers
{
    public class GeneroController : Controller
    {
        private LojaDeDiscoContext db = new LojaDeDiscoContext();

        // GET: /Genero/
        public ActionResult Index()
        {
			var generos = db.Generos
				.Include(g => g.Filhos).Include(g => g.GeneroPai)
				.Where(g => g.GeneroPaiId == null);
            return View(generos.ToList());
        }

		public ActionResult GetFilho(int id = 0)
		{
			var generos = db.Generos
				.Include(g => g.Filhos).Include(g => g.GeneroPai)
				.Where(g => g.GeneroPaiId == id || (g.GeneroPaiId == null && id == 0));
			return View(generos.OrderBy(x => x.Nome).ToList());
		}
        // GET: /Genero/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Genero genero = db.Generos.Include(g => g.GeneroPai).FirstOrDefault(g => g.Id == id);
            if (genero == null)
            {
                return HttpNotFound();
            }
            return View(genero);
        }

        // GET: /Genero/Create
        public ActionResult Create()
        {
            ViewBag.GeneroPaiId = new SelectList(db.Generos, "Id", "Nome");
            return View();
        }

        // POST: /Genero/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Nome,GeneroPaiId")] Genero genero)
        {
            if (ModelState.IsValid)
            {
                db.Generos.Add(genero);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GeneroPaiId = new SelectList(db.Generos, "Id", "Nome", genero.GeneroPaiId);
            return View(genero);
        }

        // GET: /Genero/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Genero genero = db.Generos.Find(id);
            if (genero == null)
            {
                return HttpNotFound();
            }
            ViewBag.GeneroPaiId = new SelectList(db.Generos, "Id", "Nome", genero.GeneroPaiId);
            return View(genero);
        }

        // POST: /Genero/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Nome,GeneroPaiId")] Genero genero)
        {
            if (ModelState.IsValid)
            {
                db.Entry(genero).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GeneroPaiId = new SelectList(db.Generos, "Id", "Nome", genero.GeneroPaiId);
            return View(genero);
        }

        // GET: /Genero/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Genero genero = db.Generos.Find(id);
            if (genero == null)
            {
                return HttpNotFound();
            }
            return View(genero);
        }

        // POST: /Genero/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Genero genero = db.Generos.Find(id);
            db.Generos.Remove(genero);
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
