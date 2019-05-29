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
    public class OdontologiasController : ApiController
    {
        private SMHospitalDelDiaEntities db = new SMHospitalDelDiaEntities();

        // GET: api/Odontologias
        public IQueryable<Odontologia> GetOdontologia()
        {
            return db.Odontologia;
        }

        // GET: api/Odontologias/5
        [ResponseType(typeof(Odontologia))]
        public IHttpActionResult GetOdontologia(int id)
        {
            Odontologia odontologia = db.Odontologia.Find(id);
            if (odontologia == null)
            {
                return NotFound();
            }

            return Ok(odontologia);
        }

        // PUT: api/Odontologias/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutOdontologia(int id, Odontologia odontologia)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != odontologia.idOdontologia)
            {
                return BadRequest();
            }

            db.Entry(odontologia).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OdontologiaExists(id))
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

        // POST: api/Odontologias
        [ResponseType(typeof(Odontologia))]
        public IHttpActionResult PostOdontologia(Odontologia odontologia)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Odontologia.Add(odontologia);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = odontologia.idOdontologia }, odontologia);
        }

        // DELETE: api/Odontologias/5
        [ResponseType(typeof(Odontologia))]
        public IHttpActionResult DeleteOdontologia(int id)
        {
            Odontologia odontologia = db.Odontologia.Find(id);
            if (odontologia == null)
            {
                return NotFound();
            }

            db.Odontologia.Remove(odontologia);
            db.SaveChanges();

            return Ok(odontologia);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool OdontologiaExists(int id)
        {
            return db.Odontologia.Count(e => e.idOdontologia == id) > 0;
        }
    }
}