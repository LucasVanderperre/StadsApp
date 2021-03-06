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
    public class OndernemingsController : ApiController
    {
        private NL4_Vanderperre_Lucas_Laureyns_Piet_WebAPIContext db = new NL4_Vanderperre_Lucas_Laureyns_Piet_WebAPIContext();

        // GET: api/Ondernemings
        public IEnumerable<OndernemingList> GetOndernemings()
        {
            List<OndernemingList> ondernemingenPerCategorie = new List<OndernemingList>();
            foreach (CategorieEnum item in Enum.GetValues(typeof(CategorieEnum)).Cast<CategorieEnum>())
            {
                OndernemingList list = new OndernemingList(item);
                list.ondernemingen = db.Ondernemings.Include("Adressen").Include("Openingsuren").Include("Promoties").Include("Events").ToList().FindAll(o => o.Categorie.Equals(item));
                ondernemingenPerCategorie.Add(list);

            }
            return ondernemingenPerCategorie;
        }

        // GET: api/Ondernemings/categorie
        [HttpGet]
        [Route("api/Ondernemings/categorie/{categorie}")]
        public IHttpActionResult GetOndernemingList(string categorie)
        {
            CategorieEnum myCategorie;
            Enum.TryParse(categorie, out myCategorie);
            OndernemingList list = new OndernemingList(myCategorie)
            {
                ondernemingen = db.Ondernemings.Include("Adressen").Include("Openingsuren").Include("Promoties").Include("Events").ToList().FindAll(o => o.Categorie.Equals(myCategorie))
            };
            if (list == null)
            {
                return NotFound();
            }

            return Ok(list);
        }

        // GET: api/Ondernemings/5
        [ResponseType(typeof(Onderneming))]
        [HttpGet]
        [Route("api/Ondernemings/one/{id}")]
        public IHttpActionResult GetOnderneming(int id)
        {
            Onderneming onderneming = db.Ondernemings.Include("Adressen").Include("Openingsuren").Include("Promoties").Include("Events").ToList().FirstOrDefault(o => o.OndenemingId == id);
            if (onderneming == null)
            {
                return NotFound();
            }

            return Ok(onderneming);
        }

        // GET: api/Ondernemings/5
        [HttpGet]
        [Route("api/Ondernemings/Zoek/{naam}")]
        public IHttpActionResult GetOnderneming(string naam)
        {
            string[] zoektermen = naam.Split(' ');
            OndernemingList lijst = new OndernemingList(CategorieEnum.Winkel);
            List<Onderneming> volLijst = new List<Onderneming>();
            foreach(string item in zoektermen)
            {
                volLijst.AddRange(db.Ondernemings.Include("Adressen").Include("Openingsuren").Include("Promoties").Include("Events").ToList().FindAll(o => o.Naam.ToLower().Contains(item)));
                volLijst.AddRange(db.Ondernemings.Include("Adressen").Include("Openingsuren").Include("Promoties").Include("Events").ToList().FindAll(o => o.Soort.ToLower().Contains(item)));
            }
            lijst.ondernemingen.AddRange(volLijst.Distinct());
            if (lijst == null)
            {
                return NotFound();
            }

            return Ok(lijst);
        }


        // PUT: api/Ondernemings/5
        [ResponseType(typeof(void))]
        [HttpPut]
        [Route("api/Ondernemings/{id}")]
        public IHttpActionResult PutOnderneming(int id, Onderneming onderneming)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != onderneming.OndenemingId)
            {
                return BadRequest();
            }

            db.Entry(onderneming).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OndernemingExists(id))
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


        // POST: api/Ondernemings
        [ResponseType(typeof(Onderneming))]
        [HttpPost]
        [Route("api/Ondernemings/{ondernemerId}", Name = "postOnderneming")]
        public IHttpActionResult PostOnderneming(int ondernemerId,Onderneming onderneming)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Ondernemers.Include("Ondernemingen").FirstOrDefault(o => o.GebruikerId == ondernemerId).Ondernemingen.Add(onderneming);
            db.Ondernemings.Add(onderneming);
            db.SaveChanges();

            return CreatedAtRoute("postOnderneming", new { id = onderneming.OndenemingId }, onderneming);
        }

        // DELETE: api/Ondernemings/5
        [ResponseType(typeof(Onderneming))]
        public IHttpActionResult DeleteOnderneming(int id)
        {
            Onderneming onderneming = db.Ondernemings.Find(id);
            if (onderneming == null)
            {
                return NotFound();
            }

            db.Ondernemings.Remove(onderneming);
            db.SaveChanges();

            return Ok(onderneming);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool OndernemingExists(int id)
        {
            return db.Ondernemings.Count(e => e.OndenemingId == id) > 0;
        }
    }
}