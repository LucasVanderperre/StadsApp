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
    public class NotificatiesController : ApiController
    {
        private NL4_Vanderperre_Lucas_Laureyns_Piet_WebAPIContext db = new NL4_Vanderperre_Lucas_Laureyns_Piet_WebAPIContext();

        // GET: api/Notificaties
        public IQueryable<Notificatie> GetNotificaties()
        {
            return db.Notificaties;
        }

        // GET: api/Notificaties/5
        [ResponseType(typeof(Notificatie))]
        public IHttpActionResult GetNotificatie(int id)
        {
            Notificatie notificatie = db.Notificaties.Find(id);
            if (notificatie == null)
            {
                return NotFound();
            }

            return Ok(notificatie);
        }

        // PUT: api/Notificaties/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutNotificatie(int id, Notificatie notificatie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != notificatie.NotificatieId)
            {
                return BadRequest();
            }

            db.Entry(notificatie).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NotificatieExists(id))
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

        // POST: api/Notificaties
        [ResponseType(typeof(Notificatie))]
        public IHttpActionResult PostNotificatie(Notificatie notificatie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Notificaties.Add(notificatie);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = notificatie.NotificatieId }, notificatie);
        }

        // DELETE: api/Notificaties/5
        [ResponseType(typeof(Notificatie))]
        public IHttpActionResult DeleteNotificatie(int id)
        {
            Notificatie notificatie = db.Notificaties.Find(id);
            if (notificatie == null)
            {
                return NotFound();
            }

            db.Notificaties.Remove(notificatie);
            db.SaveChanges();

            return Ok(notificatie);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool NotificatieExists(int id)
        {
            return db.Notificaties.Count(e => e.NotificatieId == id) > 0;
        }
    }
}