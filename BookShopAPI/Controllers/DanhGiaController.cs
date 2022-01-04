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
    public class DanhGiaController : ApiController
    {
        private DBModel db = new DBModel();

        // GET: api/DanhGia
        public IQueryable<DanhGia> GetDanhGias()
        {
            return db.DanhGias;
        }

        // GET: api/DanhGia/5
        [ResponseType(typeof(DanhGia))]
        public IHttpActionResult GetDanhGia(long id)
        {
            DanhGia danhGia = db.DanhGias.Find(id);
            if (danhGia == null)
            {
                return NotFound();
            }

            return Ok(danhGia);
        }

        // PUT: api/DanhGia/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDanhGia(long id, DanhGia danhGia)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != danhGia.MaDanhGia)
            {
                return BadRequest();
            }

            db.Entry(danhGia).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DanhGiaExists(id))
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

        // POST: api/DanhGia
        [ResponseType(typeof(DanhGia))]
        public IHttpActionResult PostDanhGia(DanhGia danhGia)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DanhGias.Add(danhGia);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = danhGia.MaDanhGia }, danhGia);
        }

        // DELETE: api/DanhGia/5
        [ResponseType(typeof(DanhGia))]
        public IHttpActionResult DeleteDanhGia(long id)
        {
            DanhGia danhGia = db.DanhGias.Find(id);
            if (danhGia == null)
            {
                return NotFound();
            }

            db.DanhGias.Remove(danhGia);
            db.SaveChanges();

            return Ok(danhGia);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DanhGiaExists(long id)
        {
            return db.DanhGias.Count(e => e.MaDanhGia == id) > 0;
        }
    }
}