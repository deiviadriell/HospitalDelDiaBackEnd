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
    public class EspecialidadEgresoesController : ApiController
    {
        private SMHospitalDelDiaEntities db = new SMHospitalDelDiaEntities();

        // GET: api/EspecialidadEgresoes
        public IQueryable<EspecialidadEgreso> GetEspecialidadEgreso()
        {
            return db.EspecialidadEgreso;
        }

        // GET: api/EspecialidadEgresoes/5
        [ResponseType(typeof(EspecialidadEgreso))]
        public IHttpActionResult GetEspecialidadEgreso(int id)
        {
            EspecialidadEgreso especialidadEgreso = db.EspecialidadEgreso.Find(id);
            if (especialidadEgreso == null)
            {
                return NotFound();
            }

            return Ok(especialidadEgreso);
        }

        // PUT: api/EspecialidadEgresoes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEspecialidadEgreso(int id, EspecialidadEgreso especialidadEgreso)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != especialidadEgreso.idEspecialidadEgreso)
            {
                return BadRequest();
            }

            db.Entry(especialidadEgreso).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EspecialidadEgresoExists(id))
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

        // POST: api/EspecialidadEgresoes
        [ResponseType(typeof(EspecialidadEgreso))]
        public IHttpActionResult PostEspecialidadEgreso(EspecialidadEgreso especialidadEgreso)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.EspecialidadEgreso.Add(especialidadEgreso);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = especialidadEgreso.idEspecialidadEgreso }, especialidadEgreso);
        }

        // DELETE: api/EspecialidadEgresoes/5
        [ResponseType(typeof(EspecialidadEgreso))]
        public IHttpActionResult DeleteEspecialidadEgreso(int id)
        {
            EspecialidadEgreso especialidadEgreso = db.EspecialidadEgreso.Find(id);
            if (especialidadEgreso == null)
            {
                return NotFound();
            }

            db.EspecialidadEgreso.Remove(especialidadEgreso);
            db.SaveChanges();

            return Ok(especialidadEgreso);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EspecialidadEgresoExists(int id)
        {
            return db.EspecialidadEgreso.Count(e => e.idEspecialidadEgreso == id) > 0;
        }
    }
}