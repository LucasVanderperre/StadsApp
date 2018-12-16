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
    public class OndernemersController : ApiController
    {
        private NL4_Vanderperre_Lucas_Laureyns_Piet_WebAPIContext db = new NL4_Vanderperre_Lucas_Laureyns_Piet_WebAPIContext();

        // GET: api/Ondernemers
        public IQueryable<Ondernemer> GetGebruikers()
        {
            return db.Ondernemers;
        }

        // GET: api/Ondernemers/5
        [ResponseType(typeof(Ondernemer))]
        [HttpGet]
        [Route("api/Ondernemers/{username}")]
        public IHttpActionResult GetOndernemer(string username)
        {
            Ondernemer ondernemer = db.Ondernemers.Include("Ondernemingen").Include("Ondernemingen.Adressen").Include("Ondernemingen.Promoties")
                .Include("Ondernemingen.Events").FirstOrDefault(geb => geb.username == username);
            if (ondernemer == null)
            {
                return NotFound();
            }

            return Ok(ondernemer);
        }

        // PUT: api/Ondernemers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutOndernemer(int id, Ondernemer ondernemer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ondernemer.GebruikerId)
            {
                return BadRequest();
            }

            db.Entry(ondernemer).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OndernemerExists(id))
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

        // POST: api/Ondernemers
        [ResponseType(typeof(Ondernemer))]
        public IHttpActionResult PostOndernemer(Ondernemer ondernemer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Gebruikers.Add(ondernemer);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = ondernemer.GebruikerId }, ondernemer);
        }

        // DELETE: api/Ondernemers/5
        [ResponseType(typeof(Ondernemer))]
        public IHttpActionResult DeleteOndernemer(int id)
        {
            Ondernemer ondernemer = db.Ondernemers.Find(id);
            if (ondernemer == null)
            {
                return NotFound();
            }

            db.Gebruikers.Remove(ondernemer);
            db.SaveChanges();

            return Ok(ondernemer);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool OndernemerExists(int id)
        {
            return db.Gebruikers.Count(e => e.GebruikerId == id) > 0;
        }
    }
}