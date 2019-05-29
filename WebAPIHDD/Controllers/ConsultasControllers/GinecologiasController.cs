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
    public class GinecologiasController : ApiController
    {
        private SMHospitalDelDiaEntities db = new SMHospitalDelDiaEntities();

        // GET: api/Ginecologias
        public IQueryable<Ginecologia> GetGinecologia()
        {
            return db.Ginecologia;
        }

        // GET: api/Ginecologias/5
        [ResponseType(typeof(Ginecologia))]
        public IHttpActionResult GetGinecologia(int id)
        {
            Ginecologia ginecologia = db.Ginecologia.Find(id);
            if (ginecologia == null)
            {
                return NotFound();
            }

            return Ok(ginecologia);
        }

        // PUT: api/Ginecologias/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutGinecologia(int id, Ginecologia ginecologia)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ginecologia.idGinecologia)
            {
                return BadRequest();
            }

            db.Entry(ginecologia).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GinecologiaExists(id))
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

        // POST: api/Ginecologias
        [ResponseType(typeof(Ginecologia))]
        public IHttpActionResult PostGinecologia(Ginecologia ginecologia)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Ginecologia.Add(ginecologia);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = ginecologia.idGinecologia }, ginecologia);
        }

        // DELETE: api/Ginecologias/5
        [ResponseType(typeof(Ginecologia))]
        public IHttpActionResult DeleteGinecologia(int id)
        {
            Ginecologia ginecologia = db.Ginecologia.Find(id);
            if (ginecologia == null)
            {
                return NotFound();
            }

            db.Ginecologia.Remove(ginecologia);
            db.SaveChanges();

            return Ok(ginecologia);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GinecologiaExists(int id)
        {
            return db.Ginecologia.Count(e => e.idGinecologia == id) > 0;
        }
    }
}