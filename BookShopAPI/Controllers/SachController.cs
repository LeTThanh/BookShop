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
    public class SachController : ApiController
    {
        private DBModel db = new DBModel();

        // GET: api/Sach
        public IQueryable<Sach> GetSaches()
        {
            return db.Saches;
        }

        // GET: api/Sach/5
        [ResponseType(typeof(Sach))]
        public IHttpActionResult GetSach(long id)
        {
            Sach sach = db.Saches.Find(id);
            if (sach == null)
            {
                return NotFound();
            }

            return Ok(sach);
        }

        // PUT: api/Sach/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSach(long id, Sach sach)
        {


            if (id != sach.MaSach)
            {
                return BadRequest();
            }

            db.Entry(sach).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SachExists(id))
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

        // POST: api/Sach
        [ResponseType(typeof(Sach))]
        public IHttpActionResult PostSach(Sach sach)
        {


            db.Saches.Add(sach);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = sach.MaSach }, sach);
        }

        // DELETE: api/Sach/5
        [ResponseType(typeof(Sach))]
        public IHttpActionResult DeleteSach(long id)
        {
            Sach sach = db.Saches.Find(id);
            if (sach == null)
            {
                return NotFound();
            }

            db.Saches.Remove(sach);
            db.SaveChanges();

            return Ok(sach);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SachExists(long id)
        {
            return db.Saches.Count(e => e.MaSach == id) > 0;
        }
    }
}