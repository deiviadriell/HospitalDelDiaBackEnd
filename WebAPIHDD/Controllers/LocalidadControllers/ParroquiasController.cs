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
    public class ParroquiasController : ApiController
    {
        private SMHospitalDelDiaEntities db = new SMHospitalDelDiaEntities();

        // GET: api/Parroquias
        public IQueryable<Parroquia> GetParroquia()
        {
            return db.Parroquia;
        }

        // GET: api/Parroquias/5
        [ResponseType(typeof(Parroquia))]
        public IHttpActionResult GetParroquia(int id)
        {
            Parroquia parroquia = db.Parroquia.Find(id);
            if (parroquia == null)
            {
                return NotFound();
            }

            return Ok(parroquia);
        }

        // PUT: api/Parroquias/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutParroquia(int id, Parroquia parroquia)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != parroquia.idParroquia)
            {
                return BadRequest();
            }

            db.Entry(parroquia).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParroquiaExists(id))
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

        // POST: api/Parroquias
        [ResponseType(typeof(Parroquia))]
        public IHttpActionResult PostParroquia(Parroquia parroquia)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Parroquia.Add(parroquia);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = parroquia.idParroquia }, parroquia);
        }

        // DELETE: api/Parroquias/5
        [ResponseType(typeof(Parroquia))]
        public IHttpActionResult DeleteParroquia(int id)
        {
            Parroquia parroquia = db.Parroquia.Find(id);
            if (parroquia == null)
            {
                return NotFound();
            }

            db.Parroquia.Remove(parroquia);
            db.SaveChanges();

            return Ok(parroquia);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ParroquiaExists(int id)
        {
            return db.Parroquia.Count(e => e.idParroquia == id) > 0;
        }
    }
}