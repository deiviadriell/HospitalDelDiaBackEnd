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
    public class PacientesController : ApiController
    {
        private SMHospitalDelDiaEntities db = new SMHospitalDelDiaEntities();

        // GET: api/Pacientes
        public IQueryable<Paciente> GetPaciente()
        {
            return db.Paciente;
        }

        // GET: api/Pacientes/5
        [ResponseType(typeof(Paciente))]
        public IHttpActionResult GetPaciente(int id)
        {
            Paciente paciente = db.Paciente.Find(id);
            if (paciente == null)
            {
                return NotFound();
            }

            return Ok(paciente);
        }

        // PUT: api/Pacientes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPaciente(int id, Paciente paciente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != paciente.idPaciente)
            {
                return BadRequest();
            }

            db.Entry(paciente).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PacienteExists(id))
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

        // POST: api/Pacientes
        [ResponseType(typeof(Paciente))]
        public IHttpActionResult PostPaciente(Paciente paciente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Paciente.Add(paciente);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (PacienteExists(paciente.idPaciente))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = paciente.idPaciente }, paciente);
        }

        // DELETE: api/Pacientes/5
        [ResponseType(typeof(Paciente))]
        public IHttpActionResult DeletePaciente(int id)
        {
            Paciente paciente = db.Paciente.Find(id);
            if (paciente == null)
            {
                return NotFound();
            }

            db.Paciente.Remove(paciente);
            db.SaveChanges();

            return Ok(paciente);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PacienteExists(int id)
        {
            return db.Paciente.Count(e => e.idPaciente == id) > 0;
        }
    }
}