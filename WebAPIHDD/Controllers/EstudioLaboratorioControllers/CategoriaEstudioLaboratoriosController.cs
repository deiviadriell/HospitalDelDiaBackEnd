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
    public class CategoriaEstudioLaboratoriosController : ApiController
    {
        private SMHospitalDelDiaEntities db = new SMHospitalDelDiaEntities();

        // GET: api/CategoriaEstudioLaboratorios
        public IQueryable<CategoriaEstudioLaboratorio> GetCategoriaEstudioLaboratorio()
        {
            return db.CategoriaEstudioLaboratorio;
        }

        // GET: api/CategoriaEstudioLaboratorios/5
        [ResponseType(typeof(CategoriaEstudioLaboratorio))]
        public IHttpActionResult GetCategoriaEstudioLaboratorio(int id)
        {
            CategoriaEstudioLaboratorio categoriaEstudioLaboratorio = db.CategoriaEstudioLaboratorio.Find(id);
            if (categoriaEstudioLaboratorio == null)
            {
                return NotFound();
            }

            return Ok(categoriaEstudioLaboratorio);
        }

        // PUT: api/CategoriaEstudioLaboratorios/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCategoriaEstudioLaboratorio(int id, CategoriaEstudioLaboratorio categoriaEstudioLaboratorio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != categoriaEstudioLaboratorio.idCategoriaEstudioLaboratorio)
            {
                return BadRequest();
            }

            db.Entry(categoriaEstudioLaboratorio).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoriaEstudioLaboratorioExists(id))
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

        // POST: api/CategoriaEstudioLaboratorios
        [ResponseType(typeof(CategoriaEstudioLaboratorio))]
        public IHttpActionResult PostCategoriaEstudioLaboratorio(CategoriaEstudioLaboratorio categoriaEstudioLaboratorio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CategoriaEstudioLaboratorio.Add(categoriaEstudioLaboratorio);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = categoriaEstudioLaboratorio.idCategoriaEstudioLaboratorio }, categoriaEstudioLaboratorio);
        }

        // DELETE: api/CategoriaEstudioLaboratorios/5
        [ResponseType(typeof(CategoriaEstudioLaboratorio))]
        public IHttpActionResult DeleteCategoriaEstudioLaboratorio(int id)
        {
            CategoriaEstudioLaboratorio categoriaEstudioLaboratorio = db.CategoriaEstudioLaboratorio.Find(id);
            if (categoriaEstudioLaboratorio == null)
            {
                return NotFound();
            }

            db.CategoriaEstudioLaboratorio.Remove(categoriaEstudioLaboratorio);
            db.SaveChanges();

            return Ok(categoriaEstudioLaboratorio);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CategoriaEstudioLaboratorioExists(int id)
        {
            return db.CategoriaEstudioLaboratorio.Count(e => e.idCategoriaEstudioLaboratorio == id) > 0;
        }
    }
}