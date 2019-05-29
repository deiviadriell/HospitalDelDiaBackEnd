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
    public class subMenusController : ApiController
    {
        private SMHospitalDelDiaEntities db = new SMHospitalDelDiaEntities();

        // GET: api/subMenus
        public IQueryable<subMenu> GetsubMenu()
        {
            return db.subMenu;
        }

        // GET: api/subMenus/5
        [ResponseType(typeof(subMenu))]
        public IHttpActionResult GetsubMenu(int id)
        {
            subMenu subMenu = db.subMenu.Find(id);
            if (subMenu == null)
            {
                return NotFound();
            }

            return Ok(subMenu);
        }

        // PUT: api/subMenus/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutsubMenu(int id, subMenu subMenu)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != subMenu.idSubMenu)
            {
                return BadRequest();
            }

            db.Entry(subMenu).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!subMenuExists(id))
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

        // POST: api/subMenus
        [ResponseType(typeof(subMenu))]
        public IHttpActionResult PostsubMenu(subMenu subMenu)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.subMenu.Add(subMenu);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (subMenuExists(subMenu.idSubMenu))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = subMenu.idSubMenu }, subMenu);
        }

        // DELETE: api/subMenus/5
        [ResponseType(typeof(subMenu))]
        public IHttpActionResult DeletesubMenu(int id)
        {
            subMenu subMenu = db.subMenu.Find(id);
            if (subMenu == null)
            {
                return NotFound();
            }

            db.subMenu.Remove(subMenu);
            db.SaveChanges();

            return Ok(subMenu);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool subMenuExists(int id)
        {
            return db.subMenu.Count(e => e.idSubMenu == id) > 0;
        }
    }
}