using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using wpfAPI.Models;

namespace wpfAPI.Controllers
{
    public class ThingsController : ApiController
    {
        private wpfAPIContext db = new wpfAPIContext();

        // GET: api/Things
        public IQueryable<Things> GetThings()
        {
            return db.Things;
        }

        // GET: api/Things/5
        [ResponseType(typeof(Things))]
        public async Task<IHttpActionResult> GetThings(int id)
        {
            Things things = await db.Things.FindAsync(id);
            if (things == null)
            {
                return NotFound();
            }

            return Ok(things);
        }

        // PUT: api/Things/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutThings(int id, Things things)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != things.ThingID)
            {
                return BadRequest();
            }

            db.Entry(things).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ThingsExists(id))
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

        // POST: api/Things
        [ResponseType(typeof(Things))]
        public async Task<IHttpActionResult> PostThings(Things things)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Things.Add(things);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = things.ThingID }, things);
        }

        // DELETE: api/Things/5
        [ResponseType(typeof(Things))]
        public async Task<IHttpActionResult> DeleteThings(int id)
        {
            Things things = await db.Things.FindAsync(id);
            if (things == null)
            {
                return NotFound();
            }

            db.Things.Remove(things);
            await db.SaveChangesAsync();

            return Ok(things);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ThingsExists(int id)
        {
            return db.Things.Count(e => e.ThingID == id) > 0;
        }
    }
}