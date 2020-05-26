using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL.Services;
using BLL.Interfaces;
using WebSchedule.Models;
using AutoMapper;

namespace WebSchedule.Controllers
{
    [RoutePrefix("api/group")]
    public class GroupController : ApiController
    {
        [Authorize]
        [HttpGet]
        [Route("")]
        // GET: api/group
        public IEnumerable<GroupViewModel> Get()
        {
            List<GroupViewModel> list = new List<GroupViewModel>();
            using (IGroupService gs = new GroupService(WebApiApplication.connection))
            {
                list = Mapper.Map<List<GroupViewModel>>(gs.GetAll());
            }
            return list;
        }

        [Authorize]
        [HttpGet]
        [Route("{id:int}")]
        // GET: api/group/5
        public GroupViewModel Get(int id)
        {
            GroupViewModel group = new GroupViewModel();
            using (IGroupService gs = new GroupService(WebApiApplication.connection))
            {
                group = Mapper.Map<GroupViewModel>(gs.Get(id));
            }
            return group;
        }

        [Authorize]
        [HttpGet]
        [Route("{id:int}/lessons")]
        // GET: api/group/5/lessons
        public List<LessonViewModel> GetLessons(int id)
        {
            List<LessonViewModel> list = new List<LessonViewModel>();
            using (IGroupService gs = new GroupService(WebApiApplication.connection))
            {
                list = Mapper.Map<List<LessonViewModel>>(gs.GetLessons(id));
            }
            return list;
        }

        [Authorize(Roles="Admin")]
        [HttpPost]
        [Route("")]
        // POST: api/group
        public HttpResponseMessage Post([FromBody]Group value)
        {
            HttpResponseMessage msg = new HttpResponseMessage(HttpStatusCode.Conflict);
            using (IGroupService gs = new GroupService(WebApiApplication.connection))
            {
                gs.Add(Mapper.Map<BLL.Objects.Group>(value));
                msg.StatusCode = HttpStatusCode.OK;
            }
            return msg;
        }

        [Authorize(Roles = "Admin")]
        [HttpPut]
        [Route("{id:int}")]
        // PUT: api/group/5
        public HttpResponseMessage Put(int id, [FromBody]Group value)
        {
            HttpResponseMessage msg = new HttpResponseMessage(HttpStatusCode.Conflict);
            using (IGroupService gs = new GroupService(WebApiApplication.connection))
            {
                gs.Update(id, Mapper.Map<BLL.Objects.Group>(value));
                msg.StatusCode = HttpStatusCode.OK;
            }
            return msg;
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete]
        [Route("{id:int}")]
        // DELETE: api/group/5
        public HttpResponseMessage Delete(int id)
        {
            HttpResponseMessage msg = new HttpResponseMessage(HttpStatusCode.Conflict);
            using (IGroupService gs = new GroupService(WebApiApplication.connection))
            {
                gs.Remove(gs.Get(id));
                msg.StatusCode = HttpStatusCode.OK;
            }
            return msg;
        }
    }
}
