using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL.Services;
using BLL.Interfaces;
using AutoMapper;
using WebSchedule.Models;

namespace WebSchedule.Controllers
{
    [Authorize(Roles = "Admin")]
    [RoutePrefix("api/lesson")]
    public class LessonController : ApiController
    {
        [HttpGet]
        [Route("")]
        // GET: api/lesson
        public IEnumerable<LessonViewModel> Get()
        {
            List<LessonViewModel> list = new List<LessonViewModel>();
            using (ILessonService ls = new LessonService(WebApiApplication.connection))
            {
                list = Mapper.Map<List<LessonViewModel>>(ls.GetAll());
            }
            return list;
        }

        [HttpGet]
        [Route("{id:int}")]
        // GET: api/lesson/5
        public LessonViewModel Get(int id)
        {
            LessonViewModel group = new LessonViewModel();
            using (ILessonService ls = new LessonService(WebApiApplication.connection))
            {
                group = Mapper.Map<LessonViewModel>(ls.Get(id));
            }
            return group;
        }

        [HttpPost]
        [Route("")]
        // POST: api/lesson
        public HttpResponseMessage Post([FromBody]Lesson value)
        {
            HttpResponseMessage msg = new HttpResponseMessage(HttpStatusCode.Conflict);
            using (ILessonService ls = new LessonService(WebApiApplication.connection))
            {
                ls.Add(Mapper.Map<BLL.Objects.Lesson>(value));
                msg.StatusCode = HttpStatusCode.OK;
            }
            return msg;
        }

        [HttpPut]
        [Route("{id:int}")]
        // PUT: api/lesson/5
        public HttpResponseMessage Put(int id, [FromBody]Lesson value)
        {
            HttpResponseMessage msg = new HttpResponseMessage(HttpStatusCode.Conflict);
            using (ILessonService ts = new LessonService(WebApiApplication.connection))
            {
                ts.Update(id, Mapper.Map<BLL.Objects.Lesson>(value));
                msg.StatusCode = HttpStatusCode.OK;
            }
            return msg;
        }

        [HttpDelete]
        [Route("{id:int}")]
        // DELETE: api/lesson/5
        public HttpResponseMessage Delete(int id)
        {
            HttpResponseMessage msg = new HttpResponseMessage(HttpStatusCode.Conflict);
            using (ILessonService ls = new LessonService(WebApiApplication.connection))
            {
                ls.Remove(ls.Get(id));
                msg.StatusCode = HttpStatusCode.OK;
            }
            return msg;
        }
    }
}
