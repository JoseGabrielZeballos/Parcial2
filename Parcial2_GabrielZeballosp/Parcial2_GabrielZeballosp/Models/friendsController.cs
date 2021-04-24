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

namespace Parcial2_GabrielZeballosp.Models
{
    public class friendsController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/friends
        public IQueryable<friend> Getfriends()
        {
            return db.friends;
        }

        // GET: api/friends/5
        [ResponseType(typeof(friend))]
        public IHttpActionResult Getfriend(int id)
        {
            friend friend = db.friends.Find(id);
            if (friend == null)
            {
                return NotFound();
            }

            return Ok(friend);
        }

        // PUT: api/friends/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putfriend(int id, friend friend)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != friend.FriendID)
            {
                return BadRequest();
            }

            db.Entry(friend).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!friendExists(id))
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

        // POST: api/friends
        [ResponseType(typeof(friend))]
        public IHttpActionResult Postfriend(friend friend)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.friends.Add(friend);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = friend.FriendID }, friend);
        }

        // DELETE: api/friends/5
        [ResponseType(typeof(friend))]
        public IHttpActionResult Deletefriend(int id)
        {
            friend friend = db.friends.Find(id);
            if (friend == null)
            {
                return NotFound();
            }

            db.friends.Remove(friend);
            db.SaveChanges();

            return Ok(friend);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool friendExists(int id)
        {
            return db.friends.Count(e => e.FriendID == id) > 0;
        }
    }
}