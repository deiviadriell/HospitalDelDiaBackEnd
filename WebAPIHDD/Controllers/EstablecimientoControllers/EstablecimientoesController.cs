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

namespace WebAPIHDD.Controllers.EstablecimientoControllers
{
    public class EstablecimientoesController : ApiController
    {
        private SMHospitalDelDiaEntities db = new SMHospitalDelDiaEntities();

        // GET: api/Establecimientoes
        public IQueryable<Establecimiento> GetEstablecimiento()
        {
            return db.Establecimiento;
        }

        // GET: api/Establecimientoes/5
        [ResponseType(typeof(Establecimiento))]
        public IHttpActionResult GetEstablecimiento(int id)
        {
            Establecimiento establecimiento = db.Establecimiento.Find(id);
            if (establecimiento == null)
            {
                return NotFound();
            }

            return Ok(establecimiento);
        }

        // PUT: api/Establecimientoes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEstablecimiento(int id, Establecimiento establecimiento)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != establecimiento.idEstablecimiento)
            {
                return BadRequest();
            }

            db.Entry(establecimiento).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EstablecimientoExists(id))
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

        // POST: api/Establecimientoes
        [ResponseType(typeof(Establecimiento))]
        public IHttpActionResult PostEstablecimiento(Establecimiento establecimiento)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Establecimiento.Add(establecimiento);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = establecimiento.idEstablecimiento }, establecimiento);
        }

        // DELETE: api/Establecimientoes/5
        [ResponseType(typeof(Establecimiento))]
        public IHttpActionResult DeleteEstablecimiento(int id)
        {
            Establecimiento establecimiento = db.Establecimiento.Find(id);
            if (establecimiento == null)
            {
                return NotFound();
            }

            db.Establecimiento.Remove(establecimiento);
            db.SaveChanges();

            return Ok(establecimiento);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EstablecimientoExists(int id)
        {
            return db.Establecimiento.Count(e => e.idEstablecimiento == id) > 0;
        }
    }
}