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
    public class ConsultasController : ApiController
    {
        private SMHospitalDelDiaEntities db = new SMHospitalDelDiaEntities();

        // GET: api/Consultas
        public IQueryable<Consulta> GetConsulta()
        {
            return db.Consulta;
        }

        // GET: api/Consultas/5
        [ResponseType(typeof(Consulta))]
        public IHttpActionResult GetConsulta(int id)
        {
            Consulta consulta = db.Consulta.Find(id);
            if (consulta == null)
            {
                return NotFound();
            }

            return Ok(consulta);
        }

        // PUT: api/Consultas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutConsulta(int id, Consulta consulta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != consulta.idConsulta)
            {
                return BadRequest();
            }

            db.Entry(consulta).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConsultaExists(id))
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

        // POST: api/Consultas
        [ResponseType(typeof(Consulta))]
        public IHttpActionResult PostConsulta(Consulta consulta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Consulta.Add(consulta);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = consulta.idConsulta }, consulta);
        }

        // DELETE: api/Consultas/5
        [ResponseType(typeof(Consulta))]
        public IHttpActionResult DeleteConsulta(int id)
        {
            Consulta consulta = db.Consulta.Find(id);
            if (consulta == null)
            {
                return NotFound();
            }

            db.Consulta.Remove(consulta);
            db.SaveChanges();

            return Ok(consulta);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ConsultaExists(int id)
        {
            return db.Consulta.Count(e => e.idConsulta == id) > 0;
        }
    }
}