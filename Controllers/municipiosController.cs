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
    public class municipiosController : ApiController
    {
        private webservice_cpEntities db = new webservice_cpEntities();

        // GET: api/municipios
        public IQueryable<municipio> Getmunicipios()
        {
            return db.municipios;
        }


        [HttpGet]
        [Route("api/municipios/estado/{cve_estado}")]
        public IQueryable<municipio> getMunicipiosByEstado(int cve_estado)
        {
            return db.municipios.Where(m => m.cve_estado == cve_estado);
        }

        // GET: api/municipios/5
        [ResponseType(typeof(municipio))]
        public IHttpActionResult Getmunicipio(int id)
        {
            municipio municipio = db.municipios.Find(id);
            if (municipio == null)
            {
                return NotFound();
            }

            return Ok(municipio);
        }

        // PUT: api/municipios/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putmunicipio(int id, municipio municipio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != municipio.id)
            {
                return BadRequest();
            }

            db.Entry(municipio).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!municipioExists(id))
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

        // POST: api/municipios
        [ResponseType(typeof(municipio))]
        public IHttpActionResult Postmunicipio(municipio municipio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.municipios.Add(municipio);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = municipio.id }, municipio);
        }

        // DELETE: api/municipios/5
        [ResponseType(typeof(municipio))]
        public IHttpActionResult Deletemunicipio(int id)
        {
            municipio municipio = db.municipios.Find(id);
            if (municipio == null)
            {
                return NotFound();
            }

            db.municipios.Remove(municipio);
            db.SaveChanges();

            return Ok(municipio);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool municipioExists(int id)
        {
            return db.municipios.Count(e => e.id == id) > 0;
        }
    }
}