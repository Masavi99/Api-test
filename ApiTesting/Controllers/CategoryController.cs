using ApiTesting.EF;
using ApiTesting.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiTesting.Controllers
{
    public class CategoryController : ApiController
    {
       
        [HttpPost]
        [Route("api/Category/Create")]
        public HttpResponseMessage Create(Category c)
        {
            var db = new ApiContext();
            

            try
            {
                db.Categories.Add(c);
                db.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Created" });

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }

        }

    
        [HttpGet]
        [Route("api/category/{id}")]
        public HttpResponseMessage Get(int id)
        {
            var db = new ApiContext();
            var data = db.Categories.Find(id);
   
         

            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [HttpPut]
        [Route("api/category/update")]
        public HttpResponseMessage Edit(Category c)
        {
            var db = new ApiContext();
            var exp = db.Categories.Find(c.Id);

            exp.Name = c.Name;
           


            try
            {
                db.Categories.Add(c);
                db.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Updated" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError,ex.Message);
            }

        }
        [HttpDelete]
        [Route("api/category/delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            var db = new ApiContext();
            var exp = db.Categories.Find(id);
           
            try
            {
                db.Categories.Remove(exp);
                db.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Removed Succesfully" });
            }
            catch(Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        [HttpGet]
        [Route("api/Category/all")]
        public HttpResponseMessage all()
        {
            var db = new ApiContext();
            var index=db.Categories.ToList();
            return Request.CreateResponse(HttpStatusCode.OK,index);

        }
        [HttpGet]
        [Route("api/news/name/{name}")]
        public HttpResponseMessage Get(string name)
        {
            var db = new ApiContext();
            var data = (from p in db.Categories
                        where p.Name.Contains(name)
                        select p).ToList();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
    }

    
}
