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

namespace WebAPIHDD.Controllers.PacienteControllers
{
    public class ObstetriciasController : ApiController
    {
        private SMHospitalDelDiaEntities db = new SMHospitalDelDiaEntities();

        // GET: api/Obstetricias
        public IQueryable<Obstetricia> GetObstetricia()
        {
            return db.Obstetricia;
        }

        // GET: api/Obstetricias/5
        [ResponseType(typeof(Obstetricia))]
        public IHttpActionResult GetObstetricia(int id)
        {
            Obstetricia obstetricia = db.Obstetricia.Find(id);
            if (obstetricia == null)
            {
                return NotFound();
            }

            return Ok(obstetricia);
        }

        // PUT: api/Obstetricias/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutObstetricia(int id, Obstetricia obstetricia)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != obstetricia.idObstetricia)
            {
                return BadRequest();
            }

            db.Entry(obstetricia).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ObstetriciaExists(id))
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

        // POST: api/Obstetricias
        [ResponseType(typeof(Obstetricia))]
        public IHttpActionResult PostObstetricia(Obstetricia obstetricia)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Obstetricia.Add(obstetricia);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = obstetricia.idObstetricia }, obstetricia);
        }

        // DELETE: api/Obstetricias/5
        [ResponseType(typeof(Obstetricia))]
        public IHttpActionResult DeleteObstetricia(int id)
        {
            Obstetricia obstetricia = db.Obstetricia.Find(id);
            if (obstetricia == null)
            {
                return NotFound();
            }

            db.Obstetricia.Remove(obstetricia);
            db.SaveChanges();

            return Ok(obstetricia);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ObstetriciaExists(int id)
        {
            return db.Obstetricia.Count(e => e.idObstetricia == id) > 0;
        }
    }
}