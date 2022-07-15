using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using ApiRestProveedores.NET.Models;

namespace ApiRestProveedores.NET.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class proveedorsController : ApiController
    {
        private webservice_cpEntities db = new webservice_cpEntities();

        // GET: api/proveedors
        public IQueryable<proveedor> Getproveedors()
        {
            return db.proveedors;
        }

        // GET: api/proveedors/5
        [ResponseType(typeof(proveedor))]
        public IHttpActionResult Getproveedor(int id)
        {
            proveedor proveedor = db.proveedors.Find(id);
            if (proveedor == null)
            {
                return NotFound();
            }

            return Ok(proveedor);
        }

        // PUT: api/proveedors/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putproveedor(int id, proveedor proveedor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != proveedor.id)
            {
                return BadRequest();
            }

            db.Entry(proveedor).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!proveedorExists(id))
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

        // POST: api/proveedors
        [ResponseType(typeof(proveedor))]
        public IHttpActionResult Postproveedor(proveedor proveedor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.proveedors.Add(proveedor);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = proveedor.id }, proveedor);
        }

        // DELETE: api/proveedors/5
        [ResponseType(typeof(proveedor))]
        public IHttpActionResult Deleteproveedor(int id)
        {
            proveedor proveedor = db.proveedors.Find(id);
            if (proveedor == null)
            {
                return NotFound();
            }

            db.proveedors.Remove(proveedor);
            db.SaveChanges();

            return Ok(proveedor);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool proveedorExists(int id)
        {
            return db.proveedors.Count(e => e.id == id) > 0;
        }
    }
}