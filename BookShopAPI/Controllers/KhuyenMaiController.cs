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
    public class KhuyenMaiController : ApiController
    {
        private DBModel db = new DBModel();

        // GET: api/KhuyenMai
        public IQueryable<KhuyenMai> GetKhuyenMais()
        {
            return db.KhuyenMais;
        }

        // GET: api/KhuyenMai/5
        [ResponseType(typeof(KhuyenMai))]
        public IHttpActionResult GetKhuyenMai(long id)
        {
            KhuyenMai khuyenMai = db.KhuyenMais.Find(id);
            if (khuyenMai == null)
            {
                return NotFound();
            }

            return Ok(khuyenMai);
        }

        // PUT: api/KhuyenMai/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutKhuyenMai(long id, KhuyenMai khuyenMai)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != khuyenMai.MaKM)
            {
                return BadRequest();
            }

            db.Entry(khuyenMai).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KhuyenMaiExists(id))
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

        // POST: api/KhuyenMai
        [ResponseType(typeof(KhuyenMai))]
        public IHttpActionResult PostKhuyenMai(KhuyenMai khuyenMai)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.KhuyenMais.Add(khuyenMai);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = khuyenMai.MaKM }, khuyenMai);
        }

        // DELETE: api/KhuyenMai/5
        [ResponseType(typeof(KhuyenMai))]
        public IHttpActionResult DeleteKhuyenMai(long id)
        {
            KhuyenMai khuyenMai = db.KhuyenMais.Find(id);
            if (khuyenMai == null)
            {
                return NotFound();
            }

            db.KhuyenMais.Remove(khuyenMai);
            db.SaveChanges();

            return Ok(khuyenMai);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool KhuyenMaiExists(long id)
        {
            return db.KhuyenMais.Count(e => e.MaKM == id) > 0;
        }
    }
}