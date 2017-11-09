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
using DbContext;
using WA_UNAM_NB_PR.DbContextUnam;

namespace WA_UNAM_NB_PR.Controllers.Services
{
    [Authorize]
    public class LibrosController : ApiController
    {
        private DBUploadFileContext db = new DBUploadFileContext();

        // GET: api/Libros
        public IQueryable<Libro> GetLibro()
        {
            return db.Libro;
        }

        // GET: api/Libros/5
        [ResponseType(typeof(Libro))]
        public IHttpActionResult GetLibro(int id)
        {
            Libro libro = db.Libro.Find(id);
            if (libro == null)
            {
                return NotFound();
            }

            return Ok(libro);
        }

        // PUT: api/Libros/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLibro(int id, Libro libro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != libro.PK_IdLibro)
            {
                return BadRequest();
            }

            db.Entry(libro).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LibroExists(id))
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

        // POST: api/Libros
        [ResponseType(typeof(Libro))]
        public IHttpActionResult PostLibro(Libro libro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Libro.Add(libro);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = libro.PK_IdLibro }, libro);
        }

        // DELETE: api/Libros/5
        [ResponseType(typeof(Libro))]
        public IHttpActionResult DeleteLibro(int id)
        {
            Libro libro = db.Libro.Find(id);
            if (libro == null)
            {
                return NotFound();
            }

            db.Libro.Remove(libro);
            db.SaveChanges();

            return Ok(libro);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LibroExists(int id)
        {
            return db.Libro.Count(e => e.PK_IdLibro == id) > 0;
        }






        [Route("api/libros/fecha")]
        [ResponseType(typeof(Libro))]
        public IHttpActionResult GetLibroFecha([FromUri]DateTime fecha)
        {
            
            Libro libro = db.Libro.Where(x => x.FechaAdquisicion == fecha).FirstOrDefault();
            if (libro == null)
            {
                return NotFound();
            }

            return Ok(libro);
        }
    }
}