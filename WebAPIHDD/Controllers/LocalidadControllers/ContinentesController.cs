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
    public class ContinentesController : ApiController
    {
        private SMHospitalDelDiaEntities db = new SMHospitalDelDiaEntities();

        // GET: api/Continentes
        public IQueryable<Continente> GetContinente()
        {
            return db.Continente;
        }

        // GET: api/Continentes/5
        [ResponseType(typeof(Continente))]
        public IHttpActionResult GetContinente(int id)
        {
            Continente continente = db.Continente.Find(id);
            if (continente == null)
            {
                return NotFound();
            }

            return Ok(continente);
        }

        // PUT: api/Continentes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutContinente(int id, Continente continente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != continente.idContinente)
            {
                return BadRequest();
            }

            db.Entry(continente).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContinenteExists(id))
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

        // POST: api/Continentes
        [ResponseType(typeof(Continente))]
        public IHttpActionResult PostContinente(Continente continente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Continente.Add(continente);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = continente.idContinente }, continente);
        }

        // DELETE: api/Continentes/5
        [ResponseType(typeof(Continente))]
        public IHttpActionResult DeleteContinente(int id)
        {
            Continente continente = db.Continente.Find(id);
            if (continente == null)
            {
                return NotFound();
            }

            db.Continente.Remove(continente);
            db.SaveChanges();

            return Ok(continente);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ContinenteExists(int id)
        {
            return db.Continente.Count(e => e.idContinente == id) > 0;
        }
    }
}