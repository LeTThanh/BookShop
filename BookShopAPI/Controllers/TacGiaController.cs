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
    public class TacGiaController : ApiController
    {
        private DBModel db = new DBModel();

        // GET: api/TacGia
        public IQueryable<TacGia> GetTacGias()
        {
            return db.TacGias;
        }

        // GET: api/TacGia/5
        [ResponseType(typeof(TacGia))]
        public IHttpActionResult GetTacGia(long id)
        {
            TacGia tacGia = db.TacGias.Find(id);
            if (tacGia == null)
            {
                return NotFound();
            }

            return Ok(tacGia);
        }

        // PUT: api/TacGia/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTacGia(long id, TacGia tacGia)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tacGia.MaTG)
            {
                return BadRequest();
            }

            db.Entry(tacGia).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TacGiaExists(id))
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

        // POST: api/TacGia
        [ResponseType(typeof(TacGia))]
        public IHttpActionResult PostTacGia(TacGia tacGia)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TacGias.Add(tacGia);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tacGia.MaTG }, tacGia);
        }

        // DELETE: api/TacGia/5
        [ResponseType(typeof(TacGia))]
        public IHttpActionResult DeleteTacGia(long id)
        {
            TacGia tacGia = db.TacGias.Find(id);
            if (tacGia == null)
            {
                return NotFound();
            }

            db.TacGias.Remove(tacGia);
            db.SaveChanges();

            return Ok(tacGia);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TacGiaExists(long id)
        {
            return db.TacGias.Count(e => e.MaTG == id) > 0;
        }
    }
}