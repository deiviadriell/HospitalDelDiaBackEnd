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
using WebAPIHDD;

namespace WebAPIHDD.Controllers.ConsultasControllers
{
    public class PediatriasController : ApiController
    {
        private SMHospitalDelDiaEntities db = new SMHospitalDelDiaEntities();

        // GET: api/Pediatrias
        public IQueryable<Pediatria> GetPediatria()
        {
            return db.Pediatria;
        }

        // GET: api/Pediatrias/5
        [ResponseType(typeof(Pediatria))]
        public IHttpActionResult GetPediatria(int id)
        {
            Pediatria pediatria = db.Pediatria.Find(id);
            if (pediatria == null)
            {
                return NotFound();
            }

            return Ok(pediatria);
        }

        // PUT: api/Pediatrias/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPediatria(int id, Pediatria pediatria)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pediatria.idPediatria)
            {
                return BadRequest();
            }

            db.Entry(pediatria).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PediatriaExists(id))
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

        // POST: api/Pediatrias
        [ResponseType(typeof(Pediatria))]
        public IHttpActionResult PostPediatria(Pediatria pediatria)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Pediatria.Add(pediatria);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = pediatria.idPediatria }, pediatria);
        }

        // DELETE: api/Pediatrias/5
        [ResponseType(typeof(Pediatria))]
        public IHttpActionResult DeletePediatria(int id)
        {
            Pediatria pediatria = db.Pediatria.Find(id);
            if (pediatria == null)
            {
                return NotFound();
            }

            db.Pediatria.Remove(pediatria);
            db.SaveChanges();

            return Ok(pediatria);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PediatriaExists(int id)
        {
            return db.Pediatria.Count(e => e.idPediatria == id) > 0;
        }
    }
}