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
    public class HistoriaClinicasController : ApiController
    {
        private SMHospitalDelDiaEntities db = new SMHospitalDelDiaEntities();

        // GET: api/HistoriaClinicas
        public IQueryable<HistoriaClinica> GetHistoriaClinica()
        {
            return db.HistoriaClinica;
        }

        // GET: api/HistoriaClinicas/5
        [ResponseType(typeof(HistoriaClinica))]
        public IHttpActionResult GetHistoriaClinica(int id)
        {
            HistoriaClinica historiaClinica = db.HistoriaClinica.Find(id);
            if (historiaClinica == null)
            {
                return NotFound();
            }

            return Ok(historiaClinica);
        }

        // PUT: api/HistoriaClinicas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutHistoriaClinica(int id, HistoriaClinica historiaClinica)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != historiaClinica.idHiistoriaClinica)
            {
                return BadRequest();
            }

            db.Entry(historiaClinica).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HistoriaClinicaExists(id))
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

        // POST: api/HistoriaClinicas
        [ResponseType(typeof(HistoriaClinica))]
        public IHttpActionResult PostHistoriaClinica(HistoriaClinica historiaClinica)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.HistoriaClinica.Add(historiaClinica);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = historiaClinica.idHiistoriaClinica }, historiaClinica);
        }

        // DELETE: api/HistoriaClinicas/5
        [ResponseType(typeof(HistoriaClinica))]
        public IHttpActionResult DeleteHistoriaClinica(int id)
        {
            HistoriaClinica historiaClinica = db.HistoriaClinica.Find(id);
            if (historiaClinica == null)
            {
                return NotFound();
            }

            db.HistoriaClinica.Remove(historiaClinica);
            db.SaveChanges();

            return Ok(historiaClinica);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool HistoriaClinicaExists(int id)
        {
            return db.HistoriaClinica.Count(e => e.idHiistoriaClinica == id) > 0;
        }
    }
}