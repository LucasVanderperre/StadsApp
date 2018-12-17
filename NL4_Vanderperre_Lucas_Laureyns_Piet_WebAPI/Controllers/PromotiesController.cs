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
    public class PromotiesController : ApiController
    {
        private NL4_Vanderperre_Lucas_Laureyns_Piet_WebAPIContext db = new NL4_Vanderperre_Lucas_Laureyns_Piet_WebAPIContext();

        // GET: api/Promoties
        public IQueryable<Promotie> GetPromoties()
        {
            return db.Promoties;
        }

        // GET: api/Promoties/5
        [ResponseType(typeof(Promotie))]
        public IHttpActionResult GetPromotie(int id)
        {
            Promotie promotie = db.Promoties.Find(id);
            if (promotie == null)
            {
                return NotFound();
            }

            return Ok(promotie);
        }

        // PUT: api/Promoties/5
        [ResponseType(typeof(void))]
        [HttpPut]
        [Route("api/Promoties/{id}")]
        public IHttpActionResult PutPromotie(int id, Promotie promotie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != promotie.PromotieId)
            {
                return BadRequest();
            }

            db.Entry(promotie).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PromotieExists(id))
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


        // POST: api/Promoties
        [ResponseType(typeof(Promotie))]
        [HttpPost]
        [Route("api/Promoties/{OndernemingId}", Name = "postPromotie")]
        public IHttpActionResult PostPromotie(Promotie promotie, int OndernemingId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            db.Ondernemings.Include("Promoties").FirstOrDefault(o => o.OndenemingId == OndernemingId).Promoties.Add(promotie);
            db.Promoties.Add(promotie);
            db.SaveChanges();

            var abo = db.Abonnements.Include("Onderneming").ToList().FindAll(a => a.Onderneming.OndenemingId == OndernemingId);
            var ondr = db.Ondernemings.FirstOrDefault(o => o.OndenemingId == OndernemingId);

            foreach (var item in abo)
            {
                Notificatie notificatie = new Notificatie();
                notificatie.Titel = (ondr.Naam + " heeft een nieuw promotie toegevoegd: " + promotie.Naam);
                notificatie.Toegevoegd = DateTime.Now;
                notificatie.StartDatum = promotie.Startdatum;
                db.Notificaties.Add(notificatie);
                item.Notificaties.Add(notificatie);
            }
            db.SaveChanges();

            return CreatedAtRoute("postPromotie", new { id = promotie.PromotieId }, promotie);
        }

        // DELETE: api/Promoties/5
        [ResponseType(typeof(Promotie))]
        [HttpDelete]
        [Route("api/Promoties/{promotieId}")]
        public IHttpActionResult DeletePromotie(int promotieId)
        {
            Promotie promotie = db.Promoties.Find(promotieId);
            if (promotie == null)
            {
                return NotFound();
            }

            db.Promoties.Remove(promotie);
            db.SaveChanges();

            return Ok(promotie);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PromotieExists(int id)
        {
            return db.Promoties.Count(e => e.PromotieId == id) > 0;
        }
    }
}