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
    public class GebruikersController : ApiController
    {
        private NL4_Vanderperre_Lucas_Laureyns_Piet_WebAPIContext db = new NL4_Vanderperre_Lucas_Laureyns_Piet_WebAPIContext();

        // GET: api/Gebruikers
        public IQueryable<Gebruiker> GetGebruikers()
        {
            return db.Gebruikers;
        }

        // GET: api/Gebruikers/5
        [ResponseType(typeof(Gebruiker))]
        public IHttpActionResult GetGebruiker(string username)
        {
            Gebruiker gebruiker = db.Gebruikers.Include("Abonnementen").FirstOrDefault(geb => geb.username == username);
            if (gebruiker == null)
            {
                return NotFound();
            }

            return Ok(gebruiker);
        }

        // PUT: api/Gebruikers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutGebruiker(int id, Gebruiker gebruiker)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != gebruiker.GebruikerId)
            {
                return BadRequest();
            }

            db.Entry(gebruiker).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GebruikerExists(id))
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

        // POST: api/Gebruikers
        [ResponseType(typeof(Gebruiker))]
        public IHttpActionResult PostGebruiker(Gebruiker gebruiker)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Gebruikers.Add(gebruiker);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = gebruiker.GebruikerId }, gebruiker);
        }

        // DELETE: api/Gebruikers/5
        [ResponseType(typeof(Gebruiker))]
        public IHttpActionResult DeleteGebruiker(int id)
        {
            Gebruiker gebruiker = db.Gebruikers.Find(id);
            if (gebruiker == null)
            {
                return NotFound();
            }

            db.Gebruikers.Remove(gebruiker);
            db.SaveChanges();

            return Ok(gebruiker);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GebruikerExists(int id)
        {
            return db.Gebruikers.Count(e => e.GebruikerId == id) > 0;
        }
    }
}