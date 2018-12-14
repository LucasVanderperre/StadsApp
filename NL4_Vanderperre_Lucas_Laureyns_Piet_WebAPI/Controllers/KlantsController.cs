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
    public class KlantsController : ApiController
    {
        private NL4_Vanderperre_Lucas_Laureyns_Piet_WebAPIContext db = new NL4_Vanderperre_Lucas_Laureyns_Piet_WebAPIContext();

        // GET: api/Klants
        public IQueryable<Klant> GetGebruikers()
        {
            return db.Klants;
        }

        // GET: api/Klants/5
        [HttpGet]
        [Route("api/Klants/{username}")]
        public IHttpActionResult GetKlant(string username)
        {
            Klant klant = db.Klants.Include("Abonnementen").FirstOrDefault(geb => geb.username == username);

            if (klant == null)
            {
                return NotFound();
            }

            return Ok(klant);
        }

        // PUT: api/Klants/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutKlant(int id, Klant klant)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != klant.GebruikerId)
            {
                return BadRequest();
            }

            db.Entry(klant).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KlantExists(id))
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

        // POST: api/Klants
        [ResponseType(typeof(Klant))]
        public IHttpActionResult PostKlant(Klant klant)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Klants.Add(klant);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = klant.GebruikerId }, klant);
        }

        // DELETE: api/Klants/5
        [ResponseType(typeof(Klant))]
        public IHttpActionResult DeleteKlant(int id)
        {
            Klant klant = (Klant) db.Gebruikers.Find(id);
            if (klant == null)
            {
                return NotFound();
            }

            db.Gebruikers.Remove(klant);
            db.SaveChanges();

            return Ok(klant);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool KlantExists(int id)
        {
            return db.Gebruikers.Count(e => e.GebruikerId == id) > 0;
        }
    }
}