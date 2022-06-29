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
using ApiRestProveedores.NET.Models;

namespace ApiRestProveedores.NET.Controllers
{
    public class localidadsController : ApiController
    {
        private webservice_cpEntities db = new webservice_cpEntities();

        // GET: api/localidads
        public IQueryable<localidad> Getlocalidads()
        {
            return db.localidads;
        }

        // GET: api/localidads/5
        [ResponseType(typeof(localidad))]
        public IHttpActionResult Getlocalidad(int id)
        {
            localidad localidad = db.localidads.Find(id);
            if (localidad == null)
            {
                return NotFound();
            }

            return Ok(localidad);
        }

        // PUT: api/localidads/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putlocalidad(int id, localidad localidad)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != localidad.id)
            {
                return BadRequest();
            }

            db.Entry(localidad).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!localidadExists(id))
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

        // POST: api/localidads
        [ResponseType(typeof(localidad))]
        public IHttpActionResult Postlocalidad(localidad localidad)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.localidads.Add(localidad);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = localidad.id }, localidad);
        }

        // DELETE: api/localidads/5
        [ResponseType(typeof(localidad))]
        public IHttpActionResult Deletelocalidad(int id)
        {
            localidad localidad = db.localidads.Find(id);
            if (localidad == null)
            {
                return NotFound();
            }

            db.localidads.Remove(localidad);
            db.SaveChanges();

            return Ok(localidad);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool localidadExists(int id)
        {
            return db.localidads.Count(e => e.id == id) > 0;
        }
    }
}