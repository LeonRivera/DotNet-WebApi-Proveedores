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
    public class estadoesController : ApiController
    {
        private webservice_cpEntities db = new webservice_cpEntities();

        // GET: api/estadoes
        public IQueryable<estado> Getestadoes()
        {
            return db.estadoes;
        }

        // GET: api/estadoes/5
        [ResponseType(typeof(estado))]
        public IHttpActionResult Getestado(int id)
        {
            estado estado = db.estadoes.Find(id);
            if (estado == null)
            {
                return NotFound();
            }

            return Ok(estado);
        }

        // PUT: api/estadoes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putestado(int id, estado estado)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != estado.clave)
            {
                return BadRequest();
            }

            db.Entry(estado).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!estadoExists(id))
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

        // POST: api/estadoes
        [ResponseType(typeof(estado))]
        public IHttpActionResult Postestado(estado estado)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.estadoes.Add(estado);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (estadoExists(estado.clave))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = estado.clave }, estado);
        }

        // DELETE: api/estadoes/5
        [ResponseType(typeof(estado))]
        public IHttpActionResult Deleteestado(int id)
        {
            estado estado = db.estadoes.Find(id);
            if (estado == null)
            {
                return NotFound();
            }

            db.estadoes.Remove(estado);
            db.SaveChanges();

            return Ok(estado);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool estadoExists(int id)
        {
            return db.estadoes.Count(e => e.clave == id) > 0;
        }
    }
}