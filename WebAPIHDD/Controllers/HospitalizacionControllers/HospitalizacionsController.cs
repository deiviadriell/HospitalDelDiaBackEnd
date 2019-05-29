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

namespace WebAPIHDD.Controllers.HospitalizacionControllers
{
    public class HospitalizacionsController : ApiController
    {
        private SMHospitalDelDiaEntities db = new SMHospitalDelDiaEntities();

        // GET: api/Hospitalizacions
        public IQueryable<Hospitalizacion> GetHospitalizacion()
        {
            return db.Hospitalizacion;
        }

        // GET: api/Hospitalizacions/5
        [ResponseType(typeof(Hospitalizacion))]
        public IHttpActionResult GetHospitalizacion(int id)
        {
            Hospitalizacion hospitalizacion = db.Hospitalizacion.Find(id);
            if (hospitalizacion == null)
            {
                return NotFound();
            }

            return Ok(hospitalizacion);
        }

        // PUT: api/Hospitalizacions/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutHospitalizacion(int id, Hospitalizacion hospitalizacion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != hospitalizacion.idHospitalizacion)
            {
                return BadRequest();
            }

            db.Entry(hospitalizacion).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HospitalizacionExists(id))
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

        // POST: api/Hospitalizacions
        [ResponseType(typeof(Hospitalizacion))]
        public IHttpActionResult PostHospitalizacion(Hospitalizacion hospitalizacion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Hospitalizacion.Add(hospitalizacion);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = hospitalizacion.idHospitalizacion }, hospitalizacion);
        }

        // DELETE: api/Hospitalizacions/5
        [ResponseType(typeof(Hospitalizacion))]
        public IHttpActionResult DeleteHospitalizacion(int id)
        {
            Hospitalizacion hospitalizacion = db.Hospitalizacion.Find(id);
            if (hospitalizacion == null)
            {
                return NotFound();
            }

            db.Hospitalizacion.Remove(hospitalizacion);
            db.SaveChanges();

            return Ok(hospitalizacion);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool HospitalizacionExists(int id)
        {
            return db.Hospitalizacion.Count(e => e.idHospitalizacion == id) > 0;
        }
    }
}