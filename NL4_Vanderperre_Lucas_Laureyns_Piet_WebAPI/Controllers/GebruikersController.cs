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
        [HttpGet]
        [Route("api/Gebruikers/isKlant/{username}")]
        public IHttpActionResult GetGebruiker(string username)
        {
            Gebruiker gebruiker = db.Gebruikers.FirstOrDefault(geb => geb.username == username);
            if (gebruiker == null)
            {
                return NotFound();
            }
            if(gebruiker.GetType() == typeof(Ondernemer))
            {
                return Ok(false);
            }
            else
            {
                return Ok(true);
            }
        }

        // PUT: api/Gebruikers/5
        [ResponseType(typeof(void))]
        [Route("api/Gebruikers/login")]
        public IHttpActionResult PutGebruiker(Gebruiker gbr)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Gebruiker gebruiker = db.Gebruikers.FirstOrDefault(geb => geb.username == gbr.username);

            if (gebruiker == null || gebruiker.password != gbr.password)
            {
                return BadRequest();
            }
            

            db.Entry(gebruiker).State = EntityState.Modified;

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

        // POST: api/Gebruikers/Ondernemer
        [ResponseType(typeof(Ondernemer))]
        [Route("api/Gebruikers/Ondernemer", Name = "CreateOndernemer")]
        public IHttpActionResult PostOndernemer(Ondernemer gebruiker)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
           db.Ondernemings.Add(gebruiker.Ondernemingen.First());

            db.Ondernemers.Add(gebruiker);
            db.SaveChanges();


            return CreatedAtRoute("CreateOndernemer", new { id = gebruiker.GebruikerId }, gebruiker);
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