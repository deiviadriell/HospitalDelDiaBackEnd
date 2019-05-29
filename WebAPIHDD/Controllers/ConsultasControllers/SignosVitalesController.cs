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
    public class SignosVitalesController : ApiController
    {
        private SMHospitalDelDiaEntities db = new SMHospitalDelDiaEntities();

        // GET: api/SignosVitales
        public IQueryable<SignosVitales> GetSignosVitales()
        {
            return db.SignosVitales;
        }

        // GET: api/SignosVitales/5
        [ResponseType(typeof(SignosVitales))]
        public IHttpActionResult GetSignosVitales(int id)
        {
            SignosVitales signosVitales = db.SignosVitales.Find(id);
            if (signosVitales == null)
            {
                return NotFound();
            }

            return Ok(signosVitales);
        }

        // PUT: api/SignosVitales/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSignosVitales(int id, SignosVitales signosVitales)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != signosVitales.idSignosVitales)
            {
                return BadRequest();
            }

            db.Entry(signosVitales).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SignosVitalesExists(id))
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

        // POST: api/SignosVitales
        [ResponseType(typeof(SignosVitales))]
        public IHttpActionResult PostSignosVitales(SignosVitales signosVitales)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SignosVitales.Add(signosVitales);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = signosVitales.idSignosVitales }, signosVitales);
        }

        // DELETE: api/SignosVitales/5
        [ResponseType(typeof(SignosVitales))]
        public IHttpActionResult DeleteSignosVitales(int id)
        {
            SignosVitales signosVitales = db.SignosVitales.Find(id);
            if (signosVitales == null)
            {
                return NotFound();
            }

            db.SignosVitales.Remove(signosVitales);
            db.SaveChanges();

            return Ok(signosVitales);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SignosVitalesExists(int id)
        {
            return db.SignosVitales.Count(e => e.idSignosVitales == id) > 0;
        }
    }
}