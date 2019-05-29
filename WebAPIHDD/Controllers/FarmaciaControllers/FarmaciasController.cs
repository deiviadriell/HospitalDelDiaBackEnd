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
    public class FarmaciasController : ApiController
    {
        private SMHospitalDelDiaEntities db = new SMHospitalDelDiaEntities();

        // GET: api/Farmacias
        public IQueryable<Farmacia> GetFarmacia()
        {
            return db.Farmacia;
        }

        // GET: api/Farmacias/5
        [ResponseType(typeof(Farmacia))]
        public IHttpActionResult GetFarmacia(int id)
        {
            Farmacia farmacia = db.Farmacia.Find(id);
            if (farmacia == null)
            {
                return NotFound();
            }

            return Ok(farmacia);
        }

        // PUT: api/Farmacias/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutFarmacia(int id, Farmacia farmacia)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != farmacia.idFarmacia)
            {
                return BadRequest();
            }

            db.Entry(farmacia).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FarmaciaExists(id))
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

        // POST: api/Farmacias
        [ResponseType(typeof(Farmacia))]
        public IHttpActionResult PostFarmacia(Farmacia farmacia)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Farmacia.Add(farmacia);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = farmacia.idFarmacia }, farmacia);
        }

        // DELETE: api/Farmacias/5
        [ResponseType(typeof(Farmacia))]
        public IHttpActionResult DeleteFarmacia(int id)
        {
            Farmacia farmacia = db.Farmacia.Find(id);
            if (farmacia == null)
            {
                return NotFound();
            }

            db.Farmacia.Remove(farmacia);
            db.SaveChanges();

            return Ok(farmacia);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FarmaciaExists(int id)
        {
            return db.Farmacia.Count(e => e.idFarmacia == id) > 0;
        }
    }
}