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
    public class PathsController : ApiController
    {
        private SMHospitalDelDiaEntities db = new SMHospitalDelDiaEntities();

        // GET: api/Paths
        public IQueryable<Path> GetPath()
        {
            return db.Path;
        }

        // GET: api/Paths/5
        [ResponseType(typeof(Path))]
        public IHttpActionResult GetPath(int id)
        {
            Path path = db.Path.Find(id);
            if (path == null)
            {
                return NotFound();
            }

            return Ok(path);
        }

        // PUT: api/Paths/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPath(int id, Path path)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != path.idPath)
            {
                return BadRequest();
            }

            db.Entry(path).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PathExists(id))
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

        // POST: api/Paths
        [ResponseType(typeof(Path))]
        public IHttpActionResult PostPath(Path path)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Path.Add(path);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = path.idPath }, path);
        }

        // DELETE: api/Paths/5
        [ResponseType(typeof(Path))]
        public IHttpActionResult DeletePath(int id)
        {
            Path path = db.Path.Find(id);
            if (path == null)
            {
                return NotFound();
            }

            db.Path.Remove(path);
            db.SaveChanges();

            return Ok(path);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PathExists(int id)
        {
            return db.Path.Count(e => e.idPath == id) > 0;
        }
    }
}