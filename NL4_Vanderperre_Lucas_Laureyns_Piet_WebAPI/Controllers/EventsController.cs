﻿using System;
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
    public class EventsController : ApiController
    {
        private NL4_Vanderperre_Lucas_Laureyns_Piet_WebAPIContext db = new NL4_Vanderperre_Lucas_Laureyns_Piet_WebAPIContext();

        // GET: api/Events
        public IQueryable<Event> GetEvents()
        {
            return db.Events;
        }

        // GET: api/Events/5
        [ResponseType(typeof(Event))]
        public IHttpActionResult GetEvent(int id)
        {
            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return NotFound();
            }

            return Ok(@event);
        }

        // PUT: api/Events/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEvent(int id, Event @event)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != @event.EventId)
            {
                return BadRequest();
            }

            db.Entry(@event).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventExists(id))
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

        // POST: api/Events
        [ResponseType(typeof(Event))]
        [HttpPost]
        [Route("api/Events/{OndernemingId}")]
        public IHttpActionResult PostEvent(Event @event, int OndernemingId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            db.Ondernemings.Include("Events").FirstOrDefault(o => o.OndenemingId == OndernemingId).Events.Add(@event);
            db.Events.Add(@event);
            db.SaveChanges();

            var abo = db.Abonnements.Include("Onderneming").ToList().FindAll(a => a.Onderneming.OndenemingId == OndernemingId);
            var ondr = db.Ondernemings.FirstOrDefault(o => o.OndenemingId == OndernemingId);

            foreach (var item in abo)
            {
                Notificatie notificatie = new Notificatie();
                notificatie.Titel = (ondr.Naam + " heeft een nieuw evenement toegevoegd: " + @event.Naam);
                notificatie.Toegevoegd = DateTime.Now;
                notificatie.StartDatum = @event.Startdatum;
                db.Notificaties.Add(notificatie);

                item.Notificaties.Add(notificatie);
            }
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = @event.EventId }, @event);
        }

        // DELETE: api/Events/5
        [ResponseType(typeof(Event))]
        public IHttpActionResult DeleteEvent(int id)
        {
            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return NotFound();
            }

            db.Events.Remove(@event);
            db.SaveChanges();

            return Ok(@event);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EventExists(int id)
        {
            return db.Events.Count(e => e.EventId == id) > 0;
        }
    }
}