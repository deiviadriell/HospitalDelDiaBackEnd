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
    public class TipoConsultasController : ApiController
    {
        private SMHospitalDelDiaEntities db = new SMHospitalDelDiaEntities();

        // GET: api/TipoConsultas
        public IQueryable<TipoConsulta> GetTipoConsulta()
        {
            return db.TipoConsulta;
        }

        // GET: api/TipoConsultas/5
        [ResponseType(typeof(TipoConsulta))]
        public IHttpActionResult GetTipoConsulta(int id)
        {
            TipoConsulta tipoConsulta = db.TipoConsulta.Find(id);
            if (tipoConsulta == null)
            {
                return NotFound();
            }

            return Ok(tipoConsulta);
        }

        // PUT: api/TipoConsultas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTipoConsulta(int id, TipoConsulta tipoConsulta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tipoConsulta.idTipoConsulta)
            {
                return BadRequest();
            }

            db.Entry(tipoConsulta).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoConsultaExists(id))
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

        // POST: api/TipoConsultas
        [ResponseType(typeof(TipoConsulta))]
        public IHttpActionResult PostTipoConsulta(TipoConsulta tipoConsulta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TipoConsulta.Add(tipoConsulta);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tipoConsulta.idTipoConsulta }, tipoConsulta);
        }

        // DELETE: api/TipoConsultas/5
        [ResponseType(typeof(TipoConsulta))]
        public IHttpActionResult DeleteTipoConsulta(int id)
        {
            TipoConsulta tipoConsulta = db.TipoConsulta.Find(id);
            if (tipoConsulta == null)
            {
                return NotFound();
            }

            db.TipoConsulta.Remove(tipoConsulta);
            db.SaveChanges();

            return Ok(tipoConsulta);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TipoConsultaExists(int id)
        {
            return db.TipoConsulta.Count(e => e.idTipoConsulta == id) > 0;
        }
    }
}