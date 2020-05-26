using BLL.Objects;
using WebSchedule.Models;
using AutoMapper;
using System.Collections.Generic;

namespace WebSchedule
{
    public class WebAPIProfile:Profile
    {
        public WebAPIProfile()
        {
            CreateMap<BLL.Objects.Group, WebSchedule.Models.Group>(MemberList.Source).PreserveReferences();
            CreateMap<BLL.Objects.Group, WebSchedule.Models.GroupViewModel>(MemberList.Destination).PreserveReferences();
            CreateMap<WebSchedule.Models.Group, BLL.Objects.Group>(MemberList.Destination).PreserveReferences();
            CreateMap<BLL.Objects.Lesson, WebSchedule.Models.Lesson >(MemberList.Source).PreserveReferences();
            CreateMap<BLL.Objects.Lesson, WebSchedule.Models.LessonViewModel>(MemberList.Destination).PreserveReferences();
            CreateMap<WebSchedule.Models.Lesson, BLL.Objects.Lesson>(MemberList.Destination).PreserveReferences();
            CreateMap<BLL.Objects.Teacher, WebSchedule.Models.Teacher>(MemberList.Source).PreserveReferences();
            CreateMap<BLL.Objects.Teacher, WebSchedule.Models.TeacherViewModel>(MemberList.Destination).PreserveReferences();
            CreateMap<WebSchedule.Models.Teacher, BLL.Objects.Teacher>(MemberList.Destination).PreserveReferences();
        }
    }
}