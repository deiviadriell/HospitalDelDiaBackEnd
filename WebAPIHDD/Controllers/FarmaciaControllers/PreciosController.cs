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

namespace WebAPIHDD.Controllers.FarmaciaControllers
{
    public class PreciosController : ApiController
    {
        private SMHospitalDelDiaEntities db = new SMHospitalDelDiaEntities();

        // GET: api/Precios
        public IQueryable<Precio> GetPrecio()
        {
            return db.Precio;
        }

        // GET: api/Precios/5
        [ResponseType(typeof(Precio))]
        public IHttpActionResult GetPrecio(int id)
        {
            Precio precio = db.Precio.Find(id);
            if (precio == null)
            {
                return NotFound();
            }

            return Ok(precio);
        }

        // PUT: api/Precios/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPrecio(int id, Precio precio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != precio.idPrecio)
            {
                return BadRequest();
            }

            db.Entry(precio).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PrecioExists(id))
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

        // POST: api/Precios
        [ResponseType(typeof(Precio))]
        public IHttpActionResult PostPrecio(Precio precio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Precio.Add(precio);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = precio.idPrecio }, precio);
        }

        // DELETE: api/Precios/5
        [ResponseType(typeof(Precio))]
        public IHttpActionResult DeletePrecio(int id)
        {
            Precio precio = db.Precio.Find(id);
            if (precio == null)
            {
                return NotFound();
            }

            db.Precio.Remove(precio);
            db.SaveChanges();

            return Ok(precio);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PrecioExists(int id)
        {
            return db.Precio.Count(e => e.idPrecio == id) > 0;
        }
    }
}