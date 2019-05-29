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
    public class CantonsController : ApiController
    {
        private SMHospitalDelDiaEntities db = new SMHospitalDelDiaEntities();

        // GET: api/Cantons
        public IQueryable<Canton> GetCanton()
        {
            return db.Canton;
        }

        // GET: api/Cantons/5
        [ResponseType(typeof(Canton))]
        public IHttpActionResult GetCanton(int id)
        {
            Canton canton = db.Canton.Find(id);
            if (canton == null)
            {
                return NotFound();
            }

            return Ok(canton);
        }

        // PUT: api/Cantons/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCanton(int id, Canton canton)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != canton.idCanton)
            {
                return BadRequest();
            }

            db.Entry(canton).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CantonExists(id))
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

        // POST: api/Cantons
        [ResponseType(typeof(Canton))]
        public IHttpActionResult PostCanton(Canton canton)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Canton.Add(canton);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = canton.idCanton }, canton);
        }

        // DELETE: api/Cantons/5
        [ResponseType(typeof(Canton))]
        public IHttpActionResult DeleteCanton(int id)
        {
            Canton canton = db.Canton.Find(id);
            if (canton == null)
            {
                return NotFound();
            }

            db.Canton.Remove(canton);
            db.SaveChanges();

            return Ok(canton);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CantonExists(int id)
        {
            return db.Canton.Count(e => e.idCanton == id) > 0;
        }
    }
}