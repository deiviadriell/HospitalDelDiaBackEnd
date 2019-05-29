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

namespace WebAPIHDD.Controllers.LocalidadControllers
{
    public class PaisController : ApiController
    {
        private SMHospitalDelDiaEntities db = new SMHospitalDelDiaEntities();

        // GET: api/Pais
        public IQueryable<Pais> GetPais()
        {
            return db.Pais;
        }

        // GET: api/Pais/5
        [ResponseType(typeof(Pais))]
        public IHttpActionResult GetPais(int id)
        {
            Pais pais = db.Pais.Find(id);
            if (pais == null)
            {
                return NotFound();
            }

            return Ok(pais);
        }

        // PUT: api/Pais/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPais(int id, Pais pais)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pais.idPais)
            {
                return BadRequest();
            }

            db.Entry(pais).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaisExists(id))
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

        // POST: api/Pais
        [ResponseType(typeof(Pais))]
        public IHttpActionResult PostPais(Pais pais)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Pais.Add(pais);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = pais.idPais }, pais);
        }

        // DELETE: api/Pais/5
        [ResponseType(typeof(Pais))]
        public IHttpActionResult DeletePais(int id)
        {
            Pais pais = db.Pais.Find(id);
            if (pais == null)
            {
                return NotFound();
            }

            db.Pais.Remove(pais);
            db.SaveChanges();

            return Ok(pais);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PaisExists(int id)
        {
            return db.Pais.Count(e => e.idPais == id) > 0;
        }
    }
}