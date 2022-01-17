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
                using(SqlConnection conn = new SqlConnection(connctionString))
                {
                    conn.Open();

                    string query = $@"SELECT * FROM SportShoes WHERE Id={id}";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader DataFromDB = cmd.ExecuteReader();
                    if (DataFromDB.HasRows)
                    {
                        while (DataFromDB.Read())
                        {
                            SportShoe objectSportShoe = new SportShoe(DataFromDB.GetInt32(0), DataFromDB.GetString(1), DataFromDB.GetString(2), DataFromDB.GetInt32(3), DataFromDB.GetInt32(4));
                            conn.Close();
                            return Ok(objectSportShoe);
                        }
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
            return Ok();
        }

        // POST: api/SportShoes
        public IHttpActionResult Post([FromBody] SportShoe value)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connctionString))
                {
                    conn.Open();
                    string query = $@"INSERT INTO SportShoes
                                    VALUES( '{value.CompanyName}','{value.ModelName}','{value.Size}','{value.Price}')";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    int row = cmd.ExecuteNonQuery();
                    return Get();
                }
            }
            catch (SqlException ex) { return BadRequest(ex.Message); }

            catch (Exception ex) { return BadRequest(ex.Message); }

        }

        // PUT: api/SportShoes/5
        public IHttpActionResult Put(int id, [FromBody] SportShoe value)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connctionString))
                {
                    conn.Open();
                    string Putquery = $@"UPDATE SportShoes
                                        SET CompanyName='{value.CompanyName}',ModelName='{value.ModelName}',Size='{value.Size}',Price='{value.Price}'
                                         WHERE Id={id}";
                    SqlCommand cmd = new SqlCommand(Putquery, conn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    conn.Close();
                    return Ok(Get());

                }

            }
            catch (SqlException ex) { return BadRequest(ex.Message); }

            catch (Exception ex) { return BadRequest(ex.Message); }


        }

        // DELETE: api/SportShoes/5
        public void Delete(int id)
        {
        }
    }
}
