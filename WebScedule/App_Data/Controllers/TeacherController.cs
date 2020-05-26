using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebSchedule.Models;
using BLL.Services;
using BLL.Interfaces;
using AutoMapper;

namespace WebSchedule.Controllers
{
    [RoutePrefix("api/teacher")]
    public class TeacherController : ApiController
    {
        [Authorize(Roles = "Teacher, Admin")]
        [HttpGet]
        [Route("")]
        // GET: api/teacher
        public IEnumerable<TeacherViewModel> Get()
        {
            List<TeacherViewModel> list = new List<TeacherViewModel>();
            using (ITeacherService ts = new TeacherService(WebApiApplication.connection))
            {
                list = Mapper.Map<List<TeacherViewModel>>(ts.GetAll());
            }
            return list;
        }

        [Authorize(Roles = "Teacher, Admin")]
        [HttpGet]
        [Route("{id:int}")]
        // GET: api/teacher/5
        public TeacherViewModel Get(int id)
        {
            TeacherViewModel teacher = new TeacherViewModel();
            using (ITeacherService ts = new TeacherService(WebApiApplication.connection))
            {
                teacher = Mapper.Map<TeacherViewModel>(ts.Get(id));
            }
            return teacher;
        }

        [Authorize(Roles = "Teacher, Admin")]
        [HttpGet]
        [Route("{id:int}/lessons")]
        // GET: api/teacher/5/lessons
        public List<LessonViewModel> GetLessons(int id)
        {
            List<LessonViewModel> list = new List<LessonViewModel>();
            using (ITeacherService ts = new TeacherService(WebApiApplication.connection))
            {
                list = Mapper.Map<List<LessonViewModel>>(ts.GetLessons(id));
            }
            return list;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [Route("")]
        // POST: api/teacher
        public HttpResponseMessage Post([FromBody]Teacher value)
        {
            HttpResponseMessage msg = new HttpResponseMessage(HttpStatusCode.Conflict);
            using (ITeacherService ts = new TeacherService(WebApiApplication.connection))
            {
                ts.Add(Mapper.Map<BLL.Objects.Teacher>(value));
                msg.StatusCode = HttpStatusCode.OK;
            }
            return msg;
        }

        [Authorize(Roles = "Admin")]
        [HttpPut]
        [Route("{id:int}")]
        // PUT: api/teacher/5
        public HttpResponseMessage Put(int id, [FromBody]Teacher value)
        {
            HttpResponseMessage msg = new HttpResponseMessage(HttpStatusCode.Conflict);
            using (ITeacherService ts = new TeacherService(WebApiApplication.connection))
            {
                ts.Update(id, Mapper.Map<BLL.Objects.Teacher>(value));
                msg.StatusCode = HttpStatusCode.OK;
            }
            return msg;
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete]
        [Route("{id:int}")]
        // DELETE: api/teacher/5
        public HttpResponseMessage Delete(int id)
        {
            HttpResponseMessage msg = new HttpResponseMessage(HttpStatusCode.Conflict);
            using (ITeacherService ts = new TeacherService(WebApiApplication.connection))
            {
                ts.Remove(ts.Get(id));
                msg.StatusCode = HttpStatusCode.OK;
            }
            return msg;
        }
    }
}
