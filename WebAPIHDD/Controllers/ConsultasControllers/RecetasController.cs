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
    public class RecetasController : ApiController
    {
        private SMHospitalDelDiaEntities db = new SMHospitalDelDiaEntities();

        // GET: api/Recetas
        public IQueryable<Receta> GetReceta()
        {
            return db.Receta;
        }

        // GET: api/Recetas/5
        [ResponseType(typeof(Receta))]
        public IHttpActionResult GetReceta(int id)
        {
            Receta receta = db.Receta.Find(id);
            if (receta == null)
            {
                return NotFound();
            }

            return Ok(receta);
        }

        // PUT: api/Recetas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutReceta(int id, Receta receta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != receta.idReceta)
            {
                return BadRequest();
            }

            db.Entry(receta).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecetaExists(id))
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

        // POST: api/Recetas
        [ResponseType(typeof(Receta))]
        public IHttpActionResult PostReceta(Receta receta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Receta.Add(receta);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = receta.idReceta }, receta);
        }

        // DELETE: api/Recetas/5
        [ResponseType(typeof(Receta))]
        public IHttpActionResult DeleteReceta(int id)
        {
            Receta receta = db.Receta.Find(id);
            if (receta == null)
            {
                return NotFound();
            }

            db.Receta.Remove(receta);
            db.SaveChanges();

            return Ok(receta);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RecetaExists(int id)
        {
            return db.Receta.Count(e => e.idReceta == id) > 0;
        }
    }
}