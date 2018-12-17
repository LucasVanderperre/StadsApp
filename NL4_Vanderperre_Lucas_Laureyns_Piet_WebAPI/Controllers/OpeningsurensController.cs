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
using NL4_Vanderperre_Lucas_Laureyns_Piet_WebAPI.Models;

namespace NL4_Vanderperre_Lucas_Laureyns_Piet_WebAPI.Controllers
{
    public class OpeningsurensController : ApiController
    {
        private NL4_Vanderperre_Lucas_Laureyns_Piet_WebAPIContext db = new NL4_Vanderperre_Lucas_Laureyns_Piet_WebAPIContext();

        // GET: api/Openingsurens
        public IQueryable<Openingsuren> GetOpeningsurens()
        {
            return db.Openingsurens;
        }

        // GET: api/Openingsurens/5
        [ResponseType(typeof(Openingsuren))]
        public IHttpActionResult GetOpeningsuren(int id)
        {
            Openingsuren openingsuren = db.Openingsurens.Find(id);
            if (openingsuren == null)
            {
                return NotFound();
            }

            return Ok(openingsuren);
        }

        // PUT: api/Openingsurens/5
        [ResponseType(typeof(void))]
        [HttpPut]
        [Route("api/Openingsuren/{id}")]
        public IHttpActionResult PutOpeningsuren(int id, Openingsuren openingsuren)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != openingsuren.OpeningsurenId)
            {
                return BadRequest();
            }

            db.Entry(openingsuren).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OpeningsurenExists(id))
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

        // POST: api/Openingsurens
        [ResponseType(typeof(Openingsuren))]
        public IHttpActionResult PostOpeningsuren(Openingsuren openingsuren)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Openingsurens.Add(openingsuren);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = openingsuren.OpeningsurenId }, openingsuren);
        }

        // DELETE: api/Openingsurens/5
        [ResponseType(typeof(Openingsuren))]
        public IHttpActionResult DeleteOpeningsuren(int id)
        {
            Openingsuren openingsuren = db.Openingsurens.Find(id);
            if (openingsuren == null)
            {
                return NotFound();
            }

            db.Openingsurens.Remove(openingsuren);
            db.SaveChanges();

            return Ok(openingsuren);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool OpeningsurenExists(int id)
        {
            return db.Openingsurens.Count(e => e.OpeningsurenId == id) > 0;
        }
    }
}