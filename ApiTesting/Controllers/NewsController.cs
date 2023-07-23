using ApiTesting.EF.Models;
using ApiTesting.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;

namespace ApiTesting.Controllers
{
    public class NewsController : ApiController
    {
        [HttpPost]
        [Route("api/news/create")]
        public HttpResponseMessage Create(News n)
        {
            var db = new ApiContext();

            n.Date = DateTime.Now.Date;
            try
            {
                db.Newslist.Add(n);
                db.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Created" });

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }

        }

        [HttpGet]
        [Route("api/news/{id}")]
        public HttpResponseMessage Get(int id)
        {
            var db = new ApiContext();
            var data = db.Newslist.Find(id);


            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [HttpPut]
        [Route("api/news/update")]
        public HttpResponseMessage Edit(News n)
        {
            var db = new ApiContext();
            var exp = db.Newslist.Find(n.Id);


            exp.Cat_Id = n.Cat_Id;
            exp.Title = n.Title;
            exp.Description = n.Description;
            n.Date = DateTime.Now;




            try
            {
                db.Newslist.Add(n);
                db.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Updated" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }

        }
        [HttpDelete]
        [Route("api/news/delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            var db = new ApiContext();
            var exp = db.Newslist.Find(id);

            try
            {
                db.Newslist.Remove(exp);
                db.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Removed Succesfully" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        [HttpGet]
        [Route("api/news/all")]
        public HttpResponseMessage all()
        {
            var db = new ApiContext();
            var index = db.Newslist.ToList();
            return Request.CreateResponse(HttpStatusCode.OK, index);

        }
        [HttpGet]
        [Route("api/news/title/{title}")]
        public HttpResponseMessage Get(string title)
        {
            var db = new ApiContext();
            var data = (from p in db.Newslist
                        where p.Title.Contains(title)
                        select p).ToList();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        // feature



        [HttpGet]
        [Route("api/news/category/{name}")]
        public HttpResponseMessage GetbyCatname(string name)
        {
            var db = new ApiContext();
            var data=(from i in db.Categories
                      where i.Name.Equals(name)
                      select i.Newslist).ToList();  
            //var db = new ApiContext();
            //var data=(from c in db.Categories
            //          where c.Name.Equals(cn)   
            //          select c.Newslist).ToList();
         

            return Request.CreateResponse(HttpStatusCode.OK, data);

        }




        [HttpGet]
        [Route("api/news/date/{date}")]
        public HttpResponseMessage Get(DateTime date)
        {

            var db = new ApiContext();
            var data = (from dt in db.Newslist
                        where dt.Date==date
                        select dt).ToList();

            return Request.CreateResponse(HttpStatusCode.OK, data);

        }

        [HttpGet]
        [Route("api/news/date/category/{date}/{name}")]
        public HttpResponseMessage Getbycatdate(DateTime date ,string name)
        {
            var db = new ApiContext();
            var data =(from d in db.Newslist
                       where d.Category.Name.Equals(name) && d.Date.Equals(date)
                       select d).ToList();

            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
    }
}


