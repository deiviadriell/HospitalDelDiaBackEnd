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

namespace WebAPIHDD.Controllers.ArchivoControllers
{
    public class LinkArchivoesController : ApiController
    {
        private SMHospitalDelDiaEntities db = new SMHospitalDelDiaEntities();

        // GET: api/LinkArchivoes
        public IQueryable<LinkArchivo> GetLinkArchivo()
        {
            return db.LinkArchivo;
        }

        // GET: api/LinkArchivoes/5
        [ResponseType(typeof(LinkArchivo))]
        public IHttpActionResult GetLinkArchivo(int id)
        {
            LinkArchivo linkArchivo = db.LinkArchivo.Find(id);
            if (linkArchivo == null)
            {
                return NotFound();
            }

            return Ok(linkArchivo);
        }

        // PUT: api/LinkArchivoes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLinkArchivo(int id, LinkArchivo linkArchivo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != linkArchivo.idLinkArchivo)
            {
                return BadRequest();
            }

            db.Entry(linkArchivo).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LinkArchivoExists(id))
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

        // POST: api/LinkArchivoes
        [ResponseType(typeof(LinkArchivo))]
        public IHttpActionResult PostLinkArchivo(LinkArchivo linkArchivo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.LinkArchivo.Add(linkArchivo);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = linkArchivo.idLinkArchivo }, linkArchivo);
        }

        // DELETE: api/LinkArchivoes/5
        [ResponseType(typeof(LinkArchivo))]
        public IHttpActionResult DeleteLinkArchivo(int id)
        {
            LinkArchivo linkArchivo = db.LinkArchivo.Find(id);
            if (linkArchivo == null)
            {
                return NotFound();
            }

            db.LinkArchivo.Remove(linkArchivo);
            db.SaveChanges();

            return Ok(linkArchivo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LinkArchivoExists(int id)
        {
            return db.LinkArchivo.Count(e => e.idLinkArchivo == id) > 0;
        }
    }
}