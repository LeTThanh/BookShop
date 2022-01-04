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
    public class DonHangController : ApiController
    {
        private DBModel db = new DBModel();

        // GET: api/DonHang
        public IQueryable<DonHang> GetDonHangs()
        {
            return db.DonHangs;
        }

        // GET: api/DonHang/5
        [ResponseType(typeof(DonHang))]
        public IHttpActionResult GetDonHang(long id)
        {
            DonHang donHang = db.DonHangs.Find(id);
            if (donHang == null)
            {
                return NotFound();
            }

            return Ok(donHang);
        }

        // PUT: api/DonHang/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDonHang(long id, DonHang donHang)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != donHang.MaDH)
            {
                return BadRequest();
            }

            db.Entry(donHang).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DonHangExists(id))
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

        // POST: api/DonHang
        [ResponseType(typeof(DonHang))]
        public IHttpActionResult PostDonHang(DonHang donHang)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DonHangs.Add(donHang);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = donHang.MaDH }, donHang);
        }

        // DELETE: api/DonHang/5
        [ResponseType(typeof(DonHang))]
        public IHttpActionResult DeleteDonHang(long id)
        {
            DonHang donHang = db.DonHangs.Find(id);
            if (donHang == null)
            {
                return NotFound();
            }

            db.DonHangs.Remove(donHang);
            db.SaveChanges();

            return Ok(donHang);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DonHangExists(long id)
        {
            return db.DonHangs.Count(e => e.MaDH == id) > 0;
        }
    }
}