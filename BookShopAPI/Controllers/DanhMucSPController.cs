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
    public class DanhMucSPController : ApiController
    {
        private DBModel db = new DBModel();

        // GET: api/DanhMucSP
        public IQueryable<DanhMucSP> GetDanhMucSPs()
        {
            return db.DanhMucSPs;
        }

        // GET: api/DanhMucSP/5
        [ResponseType(typeof(DanhMucSP))]
        public IHttpActionResult GetDanhMucSP(long id)
        {
            DanhMucSP danhMucSP = db.DanhMucSPs.Find(id);
            if (danhMucSP == null)
            {
                return NotFound();
            }

            return Ok(danhMucSP);
        }

        // PUT: api/DanhMucSP/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDanhMucSP(long id, DanhMucSP danhMucSP)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != danhMucSP.MaDM)
            {
                return BadRequest();
            }

            db.Entry(danhMucSP).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DanhMucSPExists(id))
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

        // POST: api/DanhMucSP
        [ResponseType(typeof(DanhMucSP))]
        public IHttpActionResult PostDanhMucSP(DanhMucSP danhMucSP)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DanhMucSPs.Add(danhMucSP);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = danhMucSP.MaDM }, danhMucSP);
        }

        // DELETE: api/DanhMucSP/5
        [ResponseType(typeof(DanhMucSP))]
        public IHttpActionResult DeleteDanhMucSP(long id)
        {
            DanhMucSP danhMucSP = db.DanhMucSPs.Find(id);
            if (danhMucSP == null)
            {
                return NotFound();
            }

            db.DanhMucSPs.Remove(danhMucSP);
            db.SaveChanges();

            return Ok(danhMucSP);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DanhMucSPExists(long id)
        {
            return db.DanhMucSPs.Count(e => e.MaDM == id) > 0;
        }
    }
}