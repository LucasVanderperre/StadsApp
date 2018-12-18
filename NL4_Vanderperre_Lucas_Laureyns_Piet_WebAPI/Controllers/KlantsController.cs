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
            Klant klant = db.Klants.Include("Abonnementen").Include("Abonnementen.Onderneming").Include("Abonnementen.Onderneming.Openingsuren").Include("Abonnementen.Onderneming.Adressen").Include("Abonnementen.Onderneming.Events")
                .Include("Abonnementen.Onderneming.Promoties").Include("Abonnementen.Notificaties").FirstOrDefault(geb => geb.username == username);

            if (klant == null)
            {
                return NotFound();
            }

            return Ok(klant);
        }

        // PUT: api/Klants/5
        [ResponseType(typeof(void))]
        [Route("api/Klants/Abonnement/{username}")]
        public IHttpActionResult PutAbonneeCheckKlant(string username, Onderneming onderneming)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Klant klant = db.Klants.Include("Abonnementen").FirstOrDefault(geb => geb.username == username);
            if (klant == null)
            {
                return BadRequest();
            }
            foreach (var item in klant.Abonnementen)
            {
                var abo = db.Abonnements.Include("Onderneming").FirstOrDefault(a => a.AbonnementId == item.AbonnementId);
                if (abo.Onderneming.OndenemingId == onderneming.OndenemingId)
                {
                    return StatusCode(HttpStatusCode.NoContent);
                }
            }

            return NotFound();
        }


        // PUT: api/Klants/5
        [ResponseType(typeof(void))]
        [Route("api/Klants/VoegAboToe/{username}")]
        public IHttpActionResult PutKlant(string username, Onderneming onderneming)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Klant klant = db.Klants.Include("Abonnementen").FirstOrDefault(geb => geb.username == username);
            if (klant == null)
            {
                return BadRequest();
            }
            Onderneming ondr = db.Ondernemings.Find(onderneming.OndenemingId);

            Abonnement abonnement = new Abonnement(ondr);
            klant.Abonnementen.Add(abonnement);

            db.Entry(klant).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KlantExists(klant.GebruikerId))
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


        // PUT: api/Klants/5
        [ResponseType(typeof(void))]
        [Route("api/Klants/SchrijfUit/{username}")]
        public IHttpActionResult PutSchrijfUitKlant(string username, Onderneming onderneming)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Klant klant = db.Klants.Include("Abonnementen").FirstOrDefault(geb => geb.username == username);
            if (klant == null)
            {
                return BadRequest();
            }

               foreach (var item in klant.Abonnementen)
            {
                var abo = db.Abonnements.Include("Onderneming").FirstOrDefault(a => a.AbonnementId == item.AbonnementId);
                if (abo.Onderneming.OndenemingId == onderneming.OndenemingId)
                {
                    db.Abonnements.Remove(abo);
                   
                }
                db.SaveChanges();
                return StatusCode(HttpStatusCode.NoContent);
            }


            db.Entry(klant).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KlantExists(klant.GebruikerId))
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