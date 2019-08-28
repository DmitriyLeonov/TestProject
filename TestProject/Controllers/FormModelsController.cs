using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TestProject.Models;

namespace TestProject.Controllers
{
    public class FormModelsController : Controller
    {
        private readonly ApplicationDbContext db = new ApplicationDbContext();

        // GET: FormModels
        public ActionResult Index()
        {
            return View(db.FormModels.ToList());
        }

        // GET: FormModels/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FormModel formModel = db.FormModels.Find(id);
            if (formModel == null)
            {
                return HttpNotFound();
            }
            return View(formModel);
        }

        // GET: FormModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FormModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Email,Name,Time,Comment")] FormModel formModel)
        {
            if (ModelState.IsValid)
            {
                db.FormModels.Add(formModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(formModel);
        }

        // GET: FormModels/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FormModel formModel = db.FormModels.Find(id);
            if (formModel == null)
            {
                return HttpNotFound();
            }
            return View(formModel);
        }

        // POST: FormModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Email,Name,Time,Comment")] FormModel formModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(formModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(formModel);
        }

        // GET: FormModels/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FormModel formModel = db.FormModels.Find(id);
            if (formModel == null)
            {
                return HttpNotFound();
            }
            return View(formModel);
        }

        // POST: FormModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            FormModel formModel = db.FormModels.Find(id);
            db.FormModels.Remove(formModel);
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
