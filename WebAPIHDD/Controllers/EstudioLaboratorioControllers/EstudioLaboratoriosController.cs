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

namespace WebAPIHDD.Controllers.EstudioLaboratorioControllers
{
    public class EstudioLaboratoriosController : ApiController
    {
        private SMHospitalDelDiaEntities db = new SMHospitalDelDiaEntities();

        // GET: api/EstudioLaboratorios
        public IQueryable<EstudioLaboratorio> GetEstudioLaboratorio()
        {
            return db.EstudioLaboratorio;
        }

        // GET: api/EstudioLaboratorios/5
        [ResponseType(typeof(EstudioLaboratorio))]
        public IHttpActionResult GetEstudioLaboratorio(int id)
        {
            EstudioLaboratorio estudioLaboratorio = db.EstudioLaboratorio.Find(id);
            if (estudioLaboratorio == null)
            {
                return NotFound();
            }

            return Ok(estudioLaboratorio);
        }

        // PUT: api/EstudioLaboratorios/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEstudioLaboratorio(int id, EstudioLaboratorio estudioLaboratorio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != estudioLaboratorio.idEstudioLaboratorio)
            {
                return BadRequest();
            }

            db.Entry(estudioLaboratorio).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EstudioLaboratorioExists(id))
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

        // POST: api/EstudioLaboratorios
        [ResponseType(typeof(EstudioLaboratorio))]
        public IHttpActionResult PostEstudioLaboratorio(EstudioLaboratorio estudioLaboratorio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.EstudioLaboratorio.Add(estudioLaboratorio);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = estudioLaboratorio.idEstudioLaboratorio }, estudioLaboratorio);
        }

        // DELETE: api/EstudioLaboratorios/5
        [ResponseType(typeof(EstudioLaboratorio))]
        public IHttpActionResult DeleteEstudioLaboratorio(int id)
        {
            EstudioLaboratorio estudioLaboratorio = db.EstudioLaboratorio.Find(id);
            if (estudioLaboratorio == null)
            {
                return NotFound();
            }

            db.EstudioLaboratorio.Remove(estudioLaboratorio);
            db.SaveChanges();

            return Ok(estudioLaboratorio);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EstudioLaboratorioExists(int id)
        {
            return db.EstudioLaboratorio.Count(e => e.idEstudioLaboratorio == id) > 0;
        }
    }
}