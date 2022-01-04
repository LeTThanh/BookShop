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
using BookShopAPI.Models;

namespace BookShopAPI.Controllers
{
    public class TinTucController : ApiController
    {
        private DBModel db = new DBModel();

        // GET: api/TinTuc
        public IQueryable<TinTuc> GetTinTucs()
        {
            return db.TinTucs;
        }

        // GET: api/TinTuc/5
        [ResponseType(typeof(TinTuc))]
        public IHttpActionResult GetTinTuc(long id)
        {
            TinTuc tinTuc = db.TinTucs.Find(id);
            if (tinTuc == null)
            {
                return NotFound();
            }

            return Ok(tinTuc);
        }

        // PUT: api/TinTuc/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTinTuc(long id, TinTuc tinTuc)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tinTuc.MaTinTuc)
            {
                return BadRequest();
            }

            db.Entry(tinTuc).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TinTucExists(id))
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

        // POST: api/TinTuc
        [ResponseType(typeof(TinTuc))]
        public IHttpActionResult PostTinTuc(TinTuc tinTuc)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TinTucs.Add(tinTuc);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tinTuc.MaTinTuc }, tinTuc);
        }

        // DELETE: api/TinTuc/5
        [ResponseType(typeof(TinTuc))]
        public IHttpActionResult DeleteTinTuc(long id)
        {
            TinTuc tinTuc = db.TinTucs.Find(id);
            if (tinTuc == null)
            {
                return NotFound();
            }

            db.TinTucs.Remove(tinTuc);
            db.SaveChanges();

            return Ok(tinTuc);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TinTucExists(long id)
        {
            return db.TinTucs.Count(e => e.MaTinTuc == id) > 0;
        }
    }
}