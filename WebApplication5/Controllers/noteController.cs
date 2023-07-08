using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{
    [RoutePrefix("api/note")]
    public class noteController : ApiController
    {
        notebookEntities1 db = new notebookEntities1();
        [HttpPost]
        [Route("save/obj")]

        public IHttpActionResult post (Table_1 obj)
        {
            try 
            {
                db.Table_1.Add(obj);
                db.SaveChanges();
            }catch (Exception) 
            {
                throw;
            }
            return Ok("saved");
        }
        [HttpGet]
        [Route("Getdata")]

        public IEnumerable<Table_1> Getdata() 
        {
            var t1 = db.Table_1.ToList();
            return t1;
        }
        [HttpDelete]
        [Route("delete/{id}")]
        public IHttpActionResult deletenotebook1(int id) 
        {
        var emp = db.Table_1.Find(id);
            if (emp == null) 
            {
                return NotFound();
            }
            db.Table_1.Remove(emp);
            db.SaveChanges();
            return Ok("record deleted");
        }
    }
}
