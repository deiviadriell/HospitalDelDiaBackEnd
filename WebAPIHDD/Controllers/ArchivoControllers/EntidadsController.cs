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

namespace WebAPIHDD.Controllers.ArchivoControllers
{
    public class EntidadsController : ApiController
    {
        private SMHospitalDelDiaEntities db = new SMHospitalDelDiaEntities();

        // GET: api/Entidads
        public IQueryable<Entidad> GetEntidad()
        {
            return db.Entidad;
        }

        // GET: api/Entidads/5
        [ResponseType(typeof(Entidad))]
        public IHttpActionResult GetEntidad(int id)
        {
            Entidad entidad = db.Entidad.Find(id);
            if (entidad == null)
            {
                return NotFound();
            }

            return Ok(entidad);
        }

        // PUT: api/Entidads/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEntidad(int id, Entidad entidad)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != entidad.idEntidad)
            {
                return BadRequest();
            }

            db.Entry(entidad).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EntidadExists(id))
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

        // POST: api/Entidads
        [ResponseType(typeof(Entidad))]
        public IHttpActionResult PostEntidad(Entidad entidad)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Entidad.Add(entidad);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = entidad.idEntidad }, entidad);
        }

        // DELETE: api/Entidads/5
        [ResponseType(typeof(Entidad))]
        public IHttpActionResult DeleteEntidad(int id)
        {
            Entidad entidad = db.Entidad.Find(id);
            if (entidad == null)
            {
                return NotFound();
            }

            db.Entidad.Remove(entidad);
            db.SaveChanges();

            return Ok(entidad);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EntidadExists(int id)
        {
            return db.Entidad.Count(e => e.idEntidad == id) > 0;
        }
    }
}