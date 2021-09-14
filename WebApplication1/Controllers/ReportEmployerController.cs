using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ReportEmployerController : ApiController
    {
        private EmployerManagmentEntities db = new EmployerManagmentEntities();

        // GET: api/ReportEmployer
        public IQueryable<Employer> GetEmployer()
        {
            return db.Employer;
        }

        // GET: api/ReportEmployer/5
        [ResponseType(typeof(Employer))]
        public IHttpActionResult GetEmployer(int id)
        {
            Employer employer = db.Employer.Find(id);
            if (employer == null)
            {
                return NotFound();
            }

            return Ok(employer);
        }

        // PUT: api/ReportEmployer/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEmployer(int id, Employer employer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != employer.Id)
            {
                return BadRequest();
            }

            db.Entry(employer).State = System.Data.Entity.EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/ReportEmployer
        [ResponseType(typeof(Employer))]
        public IHttpActionResult PostEmployer(Employer employer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Employer.Add(employer);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = employer.Id }, employer);
        }

        // DELETE: api/ReportEmployer/5
        [ResponseType(typeof(Employer))]
        public IHttpActionResult DeleteEmployer(int id)
        {
            Employer employer = db.Employer.Find(id);
            if (employer == null)
            {
                return NotFound();
            }

            db.Employer.Remove(employer);
            db.SaveChanges();

            return Ok(employer);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EmployerExists(int id)
        {
            return db.Employer.Count(e => e.Id == id) > 0;
        }
    }
}