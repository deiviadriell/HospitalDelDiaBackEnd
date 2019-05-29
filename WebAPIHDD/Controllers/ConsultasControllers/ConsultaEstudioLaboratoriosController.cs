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
    public class ConsultaEstudioLaboratoriosController : ApiController
    {
        private SMHospitalDelDiaEntities db = new SMHospitalDelDiaEntities();

        // GET: api/ConsultaEstudioLaboratorios
        public IQueryable<ConsultaEstudioLaboratorio> GetConsultaEstudioLaboratorio()
        {
            return db.ConsultaEstudioLaboratorio;
        }

        // GET: api/ConsultaEstudioLaboratorios/5
        [ResponseType(typeof(ConsultaEstudioLaboratorio))]
        public IHttpActionResult GetConsultaEstudioLaboratorio(int id)
        {
            ConsultaEstudioLaboratorio consultaEstudioLaboratorio = db.ConsultaEstudioLaboratorio.Find(id);
            if (consultaEstudioLaboratorio == null)
            {
                return NotFound();
            }

            return Ok(consultaEstudioLaboratorio);
        }

        // PUT: api/ConsultaEstudioLaboratorios/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutConsultaEstudioLaboratorio(int id, ConsultaEstudioLaboratorio consultaEstudioLaboratorio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != consultaEstudioLaboratorio.idConsultaEstudioLaboratorio)
            {
                return BadRequest();
            }

            db.Entry(consultaEstudioLaboratorio).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConsultaEstudioLaboratorioExists(id))
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

        // POST: api/ConsultaEstudioLaboratorios
        [ResponseType(typeof(ConsultaEstudioLaboratorio))]
        public IHttpActionResult PostConsultaEstudioLaboratorio(ConsultaEstudioLaboratorio consultaEstudioLaboratorio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ConsultaEstudioLaboratorio.Add(consultaEstudioLaboratorio);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = consultaEstudioLaboratorio.idConsultaEstudioLaboratorio }, consultaEstudioLaboratorio);
        }

        // DELETE: api/ConsultaEstudioLaboratorios/5
        [ResponseType(typeof(ConsultaEstudioLaboratorio))]
        public IHttpActionResult DeleteConsultaEstudioLaboratorio(int id)
        {
            ConsultaEstudioLaboratorio consultaEstudioLaboratorio = db.ConsultaEstudioLaboratorio.Find(id);
            if (consultaEstudioLaboratorio == null)
            {
                return NotFound();
            }

            db.ConsultaEstudioLaboratorio.Remove(consultaEstudioLaboratorio);
            db.SaveChanges();

            return Ok(consultaEstudioLaboratorio);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ConsultaEstudioLaboratorioExists(int id)
        {
            return db.ConsultaEstudioLaboratorio.Count(e => e.idConsultaEstudioLaboratorio == id) > 0;
        }
    }
}