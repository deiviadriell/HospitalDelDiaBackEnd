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
    public class CondicionEgresoesController : ApiController
    {
        private SMHospitalDelDiaEntities db = new SMHospitalDelDiaEntities();

        // GET: api/CondicionEgresoes
        public IQueryable<CondicionEgreso> GetCondicionEgreso()
        {
            return db.CondicionEgreso;
        }

        // GET: api/CondicionEgresoes/5
        [ResponseType(typeof(CondicionEgreso))]
        public IHttpActionResult GetCondicionEgreso(int id)
        {
            CondicionEgreso condicionEgreso = db.CondicionEgreso.Find(id);
            if (condicionEgreso == null)
            {
                return NotFound();
            }

            return Ok(condicionEgreso);
        }

        // PUT: api/CondicionEgresoes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCondicionEgreso(int id, CondicionEgreso condicionEgreso)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != condicionEgreso.idCondicionEgreso)
            {
                return BadRequest();
            }

            db.Entry(condicionEgreso).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CondicionEgresoExists(id))
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

        // POST: api/CondicionEgresoes
        [ResponseType(typeof(CondicionEgreso))]
        public IHttpActionResult PostCondicionEgreso(CondicionEgreso condicionEgreso)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CondicionEgreso.Add(condicionEgreso);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = condicionEgreso.idCondicionEgreso }, condicionEgreso);
        }

        // DELETE: api/CondicionEgresoes/5
        [ResponseType(typeof(CondicionEgreso))]
        public IHttpActionResult DeleteCondicionEgreso(int id)
        {
            CondicionEgreso condicionEgreso = db.CondicionEgreso.Find(id);
            if (condicionEgreso == null)
            {
                return NotFound();
            }

            db.CondicionEgreso.Remove(condicionEgreso);
            db.SaveChanges();

            return Ok(condicionEgreso);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CondicionEgresoExists(int id)
        {
            return db.CondicionEgreso.Count(e => e.idCondicionEgreso == id) > 0;
        }
    }
}