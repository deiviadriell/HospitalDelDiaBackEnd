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
    public class AntecedentesPatologicosController : ApiController
    {
        private SMHospitalDelDiaEntities db = new SMHospitalDelDiaEntities();

        // GET: api/AntecedentesPatologicos
        public IQueryable<AntecedentesPatologicos> GetAntecedentesPatologicos()
        {
            return db.AntecedentesPatologicos;
        }

        // GET: api/AntecedentesPatologicos/5
        [ResponseType(typeof(AntecedentesPatologicos))]
        public IHttpActionResult GetAntecedentesPatologicos(int id)
        {
            AntecedentesPatologicos antecedentesPatologicos = db.AntecedentesPatologicos.Find(id);
            if (antecedentesPatologicos == null)
            {
                return NotFound();
            }

            return Ok(antecedentesPatologicos);
        }

        // PUT: api/AntecedentesPatologicos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAntecedentesPatologicos(int id, AntecedentesPatologicos antecedentesPatologicos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != antecedentesPatologicos.idAntecedentes)
            {
                return BadRequest();
            }

            db.Entry(antecedentesPatologicos).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AntecedentesPatologicosExists(id))
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

        // POST: api/AntecedentesPatologicos
        [ResponseType(typeof(AntecedentesPatologicos))]
        public IHttpActionResult PostAntecedentesPatologicos(AntecedentesPatologicos antecedentesPatologicos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.AntecedentesPatologicos.Add(antecedentesPatologicos);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = antecedentesPatologicos.idAntecedentes }, antecedentesPatologicos);
        }

        // DELETE: api/AntecedentesPatologicos/5
        [ResponseType(typeof(AntecedentesPatologicos))]
        public IHttpActionResult DeleteAntecedentesPatologicos(int id)
        {
            AntecedentesPatologicos antecedentesPatologicos = db.AntecedentesPatologicos.Find(id);
            if (antecedentesPatologicos == null)
            {
                return NotFound();
            }

            db.AntecedentesPatologicos.Remove(antecedentesPatologicos);
            db.SaveChanges();

            return Ok(antecedentesPatologicos);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AntecedentesPatologicosExists(int id)
        {
            return db.AntecedentesPatologicos.Count(e => e.idAntecedentes == id) > 0;
        }
    }
}