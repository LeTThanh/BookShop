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
    public class NhomTKController : ApiController
    {
        private DBModel db = new DBModel();

        // GET: api/NhomTK
        public IQueryable<NhomTK> GetNhomTKs()
        {
            return db.NhomTKs;
        }

        // GET: api/NhomTK/5
        [ResponseType(typeof(NhomTK))]
        public IHttpActionResult GetNhomTK(long id)
        {
            NhomTK nhomTK = db.NhomTKs.Find(id);
            if (nhomTK == null)
            {
                return NotFound();
            }

            return Ok(nhomTK);
        }

        // PUT: api/NhomTK/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutNhomTK(long id, NhomTK nhomTK)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != nhomTK.MaNhomTK)
            {
                return BadRequest();
            }

            db.Entry(nhomTK).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NhomTKExists(id))
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

        // POST: api/NhomTK
        [ResponseType(typeof(NhomTK))]
        public IHttpActionResult PostNhomTK(NhomTK nhomTK)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.NhomTKs.Add(nhomTK);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = nhomTK.MaNhomTK }, nhomTK);
        }

        // DELETE: api/NhomTK/5
        [ResponseType(typeof(NhomTK))]
        public IHttpActionResult DeleteNhomTK(long id)
        {
            NhomTK nhomTK = db.NhomTKs.Find(id);
            if (nhomTK == null)
            {
                return NotFound();
            }

            db.NhomTKs.Remove(nhomTK);
            db.SaveChanges();

            return Ok(nhomTK);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool NhomTKExists(long id)
        {
            return db.NhomTKs.Count(e => e.MaNhomTK == id) > 0;
        }
    }
}