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
    public class CodigoCIEsController : ApiController
    {
        private SMHospitalDelDiaEntities db = new SMHospitalDelDiaEntities();

        // GET: api/CodigoCIEs
        public IQueryable<CodigoCIE> GetCodigoCIE()
        {
            return db.CodigoCIE;
        }

        // GET: api/CodigoCIEs/5
        [ResponseType(typeof(CodigoCIE))]
        public IHttpActionResult GetCodigoCIE(int id)
        {
            CodigoCIE codigoCIE = db.CodigoCIE.Find(id);
            if (codigoCIE == null)
            {
                return NotFound();
            }

            return Ok(codigoCIE);
        }

        // PUT: api/CodigoCIEs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCodigoCIE(int id, CodigoCIE codigoCIE)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != codigoCIE.idCodigoCie)
            {
                return BadRequest();
            }

            db.Entry(codigoCIE).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CodigoCIEExists(id))
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

        // POST: api/CodigoCIEs
        [ResponseType(typeof(CodigoCIE))]
        public IHttpActionResult PostCodigoCIE(CodigoCIE codigoCIE)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CodigoCIE.Add(codigoCIE);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = codigoCIE.idCodigoCie }, codigoCIE);
        }

        // DELETE: api/CodigoCIEs/5
        [ResponseType(typeof(CodigoCIE))]
        public IHttpActionResult DeleteCodigoCIE(int id)
        {
            CodigoCIE codigoCIE = db.CodigoCIE.Find(id);
            if (codigoCIE == null)
            {
                return NotFound();
            }

            db.CodigoCIE.Remove(codigoCIE);
            db.SaveChanges();

            return Ok(codigoCIE);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CodigoCIEExists(int id)
        {
            return db.CodigoCIE.Count(e => e.idCodigoCie == id) > 0;
        }
    }
}