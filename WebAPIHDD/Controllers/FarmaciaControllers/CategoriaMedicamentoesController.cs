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

namespace WebAPIHDD.Controllers.FarmaciaControllers
{
    public class CategoriaMedicamentoesController : ApiController
    {
        private SMHospitalDelDiaEntities db = new SMHospitalDelDiaEntities();

        // GET: api/CategoriaMedicamentoes
        public IQueryable<CategoriaMedicamento> GetCategoriaMedicamento()
        {
            return db.CategoriaMedicamento;
        }

        // GET: api/CategoriaMedicamentoes/5
        [ResponseType(typeof(CategoriaMedicamento))]
        public IHttpActionResult GetCategoriaMedicamento(int id)
        {
            CategoriaMedicamento categoriaMedicamento = db.CategoriaMedicamento.Find(id);
            if (categoriaMedicamento == null)
            {
                return NotFound();
            }

            return Ok(categoriaMedicamento);
        }

        // PUT: api/CategoriaMedicamentoes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCategoriaMedicamento(int id, CategoriaMedicamento categoriaMedicamento)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != categoriaMedicamento.idCategoriaMedicamento)
            {
                return BadRequest();
            }

            db.Entry(categoriaMedicamento).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoriaMedicamentoExists(id))
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

        // POST: api/CategoriaMedicamentoes
        [ResponseType(typeof(CategoriaMedicamento))]
        public IHttpActionResult PostCategoriaMedicamento(CategoriaMedicamento categoriaMedicamento)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CategoriaMedicamento.Add(categoriaMedicamento);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = categoriaMedicamento.idCategoriaMedicamento }, categoriaMedicamento);
        }

        // DELETE: api/CategoriaMedicamentoes/5
        [ResponseType(typeof(CategoriaMedicamento))]
        public IHttpActionResult DeleteCategoriaMedicamento(int id)
        {
            CategoriaMedicamento categoriaMedicamento = db.CategoriaMedicamento.Find(id);
            if (categoriaMedicamento == null)
            {
                return NotFound();
            }

            db.CategoriaMedicamento.Remove(categoriaMedicamento);
            db.SaveChanges();

            return Ok(categoriaMedicamento);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CategoriaMedicamentoExists(int id)
        {
            return db.CategoriaMedicamento.Count(e => e.idCategoriaMedicamento == id) > 0;
        }
    }
}