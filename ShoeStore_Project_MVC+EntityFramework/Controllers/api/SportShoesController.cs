using ShoeStore_Project_MVC_EntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ShoeStore_Project_MVC_EntityFramework.Controllers.api
{
    public class SportShoesController : ApiController
    {
        string connctionString = "Data Source=LAPTOP-OT5IVM7S;Initial Catalog=ShoeStore;Integrated Security=True;Pooling=False;MultipleActiveResultSets=True;Application Name=EntityFramework"; 

        // GET: api/SportShoes
        public IHttpActionResult Get()
        {
            try
            {
                List<SportShoe> listSportShoe = new List<SportShoe>();
                using (SqlConnection conn = new SqlConnection(connctionString))
                {
                    conn.Open();
                    string query = @"SELECT * FROM SportShoes";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader DataFromDB = cmd.ExecuteReader();
                    if (DataFromDB.HasRows)
                    {
                        while (DataFromDB.Read())
                        {
                            listSportShoe.Add(new SportShoe(DataFromDB.GetInt32(0),DataFromDB.GetString(1), DataFromDB.GetString(2), DataFromDB.GetInt32(3), DataFromDB.GetInt32(4)));
                        }
                        conn.Close();
                        return Ok(new {listSportShoe});
                    }
                    else
                    {
                        string respons = "not found";
                        conn.Close();
                        return Ok(new { respons });
                    }
                }
            }
            catch (SqlException ex) { return BadRequest(ex.Message); }

            catch (Exception ex) { return BadRequest(ex.Message); }

        }

        // GET: api/SportShoes/5
        public IHttpActionResult Get(int id)
        {
            try
            {

                return Ok();
            }
            catch (SqlException ex) { return BadRequest(ex.Message); }

            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        // POST: api/SportShoes
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/SportShoes/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/SportShoes/5
        public void Delete(int id)
        {
        }
    }
}
