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
    public class NhaXBController : ApiController
    {
        private DBModel db = new DBModel();

        // GET: api/NhaXB
        public IQueryable<NhaXB> GetNhaXBs()
        {
            return db.NhaXBs;
        }

        // GET: api/NhaXB/5
        [ResponseType(typeof(NhaXB))]
        public IHttpActionResult GetNhaXB(long id)
        {
            NhaXB nhaXB = db.NhaXBs.Find(id);
            if (nhaXB == null)
            {
                return NotFound();
            }

            return Ok(nhaXB);
        }

        // PUT: api/NhaXB/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutNhaXB(long id, NhaXB nhaXB)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != nhaXB.MaNXB)
            {
                return BadRequest();
            }

            db.Entry(nhaXB).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NhaXBExists(id))
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

        // POST: api/NhaXB
        [ResponseType(typeof(NhaXB))]
        public IHttpActionResult PostNhaXB(NhaXB nhaXB)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.NhaXBs.Add(nhaXB);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = nhaXB.MaNXB }, nhaXB);
        }

        // DELETE: api/NhaXB/5
        [ResponseType(typeof(NhaXB))]
        public IHttpActionResult DeleteNhaXB(long id)
        {
            NhaXB nhaXB = db.NhaXBs.Find(id);
            if (nhaXB == null)
            {
                return NotFound();
            }

            db.NhaXBs.Remove(nhaXB);
            db.SaveChanges();

            return Ok(nhaXB);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool NhaXBExists(long id)
        {
            return db.NhaXBs.Count(e => e.MaNXB == id) > 0;
        }
    }
}