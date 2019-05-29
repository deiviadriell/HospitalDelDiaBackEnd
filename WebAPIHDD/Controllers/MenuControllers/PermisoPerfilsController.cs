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

namespace WebAPIHDD.Controllers.MenuControllers
{
    public class PermisoPerfilsController : ApiController
    {
        private SMHospitalDelDiaEntities db = new SMHospitalDelDiaEntities();

        // GET: api/PermisoPerfils
        public IQueryable<PermisoPerfil> GetPermisoPerfil()
        {
            return db.PermisoPerfil;
        }

        // GET: api/PermisoPerfils/5
        [ResponseType(typeof(PermisoPerfil))]
        public IHttpActionResult GetPermisoPerfil(int id)
        {
            PermisoPerfil permisoPerfil = db.PermisoPerfil.Find(id);
            if (permisoPerfil == null)
            {
                return NotFound();
            }

            return Ok(permisoPerfil);
        }

        // PUT: api/PermisoPerfils/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPermisoPerfil(int id, PermisoPerfil permisoPerfil)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != permisoPerfil.idPermisoPerfil)
            {
                return BadRequest();
            }

            db.Entry(permisoPerfil).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PermisoPerfilExists(id))
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

        // POST: api/PermisoPerfils
        [ResponseType(typeof(PermisoPerfil))]
        public IHttpActionResult PostPermisoPerfil(PermisoPerfil permisoPerfil)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PermisoPerfil.Add(permisoPerfil);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = permisoPerfil.idPermisoPerfil }, permisoPerfil);
        }

        // DELETE: api/PermisoPerfils/5
        [ResponseType(typeof(PermisoPerfil))]
        public IHttpActionResult DeletePermisoPerfil(int id)
        {
            PermisoPerfil permisoPerfil = db.PermisoPerfil.Find(id);
            if (permisoPerfil == null)
            {
                return NotFound();
            }

            db.PermisoPerfil.Remove(permisoPerfil);
            db.SaveChanges();

            return Ok(permisoPerfil);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PermisoPerfilExists(int id)
        {
            return db.PermisoPerfil.Count(e => e.idPermisoPerfil == id) > 0;
        }
    }
}