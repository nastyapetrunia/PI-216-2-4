using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DAL.Entities;
using BLL.Objects;

namespace BLL.AutoMapper
{
    public class BLLProfile:Profile
    {
        public BLLProfile()
        {
            CreateMap<DAL.Entities.Group, BLL.Objects.Group>(MemberList.Source).PreserveReferences();
            CreateMap<BLL.Objects.Group, DAL.Entities.Group>(MemberList.Destination).PreserveReferences();
            CreateMap<DAL.Entities.Teacher, BLL.Objects.Teacher>(MemberList.Source).PreserveReferences();
            CreateMap<BLL.Objects.Teacher, DAL.Entities.Teacher>(MemberList.Destination).PreserveReferences();
            CreateMap<DAL.Entities.Lesson, BLL.Objects.Lesson>(MemberList.Source).PreserveReferences();
            CreateMap<BLL.Objects.Lesson, DAL.Entities.Lesson>(MemberList.Destination).PreserveReferences();
        }
    }
}
