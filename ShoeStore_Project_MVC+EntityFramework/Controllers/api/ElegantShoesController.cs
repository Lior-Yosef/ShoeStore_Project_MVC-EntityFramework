using ShoeStore_Project_MVC_EntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ShoeStore_Project_MVC_EntityFramework.Controllers
{
    public class ElegantShoesController : ApiController
    {
        ShoeStoreDataContext db = new ShoeStoreDataContext();
        // GET: api/ElegantShoes
        public IHttpActionResult Get()
        {
            try
            {
                return Ok(db.ElegantShoes.ToList());

            }
            catch (sqlException ex) { return BadRequest(ex.Message); }
            catch (Exception ex) { return BadRequest(ex.Message); }

        }

        // GET: api/ElegantShoes/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/ElegantShoes
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/ElegantShoes/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ElegantShoes/5
        public void Delete(int id)
        {
        }
    }
}
