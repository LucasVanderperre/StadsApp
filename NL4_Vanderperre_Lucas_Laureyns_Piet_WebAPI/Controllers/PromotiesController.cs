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
        [Route("api/Promoties/{OndernemingId}")]
        public IHttpActionResult PostPromotie(Promotie promotie, int OndernemingId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            db.Ondernemings.Include("Promoties").FirstOrDefault(o => o.OndenemingId == OndernemingId).Promoties.Add(promotie);
            db.Promoties.Add(promotie);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = promotie.PromotieId }, promotie);
        }

        // DELETE: api/Promoties/5
        [ResponseType(typeof(Promotie))]
        public IHttpActionResult DeletePromotie(int id)
        {
            Promotie promotie = db.Promoties.Find(id);
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