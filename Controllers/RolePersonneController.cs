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
    public class RolePersonneController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: RolePersonne
        public ActionResult Index()
        {
            return View(db.RolePersonnes.ToList());
        }

        // GET: RolePersonne/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RolePersonne rolePersonne = db.RolePersonnes.Find(id);
            if (rolePersonne == null)
            {
                return HttpNotFound();
            }
            return View(rolePersonne);
        }

        // GET: RolePersonne/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RolePersonne/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Role")] RolePersonne rolePersonne)
        {
            if (ModelState.IsValid)
            {
                rolePersonne.Id = Guid.NewGuid();
                db.RolePersonnes.Add(rolePersonne);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(rolePersonne);
        }

        // GET: RolePersonne/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RolePersonne rolePersonne = db.RolePersonnes.Find(id);
            if (rolePersonne == null)
            {
                return HttpNotFound();
            }
            return View(rolePersonne);
        }

        // POST: RolePersonne/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Role")] RolePersonne rolePersonne)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rolePersonne).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rolePersonne);
        }

        // GET: RolePersonne/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RolePersonne rolePersonne = db.RolePersonnes.Find(id);
            if (rolePersonne == null)
            {
                return HttpNotFound();
            }
            return View(rolePersonne);
        }

        // POST: RolePersonne/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            RolePersonne rolePersonne = db.RolePersonnes.Find(id);
            db.RolePersonnes.Remove(rolePersonne);
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
