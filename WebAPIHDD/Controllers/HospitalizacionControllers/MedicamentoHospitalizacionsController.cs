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
    public class MedicamentoHospitalizacionsController : ApiController
    {
        private SMHospitalDelDiaEntities db = new SMHospitalDelDiaEntities();

        // GET: api/MedicamentoHospitalizacions
        public IQueryable<MedicamentoHospitalizacion> GetMedicamentoHospitalizacion()
        {
            return db.MedicamentoHospitalizacion;
        }

        // GET: api/MedicamentoHospitalizacions/5
        [ResponseType(typeof(MedicamentoHospitalizacion))]
        public IHttpActionResult GetMedicamentoHospitalizacion(int id)
        {
            MedicamentoHospitalizacion medicamentoHospitalizacion = db.MedicamentoHospitalizacion.Find(id);
            if (medicamentoHospitalizacion == null)
            {
                return NotFound();
            }

            return Ok(medicamentoHospitalizacion);
        }

        // PUT: api/MedicamentoHospitalizacions/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMedicamentoHospitalizacion(int id, MedicamentoHospitalizacion medicamentoHospitalizacion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != medicamentoHospitalizacion.idMedicamentoHospitalizacion)
            {
                return BadRequest();
            }

            db.Entry(medicamentoHospitalizacion).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MedicamentoHospitalizacionExists(id))
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

        // POST: api/MedicamentoHospitalizacions
        [ResponseType(typeof(MedicamentoHospitalizacion))]
        public IHttpActionResult PostMedicamentoHospitalizacion(MedicamentoHospitalizacion medicamentoHospitalizacion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MedicamentoHospitalizacion.Add(medicamentoHospitalizacion);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = medicamentoHospitalizacion.idMedicamentoHospitalizacion }, medicamentoHospitalizacion);
        }

        // DELETE: api/MedicamentoHospitalizacions/5
        [ResponseType(typeof(MedicamentoHospitalizacion))]
        public IHttpActionResult DeleteMedicamentoHospitalizacion(int id)
        {
            MedicamentoHospitalizacion medicamentoHospitalizacion = db.MedicamentoHospitalizacion.Find(id);
            if (medicamentoHospitalizacion == null)
            {
                return NotFound();
            }

            db.MedicamentoHospitalizacion.Remove(medicamentoHospitalizacion);
            db.SaveChanges();

            return Ok(medicamentoHospitalizacion);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MedicamentoHospitalizacionExists(int id)
        {
            return db.MedicamentoHospitalizacion.Count(e => e.idMedicamentoHospitalizacion == id) > 0;
        }
    }
}