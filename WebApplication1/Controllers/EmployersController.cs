using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class EmployersController : Controller
    {
        private EmployerManagmentEntities db = new EmployerManagmentEntities();

        // GET: Employers
        public ActionResult Index()
        {
            var employer = db.Employer.Include(e => e.DocumentType1);
            return View(employer.ToList());
        }
        // GET: Employers
        public ActionResult UserManagment()
        {
            var employer = db.Employer.Include(e => e.DocumentType1);
            return View(employer.ToList());
        }

        // GET: Employers
        public ActionResult Report()
        {
            var employer = db.Employer.Include(e => e.DocumentType1);
            return View(employer.ToList());
        }


        // GET: Employers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employer employer = db.Employer.Find(id);
            if (employer == null)
            {
                return HttpNotFound();
            }
            return View(employer);
        }

        // GET: Employers/Create
        public ActionResult Create()
        {            
            ViewBag.DocumentType = new SelectList(db.DocumentType, "Id", "DocumentType1");
            ViewBag.Gender = ListGender();
            return View();
        }

        // POST: Employers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,LastName,Document,DocumentType,Email,Gender,Age,Image,Active")] Employer employer)
        {
            if (ModelState.IsValid)
            {
                db.Employer.Add(employer);
                db.SaveChanges();
                return RedirectToAction("UserManagment");
            }

            ViewBag.DocumentType = new SelectList(db.DocumentType, "Id", "DocumentType1", employer.DocumentType);           
            ViewBag.Gender = ListGender();
            return View(employer);
        }

        // GET: Employers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employer employer = db.Employer.Find(id);
            if (employer == null)
            {
                return HttpNotFound();
            }          
            ViewBag.Gender = ListGender();
            ViewBag.DocumentType = new SelectList(db.DocumentType, "Id", "DocumentType1", employer.DocumentType);
            return View(employer);
        }

        // POST: Employers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,LastName,Document,DocumentType,Email,Gender,Age,Image,Active")] Employer employer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employer).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("UserManagment");
            }
            ViewBag.DocumentType = new SelectList(db.DocumentType, "Id", "DocumentType1", employer.DocumentType);
            return View(employer);
        }

        // GET: Employers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employer employer = db.Employer.Find(id);
            if (employer == null)
            {
                return HttpNotFound();
            }
            return View(employer);
        }

        // POST: Employers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employer employer = db.Employer.Find(id);
            db.Employer.Remove(employer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public List<SelectListItem> ListGender()
        {
            List<SelectListItem> listItems = new List<SelectListItem>();
            listItems.Add(new SelectListItem
            {
                Text = "Masculino",
                Value = "Masculino",
                Selected = true
            });
            listItems.Add(new SelectListItem
            {
                Text = "Femenino",
                Value = "Femenino"
            });
            return listItems;
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
