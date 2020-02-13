using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Airport.Models;

namespace Airport.Controllers
{
    public class PersonneController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Personne
        public ActionResult Index()
        {
            var personnes = db.Personnes.Include(p => p.RolePersonne);
            return View(personnes.ToList());
        }

        // GET: Personne/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Personne personne = db.Personnes.Find(id);
            if (personne == null)
            {
                return HttpNotFound();
            }
            return View(personne);
        }

        // GET: Personne/Create
        public ActionResult Create()
        {
            ViewBag.RolePersonneId = new SelectList(db.RolePersonnes, "Id", "Role");
            return View();
        }

        // POST: Personne/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nom,Prenom,RolePersonneId")] Personne personne)
        {
            if (ModelState.IsValid)
            {
                personne.Id = Guid.NewGuid();
                db.Personnes.Add(personne);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RolePersonneId = new SelectList(db.RolePersonnes, "Id", "Role", personne.RolePersonneId);
            return View(personne);
        }

        // GET: Personne/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Personne personne = db.Personnes.Find(id);
            if (personne == null)
            {
                return HttpNotFound();
            }
            ViewBag.RolePersonneId = new SelectList(db.RolePersonnes, "Id", "Role", personne.RolePersonneId);
            return View(personne);
        }

        // POST: Personne/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nom,Prenom,RolePersonneId")] Personne personne)
        {
            if (ModelState.IsValid)
            {
                db.Entry(personne).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RolePersonneId = new SelectList(db.RolePersonnes, "Id", "Role", personne.RolePersonneId);
            return View(personne);
        }

        // GET: Personne/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Personne personne = db.Personnes.Find(id);
            if (personne == null)
            {
                return HttpNotFound();
            }
            return View(personne);
        }

        // POST: Personne/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Personne personne = db.Personnes.Find(id);
            db.Personnes.Remove(personne);
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
