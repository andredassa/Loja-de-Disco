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
    public class AutorController : Controller
    {
        private LojaDeDiscoContext db = new LojaDeDiscoContext();

        // GET: /Autor/
        public ActionResult Index()
        {
            var autores = db.Autores
				.Include(a => a.Filhos).Include(a => a.AutorPai)
				.Where(a => a.AutorPaiId == null);
			return View(autores.ToList());
        }

		public ActionResult GetFilho(int id = 0)
		{
			var autores = db.Autores
				.Include(a => a.Filhos).Include(a => a.AutorPai)
				.Where(a => a.AutorPaiId == id || (a.AutorPaiId == null && id == 0));
			return View(autores.ToList());
		}
        // GET: /Autor/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Autor autor = db.Autores.Include(a => a.AutorPai).FirstOrDefault(a => a.Id == id);
            if (autor == null)
            {
                return HttpNotFound();
            }
            return View(autor);
        }

        // GET: /Autor/Create
        public ActionResult Create()
        {
            ViewBag.AutorPaiId = new SelectList(db.Autores, "Id", "NomeAutor");
            return View();
        }

        // POST: /Autor/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,NomeAutor,AutorPaiId")] Autor autor)
        {
            if (ModelState.IsValid)
            {
                db.Autores.Add(autor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AutorPaiId = new SelectList(db.Autores, "Id", "NomeAutor", autor.AutorPaiId);
            return View(autor);
        }

        // GET: /Autor/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Autor autor = db.Autores.Find(id);
            if (autor == null)
            {
                return HttpNotFound();
            }
            ViewBag.AutorPaiId = new SelectList(db.Autores, "Id", "NomeAutor", autor.AutorPaiId);
            return View(autor);
        }

        // POST: /Autor/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,NomeAutor,AutorPaiId")] Autor autor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(autor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AutorPaiId = new SelectList(db.Autores, "Id", "NomeAutor", autor.AutorPaiId);
            return View(autor);
        }

        // GET: /Autor/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Autor autor = db.Autores.Find(id);
            if (autor == null)
            {
                return HttpNotFound();
            }
            return View(autor);
        }

        // POST: /Autor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Autor autor = db.Autores.Find(id);
            db.Autores.Remove(autor);
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
