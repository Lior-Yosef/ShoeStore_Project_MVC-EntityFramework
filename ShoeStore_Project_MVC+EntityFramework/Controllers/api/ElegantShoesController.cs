using ShoeStore_Project_MVC_EntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
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
        public async Task <IHttpActionResult> Get(int id)
        {
            try
            {
                ElegantShoes elegant = await db.ElegantShoes.FindAsync(id);
                return Ok(elegant);
            }
            catch (sqlException ex) { return BadRequest(ex.Message); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        // POST: api/ElegantShoes
        public async Task <IHttpActionResult> Post([FromBody] ElegantShoes elegantshoes)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                db.ElegantShoes.Add(elegantshoes);
                await db.SaveChangesAsync();
                return Ok("add success");
            }
            catch (sqlException ex) { return BadRequest(ex.Message); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        

        // PUT: api/ElegantShoes/5
        public async Task <IHttpActionResult> Put(int id, [FromBody] ElegantShoes elegantshoes)
        {
            try
            {
                ElegantShoes shoesToUpdate = await db.ElegantShoes.FindAsync(id);
                shoesToUpdate.CompanyName = elegantshoes.CompanyName;
                    shoesToUpdate.Gender = elegantshoes.Gender;
                    shoesToUpdate.hasHeel = elegantshoes.hasHeel;
                    shoesToUpdate.inStock = elegantshoes.inStock;
                    shoesToUpdate.size = elegantshoes.size;
                    shoesToUpdate.price = elegantshoes.price;
                    await db.SaveChangesAsync();
                    return Ok("Update success");
            }
            catch (sqlException ex) { return BadRequest(ex.Message); }
            catch (Exception ex) { return BadRequest(ex.Message); }


        }

        // DELETE: api/ElegantShoes/5
        public async Task<IHttpActionResult> Delete(int id)
        {
            try
            {
                ElegantShoes shoesRemove = await db.ElegantShoes.FindAsync(id);
                db.ElegantShoes.Remove(shoesRemove);
                await db.SaveChangesAsync();
                return Ok("Remove success");
            }
            catch (sqlException ex) { return BadRequest(ex.Message); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }
    }
}
